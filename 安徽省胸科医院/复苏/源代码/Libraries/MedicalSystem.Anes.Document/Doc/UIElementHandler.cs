using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MedicalSystem.Anes.Document; 
using System.Drawing; 
using MedicalSystem.Anes.Document.Controls; 
using DevExpress.XtraEditors;
using System.Reflection;
using System.Collections; 
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Document.Constants;
using MedicalSystem.Anes.Client.Service;
using MedicalSystem.Anes.Domain;

namespace MedicalSystem.Anes.Document.Documents
{
    public abstract  class UIElementHandler<T> :IUIElementHandler where T :Control
    {
       /// <summary>
       /// 当前控件的集合
       /// </summary>
       private   List<T> _controls = new List<T>();
       /// <summary>
       /// 当前文书包含的其它UIElementHandler集合
       /// </summary>
       private List<IUIElementHandler> _medicalPaperUIElementHandlers = new List<IUIElementHandler>();
       /// <summary>
       /// 数据源集合
       /// </summary>
       private Dictionary<string, DataTable> _dataSources = null;
       /// <summary>
       /// 错误提供控件
       /// </summary>
       private ErrorProvider _errorProvider = null;
       /// <summary>
       /// 下拉框数据项的缓存
       /// </summary>
       private static Dictionary<string, DataRow[]> _popupItemsData = new Dictionary<string, DataRow[]>();
       /// <summary>
       /// 是否有脏数据
       /// </summary>
       private bool _hasDirty = false;
       /// <summary>
       /// 表示此Handler的名称
       /// </summary>
       private string _name = string.Empty;

       protected BaseDoc _attatchDoc = null;

       public BaseDoc AttatchDoc
       {
           get { return _attatchDoc; }
           set { _attatchDoc = value; }
       }

       /// <summary>
       /// 分页设定类
       /// </summary>
       private PagerSetting _pagerSetting = new PagerSetting();
       /// <summary>
       /// 从数据源中绑定数据到界面控件
       /// 设置界面元素的属性和事件
       /// </summary>
       /// <param name="control"></param>
       public virtual void Handle()
       {
           foreach (T element in _controls)
           {
               //如果当前无分页活动,直接调用BindDataToUI()方法,否则将在PageIndexChanged事件里调用BindDataToUI()
               try
               {
                   if (PagerSetting.AllowPage == false)
                   {
                       BindDataToUI(element, _dataSources);
                   }
                   ControlSetting(element);
               }
               catch (Exception e)
               {
                   throw;
               }
           }
       }
       /// <summary>
       /// 根据控件的类型,加载控件到UIElementHandler中去
       /// </summary>
       /// <param name="control"></param>
       public void AddControlByType(Control control)
       {
           if (!(control is T))
               return;

           T element = control as T;

           _controls.Add(element);
       }
       /// <summary>
       /// 将数据源数据绑定到界面控件元素
       /// </summary>
       /// <param name="element"></param>
       public virtual void BindDataToUI(T control, Dictionary<string, DataTable> dataSources)
       {
           
       }
       /// <summary>
       /// 将界面元素内容绑定到数据源
       /// </summary>
       /// <param name="control"></param>
       /// <param name="dataSources"></param>
       public virtual void BindUIToData(T control, Dictionary<string, DataTable> dataSources)
       {

       }
       /// <summary>
       /// 控件属性事件设置
       /// </summary>
       /// <param name="element"></param>
       public virtual void ControlSetting(T control)
       {
           
       }
       /// <summary>
       /// 刷新数据
       /// </summary>
       public virtual void  RefreshData()
       {
           foreach (T control in _controls)
           {
               BindDataToUI(control, _dataSources);
           }
       }
        /// <summary>
        ///结束当前编辑
        /// </summary>
       public void EndCurrentEdit()
       {
           foreach (T control in _controls)
           {
               BindUIToData(control, _dataSources);
           }
       }
        /// <summary>
        /// 设置所有控件是否可编辑
        /// </summary>
        /// <param name="canEdit"></param>
       public void SetAllControlEditable(bool canEdit)
       {
           foreach (T control in _controls)
           {
               if (control is MedVitalSignGraph)
               {
                    MedVitalSignGraph  graph =  control as MedVitalSignGraph;
                   graph.CanUpdate = canEdit;
               }
               else
               {
                   control.Enabled = canEdit;
                   
               }
               control.BackColor = Color.White;
           }
       }
       /// <summary>
       /// 验证数据
       /// </summary>
       /// <param name="controls"></param>
       /// <returns></returns>
       public virtual bool Validate()
       {
           bool isValid = true;
           foreach (T control in _controls)
           {
               if (control is ICheckable)
               {
                   ICheckable beValidate = control as ICheckable;

                   if (!beValidate.IsValid)
                   {
                       _errorProvider.SetError(control, beValidate.InputNeededMessage);
                       //isValid = false;
                       //control.Focus();
                       //IsValid目前只验证非空,，应该允许表单刷新和表单其余数据的保存
                   }
               }
           }
           return isValid;
       }
       /// <summary>
       /// 清除错误显示
       /// </summary>
       /// <param name="controls"></param>
       /// <returns></returns>
       public virtual void ClearError()
       {
           _errorProvider.Clear();
       }
       
       /// <summary>
       /// 是否有脏数据
       /// </summary>
       public bool HasDirty
       {
           get
           {
               return _hasDirty;
           }
           set
           {
               _hasDirty = value;
           }
       }
       /// <summary>
       /// 数据验证错误提示控件
       /// </summary>
       public ErrorProvider ErrorProvider
       {
          get
          {
              return _errorProvider;
          }
          set
          {
              _errorProvider = value;
          }
       }
       /// <summary>
       /// 数据源
       /// </summary>
       public Dictionary<string, DataTable> DataSource
       {
           get
           {
               return _dataSources;
           }
           set
           {
               _dataSources = value;
           }
       }
       /// <summary>
       /// 获取所处理控件的类型
       /// </summary>
       public Type GetControlType
       {
           get
           {
               return typeof(T);
           }
       }
       /// <summary>
       /// 返回当前的控件
       /// </summary>
       public List<T> GetCurrentControls
       {
           get
           {
               return _controls;
           }
       }
       public List<Control> GetAllControls
       {
           get
           {
               List<Control> controls = new List<Control>();
               foreach (T e in _controls)
               {
                   controls.Add(e);
               }
               return controls;
           }
       }

        /// <summary>
        ///设置控件是否可见
        /// </summary>
        /// <param name="isVisible"></param>
       public void SetControlVisible(bool isVisible)
       {
           foreach (T control in _controls)
           {
               control.Visible = isVisible;
           }
       }
       /// <summary>
       /// 设置控件的停靠位置和方式
       /// </summary>
       /// <param name="dock"></param>
       public void SetControlDockStyle(DockStyle dock)
       {
           foreach (T control in _controls)
           {
               control.Dock = dock;
           }
       }
       /// <summary>
       /// 获取当前的控件
       /// </summary>
       public Control GetCurrentControl
       {
           get
           {
               if (_controls.Count > 0)
                  return  _controls[0];
               return null;
           }
       }
       /// <summary>
       /// 获取或者设置此Handler类的名称
       /// </summary>
       public string Name
       {
           get
           {
               return _name;
           }
           set
           {
               _name = value;
           }
       }
       /// <summary>
       ///获取或者设置当前文书包含的其它UIElementHandler集合
       /// </summary>
       public List<IUIElementHandler> MedicalPaperUIElementHandlers
       {
           get
           {
               return _medicalPaperUIElementHandlers;
           }
           set
           {
               _medicalPaperUIElementHandlers = value;
           }
       }
       /// <summary>
       /// 分页设置
       /// </summary>
       public PagerSetting PagerSetting
       {
           get
           {
               return _pagerSetting;
           }
           set
           {
               _pagerSetting = value;
           }
       }
       #region Common API


        /// <summary>
        /// 自动调整时间
        /// </summary>
        /// <param name="timeScaleType"></param>
        /// <param name="dateTimeRange"></param>
       protected void AdjustDateTimeRange(TimeScaleType timeScaleType, ref DateTimeRange dateTimeRange)
       {
           if (timeScaleType != TimeScaleType.None)
           {
               switch (timeScaleType)
               {
                   case TimeScaleType.FiveMinute:
                       ModMinute(ref dateTimeRange.StartDateTime, 5);
                       break;
                   case TimeScaleType.Quarter:
                       ModMinute(ref dateTimeRange.StartDateTime, 15);
                       break;
                   case TimeScaleType.HaveHour:
                       ModMinute(ref dateTimeRange.StartDateTime, 30);
                       break;
               }
           }
       }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="modNumber"></param>
       private void ModMinute(ref DateTime dateTime, int modNumber)
       {
           dateTime = dateTime.AddMinutes(-dateTime.Minute % modNumber);
       }
       /// <summary>
       /// 返回实际值在字典中对应的显示值
       /// </summary>
       /// <param name="dictTableName"></param>
       /// <param name="dictValueFieldName"></param>
       /// <param name="displayFieldName"></param>
       /// <param name="dictWhereString"></param>
       /// <param name="value"></param>
       /// <returns></returns>
       public string TransDictCode(string dictTableName, string dictValueFieldName, string displayFieldName, string dictWhereString, object value)
       {
           if (value != null)
           {
               DataTable dataTable = ExtendAppContext.Current.CodeTables[dictTableName.ToUpper()];
               if (dataTable != null && dataTable.Columns.Contains(dictValueFieldName))
               {
                   DataRow[] rows = BuildPopupItemsData(dictTableName, dictWhereString);
                   foreach (DataRow row in rows)
                   {
                       if (row[dictValueFieldName] != System.DBNull.Value && row[dictValueFieldName].ToString().Equals(value.ToString()))
                       {
                           if (dataTable.Columns.Contains(displayFieldName))
                           {
                               return row[displayFieldName].ToString();
                           }
                       }
                   }
               }
               return value.ToString();
           }
           return "";
       }
       /// <summary>
       /// 将时间转换成格式化后的字符串
       /// </summary>
       /// <param name="dateTime"></param>
       /// <param name="format"></param>
       /// <returns></returns>
       protected string FormatDateTime(DateTime dateTime, string format)
       {
           if (IsDateTimeFomrat(format))
           {
               string replaceString = "-";
               return dateTime.ToString(TransDateFormat(format, replaceString)).Replace("-", replaceString);
           }
           else if (format.ToLower().Trim().Equals("datetoage"))
           {
               //DateTime now = DateTime.Today;
               //AnesInformations.OperationMasterDataTable masterTable = (new AnesthesiaSheetDA()).GetOperationMaster(ExtendApplicationContext.Current.PatientContext.PatientID,
               //   ExtendAppContext.Current.PatientContext.VisitID,ExtendAppContext.Current.PatientContext.OperID);
               //if (masterTable != null && masterTable.Count == 1)
               //{
               //    now = masterTable[0].SCHEDULED_DATE_TIME;
               //}
               ////DateTime now = (new CommonDA()).GetSysDateTime();
               //int year = now.Year - dateTime.Year;
               //if (year > 0 && dateTime.AddYears(year) > now)
               //{
               //    year--;
               //}
               //if (year >= 1)
               //{
               //    return year.ToString() + "岁";
               //}
               //else
               //{
               //    int month = year * 12 + now.Month - dateTime.Month;
               //    if (month < 0)
               //    {
               //        month += 12;
               //    }
               //    if (month >= 1)
               //    {
               //        return month.ToString() + "个月";
               //    }
               //    else
               //    {
               //        TimeSpan ts = (TimeSpan)(now - dateTime);
               //        int days = (int)Math.Round((ts.TotalDays));
               //        if ((int)Math.Round((ts.TotalDays)) < 0)
               //        {
               //            days = 0;
               //        }
               //        days += 1;
               //        return (days.ToString() + "天");
               //    }
               //}

           }
           return dateTime.ToString();
       }


       /// <summary>
       /// 根据条件生成下拉框数据源,并缓存数据
       /// </summary>
       /// <param name="codeTableName"></param>
       /// <param name="whereCondition"></param>
       /// <returns></returns>
       protected DataRow[] BuildPopupItemsData(string codeTableName, string whereCondition)
       {
           if (string.IsNullOrEmpty(whereCondition))
               whereCondition = "";
           string key = string.Format("{0}:{1}", codeTableName.ToUpper(), whereCondition.ToUpper());
           if (_popupItemsData.ContainsKey(key))
               return _popupItemsData[key];
           else
           {
               if (!ExtendAppContext.Current.CodeTables.ContainsKey(codeTableName.ToUpper()))
                   throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", codeTableName.ToUpper()));

               DataTable codeTable = ExtendAppContext.Current.CodeTables[codeTableName.ToUpper()];
               DataRow[] rows = GetTableRows(codeTable, whereCondition);

               _popupItemsData.Add(key, rows);

               return rows;

           }

       }

       /// <summary>
       /// 是否日期格式
       /// </summary>
       /// <param name="format"></param>
       /// <returns></returns>
       protected bool IsDateTimeFomrat(string format)
       {
           if (!string.IsNullOrEmpty(format))
           {
               string replaceString = "-";
               string formatString = TransDateFormat(format, replaceString);
               if (formatString.Equals("yyyy-MM-dd") || formatString.Equals("yyyy-MM-dd HH:mm") || formatString.Equals("HH:mm") || formatString.Equals("yyyy年MM月dd日"))
               {
                   return true;
               }
           }
           return false;
       }
       /// <summary>
       /// 转换日期格式
       /// </summary>
       /// <param name="format"></param>
       /// <param name="replaceString"></param>
       /// <returns></returns>
       protected string TransDateFormat(string format, string replaceString)
       {
           string formatString = format;
           if (!string.IsNullOrEmpty(formatString))
           {
               formatString = formatString.ToLower().Trim();
               if (formatString.IndexOf(".") > 0)
               {
                   replaceString = ".";
               }
               else if (formatString.IndexOf("/") > 0)
               {
                   replaceString = "/";
               }
               formatString = formatString.Replace(replaceString, "-").Replace("yyyy-mm", "yyyy-MM").Replace("yyyy年mm", "yyyy年MM").Replace("hh:", "HH:");
           }
           return formatString;
       }
       /// <summary>
       /// 取得数据行
       /// </summary>
       /// <param name="dataTable"></param>
       /// <param name="whereString"></param>
       /// <returns></returns>
       protected DataRow[] GetTableRows(DataTable dataTable, string whereString)
       {
           DataRow[] rows;
           try
           {
               rows = dataTable.Select(TransWhereString(whereString));
           }
           catch
           {
               rows = dataTable.Select();
           }
           if (dataTable.Columns.Contains("SERIAL_NO"))
           {
               List<DataRow> list = new List<DataRow>(rows);
               list.Sort(new Comparison<DataRow>(delegate(DataRow row1, DataRow row2)
               {
                   if (row1["SERIAL_NO"] == System.DBNull.Value || row2["SERIAL_NO"] == System.DBNull.Value)
                   {
                       return 0;
                   }
                   else
                   {
                       return decimal.Parse(row1["SERIAL_NO"].ToString()).CompareTo(decimal.Parse(row2["SERIAL_NO"].ToString()));
                   }
               }));
               rows = list.ToArray();
           }
           return rows;
       }
       /// <summary>
       /// 翻译查询条件，支持变量
       /// </summary>
       /// <param name="whereString"></param>
       /// <returns></returns>
       protected string TransWhereString(string whereString)
       {
           if (whereString.ToLower().Contains("%config_deptcode%"))
               whereString = whereString.Replace("%config_deptcode%", "'" + ExtendAppContext.Current.DeptCode + "'");
           //if (whereString.ToLower().Contains("%config_AnesthesiaWardCode%".ToLower()))
           //    whereString = whereString.Replace("%config_AnesthesiaWardCode%", "'" + ApplicationConfiguration.AnesthesiaWardCode + "'");
           //if (whereString.ToLower().Contains("%config_OpertionDeptCode%".ToLower()))
           //    whereString = whereString.Replace("%config_OpertionDeptCode%", "'" + ApplicationConfiguration.OpertionDeptCode + "'");


           return whereString;

       }
       protected  bool IsFunctionFormat(string format)
       {
           if (!string.IsNullOrEmpty(format))
           {
               if (format.ToLower().Trim().Equals("datetoage"))
               {
                   return true;
               }
           }
           return false;
       }
       protected object GetFieldValue(string tableName, string fieldName)
       {
           object value = null;
           DataTable data = _dataSources[tableName.ToUpper()];
           if (tableName.ToUpper().Equals("MED_OPERATION_EXTENDED") || tableName.ToUpper().Equals("MED_POSTOPERATIVE_EXTENDED") || tableName.ToUpper().Equals("MED_PREOPERATIVE_EXPANSION"))
           {
               value = "";
               foreach (DataRow row in data.Rows)
               {
                   if (row["ITEM_NAME"] != System.DBNull.Value)
                   {
                       if (row["ITEM_NAME"].ToString().ToLower().Trim().Equals(fieldName.Trim().ToLower()))
                       {
                           if (row["ITEM_VALUE"] != System.DBNull.Value)
                           {
                               value = row["ITEM_VALUE"].ToString();
                           }
                           break;
                       }
                   }
               }
           }
           else if (tableName.ToUpper().Equals("MED_OPER_ANALGESIC_TOTAL"))
           {
               value = "";
               string name = fieldName.Trim().ToLower();
               if (name.Contains("_备注"))
                   name = name.Replace("_备注", "");
               foreach (DataRow row in data.Rows)
               {
                   if (row["TOTAL_NAME"] != System.DBNull.Value)
                   {
                       if (row["TOTAL_NAME"].ToString().ToLower().Trim().Equals(name))
                       {
                           if (fieldName.Trim().ToLower().Contains("_备注"))
                           {
                               if (row["TOTAL_MEMO"] != System.DBNull.Value)
                               {
                                   value = row["TOTAL_MEMO"].ToString();
                               }
                           }
                           else
                           {
                               if (row["TOTAL_VALUE"] != System.DBNull.Value)
                               {
                                   value = row["TOTAL_VALUE"].ToString();
                               }
                           } 
                           break;
                       }
                   }
               }
           }
           else if (tableName.ToUpper().Equals("MED_OPER_ANALGESIC_MEDICINE"))
           {
               value = "";
               string name = fieldName.Trim().ToLower();
               if (name.Contains("_单位"))
                   name = name.Replace("_单位", "");
               foreach (DataRow row in data.Rows)
               {
                   if (row["MEDICINE_NAME"] != System.DBNull.Value)
                   {
                       if (row["MEDICINE_NAME"].ToString().ToLower().Trim().Equals(name))
                       {
                           if (fieldName.Trim().ToLower().Contains("_单位"))
                           {
                               if (row["MEDICINE_DOSAGE_UNITS"] != System.DBNull.Value)
                               {
                                   value = row["MEDICINE_DOSAGE_UNITS"].ToString();
                               }
                           }
                           else
                           {
                               if (row["MEDICINE_DOSAGE"] != System.DBNull.Value)
                               {
                                   value = row["MEDICINE_DOSAGE"].ToString();
                               }
                           }
                           break;
                       }
                   }
               }
           }
           else
           {
               value = _dataSources[tableName.ToUpper()].Rows[0][fieldName];
           }
           
           return value;
       }
       protected void SetFieldValue(string tableName, string fieldName, object value)
       {
           DataTable data = _dataSources[tableName.ToUpper()];
           bool find = false;
           if (tableName.ToUpper().Equals("MED_OPERATION_EXTENDED") || tableName.ToUpper().Equals("MED_POSTOPERATIVE_EXTENDED") || tableName.ToUpper().Equals("MED_PREOPERATIVE_EXPANSION"))
           { 
               foreach (DataRow row in data.Rows)
               {
                   if (row["ITEM_NAME"] != System.DBNull.Value)
                   {
                       if (row["ITEM_NAME"].ToString().ToLower().Trim().Equals(fieldName.Trim().ToLower()))
                       {
                           row["ITEM_VALUE"] = value;
                           find = true;
                           break;
                       }
                   }
               }
               if (!find && !string.IsNullOrEmpty(fieldName))
               {
                   DataRow row = data.NewRow();
                   row["PATIENT_ID"] = ExtendAppContext.Current.PatientID;
                   row["VISIT_ID"] = ExtendAppContext.Current.VisitID;
                   row["OPER_ID"] = ExtendAppContext.Current.OperID;
                   row["ITEM_NAME"] = fieldName;
                   row["ITEM_VALUE"] = value;
                   data.Rows.Add(row);
               }
           }
           else if (tableName.ToUpper().Equals("MED_OPER_ANALGESIC_TOTAL"))
           {
               string name = fieldName.Trim().ToLower();
               foreach (DataRow row in data.Rows)
               {
                   if (row["TOTAL_NAME"] != System.DBNull.Value)
                   {
                       if (name.Contains("_备注"))
                       {
                           name = name.Replace("_备注", "");
                           if (row["TOTAL_NAME"].ToString().ToLower().Trim().Equals(fieldName.Trim().ToLower()))
                           {
                               row["TOTAL_MEMO"] = value;
                               find = true;
                               break;
                           }
                       }
                       else
                       {
                           if (row["TOTAL_NAME"].ToString().ToLower().Trim().Equals(fieldName.Trim().ToLower()))
                           {
                               row["TOTAL_VALUE"] = value;
                               find = true;
                               break;
                           }
                       }

                   }
               }
               if (!find && !string.IsNullOrEmpty(name))
               {
                   DataRow row = data.NewRow();
                   row["PATIENT_ID"] = ExtendAppContext.Current.PatientID;
                   row["VISIT_ID"] = ExtendAppContext.Current.VisitID;
                   row["OPER_ID"] = ExtendAppContext.Current.OperID;
                   row["TOTAL_NAME"] = fieldName;
                   if (name.Contains("_备注"))
                   { 
                       row["TOTAL_MEMO"] = value;
                   }
                   else 
                   {
                       row["TOTAL_VALUE"] = value;
                   } 
                   data.Rows.Add(row);
               }
           }
           else if (tableName.ToUpper().Equals("MED_OPER_ANALGESIC_MEDICINE"))
           {
               string name = fieldName.Trim().ToLower();
               foreach (DataRow row in data.Rows)
               {
                   if (row["MEDICINE_NAME"] != System.DBNull.Value)
                   {
                       if (name.Contains("_单位"))
                       {
                           name = name.Replace("_单位", "");
                           if (row["MEDICINE_NAME"].ToString().ToLower().Trim().Equals(fieldName.Trim().ToLower()))
                           {
                               row["MEDICINE_DOSAGE_UNITS"] = value;
                               find = true;
                               break;
                           }
                       }
                       else
                       {
                           if (row["MEDICINE_NAME"].ToString().ToLower().Trim().Equals(fieldName.Trim().ToLower()))
                           {
                               row["MEDICINE_DOSAGE"] = value;
                               find = true;
                               break;
                           }
                       }

                   }
               }
               if (!find && !string.IsNullOrEmpty(name))
               {
                   DataRow row = data.NewRow();
                   row["PATIENT_ID"] = ExtendAppContext.Current.PatientID;
                   row["VISIT_ID"] = ExtendAppContext.Current.VisitID;
                   row["OPER_ID"] = ExtendAppContext.Current.OperID;
                   row["MEDICINE_NAME"] = fieldName;
                   if (name.Contains("_单位"))
                   {
                       row["MEDICINE_DOSAGE_UNITS"] = value;
                   }
                   else
                   {
                       row["MEDICINE_DOSAGE"] = value;
                   }
                   data.Rows.Add(row);
               }
           }
           else
           {
               if (value == null || value == DBNull.Value || value.ToString().Trim() == string.Empty)
                   value = DBNull.Value;

               data.Rows[0][fieldName] = value;
           }
       }
       protected double GetDoubleValue(object rowValue)
       {
           if (rowValue != System.DBNull.Value && rowValue is decimal && rowValue != null)
           {
               return (double)(decimal)rowValue;
           }
           else
           {
               return 0;
           }
       }

       protected int GetDecimalValue(object rowValue)
       {
           if (rowValue != System.DBNull.Value && (rowValue is int) && rowValue != null)
           {
               return (int)rowValue;
           }
           else
           {
               return 0;
           }
       }

       protected string GetStringValue(object rowValue)
       {
           if (rowValue != System.DBNull.Value && rowValue!=null)
           {
               return rowValue.ToString();
           }
           else
           {
               return "";
           }
       }
       /// <summary>
       /// 取得系统时间
       /// </summary>
       /// <returns></returns>
       protected  DateTime GetSysDateTime()
       {
           return  AccountService.GetServerTime();
       }

       /// <summary>
       /// 麻醉操作类型对应保存在数据库中的字符
       /// </summary>
       /// <param name="anesClassType">麻醉操作类型</param>
       /// <returns>麻醉操作类型对应保存在数据库中的字符</returns>
       public string GetAnesClassTypeString(AnesClassType anesClassType)
       {
           string anesClassTypeStrings = "0123456789ABCXYOZ~D";
           int anesClassTypeIndex = (int)anesClassType;
           if (anesClassTypeIndex < anesClassTypeStrings.Length)
           {
               return anesClassTypeStrings.Substring(anesClassTypeIndex, 1);
           }
           else
           {
               return "";
           }
       }
       /// <summary>
       /// 获取一个随机的颜色
       /// </summary>
       /// <returns></returns>
       protected  Color GetRandomColor()
       {
           //System.Threading.Thread.Sleep(1);
           Random rand = new Random();
           int r = rand.Next(255);
           int g = rand.Next(255);
           int b = rand.Next(255);
           return Color.FromArgb(r, g, b);
       }
       /// <summary>
       /// 是否是时间事件
       /// </summary>
       /// <param name="eventName"></param>
       /// <returns></returns>
       protected  bool IsTimeEvent(string eventName)
       {
           bool result = false;
           if (!string.IsNullOrEmpty(eventName))
           {
               string ev = eventName.Trim();
               result = ev.Equals(EventNames.ANESSTART) || ev.Equals(EventNames.ANESEND)
                   || ev.Equals(EventNames.OPERATIONSTART) || ev.Equals(EventNames.OPERATIONEND);
           }
           return result;
       }
       /// <summary>
       /// 获取用户曲线设置
       /// </summary>
       /// <returns></returns>
       protected  List<MedVitalSignCurveDetail> GetUserVitalShowSet(string eventNo)
       {
           List<MedVitalSignCurveDetail> list = new List<MedVitalSignCurveDetail>();
           MED_PATIENT_MONITOR_CONFIG configTable = GetPatientMonitorConfigDataTable(eventNo);
           if (configTable != null && !string.IsNullOrEmpty(configTable.CONTENT.ToString()))
           {
               System.IO.MemoryStream stream = new System.IO.MemoryStream(configTable.CONTENT);
               stream.Position = 0;
               DataSet ds = new DataSet();
               ds.ReadXml(stream);
               if (ds.Tables.Count > 0)
               {
                   string tableName = "UserVitalShowSet" + ((Convert.ToInt32(eventNo) < 0) ? "0" : eventNo);
                   DataTable dataTable = ds.Tables[tableName];
                   ListFromTable(list, typeof(MedVitalSignCurveDetail), dataTable);
               }
               ds.Dispose();
               stream.Close();
               stream.Dispose();
           }
           return list;
       }
       protected  void ListFromTable(IList list, Type type, DataTable dataTable)
       {
           if (dataTable != null)
           {
               List<MemberDetail> memberDetails = AssemblyHelper.GetPropertyList(type);
               foreach (DataRow row in dataTable.Rows)
               {
                   object obj = Activator.CreateInstance(type);
                   foreach (MemberDetail memberDetail in memberDetails)
                   {
                       PropertyInfo propertyInfo = memberDetail.PropertyInfo;
                       if (dataTable.Columns.Contains(memberDetail.Name) && row[memberDetail.Name] != System.DBNull.Value)
                       {
                           try
                           {
                               AssemblyHelper.SetPropertyValue(propertyInfo, obj, row[memberDetail.Name].ToString());
                           }
                           catch (Exception ex)
                           {
                               XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }
                       }
                   }
                   list.Add(obj);
               }
           }
       }
       /// <summary>
       /// 获取当前患者监测配置数据
       /// </summary>
       /// <param name="patientID"></param>
       /// <param name="visitID"></param>
       /// <param name="operID"></param>
       /// <returns></returns>
       private MED_PATIENT_MONITOR_CONFIG GetPatientMonitorConfigDataTable(string eventNo)
       {
           MED_PATIENT_MONITOR_CONFIG patMonitorConfig = OperationInfoService.GetMonitorConfig(ExtendAppContext.Current.PatientID, ExtendAppContext.Current.VisitID,
               ExtendAppContext.Current.OperID, eventNo);
           if (patMonitorConfig == null)
           {
               patMonitorConfig = OperationInfoService.GetMonitorConfig("999", 0, 0, eventNo);
           }
           return patMonitorConfig;
       }
       #endregion
       protected List<MedSheetDetail> GetUserMedSheetShowSet(string eventNo)
       {
           List<MedSheetDetail> list = new List<MedSheetDetail>();
           //Configuration.PatientMonitorConfigDataTable configTable = GetPatientJianCeConfigDataTable();
           //if (configTable.Count > 0 && !configTable[0].IsCONTENTNull())
           //{
           //    System.IO.MemoryStream stream = new System.IO.MemoryStream(configTable[0].CONTENT);
           //    stream.Position = 0;
           //    DataSet ds = new DataSet();
           //    ds.ReadXml(stream);
           //    if (ds.Tables.Count > 0)
           //    {
           //        string tableName = "UserMedSheetShowSet" + ((eventNo < 0) ? 0 : eventNo).ToString();
           //        DataTable dataTable = ds.Tables[tableName];
           //        ListFromTable(list, typeof(MedSheetDetail), dataTable);
           //    }
           //    ds.Dispose();
           //    stream.Close();
           //    stream.Dispose();
           //}
           return list;
       }

       /// <summary>
       /// 获取当前患者监测项配置数据
       /// </summary>
       /// <param name="patientID"></param>
       /// <param name="visitID"></param>
       /// <param name="operID"></param>
       /// <returns></returns>
       //private Configuration.PatientMonitorConfigDataTable GetPatientJianCeConfigDataTable()
       //{
       //    ConfigurationDA configurationDA = new ConfigurationDA();
       //    Configuration.PatientMonitorConfigDataTable cfg = configurationDA.GetPatientJianCeConfigDataTable(
       //       ExtendAppContext.Current.PatientContext.PatientID,
       //       ExtendAppContext.Current.PatientContext.VisitID,
       //       ExtendAppContext.Current.PatientContext.OperID
       //        );
       //    if (cfg == null || cfg.Count == 0)
       //    {
       //        cfg = configurationDA.GetPatientJianCeConfigDataTable("999", 0, 0);
       //    }
       //    return cfg;
       //}
    }
}
