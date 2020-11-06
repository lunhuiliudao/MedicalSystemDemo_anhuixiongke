using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using MedicalSystem.Anes.Document;
using MedicalSystem.AnesWorkStation.Domain;
using System.Drawing;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Custom.CustomProject;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.AnesWorkStation.DataServices;
using System.Linq;
using MedicalSystem.Anes.Document.Configurations;
using System.IO;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 麻醉单实现代码
    /// </summary>
    public partial class AnesDoc : CustomBaseDoc
    {
        /// <summary>
        /// 事件类型：0-麻醉 1-复苏
        /// </summary>
        private string _eventNo = "0";
        /// <summary>
        /// 麻醉单开始时间和结束时间
        /// </summary>
        private DateTimeRange _dateTimeRange = null;
        List<MED_ANESTHESIA_EVENT> _anesEvent = new List<MED_ANESTHESIA_EVENT>();
        List<MED_VITAL_SIGN> _vitalSign = new List<MED_VITAL_SIGN>();
        public AnesDoc()
        {
            InitializeComponent();
            base.Caption = "麻醉单";
            this.BackColor = Color.White;
            base.DocKind = DocKind.Anes;
            ExtendAppContext.Current.EventNo = "0";
            _pageHours = ApplicationConfiguration.AnesDocPageHours;
        }

        /// <summary>
        /// 初始化自定义的UIElementHandler
        /// </summary>
        /// <param name="handlers"></param>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            IUIElementHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is LabelHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }
            handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is TextBoxHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }
            handlers.Add(new SDLabelHandler());
            handlers.Add(new SDTextBoxHandler());
            handlers.Add(new DrugGraphHandler());
            handlers.Add(new GridGraphHandler());
            handlers.Add(new AnesSheetDetailsHandler());
            handlers.Add(new VitalSignGraphHandler());
            handlers.Add(new LegengGraphHandler());
            handlers.Add(new SDPanelHandler());
            handlers.Add(new SHATMedSheetHandler(0));
            if (ReportViewer != null)
            {
                ReportViewer.Paint -= new PaintEventHandler(ReportViewer_Paint);
                ReportViewer.Paint += new PaintEventHandler(ReportViewer_Paint);
            }
        }

        private void ReportViewer_Paint(object sender, PaintEventArgs e)
        {
            CustomDraw(e.Graphics, 0, 0);
        }

        private void CustomDraw(Graphics g, float x, float y)
        {
            //Font font = new Font("宋体", 9);
            //Brush brush = Brushes.Black;
            //float left = 879;
            //float top = 1000;
            //float scale = 13.5f;
            //float top1 = 26.4f;
            //float ySpan = 14;
            //g.DrawString("10", font, brush, x + left, y + top);
            //g.DrawString("12", font, brush, x + left, y + top - top1);
            //for (int i = 16; i < 41; i += 2)
            //{
            //    g.DrawString(i.ToString(), font, brush, x + left, y + top - top1 - (i - ySpan) * scale);
            //}
            //g.DrawString("℃", font, brush, x + left, y + top - top1 - (42 - ySpan) * scale);
            //font.Dispose();
        }

        public override void CustomDraw(Graphics g)
        {
            CustomDraw(g, 0, -13);
        }

        /// <summary>
        /// 生成数据源
        /// </summary>
        /// <param name="dataSource"></param>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource.Clear();
            var operationMaster = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
            List<MED_OPERATION_MASTER> operMasterList = new ModelHandler<MED_OPERATION_MASTER>().FillModel(operationMaster);
            MED_OPERATION_MASTER operMater = null;
            if (operMasterList != null && operMasterList.Count > 0)
                operMater = operMasterList[0];
            _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            _vitalSign = DataContext.GetCurrent().GetVitalSignData(_eventNo);
            dataSource["MED_OPERATION_MASTER"] = operationMaster;
            dataSource["MED_OPERATION_MASTER_EXT"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER_EXT");
            dataSource["MED_PAT_MONITOR_DATA_EXT"] = DataContext.GetCurrent().GetData("MED_PAT_MONITOR_DATA_EXT");
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");
            dataSource["AnesAllEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(_anesEvent);
            dataSource["MED_ANESTHESIA_INPUT_DATA"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_INPUT_DATA");
            
            //获取起始时间和结束时间
            _dateTimeRange = base.GetGraphDateTime(_vitalSign, _anesEvent, _eventNo, operMater);
            _dateTimeRange.OrigiStartDateTime = _dateTimeRange.StartDateTime;
            _dateTimeRange.OrigiEndDateTime = _dateTimeRange.EndDateTime;
            base.AdjustDateTimeRange(TimeScaleType.FiveMinute, ref _dateTimeRange);

            if (ExtendAppContext.Current.IsRescueMode)
            {
                // labelRescue.Text = "取消抢救";
            }
            else
            {
                //  labelRescue.Text = "抢救模式";
            }
            if (!ExtendAppContext.Current.IsRescueMode)
            {
                _pageHours = ApplicationConfiguration.AnesDocPageHours;

            }
            else    //急救模式
            {
                _pageHours = 1;

            }
            if (_dateTimeRange.EndDateTime < _dateTimeRange.StartDateTime.AddHours(_pageHours))
            {
                _dateTimeRange.EndDateTime = _dateTimeRange.StartDateTime.AddHours(_pageHours);
            }
        }
        /// <summary>
        /// 分页设置
        /// </summary>
        /// <param name="pagerSetting"></param>
        protected override void OnPagerSetting(PagerSetting pagerSetting)
        {
            pagerSetting.PagerDesc.Clear();
            pagerSetting.AllowPage = true;
            double hour = ((TimeSpan)(_dateTimeRange.EndDateTime - _dateTimeRange.StartDateTime)).TotalHours;
            int pageCount = (int)(hour / _pageHours);

            if (pageCount * _pageHours < hour)
            {
                pageCount++;
            }

            for (int i = 0; i < pageCount; i++)
            {
                pagerSetting.PagerDesc.Add(new PageDesc(i, true));
                //计算当前页是否含有附页
                if (HasAttachPage(i))
                {
                    pagerSetting.PagerDesc.Add(new PageDesc(i, false));
                }
            }
            if (ExtendAppContext.Current.IsRescueMode)
            {
                pagerSetting.CurrentPageIndex = pagerSetting.TotalPageCount - 1;
            }
            //设置成第一页
            // pagerSetting.CurrentPageIndex = 0;
        }

        /// <summary>
        /// 分页导航事件
        /// </summary>
        /// <param name="currentPageIndex">当前页码</param>
        /// <param name="isMasterPage">是否为主页</param>
        /// <param name="dataSource">数据源</param>
        protected override void OnPageIndexChanged(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {
            //根据页码获取本页的时间范围
            DateTimeRange dtRange = GetPageDateTimeRange(mainPageIndex);
            //根据时间范围设置一页的数据
            dataSource["AnesthesiaEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(GetPageAnesEventDataByTimeSpan(dtRange));
            dataSource["VitalSignData"] = new ModelHandler<MED_VITAL_SIGN>().FillDataTable(GetPageVitalSignDataByTimeSpan(dtRange));
            base.SetCurrentPageData(dtRange, isMasterPage, _pageHours);

        }

        // <summary>
        // 文书上传前检查
        // </summary>
        // <returns></returns>
        protected override bool CheckBeforeCommit()
        {
            //if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ExtendAppContext.CurntSelect.AppType != ApplicationType.PACU)
            //{
            //    MessageBoxFormPC.Show("您没有上传该文书的权限！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            //AnesInformations.AnesthesiaEventDataTable anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            //foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
            //{
            //    PointType pointType = (GetDecimalValue(row["DURATIVE_INDICATOR"]) == 1 ? PointType.ProLonged : PointType.SinglePoint);
            //    if (pointType == PointType.ProLonged)
            //    {
            //        if (row["START_TIME"] != System.DBNull.Value)
            //        {
            //            if (row["END_DATE"] == System.DBNull.Value)
            //            {
            //                Dialog.MessageBox("持续性 【" + row["ITEM_NAME"].ToString() + "】 已有开始时间，但是还没有结束时间，请确认文书完成后再上传 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return false;
            //            }
            //        }
            //    }
            //}
            //OperationStatus operStatus = ExtendAppContext.Current.OperationStatus;
            //if (operStatus != OperationStatus.OutOperationRoom && operStatus != OperationStatus.TurnToPACU && operStatus != OperationStatus.TurnToSickRoom
            //     && operStatus != OperationStatus.InPACU && operStatus != OperationStatus.OutPACU && operStatus != OperationStatus.Done)
            //{

            //    MessageBoxFormPC.Show("只有 【出手术室】后才能上传麻醉单 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            return base.CheckBeforePrint();
        }

        /// <summary>
        ///打印前检查，判断是否可以打印
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforePrint()
        {
            //if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ExtendAppContext.CurntSelect.AppType != ApplicationType.PACU)
            //{
            //    MessageBoxFormPC.Show("您没有上传该文书的权限！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            return base.CheckBeforePrint();
            // return true;
        }

        /// <summary>
        /// 自定义刷新数据
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="isMasterPage"></param>
        /// <param name="dataSource"></param>
        protected override void OnCustomRefresh(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {
            //根据页码获取本页的时间范围
            DateTimeRange dtRange = GetPageDateTimeRange(mainPageIndex);

            //根据时间范围设置一页的数据
            dataSource["AnesthesiaEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(GetPageAnesEventDataByTimeSpan(dtRange, true));
            dataSource["VitalSignData"] = new ModelHandler<MED_VITAL_SIGN>().FillDataTable(GetPageVitalSignDataByTimeSpan(dtRange, true));

            base.RefreshCurrentControls(dtRange, new Type[] { typeof(MedAnesSheetDetails), typeof(MedDrugGraph), typeof(MedVitalSignGraph), typeof(MedLegengGraph) }, isMasterPage, _pageHours);
        }
        /// <summary>
        /// 自定义刷新数据时候触发事件
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="isMasterPage"></param>
        /// <param name="dataSource"></param>
        protected override void OnAfterRefreshData()
        {
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                //if (handler is SDTextBoxHandler)
                //{
                //    ((SDTextBoxHandler)handler).CalSumLiquidAndBlood();

                //    handler.HasDirty = false;

                //}
            }
        }
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="dataSource"></param>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            bool result = base.OnSaveData(dataSource);
            result = this.SaveDocDataPars(dataSource);
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    MedVitalSignGraph vitalSign = handler.GetCurrentControl as MedVitalSignGraph;
                    if (vitalSign.NewMonitorData != null)
                        vitalSign.NewMonitorData.Save();
                }
            }

            return result;
        }
        /// <summary>
        /// 根据时间范围获取一页的体征数据
        /// </summary>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private List<MED_VITAL_SIGN> GetPageVitalSignDataByTimeSpan(DateTimeRange dtRange)
        {
            return GetPageVitalSignDataByTimeSpan(dtRange, false);
        }
        /// <summary>
        /// 根据时间范围获取一页的体征数据
        /// </summary>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private List<MED_VITAL_SIGN> GetPageVitalSignDataByTimeSpan(DateTimeRange dtRange, bool isRefresh)
        {
            List<MED_VITAL_SIGN> dtVitalSignClone = new List<MED_VITAL_SIGN>();

            if (isRefresh)
            {
                _vitalSign = DataContext.GetCurrent().GetVitalSignData(_eventNo);
            }
            if (_vitalSign != null)
                _vitalSign.ForEach(row =>
                    {
                        if (row.TIME_POINT >= dtRange.StartDateTime && row.TIME_POINT <= dtRange.EndDateTime)
                        {
                            dtVitalSignClone.Add(row);
                        }
                    });
            return dtVitalSignClone;
        }
        /// <summary>
        /// 根据时间范围获取一页的麻醉事件数据
        /// </summary>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private List<MED_ANESTHESIA_EVENT> GetPageAnesEventDataByTimeSpan(DateTimeRange dtRange)
        {
            return GetPageAnesEventDataByTimeSpan(dtRange, false);
        }
        /// <summary>
        /// 根据时间范围获取一页的麻醉事件数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="dtRange"></param>
        /// <returns></returns>
        private List<MED_ANESTHESIA_EVENT> GetPageAnesEventDataByTimeSpan(DateTimeRange dtRange, bool isRefresh)
        {
            //只显示当页
            //AnesInformations.AnesthesiaEventDataTable dtAnesthesiaEventClone = (AnesInformations.AnesthesiaEventDataTable)_anesEvent.Clone();
            List<MED_ANESTHESIA_EVENT> dtAnesthesiaEventClone = new List<MED_ANESTHESIA_EVENT>();
            if (isRefresh)
            {
                _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
                base.DataSource["AnesAllEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(_anesEvent);
            }
            if (_anesEvent != null)
                _anesEvent.ForEach(row =>
                    {
                        //有起始时间，如没有，则不显示
                        if (row.START_TIME.HasValue)
                        {
                            //如果起始时间《 控件 上起始时间
                            if (row.START_TIME < dtRange.StartDateTime)
                            {
                                //没有结束时间
                                if (!row.END_TIME.HasValue)
                                {
                                    if (row.DURATIVE_INDICATOR.HasValue && (row.DURATIVE_INDICATOR == 1))
                                    {
                                        dtAnesthesiaEventClone.Add(row);
                                        return;
                                    }

                                    if (!string.IsNullOrEmpty(row.EVENT_ITEM_NAME) && row.EVENT_ITEM_NAME.Contains("呼吸"))
                                    {
                                        dtAnesthesiaEventClone.Add(row);
                                        return;
                                    }
                                }
                                else//有结束时间
                                {
                                    if (row.END_TIME > dtRange.StartDateTime)
                                    {
                                        dtAnesthesiaEventClone.Add(row);
                                    }
                                }
                            }//end if (row.START_TIME < dtRange.startTime)
                            else//如果起始时间 》=  控件 上起始时间
                            {
                                //没有结束时间
                                if (!row.END_TIME.HasValue)
                                {
                                    if (row.START_TIME < dtRange.EndDateTime)//起始时间   《  控件 上结束时间 
                                    {
                                        dtAnesthesiaEventClone.Add(row);
                                    }
                                }
                                else//有结束时间
                                {
                                    if (row.START_TIME < dtRange.EndDateTime)
                                    {
                                        dtAnesthesiaEventClone.Add(row);
                                    }
                                }
                            }
                        }
                    });
            return dtAnesthesiaEventClone;
        }
        /// <summary>
        /// 根据页码获取每页的时间范围
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private DateTimeRange GetPageDateTimeRange(int pageIndex)
        {
            DateTime startTime = _dateTimeRange.StartDateTime.AddHours(pageIndex * _pageHours);
            DateTime endTime = startTime.AddHours(_pageHours);
            DateTimeRange dtRange = new DateTimeRange(startTime, endTime);
            dtRange.OrigiStartDateTime = _dateTimeRange.OrigiStartDateTime;
            dtRange.OrigiEndDateTime = _dateTimeRange.OrigiEndDateTime;
            return dtRange;
        }
        /// <summary>
        /// 判读每页是否有附页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private bool HasAttachPage(int pageIndex)
        {
            //根据页码获取本页的时间范围和数据
            DateTimeRange dtRange = GetPageDateTimeRange(pageIndex);
            base.DataSource["AnesthesiaEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(GetPageAnesEventDataByTimeSpan(dtRange));

            //获取控件MedAnesSheetDetails
            MedAnesSheetDetails anesSheetDetails = null;
            //刷新数据.计算是否有附页
            foreach (IUIElementHandler handler in base._UIElementHandlers)
            {
                handler.PagerSetting.PageTimeSpan = dtRange;
                if (handler.GetControlType == typeof(MedDrugGraph) && handler.GetCurrentControl != null)
                    handler.RefreshData();
                if (handler.GetControlType == typeof(MedGridGraph) && handler.GetCurrentControl != null)
                    handler.RefreshData();
                if (handler.GetControlType == typeof(MedAnesSheetDetails) && handler.GetCurrentControl != null)
                {
                    anesSheetDetails = handler.GetCurrentControl as MedAnesSheetDetails;
                    anesSheetDetails.StartTime = dtRange.StartDateTime;
                    anesSheetDetails.EndTime = dtRange.EndDateTime;
                    handler.RefreshData();
                }
            }
            if (anesSheetDetails == null)
                return false;
            int totalCount = anesSheetDetails.TotalCount > 0 ? anesSheetDetails.TotalCount : 5;
            anesSheetDetails.StartIndex = 0;
            int cnt = 0;
            int n = 0;
            if (anesSheetDetails.Group)
            {
                //分组时 先重新绘制分组获取 DrawListCount 20140210
                Graphics g = Graphics.FromHwnd(anesSheetDetails.Handle);
                anesSheetDetails.DrawCollections(g);
                g.Dispose();
                anesSheetDetails.StartIndex = 0;
                cnt = anesSheetDetails.DrawListCount;
            }
            else
            {
                Graphics g = anesSheetDetails.CreateGraphics();
                float leftOffset = g.MeasureString("99", anesSheetDetails.DetailFont).Width;
                for (int i = 0; i < anesSheetDetails.Collections.Count; i++)
                {
                    if (anesSheetDetails.Collections[i] == null)
                        continue;
                    for (int j = 0; j < anesSheetDetails.Collections[i].Points.Count; j++)
                    {
                        if (anesSheetDetails.Collections[i].Points[j].StartTime >= dtRange.StartDateTime && anesSheetDetails.Collections[i].Points[j].StartTime < dtRange.StartDateTime.AddHours(_pageHours))
                        {
                            cnt++;
                            anesSheetDetails.Collections[i].Points[j].Index = cnt;//更新序号
                            List<string> list = anesSheetDetails.GetPointStrings(g, anesSheetDetails.Collections[i].Points[j], (int)anesSheetDetails.GetMainRect().X + leftOffset, (int)anesSheetDetails.GetMainRect().Y + anesSheetDetails.TopOffSet, anesSheetDetails.ColumnWidth - leftOffset);
                            if (list.Count > 1 && cnt < (totalCount - n))
                            {
                                n += list.Count - 1;
                            }
                        }
                    }
                }
            }
            //判断当前页是否有附页
            if (cnt > (totalCount - n))
            {
                return true;
            }
            return false;
        }
        public decimal GetDecimalValue(object rowValue)
        {
            if (rowValue != System.DBNull.Value && rowValue is decimal)
            {
                return (decimal)rowValue;
            }
            else
            {
                return 0;
            }
        }

        public override void Initial()
        {
            base.Initial();
            //if (this.Caption == "麻醉单")
            {
                // this.OnReportViewMouseDown += (control_MouseDown);
            }
        }

        protected override void RescueMode()
        {
            MedVitalSignGraph vitalSignGraph = null;
            MedDrugGraph drugGraph = null;
            MedGridGraph gridGraph = null;
            List<MedVitalSignGraph> vitalSignGraphs = ReportViewer.GetControls<MedVitalSignGraph>();
            List<MedDrugGraph> drugGraphs = ReportViewer.GetControls<MedDrugGraph>();
            List<MedGridGraph> gridGraphs = ReportViewer.GetControls<MedGridGraph>();

            if (vitalSignGraphs.Count > 0)
            {
                vitalSignGraph = vitalSignGraphs[0];
                if (!ExtendAppContext.Current.IsRescueMode)
                {
                    ExtendAppContext.Current.OldMinScaleCount = vitalSignGraph.MinScaleCount;
                }
            }
            if (drugGraphs.Count > 0)
            {
                drugGraph = drugGraphs[0];
            }
            if (gridGraphs.Count > 0)
            {
                gridGraph = gridGraphs[0];
            }

            base.RescueMode();

            if (ExtendAppContext.Current.IsRescueMode)
            {
                switch (vitalSignGraph.ScaleType)
                {
                    case ScaleType.HalfHour:
                        vitalSignGraph.MinScaleCount = 30;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 30;
                        gridGraph.MinScaleCount = 30;
                        break;
                    case ScaleType.Hour:
                        vitalSignGraph.MinScaleCount = 60;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 60;
                        gridGraph.MinScaleCount = 60;
                        break;
                    case ScaleType.OneMin:
                        vitalSignGraph.MinScaleCount = 1;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 1;
                        gridGraph.MinScaleCount = 1;
                        break;
                    case ScaleType.Quarter:
                        vitalSignGraph.MinScaleCount = 15;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 15;
                        gridGraph.MinScaleCount = 15;
                        break;
                    case ScaleType.TenMin:
                        vitalSignGraph.MinScaleCount = 10;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 10;
                        gridGraph.MinScaleCount = 10;
                        break;
                    case ScaleType.TriQuarter:
                        vitalSignGraph.MinScaleCount = 45;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 45;
                        gridGraph.MinScaleCount = 45;
                        break;
                    case ScaleType.TwiHour:
                        vitalSignGraph.MinScaleCount = 120;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 120;
                        gridGraph.MinScaleCount = 120;
                        break;
                    case ScaleType.TwoMin:
                        vitalSignGraph.MinScaleCount = 2;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 2;
                        gridGraph.MinScaleCount = 2;
                        break;
                    case ScaleType.FiveMin:
                        vitalSignGraph.MinScaleCount = 5;
                        vitalSignGraph.OnlyShowFileMinute = false;
                        drugGraph.MinScaleCount = 5;
                        gridGraph.MinScaleCount = 5;
                        break;
                }
            }
            else
            {
                vitalSignGraph.MinScaleCount = ExtendAppContext.Current.OldMinScaleCount;
                vitalSignGraph.OnlyShowFileMinute = true;
                drugGraph.MinScaleCount = ExtendAppContext.Current.OldMinScaleCount;
                gridGraph.MinScaleCount = ExtendAppContext.Current.OldMinScaleCount;
            }
            this.RefreshData();
        }

        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            base.OnViewBuilded(handlers, dataSources);
            List<MTextBox> txtBoxList = ReportViewer.GetControls<MTextBox>();
            foreach (MTextBox txtBox in txtBoxList)
            {
                if (txtBox.SummaryName == "总输液量")
                {
                    txtBox.Text = GetSummaryText("3");
                }
                else if (txtBox.SummaryName == "总输血量")
                {
                    txtBox.Text = GetSummaryText("B");
                }
            }
            
        }

        private string GetSummaryText(string type)
        {
            string summartText = "";
            List<MED_ANESTHESIA_EVENT> summaryList = _anesEvent.FindAll(x => x.EVENT_CLASS_CODE == type);
            var itemList = from item in summaryList
                           group item by item.EVENT_ITEM_NAME
                           into g
                           select new { EVENT_ITEM_NAME = g.Key, DOSAGE = g.Sum(a => a.DOSAGE), DOSAGE_UNITS = g.Max(a => a.DOSAGE_UNITS) };
            foreach (dynamic item in itemList)
            {
                summartText += item.EVENT_ITEM_NAME + item.DOSAGE + item.DOSAGE_UNITS + ",";
            }
            return summartText.TrimEnd(',');
        }

        protected override void OnControlInitalizing(Control control)
        {
            base.OnControlInitalizing(control);
        }

        /// <summary>
        /// 打印后自动打印PACU护理记录单
        /// </summary>
        protected override void OnAfterPrint()
        {
            DialogResult dr = MessageBox.Show("是否打印PACU护理记录单？", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes || dr == DialogResult.OK)
            {
                string docName = "PACU护理记录单";
                Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
                Type t = Type.GetType(docs[docName].Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.BackColor = Color.White;
                baseDoc.Name = docs[docName].Caption;
                baseDoc.HideScrollBar();
                baseDoc.Initial();
                baseDoc.LoadReport(Path.Combine(System.Windows.Forms.Application.StartupPath, docs[docName].Path));
                baseDoc.PrintBaseDoc();
            }
        }
    }
}
