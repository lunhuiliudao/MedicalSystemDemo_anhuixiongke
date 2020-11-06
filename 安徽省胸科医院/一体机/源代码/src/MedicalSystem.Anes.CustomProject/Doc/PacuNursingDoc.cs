// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      PacuNursingDoc.cs
// 功能描述(Description)：    PACU护理记录单，无需再界面上展示，在麻醉单打印时直接打印出来
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2020/05/07 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// PACU护理记录单
    /// </summary>
    public partial class PacuNursingDoc : CustomBaseDoc
    {
        private int pageCount = 1;                              // 文书页数

        /// <summary>
        /// 无参构造
        /// </summary>
        public PacuNursingDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            bool result = this.SaveDocDataPars(dataSource);
            return result;
        }

        /// <summary>
        /// 重写页面设置，用于多页情况
        /// </summary>
        protected override void OnPagerSetting(PagerSetting pagerSetting)
        {
            if (_pageFromHeight)
            {
                pagerSetting.PagerDesc.Clear();
                pagerSetting.AllowPage = true;
                for (int i = 0; i < pageCount; i++)
                {
                    pagerSetting.PagerDesc.Add(new PageDesc(i, true));
                }
            }
        }

        /// <summary>
        /// 翻页刷新数据
        /// </summary>
        protected override void OnPageIndexChanged(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {
            base.OnPageIndexChanged(mainPageIndex, isMasterPage, dataSource);
            DateTimeRange dtRange = new DateTimeRange(DateTime.MinValue, DateTime.MinValue);
            base.SetCurrentPageData(dtRange, isMasterPage, 5);
        }

        /// <summary>
        /// 控件创建后,未被UIElementHandler处理前调用的方法
        /// </summary>
        protected override void OnControlInitalizing(Control control)
        {
            if (control is MLabel)
            {
                MLabel lable = control as MLabel;
                if (_pageFromHeight == false && lable.Name == "pageline")
                {
                    _pageFromHeight = true;
                    float h = (float)lable.Location.Y;
                    Control ctl = lable;
                    while (ctl.Parent is Panel)
                    {
                        h += ctl.Parent.Top;
                        ctl = ctl.Parent;
                    }

                    _pagePrintHeight = h;
                    pageCount = 2;
                }
            }
        }
    }
}
