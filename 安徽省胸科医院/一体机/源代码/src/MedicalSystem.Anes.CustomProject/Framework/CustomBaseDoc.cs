// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      CustomBaseDoc.cs
// 功能描述(Description)：    所有文书的二代父类（一代父类是BaseDoc）
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Custom.CustomProject;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 所有文书的二代父类，处理文书的打印和上传
    /// </summary>
    public partial class CustomBaseDoc : BaseDoc
    {
        public static float PaperWidth = ApplicationConfiguration.PrintPaperWidth;
        public static float PaperHeight = ApplicationConfiguration.PrintPaperHeight;
        public static float PaperLeftOff = ApplicationConfiguration.PaperLeftOff;
        public static float PaperTopOff = ApplicationConfiguration.PaperTopOff;
        public static string PostPDF_ServerURL = ApplicationConfiguration.PDFServerUrl;
        public static string PostPDF_LocalURL = ApplicationConfiguration.PDFLocalUrl;
        protected bool _needPostPDFWhenPrint = false;                                        // 是否要上传PDF 
        protected bool _needCheckWhenPrint = false;                                          // 是否要进行文书质控

        /// <summary>
        /// 文书上传到服务器
        /// </summary>
        /// <param name="host_addr">服务器地址</param>
        /// <param name="local_file">本地文件的完整名称，包含地址</param>
        /// <param name="remote_file">本地文件名称</param>
        /// <param name="Protocol">传送协议，默认1</param>
        /// <param name="option">默认1</param>
        /// <returns></returns>
        [DllImport("EMRFSRVS.dll")]
        protected static extern int putfile(string host_addr, string local_file, string remote_file, int Protocol, int option);

        /// <summary>
        /// 无参构造
        /// </summary>
        public CustomBaseDoc()
        {
            int width = (int)(PaperWidth / 2.54 * 100 + 0.5);
            int height = (int)(PaperHeight / 2.54 * 100 + 0.5);
            _paperSize = new System.Drawing.Printing.PaperSize(ApplicationConfiguration.PrintPageName, width, height);
            btnMultiPrint.Visible = true;
        }

        /// <summary>
        /// 双面打印的具体实现
        /// </summary>
        protected override void DoublePrintDoc(string docName1, string docName2)
        {
            CustomDoublePrinter cusPrinter = new CustomDoublePrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            cusPrinter.LoadDoubleDoc(this.GetNursePrinters(docName1, docName2));
            cusPrinter.PLPrint();
        }

        /// <summary>
        /// 打印当前页具体实现
        /// </summary>
        protected override void PrintCurPage()
        {
            CustomSinglePrinter cusSinglePrinter = new CustomSinglePrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            cusSinglePrinter.PrintCurrentPage();
        }

        /// <summary>
        /// 加载双面文书
        /// </summary>
        /// <param name="docName1">文书名称1</param>
        /// <param name="docName2">文书名称2</param>
        protected UIElementPrinter[] GetNursePrinters(string docName1, string docName2)
        {
            UIElementPrinter[] NursePrinters = new UIElementPrinter[2];
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
            Type t = Type.GetType(docs[docName1].Type);
            BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
            baseDoc.BackColor = Color.White;
            baseDoc.Name = docs[docName1].Caption;
            baseDoc.HideScrollBar();
            baseDoc.Initial();
            baseDoc.LoadReport(Path.Combine(System.Windows.Forms.Application.StartupPath, docs[docName1].Path));
            NursePrinters[0] = new UIElementPrinter(baseDoc, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);

            t = Type.GetType(docs[docName2].Type);
            baseDoc = Activator.CreateInstance(t) as BaseDoc;
            baseDoc.BackColor = Color.White;
            baseDoc.Name = docs[docName2].Caption;
            baseDoc.HideScrollBar();
            baseDoc.Initial();
            baseDoc.LoadReport(Path.Combine(System.Windows.Forms.Application.StartupPath, docs[docName2].Path));
            NursePrinters[1] = new UIElementPrinter(baseDoc, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            return NursePrinters;
        }

        /// <summary>
        /// 文书初始化
        /// </summary>
        public override void Initial()
        {
            base.Initial();
            // 判断文书打印完成后是否需要上传PDF文件到服务器
            if (CustomSetting.PostPDF_Names != null)
            {
                foreach (string postname in CustomSetting.PostPDF_Names)
                {
                    if (postname == ExtendAppContext.Current.CurrentDocName)
                    {
                        _needPostPDFWhenPrint = true;
                        break;
                    }
                }
            }

            // 在文书打印前判断是否需要验证数据的正确性
            if (CustomSetting.DocNameCheckList != null)
            {
                foreach (string docName in CustomSetting.DocNameCheckList)
                {
                    if (docName == ExtendAppContext.Current.CurrentDocName)
                    {
                        _needCheckWhenPrint = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 生成PDF文件名，同时返回文书打印的次数
        /// </summary>
        protected string GeneratePDFFileName(ref int times)
        {
            // 获取病人ID
            string patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operID = (ExtendAppContext.Current.PatientInformationExtend.OPER_ID);

            List<MED_OPERATION_EXTENDED> dtData = CareDocService.ClientInstance.GetOperExtended(patientID, visitID, operID);
            List<MED_OPERATION_EXTENDED> dtList = dtData.Where(x => x.ITEM_NAME == ExtendAppContext.Current.CurrentDocName + ".PDF").ToList();
            if (dtList.Count > 0)
            {
                times = Convert.ToInt32(dtList[0].ITEM_VALUE);
                times++;
                dtList[0].ITEM_VALUE = times.ToString();
            }
            else
            {
                MED_OPERATION_EXTENDED row = new MED_OPERATION_EXTENDED();
                row.PATIENT_ID = patientID;
                row.VISIT_ID = visitID;
                row.OPER_ID = operID;
                row.ITEM_NAME = ExtendAppContext.Current.CurrentDocName + ".PDF";
                row.ITEM_VALUE = times.ToString();
                row.ModelStatus = ModelStatus.Add;
                dtData.Add(row);
            }

            CareDocService.ClientInstance.SaveOperExtendedList(dtData);
            string filename = patientID.ToString() + "_" +
                              visitID.ToString() + "_麻醉_" +
                              ExtendAppContext.Current.CurrentDocName + "_" +
                              operID.ToString() + "_" +
                              times.ToString();

            return filename + ".pdf";
        }

        /// <summary>
        /// 将PDF文件上传到服务器
        /// </summary>
        protected string PostPDF(string filename, int times)
        {
            string ret = "";
            using (FileStream fs = new FileStream(PostPDF_LocalURL + filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long size = fs.Length;
                byte[] array = new byte[size];

                //将文件读到byte数组中
                fs.Read(array, 0, array.Length);
                fs.Close();

                int result = CommonService.ClientInstance.PostPDFFile(
                    new { FILE = array, FileName = filename, PatientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, VisitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID });
                if (result == 1)
                {
                    string path = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID.Substring(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID.Length - 3, 3) +
                         "\\" + ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID.Substring(0, ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID.Length - 3) +
                         "\\" + ExtendAppContext.Current.PatientInformationExtend.VISIT_ID + "\\";
                    DataContext.GetCurrent().InsertEmrArchiveRecord(ExtendAppContext.Current.CurrentDocName, times, filename, path);
                }
                else
                {
                    ret = "上传失败！";
                    this.IsPostSuccessed = false;
                }
            }
            // int result = putfile(PostPDF_ServerURL, PostPDF_LocalURL + filename, filename, 1, 1);


            return ret;
        }

        /// <summary>
        /// 打印文书
        /// </summary>
        protected override void Print()
        {
            CustomPrinter printer = new CustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            printer.EndPrint += new PrintEventHandler(printer_EndPrint);
            printer.Print();
        }

        /// <summary>
        /// 集中打印
        /// </summary>
        protected override void Print(bool bMultiPrint)
        {
            CustomPrinter printer = new CustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            if (_needPostPDFWhenPrint)
            {
                printer.EndPrint += new PrintEventHandler(printer_EndPrint);
            }
            printer.Print(bMultiPrint);
            //base.Print(bMultiPrint);
        }


        /// <summary>
        /// 保存文书上传的记录
        /// </summary>
        /// <param name="docName">文书名称</param>
        protected void UpdateAnesDocCheckRecord(string docName)
        {
        }

        /// <summary>
        /// 打印前判断
        /// </summary>
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

            return true;
        }

        /// <summary>
        /// 结束打印事件， 生成PDF并上传
        /// </summary>
        void printer_EndPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter)
            {
                bool allPage = PagerSetting.AllowPage;
                PagerSetting.AllowPage = true;
                try
                {
                    if (ExtendAppContext.Current.CustomSettingContext.IsCheckDocCompelete)
                    {
                        //保存记录
                        UpdateAnesDocCheckRecord(ExtendAppContext.Current.CurrentDocName);
                    }

                    int times = 1;
                    string fileName = this.GeneratePDFFileName(ref times);
                    if (!System.IO.Directory.Exists(PostPDF_LocalURL))
                    {
                        System.IO.Directory.CreateDirectory(PostPDF_LocalURL);
                    }

                    this.ExportPDF3(PostPDF_LocalURL + fileName);
                    this.WaitPrintEnd();
                    this.PostPDF(fileName, times);
                    if (ApplicationConfiguration.IsDeleteAfterCommitDoc)
                    {
                        if (File.Exists(PostPDF_LocalURL + fileName))
                        {
                            this.DeleteDocFile(PostPDF_LocalURL + fileName);
                        }
                    }
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

        /// <summary>
        /// 弹出集中打印窗口，使用using(){}格式，默认实现Dispose，手动释放资源
        /// </summary>
        protected override void MultiPrint()
        {
            base.MultiPrint();
            using (MultiPrintFrm multiPrintFrm = new MultiPrintFrm())
            {
                multiPrintFrm.ShowDialog();
            }
            
        }

        /// <summary>
        /// 集中打印时，上传PDF到服务器
        /// </summary>
        protected override string CommitDoc2()
        {
            string rett = "";
            if (ExtendAppContext.Current.CustomSettingContext.IsCheckDocCompelete)
            {
                //保存记录
                this.UpdateAnesDocCheckRecord(Name);
            }
            try
            {
                int times = 1;
                string fileName = this.GeneratePDFFileName(ref times);
                this.ExportPDF3(PostPDF_LocalURL + fileName);
                this.WaitPrintEnd();
                rett = this.PostPDF(fileName, times);
                if (ApplicationConfiguration.IsDeleteAfterCommitDoc)
                {
                    if (File.Exists(PostPDF_LocalURL + fileName))
                    {
                        this.DeleteDocFile(PostPDF_LocalURL + fileName);
                    }
                }
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
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            return base.OnSaveData(dataSource);
            // DataContext.GetCurrent().RefreshDataSource(dataSource);
        }

        /// <summary>
        /// 抢救模式
        /// </summary>
        protected override void RescueMode()
        {
            ExtendAppContext.Current.IsRescueMode = !ExtendAppContext.Current.IsRescueMode;
            base.RescueMode();
        }

        /// <summary>
        /// 上传PDF文件（和打印流程一样）
        /// </summary>
        /// <param name="fileName">PDF文件路径</param>
        protected void ExportPDF3(string fileName)
        {
            this.IsPrintEnd = false;
            CustomPrinter printer = new CustomPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            if (!printer.ExportPDF3(fileName))// 如果返回false则说明调用系统"Microsoft Print to PDF"失败了，采用原来的生成PDF方法
            {
                base.ExportPDF(fileName);
            }
        }

        /// <summary>
        /// 等待实际打印完成
        /// </summary>
        private bool WaitPrintEnd()
        {
            bool result = true;
            int i = 0;
            while (!this.IsPrintEnd)
            {
                System.Threading.Thread.Sleep(500);
                Application.DoEvents();
                i++;
                if (i >= 20)
                {
                    result = false;
                    break;
                }
            }

            // 确保文件相关流全部关闭
            if (result)
            {
                System.Threading.Thread.Sleep(1000);
            }

            return result;
        }

        /// <summary>
        /// 归档按钮：上传PDF
        /// </summary>
        public override void SingPostPDF()
        {
            int times = 1;
            string fileName = this.GeneratePDFFileName(ref times);
            if (!System.IO.Directory.Exists(PostPDF_LocalURL))
            {
                System.IO.Directory.CreateDirectory(PostPDF_LocalURL);
            }

            this.ExportPDF3(PostPDF_LocalURL + fileName);
            this.WaitPrintEnd();
            if (string.IsNullOrEmpty(this.PostPDF(fileName, times)))
            {
                MessageBox.Show("上传成功！", "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show("上传失败！", "提示信息",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error,
                                            MessageBoxDefaultButton.Button1,
                                            MessageBoxOptions.DefaultDesktopOnly);
            }

            // 文书上传后否删除本地文件 
            if (ApplicationConfiguration.IsDeleteAfterCommitDoc)
            {
                if (File.Exists(PostPDF_LocalURL + fileName))
                {
                    this.DeleteDocFile(PostPDF_LocalURL + fileName);
                }
            }
        }

        /// <summary>
        /// 文书归档无需提示框
        /// </summary>
        public override void SingPostPDFNoMsgbox()
        {
            int times = 1;
            string fileName = this.GeneratePDFFileName(ref times);
            if (!System.IO.Directory.Exists(PostPDF_LocalURL))
            {
                System.IO.Directory.CreateDirectory(PostPDF_LocalURL);
            }

            this.ExportPDF3(PostPDF_LocalURL + fileName);
            this.WaitPrintEnd();
            this.PostPDF(fileName, times);
            if (ApplicationConfiguration.IsDeleteAfterCommitDoc)
            {
                if (File.Exists(PostPDF_LocalURL + fileName))
                {
                    this.DeleteDocFile(PostPDF_LocalURL + fileName);
                }
            }
        }

        /// <summary>
        /// 删除PDF文书方法
        /// </summary>
        /// <param name="fileName">文书全路径</param>
        private void DeleteDocFile(string fileName)
        {
            try
            {
                System.Windows.Forms.Application.DoEvents();
                File.Delete(fileName);
            }
            catch (Exception)
            {
                DeleteDocFile(fileName);
            }
        }
    }
}
