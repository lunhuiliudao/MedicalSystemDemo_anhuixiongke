using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Medicalsystem.Anes.Framework;
using System.Collections;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Client.CustomProject;
using MedicalSystem.Anes.Document;

namespace Medicalsystem.Anes.Custom.CustomProject
{
    public partial class MultiPrintFrm : DevExpress.XtraEditors.XtraForm
    {
        public MultiPrintFrm()
        {
            InitializeComponent();
        }

        private void MultiPrintFrm_Load(object sender, EventArgs e)
        {
            List<string> fileList = new List<string>();
            //foreach (CheckedListBoxItem boxItem in chkUpFileList.Items)
            //{
            //    if (boxItem.CheckState == CheckState.Checked)
            //    {
            //        fileList.Add(boxItem.Value.ToString());
            //    }
            //}

            //if (!string.IsNullOrEmpty(ApplicationConfiguration.multiPrintNames))
            //{
            //    IEnumerator ie = ApplicationConfiguration.multiPrintNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).GetEnumerator();
            //    while (ie.MoveNext())
            //    {
            //        fileList.Add(ie.Current.ToString());
            //    }
            //}             //todo


            Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();

            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
            {
                CheckedListBoxItem boxItemDocCheck = new CheckedListBoxItem(keyValuePair.Key, keyValuePair.Value.Key);
                chkDocCheckList.Items.Add(boxItemDocCheck);
                if (fileList.Contains(keyValuePair.Key))
                {
                    boxItemDocCheck.CheckState = CheckState.Checked;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("文书是否要集中打印", "集中打印", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            foreach (CheckedListBoxItem item in chkDocCheckList.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(item.Value.ToString());

                    //没有找到退出
                    if (string.IsNullOrEmpty(document.Caption))
                    {
                        DialogResult dialogResult = MessageBoxFormPC.Show(string.Format("无法加载文书'{0}'的设计模版,请确保模版文件已经存在", item.Value.ToString()),
                                "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }

                    try
                    {

                        Type t = Type.GetType(document.Type);
                        CustomBaseDoc baseDoc = Activator.CreateInstance(t) as CustomBaseDoc;
                        baseDoc.BackColor = Color.White;
                        baseDoc.Name = item.Value.ToString();
                        baseDoc.HideScrollBar();
                        baseDoc.Initial();
                        baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                        bool IsPrintSuccess = baseDoc.PrintBaseDoc();

                        List<string> fileList = new List<string>();
                        foreach (CheckedListBoxItem boxItem in chkDocCheckList.Items)
                        {
                            if (boxItem.CheckState == CheckState.Checked)
                            {
                                fileList.Add(boxItem.Value.ToString());
                            }
                        }
                        //ApplicationConfiguration.multiPrintNames = string.Join(",", fileList.ToArray());

                        //(new ConfigurationDA()).UpdateConfigTableDataTable(ExtendApplicationContext.Current.CommDict.ConfigDict);

                        //if (ExtendApplicationContext.Current.PatientInformation != null && IsPrintSuccess)
                        //{
                        //    Common.MED_ANES_BUTTON_MARKDataTable buttonMarkDT = new CommonDA().GetAnesDocButtonMarkData(ExtendApplicationContext.Current.PatientInformation.PatientID,
                        //    ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID, MedicalDocSettings.ReturnDocNameByKey(baseDoc.Name));
                        //    if (buttonMarkDT.Count == 0)
                        //    {
                        //        Common.MED_ANES_BUTTON_MARKRow dr = buttonMarkDT.NewMED_ANES_BUTTON_MARKRow();
                        //        dr.PATIENT_ID = ExtendApplicationContext.Current.PatientInformation.PatientID;
                        //        dr.VISIT_ID = ExtendApplicationContext.Current.PatientInformation.VisitID;
                        //        dr.OPER_ID = ExtendApplicationContext.Current.PatientInformation.OperID;
                        //        dr.BUTTON_NAME = MedicalDocSettings.ReturnDocNameByKey(baseDoc.Name);
                        //        dr.RGB = new CommonDA().returnRGB(Color.Blue);
                        //        buttonMarkDT.AddMED_ANES_BUTTON_MARKRow(dr);

                        //    }
                        //    else if (buttonMarkDT.Count > 0)
                        //    {
                        //        Common.MED_ANES_BUTTON_MARKRow dr = buttonMarkDT[0] as Common.MED_ANES_BUTTON_MARKRow;
                        //        dr.RGB = new CommonDA().returnRGB(Color.Blue);
                        //    }
                        //    try
                        //    {
                        //        int r = new CommonDA().UpdateAnesDocButtonMarkData(buttonMarkDT);
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        ExceptionHandler.Handle(ex);
                        //    }                 //todo
                        //}

                    }
                    catch
                    {

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}