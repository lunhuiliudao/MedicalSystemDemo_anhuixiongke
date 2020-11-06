// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SDTextBoxHandler.cs
// 功能描述(Description)：    用于计算麻醉单上的出入量信息
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using System;
using System.Collections.Generic;
using System.Data;

namespace MedicalSystem.Anes.CustomProject
{
    public class SDTextBoxHandler : TextBoxHandler
    {
        private MTextBox txtZhongChuLiang = null;                              // 总出量
        private MTextBox txtShiXueLiang = null;                                // 失血量
        private MTextBox txtNiaoLiang = null;                                  // 尿量
        private MTextBox txtQiTaChuLiang = null;                               // 其他出量
        private MTextBox txtZhongRuLiang = null;                               // 总入量
        private MTextBox txtJiaoTi = null;                                     // 胶体
        private MTextBox txtJingTi = null;                                     // 晶体
        private MTextBox txtXuanFuHongXiBao = null;                            // 悬浮红细胞
        private MTextBox txtXueJiang = null;                                   // 血浆
        private MTextBox txtQiTaRuLiang = null;                                // 其他入量
        private MTextBox txtShuYeLiang = null;                                 // 输液总量

        /// <summary>
        /// 重写控件属性事件设置，绑定各个文本框的TextChanged和DoubleClick事件
        /// </summary>
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
                else if (control.SummaryName == "输液总量")
                {
                    txtShuYeLiang = control;
                    txtShuYeLiang.TextChanged += new EventHandler(controlIn_TextChanged);
                }
            }
        }

        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        public override void BindDataToUI(MTextBox control, Dictionary<string, DataTable> dataSources)
        {
            base.BindDataToUI(control, dataSources);
            if (!string.IsNullOrEmpty(control.SummaryName) && 
                control.SummaryName.Trim() != string.Empty && 
                string.IsNullOrEmpty(control.Text.Trim()))
            {
                DataContext.GetCurrent().CalTextValue(control, dataSources);
            }

            this.HasDirty = false;
        }

        /// <summary>
        /// 文本框双击事件：获取最新的数据显示到文本框
        /// </summary>
        void control_DoubleClick(object sender, EventArgs e)
        {
            MTextBox textbox = sender as MTextBox;
            DataContext.GetCurrent().CalTextValue(textbox, base.DataSource);
        }

        /// <summary>
        /// 文本框值更改事件：自动计算总出量
        /// </summary>
        void controlOut_TextChanged(object sender, EventArgs e)
        {
            callOutSum();
        }

        /// <summary>
        /// 文本框值更改事件：自动计算总入量
        /// </summary>
        void controlIn_TextChanged(object sender, EventArgs e)
        {
            callInSum();
        }

        /// <summary>
        /// 计算总出量
        /// </summary>
        public void callOutSum()
        {
            double out1 = 0, out2 = 0, out3 = 0;
            if (txtShiXueLiang != null && txtShiXueLiang.Text != null)
            {
                double.TryParse(txtShiXueLiang.Text, out out1);
            }
            if (txtNiaoLiang != null && txtNiaoLiang.Text != null)
            {
                double.TryParse(txtNiaoLiang.Text, out out2);
            }
            if (txtQiTaChuLiang != null && txtQiTaChuLiang.Text != null)
            {
                double.TryParse(txtQiTaChuLiang.Text, out out3);
            }
            if (txtZhongChuLiang != null)
            {
                txtZhongChuLiang.Text = (out1 + out2 + out3).ToString();
            }
        }

        /// <summary>
        /// 计算总入量
        /// </summary>
        public void callInSum()
        {
            double out1 = 0, out2 = 0, out3 = 0, out4 = 0, out5 = 0;
            if (txtJiaoTi != null && txtJiaoTi.Text != null)
            {
                double.TryParse(txtJiaoTi.Text, out out1);
            }
            if (txtJingTi != null && txtJingTi.Text != null)
            {
                double.TryParse(txtJingTi.Text, out out2);
            }
            if (txtXuanFuHongXiBao != null && txtXuanFuHongXiBao.Text != null)
            {
                double.TryParse(txtXuanFuHongXiBao.Text, out out3);
            }
            if (txtXueJiang != null && txtXueJiang.Text != null)
            {
                double.TryParse(txtXueJiang.Text, out out4);
            }
            if (txtQiTaRuLiang != null && txtQiTaRuLiang.Text != null)
            {
                double.TryParse(txtQiTaRuLiang.Text, out out5);
            }
            if (txtZhongRuLiang != null)
            {
                txtZhongRuLiang.Text = (out1 + out2 + out3 + out4 + out5).ToString();
            }
        }
    }
}
