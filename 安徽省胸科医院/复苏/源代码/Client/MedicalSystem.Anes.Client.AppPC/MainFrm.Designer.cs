namespace MedicalSystem.Anes.Client.AppPC
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.timerResponse = new System.Windows.Forms.Timer(this.components);
            this.panelTop2 = new System.Windows.Forms.Panel();
            this.txtScheduledTime = new DevExpress.XtraEditors.DateEdit();
            this.searchTextBox1 = new MedicalSystem.Anes.Client.FrameWork.SearchTextBox();
            this.medMessage1 = new MedicalSystem.Anes.Client.FrameWork.MedMessage();
            this.barStaticLoginUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDownMenus = new MedicalSystem.Anes.Client.FrameWork.ButtonDownMenu();
            this.Logo = new System.Windows.Forms.Panel();
            this.tableControlMenuCourseOfDisease = new MedicalSystem.Anes.Client.FrameWork.TableControlMenu();
            this.tableControlMenuInstruments = new MedicalSystem.Anes.Client.FrameWork.TableControlMenu();
            this.tableControlMenuOperation = new MedicalSystem.Anes.Client.FrameWork.TableControlMenu();
            this.workSpaceControl1 = new MedicalSystem.Anes.Client.AppPC.WorkSpaceControl();
            this.currentUserInfo = new MedicalSystem.Anes.Client.AppPC.CurrentUser();
            this.topBarControl1 = new MedicalSystem.Anes.Client.AppPC.TopBarControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panlHeader.SuspendLayout();
            this.panelTop2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduledTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduledTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Margin = new System.Windows.Forms.Padding(4);
            this.picIcon.Padding = new System.Windows.Forms.Padding(15, 8, 15, 13);
            this.picIcon.Size = new System.Drawing.Size(84, 50);
            this.picIcon.Visible = false;
            // 
            // panelClose
            // 
            this.panelClose.Location = new System.Drawing.Point(1097, 0);
            this.panelClose.Margin = new System.Windows.Forms.Padding(4);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.currentUserInfo);
            this.panelTop.Controls.Add(this.Logo);
            this.panelTop.Controls.Add(this.topBarControl1);
            this.panelTop.Controls.Add(this.buttonDownMenus);
            this.panelTop.Location = new System.Drawing.Point(84, 0);
            this.panelTop.Size = new System.Drawing.Size(1013, 50);
            this.panelTop.Controls.SetChildIndex(this.lblTitle, 0);
            this.panelTop.Controls.SetChildIndex(this.buttonDownMenus, 0);
            this.panelTop.Controls.SetChildIndex(this.topBarControl1, 0);
            this.panelTop.Controls.SetChildIndex(this.Logo, 0);
            this.panelTop.Controls.SetChildIndex(this.currentUserInfo, 0);
            // 
            // panlHeader
            // 
            this.panlHeader.Location = new System.Drawing.Point(2, 1);
            this.panlHeader.Size = new System.Drawing.Size(1247, 50);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1013, 50);
            this.lblTitle.Text = "";
            // 
            // timerResponse
            // 
            this.timerResponse.Interval = 1000;
            this.timerResponse.Tick += new System.EventHandler(this.Timer_Ticked);
            // 
            // panelTop2
            // 
            this.panelTop2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTop2.BackgroundImage")));
            this.panelTop2.Controls.Add(this.txtScheduledTime);
            this.panelTop2.Controls.Add(this.searchTextBox1);
            this.panelTop2.Controls.Add(this.medMessage1);
            this.panelTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelTop2.Location = new System.Drawing.Point(2, 51);
            this.panelTop2.Name = "panelTop2";
            this.panelTop2.Size = new System.Drawing.Size(1247, 50);
            this.panelTop2.TabIndex = 27;
            // 
            // txtScheduledTime
            // 
            this.txtScheduledTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScheduledTime.EditValue = null;
            this.txtScheduledTime.Location = new System.Drawing.Point(736, 12);
            this.txtScheduledTime.Name = "txtScheduledTime";
            this.txtScheduledTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScheduledTime.Properties.Appearance.Options.UseFont = true;
            this.txtScheduledTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtScheduledTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtScheduledTime.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtScheduledTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtScheduledTime.Properties.LookAndFeel.SkinName = "Blue";
            this.txtScheduledTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtScheduledTime.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtScheduledTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtScheduledTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtScheduledTime.Size = new System.Drawing.Size(161, 21);
            this.txtScheduledTime.TabIndex = 42;
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox1.BackColor = System.Drawing.Color.White;
            this.searchTextBox1.CurrentText = "";
            this.searchTextBox1.DefaultText = "请输入患者ID、住院号、姓名";
            this.searchTextBox1.Location = new System.Drawing.Point(906, 7);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(299, 29);
            this.searchTextBox1.TabIndex = 4;
            this.searchTextBox1.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.SearchTextBox.BtnClickHandle(this.search_BtnClicked);
            // 
            // medMessage1
            // 
            this.medMessage1.BackColor = System.Drawing.Color.Transparent;
            this.medMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medMessage1.Location = new System.Drawing.Point(0, 0);
            this.medMessage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.medMessage1.Name = "medMessage1";
            this.medMessage1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.medMessage1.Size = new System.Drawing.Size(1247, 50);
            this.medMessage1.TabIndex = 3;
            // 
            // barStaticLoginUser
            // 
            this.barStaticLoginUser.AutoSize = true;
            this.barStaticLoginUser.BackColor = System.Drawing.Color.Transparent;
            this.barStaticLoginUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barStaticLoginUser.ForeColor = System.Drawing.Color.Transparent;
            this.barStaticLoginUser.Location = new System.Drawing.Point(529, 5);
            this.barStaticLoginUser.Name = "barStaticLoginUser";
            this.barStaticLoginUser.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.barStaticLoginUser.Size = new System.Drawing.Size(105, 27);
            this.barStaticLoginUser.TabIndex = 0;
            this.barStaticLoginUser.Text = "当前用户：MDSD";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(84, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 32);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDownMenus
            // 
            this.buttonDownMenus.BackColor = System.Drawing.Color.Transparent;
            this.buttonDownMenus.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDownMenus.IsDirty = false;
            this.buttonDownMenus.Items = null;
            this.buttonDownMenus.Location = new System.Drawing.Point(983, 0);
            this.buttonDownMenus.Name = "buttonDownMenus";
            this.buttonDownMenus.SelectIndex = -1;
            this.buttonDownMenus.Size = new System.Drawing.Size(30, 50);
            this.buttonDownMenus.TabIndex = 35;
            this.buttonDownMenus.TProgramStatus = MedicalSystem.Anes.Client.FrameWork.ProgramStatus.NoPatient;
            this.buttonDownMenus.ItemClick += new MedicalSystem.Anes.Client.FrameWork.ButtonDownMenu.ItemClickEvent(this.buttonDownMenus_ItemClick);
            // 
            // Logo
            // 
            this.Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Logo.BackgroundImage")));
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.Logo.Location = new System.Drawing.Point(700, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(410, 50);
            this.Logo.TabIndex = 36;
            // 
            // tableControlMenuCourseOfDisease
            // 
            this.tableControlMenuCourseOfDisease.BackColor = System.Drawing.Color.White;
            this.tableControlMenuCourseOfDisease.IsDirty = false;
            this.tableControlMenuCourseOfDisease.Items = null;
            this.tableControlMenuCourseOfDisease.Location = new System.Drawing.Point(1212, 121);
            this.tableControlMenuCourseOfDisease.MenuType = MedicalSystem.Anes.Client.FrameWork.TableControlMenu.ControlType.病历病程;
            this.tableControlMenuCourseOfDisease.Name = "tableControlMenuCourseOfDisease";
            this.tableControlMenuCourseOfDisease.SelectIndex = -1;
            this.tableControlMenuCourseOfDisease.Size = new System.Drawing.Size(35, 122);
            this.tableControlMenuCourseOfDisease.TabIndex = 28;
            this.tableControlMenuCourseOfDisease.ThisLeft = 0;
            this.tableControlMenuCourseOfDisease.ItemClick += new MedicalSystem.Anes.Client.FrameWork.TableControlMenu.ItemClickEvent(this.tableControlMenuTest_ItemClick);
            // 
            // tableControlMenuInstruments
            // 
            this.tableControlMenuInstruments.BackColor = System.Drawing.Color.White;
            this.tableControlMenuInstruments.IsDirty = false;
            this.tableControlMenuInstruments.Items = null;
            this.tableControlMenuInstruments.Location = new System.Drawing.Point(1212, 243);
            this.tableControlMenuInstruments.MenuType = MedicalSystem.Anes.Client.FrameWork.TableControlMenu.ControlType.患者文书;
            this.tableControlMenuInstruments.Name = "tableControlMenuInstruments";
            this.tableControlMenuInstruments.SelectIndex = -1;
            this.tableControlMenuInstruments.Size = new System.Drawing.Size(35, 122);
            this.tableControlMenuInstruments.TabIndex = 29;
            this.tableControlMenuInstruments.ThisLeft = 0;
            this.tableControlMenuInstruments.ItemClick += new MedicalSystem.Anes.Client.FrameWork.TableControlMenu.ItemClickEvent(this.tableControlMenuInstruments_ItemClick);
            // 
            // tableControlMenuOperation
            // 
            this.tableControlMenuOperation.BackColor = System.Drawing.Color.White;
            this.tableControlMenuOperation.IsDirty = false;
            this.tableControlMenuOperation.Items = null;
            this.tableControlMenuOperation.Location = new System.Drawing.Point(1212, 0);
            this.tableControlMenuOperation.MenuType = MedicalSystem.Anes.Client.FrameWork.TableControlMenu.ControlType.术中操作;
            this.tableControlMenuOperation.Name = "tableControlMenuOperation";
            this.tableControlMenuOperation.SelectIndex = -1;
            this.tableControlMenuOperation.Size = new System.Drawing.Size(35, 122);
            this.tableControlMenuOperation.TabIndex = 29;
            this.tableControlMenuOperation.ThisLeft = 0;
            this.tableControlMenuOperation.ItemClick += new MedicalSystem.Anes.Client.FrameWork.TableControlMenu.ItemClickEvent(this.tableControlMenuTest_ItemClick);
            // 
            // workSpaceControl1
            // 
            this.workSpaceControl1.BackColor = System.Drawing.Color.White;
            this.workSpaceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workSpaceControl1.Location = new System.Drawing.Point(20, 0);
            this.workSpaceControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.workSpaceControl1.Name = "workSpaceControl1";
            this.workSpaceControl1.Size = new System.Drawing.Size(1227, 464);
            this.workSpaceControl1.TabIndex = 26;
            this.workSpaceControl1.Load += new System.EventHandler(this.workSpaceControl1_Load);
            // 
            // currentUserInfo
            // 
            this.currentUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.currentUserInfo.CoorCount = 0;
            this.currentUserInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.currentUserInfo.JobName = "麻醉医生";
            this.currentUserInfo.Location = new System.Drawing.Point(643, 0);
            this.currentUserInfo.Margin = new System.Windows.Forms.Padding(4);
            this.currentUserInfo.MsgCount = 0;
            this.currentUserInfo.Name = "currentUserInfo";
            this.currentUserInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.currentUserInfo.Size = new System.Drawing.Size(340, 50);
            this.currentUserInfo.TabIndex = 2;
            this.currentUserInfo.UserName = "张三";
            this.currentUserInfo.BtnClicked += new MedicalSystem.Anes.Client.AppPC.CurrentUser.BtnClickHandle(this.currentUserInfo_BtnClicked);
            // 
            // topBarControl1
            // 
            this.topBarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.topBarControl1.Location = new System.Drawing.Point(0, 0);
            this.topBarControl1.Margin = new System.Windows.Forms.Padding(4);
            this.topBarControl1.Name = "topBarControl1";
            this.topBarControl1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.topBarControl1.Size = new System.Drawing.Size(700, 50);
            this.topBarControl1.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableControlMenuCourseOfDisease);
            this.panel1.Controls.Add(this.tableControlMenuOperation);
            this.panel1.Controls.Add(this.tableControlMenuInstruments);
            this.panel1.Controls.Add(this.workSpaceControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 101);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 1);
            this.panel1.Size = new System.Drawing.Size(1247, 465);
            this.panel1.TabIndex = 30;
            // 
            // MainFrm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 567);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFrm";
            this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainFrm_SizeChanged);
            this.Controls.SetChildIndex(this.panlHeader, 0);
            this.Controls.SetChildIndex(this.panelTop2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panlHeader.ResumeLayout(false);
            this.panelTop2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduledTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduledTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerResponse;
        private TopBarControl topBarControl1;
        private WorkSpaceControl workSpaceControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelTop2;
        private System.Windows.Forms.Label barStaticLoginUser;
        private CurrentUser currentUserInfo;
        private FrameWork.ButtonDownMenu buttonDownMenus;
        private System.Windows.Forms.Panel Logo;
        private FrameWork.TableControlMenu tableControlMenuCourseOfDisease;
        private FrameWork.TableControlMenu tableControlMenuInstruments;
        private FrameWork.TableControlMenu tableControlMenuOperation;
        private FrameWork.MedMessage medMessage1;
        private FrameWork.SearchTextBox searchTextBox1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.DateEdit txtScheduledTime;
    }
}