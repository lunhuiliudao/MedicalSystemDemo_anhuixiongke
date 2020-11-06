/*----------------------------------------------------------------
 // Copyright (C) 2007 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
 // �ļ�����BaseControl.cs
 // �ļ�����������
 //     �����ؼ�--�����ؼ������ڴ˻�����
 // 
 // ������ʶ��
 //     ������-2007-12-17
 // �޸ı�ʶ��
 *  ��ռ�� 2008-05-30
 *  ���ӽ��΢���Զ�ת�����뷨Ϊȫ��bug     
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
    /// �����ؼ�
    /// </summary>
    public partial class BaseControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region ����

        /// <summary>
        /// ������
        /// </summary>
        public const string MAINFORM = "MainForm";

        /// <summary>
        /// ȫ��
        /// </summary>
        public const string ALL = "ALL";

        #endregion ����

        #region �¼�

        /// <summary>
        /// ֪ͨ�¼�
        /// </summary>
        /// <param name="sender">������</param>
        /// <param name="e">�¼�����</param>
        /// <param name="notifyNames">֪ͨ����-ALL��ʾȫ��MAINFORM��ʾ������</param>
        public delegate void NotifyEventHandle(object sender, EventArgs e, List<string> notifyLists);

        /// <summary>
        /// ֪ͨ�����¼�
        /// </summary>
        private static readonly object _notifySender = new object();
        [Description("֪ͨ�����¼�")]
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

        #endregion �¼�

        #region ���췽��

        /// <summary>
        /// ���췽��
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

        #region ����


        /// <summary>
        /// ������Ϣ
        /// </summary>
        //protected Patient.PatientRow _patientRow;

        /// <summary>
        /// ����-�ı�ᵼ���˳�ʱ���棻
        /// </summary>
        protected DataTable _mainTable;

        /// <summary>
        /// ��Ҫ���Ƶı���-�κ�һ����ĸı䶼�ᵼ���˳�ʱ���棻
        /// </summary>
        protected DataTable[] _dataTables;

        /// <summary>
        /// ����
        /// </summary>
        protected string _title = "�ޱ���";

        /// <summary>
        /// ��ʾ
        /// </summary>
        protected string _showCode = "ZTHLJM";

        /// <summary>
        /// ָʾ�����Ƿ��Ѿ��ı䣬�����û�ǿ�ƿ��������Ƿ�ı䣬Ĭ��Ϊfalse�����Ϊtrue���˳�ʱǿ�Ʊ��棻
        /// </summary>
        private bool _dataChanged = false;

        /// <summary>
        /// Ȩ�ޱ�־��Ϊ��ӵ��Ȩ�ޣ�Ϊ��û��Ȩ��
        /// </summary>
        private bool _permissionsSign = true;

        /// <summary>
        /// ���Ҵ���
        /// </summary>
        protected string _wardCode = "";

        #endregion ����

        #region ����

        /// <summary>
        /// �ؼ�����
        /// </summary>
        [Description("�ؼ�����")]
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
        ///// ������Ϣ
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
        /// ָʾ�����Ƿ��Ѿ��ı䣬�����û�ǿ�ƿ��������Ƿ�ı䣬Ĭ��Ϊfalse�����Ϊtrue���˳�ʱǿ�Ʊ��棻
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
        /// Ȩ�ޱ�־��Ϊ��ӵ��Ȩ�ޣ�Ϊ��û��Ȩ��
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
        /// ���Ҵ���
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
        #endregion ����

        #region ����

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
        /// ѡ���Ե�ˢ�����ݣ�������������е���ʱ�������Ҫˢ��ѡ��������ش˷�����
        /// </summary>
        public virtual void RefreshDataOptional() { }
        /// <summary>
        /// �����Ĳ�����
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
                if (Dialog.MessageBox("�����Ѹı䣬�Ƿ񱣴棿", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        /// ѡ��ͬ����ʱ����˷���
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
        /// ���΢���Զ��������뷨Ϊȫ��BUG
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            IntPtr HIme = WinAPI.ImmGetContext(this.Handle);
            if (WinAPI.ImmGetOpenStatus(HIme))  //������뷨���ڴ�״̬
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = WinAPI.ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //�������뷨��Ϣ
                if (bSuccess)
                {
                    if ((iMode & WinAPI.IME_CMODE_FULLSHAPE) > 0)   //�����ȫ��
                        WinAPI.ImmSimulateHotKey(this.Handle, WinAPI.IME_CHOTKEY_SHAPE_TOGGLE);  //ת���ɰ��
                }

            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="dataTable">����</param>
        protected virtual void Save() { }

        /// <summary>
        /// ˢ����������
        /// </summary>
        protected virtual void RefreshAll() { }

        public void PopulateNewPatient()
        {
            RefreshAll();
        }
        /// <summary>
        /// ɾ��ѡ����
        /// </summary>
        /// <param name="grid">������ʾ��ͼ</param>
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
        /// ���ɶ�̬��
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
        /// ���ɶ�̬��
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
        /// ���ɶ�̬��
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
        /// ���ɶ�̬��
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
        /// ���ɶ�̬��
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
        /// ת��
        /// </summary>
        /// <param name="dataRow">������</param>
        /// <param name="columnName">����</param>
        /// <returns>���</returns>
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
        /// ת�ַ���
        /// </summary>
        /// <param name="dataRow">������</param>
        /// <param name="columnName">����</param>
        /// <returns>���</returns>
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
        /// ��������
        /// </summary>
        /// <param name="birthdayDate">��������</param>
        /// <returns>���</returns>
        protected int calcAge(DateTime birthdayDate)
        {
            DateTime curDate = DateTime.Now;
            return curDate.Year - birthdayDate.Year - (((curDate.Month < birthdayDate.Month) || ((curDate.Month == birthdayDate.Month) && (curDate.Day < birthdayDate.Day))) ? 1 : 0);
        }

        /// <summary>
        /// ��������(��ƽ92ҽԺ)
        /// </summary>
        /// <param name="birthdayDate">��������</param>
        /// <returns>���</returns>
        protected string calcAgeNanPing92(DateTime birthdayDate)
        {
            try
            {
                //2010-08-23
                //��28�죨��1�����ڣ� ���� 
                //1������ �����¼��� 
                //12�������� �����꼸�£��·ݰ��������룩
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

                //��������Ǹ��Ļ�������""
                if (nYear < 0 || nMonth < 0 || nDay < 0)
                {
                    return "";
                }

                //��28�죨��1�����ڣ� ���� 
                if (nYear == 0 && nMonth == 0)
                {
                    return nDay + "��";
                }
                //1������ �����¼���
                else if (nYear == 0)
                {
                    string sReturn = "";
                    sReturn += nMonth + "��";
                    if (nDay > 0)
                    {
                        sReturn += nDay + "��";
                    }
                    return sReturn;
                }
                //12�������� �����꼸�£��·ݰ��������룩
                else if (nYear < 12)
                {
                    string sReturn = "";
                    sReturn += nYear + "��";

                    //�������������
                    if ((double)nDay / nDaysAMonth >= 0.5)
                    {
                        nMonth += 1;
                    }

                    if (nMonth > 0)
                    {
                        sReturn += nMonth + "��";
                    }
                    return sReturn;

                }
                else
                {
                    return nYear + "��";
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="birthdayDate"></param>
        /// <returns>*��*����</returns>
        protected string calculateAge(DateTime birthdayDate, DateTime today)
        {
            double a = (DateTime.Now - birthdayDate).TotalDays;
            double aYear = Math.Floor(a / 365);
            double C = a % 365;
            double aMonth = Math.Floor(C / 30);
            double aDay = Math.Floor(C % 30);
            if (aYear < 1)
            {
                return aMonth.ToString() + "����";//+ aDay.ToString() + "��";   
            }
            else
            {
                return aYear.ToString() + "��  ";// + aMonth.ToString() + "����   " + aDay.ToString() + "��";
            }
        }


        /// <summary>
        /// ֪ͨ-֪ͨ�ı��Ա�����߻����Ӧͬ������
        /// </summary>
        /// <param name="notifyLists">֪ͨ����-ALL��ʾȫ��MAINFORM��ʾ������</param>
        protected void Notify(List<string> notifyLists)
        {
            NotifyEventHandle notify = (NotifyEventHandle)Events[_notifySender];
            if (notify != null)
            {
                notify(this, new EventArgs(), notifyLists);
            }
        }

        /// <summary>
        /// ֪ͨ-֪ͨ�ı��Ա�����߻����Ӧͬ������
        /// </summary>
        /// <param name="notifyLists">֪ͨ����-ALL��ʾȫ��MAINFORM��ʾ������</param>
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
        /// ֪ͨ-֪ͨ�ı��Ա�����߻����Ӧͬ������
        /// </summary>
        /// <param name="singleControl">��������֪ͨ�Ŀؼ�����</param>
        protected void Notify(string singleControl)
        {
            List<string> list = new List<string>();
            list.Add(singleControl);
            Notify(list);
        }

        /// <summary>
        /// ֪ͨ-֪ͨȫ��ı��Ա�����߻����Ӧͬ������
        /// </summary>
        protected void NotifyAll()
        {
            List<string> list = new List<string>();
            list.Add(ALL);
            Notify(list);
        }

        /// <summary>
        /// ֪ͨ-֪ͨ������ı��Ա�����߻����Ӧͬ������
        /// </summary>
        protected void NotifyMainForm()
        {
        }

        /// <summary>
        /// ֪ͨ����ʱ���÷���-��������д�÷����Դ������֪ͨ
        /// </summary>
        public virtual void NotifyReceive()
        {
            RefreshAll();
        }

        /// <summary>
        /// ��ӿ��е���
        /// </summary>
        /// <param name="dataTable">��</param>
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
