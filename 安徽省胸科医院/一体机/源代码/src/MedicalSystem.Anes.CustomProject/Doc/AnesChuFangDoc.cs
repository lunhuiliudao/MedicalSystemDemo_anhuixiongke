// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnesChuFangDoc.cs
// 功能描述(Description)：    麻醉处方单对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 麻醉处方单
    /// </summary>
    public partial class AnesChuFangDoc : CustomBaseDoc
    {
        private MPanel xieLinePanel = null;                         // 斜线面板
        private int height = 0;                                     // 斜线面板高度

        /// <summary>
        /// 无参构造
        /// </summary>
        public AnesChuFangDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = false;
            base.SaveDataTemplate.Visible = false;
            base.printCurPage.Visible = true;
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            string patientId = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitId = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operId = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;

            List<MED_ANESTHESIA_EVENT> _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent("0");
            dataSource["AnesAllEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(_anesEvent);
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
            dataSource["MED_OPERATION_MASTER_EXT"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER_EXT");
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_INPUT_DATA"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_INPUT_DATA");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            int chuFangClass = this.Name.Equals("麻醉处方单") ? 1 : 2;
            dataSource["MED_CHUFANG_RECORD"] = DataContext.GetCurrent().GetMedChuFangRecordList(patientId, visitId, operId, chuFangClass);
            // 获得斜线面板
            if (null == this.xieLinePanel)
            {
                List<MPanel> panelList = this.GetControls<MPanel>();
                foreach (MPanel npb in panelList)
                {
                    if (null != npb.Tag && npb.Tag.ToString().Equals("斜线"))
                    {
                        this.xieLinePanel = npb;
                        this.xieLinePanel.CustomDraw += MPanel_CustomDraw;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 自定义绘制事件：绘制斜线
        /// </summary>
        private void MPanel_CustomDraw(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 1);
            p.DashStyle = DashStyle.Dash;
            Point startPoint = new Point(0, this.xieLinePanel.Height);
            Point endPoint = new Point(this.xieLinePanel.Width, 0);
            e.Graphics.DrawLine(p, startPoint, endPoint);
        }

        /// <summary>
        /// 打印前：判断药品文本框是否显示
        /// </summary>
        protected override bool CheckBeforePrint()
        {
            this.SetPanelVisible(false);
            return true;
        }

        /// <summary>
        /// 打印后：自动生成对应的编号，同时将之前隐藏的控件都显示出来
        /// </summary>
        protected override void OnAfterPrint()
        {
            this.SetPanelVisible(true);
        }

        /// <summary>
        /// 设置处方单用药信息面板是否显示
        /// </summary>
        private void SetPanelVisible(bool isVisible)
        {
            this.height = 0;
            List<MTextBox> tbList = this.GetControls<MTextBox>();
            foreach (MTextBox mtb in tbList)
            {
                if (null != mtb.Tag && mtb.Tag.ToString().Equals("处方药名称"))
                {
                    string strText = mtb.Text.Trim();
                    if (string.IsNullOrEmpty(strText))
                    {
                        if (mtb.Parent is MPanel)
                        {
                            mtb.Parent.Visible = isVisible;
                            if (!isVisible)
                            {
                                this.height += mtb.Parent.Height;
                            }
                        }
                    }
                }
            }

            if(null != this.xieLinePanel)
            {
                this.xieLinePanel.Visible = !isVisible;
                this.xieLinePanel.Height = isVisible ? 100 : this.xieLinePanel.Height + this.height;
            }
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            bool result = true;
            List<MED_CHUFANG_RECORD> chuFangList = new ModelHandler<MED_CHUFANG_RECORD>().FillModel(dataSource["MED_CHUFANG_RECORD"]);
            if(null != chuFangList && chuFangList.Count > 0)
            {
                result = CareDocService.ClientInstance.SaveMedChuFangRecordList(chuFangList);
            }

            return result;
        }
    }
}
