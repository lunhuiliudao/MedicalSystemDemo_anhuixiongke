// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DictTextBox.cs
// 功能描述(Description)：    自定义控件：双击文本框弹出下拉列表
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.FrameWork;
using System;
using System.Data;

namespace MedicalSystem.Anes.CustomProject.Views
{
    /// <summary>
    /// 自定义控件：双击文本框弹出下拉列表
    /// </summary>
    public class DictTextBox : MedTextBox
    {
        /// <summary>
        /// 无参构造，绑定单击事件
        /// </summary>
        public DictTextBox()
        {
            Click += new EventHandler(DictTextBox_Click);
        }

        /// <summary>
        /// 单击事件：展示下拉列表
        /// </summary>
        private void DictTextBox_Click(object sender, EventArgs e)
        {
            this.ShowSeletion(this);
        }

        /// <summary>
        /// 双击事件：展示下拉列表
        /// </summary>
        private void DictTextBox_DoubleClick(object sender, EventArgs e)
        {
            this.ShowSeletion(this);
        }

        /// <summary>
        /// 根据配置的过滤条件进行过滤
        /// </summary>
        private string TransWhereString(string whereString)
        {
            if (whereString.ToLower().Contains("%config_AnesthesiaWardCode%".ToLower()))
                whereString = whereString.Replace("%config_AnesthesiaWardCode%", "'" + ExtendAppContext.Current.AnesWardCode + "'");
            if (whereString.ToLower().Contains("%config_OpertionDeptCode%".ToLower()))
                whereString = whereString.Replace("%config_OpertionDeptCode%", "'" + ExtendAppContext.Current.OperDeptCode + "'");
            return whereString;
        }

        /// <summary>
        /// 展示列表下拉框
        /// </summary>
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
            DataRow[] rows = ExtendAppContext.Current.CodeTables[textbox.DictTableName].Select(whereCondition);
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
