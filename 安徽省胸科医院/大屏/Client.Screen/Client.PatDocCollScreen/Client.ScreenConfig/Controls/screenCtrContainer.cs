using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Client.ScreenConfig
{
    public partial class screenCtrContainer : UserControl
    {
        public screenCtrContainer()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 大屏字典表
        /// </summary>
        private DataTable _screenDictDT;
        public DataTable ScreenDictDT
        {
            get
            {
                return _screenDictDT;
            }
            set
            {
                _screenDictDT = value;
            }
        }

        /// <summary>
        /// 选中的大屏控件
        /// </summary>
        private screenCtr selectedScreen = null;
        public screenCtr SelectedScreen
        {
            get
            {
                return selectedScreen;
            }
            set
            {
                selectedScreen = null;
            }
        }
        /// <summary>
        /// 大屏控件列表
        /// </summary>
        private List<screenCtr> screenCtrList = new List<screenCtr>();

        #endregion

        #region 自定义函数
        
        private void InitialScreenCtrs()
        {
            //先清空
            flowLayoutPanel1.Controls.Clear();
            //逐个增加大屏控件
            if (ScreenDictDT != null && ScreenDictDT.Rows.Count > 0)
            {
                screenCtrList = new List<screenCtr>();
                foreach (DataRow dr in ScreenDictDT.Rows)
                {
                    screenCtr ctr = new screenCtr(dr);
                    ctr.Padding = new System.Windows.Forms.Padding(2);
                    ctr.Margin = new System.Windows.Forms.Padding(40,10,20,10);
                    ctr.ScreenSelecting += ScreenSelecting;
                    ctr.ScreenSelected += ScreenSelected;

                    flowLayoutPanel1.Controls.Add(ctr);
                    ctr.IsSelected = false;
                    screenCtrList.Add(ctr);
                }
                //screenCtrList[0].IsSelected = true;
            }
        }

        public void ClearSelectScreen()
        {
            foreach (screenCtr ctr in screenCtrList)
            {
                ctr.IsSelected = false;
            }
        }

        public void RefreshControls()
        {
            InitialScreenCtrs();
        }

        
        #endregion

        #region 组件事件

        /// <summary>
        /// 选中大屏组件更改后触发
        /// </summary>
        public event EventHandler ScreenSelectChanged;

        public event EventHandler ScreenSelectChanging;

        #endregion

        #region 事件

        private void screenCtrContainer_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                InitialScreenCtrs();
            }
        }

        private void ScreenSelecting(object sender, EventArgs e)
        {
            screenCtr selectingScreen = sender as screenCtr;
            selectingScreen.canSelect = selectedScreen == null;
        }

        /// <summary>
        /// 选中当前大屏控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenSelected(object sender, EventArgs e)
        {
            if (sender is screenCtr)
            {
                selectedScreen = sender as screenCtr;
                if (ScreenSelectChanged != null)
                {
                    ScreenSelectChanged(sender, e);
                }
            }
        }


        #endregion
    }
}
