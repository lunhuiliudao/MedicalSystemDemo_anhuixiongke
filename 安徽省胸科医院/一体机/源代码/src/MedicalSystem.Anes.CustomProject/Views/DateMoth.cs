// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DateMoth.cs
// 功能描述(Description)：    自定义日期控件
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 自定义日期控件
    /// </summary>
    public partial class DateMoth : UserControl
    {
        /// <summary>
        /// 当前选中的控件
        /// </summary>
        private System.Windows.Forms.Control currentCtr = null;      

        /// <summary>
        /// 当前年
        /// </summary>
        /// <value>The temporary year.</value>
        private int TempYear { get; set; }

        /// <summary>
        /// 当前年
        /// </summary>
        /// <value>The current year.</value>
        public int CurrentYear { get; set; }

        /// <summary>
        /// 当前月
        /// </summary>
        /// <value>The current moth.</value>
        public int CurrentMoth { get; set; }

        /// <summary>
        /// 返回开始日期
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate
        {
            get { return GetDate(true); }
        }

        /// <summary>
        /// 返回结束日期
        /// </summary>
        /// <value>The end date.</value>
        public DateTime EndDate
        {
            get { return GetDate(false); }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public DateMoth()
        {
            InitializeComponent();
            this.Width = 120;
            this.Height = 21;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="isStartTime">if set to <c>true</c> [is start time].</param>
        /// <returns>DateTime.</returns>
        private DateTime GetDate(bool isStartTime)
        {
            DateTime result = DateTime.MinValue;

            if (isStartTime)
                result = DateTime.Parse(CurrentYear.ToString() + "-" + CurrentMoth.ToString() + "-1");
            else
                result = DateTime.Parse(CurrentYear.ToString() + "-" + CurrentMoth.ToString() + "-1").AddMonths(1);
            return result;
        }

        /// <summary>
        /// 根据当前年月设置当前值
        /// </summary>
        private void SetCurrentValue()
        {
            popupContainerEdit.Text = CurrentYear.ToString() + "年" + CurrentMoth.ToString() + "月";
        }

        /// <summary>
        /// 初始化年分控件事件
        /// </summary>
        private void InitControlClick()
        {
            foreach (System.Windows.Forms.Control ctrl in panel.Controls)
            {
                if (ctrl.Name.Contains("labelM"))
                {
                    ctrl.Click += new EventHandler(ctrl_Click);
                    ctrl.MouseEnter += ctrl_MouseEnter;
                    ctrl.MouseLeave += ctrl_MouseLeave;
                }

                if (ctrl.Name == "labelM" + CurrentMoth.ToString().Trim())
                    SetCurrtntMonth(ctrl);
            }
        }

        /// <summary>
        /// 鼠标进入控件时转换背景色
        /// </summary>
        void ctrl_MouseLeave(object sender, EventArgs e)
        {
            ((LabelControl)sender).BorderStyle = BorderStyles.Default;
        }

        /// <summary>
        /// 鼠标离开控件时背景色恢复默认
        /// </summary>
        void ctrl_MouseEnter(object sender, EventArgs e)
        {
            ((LabelControl)sender).BorderStyle = BorderStyles.Office2003;
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DateMoth_Load(object sender, EventArgs e)
        {
            if (CurrentMoth <= 0)
            {   CurrentMoth = DateTime.Now.Month;
            }

            if (CurrentYear <= 0)
            {    CurrentYear = DateTime.Now.Year;
            }

            TempYear = CurrentYear;
            labelCurrentInfo.Text = TempYear.ToString() + "年";
            this.SetCurrentValue();
            this.InitControlClick();
        }

        /// <summary>
        /// 上一年事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void labelUp_Click(object sender, EventArgs e)
        {
            TempYear--;
            labelCurrentInfo.Text = TempYear.ToString() + "年";
        }

        /// <summary>
        /// 下一年事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void labeDown_Click(object sender, EventArgs e)
        {
            TempYear++;
            labelCurrentInfo.Text = TempYear.ToString() + "年";
        }

        /// <summary>
        /// 今年月事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void labelCurrentYear_Click(object sender, EventArgs e)
        {
            CurrentYear = DateTime.Now.Year;
            CurrentMoth = DateTime.Now.Month;
            TempYear = CurrentYear;
            labelCurrentInfo.Text = TempYear.ToString() + "年";
            SetCurrentValue();

            foreach (System.Windows.Forms.Control ctrl in panel.Controls)
            {
                if (ctrl.Name == "labelM" + CurrentMoth.ToString().Trim())
                {
                    this.SetCurrtntMonth(ctrl);
                    break;
                }
            }
        }

        /// <summary>
        /// 月份单击事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void ctrl_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctrl = sender as System.Windows.Forms.Control;
            CurrentYear = TempYear;
            CurrentMoth = int.Parse(ctrl.Name.Replace("labelM", ""));
            SetCurrentValue();
            SetCurrtntMonth(ctrl);
            popupContainerEdit.ClosePopup();
        }

        /// <summary>
        /// 设置当前选中控件的前景色和背景色
        /// </summary>
        /// <param name="ctr"></param>
        private void SetCurrtntMonth(System.Windows.Forms.Control ctr)
        {
            if (currentCtr != null)
            {
                currentCtr.ForeColor = Color.Black;
                currentCtr.BackColor = Color.White;
            }

            ctr.ForeColor = Color.White;
            ctr.BackColor = Color.FromArgb(100, 170, 250);
            currentCtr = ctr;
        }
    }
}
