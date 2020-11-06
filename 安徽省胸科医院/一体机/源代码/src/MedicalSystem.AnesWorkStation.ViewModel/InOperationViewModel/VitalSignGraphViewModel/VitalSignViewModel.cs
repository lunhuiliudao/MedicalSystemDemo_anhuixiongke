using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using System.Runtime.Serialization.Json;
using System.IO;
using MedicalSystem.AnesWorkStation.Model;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    /// <summary>
    /// 当前体征明细
    /// </summary>
    public class VitalSignViewModel : ViewModelBase
    {
        private List<VitalSignCurveDetailModel> _vitalSignCurves = null;
        private List<MED_VITAL_SIGN> _vitalSignList = null;
        private MedVitalSignGraph _vitalSignGraph = null;
        private AxisSetting _xAxisSetting = null;
        private List<MED_ANESTHESIA_EVENT> _anesEventList = null;
        /// <summary>
        /// 传入数据
        /// </summary>
        public List<VitalSignCurveDetailModel> VitalSignCurves
        {
            get
            {
                return _vitalSignCurves;
            }
            set
            {
                _vitalSignCurves = value;
            }
        }
        public VitalSignViewModel(List<MED_VITAL_SIGN> vitalSignList, List<MED_ANESTHESIA_EVENT> anesEventList, MedVitalSignGraph vitalSignGraph, AxisSetting xAxisSetting)
        {
            _vitalSignList = vitalSignList;
            _anesEventList = anesEventList;
            _vitalSignGraph = vitalSignGraph;
            _xAxisSetting = xAxisSetting;
        }
        /// <summary>
        /// 当前体征明细
        /// </summary> 
        public List<VitalSignCurveDetailModel> GetVitalSignCurve(bool isIntensive, RescueTime rescueTime)
        {
            List<VitalSignCurveDetailModel> curveList = new List<VitalSignCurveDetailModel>();
            Dictionary<string, VitalSignCurveDetailModel> dict = new Dictionary<string, VitalSignCurveDetailModel>();
            List<VitalSignCurveDetailModel> detailModel = GetUserVitalShowSet("0");
            //188,100,92,44,65,66,89,90密集体征默认显示以上体征
            foreach (VitalSignCurveDetailModel detail in detailModel)
            {
                if (isIntensive && !(detail.CurveCode == "188" || detail.CurveCode == "100" || detail.CurveCode == "92" || detail.CurveCode == "44"
                    || detail.CurveCode == "65" || detail.CurveCode == "66" || detail.CurveCode == "89" || detail.CurveCode == "90"))
                    continue;
                if (!string.IsNullOrEmpty(detail.CurveCode) && !dict.ContainsKey(detail.CurveCode))
                {
                    dict.Add(detail.CurveCode, detail);
                }
                else if (string.IsNullOrEmpty(detail.CurveCode) && !string.IsNullOrEmpty(detail.CurveName))
                {
                    foreach (MED_VITAL_SIGN vrow in _vitalSignList)
                    {
                        if (vrow.ITEM_NAME.Equals(detail.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                        {
                            dict.Add(vrow.ITEM_CODE, detail);
                            break;
                        }
                    }
                }
            }
            foreach (MedVitalSignCurveDetail detail in _vitalSignGraph.CurveDetails)
            {
                if (!string.IsNullOrEmpty(detail.CurveCode) && !dict.ContainsKey(detail.CurveCode))
                {
                    if (isIntensive && !(detail.CurveCode == "188" || detail.CurveCode == "100" || detail.CurveCode == "92" || detail.CurveCode == "44"
                   || detail.CurveCode == "65" || detail.CurveCode == "66"))
                        continue;
                    dict.Add(detail.CurveCode, ConvertToDetailModel(detail));
                }
            }
            List<string> itemNames = new List<string>();
            foreach (var item in detailModel)
            {
                if (!itemNames.Contains(item.CurveCode))
                    itemNames.Add(item.CurveCode);
            }
            //  if (_vitalSignList != null && _vitalSignList.Count > 0)
            {
                _vitalSignList.ForEach(row =>
                {
                    if (!itemNames.Contains(row.ITEM_CODE.Trim()))
                        itemNames.Add(row.ITEM_CODE);
                });
                itemNames = SortSignTitle(itemNames);
                ///逐条增加曲线
                #region 逐条增加曲线
                foreach (string item in itemNames)
                {
                    //   if (dict.ContainsKey(item) && !dict[item].Visible) continue;

                    VitalSignCurveDetailModel vitalSignCurveDetail = null;
                    if (dict.ContainsKey(item))
                    {
                        vitalSignCurveDetail = dict[item];
                    }
                    else if (ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(item) && dict.ContainsKey(ExtendAppContext.Current.MonitorFunctionCodeDict[item]))
                    {
                        vitalSignCurveDetail = dict[ExtendAppContext.Current.MonitorFunctionCodeDict[item]];
                    }
                    List<MED_VITAL_SIGN> vitallist = _vitalSignList.Where(x => x.ITEM_CODE == item).ToList();
                    if (vitallist != null && vitallist.Count > 0)
                    {
                        Color color;
                        //bool isDigit = false;
                        if (vitalSignCurveDetail == null)
                        {
                            color = GetRandomColor();
                            //isDigit = false;
                            SymbolModel symbol = GetRandomSymbol();
                            List<SymbolModel> symbolList = new List<SymbolModel>();
                            symbolList.Add(symbol);
                            string name = ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(item) ? ExtendAppContext.Current.MonitorFunctionCodeDict[item] : item;
                            vitalSignCurveDetail = new VitalSignCurveDetailModel(name, item, 0);
                            LegendItem litem = new LegendItem();
                            litem.Code = item;
                            litem.DisplayName = name;
                            litem.Symbol = symbol;
                            vitalSignCurveDetail.LegendList.Add(litem);
                            vitalSignCurveDetail.ShowType = CurveShowType.Line;
                            vitalSignCurveDetail.SymbolEntry = "";
                            vitalSignCurveDetail.Visible = true;
                            vitalSignCurveDetail.YAxisIndex = 0;
                            vitalSignCurveDetail.HideTime = new List<DateTimeRangeModel>() {
                                new DateTimeRangeModel(DateTime.MinValue, DateTime.MinValue)
                                {
                                    CurrentEntDT = null,
                                    CurrentStartDT = null,
                                    EndDateTime = null,
                                    SelectTime = null,
                                    StartDateTime = null
                                }
                            };
                            if (!dict.ContainsKey(item) && !isIntensive)
                                dict.Add(litem.Code, vitalSignCurveDetail);
                        }
                        //bool isModify = false;
                        if (vitalSignCurveDetail != null)
                        {
                            if (vitalSignCurveDetail.Points == null)
                                vitalSignCurveDetail.Points = new List<VitalSignPointModel>();
                            if (vitallist != null)
                            {
                                DateTime timePoint = vitallist[0].TIME_POINT;
                                DateTime hideStr = DateTime.MinValue;
                                DateTime hideEnd = DateTime.MinValue;
                                #region 密集体征
                                if (isIntensive)
                                {
                                    vitallist.ForEach(row =>
                                    {
                                        double tempValue;
                                        if (dict.ContainsKey(vitalSignCurveDetail.CurveCode) &&
                                            !string.IsNullOrEmpty(row.ITEM_VALUE) &&
                                            double.TryParse(row.ITEM_VALUE, out tempValue) &&
                                            Convert.ToDouble(row.ITEM_VALUE) > 0)
                                        {
                                            DateTime endTime = rescueTime.EndTime != null ? rescueTime.EndTime.Value : DateTime.Now;
                                            if (row.TIME_POINT >= rescueTime.BeginTime && row.TIME_POINT <= endTime)
                                            {
                                                vitalSignCurveDetail.ShowTimeInterval = ShowTimeInterval.AnyTime;
                                                vitalSignCurveDetail.Points.Add(new VitalSignPointModel(row.TIME_POINT, Convert.ToDouble(row.ITEM_VALUE), vitalSignCurveDetail, vitalSignCurveDetail.LegendList[0].Symbol, row.Flag));
                                            }
                                        }
                                    });
                                }
                                #endregion
                                #region 普通体征
                                else
                                {
                                    vitallist.ForEach(row =>
                                    {
                                        int mu = (int)((TimeSpan)(row.TIME_POINT - _xAxisSetting.BeginFactTime.Value.AddSeconds(-_xAxisSetting.BeginFactTime.Value.Second))).TotalMinutes;
                                        string value = row.ITEM_VALUE;
                                        double d = 0;
                                        //isModify = false;
                                        if (double.TryParse(value, out d) && d >= 0)
                                        {
                                            if (dict.ContainsKey(vitalSignCurveDetail.CurveCode) && ((mu % (int)dict[vitalSignCurveDetail.CurveCode].ShowTimeInterval) == 0) && Convert.ToDouble(row.ITEM_VALUE) > 0)
                                            {
                                                timePoint = timePoint.AddMinutes((int)dict[vitalSignCurveDetail.CurveCode].ShowTimeInterval);
                                                DateTime curRowPoint = row.TIME_POINT.AddMinutes((int)dict[vitalSignCurveDetail.CurveCode].ShowTimeInterval);
                                                if (timePoint != curRowPoint)
                                                {
                                                    hideStr = vitallist[vitallist.IndexOf(row) - 1].TIME_POINT.AddMinutes((int)dict[vitalSignCurveDetail.CurveCode].ShowTimeInterval);
                                                    hideEnd = row.TIME_POINT.AddMinutes(-(int)dict[vitalSignCurveDetail.CurveCode].ShowTimeInterval);
                                                    timePoint = row.TIME_POINT.AddMinutes((int)dict[vitalSignCurveDetail.CurveCode].ShowTimeInterval); ;
                                                    DateTimeRangeModel range = new DateTimeRangeModel(hideStr, hideEnd);
                                                    vitalSignCurveDetail.HideTime.Add(range);
                                                }
                                                vitalSignCurveDetail.Points.Add(new VitalSignPointModel(row.TIME_POINT, Convert.ToDouble(row.ITEM_VALUE), vitalSignCurveDetail, vitalSignCurveDetail.LegendList[0].Symbol, row.Flag));
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(row.Flag) && row.Flag.Equals("1"))
                                        {
                                            //isModify = true;
                                        }
                                    });
                                }
                                #endregion


                            }
                            if (vitalSignCurveDetail.Points.Count > 0)
                            {
                                curveList.Add(vitalSignCurveDetail);
                            }
                        }
                    }
                    else
                    {
                        if (vitalSignCurveDetail != null && !vitalSignCurveDetail.IsDigit && vitalSignCurveDetail.Points.Count > 0)
                            curveList.Add(vitalSignCurveDetail);
                    }
                }
                #endregion 逐条增加曲线
            }
            VitalSignCurves = curveList;
            if (_anesEventList != null)
                ControlBreath(_anesEventList, dict);
            return VitalSignCurves;
        }
        /// <summary>
        /// 呼吸控制
        /// </summary>
        /// <param name="anesEvent"></param>
        /// <param name="vitalSignGraph"></param>
        protected void ControlBreath(List<MED_ANESTHESIA_EVENT> anesEvent, Dictionary<string, VitalSignCurveDetailModel> dict)
        {
            if (anesEvent != null)
            {
                List<MED_ANESTHESIA_EVENT> rows = anesEvent.Where(x => !string.IsNullOrEmpty(x.EVENT_ITEM_NAME) && x.EVENT_ITEM_NAME.Contains("呼吸")).ToList();
                if (rows.Count == 0) return;
                //控制呼吸时间列表
                List<MedVitalSignBreathControlTime> listControlTime = new List<MedVitalSignBreathControlTime>();
                //最大体征时间
                DateTime maxVitalSignTime = DateTime.MaxValue;
                VitalSignCurveDetailModel curveBreath = null;
                //获取体征当前时间以及呼吸曲线
                for (int i = 0; i < _vitalSignCurves.Count; i++)
                {
                    if (_vitalSignCurves[i].CurveName.Contains("呼吸"))
                    {
                        curveBreath = _vitalSignCurves[i];
                        continue;
                    }
                    for (int j = 0; j < _vitalSignCurves[i].Points.Count; j++)
                    {
                        if (maxVitalSignTime == DateTime.MaxValue)
                        {
                            maxVitalSignTime = _vitalSignCurves[i].Points[j].Time;
                        }
                        else if (maxVitalSignTime < _vitalSignCurves[i].Points[j].Time)
                        {
                            maxVitalSignTime = _vitalSignCurves[i].Points[j].Time;
                        }
                    }
                }
                if (curveBreath == null)//生成曲线
                {
                    if (dict.ContainsKey("92"))
                    {
                        curveBreath = dict["92"];
                        _vitalSignCurves.Add(curveBreath);
                    }
                }
                if (curveBreath != null)
                {
                    listControlTime.AddRange(BreathTimeList("自主呼吸", anesEvent, _vitalSignGraph, dict));
                    listControlTime.AddRange(BreathTimeList("控制呼吸", anesEvent, _vitalSignGraph, dict));
                    listControlTime.AddRange(BreathTimeList("辅助呼吸", anesEvent, _vitalSignGraph, dict));
                }
                //排序 listControlTime
                listControlTime.Sort(new Comparison<MedVitalSignBreathControlTime>(delegate (MedVitalSignBreathControlTime controlTime1, MedVitalSignBreathControlTime controlTime2)
                {
                    return controlTime1.oStartTime.CompareTo(controlTime2.oStartTime);
                }));
                //调整  listControlTime ，使得时间无重叠 
                if (listControlTime.Count > 1)
                {
                    MedVitalSignBreathControlTime breathControlTime1 = null;
                    MedVitalSignBreathControlTime breathControlTime2 = null;
                    for (int i = 0; i < listControlTime.Count - 1; i++)
                    {
                        breathControlTime1 = listControlTime[i];
                        breathControlTime2 = listControlTime[i + 1];
                        if (breathControlTime1.endTime >= breathControlTime2.startTime)
                        {
                            breathControlTime1.endTime = breathControlTime2.startTime.AddMinutes(-5);
                        }
                    }
                }
                VitalSignPointModel point = null;//删除所有时间段内的点 
                for (int count = 0; count < listControlTime.Count; count++)
                {
                    //删除控制呼吸以及辅助呼吸点
                    DateTimeRange range = new DateTimeRange(listControlTime[count].startTime, listControlTime[count].endTime);
                    if (curveBreath.Points == null) curveBreath.Points = new List<VitalSignPointModel>();
                    for (int i = 0; i < curveBreath.Points.Count; i++)
                    {
                        point = curveBreath.Points[i];
                        if (point.Time >= range.StartDateTime && point.Time <= range.EndDateTime)
                        {
                            curveBreath.Points.Remove(point);
                            i--;
                        }
                    }
                    DateTime dt = range.StartDateTime;
                    dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                    //控制呼吸处理
                    if (listControlTime[count].BreathType == BreathControlType.ControlBreath)
                    {
                        SymbolModel symbol = new SymbolModel(SymbolType.Text);
                        symbol.Text = "C";
                        bool isExist = false;
                        for (int i = 0; i < curveBreath.LegendList.Count; i++)
                        {
                            if (curveBreath.LegendList[i].Symbol.SymbolType == symbol.SymbolType)
                            {
                                curveBreath.LegendList[i].Code = "控制呼吸";
                                curveBreath.LegendList[i].DisplayName = "控制呼吸";
                                isExist = true;
                            }
                        }
                        if (!isExist)
                        {
                            LegendItem item = new LegendItem();
                            item.Code = "控制呼吸";
                            item.DisplayName = "控制呼吸";
                            item.Symbol = symbol;
                            curveBreath.LegendList.Add(item);
                        }
                        while (dt <= range.EndDateTime)
                        {
                            point = new VitalSignPointModel(dt, listControlTime[count].breathValue, curveBreath, symbol, "");
                            curveBreath.Points.Add(point);  //加入新点 
                            dt = dt.AddMinutes(listControlTime[count].showTimeInterval);
                        }
                    }
                    //辅助呼吸处理
                    else if (listControlTime[count].BreathType == BreathControlType.HelpBreath)
                    {
                        SymbolModel symbol = new SymbolModel(SymbolType.Text);
                        symbol.Text = "A";
                        bool isExist = false;
                        for (int i = 0; i < curveBreath.LegendList.Count; i++)
                        {
                            if (curveBreath.LegendList[i].Symbol.SymbolType == symbol.SymbolType)
                            {
                                curveBreath.LegendList[i].Code = "辅助呼吸";
                                curveBreath.LegendList[i].DisplayName = "辅助呼吸";
                                isExist = true;
                            }
                        }
                        if (!isExist)
                        {
                            LegendItem item = new LegendItem();
                            item.Code = "辅助呼吸";
                            item.DisplayName = "辅助呼吸";
                            item.Symbol = symbol;
                            curveBreath.LegendList.Add(item);
                        }

                        while (dt <= range.EndDateTime)
                        {
                            point = new VitalSignPointModel(dt, listControlTime[count].breathValue, curveBreath, symbol, "");
                            curveBreath.Points.Add(point);  //加入新点 
                            dt = dt.AddMinutes(listControlTime[count].showTimeInterval);
                        }
                    }
                    else
                    {
                        while (dt <= range.EndDateTime)
                        {
                            point = new VitalSignPointModel(dt, listControlTime[count].breathValue, curveBreath, curveBreath.LegendList[0].Symbol, "");
                            curveBreath.Points.Add(point);  //加入新点 
                            dt = dt.AddMinutes(listControlTime[count].showTimeInterval);
                        }
                    }

                    curveBreath.Points.Sort(new Comparison<VitalSignPointModel>(delegate (VitalSignPointModel point1, VitalSignPointModel point2)
                    {
                        return point1.Time.CompareTo(point2.Time);
                    }));

                }
            }
        }
        /// <summary>
        /// 获取呼吸时间列表
        /// </summary>
        /// <param name="breathType"></param>
        /// <param name="anesEvent"></param>
        /// <param name="vitalSignGraph"></param>
        /// <returns></returns>
        private List<MedVitalSignBreathControlTime> BreathTimeList(string breathType, List<MED_ANESTHESIA_EVENT> anesEvent, MedVitalSignGraph vitalSignGraph, Dictionary<string, VitalSignCurveDetailModel> dict)
        {
            List<MED_ANESTHESIA_EVENT> rows = anesEvent.Where(x => x.EVENT_ITEM_NAME.Contains(breathType)).ToList();

            DateTime controlStartTime = DateTime.MinValue;
            DateTime controlEndTime = DateTime.MaxValue;
            double dBreathValue = -1;
            //控制呼吸时间列表
            List<MedVitalSignBreathControlTime> listControlTime = new List<MedVitalSignBreathControlTime>();
            DateTime sysDatetTime = DateTime.Now;
            if (rows != null)
                rows.ForEach(anesthesiaEventRow =>
                {
                    //初始化值
                    controlStartTime = DateTime.MinValue;
                    controlEndTime = DateTime.MaxValue;
                    if (anesthesiaEventRow.START_TIME.HasValue)
                    {
                        controlStartTime = anesthesiaEventRow.START_TIME.Value;
                    }
                    if (anesthesiaEventRow.END_TIME.HasValue)
                    {
                        controlEndTime = anesthesiaEventRow.END_TIME.Value;
                    }
                    if (anesthesiaEventRow.DOSAGE.HasValue)
                    {
                        dBreathValue = (double)anesthesiaEventRow.DOSAGE;
                    }
                    else
                    {
                        dBreathValue = 0;
                    }
                    //有开始时间  并且有体征数据 并且有呼吸值
                    if (controlStartTime != DateTime.MinValue && dBreathValue >= 0)
                    {
                        //没有结束时间
                        if (controlEndTime == DateTime.MaxValue)
                        {
                            controlEndTime = sysDatetTime;
                        }
                        DateTimeRange range = new DateTimeRange(controlStartTime, controlEndTime);
                        //控制呼吸
                        MedVitalSignBreathControlTime breathControlTime = new MedVitalSignBreathControlTime();
                        breathControlTime.startTime = range.StartDateTime;
                        breathControlTime.endTime = range.EndDateTime;

                        breathControlTime.oStartTime = controlStartTime;
                        breathControlTime.oEndTime = controlEndTime;

                        breathControlTime.breathValue = dBreathValue;
                        //显示频率 
                        int timeSpan = 5;
                        string breathName = "呼吸";
                        Color color = Color.Magenta;
                        //设置初始值
                        foreach (VitalSignCurveDetailModel detail in dict.Values)
                        {
                            if (detail.CurveName.Equals("呼吸"))
                            {
                                color = detail.Color;
                                break;
                            }
                        }
                        foreach (VitalSignCurveDetailModel detail in dict.Values)
                        {
                            if (breathType == "自主呼吸")
                                breathName = "呼吸";
                            else
                                breathName = breathType;

                            if (detail.CurveName.Equals(breathName))
                            {
                                color = detail.Color;

                                switch (detail.ShowTimeInterval)
                                {
                                    case ShowTimeInterval.Five:
                                        timeSpan = 5;
                                        break;
                                    case ShowTimeInterval.Fifiteen:
                                        timeSpan = 15;
                                        break;
                                    case ShowTimeInterval.Ten:
                                        timeSpan = 10;
                                        break;
                                    case ShowTimeInterval.Twenty:
                                        timeSpan = 20;
                                        break;
                                    case ShowTimeInterval.HalfHour:
                                        timeSpan = 30;
                                        break;
                                    case ShowTimeInterval.Hour:
                                        timeSpan = 60;
                                        break;
                                }
                            }
                        }
                        //新增显示频率 20120927
                        breathControlTime.showTimeInterval = timeSpan;
                        breathControlTime.curveColor = color;

                        if (breathType.Contains("控制呼吸"))
                        {
                            breathControlTime.BreathType = BreathControlType.ControlBreath;
                            if (!string.IsNullOrEmpty(vitalSignGraph.BreathPara1) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara2) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara3))
                            {
                                List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable = AnesInfoService.ClientInstance.GetPatMonitorExtList(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                        ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                                if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
                                {
                                    List<MED_PAT_MONITOR_DATA_EXT> rows1 = patMonitorDataExtDataTable.Where(x => x.ITEM_CODE == vitalSignGraph.BreathPara1 || x.ITEM_CODE == vitalSignGraph.BreathPara2 || x.ITEM_CODE == vitalSignGraph.BreathPara3).ToList();

                                    if (rows1 != null && rows1.Count > 0)
                                    {
                                        rows1.ForEach(rr =>
                                        {
                                            if (!vitalSignGraph.BreathParalList.ContainsKey(rr.TIME_POINT))
                                            {
                                                vitalSignGraph.BreathParalList.Add(rr.TIME_POINT, new MedVitalSignGraph.BreathPara());
                                            }
                                            if (!string.IsNullOrEmpty(rr.ITEM_VALUE))
                                            {
                                                if (rr.ITEM_CODE.Equals(vitalSignGraph.BreathPara1))
                                                {
                                                    vitalSignGraph.BreathParalList[rr.TIME_POINT].Para1 = rr.ITEM_VALUE;
                                                }
                                                else if (rr.ITEM_CODE.Equals(vitalSignGraph.BreathPara2))
                                                {
                                                    vitalSignGraph.BreathParalList[rr.TIME_POINT].Para2 = rr.ITEM_VALUE;
                                                }
                                                else if (rr.ITEM_CODE.Equals(vitalSignGraph.BreathPara3))
                                                {
                                                    vitalSignGraph.BreathParalList[rr.TIME_POINT].Para3 = rr.ITEM_VALUE;
                                                }
                                            }
                                        });
                                    }
                                }
                            }
                        }
                        else if (breathType.Contains("辅助呼吸"))
                            breathControlTime.BreathType = BreathControlType.HelpBreath;
                        else if (breathType.Contains("自主呼吸"))
                            breathControlTime.BreathType = BreathControlType.FreeBreath;


                        listControlTime.Add(breathControlTime);

                    }
                });
            return listControlTime;
        }

        /// <summary>
        /// 获取麻醉单血气记录
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public List<TextMarkPoint> GetBloodGasItems(string patientID, int visitID, int operID)
        {
            LoadBloodGasItem();
            List<TextMarkPoint> list = new List<TextMarkPoint>();
            //string[] detailList = ExtendAppContext.Current.DefaultBloodGasItem.ToArray();
            List<MED_BLOOD_GAS_DICT> bloodGasDict = ApplicationModel.Instance.AllDictList.BloodGasDictList;
            List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = AnesInfoService.ClientInstance.GetBloodGasMasterList(patientID, visitID, operID);
            if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count > 0)
            {
                List<MED_BLOOD_GAS_DETAIL_SHOW> bloodGasDetailDataTable = null;
                bloodGasMasterDataTable.ForEach(row =>
                {
                    if (!string.IsNullOrEmpty(row.NURSE_MEMO2) && row.NURSE_MEMO2.StartsWith("ok@"))
                    {
                        string typeName = "静脉";
                        if (!string.IsNullOrEmpty(row.NURSE_MEMO1))
                        {
                            typeName = row.NURSE_MEMO1;
                        }
                        //else
                        //{
                        //    typeName = "动脉";
                        //}
                        string MarkText = typeName + "血气" + "\n";
                        //bloodGasDetailDataTable = AnesInfoService.ClientInstance.GetBloodGasDetailList(row.DETAIL_ID);
                        bloodGasDetailDataTable = this.GetDetailShowList(row.DETAIL_ID);// 从血气表和血气另存表获取血气数据

                        if (bloodGasDetailDataTable != null && bloodGasDetailDataTable.Count > 0)
                        {
                            //foreach (var item in bloodGasDict)
                            //{
                            //    MED_BLOOD_GAS_DETAIL tmpItem = bloodGasDetailDataTable.Find(x => x.BLG_CODE == item.BLG_CODE);
                            //    if (item != null && !string.IsNullOrEmpty(tmpItem.BLG_VALUE))// 如果上面找不到，则会出现空指针异常
                            //    {
                            //        MarkText += ExtendAppContext.Current.BloodGasItemDict[tmpItem.BLG_CODE] + "=" + tmpItem.BLG_VALUE + "\n";
                            //    }
                            //}
                            bloodGasDetailDataTable.ForEach(gasRow =>
                            {
                                if (!string.IsNullOrEmpty(gasRow.BLG_VALUE))
                                {
                                    MarkText += ExtendAppContext.Current.BloodGasItemDict[gasRow.BLG_CODE] + "=" + gasRow.BLG_VALUE + "\n";
                                }
                            });
                        }
                        list.Add(new TextMarkPoint(row.RECORD_DATE, MarkText));
                    }
                });
            }
            return list;
        }
        /// <summary>
        /// 获取血气数据（主要从另存表里获取）
        /// </summary>
        /// <param name="strDetailId"></param>
        /// <returns></returns>
        private List<MED_BLOOD_GAS_DETAIL_SHOW> GetDetailShowList(string strDetailId)
        {
            List<MED_BLOOD_GAS_DETAIL_SHOW> originList = AnesInfoService.ClientInstance.GetBloodGasDetailShowList(strDetailId);// 血气主表的数据

            List<MED_BLOOD_GAS_DETAIL_SHOW> extList = AnesInfoService.ClientInstance.GetBloodGasDetailExtShowList(strDetailId);// 血气另存表的数据

            List<MED_BLOOD_GAS_DETAIL_SHOW> result = new List<MED_BLOOD_GAS_DETAIL_SHOW>(extList);

            originList.ForEach(x =>
            {
                if (null == extList.FirstOrDefault(row => row.DETAIL_ID.Equals(x.DETAIL_ID) &&
                                                    row.BLG_CODE.Equals(x.BLG_CODE)))// 另存表数据不存在某血气的话，增加此血气
                {
                    result.Add(x);
                }
            });

            return result;
        }
        /// <summary>
        /// 初始化血气代码名称字典及默认显示项目
        /// </summary>
        private void LoadBloodGasItem()
        {
            List<MED_BLOOD_GAS_DICT> bloodGasList = ApplicationModel.Instance.AllDictList.BloodGasDictList;
            if (bloodGasList != null && bloodGasList.Count > 0)
            {
                foreach (MED_BLOOD_GAS_DICT row in bloodGasList)
                {
                    if (!ExtendAppContext.Current.BloodGasItemDict.ContainsKey(row.BLG_CODE))
                    {
                        ExtendAppContext.Current.BloodGasItemDict.Add(row.BLG_CODE, row.BLG_NAME);
                    }
                    if (row.BLG_STATUS == "1")// 状态;0 表示主程序报表中不显示，即采集程序也不采集该化验项目。1，表示允许采集程序采集该化验项目
                    {
                        if (!ExtendAppContext.Current.DefaultBloodGasItem.Contains(row.BLG_CODE))
                        {
                            ExtendAppContext.Current.DefaultBloodGasItem.Add(row.BLG_CODE);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取用户曲线设置
        /// </summary>
        /// <returns></returns>
        protected List<VitalSignCurveDetailModel> GetUserVitalShowSet(string eventNo)
        {
            List<VitalSignCurveDetailModel> detailList = new List<VitalSignCurveDetailModel>();
            List<MedVitalSignCurveDetail> list = new List<MedVitalSignCurveDetail>();
            MED_PATIENT_MONITOR_CONFIG config = GetPatientMonitorConfigDataTable(eventNo);
            if (config != null && !string.IsNullOrEmpty(config.CONTENT.ToString()))
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(config.CONTENT);
                stream.Position = 0;
                DataSet ds = new DataSet();
                ds.ReadXml(stream);
                if (ds.Tables.Count > 0)
                {
                    string tableName = "UserVitalShowSet" + ((Convert.ToInt32(eventNo) < 0) ? "0" : eventNo);
                    DataTable dataTable = ds.Tables[tableName];
                    ListFromTable(list, typeof(MedVitalSignCurveDetail), dataTable);
                }
                ds.Dispose();
                stream.Close();
                stream.Dispose();
            }
            foreach (MedVitalSignCurveDetail detail in list)
            {
                detailList.Add(ConvertToDetailModel(detail));
            }
            return detailList;
        }

        /// <summary>
        /// 获取当前患者监测配置数据
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        private MED_PATIENT_MONITOR_CONFIG GetPatientMonitorConfigDataTable(string eventNo)
        {
            MED_PATIENT_MONITOR_CONFIG config = null;
            if (ExtendAppContext.Current.PatientInformationExtend != null)//出手术室时候为Null 异常

                config = AnesInfoService.ClientInstance.GetPatientMonitorConfig(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID
                    , ExtendAppContext.Current.PatientInformationExtend.OPER_ID, eventNo);

            if (config == null)
            {
                config = AnesInfoService.ClientInstance.GetPatientMonitorConfig("999", 0, 0, eventNo);
            }
            return config;
        }
        protected void ListFromTable(IList list, Type type, DataTable dataTable)
        {
            if (dataTable != null)
            {
                List<MemberDetail> memberDetails = AssemblyHelper.GetPropertyList(type);
                foreach (DataRow row in dataTable.Rows)
                {
                    object obj = Activator.CreateInstance(type);
                    foreach (MemberDetail memberDetail in memberDetails)
                    {
                        PropertyInfo propertyInfo = memberDetail.PropertyInfo;
                        if (dataTable.Columns.Contains(memberDetail.Name) && row[memberDetail.Name] != System.DBNull.Value)
                        {
                            try
                            {
                                if (propertyInfo.Name.Equals("LegendList"))
                                {
                                    string value = row[memberDetail.Name].ToString();
                                    string[] valueList = value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                    List<LegendItem> LegendList = new List<LegendItem>();
                                    foreach (var str in valueList)
                                    {
                                        if (!string.IsNullOrEmpty(str))
                                        {
                                            LegendItem item = new LegendItem();
                                            item.Code = row["CurveCode"].ToString();
                                            item.DisplayName = row["CurveName"].ToString();
                                            item.Symbol = new SymbolModel((SymbolType)Enum.Parse(typeof(SymbolType), str));
                                            LegendList.Add(item);
                                        }
                                    }
                                    propertyInfo.SetValue(obj, LegendList, null);
                                }
                                else if (propertyInfo.Name.Equals("HideTime"))
                                {
                                    string value = row[memberDetail.Name].ToString();
                                    string[] valueList = value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                    List<DateTimeRangeModel> HideTime = new List<DateTimeRangeModel>();
                                    foreach (var str in valueList)
                                    {
                                        if (!string.IsNullOrEmpty(str))
                                        {
                                            string[] timeList = str.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

                                            if (timeList.Length == 2)
                                            {
                                                DateTimeRangeModel item = new DateTimeRangeModel(Convert.ToDateTime(timeList[0]), Convert.ToDateTime(timeList[1]));
                                                HideTime.Add(item);
                                            }
                                        }
                                    }
                                    propertyInfo.SetValue(obj, HideTime, null);
                                }
                                else
                                    AssemblyHelper.SetPropertyValue(propertyInfo, obj, row[memberDetail.Name].ToString());
                            }
                            catch (Exception)
                            {
                                //提示信息
                                throw;
                            }
                        }
                    }
                    list.Add(obj);
                }
            }
        }
        /// <summary>
        /// 获取一个随机的颜色
        /// </summary>
        /// <returns></returns>
        protected Color GetRandomColor()
        {
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            return Color.FromArgb(r, g, b);
        }
        /// <summary>
        /// 随机标识
        /// </summary>
        private SymbolModel GetRandomSymbol()
        {
            System.Threading.Thread.Sleep(1);
            Random rand = new Random();
            return new SymbolModel((SymbolType)rand.Next((int)SymbolType.Image) - 1);
        }
        //转换MODEL
        private VitalSignCurveDetailModel ConvertToDetailModel(MedVitalSignCurveDetail detail)
        {
            VitalSignCurveDetailModel detailMode = new VitalSignCurveDetailModel();
            detailMode.CurveName = detail.CurveName;
            detailMode.CurveCode = detail.CurveCode;
            detailMode.Visible = detail.Visible;
            string type = detail.SymbolType.ToString();
            LegendItem item = new LegendItem();
            item.Code = detail.CurveCode;
            item.DisplayName = detail.CurveName;
            item.Symbol = new SymbolModel((SymbolType)Enum.Parse(typeof(SymbolType), type));
            detailMode.LegendList.Add(item);
            // detailMode.LegendDictionary.Add(detail.CurveName, new SymbolModel((SymbolType)Enum.Parse(typeof(SymbolType), type)));
            detailMode.SymbolEntry = detail.SymbolEntry;
            detailMode.Color = detail.Color;
            detailMode.DecimalDigits = detail.DotNumber;
            string showType = detail.ShowType.ToString();
            detailMode.ShowType = (CurveShowType)Enum.Parse(typeof(CurveShowType), showType);
            detailMode.YAxisIndex = detail.YAxisIndex;
            string showTime = detail.ShowTimeInterval.ToString();
            detailMode.ShowTimeInterval = (ShowTimeInterval)Enum.Parse(typeof(ShowTimeInterval), showTime);
            DateTimeRangeModel timeRange = new DateTimeRangeModel(detail.HideStartTime, detail.HideEndTime);
            detailMode.HideTime = new List<DateTimeRangeModel>();
            detailMode.HideTime.Add(timeRange);
            return detailMode;
        }
        /// <summary>
        /// 体征项目排序
        /// </summary>
        private List<string> SortSignTitle(List<string> monitorValueList)
        {
            List<MED_MONITOR_FUNCTION_CODE> tmpList = new List<MED_MONITOR_FUNCTION_CODE>();
            List<MED_MONITOR_FUNCTION_CODE> listMonitorFunction = ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList;
            for (int i = 0; i < monitorValueList.Count; i++)
            {
                MED_MONITOR_FUNCTION_CODE item = listMonitorFunction.Find(x => x.ITEM_CODE == monitorValueList[i]);
                tmpList.Add(item);
            }
            //return tmpList.OrderBy(x => x.PRINT_ITEM_NO).Select(x => x.ITEM_CODE).ToList();

            return tmpList.Select(x => x.ITEM_CODE).ToList();
        }
    }
}
