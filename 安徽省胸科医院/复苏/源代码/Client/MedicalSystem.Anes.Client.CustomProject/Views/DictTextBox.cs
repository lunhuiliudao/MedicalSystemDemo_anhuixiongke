using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.CustomProject.Views
{
    public class DictTextBox : MedTextBox
    {
        public DictTextBox()
        {
            //if (ApplicationConfiguration.DoubleSelect)
            //{
            //    DoubleClick += new EventHandler(DictTextBox_DoubleClick);
            //}
            //else
            {
                Click += new EventHandler(DictTextBox_Click);
            }
        }

        private void DictTextBox_Click(object sender, EventArgs e)
        {
            ShowSeletion(this);
        }

        private void DictTextBox_DoubleClick(object sender, EventArgs e)
        {
            ShowSeletion(this);
        }

        private string TransWhereString(string whereString)
        {
            if (whereString.ToLower().Contains("%config_AnesthesiaWardCode%".ToLower()))
                whereString = whereString.Replace("%config_AnesthesiaWardCode%", "'" + ExtendApplicationContext.Current.AnesthesiaWardCode + "'");
            if (whereString.ToLower().Contains("%config_OpertionDeptCode%".ToLower()))
                whereString = whereString.Replace("%config_OpertionDeptCode%", "'" + ExtendApplicationContext.Current.OperRoom + "'");
            return whereString;

        }

        /// <summary>
        /// 列表下拉框
        /// </summary>
        /// <param name="textBox"></param>
        private void ShowSeletion(MedTextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.DictTableName))
            {
                return;
            }
            string whereCondition = textbox.DictWhereString;
            if (string.IsNullOrEmpty(textbox.DictWhereString) && textbox.DictTableName.ToUpper().Trim().Equals("MED_OPERATING_ROOM"))
            {
                string bedType = "0";
                whereCondition = "BED_TYPE = '" + bedType + "'";
            }
            whereCondition = TransWhereString(whereCondition);
            DataRow[] rows = ExtendApplicationContext.Current.CodeTables[textbox.DictTableName].Select(whereCondition);
            string displayName = !string.IsNullOrEmpty(textbox.DisplayFieldName) ? textbox.DisplayFieldName : textbox.DictValueFieldName;
            textbox.HasLookUpItems = rows.Length > 0;
            Dialog.ShowCustomSelection(rows, displayName, textbox,
               new System.Drawing.Size(textbox.Width, 300), new EventHandler(delegate(object sender1, EventArgs e1)
               {
                   if (sender1 is int)
                   {
                       int result = (int)sender1;
                       if (result > -1)
                       {
                           if (textbox.MultiSelect)
                           {
                               if (textbox.Data == null || string.IsNullOrEmpty(textbox.Data.ToString().Trim()))
                               {
                                   textbox.Data = rows[result][textbox.DictValueFieldName].ToString();
                               }
                               else
                               {
                                   textbox.Data = textbox.Data.ToString() + "," + rows[result][textbox.DictValueFieldName].ToString();
                               }
                               textbox.ProgramChanging = true;
                               if (string.IsNullOrEmpty(textbox.Text.Trim()))
                               {
                                   textbox.Text = rows[result][textbox.DisplayFieldName].ToString();
                               }
                               else
                               {
                                   textbox.Text = textbox.Text + "," + rows[result][textbox.DisplayFieldName].ToString();
                               }
                           }
                           else
                           {
                               textbox.Data = rows[result][textbox.DictValueFieldName].ToString();
                               textbox.ProgramChanging = true;
                               textbox.Text = rows[result][textbox.DisplayFieldName].ToString();
                           }
                       }
                   }

               }));
        }
    }
}
