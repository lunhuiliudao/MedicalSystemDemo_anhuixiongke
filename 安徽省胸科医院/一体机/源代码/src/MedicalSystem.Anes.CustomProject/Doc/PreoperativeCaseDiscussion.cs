// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      PreoperativeCaseDiscussion.cs
// 功能描述(Description)：    术前病例讨论的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/06/27 15:39
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    public partial class PreoperativeCaseDiscussion : CustomBaseDoc
    {
        private int pageCount = 1;                              // 文书页数
        public PreoperativeCaseDiscussion()
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
            dataSource["MED_PREOPERATIVE_EXPANSION"] = DataContext.GetCurrent().GetData("MED_PREOPERATIVE_EXPANSION");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            //
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
            dataSource["MED_BJCA_SIGN"] = DataContext.GetCurrent().GetData("MED_BJCA_SIGN");
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
