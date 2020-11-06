// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      UserControl_BreathParas.cs
// 功能描述(Description)：    自定义控件：体征项呼吸数据的设置
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 自定义控件：体征项呼吸数据的设置
    /// </summary>
    public partial class UserControl_BreathParas : UserControl
    {
        private string _code1, _code2, _code3;
        private DateTime _timePoint;
        private List<string> _list;
        public bool delBreathParas = false;

        /// <summary>
        /// 结果列表
        /// </summary>
        public List<string> ResultList
        {
            get { return _list; }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public UserControl_BreathParas()
            : this(DateTime.Now, "", "", "") { }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="timePoint">时间节点</param>
        /// <param name="code1">呼吸编码1</param>
        /// <param name="code2">呼吸编码2</param>
        /// <param name="code3">呼吸编码3</param>
        public UserControl_BreathParas(DateTime timePoint, string code1, string code2, string code3)
            : this(timePoint, code1, code2, code3, "", "", "") { }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="timePoint">时间节点</param>
        /// <param name="code1">呼吸编码1</param>
        /// <param name="code2">呼吸编码2</param>
        /// <param name="code3">呼吸编码3</param>
        /// <param name="value1">呼吸编码1对应的结果值</param>
        /// <param name="value2">呼吸编码2对应的结果值</param>
        /// <param name="value3">呼吸编码3对应的结果值</param>
        public UserControl_BreathParas(DateTime timePoint, string code1, string code2, string code3, string value1, string value2, string value3)
        {
            _timePoint = timePoint;
            _code1 = code1;
            _code2 = code2;
            _code3 = code3;
            InitializeComponent();
            dateEdit1.EditValue = _timePoint;
            if (!string.IsNullOrEmpty(value1))
            {
                txtCode1.Text = value1;
            }
            if (!string.IsNullOrEmpty(value2))
            {
                txtCode2.Text = value2;
            }
            if (!string.IsNullOrEmpty(value3))
            {
                txtCode3.Text = value3;
            }
        }
      
        /// <summary>
        /// 根据Code转换成ItemName
        /// </summary>
        private string GetCode(string code)
        {
            string result = code;
            //if (ExtendAppContext.Current.CommDict.MonitorFuntionDict != null)
            if (ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList != null)
            {
                List<MED_MONITOR_FUNCTION_CODE> rows = ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList.Where(x => x.ITEM_CODE == code).ToList();
                if (rows != null && rows.Count > 0 && rows[0].ITEM_NAME != null)
                {
                    result = rows[0].ITEM_NAME;
                }
            }

            return result;
        }

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        private void UserControl_BreathParas_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (!string.IsNullOrEmpty(_code1))
                {
                    lblCode1.Text = GetCode(_code1);
                }
                if (!string.IsNullOrEmpty(_code2))
                {
                    lblCode2.Text = GetCode(_code2);
                }
                if (!string.IsNullOrEmpty(_code3))
                {
                    lblCode3.Text = GetCode(_code3);
                }
                if (ParentForm != null)
                {
                    ParentForm.AcceptButton = btnOK;
                    ParentForm.CancelButton = btnCancel;
                }

                btnOK.Enabled = false;
            }
        }

        /// <summary>
        /// 文本框值为不为空，保存按钮才可用
        /// </summary>
        private void txtCode1_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = !string.IsNullOrEmpty(txtCode1.Text) || !string.IsNullOrEmpty(txtCode2.Text) || !string.IsNullOrEmpty(txtCode3.Text);
        }

        /// <summary>
        /// 保存数据，呼吸编码对应的值
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            _list = new List<string>(new string[] { txtCode1.Text, txtCode2.Text, txtCode3.Text });
        }

        /// <summary>
        /// 删除当前呼吸数据
        /// </summary>
        private void BtnDele_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dateEdit1.Time.ToString()) && 
                !string.IsNullOrEmpty(txtCode1.Text) && 
                !string.IsNullOrEmpty(txtCode2.Text) && 
                !string.IsNullOrEmpty(txtCode3.Text))
            {
                delBreathParas = true;
            }
        }
    }
}
