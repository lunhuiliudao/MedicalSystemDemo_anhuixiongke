// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnesDoc.cs
// 功能描述(Description)：    麻醉单对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Custom.CustomProject;
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

namespace MedicalSystem.Anes.CustomProject
{
    public partial class PACUDoc : CustomBaseDoc
    {
        private string _eventNo = "1";                                                         // 事件类型：0-麻醉 1-复苏
        private DateTimeRange _dateTimeRange = null;                                           // 麻醉单开始时间和结束时间
        private List<MED_ANESTHESIA_EVENT> _anesEvent = new List<MED_ANESTHESIA_EVENT>();      // 患者用药等事件信息列表
        private List<MED_VITAL_SIGN> _vitalSign = new List<MED_VITAL_SIGN>();                  // 患者体征信息

        /// <summary>
        /// 无参构造
        /// </summary>
        public PACUDoc()
        {
            InitializeComponent();
            base.Caption = "复苏单";
            base.DocKind = DocKind.PACU;
            this.BackColor = Color.White;
            ExtendAppContext.Current.EventNo = "1";
            _pageHours = ApplicationConfiguration.AnesDocPageHours;
        }

        /// <summary>
        /// 初始化自定义的UIElementHandler，使用个性化Handler
        /// </summary>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            IUIElementHandler handlerTemp = null;

            // 去除通用LabelHandler，使用SDLabelHandler，显示文书第几页信息
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

            // 去除通用的自定义控件Handler，使用ExtendCustomControlHandler来计算评分和ASA等级 等信息
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

            // 去除通用TextBoxHandler， 使用SDTextBoxHandler来计算出入量信息
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
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource.Clear();
            var operationMaster = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
            MED_OPERATION_MASTER operMater = ExtendAppContext.Current.MED_OPERATION_MASTER;
            _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent();
            _vitalSign = DataContext.GetCurrent().GetVitalSignData();
            dataSource["MED_OPERATION_MASTER"] = operationMaster;
            dataSource["MED_PAT_MONITOR_DATA_EXT"] = DataContext.GetCurrent().GetData("MED_PAT_MONITOR_DATA_EXT");
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            dataSource["AnesAllEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(_anesEvent);

            //获取起始时间和结束时间
            _dateTimeRange = base.GetGraphDateTime(_vitalSign, _anesEvent, _eventNo, operMater);
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
        // 文书上传前检查，个性化操作，暂时注释，请勿删除
        // </summary>
        //protected override bool CheckBeforeCommit()
        //{
        //    if (!AccessControl.CheckModifyRightForOperator("麻醉记录单") && ExtendAppContext.CurntSelect.AppType != ApplicationType.PACU)
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
        //    OperationStatus operStatus = ExtendAppContext.CurntSelect.OperationStatus;
        //    if (operStatus != OperationStatus.OutOperationRoom && operStatus != OperationStatus.TurnToPACU && operStatus != OperationStatus.TurnToSickRoom
        //         && operStatus != OperationStatus.InPACU && operStatus != OperationStatus.OutPACU && operStatus != OperationStatus.Done)
        //    {

        //        MessageBoxFormPC.Show("只有 【出手术室】后才能上传麻醉单 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }

        //    return true;
        //}

        /// <summary>
        ///打印前检查，判断是否可以打印
        /// </summary>
        protected override bool CheckBeforePrint()
        {
            return base.CheckBeforePrint();
        }

        /// <summary>
        /// 自定义刷新数据，指定所需刷新的控件，提高效率
        /// </summary>
        protected override void OnCustomRefresh(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {
            //根据页码获取本页的时间范围
            DateTimeRange dtRange = GetPageDateTimeRange(mainPageIndex);

            //根据时间范围设置一页的数据
            dataSource["AnesthesiaEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(GetPageAnesEventDataByTimeSpan(dtRange, true));
            dataSource["VitalSignData"] = new ModelHandler<MED_VITAL_SIGN>().FillDataTable(GetPageVitalSignDataByTimeSpan(dtRange, true));
            base.RefreshCurrentControls(dtRange, 
                                        new Type[] { typeof(MedAnesSheetDetails), 
                                                     typeof(MedDrugGraph), 
                                                     typeof(MedVitalSignGraph), 
                                                     typeof(MedLegengGraph) }, 
                                        isMasterPage, 
                                        _pageHours);
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            bool result = this.SaveDocDataPars(dataSource);

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
        private List<MED_VITAL_SIGN> GetPageVitalSignDataByTimeSpan(DateTimeRange dtRange)
        {
            return this.GetPageVitalSignDataByTimeSpan(dtRange, false);
        }

        /// <summary>
        /// 根据时间范围获取一页的体征数据
        /// </summary>
        private List<MED_VITAL_SIGN> GetPageVitalSignDataByTimeSpan(DateTimeRange dtRange, bool isRefresh)
        {
            List<MED_VITAL_SIGN> dtVitalSignClone = new List<MED_VITAL_SIGN>();

            if (isRefresh)
            {
                _vitalSign = DataContext.GetCurrent().GetVitalSignData(_eventNo);
            }
            if (_vitalSign != null)
            {
                _vitalSign.ForEach(row =>
                    {
                        if (row.TIME_POINT >= dtRange.StartDateTime && row.TIME_POINT <= dtRange.EndDateTime)
                        {
                            dtVitalSignClone.Add(row);
                        }
                    });
            }

            return dtVitalSignClone;
        }

        /// <summary>
        /// 根据时间范围获取一页的麻醉事件数据
        /// </summary>
        private List<MED_ANESTHESIA_EVENT> GetPageAnesEventDataByTimeSpan(DateTimeRange dtRange)
        {
            return this.GetPageAnesEventDataByTimeSpan(dtRange, false);
        }

        /// <summary>
        /// 根据时间范围获取一页的麻醉事件数据
        /// </summary>
        private List<MED_ANESTHESIA_EVENT> GetPageAnesEventDataByTimeSpan(DateTimeRange dtRange, bool isRefresh)
        {
            List<MED_ANESTHESIA_EVENT> dtAnesthesiaEventClone = new List<MED_ANESTHESIA_EVENT>();
            if (isRefresh)
            {
                _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
                base.DataSource["AnesAllEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(_anesEvent);
            }
            if (_anesEvent != null)
            {
                _anesEvent.ForEach(row =>
                {
                    // 有起始时间，如没有，则不显示
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
                            else
                            {
                                if (row.END_TIME > dtRange.StartDateTime)
                                {
                                    dtAnesthesiaEventClone.Add(row);
                                }
                            }

                        }
                        else  //如果起始时间 》=  控件 上起始时间
                        {
                            // 没有结束时间
                            if (!row.END_TIME.HasValue)
                            {
                                if (row.START_TIME < dtRange.EndDateTime)//起始时间   《  控件 上结束时间 
                                {
                                    dtAnesthesiaEventClone.Add(row);
                                }
                            }
                            else// 有结束时间
                            {
                                if (row.START_TIME < dtRange.EndDateTime)
                                {
                                    dtAnesthesiaEventClone.Add(row);
                                }
                            }
                        }
                    }
                });
            }

            return dtAnesthesiaEventClone;
        }

        /// <summary>
        /// 根据页码获取每页的时间范围
        /// </summary>
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
        private bool HasAttachPage(int pageIndex)
        {
            //根据页码获取本页的时间范围和数据
            DateTimeRange dtRange = GetPageDateTimeRange(pageIndex);
            base.DataSource["AnesthesiaEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(GetPageAnesEventDataByTimeSpan(dtRange));

            // 获取控件MedAnesSheetDetails
            MedAnesSheetDetails anesSheetDetails = null;
            // 刷新数据.计算是否有附页
            foreach (IUIElementHandler handler in base._UIElementHandlers)
            {
                handler.PagerSetting.PageTimeSpan = dtRange;
                if (handler.GetControlType == typeof(MedDrugGraph) && handler.GetCurrentControl != null)
                {
                    handler.RefreshData();
                }
                if (handler.GetControlType == typeof(MedGridGraph) && handler.GetCurrentControl != null)
                {
                    handler.RefreshData();
                }
                if (handler.GetControlType == typeof(MedAnesSheetDetails) && handler.GetCurrentControl != null)
                {
                    anesSheetDetails = handler.GetCurrentControl as MedAnesSheetDetails;
                    anesSheetDetails.StartTime = dtRange.StartDateTime;
                    anesSheetDetails.EndTime = dtRange.EndDateTime;
                    handler.RefreshData();
                }
            }

            if (anesSheetDetails == null)
            {
                return false;
            }

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
                    {
                        continue;
                    }

                    for (int j = 0; j < anesSheetDetails.Collections[i].Points.Count; j++)
                    {
                        if (anesSheetDetails.Collections[i].Points[j].StartTime >= dtRange.StartDateTime && 
                            anesSheetDetails.Collections[i].Points[j].StartTime < dtRange.StartDateTime.AddHours(_pageHours))
                        {
                            cnt++;
                            anesSheetDetails.Collections[i].Points[j].Index = cnt;//更新序号
                            List<string> list = anesSheetDetails.GetPointStrings(g, 
                                                                                 anesSheetDetails.Collections[i].Points[j], 
                                                                                 (int)anesSheetDetails.GetMainRect().X + leftOffset, 
                                                                                 (int)anesSheetDetails.GetMainRect().Y + anesSheetDetails.TopOffSet,
                                                                                 anesSheetDetails.ColumnWidth - leftOffset);
                            if (list.Count > 1 && cnt < (totalCount - n))
                            {
                                n += list.Count - 1;
                            }
                        }
                    }
                }
            }

            // 判断当前页是否有附页
            if (cnt > (totalCount - n))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Value转Decimal
        /// </summary>
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
