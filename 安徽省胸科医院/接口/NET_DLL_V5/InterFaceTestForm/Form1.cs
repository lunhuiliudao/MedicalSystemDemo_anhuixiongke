using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using InterFaceV5;
using System.Xml.Serialization;
using MedicalSytem.Soft.Model;


namespace InterFaceTestForm
{
    public partial class Form1 : Form
    {
        string filePath = Application.StartupPath + "\\MDEP.ini";
        public Form1()
        {
            string mess = "JZLSH,YLJGDM,YLJGMC,JZLB,ZYHM,MZH,PATID, HZXM,WDBSH,YEXH,WDMC,WDBBH,WDLB,WDLBSM ,WDMXLBDM,WDMXLBSM,ISPDF,ISWDD,ISJGH,CJYSDM,CJYSMC,SHYSDM,SHYSMC,CJSJ,SHSJ,WJCCBZ,URL,PAGEINDEX,BLZT,DATASTATUS, JLZT,SJLY,GXRQ";
            mess = mess.ToLower();
            InitializeComponent();
            //this.tbDBMS.Text = Publicini.ReadIniDataString("Database", "DBMS", "o73", filePath);
            //this.tbSN.Text = Publicini.ReadIniDataString("Database", "ServerName", "", filePath).Replace("@","").Trim();
            //this.tbDB.Text = Publicini.ReadIniDataString("Database", "Database", "", filePath);
            //this.tbUserID.Text = Publicini.ReadIniDataString("Database", "LogId", "", filePath);
            //this.tbpwd.Text = CryptUtil.DecryptString(Publicini.ReadIniDataString("Database", "LogPassword", "", filePath));
            this.tbwsurl.Text = Publicini.ReadIniDataString("Run_Config", "WSURL", "", filePath);
        }

        /// <summary>
        /// 根据住院号获取检查报告号以及检查类别
        /// </summary>
        private void ANES_PACS001_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtInpno.Text.Trim()))
            {
                MessageBox.Show("住院号不能为空");
                return;
            }

            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Patient.InpNo = txtInpno.Text.Trim();
            paramIn.Code = "PACS01";
            string ret = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
            MessageBox.Show(ret);
        }

        private void ANES_EMR001_Click(object sender, EventArgs e)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "EMRVIEW.DLL";
            object emrView = System.Reflection.Assembly.LoadFrom(filePath).CreateInstance("JHEMR.EMRVIEW.Class1");

            MethodInfo[] methodInfos = emrView.GetType().GetMethods();

            foreach (MethodInfo methodInfo in methodInfos)
            {
                if (methodInfo.Name.Equals("ShowEMRView"))
                {

                    methodInfo.Invoke(emrView, new object[] { this.tb_patientId.Text, int.Parse(this.tb_visitId.Text) });
                    continue;
                }
            }
        }



        private void ANES_HIS104_Click(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

            if (string.IsNullOrEmpty(txtInpno.Text.Trim()))
            {
                MessageBox.Show("住院号不能为空");
                return;
            }
            paramIn.Patient.InpNo = txtInpno.Text.Trim();

            paramIn.Code = "PAT102";

            string returnMessage = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
            MessageBox.Show(returnMessage);
        }

        private void ANES_HIS103_Click(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }
            //paramIn.Code = "ICU103";

            //paramIn.App = "ICU 同步医嘱";

            paramIn.Patient.PatientId = tb_patientId.Text.Trim();
            paramIn.Patient.VisitId = decimal.Parse(tb_visitId.Text);

            // string mess = InterFaceV5.InterFaceV5.ToJson(paramIn);

            // string returnMessage = InterFaceV5.InterFaceV5.of_systeminterface("",mess);
            // MessageBox.Show(returnMessage);
        }

        private void ANES_EMR004_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.reserved01 = this.tb_inpNo.Text;//类别
            //paramIn.reserved02 = this.tb_wardCode.Text;//子类别
            //paramIn.reserved03 = this.the_reserved03.Text;//归档主键
            //paramIn.reserved04 = this.the_reserved04.Text;//文件名称
            //paramIn.reserved11 = decimal.Parse("1");//归档次数
            //paramIn.reserved12 = decimal.Parse("0");//页码0开始

            //paramIn.reserved13 = decimal.Parse(this.the_reserved07.Text);//0为提交 1为取消提交 2为只存提交状态
            //paramIn.reserved05 = this.the_reserved05.Text;//PDF或者JPG文件全路径
            //paramIn.orderedby = this.the_reserved06.Text;//使用者工号

            //MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "EMR", "EMR004", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ANES_HIS301_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.reserved01 = this.tb_inpNo.Text;//类别
            //paramIn.reserved02 = this.tb_wardCode.Text;//子类别
            //paramIn.reserved03 = this.the_reserved03.Text;//归档主键
            //paramIn.reserved04 = this.the_reserved04.Text;//文件名称
            //paramIn.reserved11 = decimal.Parse(this.the_reserved05.Text);//归档次数
            //paramIn.reserved12 = decimal.Parse(this.the_reserved06.Text);//页码0开始

            //  MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS301", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }
        /// <summary>
        /// 病理信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ANES_PIS001_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "PIS", "PIS001", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }
        /// <summary>
        /// 同步科室信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ICU_HIS001_Click(object sender, EventArgs e)
        {
            //  InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();

            //  MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "HIS", "HIS001", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }
        /// <summary>
        /// 同步人员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ICU_HIS002_Click(object sender, EventArgs e)
        {
            // InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "HIS", "HIS002", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_HIS101_Click(object sender, EventArgs e)
        {
            // InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            // paramIn.patientid = this.tb_patientId.Text;

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "HIS", "HIS101", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_LIS001_Click(object sender, EventArgs e)
        {
            // InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            // paramIn.patientid = this.tb_patientId.Text;
            // paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //// MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "LIS", "LIS001", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_PACS001_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //    MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "PACS", "PACS001", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_EMR001_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "EMR", "EMR001", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_HIS104_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.inpno = this.tb_inpNo.Text;

            //    MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "HIS", "HIS104", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_HIS103_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "HIS", "HIS103", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_HIS102_Click(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            if (string.IsNullOrEmpty(this.tb_wardCode.Text))
            {
                this.lb_sign.Text = "请输入病区代码";
                return;
            }
            paramIn.Patient.WardCode = this.tb_wardCode.Text;
            // paramIn.Code = "ICU102";

            // paramIn.App = "ICU 病区同步患者信息";
            paramIn.Patient.PatientId = tb_patientId.Text.Trim();
            paramIn.Patient.VisitId = decimal.Parse(tb_visitId.Text);
            //  string mess = InterFaceV5.InterFaceV5.ToJson(paramIn);
            // string returnMessage = InterFaceV5.InterFaceV5.of_systeminterface(mess);
            //  MessageBox.Show(returnMessage);
        }

        private void ICU_EMR004_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.reserved01 = this.tb_inpNo.Text;//类别
            //paramIn.reserved02 = this.tb_wardCode.Text;//子类别
            //paramIn.reserved03 = this.the_reserved03.Text;//归档主键
            //paramIn.reserved04 = this.the_reserved04.Text;//文件名称
            //paramIn.reserved11 = decimal.Parse("1");//归档次数
            //paramIn.reserved12 = decimal.Parse("0");//页码0开始

            //paramIn.reserved13 = decimal.Parse(this.the_reserved07.Text);//0为提交 1为取消提交 2为只存提交状态
            //paramIn.reserved05 = this.the_reserved05.Text;//PDF或者JPG文件全路径
            //paramIn.orderedby = this.the_reserved06.Text;//使用者工号

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "EMR", "EMR004", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ICU_HIS301_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.reserved01 = this.tb_inpNo.Text;//类别
            //paramIn.reserved02 = this.tb_wardCode.Text;//子类别
            //paramIn.reserved03 = this.the_reserved03.Text;//归档主键
            //paramIn.reserved04 = this.the_reserved04.Text;//文件名称
            //paramIn.reserved11 = decimal.Parse(this.the_reserved05.Text);//归档次数
            //paramIn.reserved12 = decimal.Parse(this.the_reserved06.Text);//页码0开始

            //MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "EMR", "EMR004", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }
        /// <summary>
        /// 病理信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ICU_PIS001_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);

            //  MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ICUMGR", "PIS", "PIS001", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            writeIniFile();
            GPublicConfig gpconfig = new GPublicConfig();
            try
            {

                if (this.cbwsurl.Checked == true)
                {
                    string lsWSURL = this.tbwsurl.Text.Trim();
                    if (!lsWSURL.ToUpper().Contains("?WSDL"))
                    {
                        lsWSURL += "?WSDL";
                    }
                    System.Diagnostics.Process.Start(lsWSURL);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库失败，请根据提示检查MDEP.INI文件中的配置！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void writeIniFile()
        {

            Publicini.WriteIniData("Run_Config", "WSURL", this.tbwsurl.Text.Trim(), filePath);
        }

        private void SEMR_HIS900_Click(object sender, EventArgs e)
        {
            InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();

            //   MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("SEMRMGR", "HIS", "HIS900", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void SEMR_HIS901_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;

            ///   MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("SEMRMGR", "HIS", "HIS901", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void SEMR_HIS902_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.startdatetime = new DateTime(2011, 6, 1, 0, 0, 0);//this.DT_start.Value;
            //paramIn.stopdatetime = new DateTime(2011, 6, 1, 0, 0, 0);//this.DT_end.Value;

            //  MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("SEMRMGR", "HIS", "HIS902", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void SEMR_HIS903_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.reserved01 = this.the_reserved03.Text;//SEMR的VISIT_DATE
            //paramIn.reserved02 = this.the_reserved04.Text;//SEMR的VISIT_NO

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("SEMRMGR", "HIS", "HIS903", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void CSSD_001_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            //if (string.IsNullOrEmpty(this.the_reserved03.Text))
            //{
            //    this.lb_sign.Text = "请在reserved03输入框中输入器械条形码";
            //    return;
            //}
            //paramIn.reserved01 = this.the_reserved03.Text;

            //  MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "CSSD", "CSSD001", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_showImg frm_show = new frm_showImg();
            frm_show.Show();
        }

        private void ANES_HIS202_Click(object sender, EventArgs e)
        {
            InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.txtOperIdorScheduleId.Text))
            {
                this.lb_sign.Text = "请在INP_NO输入框中输入患者SCHEDULE_ID";
                return;
            }
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid =int.Parse(this.tb_visitId.Text);
            //paramIn.operid = int.Parse(this.tb_inpNo.Text);
            //MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS202", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ANES_HIS203_Click(object sender, EventArgs e)
        {
            //InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.txtOperIdorScheduleId.Text))
            {
                this.lb_sign.Text = "请在INP_NO输入框中输入患者SCHEDULE_ID";
                return;
            }
            if (this.DT_start.Value > this.DT_end.Value)
            {
                this.lb_sign.Text = "开始时间不能大于结束时间，请检查!";
                return;
            }
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.operid = int.Parse(this.tb_inpNo.Text);
            //paramIn.startdatetime = this.DT_start.Value;
            //paramIn.stopdatetime = this.DT_end.Value;
            //   MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS203", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");

            paramIn.Code = "OPER503W";
            paramIn.OpenClient = false;

            paramIn.Patient.PatientId = this.tb_patientId.Text;
            paramIn.Patient.VisitId = int.Parse(this.tb_visitId.Text);
            paramIn.Patient.OperId = int.Parse(this.txtOperIdorScheduleId.Text);

            InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
        }

        private void ANES_HIS211_Click(object sender, EventArgs e)
        {
            ParamInputDomain paramIn = new ParamInputDomain();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.txtOperIdorScheduleId.Text))
            {
                this.lb_sign.Text = "请在INP_NO输入框中输入患者SCHEDULE_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.the_reserved04.Text))
            {
                this.lb_sign.Text = "请在reserved04输入框中输入该手术的状态位";
                return;
            }
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.operid = int.Parse(this.tb_inpNo.Text);
            //paramIn.reserved20 = this.the_reserved04.Text;

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS211", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
            paramIn.Code = "OPER503W";
            paramIn.OpenClient = false;

            paramIn.Patient.PatientId = this.tb_patientId.Text;
            paramIn.Patient.VisitId = int.Parse(this.tb_visitId.Text);
            paramIn.Patient.OperId = int.Parse(this.txtOperIdorScheduleId.Text);
            paramIn.Operation.OperStatus = decimal.Parse(this.the_reserved04.Text);

            InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
        }

        private void ANES_HIS212_Click(object sender, EventArgs e)
        {
            InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.txtOperIdorScheduleId.Text))
            {
                this.lb_sign.Text = "请在INP_NO输入框中输入患者SCHEDULE_ID";
                return;
            }
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.operid = int.Parse(this.tb_inpNo.Text);

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS212", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void ANES_HIS209_Click(object sender, EventArgs e)
        {
            InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.txtOperIdorScheduleId.Text))
            {
                this.lb_sign.Text = "请在INP_NO输入框中输入患者SCHEDULE_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.txtInpno.Text))
            {
                this.lb_sign.Text = "请在reserved03输入框中输入费用类别(麻醉或手术，用数字表示)";
                return;
            }
            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);
            //paramIn.operid = int.Parse(this.tb_inpNo.Text);
            //paramIn.reserved02 = this.the_reserved03.Text;
            //paramIn.reserved03 = this.the_reserved04.Text;

            //  MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS209", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cb_supply.Items.Clear();
            this.cb_supply.Text = string.Empty;
            this.label19.Text = "提示：EXE或者WEB类型接口在填写patientid等参数时,\t\n参数必须全部小写，必须在前面加上'@@'，并且拼写无误！\t\n常见参数列表如下(对应MED_VS_HIS_PAT表中数据)：\t\nHIS_PATIENT_ID、MED_PATIENT_ID->@@patientid;\t\nHIS_VISIT_ID->@@hisvisitid;\t\nRESERVED01->@@inpno";

            switch (this.cb_type.Text.Trim())
            {
                case "PACS接口":
                    this.cb_supply.Text = Publicini.ReadIniDataString("Run_Config", "PACSNAME", "", filePath);
                    this.tb_filePath.Text = Publicini.ReadIniDataString("Run_Config", "PACSIP", "", filePath);
                    this.tb_parms.Text = Publicini.ReadIniDataString("Run_Config", "PACSPARM", "", filePath);
                    this.cb_supply.Items.Add("沈阳东软PACS");
                    this.cb_supply.Items.Add("美迪康PACS");
                    this.cb_supply.Items.Add("华海医信PACS");
                    this.cb_supply.Items.Add("莱德PACS");
                    this.cb_supply.Items.Add("其他URL方式PACS接口");
                    this.cb_supply.Items.Add("其他EXE方式PACS接口");
                    break;
                case "EMR接口":
                    this.cb_supply.Text = Publicini.ReadIniDataString("Run_Config", "EMRNAME", "", filePath);
                    this.tb_filePath.Text = Publicini.ReadIniDataString("Run_Config", "EMRIP", "", filePath);
                    this.tb_parms.Text = Publicini.ReadIniDataString("Run_Config", "EMRPARM", "", filePath);
                    this.cb_supply.Items.Add("浙大中控EMR");
                    this.cb_supply.Items.Add("南京海泰EMR");
                    this.cb_supply.Items.Add("嘉禾美康EMR");
                    this.cb_supply.Items.Add("掌握EMR");
                    this.cb_supply.Items.Add("其他URL方式EMR接口");
                    this.cb_supply.Items.Add("其他EXE方式EMR接口");
                    break;
            }

        }

        private void bt_saveSif_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.cb_type.Text) || string.IsNullOrEmpty(this.cb_supply.Text))
                {
                    return;
                }
                switch (cb_type.Text.Trim())
                {
                    case "PACS接口":
                        Publicini.WriteIniData("Run_Config", "PACSNAME", this.cb_supply.Text.Trim(), filePath);
                        Publicini.WriteIniData("Run_Config", "PACSIP", this.tb_filePath.Text.Trim(), filePath);
                        Publicini.WriteIniData("Run_Config", "PACSPARM", this.tb_parms.Text.Trim(), filePath);
                        MessageBox.Show("保存第三方PACS系统配置成功！", "提示");
                        break;
                    case "EMR接口":
                        Publicini.WriteIniData("Run_Config", "EMRNAME", this.cb_supply.Text.Trim(), filePath);
                        Publicini.WriteIniData("Run_Config", "EMRIP", this.tb_filePath.Text.Trim(), filePath);
                        Publicini.WriteIniData("Run_Config", "EMRPARM", this.tb_parms.Text.Trim(), filePath);
                        MessageBox.Show("保存第三方EMR系统配置成功！", "提示");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message, "提示");
            }
        }

        private void cb_supply_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string lsFilePathPacs = Publicini.ReadIniDataString("Run_Config", "PACSIP", "", filePath);
            //string lsFileParmPacs = Publicini.ReadIniDataString("Run_Config", "PACSPARM", "", filePath);

            //string lsFilePathEmr = Publicini.ReadIniDataString("Run_Config", "EMRIP", "", filePath);
            //string lsFileParmEmr = Publicini.ReadIniDataString("Run_Config", "EMRPARM", "", filePath);

            string lsFilePath = this.tb_filePath.Text.Trim();

            this.tb_parms.Enabled = true;
            if (this.cb_type.Text.Trim() == "PACS接口")
            {
                if (string.IsNullOrEmpty(lsFilePath))
                {
                    switch (this.cb_supply.Text.Trim())
                    {
                        case "沈阳东软PACS":
                            this.tb_filePath.Text = string.Empty;
                            this.tb_parms.Text = string.Empty;
                            this.label19.Text = "提示：沈阳东软PACS是调用DLL文件，无需填写参数";
                            break;
                        case "美迪康PACS":
                            this.tb_filePath.Text = "\\MdcHisView\\MdcHisView.exe";
                            this.tb_parms.Text = "@@patientid";
                            break;
                        case "华海医信PACS":
                            this.tb_filePath.Text = "C:\\Program Files\\HHRIS\\临床医生工作\\MedClinicalWS.exe /S7 /E";
                            this.tb_parms.Text = "@@patientid";
                            break;
                        case "莱德PACS":
                            this.tb_filePath.Text = "http://192.168.0.14:258/WebDoqLeiView/Default.aspx?type=hos&id=@@patientid&regdate=";
                            this.tb_parms.Enabled = false;
                            break;
                        case "其他URL方式PACS接口":
                            this.tb_filePath.Text = string.Empty;
                            this.tb_parms.Enabled = false;
                            break;
                        case "其他EXE方式PACS接口":
                            this.tb_filePath.Text = string.Empty;
                            this.tb_parms.Text = string.Empty;
                            break;
                    }
                }
            }
            else if (this.cb_type.Text.Trim() == "EMR接口")
            {
                if (string.IsNullOrEmpty(lsFilePath))
                {
                    switch (this.cb_supply.Text.Trim())
                    {
                        case "浙大中控EMR":
                            this.tb_filePath.Text = System.Environment.CurrentDirectory + "\\MedDoc\\MedDocSys.exe";
                            this.tb_parms.Enabled = false;
                            break;
                        case "南京海泰EMR":
                            this.tb_filePath.Text = "http://localhost/htweb/ShowInpatientInfo.jsp?ipid=@@patientid& patientName=";
                            this.tb_parms.Enabled = false;
                            break;
                        case "嘉禾美康EMR":
                            this.tb_filePath.Text = string.Empty;
                            this.tb_parms.Enabled = false;
                            break;
                        case "掌握EMR":
                            this.tb_filePath.Text = "D:\\dzbl\\viewcom.exe";
                            this.tb_parms.Text = "@@patientid";
                            break;
                        case "其他URL方式EMR接口":
                            this.tb_filePath.Text = string.Empty;
                            this.tb_parms.Enabled = false;
                            break;
                        case "其他EXE方式EMR接口":
                            this.tb_filePath.Text = string.Empty;
                            this.tb_parms.Text = string.Empty;
                            break;
                    }
                }
            }
        }

        private void sifInfo_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }

            //paramIn.patientid = this.tb_patientId.Text;
            //paramIn.visitid = int.Parse(this.tb_visitId.Text);

            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS106", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InterFaceV5.InterFaceV5 paramIn = new InterFaceV5.InterFaceV5();
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            // paramIn.patientid = this.tb_patientId.Text;
            // MessageBox.Show(InterFaceV5.InterFaceV5.of_systeminterface("ANESMGR", "HIS", "HIS107", paramIn), "返回框为空表示接口同步正确，否则提示错误信息");
        }

        //手术名称字典
        private void button1_Click_1(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "DICT103";
            paramIn.OpenClient = false;
            string returnMessage = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
            MessageBox.Show(returnMessage);
        }

        /// <summary>
        /// 科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ANES_HIS001_Click(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "DICT101";
            paramIn.OpenClient = false;
            string returnMessage = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
            MessageBox.Show(returnMessage);
        }

        /// <summary>
        /// 人员同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ANES_HIS002_Click(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "DICT102";
            paramIn.OpenClient = false;
            string returnMessage = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
            MessageBox.Show(returnMessage);
        }


        private void ANES_HIS201_Click(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

            paramIn.Code = "OPER101";
            //paramIn.Code = "UPDATE101";

            paramIn.Operation.StartDataTime = DT_start.Value.Date;
            //paramIn.Operation.StopDataTime = DT_start.Value.AddDays(1).Date;
            paramIn.Operation.StopDataTime = DT_end.Value.Date;

            InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
        }

        private void ANES_HIS101_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }


            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

            paramIn.Code = "PAT101";

            paramIn.Patient.PatientId = tb_patientId.Text.Trim();
            paramIn.Patient.VisitId = tb_visitId.Text.Trim().ParseToDecimal();

            InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
        }


        private void ANES_LIS001_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }
            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }

            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

            paramIn.Code = "LIS101";

            paramIn.Patient.PatientId = tb_patientId.Text.Trim();
            paramIn.Patient.VisitId = tb_visitId.Text.Trim().ParseToDecimalNullable();

            InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "OPER505W";
            paramIn.Patient.PatientId = "0008247775";
            paramIn.Patient.VisitId = (decimal)1;
            paramIn.EmrDocUpLoad.MrClass = "麻醉";
            paramIn.EmrDocUpLoad.MrSubClass = "复苏记录单";
            paramIn.EmrDocUpLoad.ArchiveKey = (decimal)1;
            paramIn.EmrDocUpLoad.ArchiveTimes = (decimal)1;
            paramIn.EmrDocUpLoad.EmrFileIndex = (decimal)0;
            paramIn.EmrDocUpLoad.EmrFileName = "0008247775_1_麻醉_复苏记录单_1_1.pdf";
            InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
        }

        private void btn_PAT201_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tb_patientId.Text))
            {
                this.lb_sign.Text = "请输入患者PATIENT_ID";
                return;
            }

            if (string.IsNullOrEmpty(this.tb_visitId.Text))
            {
                this.lb_sign.Text = "请输入患者VISIT_ID";
                return;
            }

            if (string.IsNullOrEmpty(this.txtOperIdorScheduleId.Text))
            {
                this.lb_sign.Text = "请输入患者OPER_ID";
                return;
            }

            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "PAT201";
            paramIn.Patient.PatientId = tb_patientId.Text.Trim();
            paramIn.Patient.VisitId = int.Parse(this.tb_visitId.Text);
            paramIn.Operation.OperId = int.Parse(this.txtOperIdorScheduleId.Text);
            string returnMessage = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
            MessageBox.Show(returnMessage);
        }
    }
}
