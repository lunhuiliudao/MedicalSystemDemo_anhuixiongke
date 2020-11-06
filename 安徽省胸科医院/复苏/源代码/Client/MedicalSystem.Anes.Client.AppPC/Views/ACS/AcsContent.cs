using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class AcsContent : BaseView
    {
        CommonRepository commonRepository = new CommonRepository();

        AccountRepository accountRepository = new AccountRepository();

        public AcsContent()
        {
            InitializeComponent();
        }
        private void AcsContent_Load(object sender, EventArgs e)
        {
            DesSecurity.authFileName = Application.StartupPath + "\\Hs_medsys.key";
        }
        public void SetContext(string contexts)
        { 
            webBrowserContent.DocumentText = contexts;
        }

        public void SetContextKeyWords(string keyWords)
        {

            txtKeyWords.Text = keyWords;
            btnSearch_Click(null, null);
        }
        DataTable dtKeyWordsContext = null;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DesSecurity.authFileName = Application.StartupPath + "\\Hs_medsys.key";
            lbDrugName.Text = "药品名";
            dtKeyWordsContext = null;
            if (!string.IsNullOrEmpty(txtKeyWords.Text))
            {
                List<STANDARD_KEYWORD> list = commonRepository.GetAcsContextByKeyWord(txtKeyWords.Text).Data;

                dtKeyWordsContext = ModelHelper<STANDARD_KEYWORD>.ConvertListToDataTable(list);
                if (dtKeyWordsContext.Rows.Count > 1)
                {
                    lbKeyWordsList.Visible = true;
                    lbKeyWordsList.Width = txtKeyWords.Width;
                    lbKeyWordsList.Top = txtKeyWords.Top + txtKeyWords.Height;
                    lbKeyWordsList.Left = txtKeyWords.Left;

                    DataRow row = null;
                    lbKeyWordsList.Items.Clear();

                    for (int index = 0; index < dtKeyWordsContext.Rows.Count; index++)
                    {
                        row = dtKeyWordsContext.Rows[index];
                        if (row["WORD"] != null && row["WORD"] != DBNull.Value)
                        {
                            lbKeyWordsList.Items.Add(row["WORD"].ToString());

                        }
                    }
                }
                else if (dtKeyWordsContext.Rows.Count == 1)
                {
                    DataRow row = dtKeyWordsContext.Rows[0];
                    ShowContent(row);
                }
            }
        }


        private void ShowContent(DataRow row)
        {
            string contexts = "";

            if (row["CONTENT"] != null && row["CONTENT"] != DBNull.Value)
            {
               // byte[] value = Convert.FromBase64String(row["CONTENT"].ToString());
                byte[] value = (byte[])row["CONTENT"];
                ////读取blob
                //contexts = Encoding.Default.GetString(value);
                //contexts = Convert.ToBase64String(value);
                contexts = Encoding.Unicode.GetString(value);
                //解密Blob的字符串

                contexts = DesSecurity.Decrypt(contexts); //StringHelper.Base64Decode(contexts);// 
            }

            string contextsCopy = contexts;
            string AcsAddress = ApplicationConfiguration.AcsAddress;
            contextsCopy = contextsCopy.Replace("../upload/", AcsAddress + "/upload/");

            lbDrugName.Text = txtKeyWords.Text;

            SetContext(contextsCopy);
        }

        private void lbKeyWordsList_DoubleClick(object sender, EventArgs e)
        {
            if (lbKeyWordsList.SelectedItem != null)
            {
                txtKeyWords.Text = lbKeyWordsList.SelectedItem.ToString();
                lbKeyWordsList.Visible = false;
                if (dtKeyWordsContext != null)
                {
                    DataRow[] rows = dtKeyWordsContext.Select(" WORD   = '" + txtKeyWords.Text + "'");
                    if (rows != null && rows.Length > 0)
                    {
                        ShowContent(rows[0]);
                    }
                }

            }

        }
    }
}
