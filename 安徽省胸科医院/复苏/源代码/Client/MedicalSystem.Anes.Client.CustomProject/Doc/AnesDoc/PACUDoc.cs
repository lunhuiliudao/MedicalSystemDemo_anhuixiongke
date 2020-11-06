using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using Medicalsystem.Anes.Custom.CustomProject;
using MedicalSystem.Services;
using MedicalSystem.Anes.Client.Repository;
using Newtonsoft.Json;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class PACUDoc : CustomBaseDoc
    {

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        /// <summary>
        /// 事件类型：0-麻醉 1-复苏
        /// </summary>
        private string _eventNo = "1";
        /// <summary>
        /// 麻醉单开始时间和结束时间
        /// </summary>
        private DateTimeRange _dateTimeRange = null;
        List<MED_ANESTHESIA_EVENT> _anesEvent = new List<MED_ANESTHESIA_EVENT>();
        List<MED_VITAL_SIGN> _vitalSign = new List<MED_VITAL_SIGN>();
        public PACUDoc()
        {
            InitializeComponent();
            base.Caption = "复苏单";
            base.DocKind = DocKind.PACU;
            this.BackColor = Color.White;
            ExtendApplicationContext.Current.EventNo = "1";
            _pageHours = ExtendApplicationContext.Current.AnesDocPageHours;
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
                if (handler is CustomControlHandler)
                {
                    handlerTemp = handler;
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
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            } 
            handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is SDTextBoxHandler)
                {
                    handlerTemp = handler;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }
            handlers.Add(new ExtendCustomControlHandler());
            handlers.Add(new SDLabelHandler());
            handlers.Add(new SDTextBoxHandler());
            handlers.Add(new DrugGraphHandler());
            handlers.Add(new GridGraphHandler());
            handlers.Add(new AnesSheetDetailsHandler());
            handlers.Add(new VitalSignGraphHandler());
            handlers.Add(new LegengGraphHandler());
        }

        /// <summary>
        /// 生成数据源
        /// </summary>
        /// <param name="dataSource"></param>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource.Clear();
            var operationMaster = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");

            List<MED_OPERATION_MASTER> lists = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(operationMaster);

            MED_OPERATION_MASTER operMaster = lists[0];
            Logger.Error("PACUDoc:" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
            _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            _vitalSign = DataContext.GetCurrent().GetVitalSignData(_eventNo);
            dataSource["MED_OPERATION_MASTER"] = operationMaster;
            dataSource["MED_PAT_MONITOR_DATA_EXT"] = DataContext.GetCurrent().GetData("MED_PAT_MONITOR_DATA_EXT");
            dataSource["MED_OPERATION_MASTER_EXT"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER_EXT");
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");
            dataSource["AnesAllEvent"] = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertListToDataTable(_anesEvent);
            //dataSource["MED_BJCA_SIGN"] = DataContext.GetCurrent().GetData("MED_BJCA_SIGN");
            //DataTable bjcaDt = DataContext.GetCurrent().GetData("MED_BJCA_SIGN");
            //if (bjcaDt.Rows.Count > 0)
            //{
            //    DataRow[] dataRows = bjcaDt.Select("SIGNDOCNAME = '" + this.Caption + "'");
            //    if (dataRows.Length > 0)
            //    {
            //        DataTable dt = bjcaDt.Clone();
            //        foreach (var item in dataRows)
            //        {
            //            dt.Rows.Add(item.ItemArray);
            //        }
            //        dataSource["MED_BJCA_SIGN"] = dt;
            //    }
            //}
            //获取起始时间和结束时间
            _dateTimeRange = base.GetGraphDateTime(_vitalSign, _anesEvent, _eventNo, operMaster);
            _dateTimeRange.OrigiStartDateTime = _dateTimeRange.StartDateTime;
            _dateTimeRange.OrigiEndDateTime = _dateTimeRange.EndDateTime;

            base.AdjustDateTimeRange(TimeScaleType.FiveMinute, ref _dateTimeRange);

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
            dataSource["AnesthesiaEvent"] = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertListToDataTable(GetPageAnesEventDataByTimeSpan(dtRange));

            dataSource["VitalSignData"] = ModelHelper<MED_VITAL_SIGN>.ConvertListToDataTable(GetPageVitalSignDataByTimeSpan(dtRange));
            base.SetCurrentPageData(dtRange, isMasterPage, _pageHours);

        }

        // <summary>
        // 文书上传前检查
        // </summary>
        // <returns></returns>
        //protected override bool CheckBeforeCommit()
        //{
        //    if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ExtendApplicationContext.Current.AppType != ApplicationType.PACU)
        //    {
        //        Dialog.MessageBox("您没有上传该文书的权限！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }
        //    AnesInformations.AnesthesiaEventDataTable anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
        //    foreach (AnesInformations.AnesthesiaEventRow row in anesEvent)
        //    {
        //        PointType pointType = (GetDecimalValue(row["DURATIVE_INDICATOR"]) == 1 ? PointType.ProLonged : PointType.SinglePoint);
        //        if (pointType == PointType.ProLonged)
        //        {
        //            if (row["START_TIME"] != System.DBNull.Value)
        //            {
        //                if (row["END_DATE"] == System.DBNull.Value)
        //                {
        //                    MessageBoxFormPC.Show("持续性 【" + row["ITEM_NAME"].ToString() + "】 已有开始时间，但是还没有结束时间，请确认文书完成后再上传 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    OperationStatus operStatus = ExtendApplicationContext.Current.OperationStatus;
        //    if (operStatus != OperationStatus.OutOperationRoom && operStatus != OperationStatus.TurnToPACU && operStatus != OperationStatus.TurnToSickRoom
        //         && operStatus != OperationStatus.InPACU && operStatus != OperationStatus.OutPACU && operStatus != OperationStatus.Done)
        //    {

        //        MessageBoxFormPC.Show("只有 【出手术室】后才能上传麻醉单 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }

        //    return true;
        //}
        //protected override bool CheckBeforeCommit()
        //{
        //    if (ExtendApplicationContext.Current.PatientInformationExtend.OPER_STATUS_CODE < 50)
        //    {
        //        MessageBoxFormPC.Show("请在出复苏室之后才能归档！");
        //        return false;
        //    }
        //    return true;
        //}
        /// <summary>
        ///打印前检查，判断是否可以打印
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforePrint()
        {
            if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ExtendApplicationContext.Current.AppType != ApplicationType.PACU)
            {
                MessageBoxFormPC.Show("您没有归档该文书的权限！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            OperationStatus operStatus = ExtendApplicationContext.Current.OperationStatus;
            if (operStatus != OperationStatus.TurnToSickRoom
                 && operStatus != OperationStatus.TurnToICU && operStatus != OperationStatus.OutPACU && operStatus != OperationStatus.Done)
            {
                if (MessageBoxFormPC.Show("病人还未出 【复苏室】，是否继续打印 ？", "操作提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return false;
                }
            }
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
            dataSource["AnesthesiaEvent"] = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertListToDataTable(GetPageAnesEventDataByTimeSpan(dtRange, true));
            dataSource["VitalSignData"] = ModelHelper<MED_VITAL_SIGN>.ConvertListToDataTable(GetPageVitalSignDataByTimeSpan(dtRange, true));

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
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            List<MED_OPERATION_MASTER> operMasterList = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER operMaster = null;
            if (operMasterList != null && operMasterList.Count > 0)
            {
                operMaster = operMasterList[0];
                if (!operMaster.OUT_PACU_DATE_TIME.HasValue && operMaster.OPER_STATUS_CODE == (int)OperationStatus.InPACU)
                {
                    MED_OPERATION_MASTER master = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                    if (master.OUT_PACU_DATE_TIME.HasValue)
                    {
                        operMaster.OUT_PACU_DATE_TIME = master.OUT_PACU_DATE_TIME;
                        operMaster.OPER_STATUS_CODE = master.OPER_STATUS_CODE;
                    }
                }
                if (operMaster.IN_PACU_DATE_TIME.HasValue && !operMaster.OUT_PACU_DATE_TIME.HasValue)
                    operMaster.OPER_STATUS_CODE = 45;
            }

            List<MED_PAT_MASTER_INDEX> patIndexList = ModelHelper<MED_PAT_MASTER_INDEX>.ConvertDataTableToList(dataSource["MED_PAT_MASTER_INDEX"]);
            MED_PAT_MASTER_INDEX patMasterIndex = null;
            if (patIndexList != null && patIndexList.Count > 0)
                patMasterIndex = patIndexList[0];

            List<MED_PAT_VISIT> patVisitList = ModelHelper<MED_PAT_VISIT>.ConvertDataTableToList(dataSource["MED_PAT_VISIT"]);
            MED_PAT_VISIT patVisit = null;
            if (patVisitList != null && patVisitList.Count > 0)
                patVisit = patVisitList[0];

            List<MED_ANESTHESIA_PLAN> anesPlanList = ModelHelper<MED_ANESTHESIA_PLAN>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_PLAN"]);
            MED_ANESTHESIA_PLAN anesPlan = null;
            if (anesPlanList != null && anesPlanList.Count > 0)
                anesPlan = anesPlanList[0];

            List<MED_ANESTHESIA_PLAN_PMH> anesPlanPMHList = ModelHelper<MED_ANESTHESIA_PLAN_PMH>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_PLAN_PMH"]);

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;
            if (anesPlanPMHList != null && anesPlanPMHList.Count > 0)
                anesPlanPmh = anesPlanPMHList[0];

            List<MED_OPERATION_EXTENDED> operExtended = ModelHelper<MED_OPERATION_EXTENDED>.ConvertDataTableToList(dataSource["MED_OPERATION_EXTENDED"]);

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = ModelHelper<MED_POSTOPERATIVE_EXTENDED>.ConvertDataTableToList(dataSource["MED_POSTOPERATIVE_EXTENDED"]);
            //OperationInfoService.SaveMedicalBasicDoc(operMaster, patIndex, patVisit, null, anesPlan, null, anesPlanPMH, operExtended, posExtended, null);

            MED_PATS_IN_HOSPITAL patsInHospital = null;


            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;


            List<MED_PREOPERATIVE_EXPANSION> preExpansion = null;

            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });


            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    MedVitalSignGraph vitalSign = handler.GetCurrentControl as MedVitalSignGraph;
                    if (vitalSign.NewMonitorData != null)
                        vitalSign.NewMonitorData.Save();
                }
            }
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
                base.DataSource["AnesAllEvent"] = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertListToDataTable(_anesEvent);
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
            base.DataSource["AnesthesiaEvent"] = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertListToDataTable(GetPageAnesEventDataByTimeSpan(dtRange));

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
    }
}
