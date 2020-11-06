using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Client.FrameWork;
using DevExpress.XtraEditors;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Client.AppPC
{
    /// <summary>
    /// 界面主要工作区域
    /// </summary>
    [ToolboxItem(true)]
    public partial class WorkSpaceControl : UserControl
    {
        PatientListView _patientView = null;
        PatientListViewPACU _patienViewPACU = null;
        protected DataTemplate _dataTemplate;
        private AnesthesiaEventsEditor _anesthesiaEventsEditor = null;
        private PatMonitorEditor monitor = null;
        private AnesthesiaEventDictSelector selector = null;
        public WorkSpaceControl()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }


        #region 病人搜索列表界面操作

        public void Initial(PatientListView view)
        {
            _patientView = view;
        }
        public void Initial(PatientListViewPACU view)
        {
            _patienViewPACU = view;
        }
        public void AddPatientView()
        {
            if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDirty)
            {
                if (MessageBoxFormPC.Show("是否保存麻醉事件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _anesthesiaEventsEditor.Save();
                }
            }
            // Application.DoEvents();
            panelProcess.Visible = false;
            if (ApplicationConfiguration.IsPACUProgram)
            {
                panelAnesEvent.Text = "复苏事件";
                lblDocTtile.Text = "复苏记录单";
                AddViewToWorkSpace(_patienViewPACU, "PatientListViewPACU");
            }
            else
            {
                panelAnesEvent.Text = "麻醉事件";
                lblDocTtile.Text = "麻醉记录单";
                AddViewToWorkSpace(_patientView, "PatientListView");
            }
        }
        public void AddPatientView(BaseView view, string statusName)
        {
            if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDirty)
            {
                if (MessageBoxFormPC.Show("是否保存麻醉事件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _anesthesiaEventsEditor.Save();
                }
            }
            // Application.DoEvents();
            panelProcess.Visible = false;
            AddViewToWorkSpace(view, statusName);
        }
        /// <summary>
        /// 在主界面中打开View
        /// </summary>
        /// <param name="view"></param>
        public void AddViewToWorkSpace(BaseView view, string viewName)
        {
            view.Name = viewName;
            view.Dock = DockStyle.Fill;
            panelControlContainter.Controls.Clear();
            panelControlContainter.BackColor = Color.White;
            Console.WriteLine("AddViewToWorkSpace —> Controls.Add(view) [START]: " + DateTime.Now.ToString("mm:ss.fff"));
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    panelControlContainter.Controls.Add(view);
                };
                worker.RunWorkerAsync();
            }
            Console.WriteLine("AddViewToWorkSpace —> Controls.Add(view) [E N D]: " + DateTime.Now.ToString("mm:ss.fff"));
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;
            //如果为竖屏
            if (Screen.PrimaryScreen.Bounds.Width < Screen.PrimaryScreen.Bounds.Height)
            {
                this.Padding = new Padding(0, 0, 0, 0);
            }
            RaiseEvent(viewName);
        }

        #endregion

        #region 文书操作界面

        private BaseDoc _baseDoc;

        /// <summary>
        /// 添加医疗文书
        /// </summary>
        /// <param name="baseDoc"></param>
        public void AddDocToWorkSpace(BaseDoc baseDoc)
        {
            panelProcess.Visible = true;
            panelControlContainter.Controls.Clear();
            panelControlContainter.BackColor = Color.FromArgb(199, 233, 250);
            if (baseDoc != null)
            {
                if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.AnesthesiaRecord || ExtendApplicationContext.Current.SystemStatus == ProgramStatus.PACURecord)
                {
                    if (ExtendApplicationContext.Current.PatientInformationExtend != null)
                    {
                        splitContainer1.Panel1Collapsed = false;
                        splitContainer1.Panel2Collapsed = false;
                        AnesEventShow(false, "");
                    }
                }
                else
                {
                    if (ExtendApplicationContext.Current.PatientInformationExtend != null)
                    {
                        splitContainer1.Panel1Collapsed = false;
                        splitContainer1.Panel2Collapsed = true;
                    }
                }
                _baseDoc = baseDoc;
                baseDoc.Dock = DockStyle.Fill;
                panelControlContainter.Controls.Add(baseDoc);
                RaiseEvent("");
                //  Application.DoEvents();
                _dataTemplate = new DataTemplate(baseDoc);
                baseDoc.SaveTemplateClicked += new EventHandler(SaveTemplateClicked);
                baseDoc.ApplyTemplateClicked += new EventHandler(ApplyTemplateClicked);
                baseDoc.SaveAllDataTemplateClicked += new EventHandler(SaveAllDataTemplateClicked);
                baseDoc.ApplyAllDataTemplateClicked += new EventHandler(ApplyAllDataTemplateClicked);
                _baseDoc.RefreshMonitorHandler += delegate
                {
                    if (monitor != null)
                    {
                        monitor.GetVitalSignDataTable();
                        AccessOperEvent();
                        monitor.BringToFront();
                    }

                };
            }
        }
        void button_MouseLeave(object sender, EventArgs e)
        {
            (sender as SimpleButton).BackgroundImage = Resources.按钮样式1;
            (sender as SimpleButton).ForeColor = Color.Black;
        }

        void button_MouseEnter(object sender, EventArgs e)
        {
            (sender as SimpleButton).BackgroundImage = Resources.按钮样式2;
            (sender as SimpleButton).Appearance.BackColor = System.Drawing.Color.Transparent;
            (sender as SimpleButton).Appearance.Options.UseBackColor = true;
            (sender as SimpleButton).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            (sender as SimpleButton).ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            (sender as SimpleButton).LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            (sender as SimpleButton).LookAndFeel.UseDefaultLookAndFeel = false;
            (sender as SimpleButton).ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            (sender as SimpleButton).BackgroundImageLayout = ImageLayout.Stretch;
            (sender as SimpleButton).ForeColor = Color.White;
        }

        #endregion

        #region 麻醉事件及体征操作

        private void panelAnesEvent_Click(object sender, EventArgs e)
        {
            if (monitor != null && monitor.IsDirty)
            {
                if (MessageBoxFormPC.Show("是否保存体征修改项目？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    monitor.Save();
                }
            }
            if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDirty)
            {
                if (MessageBoxFormPC.Show("是否保存麻醉事件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _anesthesiaEventsEditor.Save();
                }
            }
            panelTopEvent.BackgroundImage = Resources.事件体征1;
            panelControlSelector.Visible = true;

            AnesEventShow(false, "");
        }

        private void panelVitalSign_Click(object sender, EventArgs e)
        {
            if (monitor != null && monitor.IsDirty)
            {
                if (MessageBoxFormPC.Show("是否保存体征修改项目？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    monitor.Save();
                }
            }
            if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDirty)
            {
                if (MessageBoxFormPC.Show("是否保存麻醉事件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _anesthesiaEventsEditor.Save();
                }
            }
            panelTopEvent.BackgroundImage = Resources.事件体征2;
            panelControlSelector.Visible = false;

            VitalSignShow();
        }

        #endregion

        public void SaveClicked(object sender, EventArgs e)
        {
            if (_baseDoc != null)
            {
                _baseDoc.RefreshData(true);
            }
        }

        private void AnesEventShow(bool isAddEvent, string eventName)
        {
            panelControlEvent.Controls.Clear();
            if (_anesthesiaEventsEditor == null)
            {
                _anesthesiaEventsEditor = new AnesthesiaEventsEditor(ExtendApplicationContext.Current.PatientInformationExtend, ApplicationConfiguration.IsPACUProgram ? "1" : "0");
                _anesthesiaEventsEditor.EventSaveClicked += new EventHandler(SaveClicked);
                _anesthesiaEventsEditor.Dock = DockStyle.Fill;
            }
            else
            {
                _anesthesiaEventsEditor.RefAnesthesiaEvent(ExtendApplicationContext.Current.PatientInformationExtend, ApplicationConfiguration.IsPACUProgram ? "1" : "0");
            }
            panelControlEvent.Controls.Add(_anesthesiaEventsEditor);
            _anesthesiaEventsEditor.BringToFront();
            panelControlEvent.Dock = DockStyle.Fill;

            AccessOperEvent();
            AnesEventSelector();
            // panelControlEvent.Controls.Add(panelControlSelector);
        }
        private void AnesEventSelector()
        {
            if (selector == null)
            {
                panelControlSelector.Controls.Clear();
                panelControlSelector.Dock = DockStyle.Top;
                selector = new AnesthesiaEventDictSelector("", _anesthesiaEventsEditor);
                panelControlSelector.Controls.Add(selector);
                selector.Dock = DockStyle.Fill;
                selector.BringToFront();
            }
        }
        private void VitalSignShow()
        {
            panelControlEvent.Controls.Clear();
            panelControlEvent.Dock = DockStyle.Fill;
            monitor = new PatMonitorEditor(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID, ApplicationConfiguration.IsPACUProgram ? "1" : "0");
            panelControlEvent.Controls.Add(monitor);
            monitor.SignVitalSaveClicked += new EventHandler(SaveClicked);
            monitor.Dock = DockStyle.Fill;
            AccessOperEvent();
            monitor.BringToFront();
        }
        private void AccessOperEvent()
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                if (!AccessControl.CheckModifyRightForOperator("复苏记录单") && ApplicationConfiguration.ApplicationPatterns == "0")
                {
                    if (_anesthesiaEventsEditor != null)
                    {
                        _anesthesiaEventsEditor.SetReadOnly(false);
                    }
                    if (selector != null)
                    {
                        selector.Visible = true;
                    }
                    if (monitor != null)
                    {
                        monitor.SetReadOnly(false);
                    }
                }
            }
            else if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
            {
                if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ApplicationConfiguration.ApplicationPatterns == "0")
                {
                    if (_anesthesiaEventsEditor != null)
                    {
                        _anesthesiaEventsEditor.SetReadOnly(false);
                    }
                    if (selector != null)
                    {
                        selector.Visible = false;
                    }
                    if (monitor != null)
                    {
                        monitor.SetReadOnly(false);
                    }
                }
            }
        }
        /// <summary>
        /// 取消手术 病案提交
        /// </summary>
        /// <param name="operationStatus"></param>
        public void CancelOrCommitOperation(OperationStatus operationStatus, string cancelReason)
        {
            toolBarsControl1.CancelOrCommitOperation(operationStatus, cancelReason);
        }

        public void RecoveryOperation(string recoveryReason)
        {
            //toolBarsControl1.RecoveryOperation(recoveryReason);
        }
        #region 界面切换事件

        /// <summary>
        /// 界面切换事件
        /// </summary>
        public EventHandler<ViewChangedEventArgs> ViewChangedEvent;

        /// <summary>
        /// 发起界面切换事件
        /// </summary>
        /// <param name="viewName">界面名称</param>
        /// <param name="viewType">界面类型名称</param>
        /// <param name="isShowDialog">是否以模式窗口显示</param>
        public void RaiseEvent(string viewName)
        {
            if (ViewChangedEvent != null)
                ViewChangedEvent(this, new ViewChangedEventArgs(viewName));
        }

        #endregion

        /// <summary>
        /// 模式显示窗体
        /// </summary>
        /// <param name="view"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public DialogResult ShowViewDialog(BaseView view, int width, int height)
        {
            DialogHostFormPC dialogHostForm = new DialogHostFormPC(view.Caption, width, height);
            dialogHostForm.Child = view;
            return dialogHostForm.ShowDialog();
        }


        public DialogResult ShowViewDialog2(BaseView view, bool isMaximized)
        {
            DialogHostFormPC dialogHostForm = new DialogHostFormPC(view.Caption, false);
            dialogHostForm.Child = view;
            dialogHostForm.MaximizeBox = false;
            dialogHostForm.Height = Screen.PrimaryScreen.WorkingArea.Height - 80; ;
            dialogHostForm.Width = Screen.PrimaryScreen.WorkingArea.Width - 80;
            dialogHostForm.StartPosition = FormStartPosition.CenterScreen;
            dialogHostForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            return dialogHostForm.ShowDialog();
        }
        public Control CurrentControl
        {
            get
            {
                if (panelControlContainter.Controls.Count > 0)
                    return panelControlContainter.Controls[0];
                else
                    return this;
            }
        }
        public void SaveTemplateClicked(object sender, EventArgs e)
        {
            _dataTemplate.SaveModel();
        }
        public void ApplyTemplateClicked(object sender, EventArgs e)
        {
            _dataTemplate.ApplyModel();
        }
        public void SaveAllDataTemplateClicked(object sender, EventArgs e)
        {
            _dataTemplate.SaveAllDataModel(_baseDoc.GetTotalModelDataTabla());
        }
        public void ApplyAllDataTemplateClicked(object sender, EventArgs e)
        {
            DataTable TotalModelDT = _dataTemplate.ApplyAllDataModel();
            _baseDoc.ApplyAllDocTemplate(TotalModelDT);
        }

        private void lblRescue_Click(object sender, EventArgs e)
        {
            //lblRescue.Image = Resources.抢救_3;
            //RescueControl rescue = new RescueControl();
            //DialogHostFormPC dialogHostForm = new DialogHostFormPC("抢救", rescue.Width, rescue.Height);
            //dialogHostForm.Child = rescue;
            //dialogHostForm.ShowDialog();
        }

        private void lblRescue_MouseMove(object sender, MouseEventArgs e)
        {
            lblRescue.Image = Resources.抢救_2;
        }

        private void lblRescue_MouseLeave(object sender, EventArgs e)
        {
            lblRescue.Image = Resources.抢救_1;
        }
    }
}
