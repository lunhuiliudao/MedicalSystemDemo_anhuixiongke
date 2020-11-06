/*----------------------------------------------------------------
 // Copyright (C) 2007 麦迪斯顿(北京)医疗科技发展有限公司
 // 文件名：BaseControl.cs
 // 文件功能描述：
 //     基础控件--其他控件建立在此基础上
 // 
 // 创建标识：
 //     戴呈祥-2007-12-17
 // 修改标识：
 *  于占涛 2008-05-30
 *  增加解决微软自动转换输入法为全角bug     
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Com.MedicalSystem.Icu.DataSetModel;
using Com.MedicalSystem.Common.Controls;
using Com.MedicalSystem.Icu.Configurations;
using Com.MedicalSystem.Common.Utilities;

namespace MedicalSystem.AnesWorkStation.Score
{
    /// <summary>
    /// 基础控件
    /// </summary>
    public partial class BaseControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region 常量

        /// <summary>
        /// 主窗体
        /// </summary>
        public const string MAINFORM = "MainForm";

        /// <summary>
        /// 全体
        /// </summary>
        public const string ALL = "ALL";

        #endregion 常量

        #region 事件

        /// <summary>
        /// 通知事件
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">事件参数</param>
        /// <param name="notifyNames">通知名单-ALL表示全体MAINFORM表示主窗体</param>
        public delegate void NotifyEventHandle(object sender, EventArgs e, List<string> notifyLists);

        /// <summary>
        /// 通知发出事件
        /// </summary>
        private static readonly object _notifySender = new object();
        [Description("通知发出事件")]
        public event NotifyEventHandle NotifySender
        {
            add
            {
                Events.AddHandler(_notifySender, value);
            }
            remove
            {
                Events.RemoveHandler(_notifySender, value);
            }
        }

        #endregion 事件

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseControl()
        {
        }

        //public static Patient.PatientRow GetPatientRow(string patientID, decimal visitID, decimal deptID)
        //{
        //    Patient.PatientDataTable table = new Patient.PatientDataTable();
        //    Patient.PatientRow row = table.NewPatientRow();
        //    row.PATIENT_ID = patientID;
        //    row.VISIT_ID = visitID;
        //    row.DEP_ID = deptID;
        //    return row;
        //}
        protected string _patientID;
        protected decimal _visitID, _deptID;

        public BaseControl(string patientID, decimal visitID, decimal deptID, string title)
        {
            _patientID = patientID;
            _visitID = visitID;
            _deptID = deptID;
            _title = title;
            InitializeComponent();
            //if (patientRow != null)
            //    _currentPatientId = patientRow.PATIENT_ID;
        }

        //public BaseControl(Patient.PatientRow patientRow, string title,string showCode)
        //{
        //    _patientRow = patientRow;
        //    _title = title;
        //    _showCode = showCode;
        //    InitializeComponent();
        //    if (patientRow != null)
        //        _currentPatientId = patientRow.PATIENT_ID;
        //}

        #endregion

        #region 变量


        /// <summary>
        /// 病人信息
        /// </summary>
        //protected Patient.PatientRow _patientRow;

        /// <summary>
        /// 主表-改变会导致退出时保存；
        /// </summary>
        protected DataTable _mainTable;

        /// <summary>
        /// 需要控制的表集合-任何一个表的改变都会导致退出时保存；
        /// </summary>
        protected DataTable[] _dataTables;

        /// <summary>
        /// 标题
        /// </summary>
        protected string _title = "无标题";

        /// <summary>
        /// 表示
        /// </summary>
        protected string _showCode = "ZTHLJM";

        /// <summary>
        /// 指示数据是否已经改变，用于用户强制控制数据是否改变，默认为false，如果为true则退出时强制保存；
        /// </summary>
        private bool _dataChanged = false;

        /// <summary>
        /// 权限标志，为真拥有权限，为假没有权限
        /// </summary>
        private bool _permissionsSign = true;

        /// <summary>
        /// 科室代码
        /// </summary>
        protected string _wardCode = "";

        #endregion 变量

        #region 属性

        /// <summary>
        /// 控件标题
        /// </summary>
        [Description("控件标题")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        ///// <summary>
        ///// 病人信息
        ///// </summary>
        //public Patient.PatientRow PatientRow
        //{
        //    get
        //    {
        //        return _patientRow;
        //    }
        //    set
        //    {
        //        _patientRow = value;

        //    }
        //}

        /// <summary>
        /// 指示数据是否已经改变，用于用户强制控制数据是否改变，默认为false，如果为true则退出时强制保存；
        /// </summary>
        public bool DataChanged
        {
            get
            {
                return _dataChanged;
            }
            set
            {
                _dataChanged = value;
            }
        }
        /// <summary>
        /// 权限标志，为真拥有权限，为假没有权限
        /// </summary>
        /// 

        public bool PermissionsSign
        {
            get
            {
                return _permissionsSign;
            }
        }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string WardCode
        {
            get
            {
                return _wardCode;
            }
            set
            {
                _wardCode = value;
            }
        }
        #endregion 属性

        #region 方法

        private void CheckPermissions()
        {
            Type Type1 = this.GetType();
            _permissionsSign = MedConfiguration.CheckPermission(Type1.FullName);
            this.ControlAdded += new ControlEventHandler(BaseControl_ControlAdded);
        }
        public void BaseControl_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is DataGridView)
            {
                (e.Control as DataGridView).ReadOnly = !_permissionsSign;
                (e.Control as DataGridView).AllowDrop = _permissionsSign;
            }
        }
        /// <summary>
        /// 选择性的刷新数据，在主面版容器中导航时，如果需要刷新选中项，则重载此方法，
        /// </summary>
        public virtual void RefreshDataOptional() { }
        /// <summary>
        /// 检查更改并保存
        /// </summary>
        public void CheckChangedAndSave()
        {
            bool needSave = _dataChanged;

            if (!needSave)
            {
                if (_dataTables != null)
                {
                    foreach (DataTable dataTable in _dataTables)
                    {
                        using (DataTable dt = dataTable.GetChanges())
                        {
                            if ((dt != null) && (dt.Rows.Count > 0))
                            {
                                needSave = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (!needSave)
            {
                if (_mainTable != null)
                {
                    using (DataTable dt = _mainTable.GetChanges())
                    {
                        if ((dt != null) && (dt.Rows.Count > 0))
                        {
                            needSave = true;
                        }
                    }
                }
            }

            if (needSave)
            {
                if (Dialog.MessageBox("数据已改变，是否保存？", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
                else
                {
                    try
                    {
                        _mainTable.AcceptChanges();
                    }
                    catch
                    {
                        try
                        {
                            _mainTable.RejectChanges();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 选择不同病人时激活此方法
        /// </summary>
        /// <param name="patientInfo"></param>
        protected virtual void OnPatientChange(Patient.PatientRow patientRow)
        {
            RefreshAll();
        }

        public string CurrentPateinetID
        {
            get
            {
                return _currentPatientId;
            }
            set { _currentPatientId = value; }
        }
        private string _currentPatientId;
        /// <summary>
        /// 解决微软自动更新输入法为全角BUG
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            IntPtr HIme = WinAPI.ImmGetContext(this.Handle);
            if (WinAPI.ImmGetOpenStatus(HIme))  //如果输入法处于打开状态
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = WinAPI.ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //检索输入法信息
                if (bSuccess)
                {
                    if ((iMode & WinAPI.IME_CMODE_FULLSHAPE) > 0)   //如果是全角
                        WinAPI.ImmSimulateHotKey(this.Handle, WinAPI.IME_CHOTKEY_SHAPE_TOGGLE);  //转换成半角
                }

            }
        }

        /// <summary>
        /// 保存主表更改
        /// </summary>
        /// <param name="dataTable">主表</param>
        protected virtual void Save() { }

        /// <summary>
        /// 刷新所有数据
        /// </summary>
        protected virtual void RefreshAll() { }

        public void PopulateNewPatient()
        {
            RefreshAll();
        }
        /// <summary>
        /// 删除选择行
        /// </summary>
        /// <param name="grid">主表显示视图</param>
        protected virtual void DeleteSelectRows(MedDataGridView grid)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                try
                {
                    grid.Rows.Remove(row);
                }
                catch { }
            }
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        protected DataGridViewColumn GenerateCheckBoxColumn(string title, string fieldName, int width)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        protected DataGridViewColumn GenerateColumn(string title, string fieldName, int width)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        protected DataGridViewColumn GenerateColumn(string title, string fieldName, int width, bool read)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            column.ReadOnly = read;
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        protected DataGridViewColumn GenerateColumn(string title, string fieldName, int width, bool read, bool visible)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Name = fieldName;
            column.Width = width;
            column.ReadOnly = read;
            column.Visible = visible;
            return column;
        }
        /// <summary>
        /// 生成动态列
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fieldName"></param>
        /// <param name="width"></param>
        /// <param name="listItems"></param>
        /// <returns></returns>
        protected DataGridViewColumn GenerateColumn(string title, string fieldName, int width, string[] listItems)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            foreach (string itemValue in listItems)
            {
                column.Items.Add(itemValue);
            }
            column.HeaderText = title;
            column.DataPropertyName = fieldName;
            column.Width = width;
            column.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            return column;
        }
        /// <summary>
        /// 转数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns>结果</returns>
        protected object praseDouble(DataRow dataRow, string columnName)
        {
            object result = dataRow[columnName];
            if ((result != null) && (result.ToString() != ""))
            {
                result = double.Parse(result.ToString());
            }
            return result;
        }
        /// <summary>
        /// 转字符串
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns>结果</returns>
        public virtual object praseString(DataRow dataRow, string columnName)
        {
            object result = dataRow[columnName];
            if (result != null)
            {
                result = result.ToString();
                if (((string)result).StartsWith(PrintCell.LINESPLITCHAR))
                {
                    result = ((string)result).Substring(1);
                }
            }
            return result;
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="birthdayDate">出生日期</param>
        /// <returns>结果</returns>
        protected int calcAge(DateTime birthdayDate)
        {
            DateTime curDate = DateTime.Now;
            return curDate.Year - birthdayDate.Year - (((curDate.Month < birthdayDate.Month) || ((curDate.Month == birthdayDate.Month) && (curDate.Day < birthdayDate.Day))) ? 1 : 0);
        }

        /// <summary>
        /// 计算年龄(南平92医院)
        /// </summary>
        /// <param name="birthdayDate">出生日期</param>
        /// <returns>结果</returns>
        protected string calcAgeNanPing92(DateTime birthdayDate)
        {
            try
            {
                //2010-08-23
                //≤28天（或1月以内） 按天 
                //1岁以内 按几月几天 
                //12周岁以内 按几岁几月（月份按四舍五入）
                DateTime curDate = DateTime.Now;
                int nYear = curDate.Year - birthdayDate.Year;
                int nMonth = curDate.Month - birthdayDate.Month;
                int nDay = curDate.Day - birthdayDate.Day;

                int nDaysAMonth = 0;
                int nMonthJudge = 0;
                int nYearJudge = 0;
                if (nDay < 0)
                {
                    nYearJudge = curDate.Year;
                    nMonthJudge = curDate.Month - 1;
                    if (nMonthJudge == 0)
                    {
                        nMonthJudge = 12;
                        nYearJudge -= 1;
                    }
                }
                else
                {
                    nYearJudge = curDate.Year;
                    nMonthJudge = curDate.Month;
                }

                switch (nMonthJudge)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        nDaysAMonth = 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        nDaysAMonth = 30;
                        break;
                    default:
                        nDaysAMonth = ((nYearJudge % 4 == 0) ? 29 : 28);
                        break;
                }

                if (nDay < 0)
                {
                    nMonth -= 1;
                    nDay += nDaysAMonth;
                }
                if (nMonth < 0)
                {
                    nYear -= 1;
                    nMonth += 12;
                }

                //年龄计算是负的话，返回""
                if (nYear < 0 || nMonth < 0 || nDay < 0)
                {
                    return "";
                }

                //≤28天（或1月以内） 按天 
                if (nYear == 0 && nMonth == 0)
                {
                    return nDay + "天";
                }
                //1岁以内 按几月几天
                else if (nYear == 0)
                {
                    string sReturn = "";
                    sReturn += nMonth + "月";
                    if (nDay > 0)
                    {
                        sReturn += nDay + "天";
                    }
                    return sReturn;
                }
                //12周岁以内 按几岁几月（月份按四舍五入）
                else if (nYear < 12)
                {
                    string sReturn = "";
                    sReturn += nYear + "岁";

                    //四舍五入计算用
                    if ((double)nDay / nDaysAMonth >= 0.5)
                    {
                        nMonth += 1;
                    }

                    if (nMonth > 0)
                    {
                        sReturn += nMonth + "月";
                    }
                    return sReturn;

                }
                else
                {
                    return nYear + "岁";
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="birthdayDate"></param>
        /// <returns>*岁*个月</returns>
        protected string calculateAge(DateTime birthdayDate, DateTime today)
        {
            double a = (DateTime.Now - birthdayDate).TotalDays;
            double aYear = Math.Floor(a / 365);
            double C = a % 365;
            double aMonth = Math.Floor(C / 30);
            double aDay = Math.Floor(C % 30);
            if (aYear < 1)
            {
                return aMonth.ToString() + "个月";//+ aDay.ToString() + "天";   
            }
            else
            {
                return aYear.ToString() + "岁  ";// + aMonth.ToString() + "个月   " + aDay.ToString() + "天";
            }
        }


        /// <summary>
        /// 通知-通知改变以便相关者获得响应同步更新
        /// </summary>
        /// <param name="notifyLists">通知名单-ALL表示全体MAINFORM表示主窗体</param>
        protected void Notify(List<string> notifyLists)
        {
            NotifyEventHandle notify = (NotifyEventHandle)Events[_notifySender];
            if (notify != null)
            {
                notify(this, new EventArgs(), notifyLists);
            }
        }

        /// <summary>
        /// 通知-通知改变以便相关者获得响应同步更新
        /// </summary>
        /// <param name="notifyLists">通知名单-ALL表示全体MAINFORM表示主窗体</param>
        protected void Notify(string[] notifyLists)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < notifyLists.Length; i++)
            {
                list.Add(notifyLists[i]);
            }
            Notify(list);
        }

        /// <summary>
        /// 通知-通知改变以便相关者获得响应同步更新
        /// </summary>
        /// <param name="singleControl">单个接收通知的控件名称</param>
        protected void Notify(string singleControl)
        {
            List<string> list = new List<string>();
            list.Add(singleControl);
            Notify(list);
        }

        /// <summary>
        /// 通知-通知全体改变以便相关者获得响应同步更新
        /// </summary>
        protected void NotifyAll()
        {
            List<string> list = new List<string>();
            list.Add(ALL);
            Notify(list);
        }

        /// <summary>
        /// 通知-通知主窗体改变以便相关者获得响应同步更新
        /// </summary>
        protected void NotifyMainForm()
        {
        }

        /// <summary>
        /// 通知到达时调用方法-子类需重写该方法以处理相关通知
        /// </summary>
        public virtual void NotifyReceive()
        {
            RefreshAll();
        }

        /// <summary>
        /// 添加空行到表
        /// </summary>
        /// <param name="dataTable">表</param>
        protected void AddEmptyRowToTable(DataTable dataTable, int rowCount, string primaryKey)
        {
            while (dataTable.Rows.Count < rowCount)
            {
                DataRow row = dataTable.NewRow();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (dataTable.Columns[i].ColumnName.Equals(primaryKey))
                    {
                        row[i] = dataTable.Rows.Count + 1;
                    }
                    else if (dataTable.Columns[i].DataType.Name.Equals("String"))
                    {
                        row[i] = "";
                    }
                    else if (dataTable.Columns[i].DataType.Name.Equals("DateTime"))
                    {
                        row[i] = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        row[i] = 0;
                    }

                }
                dataTable.Rows.Add(row);
            }
        }

        #endregion
    }
}
