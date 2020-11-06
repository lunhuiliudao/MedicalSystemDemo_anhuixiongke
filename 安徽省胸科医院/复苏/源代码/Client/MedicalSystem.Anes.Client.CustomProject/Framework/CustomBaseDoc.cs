using System;
using System.Collections.Generic;
using System.Data;
using MedicalSystem.Anes.Client.FrameWork;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document;
using Medicalsystem.Anes.Custom.CustomProject;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class CustomBaseDoc : BaseDoc
    {
        //public static float PaperWidth = 21.0f;
        //public static float PaperHeight = 29.7f;
        public static float PaperWidth = ApplicationConfiguration.PrintPaperWidth;
        public static float PaperHeight = ApplicationConfiguration.PrintPaperHeight;
        public static float PaperLeftOff = ApplicationConfiguration.PaperLeftOff;
        public static float PaperTopOff = ApplicationConfiguration.PaperTopOff;
        [DllImport("EMRFSRVS.dll")]
        protected static extern int putfile(string host_addr, string local_file, string remote_file, int Protocol, int option);


        protected bool _needPostPDFWhenPrint = false;  // 是否要上传PDF 
        // 是否要进行文书质控
        protected bool _needCheckWhenPrint = false;
        public CustomBaseDoc()
        {
            int width = (int)(PaperWidth / 2.54 * 100 + 0.5);
            int height = (int)(PaperHeight / 2.54 * 100 + 0.5);
            _paperSize = new System.Drawing.Printing.PaperSize(ApplicationConfiguration.PrintPageName, width, height);
            // btnMultiPrint.Visible = true;
        }
        public override void Initial()
        {
            base.Initial();
            if (CustomSetting.PostPDF_Names != null)
            {
                foreach (string postname in CustomSetting.PostPDF_Names)
                {
                    if (postname == this.Caption)
                    {
                        _needPostPDFWhenPrint = true;
                        break;
                    }
                }
            }

            if (CustomSetting.DocNameCheckList != null)
            {
                foreach (string docName in CustomSetting.DocNameCheckList)
                {
                    if (docName == this.Caption)
                    {
                        _needCheckWhenPrint = true;
                        break;
                    }
                }
            }
        }

        //生成PDF文件名
        protected string GeneratePDFFileName(ref int times)
        {
            // 获取病人ID
            string patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            int visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            int operID = (ExtendApplicationContext.Current.PatientContextExtend.OperID);

            //List<MED_OPERATION_EXTENDED> dtData = CommonService.GetOperExtended(patientID, visitID, operID);
            //List<MED_OPERATION_EXTENDED> dtList = dtData.Where(x => x.ITEM_NAME == ExtendApplicationContext.Current.CurrentDocName + ".PDF").ToList();
            //if (dtList.Count > 0)
            //{
            //    times = Convert.ToInt32(dtList[0].ITEM_VALUE);
            //    times++;
            //    dtList[0].ITEM_VALUE = times.ToString();
            //}
            //else
            //{
            //    MED_OPERATION_EXTENDED row = new MED_OPERATION_EXTENDED();
            //    row.PATIENT_ID = patientID;
            //    row.VISIT_ID = visitID;
            //    row.OPER_ID = operID;
            //    row.ITEM_NAME = ExtendApplicationContext.Current.CurrentDocName + ".PDF";
            //    row.ITEM_VALUE = times.ToString();
            //    dtData.Add(row);
            //}
            //CommonService.SaveOperExtendedList(dtData);
            string filename = patientID.ToString() + "_" + visitID.ToString() + "_麻醉_" + this.Caption + "_" + operID.ToString() + "_" + times.ToString();
            return filename + ".pdf";
        }

        // 将PDF文件归档
        protected string PostPDF(string filename, int times)
        {
            string ret = "";
            int result = putfile(CustomSetting.PostPDF_ServerURL, CustomSetting.PostPDF_LocalURL + filename, filename, 1, 1);
            if (result == 0)
            {
                string path = ExtendApplicationContext.Current.PatientContextExtend.PatientID.Substring(ExtendApplicationContext.Current.PatientContextExtend.PatientID.Length - 3, 3) +
                     "\\" + ExtendApplicationContext.Current.PatientContextExtend.PatientID.Substring(0, ExtendApplicationContext.Current.PatientContextExtend.PatientID.Length - 3) +
                     "\\" + ExtendApplicationContext.Current.PatientContextExtend.VisitID + "\\";
                DataContext.GetCurrent().InsertEmrArchiveRecord(this.Caption, times, filename, path);
            }
            else ret = "归档失败！";
            if (ApplicationConfiguration.IsDeleteAfterCommitDoc)
            {
                if (File.Exists(CustomSetting.PostPDF_LocalURL + filename))
                {
                    File.Delete(CustomSetting.PostPDF_LocalURL + filename);
                }
            }
            return ret;
        }




        protected override void Print()
        {
            CustomPrinter printer = new CustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            if (_needPostPDFWhenPrint)
                printer.EndPrint += new PrintEventHandler(printer_EndPrint);
            printer.Print();
        }
        protected override void Print(bool bMultiPrint)
        {
            CustomPrinter printer = new CustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            if (_needPostPDFWhenPrint)
                printer.EndPrint += new PrintEventHandler(printer_EndPrint);
            base.Print(bMultiPrint);
        }


        // 将PDF文件上传
        protected void UpdateAnesDocCheckRecord(string docName)
        {
            //DataContext.GetCurrent().UpdateAnesDocCheckRecord(DataContext.GetCurrent().GetAnesDocCheckRecord(docName));                  //todo
        }


        protected override bool CheckBeforePrint()
        {
            List<MTextBox> boxs = GetControls<MTextBox>();
            foreach (MTextBox textbox in boxs)
            {
                if (!string.IsNullOrEmpty(textbox.WantValueBeforePrint) && string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    MessageBoxFormPC.Show(textbox.WantValueBeforePrint);
                    return false;
                }
            }
            List<MRichTextBox> boxs2 = GetControls<MRichTextBox>();
            foreach (MRichTextBox textbox in boxs2)
            {
                if (!string.IsNullOrEmpty(textbox.WantValueBeforePrint) && string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    MessageBoxFormPC.Show(textbox.WantValueBeforePrint);
                    return false;
                }
            }
            //List<BJCAControl> controls = GetControls<BJCAControl>();
            //foreach (BJCAControl ctl in controls)
            //{
            //    if (ctl.pictureBox1.Image == null)
            //    {
            //        if (MessageBoxFormPC.Show("签名未完成，是否继续打印 ？", "操作提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            //        {
            //            return false;
            //        }
            //        else
            //            break;
            //    }
            //}
            return true;
        }

        // 结束打印事件， 生成PDF并上传
        void printer_EndPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter)
            {
                bool allPage = PagerSetting.AllowPage;
                PagerSetting.AllowPage = true;
                try
                {
                    if (ExtendApplicationContext.Current.CustomSettingContext.IsCheckDocCompelete)
                    {
                        //保存记录
                        UpdateAnesDocCheckRecord(this.Caption);
                    }
                    int times = 1;
                    string fileName = GeneratePDFFileName(ref times);
                    string url = CustomSetting.PostPDF_LocalURL;
                    ExportPDF(CustomSetting.PostPDF_LocalURL + fileName);
                    PostPDF(fileName, times);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
                finally
                {
                    PagerSetting.AllowPage = allPage;
                }
            }
        }

        protected override void MultiPrint()
        {
            base.MultiPrint();
            MultiPrintFrm multiPrintFrm1 = new MultiPrintFrm();
            multiPrintFrm1.Show();
        }

        protected override string CommitDoc2()
        {
            string rett = "";
            if (ExtendApplicationContext.Current.CustomSettingContext.IsCheckDocCompelete)
            {
                //保存记录
                UpdateAnesDocCheckRecord(Name);
            }
            try
            {
                int times = 1;
                string fileName = GeneratePDFFileName(ref times);
                ExportPDF(CustomSetting.PostPDF_LocalURL + fileName);
                rett = PostPDF(fileName, times);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rett;
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="dataSource"></param>
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            DataContext.GetCurrent().RefreshDataSource(dataSource);
        }


        protected override void RescueMode()
        {
            ExtendApplicationContext.Current.IsRescueMode = !ExtendApplicationContext.Current.IsRescueMode;
            base.RescueMode();
        }

        /// <summary>
        /// 归档按钮：上传PDF
        /// </summary>
        public override void SingPostPDF()
        {
            int times = 1;
            string fileName = this.GeneratePDFFileName(ref times);
            if (!System.IO.Directory.Exists(CustomSetting.PostPDF_LocalURL))
            {
                System.IO.Directory.CreateDirectory(CustomSetting.PostPDF_LocalURL);
            }

            this.ExportPDF(CustomSetting.PostPDF_LocalURL + fileName);
            if (string.IsNullOrEmpty(this.PostPDF(fileName, times)))
            {
                MessageBoxFormPC.Show("归档成功！", "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxFormPC.Show("归档失败！", "提示信息",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
            }
        }

        protected override bool CheckBeforeCommit()
        {
            List<MTextBox> boxs = GetControls<MTextBox>();
            foreach (MTextBox textbox in boxs)
            {
                if (!string.IsNullOrEmpty(textbox.WantValueBeforePrint) && string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    MessageBoxFormPC.Show(textbox.WantValueBeforePrint);
                    return false;
                }
            }

            List<MRichTextBox> boxs2 = GetControls<MRichTextBox>();
            foreach (MRichTextBox textbox in boxs2)
            {
                if (!string.IsNullOrEmpty(textbox.WantValueBeforePrint) && string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    MessageBoxFormPC.Show(textbox.WantValueBeforePrint);
                    return false;
                }
            }

            //if (ExtendApplicationContext.Current.PatientInformationExtend.OPER_STATUS_CODE < 50)
            //{
            //    MessageBoxFormPC.Show("请在出复苏室之后才能上传！");
            //    return false;
            //}



            return true;
        }
    }
}
