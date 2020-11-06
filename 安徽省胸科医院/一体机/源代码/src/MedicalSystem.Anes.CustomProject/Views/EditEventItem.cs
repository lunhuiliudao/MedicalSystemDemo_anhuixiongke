// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      EditEventItem.cs
// 功能描述(Description)：    单个事件项编辑窗口
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 单个事件项编辑窗口
    /// </summary>
    public partial class EditEventItem : BaseView
    {
        /// <summary>
        /// 事件类型枚举
        /// </summary>
        public enum ItemTypes
        {
            EventItem,
            MedicineItem,
            OtherItem,
        }

        protected ItemTypes _itemType;                        // 类型
        protected MED_ANESTHESIA_EVENT _dataRow;              // 数据

        /// <summary>
        /// 标题颜色
        /// </summary>
        public Color TitleColor
        {
            get { return labelName.ForeColor; }
            set { labelName.ForeColor = value; }
        }

        /// <summary>
        /// 当前事件的类型
        /// </summary>
        public ItemTypes ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        /// <summary>
        /// 当前处于编辑的事件数据源
        /// </summary>
        public MED_ANESTHESIA_EVENT DataSource
        {
            get { return _dataRow; }
            set { _dataRow = value; }
        }

        /// <summary>
        /// 是否删除当前事件
        /// </summary>
        public bool IsDelete
        {
            get { return chkDelete.Checked;  }
            set { chkDelete.Checked = value; }
        }

        /// <summary>
        /// 删除复选框 是否显示
        /// </summary>
        public bool IsAllowDel
        {
            get { return chkDelete.Visible; }
            set { chkDelete.Visible = value; }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public EditEventItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        private void EditEventItem_Load(object sender, EventArgs e)
        {
            labelName.Text = _dataRow.EVENT_ITEM_NAME;
            chkDelete.Text = "删除";
            timeEditStart.Time = _dataRow.START_TIME.Value;
            if (!_dataRow.END_TIME.HasValue)
            {
                timeEditEnd.Time = DateTime.Now;
                timeEditEnd.Enabled = false;
                checkEndDate.Checked = false;
            }
            else
            {
                timeEditEnd.Time = _dataRow.END_TIME.Value;
                timeEditEnd.Enabled = true;
                checkEndDate.Checked = true;
            }

            if (_itemType == ItemTypes.EventItem)
            {
                if (_dataRow.EVENT_ITEM_NAME.ToString().EndsWith("呼吸"))
                {
                    panelMid.Height = 65;
                    foreach (Control ctl in panelMid.Controls)
                    {
                        ctl.Visible = false;
                    }
                    chkContinued.Text = "持续";
                    labelDosage.Text = "频率";
                    labelDosage.Location = new Point(16, 39);
                    txtDosage.Location = new Point(56, 38);
                    chkContinued.Visible = true;
                    labelDosage.Visible = true;
                    txtDosage.Visible = true;
                }
                else
                {
                    panelMid.Visible = false;
                    return;
                }
            }

            if (_dataRow.DURATIVE_INDICATOR.HasValue)
                chkContinued.Checked = _dataRow.DURATIVE_INDICATOR == 1 ? true : false;

            if (!string.IsNullOrEmpty(_dataRow.ADMINISTRATOR))
                txtPath.Text = _dataRow.ADMINISTRATOR;

            if (_dataRow.CONCENTRATION.HasValue)
                txtDensity.Text = _dataRow.CONCENTRATION.ToString();

            if (!string.IsNullOrEmpty(_dataRow.CONCENTRATION_UNIT))
                txtPathUnit.Text = _dataRow.CONCENTRATION_UNIT.ToString();

            if (_dataRow.PERFORM_SPEED.HasValue)
                txtSpeed.Text = _dataRow.PERFORM_SPEED.ToString();

            if (!string.IsNullOrEmpty(_dataRow.SPEED_UNIT))
                txtSpeedUnit.Text = _dataRow.SPEED_UNIT.ToString();

            if (_dataRow.DOSAGE.HasValue)
                txtDosage.Text = _dataRow.DOSAGE.ToString();

            if (!string.IsNullOrEmpty(_dataRow.DOSAGE_UNITS))
                txtDosageUnit.Text = _dataRow.DOSAGE_UNITS.ToString();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            _dataRow.START_TIME = timeEditStart.Time;
            if (!checkEndDate.Checked)
                _dataRow.END_TIME = null;
            else
                _dataRow.END_TIME = timeEditEnd.Time;

            if (chkContinued.Checked)
                _dataRow.DURATIVE_INDICATOR = 1;
            else if (!_dataRow.DURATIVE_INDICATOR.HasValue)
                _dataRow.DURATIVE_INDICATOR = 0;

            if (txtPath.Text.Trim() == "")
                _dataRow.ADMINISTRATOR = null;
            else
                _dataRow.ADMINISTRATOR = txtPath.Text.Trim();

            if (txtDensity.Text.Trim() == "")
                _dataRow.CONCENTRATION = null;
            else
                _dataRow.CONCENTRATION = Convert.ToDecimal(txtDensity.Text);

            if (txtPathUnit.Text.Trim() == "")
                _dataRow.CONCENTRATION_UNIT = null;
            else
                _dataRow.CONCENTRATION_UNIT = txtPathUnit.Text.Trim();

            if (txtSpeed.Text.Trim() == "")
                _dataRow.PERFORM_SPEED = null;
            else
                _dataRow.PERFORM_SPEED = Convert.ToDecimal(txtSpeed.Text);

            if (txtSpeedUnit.Text.Trim() == "")
                _dataRow.SPEED_UNIT = null;
            else
                _dataRow.SPEED_UNIT = txtSpeedUnit.Text.Trim();

            if (txtDosage.Text.Trim() == "")
                _dataRow.DOSAGE = null;
            else
                _dataRow.DOSAGE = Convert.ToDecimal(txtDosage.Text);

            if (txtDosageUnit.Text.Trim() == "")
                _dataRow.DOSAGE_UNITS = null;
            else
                _dataRow.DOSAGE_UNITS = txtDosageUnit.Text.Trim();

            ParentForm.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 开始时间控件双击，获取当前时间
        /// </summary>
        private void timeEditStart_Properties_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.X < 150)
            {
                timeEditStart.Time = DateTime.Now;
            }
        }

        /// <summary>
        /// 结束时间控件双击，获取当前时间
        /// </summary>
        private void timeEditEnd_Properties_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.X < 150)
            {
                timeEditEnd.Time = DateTime.Now;
            }
        }
        
        /// <summary>
        /// 勾选结束时间,对应的结束时间控件才显示
        /// </summary>
        private void checkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEndDate.Checked)
            {
                timeEditEnd.Enabled = true;
            }
            else
            {
                timeEditEnd.Enabled = false;
            }
        }
    }
}
