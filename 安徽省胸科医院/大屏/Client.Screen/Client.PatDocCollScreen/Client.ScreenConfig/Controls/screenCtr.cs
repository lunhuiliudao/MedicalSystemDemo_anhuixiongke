using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalSystem.MedScreen.Common;
using MedicalSystem.MedScreen.Controls;
using MedicalSystem.AnesIcuQuery.Models.Tables;
using MedicalSystem.AnesIcuQuery.Common;

namespace MedicalSystem.MedScreen.Client.ScreenConfig
{
    public partial class screenCtr : UserControl
    {
        public screenCtr()
        {
            InitializeComponent();
        }

        public screenCtr(DataRow dr)
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.MouseDoubleClick += screenCtr_MouseDoubleClick;
            }
            curntScreenRow = dr;
        }

        #region 变量
        /// <summary>
        /// 当前大屏控件的数据源行
        /// </summary>
        private DataRow curntScreenRow = null;

        private bool _isSelected = false;
        /// <summary>
        /// 设置是否选中
        /// </summary>
        public bool IsSelected
        {
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    Control ParentControl = this.Parent;
                    SetControlColorBackImg(this, Color.WhiteSmoke, null);
                    foreach (Control Control1 in Parent.Controls)
                    {
                        if (Control1 != this)
                        {
                            SetControlColorBackImg(Control1, Color.Black, null);
                        }
                    }
                    if (ScreenSelected != null)
                    {
                        ScreenSelected(this, EventArgs.Empty);
                    }
                    
                }
                else
                {
                    SetControlColorBackImg(this, Color.Black, null);
                }
            }
            get
            {
                return _isSelected;
            }
        }

        public ScreenDictDT selectedScreen = null;

        /// <summary>
        /// 是否可选中
        /// </summary>
        public bool canSelect = false;

        #endregion

        #region 组件事件

        public event EventHandler ScreenSelecting;
        /// <summary>
        /// 大屏组件被选中后触发
        /// </summary>
        public event EventHandler ScreenSelected;
        
        #endregion

        #region 自定义函数
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitialData()
        {
            if (curntScreenRow != null)
            {
                selectedScreen = new ScreenDictDT();
                selectedScreen.SCREEN_NO = curntScreenRow["SCREEN_NO"].ToString();
                selectedScreen.SCREEN_TYPE = curntScreenRow["SCREEN_TYPE"].ToString();
                selectedScreen.SCREEN_LABEL = curntScreenRow["SCREEN_LABEL"].ToString();
                selectedScreen.FULL_SCREEN = decimal.Parse(curntScreenRow["FULL_SCREEN"].ToString());
                selectedScreen.SCREEN_WIDTH = decimal.Parse(curntScreenRow["SCREEN_WIDTH"].ToString());
                selectedScreen.SCREEN_HEIGHT = decimal.Parse(curntScreenRow["SCREEN_HEIGHT"].ToString());

                lblScreenNum.Text = "编号:" + curntScreenRow["SCREEN_NO"].ToString();
                lblScreenLabel.Text = curntScreenRow["SCREEN_LABEL"].ToString();
                lblScreenType.Text = curntScreenRow["SCREEN_TYPE"].ToString();
                bool isFullScreen =  CommHelper.GetBoolean(curntScreenRow["FULL_SCREEN"].ToString());
                if (isFullScreen)
                    lblSize.Text = "全屏";
                else
                {
                    string width = curntScreenRow["SCREEN_WIDTH"].ToString();
                    string height = curntScreenRow["SCREEN_HEIGHT"].ToString();
                    lblSize.Text = width + "×" + height;
                }
            }
        }

        /// <summary>
        /// 设置背景颜色
        /// </summary>
        /// <param name="control"></param>
        /// <param name="color"></param>
        /// <param name="backImg"></param>
        private void SetControlColorBackImg(Control control, Color color, Image backImg)
        {
            foreach (Control Control1 in control.Controls)
            {
                if (Control1 is Label)
                    Control1.ForeColor = color;
            }
            control.BackgroundImage = backImg;
        }
        #endregion

        #region 窗体事件
        private void screenCtr_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                InitialData();
            }
        }

        /// <summary>
        /// 双击选中组件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void screenCtr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ScreenSelecting != null)
            {
                ScreenSelecting(this, EventArgs.Empty);
                if (!canSelect)
                {
                    AutoClosedMsgBox.Show("正在编辑其他大屏,请点击【保存】按钮保存，或【取消】对该大屏的编辑。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.IsSelected = true;
        }
        #endregion

       

       
    }
}
