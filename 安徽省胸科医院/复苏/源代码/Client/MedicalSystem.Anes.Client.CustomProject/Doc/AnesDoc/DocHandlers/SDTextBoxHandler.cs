using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class SDTextBoxHandler : TextBoxHandler
    {
        private MTextBox txtZhongChuLiang = null;
        private MTextBox txtShiXueLiang = null;
        private MTextBox txtNiaoLiang = null;
        private MTextBox txtQiTaChuLiang = null;

        private MTextBox txtZhongRuLiang = null;
        private MTextBox txtJiaoTi = null;
        private MTextBox txtJingTi = null;
        private MTextBox txtXuanFuHongXiBao = null;
        private MTextBox txtXueJiang = null;
        private MTextBox txtQiTaRuLiang = null;

        /// <summary>
        /// 控件属性事件设置
        /// </summary>
        /// <param name="element"></param>
        public override void ControlSetting(MTextBox control)
        {
            base.ControlSetting(control);
            if (!string.IsNullOrEmpty(control.SummaryName) && control.SummaryName.Trim() != string.Empty)
            {
                control.DoubleClick += new EventHandler(control_DoubleClick);
                if (control.SummaryName == "总出量")
                {
                    txtZhongChuLiang = control;
                }
                else if (control.SummaryName == "失血量")
                {
                    txtShiXueLiang = control;
                    txtShiXueLiang.TextChanged += new EventHandler(controlOut_TextChanged);
                }
                else if (control.SummaryName == "尿量")
                {
                    txtNiaoLiang = control;
                    txtNiaoLiang.TextChanged += new EventHandler(controlOut_TextChanged);
                }
                else if (control.SummaryName == "其它出量")
                {
                    txtQiTaChuLiang = control;
                    txtQiTaChuLiang.TextChanged += new EventHandler(controlOut_TextChanged);
                }
                else if (control.SummaryName == "总入量")
                {
                    txtZhongRuLiang = control;
                }
                else if (control.SummaryName == "胶体")
                {
                    txtJiaoTi = control;
                    txtJiaoTi.TextChanged += new EventHandler(controlIn_TextChanged);
                }
                else if (control.SummaryName == "晶体")
                {
                    txtJingTi = control;
                    txtJingTi.TextChanged += new EventHandler(controlIn_TextChanged);
                }
                else if (control.SummaryName == "红细胞")
                {
                    txtXuanFuHongXiBao = control;
                    txtXuanFuHongXiBao.TextChanged += new EventHandler(controlIn_TextChanged);
                }
                else if (control.SummaryName == "血浆")
                {
                    txtXueJiang = control;
                    txtXueJiang.TextChanged += new EventHandler(controlIn_TextChanged);
                }
                else if (control.SummaryName == "其它入量")
                {
                    txtQiTaRuLiang = control;
                    txtQiTaRuLiang.TextChanged += new EventHandler(controlIn_TextChanged);
                }
            }
        }

        //<summary>
        //绑定数据源数据到控件
        //</summary>
        //<param name="control"></param>
        //<param name="dataSources"></param>
        public override void BindDataToUI(MTextBox control, Dictionary<string, DataTable> dataSources)
        {
            base.BindDataToUI(control, dataSources);
            //if (!string.IsNullOrEmpty(control.SummaryName) && control.SummaryName.Trim() != string.Empty && string.IsNullOrEmpty(control.Text.Trim()))
            if (!string.IsNullOrEmpty(control.SummaryName) &&
              control.SummaryName.Trim() != string.Empty)// TextBox有值也要重新计算
            {
                //DataContext.GetCurrent().CalTextValue(control, dataSources);
                if (DataContext.GetCurrent().CalTextValue(control, dataSources))
                {
                    this.IsAutoInOutDirty = true;// 存在自动计算出入量
                }
            }
            //this.HasDirty = false;
        }

        void control_DoubleClick(object sender, EventArgs e)
        {
            MTextBox textbox = sender as MTextBox;
            DataContext.GetCurrent().CalTextValue(textbox, base.DataSource);
        }

        void controlOut_TextChanged(object sender, EventArgs e)
        {
            callOutSum();
        }

        void controlIn_TextChanged(object sender, EventArgs e)
        {
            callInSum();
        }

        public void callOutSum()
        {
            double out1 = 0, out2 = 0, out3 = 0;
            if (txtShiXueLiang != null && txtShiXueLiang.Text != null)
                double.TryParse(txtShiXueLiang.Text, out out1);
            if (txtNiaoLiang != null && txtNiaoLiang.Text != null)
                double.TryParse(txtNiaoLiang.Text, out out2);
            if (txtQiTaChuLiang != null && txtQiTaChuLiang.Text != null)
                double.TryParse(txtQiTaChuLiang.Text, out out3);
            if (txtZhongChuLiang != null)
                txtZhongChuLiang.Text = (out1 + out2 + out3).ToString();
        }
        public void callInSum()
        {
            double out1 = 0, out2 = 0, out3 = 0, out4 = 0, out5 = 0;
            if (txtJiaoTi != null && txtJiaoTi.Text != null)
                double.TryParse(txtJiaoTi.Text, out out1);

            if (txtJingTi != null && txtJingTi.Text != null)
                double.TryParse(txtJingTi.Text, out out2);

            if (txtXuanFuHongXiBao != null && txtXuanFuHongXiBao.Text != null)
                double.TryParse(txtXuanFuHongXiBao.Text, out out3);

            if (txtXueJiang != null && txtXueJiang.Text != null)
                double.TryParse(txtXueJiang.Text, out out4);

            if (txtQiTaRuLiang != null && txtQiTaRuLiang.Text != null)
                double.TryParse(txtQiTaRuLiang.Text, out out5);
            if (txtZhongRuLiang != null)
                txtZhongRuLiang.Text = (out1 + out2 + out3 + out4 + out5).ToString();
        }
    }
}
