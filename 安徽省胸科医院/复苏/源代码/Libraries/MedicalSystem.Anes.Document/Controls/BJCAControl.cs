using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Utilities;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false), Description("北京数字签名控件")]
    public partial class BJCAControl : UserControl, IPrintable
    {
        public delegate void CustomDrawEventHandler(Graphics g, float x, float y, object sender, EventArgs e);
        public delegate void CustomCAClick(object sender, EventArgs e);

        private string ImageBase64 = string.Empty;
        private string _containerName = string.Empty;
        private static readonly object _customDraw = new object();
        private string _docDataStr = string.Empty;
        private string _certname = string.Empty;
        private bool _noPrint = false;
        private string certSN = string.Empty;
        private string _usercert = string.Empty;

        /// <summary>
        /// 不打印
        /// </summary>
        [DisplayName("不打印"), Description("不打印"), Category("数据(自定义)")]
        public bool NoPrint
        {
            get { return _noPrint; }
            set { _noPrint = value; }
        }

        /// <summary>
        /// 对应数据库里的SIGNNAME
        /// </summary>
        public string CertName
        {
            get { return this._certname; }
        }

        /// <summary>
        /// 对应数据库里的CERTSN
        /// </summary>
        public string CertSN
        {
            get { return this.certSN; }
        }

        /// <summary>
        /// 删除签名图片事件
        /// </summary>
        public event CustomCAClick OnCustomDelete;

        /// <summary>
        /// 保存签名图片
        /// </summary>
        public event CustomCAClick OnCustomSave;

        /// <summary>
        /// 自定义绘制事件
        /// </summary>
        public event CustomDrawEventHandler CustomDraw
        {
            add
            {
                Events.AddHandler(_customDraw, value);
            }
            remove
            {
                Events.RemoveHandler(_customDraw, value);
            }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public BJCAControl()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(NewPictureBox_Paint);
        }

        /// <summary>
        /// IPrintable 接口方法的实现绘制
        /// </summary>
        public void Draw(Graphics g, float x, float y)
        {
            if (pictureBox1.Image != null)
            {
                using (Bitmap pic = new Bitmap(pictureBox1.Image))
                {
                    g.DrawImage(pic, x, y, panelMain.Width, panelMain.Height);
                }
            }
            else
            {
                CustomDrawEventHandler eventHandle = Events[_customDraw] as CustomDrawEventHandler;
                if (eventHandle != null)
                {
                    eventHandle(g, x, y, this, null);
                }
            }
        }

        /// <summary>
        /// 初始化加载图片
        /// </summary>
        public void LoadImage(DataRow row)
        {
            if (!row.IsNull("SIGNIMAGE"))
            {
                pictureBox1.Image = Base64StringToImage(StringHelper.Arr2Str(row["SIGNIMAGE"] as byte[]));
                labelControl1.Text = row.IsNull("SIGNDATE") ? string.Empty : row["SIGNDATE"].ToString();
            }
        }

        /// <summary>
        /// 清空签名图片
        /// </summary>
        public void ClearPic()
        {
            this.pictureBox1.Image = null;
        }

        /// <summary>
        /// 重绘事件
        /// </summary>
        private void NewPictureBox_Paint(object sender, PaintEventArgs e)
        {
            CustomDrawEventHandler eventHandle = Events[_customDraw] as CustomDrawEventHandler;
            if (eventHandle != null)
            {
                eventHandle(e.Graphics, 0, 0, sender, null);
            }
        }

        /// <summary>
        /// 签名按钮
        /// </summary>
        private void BtnSign_Click(object sender, EventArgs e)
        {
            string list = axXTXApp1.SOF_GetUserList();//获取证书信息
            if (list == null || list.Equals(""))
            {
                MessageBox.Show("请插入USbkey，请重新尝试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string[] templist = list.Split(new String[] { "||", "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> keyList = new Dictionary<string, string>();
                for (int i = 0; i <= templist.Length - 1; i = i + 2)
                {
                    keyList.Add(templist[i], templist[i + 1]);
                }
                if (keyList.Count > 1)
                {
                    List<string> keyNameList = new List<string>();
                    foreach (var item in keyList)
                    {
                        keyNameList.Add(item.Key);
                    }
                    object selectKey = Dialog.SingleInputSelect("请选择Key盘：", keyNameList.ToArray());
                    _certname = selectKey.ToString();
                    _containerName = keyList[selectKey.ToString()];
                }
                else
                {
                    _certname = templist[0];
                    _containerName = templist[1];
                }
                _usercert = axXTXApp1.SOF_ExportUserCert(_containerName);
                GetKeyPicLib.GetPic getpic = new GetKeyPicLib.GetPic();
                ImageBase64 = getpic.ConvertPicFormat(getpic.GetPic(_containerName), 3);

                if (this.SignData())
                {
                    Dialog.MessageBox("数字签名成功！");//21844716
                    byte[] arr = Convert.FromBase64String(ImageBase64);
                    MemoryStream ms = new MemoryStream(arr);
                    Bitmap bmp = new Bitmap(ms);
                    pictureBox1.Image = bmp;
                    ms.Close();
                }
            }
        }

        /// <summary>
        /// 执行签名
        /// </summary>
        private bool SignData()
        {
            _docDataStr = GetDocControlString();
            BJCA_TS_CLIENTCOMLib.BJCATSEngine tss = new BJCA_TS_CLIENTCOMLib.BJCATSEngine();//加盖时间戳控件
            string signvalue = axXTXApp1.SOF_SignData(this._containerName, _docDataStr);//2.对原文 进行签名；
            // string signvalue = @"MEUCIA+dyFVNMDOm03hfzm7vMjur0OCx08PW3SOcMMEfu0G2AiEAqF9jUD5arcpj/BExl3uMYmb1UQdW2D6bhTM89HEX+Rg=";
            string time_req = tss.CreateTimeStampRequest(_docDataStr);//3.获取时间戳请求；
            string timestampValue = tss.CreateTimeStamp(time_req); //4.加盖时间戳。
            string usercert = axXTXApp1.SOF_ExportUserCert(_containerName);
            string certSN = axXTXApp1.SOF_GetCertInfo(usercert, 2);//客户端证书编号，certSN；--电子签名验证时需要。
            string controlID = this.Name;
            string end = axXTXApp1.SOF_GetCertInfo(usercert, 12);
            end = end.Substring(0, 4) + '-' + end.Substring(4, 2) + '-' + end.Substring(6, 2);
            DateTime endDate = Convert.ToDateTime(end);
            DateTime curDate = DateTime.Now;
            int day = ((TimeSpan)(endDate - curDate)).Days;
            if (day < 0)
            {
                day = Math.Abs(day);
                Dialog.MessageBox("您的证书已经过期" + day + "天，请联系管理员更新证书！");
                return false;
            }
            else if (day <= 3)
            {
                if (day == 0)
                {
                    Dialog.MessageBox("您的证书明天过期，请及时联系管理员更新证书！");
                }
                else
                {
                    Dialog.MessageBox("您的证书还有" + day + "天过期，请及时联系管理员更新证书！");
                }

            }
            if (string.IsNullOrEmpty(time_req))
            {
                time_req = "0";
                timestampValue = "0";
            }
            if (string.IsNullOrEmpty(signvalue))//|| string.IsNullOrEmpty(time_req)
            {
                Dialog.MessageBox("无法连接数字签名服务器，请联系管理员！");
                return false;
            }

            if (null != this.OnCustomSave)
            {
                MED_BJCA_SIGN curCA = new MED_BJCA_SIGN()
                {
                    SIGNID = Guid.NewGuid().ToString(),
                    SIGNNAME = _certname,
                    SIGNTYPE = 0,
                    CERTSN = certSN,
                    SIGNVALUE = StringHelper.Str2Arr(signvalue),
                    TIMESTAMPVALUE = StringHelper.Str2Arr(timestampValue),
                    SIGNCERT = StringHelper.Str2Arr(usercert),
                    SIGNIMAGE = StringHelper.Str2Arr(ImageBase64),
                    ORGDATA = StringHelper.Str2Arr(_docDataStr),
                    CONTROLID = controlID,
                };

                try
                {
                    // 将数据保存的操作放到handle中
                    this.OnCustomSave(curCA, null);
                }
                catch (Exception ex)
                {
                    MedicalSystem.Anes.Core.Log.LogHelper.WriteErrLog("保存签名图片失败", ex);
                    Dialog.MessageBox("保存签名图片失败！");
                    return false;
                }
            }

            return true;
        }

        private string GetDocControlString()
        {
            MedReportView ReportViewer = GetReportViewer(this) as MedReportView;
            List<string> StrList = new List<string>();
            List<MTextBox> MtextList = ReportViewer.GetControls<MTextBox>();
            foreach (MTextBox m in MtextList)
            {
                StrList.Add(string.Format("{0}-{1}", m.Name, m.Value));
            }
            List<MRichTextBox> MRichtextList = ReportViewer.GetControls<MRichTextBox>();
            foreach (MRichTextBox m in MRichtextList)
            {
                StrList.Add(string.Format("{0}-{1}", m.Name, m.Value));
            }
            List<CustomControl> MCustomcontrol = ReportViewer.GetControls<CustomControl>();
            foreach (CustomControl m in MCustomcontrol)
            {
                if (m.MultiSelect == true)
                {
                    StrList.Add(string.Format("{0}-{1}", m.Name, m.Value));
                }
                else
                {
                    StrList.Add(string.Format("{0}-{1}", m.Name, m.SimpleValue));
                }
            }
            return string.Join(",", StrList.ToArray());
        }

        private Control GetReportViewer(Control Currentcontrol)
        {
            if (Currentcontrol.Parent is MedReportView)
            {
                return Currentcontrol.Parent;
            }
            else
            {
                return GetReportViewer(Currentcontrol.Parent);
            }
        }

        /// <summary>
        /// 图片 转为    base64编码的文本
        /// </summary>
        private void ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);
                //this.pictureBox1.Image = bmp;
                FileStream fs = new FileStream(Imagefilename + ".txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                sw.Write(strbaser64);

                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ImgToBase64String 转换失败\nException:" + ex.Message);
            }
        }

        /// <summary>
        /// base64编码的文本 转为    图片
        /// </summary>
        private Bitmap Base64StringToImage(string inputStr)
        {
            byte[] arr = Convert.FromBase64String(inputStr);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            ms.Close();
            return bmp;
        }

        /// <summary>
        /// 删除签名图片
        /// </summary>
        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            string list = axXTXApp1.SOF_GetUserList();//获取证书信息
            if (list == null || list.Equals(""))
            {
                MessageBox.Show("请插入USbkey，请重新尝试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string[] templist = list.Split(new String[] { "||", "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> keyList = new Dictionary<string, string>();
                for (int i = 0; i <= templist.Length - 1; i = i + 2)
                {
                    keyList.Add(templist[i], templist[i + 1]);
                }
                if (keyList.Count > 1)
                {
                    List<string> keyNameList = new List<string>();
                    foreach (var item in keyList)
                    {
                        keyNameList.Add(item.Key);
                    }
                    object selectKey = Dialog.SingleInputSelect("请选择Key盘：", keyNameList.ToArray());
                    _certname = selectKey.ToString();
                    _containerName = keyList[selectKey.ToString()];
                }
                else
                {
                    _certname = templist[0];
                    _containerName = templist[1];
                }
                _usercert = axXTXApp1.SOF_ExportUserCert(_containerName);
            }

            this.certSN = axXTXApp1.SOF_GetCertInfo(_usercert, 2);//客户端证书编号，certSN；--电子签名验证时需要。
            if (null != this.OnCustomDelete)
            {
                this.OnCustomDelete(this, null);
            }
        }


        //private string GetAnesEventString(decimal eventNo)
        //{
        //    string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
        //    decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
        //    decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
        //    DataTable envetDT = new AnesthesiaSheetDA().GetAnesthesiaEvent(patientID, visitID, operID, eventNo);
        //    List<string> strList = new List<string>();
        //    foreach (DataRow row in envetDT.Rows)
        //    {
        //        foreach (DataColumn col in envetDT.Columns)
        //        {
        //            strList.Add(row.IsNull(col) ? string.Empty : row[col].ToString());
        //        }
        //    }
        //    return string.Join(",", strList.ToArray());
        //}

        //private string GetAnesVitalSign(decimal eventNo)
        //{
        //    string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
        //    decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
        //    decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
        //    DataTable vitalDT = new AnesthesiaSheetDA().GetVitalSignData(patientID, visitID, operID, eventNo);
        //    List<string> strList = new List<string>();
        //    foreach (DataRow row in vitalDT.Rows)
        //    {
        //        foreach (DataColumn col in vitalDT.Columns)
        //        {
        //            strList.Add(row.IsNull(col) ? string.Empty : row[col].ToString());
        //        }
        //    }
        //    return string.Join(",", strList.ToArray());
        //}

        /// <summary>
        /// 校验签名值
        /// </summary>
        /// <returns>1为正确，0为未签名，-1为错误</returns>
        //public int VerifySignedData(string DocName)
        //{
        //    string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
        //    decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
        //    decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;

        //    string whereString = " Where PATIENT_ID = '" + patientID + "' and  VISIT_ID = " + visitID + " and  OPER_ID = " + operID + " ";
        //    whereString += " and SIGNDOCNAME  ='" + DocName + "' ORDER BY SIGNDATE ";
        //    DataTable data = new CommonDA().GetDataWithPrimaryKey(" MED_BJCA_SIGN ", whereString);
        //    if (data.Rows.Count == 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        DataRow row = data.Rows[data.Rows.Count - 1];
        //        string orgdate = GetDocControlString();
        //        string usercert = StringHelper.Arr2Str(row["SIGNCERT"] as byte[]);
        //        string signvalue = StringHelper.Arr2Str(row["SIGNVALUE"] as byte[]);
        //        BJCA_SVS_CLIENTCOMLib.BJCASVSEngine svs = new BJCA_SVS_CLIENTCOMLib.BJCASVSEngine();
        //        int ret = svs.VerifySignedData(usercert, orgdate, signvalue);

        //        if (ret == 0)
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //}

        /// <summary>
        /// 校验麻醉事件签名值
        /// </summary>
        /// <returns>1为正确，0为未签名，-1为错误</returns>
        //public int VerifySignedAnesEventData(string DocName)
        //{
        //    string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
        //    decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
        //    decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
        //    string signdocName = DocName.Contains("麻醉单") || DocName.Contains("麻醉记录单") ? "麻醉事件" : "复苏事件";
        //    string whereString = " Where PATIENT_ID = '" + patientID + "' and  VISIT_ID = " + visitID + " and  OPER_ID = " + operID + " ";
        //    whereString += " and SIGNDOCNAME  ='" + signdocName + "' ORDER BY SIGNDATE ";
        //    DataTable data = new CommonDA().GetDataWithPrimaryKey(" MED_BJCA_SIGN ", whereString);
        //    if (data.Rows.Count == 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        DataRow row = data.Rows[data.Rows.Count - 1];
        //        string orgdate = GetAnesEventString(DocName.Contains("麻醉单") || DocName.Contains("麻醉记录单") ? 0 : 1);
        //        string usercert = StringHelper.Arr2Str(row["SIGNCERT"] as byte[]);
        //        string signvalue = StringHelper.Arr2Str(row["SIGNVALUE"] as byte[]);
        //        BJCA_SVS_CLIENTCOMLib.BJCASVSEngine svs = new BJCA_SVS_CLIENTCOMLib.BJCASVSEngine();
        //        int ret = svs.VerifySignedData(usercert, orgdate, signvalue);

        //        if (ret == 0)
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //}

        /// <summary>
        /// 校验麻醉事件签名值
        /// </summary>
        /// <returns>1为正确，0为未签名，-1为错误</returns>
        //public int VerifySignedVitalSignData(string DocName)
        //{
        //    string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
        //    decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
        //    decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
        //    string signdocName = DocName.Contains("麻醉单") || DocName.Contains("麻醉记录单") ? "麻醉体征" : "复苏体征";
        //    string whereString = " Where PATIENT_ID = '" + patientID + "' and  VISIT_ID = " + visitID + " and  OPER_ID = " + operID + " ";
        //    whereString += " and SIGNDOCNAME  ='" + signdocName + "' ORDER BY SIGNDATE ";
        //    DataTable data = new CommonDA().GetDataWithPrimaryKey(" MED_BJCA_SIGN ", whereString);
        //    if (data.Rows.Count == 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        DataRow row = data.Rows[data.Rows.Count - 1];
        //        string orgdate = GetAnesVitalSign(DocName.Contains("麻醉单") || DocName.Contains("麻醉记录单") ? 0 : 1);
        //        string usercert = StringHelper.Arr2Str(row["SIGNCERT"] as byte[]);
        //        string signvalue = StringHelper.Arr2Str(row["SIGNVALUE"] as byte[]);
        //        BJCA_SVS_CLIENTCOMLib.BJCASVSEngine svs = new BJCA_SVS_CLIENTCOMLib.BJCASVSEngine();
        //        int ret = svs.VerifySignedData(usercert, orgdate, signvalue);

        //        if (ret == 0)
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //}
    }
}
