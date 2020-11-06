using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      KeyBoardEvent.cs
//功能描述(Description)：    键盘事件响应
//数据表(Tables)：		    无
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace MedicalSystem.UsbKeyBoard
{
    public class KeyBoardEvent
    {

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        static UInt32 POC_MAINBOARD_LED_NUM = 3;
        static UInt32 POC_SECONDBOARD_LED_NUM = 6;
        static bool sdk_init_main_once = false;
        static bool sdk_init_second_once = false;

        POC_API.keycode_event_callback OnKeycodeDelegateCallback;
        POC_API.keycode_event_callback OnKeycodeDelegateCallbackSecond;

        public delegate void KeyStandard_Event(UInt32 keycode, UInt32 Fnkeys);
        public event KeyStandard_Event KeyStandardEvent;
        public delegate void KeyFunction_Event(string keycode);
        public event KeyFunction_Event KeyFunctionEvent;
        /// <summary>
        /// 文件锁
        /// </summary>
        static ReaderWriterLockSlim logWriteLock = new ReaderWriterLockSlim();
        /// <summary>
        /// 键盘相应事件
        /// </summary>
        /// <param name="keycode"></param>
        private unsafe void keycode_event(UInt32 keycode, UInt32 Fnkeys)
        {
            #region Standard Keycode

            if (keycode <= 255)
            {
                if (KeyStandardEvent != null)
                {
                    KeyStandardEvent(keycode, Fnkeys);
                    Keys key = (Keys)keycode;
                    WriteKeyDownLog(string.Format("{0}->{1}", key, keycode));
                }

            }
            #endregion//Standard Keycode End

            #region Nonstandard Keycode
            else
            {
                byte[] bKeycode = new byte[4];
                bKeycode[0] = (byte)(keycode >> 24);
                bKeycode[1] = (byte)(keycode >> 16);
                bKeycode[2] = (byte)(keycode >> 8);
                bKeycode[3] = (byte)(keycode & 0xFF);
                string strKeycode = System.Text.Encoding.ASCII.GetString(bKeycode);

                if (KeyFunctionEvent != null)
                {
                    KeyFunctionEvent(strKeycode);
                    WriteKeyDownLog(strKeycode);
                }
            }
            #endregion//Nonstandard Keycode End
        }

        #region 虚拟键盘
        /// <summary>
        /// 本地虚拟键盘服务
        /// </summary>
        string url = "http://localhost:6300/";

        /// <summary>
        /// 关闭虚拟键盘服务
        /// </summary>
        public void StopVirtualKeyBoardService()
        {
            string data = string.Format("KeyCode=Exit");
            HttpGet(url, data);
        }
        string WebRequestDocUrl = "http://localhost:6466/";
        public void StartWebDocPicService()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(WebRequestDocUrl);
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                HttpListenerResponse response = context.Response;
                Stream outputStream = response.OutputStream;
                StreamWriter writer = new StreamWriter(outputStream);
                string patientID = request.QueryString["patientID"];
                string visitID = request.QueryString["visitID"];
                string operID = request.QueryString["operID"];
                string docName = "术前访视单"; HttpUtility.UrlDecode(request.QueryString["docName"]); ;
                ExtendAppContext.Current.PatientID = patientID;
                ExtendAppContext.Current.VisitID = Convert.ToInt32(visitID);
                ExtendAppContext.Current.OperID = Convert.ToInt32(operID);
                if (!string.IsNullOrEmpty(patientID) && !string.IsNullOrEmpty(docName))
                {
                    Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
                    KeyValuePair<string, MedicalDocElement> keyValuePairDoc = new KeyValuePair<string, MedicalDocElement>();
                    foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
                    {
                        if (keyValuePair.Key.Trim() == docName.Trim())
                        {
                            keyValuePairDoc = keyValuePair;
                            break;
                        }
                    }
                    Type t = Type.GetType(keyValuePairDoc.Value.Type);
                    BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                    baseDoc.BackColor = Color.White;
                    baseDoc.Name = docName;
                    baseDoc.Initial();
                    long l1 = System.DateTime.Now.Ticks;
                    string path = null;
                    if (MedicalDocSettings.GetMedicalDocNameAndPath().ContainsKey(docName))
                    {
                        path = MedicalDocSettings.GetMedicalDocNameAndPath()[docName].Path;
                        baseDoc.LoadReport(Path.Combine(ExtendAppContext.Current.AppPath, path));
                    }
                    long l2 = System.DateTime.Now.Ticks;
                    Console.WriteLine((l2 - l1) / 1000000);
                    if (!System.IO.Directory.Exists(string.Format(@"{0}\文书图片", Application.StartupPath)))
                        System.IO.Directory.CreateDirectory(string.Format(@"{0}\文书图片", Application.StartupPath));
                    string fileName = patientID + "_" + visitID + "_" + operID;
                    if (!System.IO.Directory.Exists(string.Format(@"{0}\文书图片\{1}", Application.StartupPath, fileName)))
                        System.IO.Directory.CreateDirectory(string.Format(@"{0}\文书图片\{1}", Application.StartupPath, fileName));
                    string jpgPath = string.Format(@"{0}\文书图片\{1}\{2}", Application.StartupPath, fileName, docName);
                    if (!System.IO.Directory.Exists(jpgPath))
                        System.IO.Directory.CreateDirectory(jpgPath);
                    else
                    {
                        System.IO.Directory.Delete(jpgPath, true);
                        System.IO.Directory.CreateDirectory(jpgPath);
                    }
                    bool isPic = baseDoc.ExportDocToWebJPG(jpgPath, docName);
                }
            }
        }
        /// <summary>
        /// 启用虚拟键盘服务
        /// </summary>
        public void StartVirtualKeyBoardService()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                HttpListenerResponse response = context.Response;
                Stream outputStream = response.OutputStream;
                StreamWriter writer = new StreamWriter(outputStream);
                try
                {
                    string KeyCode = request.QueryString["KeyCode"];
                    if (KeyCode == "Exit")//退出监听服务
                    {
                        break;
                    }
                    else if (KeyCode == "Connection")//连接服务
                    {
                        writer.WriteLine("麻醉一体机键盘已连接！");
                    }
                    else
                    {
                        if (KeyFunctionEvent != null)
                        {
                            KeyFunctionEvent(KeyCode);
                            writer.WriteLine(string.Format("KeyCode:{0}已响应", KeyCode));
                        }
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(string.Format("虚拟键盘响应异常{0}", ex.Message));
                }
                finally
                {
                    writer.Close();
                }
            }
            listener.Stop();
        }

        /// <summary>
        /// Http发送Get请求方法
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public string HttpGet(string Url, string postDataStr)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion



        /// <summary>
        /// 按键日志记录
        /// </summary>
        /// <param name="keyMsg"></param>
        private void WriteKeyDownLog(string keyMsg)
        {
            try
            {
                logWriteLock.EnterWriteLock();//锁文件，导致被占用

                string pathDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KeyBoardLog");
                if (!Directory.Exists(pathDir))
                    Directory.CreateDirectory(pathDir); //新建文件夹   

                string fileName = string.Format("KeyBoardLog\\{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                string KyeInfo = string.Format("KeyDown:{0},{1} ", keyMsg, DateTime.Now);
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(KyeInfo);
                    sw.Close();
                }
            }
            catch (Exception)
            { }
            finally
            {
                logWriteLock.ExitWriteLock();//关闭锁
            }
        }

        /// <summary>
        /// 载入键盘
        /// </summary>
        public void LoadKeyBoard()
        {
            InitMainKeyBoard();
            InitSecondKeyBoard();

            //默认开启英文键盘灯
            SetMainKeyboardLedStatus(0, false);//大写
            SetMainKeyboardLedStatus(1, false);//中文
            SetMainKeyboardLedStatus(2, true);//英文
        }

        /// <summary>
        /// 初始化主键盘
        /// </summary>
        private void InitMainKeyBoard()
        {
            UInt32 LastErrCode;

            byte[] sdk_version = new byte[POC_API.HIT_MAX_LIB_VER_STR_LENGTH];
            LastErrCode = POC_API.poc_get_version(POC_API.POC_KEYBOARD_PID, sdk_version);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                //弹框
                Console.WriteLine("MainKeyBoard Fails to get SDK version " + TranslateErrorCode(LastErrCode));
                return;
            }
            Console.WriteLine("MainKeyBoard SDK Version:" + System.Text.Encoding.ASCII.GetString(sdk_version));


            LastErrCode = POC_API.poc_init(POC_API.POC_KEYBOARD_PID);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {//弹框
                Console.WriteLine("MainKeyBoard Fails to init library " + TranslateErrorCode(LastErrCode));
                return;
            }
            else
            {
                sdk_init_main_once = true;
            }

            byte[] fw_version = new byte[POC_API.HIT_MAX_FW_VER_STR_LENGTH];
            LastErrCode = POC_API.poc_get_firmware_version(POC_API.POC_KEYBOARD_PID, fw_version);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                Console.WriteLine("MainKeyBoard Firmware Version:Unknown");
            }
            else
            {
                Console.WriteLine("MainKeyBoard Firmware Version" + System.Text.Encoding.ASCII.GetString(fw_version));
            }

            byte[] board_name = new byte[POC_API.HIT_MAX_BOARD_NAME_STR_LENGTH];
            LastErrCode = POC_API.poc_get_board_name(POC_API.POC_KEYBOARD_PID, board_name);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                Console.WriteLine("MainKeyBoard Board Name:Unknown");
            }
            else
            {
                Console.WriteLine("MainKeyBoard Board Name:" + System.Text.Encoding.ASCII.GetString(board_name));
            }

            unsafe
            {
                OnKeycodeDelegateCallback = new POC_API.keycode_event_callback(keycode_event);
            }
            LastErrCode = POC_API.poc_set_keycode_callback(POC_API.POC_KEYBOARD_PID, OnKeycodeDelegateCallback);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                //弹框
                Console.WriteLine("Fails poc set keycode callback: " + LastErrCode.ToString("X8"));
            }
        }
        /// <summary>
        /// 初始化第二键盘
        /// </summary>
        private void InitSecondKeyBoard()
        {
            UInt32 LastErrCode;

            byte[] sdk_version = new byte[POC_API.HIT_MAX_LIB_VER_STR_LENGTH];
            LastErrCode = POC_API.poc_get_version(POC_API.POC_KEYBOARD_PID_SECOND, sdk_version);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                //弹框
                Console.WriteLine("SecondKeyBoard Fails to get SDK version " + TranslateErrorCode(LastErrCode));
                return;
            }

            Console.WriteLine("SecondKeyBoard Version" + System.Text.Encoding.ASCII.GetString(sdk_version));

            LastErrCode = POC_API.poc_init(POC_API.POC_KEYBOARD_PID_SECOND);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                //弹框
                Console.WriteLine("SecondKeyBoard Fails to init library " + TranslateErrorCode(LastErrCode));
                return;
            }
            else
            {
                sdk_init_second_once = true;
            }

            byte[] fw_version = new byte[POC_API.HIT_MAX_FW_VER_STR_LENGTH];
            LastErrCode = POC_API.poc_get_firmware_version(POC_API.POC_KEYBOARD_PID_SECOND, fw_version);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                Console.WriteLine("SecondKeyBoard Firmware Version:Unknown");
            }
            else
            {
                Console.WriteLine("SecondKeyBoard Firmware Version:" + System.Text.Encoding.ASCII.GetString(fw_version));
            }

            byte[] board_name = new byte[POC_API.HIT_MAX_BOARD_NAME_STR_LENGTH];
            LastErrCode = POC_API.poc_get_board_name(POC_API.POC_KEYBOARD_PID_SECOND, board_name);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                Console.WriteLine("SecondKeyBoard Board Name:Unknown");
            }
            else
            {
                Console.WriteLine("SecondKeyBoard Board Name:" + System.Text.Encoding.ASCII.GetString(board_name));
            }

            unsafe
            {
                OnKeycodeDelegateCallbackSecond = new POC_API.keycode_event_callback(keycode_event);
            }
            LastErrCode = POC_API.poc_set_keycode_callback(POC_API.POC_KEYBOARD_PID_SECOND, OnKeycodeDelegateCallbackSecond);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                //弹框
                Console.WriteLine("Fails poc set keycode callback: " + LastErrCode.ToString("X8"));
            }
        }

        private string TranslateErrorCode(UInt32 LastErrCode)
        {
            switch (LastErrCode)
            {
                case POC_API.POC_ERR_USBHID_IS_BUSY:
                    return "Deivce is busy, try again";

                default:
                    return LastErrCode.ToString("X8");
            }
        }

        /// <summary>
        /// 卸载键盘
        /// </summary>
        public void UnLoadKeyBoard()
        {
            CloseSecondKeyBoardAllLed();
            CloseMainKeyBoardAllLed();
            if (sdk_init_main_once && sdk_init_second_once)
            {
                UInt32 LastErrCode = POC_API.poc_deinit(POC_API.POC_KEYBOARD_PID);
                if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                {
                    //弹框
                    Console.WriteLine("Fails to deinit library " + TranslateErrorCode(LastErrCode));
                }
            }
        }

        #region 主键盘LED

        /// <summary>
        /// 获取主键盘LED灯状态
        /// </summary>
        /// <param name="ledNumber">键盘灯编号 0 1 2</param>
        /// <returns></returns>
        public byte GetMainKeyboardLedStatus(int ledNumber)
        {
            if (!sdk_init_main_once)
                return 0;
            UInt32 LastErrCode;
            byte ledStatus;
            switch (ledNumber)
            {
                case 0:
                    //LED 1
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN1, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 1, " + LastErrCode.ToString("X8"));
                    }
                    break;
                case 1:
                    //LED 2
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN2, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 2, " + LastErrCode.ToString("X8"));
                    }
                    break;
                case 2:
                    //LED 3
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN3, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 3, " + LastErrCode.ToString("X8"));
                    }
                    break;
                default:
                    ledStatus = 0;
                    break;
            }
            return ledStatus;
        }

        /// <summary>
        /// 设置主键盘LED灯
        /// </summary>
        /// <param name="ledNumber">0 1 2 </param>
        public bool SetMainKeyboardLedStatus(int ledNumber, bool isOpen)
        {
            if (!sdk_init_main_once)
                return false;
            UInt32 LastErrCode;
            bool result = false;
            switch (ledNumber)
            {
                case 0:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN1);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN1);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
                case 1:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN2);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN2);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
                case 2:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN3);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID, POC_API.led_enum.POC_LED_PIN3);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
            }
            return result;
        }


        /// <summary>
        /// 同时打开主键盘LED
        /// </summary>
        /// <param name="ledCount">1 2 3</param>
        public void OpenMainKeyBoardAllLed(int ledCount)
        {
            if (!sdk_init_second_once)
                return;
            UInt32 LastErrCode;
            bool[] LedID = new bool[POC_MAINBOARD_LED_NUM];

            for (int i = 0; i < ledCount; i++)
            {
                LedID[i] = true;
            }
            LastErrCode = POC_API.poc_set_all_led_status(POC_API.POC_KEYBOARD_PID, POC_MAINBOARD_LED_NUM, LedID);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set all led " + LastErrCode.ToString("X8"));
                return;
            }
        }

        /// <summary>
        /// 同时关闭主键盘LED
        /// </summary>
        public void CloseMainKeyBoardAllLed()
        {
            if (!sdk_init_second_once)
                return;
            UInt32 LastErrCode;
            bool[] LedID = new bool[3] { false, false, false };

            LastErrCode = POC_API.poc_set_all_led_status(POC_API.POC_KEYBOARD_PID, POC_MAINBOARD_LED_NUM, LedID);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                MessageBox.Show("Fails to set all led " + LastErrCode.ToString("X8"));
        }

        #endregion

        #region 第二键盘LED
        /// <summary>
        /// 获取第二键盘LED灯状态
        /// </summary>
        /// <param name="ledNumber">0 1 2 3 4 5</param>
        /// <returns></returns>
        public byte GetSecondKeyboardLedStatus(int ledNumber)
        {
            if (!sdk_init_second_once)
                return 0;

            UInt32 LastErrCode;

            byte ledStatus;

            switch (ledNumber)
            {
                case 0:
                    //LED 1
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN1, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 1, " + LastErrCode.ToString("X8"));
                    }
                    break;
                case 1:
                    //LED 2
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN2, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 2, " + LastErrCode.ToString("X8"));
                    }

                    break;
                case 2:
                    //LED 3
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN3, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 3, " + LastErrCode.ToString("X8"));
                    }
                    break;
                case 3:
                    //LED 4
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN4, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 4, " + LastErrCode.ToString("X8"));
                    }
                    break;
                case 4:
                    //LED 5
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN5, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 5, " + LastErrCode.ToString("X8"));
                    }
                    break;
                case 5:
                    //LED 6
                    LastErrCode = POC_API.poc_get_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN6, out ledStatus);
                    if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                    {
                        //弹框
                        Console.WriteLine("Fails to get HIT_LED_PIN 6, " + LastErrCode.ToString("X8"));
                    }
                    break;
                default:
                    ledStatus = 0;
                    break;
            }

            //if (ledStatus == 1)
            //{
            //    SecondKeyBoardArr[ledNumber] = true;
            //}
            return ledStatus;
        }

        /// <summary>
        /// 设置第二键盘LED灯
        /// </summary>
        /// <param name="ledNumber">0 1 2 3 4 5</param>
        public bool SetSecondKeyboardLedStatus(int ledNumber, bool isOpen)
        {
            if (!sdk_init_second_once)
                return false;
            UInt32 LastErrCode;

            bool result = false;
            switch (ledNumber)
            {
                case 0:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN1);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN1);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
                case 1:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN2);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN2);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
                case 2:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN3);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN3);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
                case 3:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN4);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN4);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
                case 4:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN5);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN5);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
                case 5:
                    if (isOpen)
                    {
                        LastErrCode = POC_API.poc_led_on(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN6);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    else
                    {
                        LastErrCode = POC_API.poc_led_off(POC_API.POC_KEYBOARD_PID_SECOND, POC_API.led_enum.POC_LED_PIN6);
                        if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                            //弹框
                            Console.WriteLine("Fails to set HIT_LED_PIN " + LastErrCode.ToString("X8"));
                        else
                            result = true;
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// 同时打开第二键盘LED
        /// </summary>
        /// <param name="ledCount">1 2 3 4 5 6 </param>
        public void OpenSecondKeyBoardAllLed(int ledCount)
        {
            if (!sdk_init_second_once)
                return;
            UInt32 LastErrCode;
            bool[] LedID = new bool[6];

            for (int i = 0; i < ledCount; i++)
            {
                LedID[i] = true;
            }
            LastErrCode = POC_API.poc_set_all_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_SECONDBOARD_LED_NUM, LedID);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                MessageBox.Show("Fails to set all led " + LastErrCode.ToString("X8"));
            return;
        }

        /// <summary>
        /// 同时关闭第二键盘LED
        /// </summary>
        public void CloseSecondKeyBoardAllLed()
        {
            if (!sdk_init_second_once)
                return;
            UInt32 LastErrCode;
            bool[] LedID = new bool[6] { false, false, false, false, false, false };

            LastErrCode = POC_API.poc_set_all_led_status(POC_API.POC_KEYBOARD_PID_SECOND, POC_SECONDBOARD_LED_NUM, LedID);
            if (LastErrCode != POC_API.POC_ERR_NO_ERROR)
                MessageBox.Show("Fails to set all led " + LastErrCode.ToString("X8"));
        }
        #endregion
    }
}
