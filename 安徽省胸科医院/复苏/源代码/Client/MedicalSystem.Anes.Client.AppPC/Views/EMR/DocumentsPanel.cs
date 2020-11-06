using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Utilities;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class DocumentsPanel : BaseView
    {
        # region 构造方法

        public DocumentsPanel() : this(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID, ExtendApplicationContext.Current.PatientInformationExtend.OPER_ID) { }
        public DocumentsPanel(string patientID, decimal visitID, decimal operID) : this(patientID, visitID, operID, "病历病程") { }

        public DocumentsPanel(string patientID, decimal visitID, decimal operID, string title)
        //: base(patientID, visitID, operID, title)
        {
            Caption = ViewNames.HisDocuments;
            InitializeComponent(); 
            RefreshDataa();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 病理病程索引表
        /// </summary>
        //Sync.MED_MR_INDEXDataTable mrIndexDT;
        //Sync.MED_MR_FILE_INDEXDataTable mrFileIndexDT; 
        string _patientID = null;
        decimal _visitID = 0;

        #endregion 变量

        #region 方法

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshDataa()
        {

           // SyncProxy.SyncEMR(ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.VisitID, null);

            if (this.gridView1.RowCount == 0) return; 
            ///没有病人信息则不处理
            if (string.IsNullOrEmpty(_patientID)) return;

           
        } 

        #endregion 方法

        #region 事件

        /// <summary>
        /// 表格单元格需要数据事件
        /// </summary>
        /// <param name="sender">表格</param>
        /// <param name="e">事件参数</param>
        private void medDataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            

        }

        #endregion 事件

        private void medDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        [DllImport("fsrv.dll")]
        private static extern int get_file(string host_addr, string remote_file, string local_file, int option);
       

        private void btnQuary_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                //string fileName = "";
                //string path = "";

                try
                {
                    //mrFileIndexDT = SyncProxy.GetMrFileIndex(_patientID, (int)_visitID, Convert.ToInt32(gridView1.GetFocusedRowCellValue("FILE_NO")));
                    //if (mrFileIndexDT.Rows.Count > 0)
                    //{
                    //    fileName = mrFileIndexDT.Rows[0]["file_name"].ToString();
                    //    if (fileName == "")
                    //    {
                    //        return;
                    //    }
                    //}
                    //mrIndexDT = SyncProxy.GetMrIndex(_patientID, (int)_visitID);
                    //if (mrIndexDT.Rows.Count > 0)
                    //{
                    //    string strpatienturl = string.Empty;
                    //    string strlocaurl = string.Empty;
                    //    string strpath = string.Empty;
                    //    strpatienturl = _patientID;

                    //    strlocaurl = strpatienturl.Substring(strpatienturl.Length - 2);
                    //    strpath = strpatienturl.Substring(0, strpatienturl.Length - 2);
                    //    path = mrIndexDT.Rows[0]["access_path"].ToString();
                    //    if (path == "")
                    //    {
                    //        return;
                    //    } 
                    //    path += "\\" + strlocaurl + "\\" + strpath;

                    //    if (System.IO.File.Exists(@"c:\mrtemp.doc"))
                    //    {
                    //        System.IO.File.Delete(@"c:\mrtemp.doc");
                    //    }
                    //    int result = get_file("192.168.1.53", path + @"\" + fileName, @"c:\mrtemp.doc", 1);
                    //    if (result >= 0 && System.IO.File.Exists(@"c:\mrtemp.doc"))
                    //    {
                    //        DocumentsSelect ds = new DocumentsSelect();
                    //        ds.ShowDialog();
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Dialog.MessageBox(ex.Message, MessageBoxIcon.Information);
                }
            }
        }

    }
}
