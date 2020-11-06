using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MedicalSystem.MedScreen.Controls;
using MedicalSystem.MedScreen.Network;
using MedicalSystem.MedScreen.Common;
using MedicalSystem.AnesIcuQuery.Models;
using MedicalSystem.AnesIcuQuery.Network;
using ClientScreens;

namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    public partial class MainScreenFrm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 按键监听
        /// </summary>
        KeyboardHook k_hook = null;

        public MainScreenFrm()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            //扩展屏显示，主屏索引是0，扩展屏1索引1，扩展屏2索引2....
            //注意需要设置显示在扩展屏上的大屏，不能设置全屏，只能设置大小
            if (System.Windows.Forms.Screen.AllScreens.Length >= 2)
            {
                ChooseScreenFrm chsScreen = new ChooseScreenFrm();
                if (chsScreen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ExtendAppContext.Current.ScreenIndex = chsScreen.SelectedIndex;
                }
            }
            InitialScreenConfig();
            InitialScreenControl();
            //this.SetDesktopLocation(System.Windows.Forms.Screen.AllScreens[ExtendAppContext.Current.ScreenIndex].Bounds.Left, System.Windows.Forms.Screen.AllScreens[ExtendAppContext.Current.ScreenIndex].Bounds.Top);

        }

        /// <summary>
        /// 初始化加载大屏控件
        /// </summary>
        private void InitialScreenControl()
        {
            XtraUserControl userCtr = null;
            try
            {
                //if (ExtendAppContext.Current.ShowScreenNo > 1)
                {
                    this.Left = System.Windows.Forms.Screen.AllScreens[ExtendAppContext.Current.ScreenIndex].Bounds.Left;
                    this.Top = System.Windows.Forms.Screen.AllScreens[ExtendAppContext.Current.ScreenIndex].Bounds.Top;
                }
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", OperationEnum.Equal, ExtendAppContext.Current.CurntScreenNo);
                DataTable screenDictData = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenDict, queryParams).ToDataTable();
                if (screenDictData != null && screenDictData.Rows.Count > 0)
                {
                    string typeName = screenDictData.Rows[0]["SCREEN_TYPE"].ToString();
                    ExtendAppContext.Current.ScreenLabel = screenDictData.Rows[0]["SCREEN_LABEL"].ToString();
                    bool isFullScreen = screenDictData.Rows[0]["FULL_SCREEN"].ToString() == "1";
                    int width = int.Parse(screenDictData.Rows[0]["SCREEN_WIDTH"].ToString());
                    int height = int.Parse(screenDictData.Rows[0]["SCREEN_HEIGHT"].ToString());
                    if (isFullScreen)
                        this.WindowState = FormWindowState.Maximized;
                    else
                    {
                        this.Width = width;
                        this.Height = height;
                    }
                    ExtendAppContext.Current.CurntScreentType = ScreenTypeHelper.GetScreenTypeByName(typeName);
                    TransMessageManager.Instance.OpenConnection();
                }
                else
                {
                    //new frmMessageBox().Show("未获取到当前大屏的配置信息，请完成大屏配置后重新登录。", "大屏提示", MessageBoxButtons.OK, MessageBoxIcon.Information, 0);
                    AutoClosedMsgBox.Show("未获取到当前大屏的配置信息，请完成大屏配置后重新登录。", "大屏提示", 0, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            switch (ExtendAppContext.Current.CurntScreentType)
            {
                case ScreenType.OperScheduleScreen:
                    userCtr = new OperScheduleScreen();
                    (userCtr as OperScheduleScreen).parentDoubleClick += new EventHandler(MainScreenFrm_DoubleClick);
                    break;
                case ScreenType.FamilyWaitScreen:
                    userCtr = new FamilyWaitScreen();
                    (userCtr as FamilyWaitScreen).parentDoubleClick += new EventHandler(MainScreenFrm_DoubleClick);
                    break;
            }
            userCtr.Parent = this;
            userCtr.Dock = DockStyle.Fill;
        }

        private void InitialScreenConfig()
        {
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", OperationEnum.Equal, ExtendAppContext.Current.CurntScreenNo);
                DataTable screenConfigDT = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenConfig, queryParams).ToDataTable();
                if (screenConfigDT.Rows.Count == 0)
                {
                    //new frmMessageBox().Show("未获取到当前大屏的配置信息，请完成大屏配置后重新登录。", "大屏提示", MessageBoxButtons.OK, MessageBoxIcon.Information, 0);
                    AutoClosedMsgBox.Show("未获取到当前大屏的配置信息，请完成大屏配置后重新登录。", "大屏提示", 0, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
                else
                {
                    DataRow dr = screenConfigDT.Rows[0];
                    ExtendAppContext.Current.OperDeptCode = dr["OPER_DEPT_CODE"].ToString();
                    ExtendAppContext.Current.OperRoomFilter = dr["OPERROOM_FILTER"].ToString();
                    ExtendAppContext.Current.RefreshTime = int.Parse(dr["REFRESH_TIME"].ToString());
                    ExtendAppContext.Current.RowCount = int.Parse(dr["ROW_COUNT"].ToString());
                    ExtendAppContext.Current.IsBroadCast = int.Parse(dr["VOICE_BROADCAST"].ToString()) == 1;
                    ExtendAppContext.Current.SeqMode = dr["SHOW_MODE"].ToString().Equals("Sequence");
                    ExtendAppContext.Current.MarkSpec = int.Parse(dr["MARK_SPEC"].ToString()) == 1;
                    ExtendAppContext.Current.IsTV = int.Parse(dr["SHOW_TV"].ToString()) == 1;
                    ExtendAppContext.Current.IsPrivate = int.Parse(dr["PROTECT_PRIVATE"].ToString()) == 1;
                    ExtendAppContext.Current.SkinName = dr["SKIN"].ToString();
                    //获取静态播报信息列表
                    DataTable staticMsgTable = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetValidMsgData, queryParams).ToDataTable();
                    List<string> staticListMsg = new List<string>();
                    if (staticMsgTable != null && staticMsgTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in staticMsgTable.Rows)
                        {
                            if (!row.IsNull("MSG_CONTENT") && !string.IsNullOrEmpty(row["MSG_CONTENT"].ToString()))
                                staticListMsg.Add(row["MSG_CONTENT"].ToString());
                        }
                        ExtendAppContext.Current.StaticMsgList = staticListMsg;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void MainScreenFrm_Load(object sender, EventArgs e)
        {

            ////扩展屏显示，主屏索引是0，扩展屏1索引1，扩展屏2索引2....
            //if (System.Windows.Forms.Screen.AllScreens.Length >= 2)
            //{
            //    this.SetDesktopLocation(System.Windows.Forms.Screen.AllScreens[1].Bounds.Left, System.Windows.Forms.Screen.AllScreens[1].Bounds.Top);
            //}
            this.SetDesktopLocation(System.Windows.Forms.Screen.AllScreens[ExtendAppContext.Current.ScreenIndex].Bounds.Left, System.Windows.Forms.Screen.AllScreens[ExtendAppContext.Current.ScreenIndex].Bounds.Top);

            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
        }

        private void MainScreenFrm_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = AutoClosedMsgBox.Show("是否要退出医患协同大屏？", "大屏提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //TransMessageManager.Instance.CloseConnection();
                Environment.Exit(0);
            }

            //this.FormBorderStyle = this.FormBorderStyle == FormBorderStyle.Sizable ? FormBorderStyle.None : FormBorderStyle.Sizable;
        }

        //判断输入键值（实现KeyDown事件）
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)//ESC键，退出
            {
                DialogResult result = AutoClosedMsgBox.Show("是否要退出医患协同大屏？", "大屏提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }
    }
}