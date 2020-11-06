using System;
using System.Collections.Generic;
using System.Text;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;
using System.Data;
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Client.FrameWork;

namespace MedicalSystem.Anes.Document.Documents
{
   public class RichTextBoxHandler:UIElementHandler<MRichTextBox>
    {  
       /// <summary>
        /// 绑定控件内容到数据源
       /// </summary>
       /// <param name="control"></param>
       /// <param name="dataSources"></param>
       public override void BindDataToUI(MRichTextBox control, Dictionary<string, System.Data.DataTable> dataSources)
       { 
           if (dataSources.Count == 0) 
               return;
           if (string.IsNullOrEmpty(control.SourceTableName))
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

           if (!string.IsNullOrEmpty(control.SourceTableName) && !string.IsNullOrEmpty(control.SourceFieldName))
           {
               control.SetData(GetFieldValue(control.SourceTableName, control.SourceFieldName));
           }
           if (control.Data is DateTime && (IsDateTimeFomrat(control.Format) || IsFunctionFormat(control.Format)))
           {
               control.Text = FormatDateTime((DateTime)control.Data, control.Format);
           }
           else if (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName) && control.DictValueFieldName.ToLower() != control.DisplayFieldName.ToLower() && !control.MultiSelect)
           {
               control.Text = TransDictCode(control.DictTableName, control.DictValueFieldName, control.DisplayFieldName, control.DictWhereString, control.Data);
           }
           else if (control.MultiSelect)
           {
               if (control.Data != null)
               {
                   control.Text = control.Data.ToString();
               }
           }
       }
       /// <summary>
       ///  绑定数据源数据到控件
       /// </summary>
       /// <param name="control"></param>
       /// <param name="dataSources"></param>
       public override void BindUIToData(MRichTextBox control, Dictionary<string, System.Data.DataTable> dataSources)
       {
           if (dataSources.Count == 0) return;
           if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
               return; 
           if (control.ReadOnly == true  || control.Enabled == false)
               return;

           if (string.IsNullOrEmpty(control.Text))
               control.Data = DBNull.Value;
           else
           {
               if (string.IsNullOrEmpty(control.DictTableName) && string.IsNullOrEmpty(control.DictValueFieldName))
               {
                   SetControlValue(control);
               }
               else if (control.CanEdit)
               {
                   //如果控件同时支持下拉框和文本编辑功能
                   //如果从下拉框中选择的值跟实际编辑的文本值不相同(表示用户修改了从下拉框中选择的值)
                   //则根据当前的文本值重新设置实际Data值
                   if (!string.IsNullOrEmpty(control.SelectedText) && control.SelectedText.Trim() != control.Text.Trim())
                   {
                       SetControlValue(control);
                   }
               }
           }

           SetFieldValue(control.SourceTableName, control.SourceFieldName, control.Data);
       }
       
       /// <summary>
       /// 控件事件属性设置
       /// </summary>
       /// <param name="control"></param>
       public override void ControlSetting(MRichTextBox control)
       {
           if (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName))
           {
                if (ApplicationConfiguration.DoubleSelect)// 和一体机一致
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
               base.HasDirty = true;

               if (!string.IsNullOrEmpty(control.DictTableName) && !string.IsNullOrEmpty(control.DictValueFieldName) /*&& control.HasLookUpItems==false*/ && control.CanEdit)
               {
                   SetControlValue(control);
               }
               
           };
       }
       
           /// <summary>
       /// 从字典下拉框中选择
       /// </summary>
       /// <param name="textBox"></param>
       private void ShowPopupForm(MRichTextBox textbox)
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
               ShowDateTimeSelector(textbox, dateTime, formatString);
           }
           else
           {
               ShowSeletion(textbox);
           }

       }
       /// <summary>
       /// 设置控件的实际值
       /// </summary>
       /// <param name="control"></param>
       private void SetControlValue(MRichTextBox control)
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
               else if (control.InputType == MedInputType.Nurmeric)
                   control.Data = Convert.ToDecimal(control.Text);
           }
           if (control.Data is DateTime && !string.IsNullOrEmpty(control.Format) && base.DataSource[control.SourceTableName].Columns[control.SourceFieldName].DataType == typeof(string))
           {
               control.Data = FormatDateTime((DateTime)control.Data, control.Format);
           }
       }
       /// <summary>
       /// 列表下拉框
       /// </summary>
       /// <param name="textBox"></param>
       private void ShowSeletion(MRichTextBox textbox)
       {
           string whereCondition = textbox.DictWhereString;
           if (string.IsNullOrEmpty(textbox.DictWhereString) && textbox.DictTableName.ToUpper().Trim().Equals("MED_OPERATING_ROOM"))
           {
               string bedType = "0";
               //if (Configurations.IsYouDaoProgram || Globals.SystemStatus == Globals.ProgramStatus.PACURecord)
               //{
               //    bedType = "1";
               //}
               whereCondition = "BED_TYPE = '" + bedType + "'";
           }
           DataRow[] rows = BuildPopupItemsData(textbox.DictTableName, whereCondition);
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
                                  //textbox.Data = textbox.Data.ToString() + "," + rows[result][textbox.DictValueFieldName].ToString();
                                  textbox.Data = textbox.Data.ToString() + "+" + rows[result][textbox.DictValueFieldName].ToString();

                              }
                              textbox.ProgramChanging = true;
                              if (string.IsNullOrEmpty(textbox.Text.Trim()))
                              {
                                  textbox.SelectedText = rows[result][textbox.DisplayFieldName].ToString();
                              }
                              else
                              {
                                  //textbox.SelectedText = textbox.Text + "," + rows[result][textbox.DisplayFieldName].ToString();
                                  textbox.SelectedText = textbox.Text + "+" + rows[result][textbox.DisplayFieldName].ToString();
                              }
                          }
                          else
                          {
                              textbox.Data = rows[result][textbox.DictValueFieldName].ToString();
                              textbox.ProgramChanging = true;
                              textbox.SelectedText = rows[result][textbox.DisplayFieldName].ToString();
                              //textbox.Text = rows[result][textbox.DisplayFieldName].ToString();
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
       private void ShowDateTimeSelector(MRichTextBox textbox, DateTime dateTime, string formatString)
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
    }
}
