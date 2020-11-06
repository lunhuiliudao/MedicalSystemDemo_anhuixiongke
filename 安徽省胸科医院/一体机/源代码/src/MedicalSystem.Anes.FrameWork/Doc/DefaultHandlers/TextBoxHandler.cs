using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MedicalSystem.Anes.Document.Controls;
using System.Data;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Configurations;
using System.ComponentModel;
using MedicalSystem.Anes.Document.Constants;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Anes.Framework.Utilities;

namespace MedicalSystem.Anes.Document.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public class TextBoxHandler : UIElementHandler<MTextBox>
    {
        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindUIToData(MTextBox control, Dictionary<string, DataTable> dataSources)
        {
            if (dataSources.Count == 0) return;
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;
            if (control.ReadOnly == true || control.Enabled == false)
                return;
            if (string.IsNullOrEmpty(control.Text))
            {
                control.Data = DBNull.Value;
            }
            else
            {
                if (control.SourceTableName != null && control.SourceTableName.Equals("MED_OPERATION_EXTENDED"))
                {

                }
                if (string.IsNullOrEmpty(control.DictTableName) && string.IsNullOrEmpty(control.DictValueFieldName))
                {
                    SetControlValue(control);
                }
                else if (control.CanEdit)
                {
                    bool isAleadySetValue = false;
                    if (!string.IsNullOrEmpty(control.SelectedText) && control.SelectedText.Trim() != control.Text.Trim())
                    {
                        isAleadySetValue = true;
                        SetControlValue(control);
                    }
                    if (control.SelectedData != null && control.SelectedData != control.Data)
                    {
                        if (!string.IsNullOrEmpty(control.SelectedText) && control.SelectedText.Trim() == control.Text.Trim())
                        {
                            control.Data = control.SelectedData;
                        }
                        else
                        {
                            if (!isAleadySetValue)
                            {
                                SetControlValue(control);
                            }
                        }
                    }
                    else if (control.SelectedData == null && (control.Data == null || control.Data == DBNull.Value))
                    {
                        SetControlValue(control);
                    }
                    if (control.SelectedData == null && control.Data != null && !string.IsNullOrEmpty(control.Text.ToString())
                        && control.Data.ToString() != control.Text && !string.IsNullOrEmpty(control.DictTableName))
                    {
                        DataTable dictTable = ExtendAppContext.Current.CodeTables[control.DictTableName];
                        string fieldName = control.DictValueFieldName;
                        string displayName = control.DisplayFieldName;
                        DataRow[] rows = dictTable.Select(string.Format("{0} = '{1}'", fieldName, control.Data.ToString()));
                        if (rows.Length > 0)
                        {
                            if (rows[0][displayName].ToString() != control.Text)
                            {
                                SetControlValue(control);
                            }
                        }
                    }
                }
            }
            if (control.SourceFieldName.Equals("CERVIX"))
            {
                object o = control.Data;
                string s = control.Text;
            }
            SetFieldValue(control.SourceTableName, control.SourceFieldName, control.Data);
        }
        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(MTextBox control, Dictionary<string, DataTable> dataSources)
        {
            if (dataSources.Count == 0) return;
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;
            if (!dataSources.ContainsKey(control.SourceTableName.ToUpper()))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表,请添加此绑定数据源!", control.SourceTableName.ToUpper()));
            if (dataSources[control.SourceTableName.ToUpper()].Rows.Count != 1 && control.SourceTableName.ToUpper() != "MED_OPERATION_EXTENDED" && control.SourceTableName.ToUpper() != "MED_POSTOPERATIVE_EXTENDED" && control.SourceTableName.ToUpper() != "MED_PREOPERATIVE_EXPANSION"
                && control.SourceTableName.ToUpper() != "MED_OPER_ANALGESIC_TOTAL" && control.SourceTableName.ToUpper() != "MED_OPER_ANALGESIC_MEDICINE")
                throw new NotImplementedException(string.Format("在名为{0}的表中查询到多条记录,应仅只包含当前患者的唯一记录!", control.SourceTableName.ToUpper()));
            if (!dataSources[control.SourceTableName.ToUpper()].Columns.Contains(control.SourceFieldName) && control.SourceTableName.ToUpper() != "MED_OPERATION_EXTENDED" && control.SourceTableName.ToUpper() != "MED_POSTOPERATIVE_EXTENDED" && control.SourceTableName.ToUpper() != "MED_PREOPERATIVE_EXPANSION"
                && control.SourceTableName.ToUpper() != "MED_OPER_ANALGESIC_TOTAL" && control.SourceTableName.ToUpper() != "MED_OPER_ANALGESIC_MEDICINE")
            {
                throw new NotImplementedException(string.Format("在名为{0}的表中未找到名为{1}的数据列!", control.SourceTableName.ToUpper(), control.SourceFieldName));
            }
            if (control.SourceTableName.ToUpper() != "MED_OPERATION_EXTENDED" && control.SourceTableName.ToUpper() != "MED_POSTOPERATIVE_EXTENDED" && control.SourceTableName.ToUpper() != "MED_PREOPERATIVE_EXPANSION"
                && control.SourceTableName.ToUpper() != "MED_OPER_ANALGESIC_TOTAL" && control.SourceTableName.ToUpper() != "MED_OPER_ANALGESIC_MEDICINE")
            {
                int maxLength = dataSources[control.SourceTableName.ToUpper()].Columns[control.SourceFieldName].MaxLength;
                if (maxLength != -1)
                    control.MaxLength = maxLength;
            }
            if (control.SourceFieldName == "WARD_CODE")
            {

            }
            if (!string.IsNullOrEmpty(control.SourceTableName) && !string.IsNullOrEmpty(control.SourceFieldName))
            {
                control.SetData(GetFieldValue(control.SourceTableName, control.SourceFieldName));
            }
            object data = control.Data;
            if (control.Data is DateTime && (IsDateTimeFomrat(control.Format)))
            {
                control.Tag = "1";
                control.Text = FormatDateTime((DateTime)control.Data, control.Format);
            }
            else if (control.Data is DateTime && IsFunctionFormat(control.Format))
            {
                control.Tag = "1";
                //control.Text = DateDiff.CalAge((DateTime)control.Data, DateTime.Now);
                List<MED_OPERATION_MASTER> operMaster = new ModelHandler<MED_OPERATION_MASTER>().FillModel(dataSources["MED_OPERATION_MASTER"]);
                if (operMaster.Count > 0)
                {
                    control.Text = DateDiff.CalAge(Convert.ToDateTime(control.Data), operMaster[0].SCHEDULED_DATE_TIME.Value);
                }
                else
                {
                    control.Text = DateDiff.CalAge(Convert.ToDateTime(control.Data), DateTime.Now);
                }
            }
            else if (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName) && control.DictValueFieldName.ToLower() != control.DisplayFieldName.ToLower() && !control.MultiSelect)
            {
                control.Text = GetDisplayByValue(control, control.Data.ToString());// TransDictCode(control.DictTableName, control.DictValueFieldName, control.DisplayFieldName, control.DictWhereString, control.Data);
            }
            else if (control.MultiSelect)
            {
                if (control.Data != null)
                {
                    control.Text = control.Data.ToString();
                }
            }
            control.Data = data;
            if (!string.IsNullOrEmpty(control.InitValue) && control.InitValue.ToLower() == "datetoage")
            {
                if (!string.IsNullOrEmpty(control.Data.ToString()))
                {
                    List<MED_OPERATION_MASTER> operMaster = new ModelHandler<MED_OPERATION_MASTER>().FillModel(dataSources["MED_OPERATION_MASTER"]);
                    if (operMaster.Count > 0)
                    {
                        control.Text = DateDiff.CalAge(Convert.ToDateTime(control.Data), operMaster[0].SCHEDULED_DATE_TIME.Value);
                    }
                    else
                    {
                        control.Text = DateDiff.CalAge(Convert.ToDateTime(control.Data), DateTime.Now);
                    }
                }
                else
                {
                    control.Text = "未填";
                }
            }
            if (!string.IsNullOrEmpty(control.InitValue) && control.InitValue.ToLower() == "patinfo")
            {
                if (!string.IsNullOrEmpty(control.Data.ToString()))
                {
                    if (control.Text.Equals("0"))
                    {
                        control.Text = "";
                    }
                }
                else
                {
                    control.Text = "";
                }
            }
        }
        /// <summary>
        /// 控件事件设置
        /// </summary>
        /// <param name="control"></param>
        public override void ControlSetting(MTextBox control)
        {
            if (IsDateTimeFomrat(control.Format) || (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName)))
            {
                if (ApplicationConfiguration.DoubleSelect && !IsDateTimeFomrat(control.Format))
                {
                    control.DoubleClick += delegate
                    {
                        ShowPopupForm(control);
                    };
                }
                else
                {
                    control.Click += delegate
                    {
                        ShowPopupForm(control);
                    };
                    control.Enter += delegate
                    {
                        ShowPopupForm(control);
                    };
                }


            }
            control.TextChanged += delegate
            {
                if (control.ReadOnly)
                {
                }
                else
                {
                    base.HasDirty = true;

                    if (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName) /*&& control.HasLookUpItems == false*/ && control.CanEdit)
                    {
                        SetControlValue(control);
                    }
                }
            };
        }
        /// <summary>
        /// 设置控件的实际值
        /// </summary>
        /// <param name="control"></param>
        protected void SetControlValue(MTextBox control)
        {
            if (control.MultiSelect)
            {
                control.Data = control.Text;
            }
            else
            {
                if (control.InputType == MedInputType.Integer)
                    control.Data = Convert.ToInt32(control.Text);
                else if (control.InputType == MedInputType.String || control.InputType == MedInputType.General)
                    control.Data = control.Text;
                else if (control.InputType == MedInputType.Nurmeric && !string.IsNullOrEmpty(control.Text.Trim()))
                    control.Data = Convert.ToDecimal(control.Text);
                else if (control.InputType == MedInputType.Date || control.InputType == MedInputType.Time)
                    control.Data = Convert.ToDateTime(control.Text);
            }
            if (control.Data is DateTime && !string.IsNullOrEmpty(control.Format) && (control.SourceTableName.ToUpper() == "MED_CUSTOM_DATA" || base.DataSource[control.SourceTableName].Columns[control.SourceFieldName].DataType == typeof(string)))
            {
                control.Data = FormatDateTime((DateTime)control.Data, control.Format);
            }
        }
        /// <summary>
        /// 从字典下拉框中选择
        /// </summary>
        /// <param name="textBox"></param>
        private void ShowPopupForm(MTextBox textbox)
        {
            //如果只读 退出
            if (textbox.ReadOnly)
                return;
            //如果是时间下拉框
            if (IsDateTimeFomrat(textbox.Format))
            {
                DateTime dateTime;
                if (textbox.Data != null && textbox.Data is DateTime)
                {
                    dateTime = (DateTime)textbox.Data;
                }
                else if (!DateTime.TryParse(textbox.Text.Replace(",", "-").Replace("/", "-"), out dateTime))
                {
                    dateTime = DateTime.Now;
                }
                string replaceString = "-";
                string formatString = TransDateFormat(textbox.Format, replaceString);
                ShowDevDateTimeEditor(textbox, dateTime, formatString);

            }
            else
            {
                ShowSeletion(textbox);
            }

        }
        /// <summary>
        /// 列表下拉框
        /// </summary>
        /// <param name="textBox"></param>
        private void ShowSeletion(MTextBox textbox)
        {
            string whereCondition = textbox.DictWhereString;
            if (string.IsNullOrEmpty(textbox.DictWhereString) && textbox.DictTableName.ToUpper().Trim().Equals("MED_OPERATING_ROOM"))
            {
                string bedType = "0";
                whereCondition = "BED_TYPE = '" + bedType + "'";
            }
            DataRow[] rows = BuildPopupItemsData(textbox.DictTableName, whereCondition);
            string displayName = !string.IsNullOrEmpty(textbox.DisplayFieldName) ? textbox.DisplayFieldName.ToUpper() : textbox.DictValueFieldName.ToUpper();
            int selectionWith = textbox.Width;
            if (textbox.DictTableName.ToUpper().Trim().Equals("MED_HIS_USERS"))
            {
                displayName += ",USER_JOB_ID";
                selectionWith = textbox.Width * 2;
            }
            //end
            textbox.HasLookUpItems = rows.Length > 0;
            Dialog.ShowCustomSelection(rows, displayName, textbox,
               new System.Drawing.Size(selectionWith, 300), new EventHandler(delegate(object sender1, EventArgs e1)
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
                                   textbox.SelectedData = rows[result][textbox.DictValueFieldName].ToString();
                               }
                               else
                               {
                                   textbox.SelectedData = textbox.Data.ToString() + "," + rows[result][textbox.DictValueFieldName].ToString();
                               }
                               textbox.ProgramChanging = true;
                               if (string.IsNullOrEmpty(textbox.Text.Trim()))
                               {
                                   textbox.SelectedText = rows[result][textbox.DisplayFieldName].ToString();
                               }
                               else
                               {
                                   textbox.SelectedText = textbox.Text + "," + rows[result][textbox.DisplayFieldName].ToString();
                               }
                           }
                           else
                           {
                               textbox.SelectedData = rows[result][textbox.DictValueFieldName].ToString();
                               textbox.ProgramChanging = true;
                               textbox.SelectedText = rows[result][textbox.DisplayFieldName].ToString();
                           }
                       }
                   }

               }));
        }
        /// <summary>
        ///显示下拉时间选择框
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="dateTime"></param>
        /// <param name="formatString"></param>
        private void ShowDateTimeSelector(MTextBox textbox, DateTime dateTime, string formatString)
        {
            Dialog.ShowDateTimeSelector(dateTime, textbox,
                 new EventHandler(delegate(object sender, EventArgs e)
                 {
                     if (sender is DateTime)
                     {
                         textbox.Data = (DateTime)sender;
                         textbox.SetText();
                     }
                 }), formatString);
        }

        private void ShowDevDateTimeEditor(MTextBox textbox, DateTime dateTime, string formatString)
        {
            string editFormatString = "d";
            if (formatString.Equals("yyyy-MM-dd"))
            {
                editFormatString = "d";
            }
            else if (formatString.Equals("yyyy年MM月dd日"))
            {
                formatString = "D";
                editFormatString = "d";
            }
            else if (formatString.Equals("yyyy-MM-dd HH:mm"))
            {
                editFormatString = "t";
            }
            else if (formatString.Equals("HH:mm"))
            {
                editFormatString = "t";
            }
            Dialog.ShowDevDateTimeEditor(dateTime, textbox, new System.Drawing.Rectangle(0, 0, textbox.Width, textbox.Height), new EventHandler(delegate(object sender, EventArgs e)
                {
                    if (sender != null && sender.ToString() != string.Empty)
                    {
                        textbox.Data = (DateTime)sender;
                        textbox.SetText();
                    }
                    else
                    {
                        textbox.Data = null;
                        textbox.Text = string.Empty;
                    }
                }), formatString, editFormatString);
        }

        /// <summary>
        /// 字典名称转换。
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetDisplayByValue(MTextBox textbox, string value)
        {
            string display = "";
            if (textbox.DictTableName != null
                && !string.IsNullOrEmpty(textbox.DisplayFieldName)
                && !string.IsNullOrEmpty(textbox.DictValueFieldName)
                && textbox.DisplayFieldName.ToUpper() != textbox.DictValueFieldName.ToUpper())
            {
                string whereCondition = textbox.DictWhereString;
                if (string.IsNullOrEmpty(textbox.DictWhereString) && textbox.DictTableName.ToUpper().Trim().Equals("MED_OPERATING_ROOM"))
                {
                    string bedType = "0";
                    whereCondition = "BED_TYPE = '" + bedType + "'";
                }
                DataRow[] rows = BuildPopupItemsData(textbox.DictTableName, whereCondition);

                IEnumerable<string> query = rows
                    .Where(x => Convert.ToString(x[textbox.DictValueFieldName]) == value)
                    .Select(x => Convert.ToString(x[textbox.DisplayFieldName]));
                display = query.FirstOrDefault() ?? value;
                return display;
            }

            return value;
        }
    }
}
