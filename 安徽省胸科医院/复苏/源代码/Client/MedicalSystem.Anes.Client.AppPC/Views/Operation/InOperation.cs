using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Medicalsystem.Anes.Framework;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.AppPC;
using MedicalSystem.Anes.Client.FrameWork;

namespace Medicalsystem.Anes.Views
{
    /// <summary>
    /// 术中信息维护类
    /// </summary>
    [ToolboxItem(true)]
    public partial class InOperation : BaseView
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientInfo">病人基本信息</param>
        public InOperation(MED_PATIENT_CARD patientInfo, decimal eventNo)
            : this(patientInfo, eventNo, false)
        {
        }

        public InOperation(MED_PATIENT_CARD patientInfo, decimal eventNo, bool showAnesAndOper)
        {
            Caption = ViewNames.InOperation;
            if (eventNo == 1)
            {
                Caption = ViewNames.PACUInOperation;
            }
            DevExpress.XtraEditors.SplitContainerControl splitter = new DevExpress.XtraEditors.SplitContainerControl();
            splitter.Dock = DockStyle.Fill;
            Controls.Add(splitter);
            splitter.Horizontal = false;
            splitter.Panel2.MinSize = 150;
            splitter.Panel1.MinSize = 200;
            splitter.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            Panel pnlBody = new Panel();
            pnlBody.Dock = DockStyle.Fill;   
            _anesthesiaEventsEditor = new AnesthesiaEventsEditor(patientInfo, eventNo.ToString()); 
            pnlBody.Controls.Add(_anesthesiaEventsEditor);
            _anesthesiaEventsEditor.Dock = DockStyle.Fill;
            _anesthesiaEventsEditor.BringToFront(); 
            splitter.Panel1.Controls.Add(pnlBody); 
            _patMonitorEditor = new PatMonitorEditor(patientInfo.PATIENT_ID, patientInfo.VISIT_ID, patientInfo.OPER_ID, eventNo.ToString());
            _patMonitorEditor.Dock = DockStyle.Fill;
            splitter.SplitterPosition = 280;
            splitter.Panel2.Controls.Add(_patMonitorEditor); 
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                if (_anesthesiaEventsEditor != null)
                {
                    _anesthesiaEventsEditor.SetReadOnly(false);
                } 
                if (_patMonitorEditor != null)
                {
                    _patMonitorEditor.SetReadOnly(false);
                }
            }
            else if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
            {
                if (!AccessControl.CheckModifyRight(PermissionContext.ANESRECORDOPER) || !AccessControl.CheckModifyRightForOperator("麻醉记录单"))//ApplicationConfiguration.AnesRecordOper)//麻醉数据修改操作权限控制
                {
                if (_anesthesiaEventsEditor != null)
                {
                    _anesthesiaEventsEditor.SetReadOnly(true);
                } 
                }
                else
                {
                if (_anesthesiaEventsEditor != null)
                {
                    _anesthesiaEventsEditor.SetReadOnly(false);
                } 
                }
                if (!AccessControl.CheckModifyRight(PermissionContext.MonitorDataEdit) || !AccessControl.CheckModifyRightForOperator("麻醉记录单"))
                {
                if (_patMonitorEditor != null)
                {
                    _patMonitorEditor.SetReadOnly(true);
                }
                }
                else
                {
                if (_patMonitorEditor != null)
                {
                    _patMonitorEditor.SetReadOnly(false);
                }
                }

            }

            //只有PACU时判断
            if (ExtendApplicationContext.Current.EventNo == "1" )
            {
                if (!ExtendApplicationContext.Current.CustomSettingContext.IsShowAnesthesiaEventsEditor)
                {
                    SetAnesthesiaEventsEditorVisible(false);
                    splitter.Panel1.MinSize = 0;
                    splitter.Panel2.MinSize = (int)(Screen.PrimaryScreen.Bounds.Height);
                    splitter.Panel1.Height = 0;
                    splitter.SplitterPosition = 0;
                }
                if (!ExtendApplicationContext.Current.CustomSettingContext.IsShowPatMonitorEditor)
                {
                    _patMonitorEditor.Visible = false;

                    splitter.Panel2.MinSize = 0;
                    splitter.Panel1.MinSize = (int)(Screen.PrimaryScreen.Bounds.Height);
                    splitter.Panel2.Height = 0;

                    splitter.SplitterPosition = (int)(Screen.PrimaryScreen.Bounds.Height);

                }
            }
        } 
        private void _anesthesiaEventDictSelector_ItemSelected(object sender, EventArgs e)
        {
            if (sender is DataGridViewRow)
            {
                MED_ANESTHESIA_EVENT row = AddRow(sender);
                if (_anesthesiaEventsEditor != null)
                {
                    _anesthesiaEventsEditor.RefreshRow(row);
                }
            }
        }

        private AnesthesiaEventsEditor _anesthesiaEventsEditor = null;
        private PatMonitorEditor _patMonitorEditor = null;
        private PatMonitorEditor _patMonitorEditor1 = null; 

        /// <summary>
        /// 设置事件控件是否可见
        /// </summary>
        /// <param name="visible"></param>
        public void SetAnesthesiaEventsEditorVisible(bool visible )
        {
            if (_anesthesiaEventsEditor != null)
                _anesthesiaEventsEditor.Visible = visible;
        }
        /// <summary>
        /// 设置体征控件是否可见
        /// </summary>
        /// <param name="visible"></param>
        public void SetPatMonitorEditorVisible(bool visible)
        {
            if (_patMonitorEditor != null)
            {
                _patMonitorEditor.Visible = visible;
            }
            if (_patMonitorEditor1 != null)
            {
                _patMonitorEditor1.Visible = visible;
            }
        }
        /// <summary>
        /// 设置 事件字典 控件是否可见
        /// </summary>
        /// <param name="visible"></param>
       
        private static readonly object _dataChangedEventHandle = new object();
        public event EventHandler DataChanged
        {
            add
            {
                Events.AddHandler(_dataChangedEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_dataChangedEventHandle, value);
            }
        }

        public bool IsDataChanged
        {
            get
            {
                if (_anesthesiaEventsEditor != null)
                {
                    return _anesthesiaEventsEditor.IsDataChanged;
                }
                return false;
            }
        }

        public override bool IsDirty
        {
            get
            {
                bool result = false;
                if (_anesthesiaEventsEditor != null)
                {
                    result = _anesthesiaEventsEditor.IsDirty;
                }
                if (_patMonitorEditor != null && _patMonitorEditor.IsDirty)
                {
                    result = true;
                }
                return result;
            }
        }

        public bool IsDataSaved
        {
            get
            {
                bool result = false;
                if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDataSaved)
                {
                    result = true;
                }
                else if (_patMonitorEditor != null && _patMonitorEditor.IsDataSaved)
                {
                    result = true;
                }
                return result;
            }
        }

        public bool ShowCloseButton
        {
            get
            {
                if (_anesthesiaEventsEditor != null)
                {
                    return _anesthesiaEventsEditor.ShowCloseButton;
                }
                return false;
            }
            set
            {
                if (_anesthesiaEventsEditor != null)
                {
                    _anesthesiaEventsEditor.ShowCloseButton = value;
                }
            }
        }

        public bool CheckItems()
        {
            if (_anesthesiaEventsEditor != null)
            {
                return _anesthesiaEventsEditor.CheckItems();
            }
            return false;
        }

        public override bool Save()
        {
            bool result = false;
            if (_anesthesiaEventsEditor != null)
            {
                result = _anesthesiaEventsEditor.Save();
            }
            if (_patMonitorEditor != null && _patMonitorEditor.Save())
            {
                result = true;
            }
            return result;
        }

        public void SetMonitorDataOnly()
        {
            if (_anesthesiaEventsEditor != null)
            {
                _anesthesiaEventsEditor.Visible = false;
            }
            if (_patMonitorEditor != null)
            {
                _patMonitorEditor.Dock = DockStyle.Fill;
            }
        }

        public void SetEventType(string typeName)
        {
            if (_anesthesiaEventsEditor != null)
            {
                _anesthesiaEventsEditor.SetEventType(typeName);
            }
        }

        public void SetText(string text)
        {
            if (_anesthesiaEventsEditor != null)
            {
                _anesthesiaEventsEditor.SetText(text);
            }
        }

        public void SetText(string text, DateTime startTime)
        {
            if (_anesthesiaEventsEditor != null)
            {
                _anesthesiaEventsEditor.SetText(text,startTime);
            }
        }

        public void CopyConcentrationRow()
        {
            if (_anesthesiaEventsEditor != null)
            {
                _anesthesiaEventsEditor.CopyConcentrationRow();
            }
        }

        public MED_ANESTHESIA_EVENT AddRow(object obj)
        {
            if (_anesthesiaEventsEditor != null)
            {
                return _anesthesiaEventsEditor.AddRow(obj); 
            }
            return null;
        }

        public MED_ANESTHESIA_EVENT AddRow(object obj, Nullable<DateTime> startTime, Nullable<DateTime> endDate)
        {
            if (_anesthesiaEventsEditor != null)
            {
                return _anesthesiaEventsEditor.AddRow(obj, startTime, endDate);
            }
            return null;
        }
    }
}
