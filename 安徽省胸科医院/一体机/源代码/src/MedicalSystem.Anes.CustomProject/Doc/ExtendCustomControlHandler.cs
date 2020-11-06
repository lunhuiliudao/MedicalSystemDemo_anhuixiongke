// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      ExtendCustomControlHandler.cs
// 功能描述(Description)：    自定义控件对应Handler的扩展实体类，用于计算评分、ASA等级等功能
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using System;
using System.Collections.Generic;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 自定义控件对应Handler的扩展实体类，用于计算评分、ASA等级等功能
    /// </summary>
    public class ExtendCustomControlHandler : CustomControlHandler
    {
        private MTextBox _text1 = null;                          // 手术切口清洁程度
        private MTextBox _text2 = null;                          // 计算麻醉ASA分级
        private MTextBox _text3 = null;                          // 计算手术持续时间
        private MTextBox _text4 = null;                          // 计算总分
        private MTextBox _text5 = null;                          // 恢复室Steward苏醒评分
        private CustomControl _nnisControl = null;               // NNIS分级控件
        private Dictionary<string, List<CustomControl>> _groupCustomControls = new Dictionary<string, List<CustomControl>>(); 

        /// <summary>
        /// 将UI上的数据绑定到数据源
        /// </summary>
        public override void BindUIToData(CustomControl control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
            {
                return;
            }

            object value = null;
            if (control.MultiSelect)
            {
                Type type = typeof(string);
                if (control.SourceTableName.ToUpper().Equals("MED_CUSTOM_DATA"))
                {
                }
                else
                {
                    type = dataSources[control.SourceTableName.ToUpper()].Columns[control.SourceFieldName].DataType;
                }

                value = AssemblyHelper.GetValueFromString(type, control.Value);
            }
            else
            {
                if (control.SourceTableName == "MED_OPER_RISK_ESTIMATE" && control.SourceFieldName == "OPER_TYPE")
                {
                    if (control.SimpleValue == null) return;
                }

                value = control.SimpleValue;
            }

            this.SetFieldValue(control.SourceTableName, control.SourceFieldName, value);
        }

        /// <summary>
        /// 重写控件绑定事件
        /// </summary>
        public override void ControlSetting(CustomControl control)
        {
            base.ControlSetting(control);

            if (control.Name == "NNISCustomControl")
                _nnisControl = control;

            if (!string.IsNullOrEmpty(control.GroupName))
            {
                if (!_groupCustomControls.ContainsKey(control.GroupName))
                {
                    _groupCustomControls.Add(control.GroupName, new List<CustomControl>());
                }

                if (!_groupCustomControls[control.GroupName].Contains(control))
                {
                    _groupCustomControls[control.GroupName].Add(control);
                }

                // 自定义控件值变更事件
                control.ValueChanged += delegate
                {
                    // 单选
                    if (control.GroupName != "恢复室Steward苏醒评分")
                    if (control.SimpleValue != null)
                    {
                        List<CustomControl> controls = _groupCustomControls[control.GroupName];
                        foreach (CustomControl c in controls)
                        {
                            if (c != control)
                            {
                                c.SimpleValue = null;
                                c.Value = string.Empty;
                            }
                        }
                    }

                    //计算评分
                    this.CalculateRiskAssessmentData();
                };
            }
        }

        /// <summary>
        /// 计算评分的方法
        /// </summary>
        public void CalculateRiskAssessmentData()
        {
            //获取相关控件
            if (_text1 == null || _text2 == null || _text3 == null || _text4 == null)
            {
                foreach (IUIElementHandler handler in base.MedicalPaperUIElementHandlers)
                {
                    if (handler is TextBoxHandler)
                    {
                        TextBoxHandler h = handler as TextBoxHandler;
                        foreach (MTextBox text in h.GetCurrentControls)
                        {
                            if (text.Name.Trim() == "MTextBox6")
                                _text1 = text;
                            else if (text.Name.Trim() == "MTextBox7")
                                _text2 = text;
                            else if (text.Name.Trim() == "MTextBox8")
                                _text3 = text;
                            else if (text.Name.Trim() == "MTextBox11")
                                _text4 = text;
                            else if (text.Name.Trim() == "MTxt_Steward")
                                _text5 = text;
                        }

                        break;
                    }
                }
            }

            // 计算手术切口清洁程度
            if (_text1 != null)
            {
                _text1.Text = string.Empty;
                this.SetControlValue(_groupCustomControls["手术切口清洁程度"], _text1);
            }
           
            // 计算麻醉ASA分级
            if (_text2 != null)
            {
                _text2.Text = string.Empty;
                this.SetControlValue(_groupCustomControls["ASA分级"], _text2);
            }
          
            // 计算手术持续时间
            if (_text3 != null)
            {
                _text3.Text = string.Empty;
                this.SetControlValue(_groupCustomControls["手术持续时间"], _text3);
            }

            // 恢复室Steward苏醒评分
            if (_text5 != null)
            {
                _text5.Text = string.Empty;
                this.SetGroupControlValue(_groupCustomControls["恢复室Steward苏醒评分"], _text5);
            } 

            // 计算总分
            if (_text4 != null)
            {
                _text4.Text = "0";
                if (!string.IsNullOrEmpty(_text1.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text1.Text.Trim())).ToString();
                }
                if (!string.IsNullOrEmpty(_text2.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text2.Text.Trim())).ToString();
                }
                if (!string.IsNullOrEmpty(_text3.Text.Trim()))
                {
                    _text4.Text = (Convert.ToInt32(_text4.Text) + Convert.ToInt32(_text3.Text.Trim())).ToString();
                }

                _nnisControl.SimpleValue = Convert.ToInt32(_text4.Text.Trim());
            }
        }

        /// <summary>
        /// 设置控件的值
        /// </summary>
        private void SetControlValue(List<CustomControl> customControls, MTextBox text)
        {
            foreach (CustomControl customControl in customControls)
            {
                if (customControl.SimpleValue != null)
                {
                    int v;
                    if (int.TryParse(customControl.SimpleValue.ToString(), out v))
                    {
                        text.Text = v.ToString();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 设置同一组自定义控件的值
        /// </summary>
        private void SetGroupControlValue(List<CustomControl> customControls, MTextBox text)
        {
            int total = 0;
            foreach (CustomControl customControl in customControls)
            {
                if (customControl.SimpleValue != null)
                {
                    int v;
                    if (int.TryParse(customControl.SimpleValue.ToString(), out v))
                    {
                        total += v;
                        text.Text = total.ToString(); 
                    }
                }
            }
        }
    }
}
