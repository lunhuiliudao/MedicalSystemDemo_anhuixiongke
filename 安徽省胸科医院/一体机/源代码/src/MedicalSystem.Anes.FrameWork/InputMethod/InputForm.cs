using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using System.Reflection;
using System.Drawing.Drawing2D;
using MedicalSystem.Anes.Client.FrameWork.Properties;
namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class InputForm : Form
    {
        // [DllImport("user32", EntryPoint = "HideCaret")]
        // private static extern bool HideCaret(IntPtr hWnd);
        //void textBoxInput_GotFocus(object sender, EventArgs e)
        //{
        //    HideCaret((sender as TextBox).Handle);
        //}
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #region 属性变量
        /// <summary>
        /// 字典路径
        /// </summary>
        string path = @"\输入法测试\词库";
        /// <summary>
        /// 词频文件
        /// </summary>
        string FrequencyFile = @"\输入法测试\词库\词频.txt";
        /// <summary>
        /// 词频
        /// </summary>
        Dictionary<string, int> FrequencyDict = new Dictionary<string, int>();
        /// <summary>
        /// 字典库
        /// </summary>
        List<string[]> ListDict = new List<string[]>();
        /// <summary>
        /// 词库索引字典
        /// </summary>
        Dictionary<string, List<DicIndex>> ListDicIndex = new Dictionary<string, List<DicIndex>>();
        /// <summary>
        /// 搜索结果
        /// </summary>
        List<Word> ListResult = new List<Word>();

        /// <summary>
        /// 字符字典类
        /// </summary>
        Dictionary<string, string> SymbolDic = new Dictionary<string, string>();

        /// <summary>
        /// CN9对应NO和字母
        /// </summary>
        Dictionary<int, string[]> KeyDic = new Dictionary<int, string[]>();
        /// <summary>
        /// CN9NO键按下记录
        /// </summary>
        List<int> keyNumberList = new List<int>();
        /// <summary>
        /// CN9组合
        /// </summary>
        Stack<string> keyStack = new Stack<string>();

        /// <summary>
        /// 翻页开始索引
        /// </summary>
        int startIndex = 0;
        /// <summary>
        /// 翻页结束索引
        /// </summary>
        int endIndex = 0;
        /// <summary>
        /// 当前选中内容
        /// </summary>
        public int selectedIndex = 0;

        /// <summary>
        /// 默认CN输入法
        /// </summary>
        InputMethodType.InputType inputType = InputMethodType.InputType.NO;

        /// <summary>
        /// 设置或获得输入法当前状态
        /// </summary>
        public InputMethodType.InputType InputType
        {
            get
            {
                return inputType;
            }
            set
            {
                inputType = value;
                switch (inputType)
                {
                    case InputMethodType.InputType.NO://数字
                        btnInputType.Text = "数";
                        break;
                    case InputMethodType.InputType.EN://英文
                        btnInputType.Text = "英";
                        break;
                    case InputMethodType.InputType.CN://中文
                        btnInputType.Text = "中";
                        break;
                    case InputMethodType.InputType.ENUpper://大写
                        btnInputType.Text = "大";
                        break;
                    case InputMethodType.InputType.NULL://关闭
                        btnInputType.Text = "关";
                        break;
                }
            }
        }

        IntPtr _ParentForm;
        /// <summary>
        /// 当前激活窗体
        /// </summary>
        public new IntPtr ParentForm
        {
            get
            {
                return _ParentForm;
            }
            set
            {
                _ParentForm = value;
                SetForegroundWindow(value);
            }
        }

        /// <summary>
        /// 最终结果
        /// </summary>
        string _resultStr = string.Empty;

        /// <summary>
        /// 最终结果
        /// </summary>
        public string ResultStr
        {
            set { _resultStr = value; }
            get { return _resultStr; }
        }

        /// <summary>
        /// 符号菜单
        /// </summary>
        ContextMenuStrip symbolMenu = new ContextMenuStrip();

        /// <summary>
        /// 启用调试，显示所有拼音
        /// </summary>
        bool IsDebug = false;
        #endregion

        #region 将当前窗体指定为浮动工具条窗体
        public enum WindowStyles : uint
        {
            WS_OVERLAPPED = 0x00000000,
            WS_POPUP = 0x80000000,
            WS_CHILD = 0x40000000,
            WS_MINIMIZE = 0x20000000,
            WS_VISIBLE = 0x10000000,
            WS_DISABLED = 0x08000000,
            WS_CLIPSIBLINGS = 0x04000000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_MAXIMIZE = 0x01000000,
            WS_BORDER = 0x00800000,
            WS_DLGFRAME = 0x00400000,
            WS_VSCROLL = 0x00200000,
            WS_HSCROLL = 0x00100000,
            WS_SYSMENU = 0x00080000,
            WS_THICKFRAME = 0x00040000,
            WS_GROUP = 0x00020000,
            WS_TABSTOP = 0x00010000,

            WS_MINIMIZEBOX = 0x00020000,
            WS_MAXIMIZEBOX = 0x00010000,

            WS_CAPTION = WS_BORDER | WS_DLGFRAME,
            WS_TILED = WS_OVERLAPPED,
            WS_ICONIC = WS_MINIMIZE,
            WS_SIZEBOX = WS_THICKFRAME,
            WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
            WS_CHILDWINDOW = WS_CHILD,

            //Extended Window Styles

            WS_EX_DLGMODALFRAME = 0x00000001,
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_ACCEPTFILES = 0x00000010,
            WS_EX_TRANSPARENT = 0x00000020,

            //#if(WINVER >= 0x0400)

            WS_EX_MDICHILD = 0x00000040,
            WS_EX_TOOLWINDOW = 0x00000080,
            WS_EX_WINDOWEDGE = 0x00000100,
            WS_EX_CLIENTEDGE = 0x00000200,
            WS_EX_CONTEXTHELP = 0x00000400,

            WS_EX_RIGHT = 0x00001000,
            WS_EX_LEFT = 0x00000000,
            WS_EX_RTLREADING = 0x00002000,
            WS_EX_LTRREADING = 0x00000000,
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            WS_EX_RIGHTSCROLLBAR = 0x00000000,

            WS_EX_CONTROLPARENT = 0x00010000,
            WS_EX_STATICEDGE = 0x00020000,
            WS_EX_APPWINDOW = 0x00040000,

            WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
            WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),

            //#endif /* WINVER >= 0x0400 */

            //#if(WIN32WINNT >= 0x0500)

            WS_EX_LAYERED = 0x00080000,

            //#endif /* WIN32WINNT >= 0x0500 */

            //#if(WINVER >= 0x0500)

            WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
            WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring

            //#endif /* WINVER >= 0x0500 */

            //#if(WIN32WINNT >= 0x0500)

            WS_EX_COMPOSITED = 0x02000000,
            WS_EX_NOACTIVATE = 0x08000000

            //#endif /* WIN32WINNT >= 0x0500 */

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams ret = base.CreateParams;
                ret.Style = (int)WindowStyles.WS_THICKFRAME | (int)WindowStyles.WS_CHILD;
                ret.ExStyle |= (int)WindowStyles.WS_EX_NOACTIVATE | (int)WindowStyles.WS_EX_TOOLWINDOW;
                ret.X = this.Location.X;
                ret.Y = this.Location.Y;
                return ret;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public InputForm()
        {
            InitializeComponent();
            this.TopMost = true;
            path = System.Windows.Forms.Application.StartupPath + "\\InputMethod\\WordLibrary";
            FrequencyFile = path + "\\词频.txt";
            LoadData();//载入字典
        }

        /// <summary>
        /// 启动载入参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputForm_Load(object sender, EventArgs e)
        {
            this.listBoxResult.DrawMode = DrawMode.OwnerDrawFixed;
            this.listBoxResult.DrawItem += new DrawItemEventHandler(ResultList_DrawItem);
            //LoadData();
        }

        /// <summary>
        /// 载入数据，包括字典，建立索引
        /// </summary>
        public void LoadData()
        {
            //加载CN9按键字典
            string[] keyNunber = new string[] { "", "", "a,b,c", "d,e,f", "g,h,i", "j,k,l", "m,n,o", "p,q,r,s", "t,u,v", "w,x,y,z" };
            for (int i = 1; i < keyNunber.Length; i++)
            {
                KeyDic.Add(i, keyNunber[i].Split(','));
            }
            //字符类
            InitSymbolList();
            #region 载入字典
            if (Directory.Exists(path))
            {
                String[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                int index = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    StreamReader sr = new StreamReader(files[i], Encoding.UTF8);
                    String line;
                    string[] temp = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (files[i].EndsWith("词频.txt"))
                        {
                            temp = line.ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                            if (temp.Length == 2)//记在词频 
                                FrequencyDict.Add(temp[0], Convert.ToInt32(temp[1]));//记录下次数
                        }
                        else
                        {
                            temp = line.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            ListDict.Add(temp);
                            CreateIndex(files[i], temp[0].Substring(1, 1), index);
                            index++;
                        }
                    }
                    sr.Close();
                }
            }
            #endregion
        }

        /// <summary>
        /// 创建字典索引
        /// </summary>
        /// <param name="key">字典文件</param>
        /// <param name="startStr">开始拼音</param>
        /// <param name="index">当前累索引</param>
        private void CreateIndex(string key, string startStr, int index)
        {
            if (ListDicIndex.ContainsKey(key))
            {
                for (int i = 0; i < ListDicIndex[key].Count; i++)
                {
                    if (ListDicIndex[key][i].StartStr == startStr)//相同字符开始记录索引
                    {
                        ListDicIndex[key][i].EndIndex = index;
                        return;
                    }
                }
                //同一个字库新加入一个开始位置
                ListDicIndex[key].Add(new DicIndex(key, startStr, index, index + 1));
            }
            else
            {
                //另起一个新的词库
                List<DicIndex> newList = new List<DicIndex>();
                newList.Add(new DicIndex(key, startStr, index, index + 1));
                ListDicIndex.Add(key, newList);
            }
        }

        /// <summary>
        /// 初始化字符列表
        /// </summary>
        private void InitSymbolList()
        {   //存放字符

            for (int i = 0; i < Syllable.FuStrArr.Length; i++)
            {
                SymbolDic.Add("字符" + (i + 1) + Syllable.FuStrArr[i].Substring(0, 5), Syllable.FuStrArr[i]);
                ToolStripMenuItem tsmi = new ToolStripMenuItem("字符" + (i + 1) + Syllable.FuStrArr[i].Substring(0, 5));
                symbolMenu.Items.Add(tsmi);
            }
            symbolMenu.Font = new Font("微软雅黑", 15);
            this.listBoxResult.ContextMenuStrip = symbolMenu;
        }

        /// <summary>
        /// 显示符号
        /// </summary>
        /// <returns></returns>
        private void ShowSymbolMenu()
        {
            this.Show();
            symbolMenu.Show(listBoxResult, new Point(listBoxResult.Left, listBoxResult.Top));
        }
        /// <summary>
        /// 关闭窗口记录词频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveFrequency();
        }

        /// <summary>
        ///  保存词频
        /// </summary>
        public void SaveFrequency()
        {
            FileStream fs = new FileStream(FrequencyFile, FileMode.Create);
            foreach (KeyValuePair<string, int> kv in FrequencyDict)
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(kv.Key + "|" + kv.Value + "\r\n");
                //开始写入
                fs.Write(data, 0, data.Length);
            }
            fs.Close();
        }

        /// <summary>
        /// 字符菜单选择
        /// </summary>
        void GetSymbolSelect(string menuText)
        {
            for (int i = 0; i < SymbolDic[menuText].Length; i++)
            {
                Word w = new Word();
                w.Words = SymbolDic[menuText].Substring(i, 1);
                w.Counts = 0;
                ListResult.Add(w);
            }
            //每页最多显示9个
            startIndex = 0;
            if (ListResult.Count > 9)
            {
                endIndex = 9;
                btnNext.Enabled = true;
            }
            else
            {
                endIndex = ListResult.Count;
            }
            DisplayResult(startIndex, endIndex);
        }

        /// <summary>
        /// 全键盘输入法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            //InputKeys(e.KeyCode);
        }
        /// <summary>
        /// 输入法内容颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ResultList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            ListBox list = (ListBox)sender;
            string[] strArr = list.Items[e.Index].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (strArr.Length <= 0)
            {
                return;
            }
            StringBuilder sbstart = new StringBuilder();
            StringBuilder sbmid = new StringBuilder();
            StringBuilder sblast = new StringBuilder();

            if (selectedIndex > 0)
            {
                //前半段
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (i < selectedIndex)
                        sbstart.Append(strArr[i] + " ");
                }
            }
            for (int i = 0; i < strArr.Length; i++)    //选中部分
            {
                if (i == selectedIndex)
                    sbmid.Append(strArr[i] + " ");
            }
            for (int i = selectedIndex + 1; i < strArr.Length; i++) //后半段
            {
                if (i != selectedIndex)
                    sblast.Append(strArr[i] + " ");
            }
            e.DrawBackground();

            Rectangle bound = new Rectangle((int)e.Graphics.MeasureString(strArr[selectedIndex], listBoxResult.Font).Width, 0, e.Bounds.Width, e.Bounds.Height);
            Brush myBrush = Brushes.Blue;
            int left = 0;//左边距

            if (!string.IsNullOrEmpty(sbstart.ToString()))//前半段颜色
            {
                bound = new Rectangle(left, 0, e.Bounds.Width, e.Bounds.Height);
                e.Graphics.DrawString(sbstart.ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                left = (int)e.Graphics.MeasureString(sbstart.ToString(), listBoxResult.Font).Width;
            }
            myBrush = Brushes.Red; //选中颜色
            bound = new Rectangle(left, 0, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawString(strArr[selectedIndex], e.Font, myBrush, bound, StringFormat.GenericDefault);
            left += (int)e.Graphics.MeasureString(strArr[selectedIndex], listBoxResult.Font).Width;

            myBrush = Brushes.Blue;    //后半段颜色
            bound = new Rectangle(left, 0, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawString(sblast.ToString(), e.Font, myBrush, bound, StringFormat.GenericDefault);
            e.DrawFocusRectangle();

            int width = (int)e.Graphics.MeasureString(list.Items[e.Index].ToString(), listBoxResult.Font).Width + 50;
            this.Width = width < 500 ? 500 : width;
        }

        /// <summary>
        /// 初始化变量
        /// </summary>
        private void InitVariable()
        {
            listBoxResult.Items.Clear();
            ListResult.Clear();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnPrevious.Image = Resources.InputMethodLeft1;
            btnNext.Image = Resources.InputMethodRight1;
            selectedIndex = 0;
            if (inputType != InputMethodType.InputType.CN)
                textBoxInput.Text = string.Empty;
        }

        #region 输入法 删除，选择，确认，翻页
        /// <summary>
        /// 删除键
        /// </summary>
        private void DeleteKey()
        {
            if (!string.IsNullOrEmpty(textBoxInput.Text))
            {
                if (inputType == InputMethodType.InputType.CN9)
                {
                    DeleteGroupPinyin();
                    textBoxInput.Text = GetGroupPinyin();
                }
                else
                {
                    textBoxInput.Text = Back(textBoxInput.Text);
                    if (inputType == InputMethodType.InputType.CN)
                    {
                        FindString(new string[] { textBoxInput.Text });
                    }
                    if (string.IsNullOrEmpty(textBoxInput.Text))
                        this.Hide();
                }
            }
            else
            {
                if (keyNumberList.Count > 0)
                {
                    DeleteGroupPinyin();
                }
                else
                {
                    KeybdEvent(Keys.Back);
                }
            }
        }

        /// <summary>
        /// 删除CN9
        /// </summary>
        /// <param name="keyIndex"></param>
        private void DeleteGroupPinyin()
        {
            keyStack.Clear();
            if (keyNumberList.Count > 0)
            {
                keyNumberList.RemoveAt(keyNumberList.Count - 1);
            }
            foreach (int item in keyNumberList)
            {
                SetGroupPinyin(item);
            }
            if (keyNumberList.Count <= 0)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 退格键
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string Back(string value)
        {
            value = value.Substring(0, value.Length - 1);
            if (!string.IsNullOrEmpty(value) && value.Substring(value.Length - 1) == "'")
            {
                value = value.Substring(0, value.Length - 1);
            }
            return value;
        }

        /// <summary>
        /// 下一个选择
        /// </summary>
        private void NextChoice()
        {
            if (ListResult.Count == 0)//发送光标向右
            {
                KeybdEvent(Keys.Right);
            }
            else
            {
                if (selectedIndex < endIndex - startIndex - 1)
                {
                    selectedIndex++;
                }
                listBoxResult.Refresh();
            }
        }

        /// <summary>
        /// 前一个选择
        /// </summary>
        private void PreviousChoice()
        {
            if (ListResult.Count == 0)//发送光标向左
            {
                KeybdEvent(Keys.Left);
            }
            else
            {
                if (selectedIndex > 0)
                {
                    selectedIndex--;
                }
                listBoxResult.Refresh();
            }
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void PreviousPage()
        {
            startIndex -= 9;
            endIndex -= (endIndex % 9 == 0 ? 9 : endIndex % 9);
            endIndex = endIndex <= 9 ? 9 : endIndex;
            selectedIndex = 0;
            btnNext.Enabled = true;
            btnNext.Image = Resources.InputMethodRight2;
            if (startIndex <= 0)
            {
                btnPrevious.Enabled = false;
                btnPrevious.Image = Resources.InputMethodLeft1;
            }
            DisplayResult(startIndex, endIndex);

        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void NextPage()
        {
            startIndex += 9;
            endIndex += 9;
            selectedIndex = 0;
            btnPrevious.Enabled = true;
            btnPrevious.Image = Resources.InputMethodLeft2;
            if (endIndex >= ListResult.Count)
            {
                btnNext.Enabled = false;
                btnNext.Image = Resources.InputMethodRight1;
                endIndex = ListResult.Count;
            }
            DisplayResult(startIndex, endIndex);

        }

        /// <summary>
        /// 确认选择
        /// </summary>
        private void EnterChoice(Keys key)
        {
            if (listBoxResult.Items.Count > 0)
            {
                _resultStr = ListResult[startIndex + selectedIndex].Words;
                //字典记录: 'xi'huan'bian'cheng 喜欢编程
                if (ListResult[startIndex + selectedIndex].Key != null)
                {
                    AddFrequencyDict(ListResult[startIndex + selectedIndex].Key);
                }
                textBoxInput.Text = "";
                SendResult(_resultStr);

                if (this.inputType == InputMethodType.InputType.CN9 || this.inputType == InputMethodType.InputType.CN)
                    SaveFrequency();//保存词频
            }
            else
            {
                KeybdEvent(key);
            }
            InitVariable();
            keyStack.Clear();
            keyNumberList.Clear();
            listBoxGroup.Items.Clear();

        }

        /// <summary>
        /// 输入数字是否是选择状态
        /// </summary>
        /// <returns></returns>
        public bool ChoiceStatus()
        {
            if (listBoxResult.Items.Count > 0)
                return true;
            else
                return false;
        }

        InputMethodType.InputType inputTypeTemp = InputMethodType.InputType.NO;

        /// <summary>
        /// 发送结果到焦点
        /// </summary>
        /// <param name="result"></param>
        private void SendResult(string result)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(100);
            this.Hide();
            inputTypeTemp = inputType;
            inputType = InputMethodType.InputType.NO;
            SendKeys.SendWait(result);
            inputType = inputTypeTemp;
            //  Console.WriteLine("输入法SendResult");
        }

        /// <summary>
        /// 键盘keybd_event
        /// </summary>
        /// <param name="key"></param>
        private void KeybdEvent(Keys key)
        {
            //Application.DoEvents();
            //System.Threading.Thread.Sleep(100);
            if (inputType != InputMethodType.InputType.Symbol)
            {
                this.Hide();

                switch (key)
                {
                    case Keys.Up:
                        SendResult("{Up}");
                        break;
                    case Keys.Left:
                        SendResult("{Left}");
                        break;
                    case Keys.Down:
                        SendResult("{Down}");
                        break;
                    case Keys.Right:
                        SendResult("{Right}");
                        break;
                    default:
                        SendResult(KeyCodeToChar(key).ToString());
                        break;
                }
                //keybd_event((byte)key, 0, 0x0, 0);
                //keybd_event((byte)key, 0, 0x2, 0);
                // Console.WriteLine("输入法KeybdEvent");
            }
        }

        [DllImport("user32.dll")]
        static extern int MapVirtualKey(uint uCode, uint uMapType);
        private static char KeyCodeToChar(Keys k)
        {
            int nonVirtualKey = MapVirtualKey((uint)k, 2);
            char mappedChar = Convert.ToChar(nonVirtualKey);
            return mappedChar;
        }

        /// <summary>
        /// 显示当前页输入法内容
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private string DisplayResult(int start, int end)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            int count = 1;
            listBoxResult.Items.Clear();
            for (int i = start; i < end; i++)
            {
                sb.Append(count + "." + ListResult[i].Words + " ");
                count++;
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                listBoxResult.Items.Add(sb.ToString());
                result = ListResult[start].PinYinStr;
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 词频个数新增
        /// </summary>
        /// <param name="key"></param>
        private void AddFrequencyDict(string key)
        {
            if (inputType == InputMethodType.InputType.CN9 || inputType == InputMethodType.InputType.CN)
            {
                if (FrequencyDict.ContainsKey(key))
                {
                    FrequencyDict[key] += 1;
                }
                else
                {
                    FrequencyDict[key] = 1;
                }
                //词频进行倒序排序
                FrequencyDict = FrequencyDict.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);
            }
        }

        /// <summary>
        /// 输入Key
        /// </summary>
        /// <param name="key"></param>
        public void InputKeys(Keys key)
        {
            switch (key)
            {
                case Keys.Back://删除按钮
                    DeleteKey();
                    break;
                case Keys.Right: //选择字
                    NextChoice();
                    break;
                case Keys.Left://选择字
                    PreviousChoice();
                    break;
                case Keys.Up://上一页
                    if (ListResult.Count == 0)//发送光标向上
                    {
                        KeybdEvent(Keys.Up);
                    }
                    else if (btnPrevious.Enabled)
                    {
                        PreviousPage();
                    }
                    else if (inputType == InputMethodType.InputType.Symbol)
                    {
                        KeybdEvent(Keys.Up);
                    }
                    break;
                case Keys.Down://下一页
                    if (ListResult.Count == 0)//发送光标向右
                    {
                        KeybdEvent(Keys.Down);
                    }
                    else if (btnNext.Enabled)
                    {
                        NextPage();
                    }
                    else if (inputType == InputMethodType.InputType.Symbol)
                    {
                        KeybdEvent(Keys.Down);
                    }
                    break;
                case Keys.Space://选择
                case Keys.Enter://选择
                    if (inputType == InputMethodType.InputType.Symbol)//字符选择
                    {
                        for (int i = 0; i < symbolMenu.Items.Count; i++)
                        {
                            if (symbolMenu.Items[i].Selected)
                            {
                                GetSymbolSelect(symbolMenu.Items[i].Text);
                                break;
                            }
                        }
                        symbolMenu.Hide();
                        inputType = InputMethodType.InputType.NO;
                    }
                    else
                    {
                        EnterChoice(key);
                    }
                    break;
                case Keys.F1://数字
                    this.inputType = InputMethodType.InputType.NO;
                    btnInputType.Text = "数";
                    break;
                case Keys.F2://英文
                    this.inputType = InputMethodType.InputType.EN;
                    btnInputType.Text = "英";
                    break;
                case Keys.F3://中文
                    this.inputType = InputMethodType.InputType.CN;
                    btnInputType.Text = "中";
                    break;
                case Keys.F4://大写
                    this.inputType = InputMethodType.InputType.ENUpper;
                    btnInputType.Text = "大";
                    break;
                case Keys.F5://符号
                    if (this.inputType == InputMethodType.InputType.Symbol)
                    {
                        symbolMenu.Hide();
                        this.Hide();
                        this.inputType = InputMethodType.InputType.NO;
                    }
                    else
                    {
                        this.inputType = InputMethodType.InputType.Symbol;
                        ShowSymbolMenu();
                    }
                    break;
                case Keys.F7://大写
                    if (this.inputType == InputMethodType.InputType.CN)
                    {
                        this.inputType = InputMethodType.InputType.EN;
                        btnInputType.Text = "英";
                    }
                    else
                    {
                        this.inputType = InputMethodType.InputType.CN;
                        btnInputType.Text = "中";
                    }
                    break;
                default:
                    SetInputKey((int)key);
                    break;
            }

        }

        /// <summary>
        /// 输入接受字符
        /// </summary>
        /// <param name="keyCode"></param>
        private void SetInputKey(int keyCode)
        {
            string inputStr = Convert.ToChar(keyCode).ToString().ToLower();//输入字母
            string inputStrNumber = string.Empty;

            //输入法输入切换
            if (keyCode == (int)Keys.F1 || keyCode == (int)Keys.F2 || keyCode == (int)Keys.F3 || keyCode == (int)Keys.F4 || keyCode == (int)Keys.F5)
            {
                keyStack.Clear();//清空原先输入内容
                keyNumberList.Clear();
                InitVariable();
            }
            else if (keyCode == (int)Keys.F6)//小数点
            {
                if (inputType == InputMethodType.InputType.CN9 || inputType == InputMethodType.InputType.CN)
                {
                    SendResult("。");
                }
                else
                {
                    SendResult(".");
                }
            }
            else if (keyCode == (int)Keys.Enter)
            {
                if (ListResult.Count == 0)//发送回车键
                {
                    KeybdEvent(Keys.Enter);
                }
            }
            else if (keyCode == (int)Keys.Space)
            {
                if (ListResult.Count == 0)//发送空格
                {
                    KeybdEvent(Keys.Space);
                }
            }
            else if (keyCode > 97 && keyCode <= 105 && inputType == InputMethodType.InputType.CN9)//CN9输入方式
            {
                inputStrNumber = Convert.ToChar(keyCode - 48).ToString().ToLower();//获得键盘NO
                SetGroupPinyin(Convert.ToInt32(inputStrNumber));
                textBoxInput.Text = GetGroupPinyin();
                keyNumberList.Add(Convert.ToInt32(inputStrNumber));
            }
            else if (keyCode > 97 && keyCode <= 105 && (inputType == InputMethodType.InputType.EN || inputType == InputMethodType.InputType.ENUpper)
                && keyNumberList.Count == 0)//英文，每次只允许录入一个
            {
                inputStrNumber = Convert.ToChar(keyCode - 48).ToString().ToLower();//获得键盘NO
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (string item in KeyDic[Convert.ToInt32(inputStrNumber)])
                {
                    Word w = new Word();
                    if (this.inputType == InputMethodType.InputType.ENUpper)
                        w.Words = item.ToUpper();
                    else
                        w.Words = item.ToLower();
                    w.Counts = 0;
                    ListResult.Add(w);
                    sb.Append(count + "." + w.Words + " ");
                    count++;
                }
                listBoxResult.Items.Add(sb.ToString());
                endIndex = count - 1;
                keyNumberList.Add(Convert.ToInt32(inputStrNumber));
            }
            else if (keyCode >= 96 && keyCode <= 105 && inputType == InputMethodType.InputType.NO)//数字
            {
                inputStrNumber = Convert.ToChar(keyCode - 48).ToString().ToLower();//获得键盘NO
                _resultStr = inputStrNumber;
                KeybdEvent((Keys)keyCode);
            }
            else if (keyCode == 96 && inputType != InputMethodType.InputType.NO)//空格按键
            {
                KeybdEvent(Keys.Space);
            }
            else if (inputType == InputMethodType.InputType.CN)//全键盘
            {
                if (keyCode != (int)Keys.Back && keyCode != (int)Keys.Space && keyCode != (int)Keys.Enter)
                {
                    textBoxInput.Text = CommonFun.GetEnterPinyin(inputStr, textBoxInput.Text);
                }
                FindString(new string[] { textBoxInput.Text });
            }
            else
            {
                // KeybdEvent((Keys)keyCode);
                SendResult(inputStr);
            }
        }


        /// <summary>
        /// 获取CN9
        /// </summary>
        /// <param name="keyIndex"></param>
        private void SetGroupPinyin(int keyIndex)
        {
            int tempCount = 0;
            string result = string.Empty;
            listBoxGroup.Items.Clear();
            List<string> tempList = new List<string>();

            if (keyStack.Count <= 0)//正常入栈
            {
                for (int i = KeyDic[keyIndex].Length - 1; i >= 0; i--)
                {
                    if (KeyDic[keyIndex][i] != "u" && KeyDic[keyIndex][i] != "i" && KeyDic[keyIndex][i] != "v")
                    {
                        keyStack.Push(KeyDic[keyIndex][i]);
                        if (IsDebug)
                            listBoxGroup.Items.Add(KeyDic[keyIndex][i]);
                    }
                }
            }
            else
            {
                string currentStr = string.Empty;
                do
                {
                    string strall = keyStack.Pop();
                    foreach (string inputStr in KeyDic[keyIndex])
                    {
                        int index = 0;
                        currentStr = CommonFun.GetEnterPinyin(inputStr, strall);
                        tempCount = CommonFun.GetCount(currentStr);
                        if (!tempList.Contains(currentStr))
                        {
                            //按照拼音个数降序
                            #region 排序算法，比较慢
                            //for (int i = 0; i < tempList.Count; i++)
                            //{
                            //    if (CommonFun.GetCount(tempList[i]) >= tempCount)
                            //        index = i;
                            //}
                            //if (index > 0 && index == tempList.Count - 1)
                            //    tempList.Add(currentStr);
                            //else
                            //    tempList.Insert(index, currentStr);
                            #endregion
                            //修改为二分法
                            index = CommonFun.FindIndex(tempList, tempCount);
                            tempList.Insert(index, currentStr);
                        }
                    }
                } while (keyStack.Count > 0);

                for (int i = tempList.Count - 1; i >= 0; i--)
                {
                    string[] tempArr = CommonFun.StringSplitToArr(tempList[i]);
                    if (tempArr.Length > 2 && (tempArr[tempArr.Length - 1].Length <= 1 && tempArr[tempArr.Length - 2].Length <= 1))
                        continue;
                    keyStack.Push(tempList[i]);
                    if (IsDebug)
                        listBoxGroup.Items.Add(tempList[i]);
                }
                #region 过滤不必要的组合 之前逻辑干掉
                //  List<string> tempList = new List<string>();
                //foreach (string sResult in tempKeyStack)
                //{
                //    tempCount = CommonFun.GetCount(sResult);
                //    string[] tempArr = CommonFun.StringSplitToArr(sResult);

                //    //单个词并且，不能多音节组成词语或者最后2位都是单个字
                //    if (tempCount > 0 && tempArr.Length > 1 && (tempArr[0].Length <= 1
                //      || (tempArr[tempArr.Length - 1].Length <= 1 && tempArr[tempArr.Length - 2].Length <= 1)
                //    ))
                //    {
                //        continue;
                //    }
                //    //2个以上切分，并且最后一位单独--去除
                //    if (tempArr.Length > 2 && tempArr[tempArr.Length - 1].Length <= 1)
                //    {
                //        continue;
                //    }
                //    //单个完整字往前排
                //    if (!tempList.Contains(sResult))
                //    {
                //        int index = CommonFun.GetListIndex(tempList, sResult);
                //        if (index == tempList.Count - 1)
                //        {
                //            tempList.Add(sResult);
                //        }
                //        else
                //        {
                //            tempList.Insert(index, sResult);
                //        }
                //    }
                //}

                //foreach (string item in tempList)
                //{
                //    keyStack.Push(item);
                //    listBoxGroup.Items.Add(item);
                //}
                #endregion
            }
        }

        /// <summary>
        /// CN9联想功能
        /// </summary>
        /// <returns></returns>
        private string GetGroupPinyin()
        {
            string result = string.Empty;
            List<string> list = new List<string>();
            foreach (string sResult in keyStack)
            {
                list.Add(sResult);
            }
            result = FindString(list.ToArray());
            return result.StartsWith("'") ? result.Substring(1) : result;
        }

        /// <summary>
        /// 查找相关字库内容
        /// </summary>
        /// <param name="value"></param>
        private string FindString(string[] value)
        {
            InitVariable();
            if (value.Length == 0)
            {
                return "";
            }
            SearchDict(value, 1);//全字相同匹
            //SearchDict(value, 2);//首字母相同
            //SearchDict(value, 3);//声母相同

            #region 原先匹配逻辑 一个一个匹配比较影响效率
            //for (int i = 0; i < ListDict.Count; i++)
            //{
            //    //ListDict[i] 为2个元素，全CN，汉字
            //    tem1 = ListDict[i][0].Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);//字典
            //    foreach (string item in value)
            //    {
            //        tem2 = item.Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);//输入内容
            //        if (ListDict[i].Length == 2 && tem1.Length == tem2.Length && IsEque(tem1, tem2))
            //        {
            //            Word w = new Word();
            //            //w.PinYinArr = ListDict[i][0].Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);
            //            w.PinYinStr = ListDict[i][0];
            //            w.Key = ListDict[i][0] + " " + ListDict[i][1];
            //            w.Words = ListDict[i][1];
            //            w.Counts = 0;
            //            if (!ListResult.Contains(w))
            //            {
            //                ListResult.Add(w);
            //            }
            //        }
            //    }
            //}
            #endregion

            SortFrequencyDict();
            //每页最多显示9个
            startIndex = 0;
            if (ListResult.Count > 9)
            {
                endIndex = 9;
                btnNext.Image = Resources.InputMethodRight2;
                btnNext.Enabled = true;
            }
            else
            {
                endIndex = ListResult.Count;
            }
            return DisplayResult(startIndex, endIndex);
        }

        /// <summary>
        /// 查询字库
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isEcho"></param>
        private void SearchDict(string[] value, int seaType)
        {
            string[] tem1 = null;
            string[] tem2 = null;
            int tempStartIndex = 0;
            int tempEndIndex = 0;
            string tempStartStr = string.Empty;//声母

            // 生成的时候去过滤不必要的拼音组合
            int pingyinCount = -1;   //记录组合拼音的最短字数
            int tempPingyinCount = -1;   //记录组合拼音的最短字数
            foreach (string item in value)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                tempPingyinCount = CommonFun.GetCount(item);
                if (tempPingyinCount > pingyinCount && pingyinCount > -1)
                    break;
                pingyinCount = tempPingyinCount;
                tempStartStr = item.Substring(0, 1);
                tem2 = CommonFun.StringSplitToArr(item);//输入内容
                foreach (KeyValuePair<string, List<DicIndex>> kv in ListDicIndex)//循环字典
                {
                    foreach (DicIndex itemIndex in kv.Value)
                    {
                        if (itemIndex.StartStr == tempStartStr)//获得索引段
                        {
                            tempStartIndex = itemIndex.StartIndex;
                            tempEndIndex = itemIndex.EndIndex;
                            break;
                        }
                    }

                    for (int i = tempStartIndex; i < tempEndIndex; i++)//ListDict.Count
                    {
                        //if (i > tempEndIndex)  //查询字典匹配
                        //    break;
                        //ListDict[i] 为2个元素，全CN，汉字
                        tem1 = CommonFun.StringSplitToArr(ListDict[i][0]);//字典
                        if (seaType == 1)
                        {
                            #region 相等查找
                            if (ListDict[i].Length == 2 && tem1.Length == tem2.Length &&
                                (CommonFun.IsEque(tem1, tem2) || CommonFun.IsStartEque(tem1, tem2))
                                )//全字相同匹或者首字母相同2个条件合并到一起搜索不用搜索2次 2016-1-22优化
                            {
                                Word w = AddNewWord(i);
                                if (!IsInWord(w.Words))
                                {
                                    ListResult.Add(w);
                                }
                            }
                            #endregion
                        }
                        else if (seaType == 2)
                        {
                            #region 小于查找
                            if (ListDict[i].Length == 2 && tem1.Length <= tem2.Length && CommonFun.IsStartEque(tem1, tem2))
                            {
                                Word w = AddNewWord(i);
                                if (!IsInWord(w.Words))
                                {
                                    ListResult.Add(w);
                                }
                            }
                            #endregion
                        }
                        else if (seaType == 3)
                        {
                            #region 小于查找
                            if (ListDict[i].Length == 2 && tem1.Length <= tem2.Length && CommonFun.IsLess(tem1, tem2))
                            {
                                Word w = AddNewWord(i);
                                if (!IsInWord(w.Words))
                                {
                                    ListResult.Add(w);
                                }
                            }
                            #endregion
                        }
                    }//匹配字典
                }//循环字典
            }//音节循环查询
        }

        /// <summary>
        /// 创建一个Nwe Word
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Word AddNewWord(int i)
        {
            Word w = new Word();
            //w.PinYinArr =CommonFun.StringSplitToArr( ListDict[i][0])
            w.PinYinStr = ListDict[i][0];
            w.Key = ListDict[i][0] + " " + ListDict[i][1];
            w.Words = ListDict[i][1];
            w.Counts = 0;
            return w;
        }

        /// <summary>
        /// 是否存在指定Word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private bool IsInWord(string word)
        {
            bool result = false;
            foreach (Word item in ListResult)
            {
                if (item.Words == word)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 词频智能排序
        /// </summary>
        private void SortFrequencyDict()
        {
            foreach (Word item in ListResult)
            {
                if (FrequencyDict.ContainsKey(item.Key))
                {
                    item.Counts = FrequencyDict[item.Key];//词频加入
                }
            }
            //进行筛选排序
            ListResult = ListResult.OrderByDescending(r => r.Counts).ToList();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousPage();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            NextPage();
        }
        private void btnInputType_Click(object sender, EventArgs e)
        {
            if (this.inputType == InputMethodType.InputType.CN9)
            {
                this.inputType = InputMethodType.InputType.EN;
                btnInputType.Text = "英";
            }
            else if (this.inputType == InputMethodType.InputType.EN)
            {
                this.inputType = InputMethodType.InputType.ENUpper;
                btnInputType.Text = "大";
            }
            else if (this.inputType == InputMethodType.InputType.ENUpper)
            {
                this.inputType = InputMethodType.InputType.NO;
                btnInputType.Text = "数";
            }
            else if (this.inputType == InputMethodType.InputType.NO)
            {
                this.inputType = InputMethodType.InputType.CN9;
                btnInputType.Text = "中";
            }
        }
    }
}
