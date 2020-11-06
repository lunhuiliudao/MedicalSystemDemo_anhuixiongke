// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      VitalSignGraphHandler.cs
// 功能描述(Description)：    麻醉单体征控件对应的Handler
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Constants;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    public class VitalSignGraphHandler : UIElementHandler<MedVitalSignGraph>
    {
        private string _eventNo = "0";                                     // 系统类型：麻醉（0） OR 复苏（1）
        protected MedVitalSignGraph _currentGraph = null;                  // 体征控件
        protected DateTime _currentTime = DateTime.MinValue;               // 当前时间点

        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        public override void BindDataToUI(MedVitalSignGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("AnesthesiaEvent"))
            {
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));
            }
            if (!dataSources.ContainsKey("VitalSignData"))
            {
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.VitalSignDataTable,请添加此绑定数据源!", "VitalSignData"));
            }
            if (!dataSources.ContainsKey("AnesAllEvent"))
            {
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesAllEvent"));
            }

            List<MED_VITAL_SIGN> vitalSignData = new ModelHandler<MED_VITAL_SIGN>().FillModel(dataSources["VitalSignData"]);
            List<MED_ANESTHESIA_EVENT> anesEvent = new ModelHandler<MED_ANESTHESIA_EVENT>().FillModel(dataSources["AnesthesiaEvent"]);
            List<MED_ANESTHESIA_EVENT> anesAllEvent = new ModelHandler<MED_ANESTHESIA_EVENT>().FillModel(dataSources["AnesAllEvent"]);

            if (control != null)
            {
                control.Curves.Clear();
                control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
                control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
                control.MinStartDateTime = PagerSetting.PageTimeSpan.OrigiStartDateTime;
                control.MaxEndDateTime = PagerSetting.PageTimeSpan.OrigiEndDateTime;
                _eventNo = ExtendAppContext.Current.EventNo;
                Dictionary<string, MedVitalSignCurveDetail> dict = new Dictionary<string, MedVitalSignCurveDetail>();
                List<MedVitalSignCurveDetail> userVitalSets = GetUserVitalShowSet(control.EventNo);
                // 形成最新的曲线字典
                foreach (MedVitalSignCurveDetail vitalSet in userVitalSets)
                {
                    if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !dict.ContainsKey(vitalSet.CurveCode))
                    {
                        dict.Add(vitalSet.CurveCode, vitalSet);
                    }
                    else if (string.IsNullOrEmpty(vitalSet.CurveCode) && !string.IsNullOrEmpty(vitalSet.CurveName))//
                    {
                        foreach (MED_VITAL_SIGN vrow in vitalSignData)
                        {
                            if (vrow.ITEM_NAME.Equals(vitalSet.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                            {
                                dict.Add(vrow.ITEM_CODE, vitalSet);
                                break;
                            }
                        }
                    }
                }

                //foreach (MedVitalSignCurveDetail detail in control.CurveDetails)
                //{
                //    if (!string.IsNullOrEmpty(detail.CurveCode) && !dict.ContainsKey(detail.CurveCode))
                //    {
                //        dict.Add(detail.CurveCode, detail);
                //    }
                //}

                // 获取监测表格中显示的体征项
                MedSheet medSheet = null;
                foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
                {
                    if (handler.GetControlType == typeof(MedSheet) && handler.GetCurrentControl != null)
                    {
                        medSheet = handler.GetCurrentControl as MedSheet;
                        break;
                    }
                }

                // 将最新的曲线字典设置成全局曲线字典，
                ExtendAppContext.Current.VitalSignCurveDetailDict = dict;
                DateTime dgStartTime = DateTime.MinValue;
                bool IsModifyVitalSignShowDifferent = ApplicationConfiguration.IsModifyVitalSignShowDifferent;
                if (vitalSignData != null && vitalSignData.Count > 0)
                {
                    List<string> itemNames = new List<string>();
                    vitalSignData.ForEach(row =>
                        {
                            if (!itemNames.Contains(row.ITEM_CODE.Trim()))
                            {
                                itemNames.Add(row.ITEM_CODE);
                            }
                        });

                    // 排序
                    itemNames = this.SortSignTitle(itemNames);

                    // 去除监测表中显示的体征项
                    if (null != medSheet)
                    {
                        for (int i = 0; i < medSheet.Rows.Count; i++)
                        {
                            if (itemNames.Contains(medSheet.Rows[i].ItemCode))
                            {
                                itemNames.Remove(medSheet.Rows[i].ItemCode);
                            }
                        }
                    }

                    // 逐条增加曲线
                    foreach (string item in itemNames)
                    {
                        if (dict.ContainsKey(item) && !dict[item].Visible)
                        {
                            continue;
                        }

                        MedVitalSignCurveDetail vitalSignCurveDetail = null;
                        if (dict.ContainsKey(item))
                        {
                            vitalSignCurveDetail = dict[item];
                        }
                        else if (ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(item) &&
                                 dict.ContainsKey(ExtendAppContext.Current.MonitorFunctionCodeDict[item]))
                        {
                            vitalSignCurveDetail = dict[ExtendAppContext.Current.MonitorFunctionCodeDict[item]];
                        }

                        List<MED_VITAL_SIGN> vitallist = vitalSignData.Where(x => x.ITEM_CODE == item).ToList();
                        if (vitallist != null && vitallist.Count > 0)
                        {
                            Color color;
                            bool isDigit = false;
                            MedSymbol symbol = null;
                            MedVitalSignCurve curve = null;
                            if (vitalSignCurveDetail != null)
                            {
                                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Image)
                                {
                                    try
                                    {
                                        symbol = new MedSymbol(Image.FromStream(Sundries.DecodeWithString(vitalSignCurveDetail.SymbolEntry)));
                                    }
                                    catch
                                    {
                                        symbol = new MedSymbol(MedSymbolType.None);
                                    }
                                }
                                else
                                {
                                    symbol = new MedSymbol(vitalSignCurveDetail.SymbolType);
                                }

                                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Text)
                                {
                                    symbol.Text = vitalSignCurveDetail.SymbolEntry;
                                }

                                color = vitalSignCurveDetail.Color;
                                isDigit = vitalSignCurveDetail.ShowType == MedCurveShowType.Digit;
                                if (dict.ContainsKey(item))
                                {
                                    isDigit = dict[item].ShowType == MedCurveShowType.Digit;
                                    color = dict[item].Color;
                                }

                                curve = new MedVitalSignCurve(vitalSignCurveDetail.CurveName, item, vitalSignCurveDetail.YAxisIndex,
                                                              color, symbol, isDigit);
                                curve.DotNumber = vitalSignCurveDetail.DotNumber;
                            }
                            else
                            {
                                color = GetRandomColor();
                                isDigit = false;
                                symbol = GetRandomSymbol();
                                vitalSignCurveDetail = new MedVitalSignCurveDetail();
                                vitalSignCurveDetail.Color = color;
                                vitalSignCurveDetail.CurveCode = item;
                                vitalSignCurveDetail.CurveName = ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(item) ? ExtendAppContext.Current.MonitorFunctionCodeDict[item] : item;
                                vitalSignCurveDetail.DotNumber = 0;
                                vitalSignCurveDetail.ShowType = MedCurveShowType.Line;
                                vitalSignCurveDetail.SymbolEntry = "";
                                vitalSignCurveDetail.YAxisIndex = 0;
                                vitalSignCurveDetail.Visible = true;
                                control.CurveDetails.Add(vitalSignCurveDetail);
                                curve = new MedVitalSignCurve(vitalSignCurveDetail.CurveName, item, vitalSignCurveDetail.YAxisIndex,
                                                              color, symbol, isDigit);
                                curve.DotNumber = vitalSignCurveDetail.DotNumber;
                            }
                            if (symbol != null)
                            {
                                symbol.Size = 8f;
                            }

                            bool isModify = false;
                            if (curve != null)
                            {
                                if (vitallist != null)
                                    vitallist.ForEach(row =>
                                        {
                                            int mu = (int)((TimeSpan)(row.TIME_POINT - control.StartTime.AddSeconds(-control.StartTime.Second))).TotalMinutes;
                                            if (curve.IsDigit || control.InterValControl == InterValControlType.ControlAll)
                                            {
                                                string value = row.ITEM_VALUE;
                                                double d = 0;
                                                if (double.TryParse(value, out d) && d >= 0)
                                                {
                                                    if (dict.ContainsKey(curve.Code) && ((mu % (int)dict[curve.Code].ShowTimeInterval) == 0) &&
                                                        Convert.ToDouble(row.ITEM_VALUE) > 0)
                                                    {

                                                        if (vitalSignCurveDetail.HideStartTime != DateTime.MinValue)
                                                        {
                                                            if (vitalSignCurveDetail.HideStartTime == vitalSignCurveDetail.HideEndTime)
                                                            {
                                                                return;
                                                            }
                                                            else if (vitalSignCurveDetail.HideStartTime < vitalSignCurveDetail.HideEndTime)
                                                            {
                                                                if (row.TIME_POINT >= vitalSignCurveDetail.HideStartTime &&
                                                                    row.TIME_POINT <= vitalSignCurveDetail.HideEndTime)
                                                                {
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (row.TIME_POINT >= vitalSignCurveDetail.HideStartTime ||
                                                                    row.TIME_POINT <= vitalSignCurveDetail.HideEndTime)
                                                                {
                                                                    return;
                                                                }
                                                            }
                                                        }

                                                        if (IsModifyVitalSignShowDifferent)
                                                        {
                                                            isModify = false;
                                                            if (!string.IsNullOrEmpty(row.Flag) && row.Flag.Equals("1"))
                                                            {
                                                                isModify = true;
                                                            }

                                                            curve.Points.Add(new MedVitalSignPoint(row.TIME_POINT,
                                                                                                   Convert.ToDouble(row.ITEM_VALUE),
                                                                                                   curve,
                                                                                                   isModify));
                                                        }
                                                        else
                                                        {
                                                            curve.Points.Add(new MedVitalSignPoint(row.TIME_POINT,
                                                                                                   Convert.ToDouble(row.ITEM_VALUE),
                                                                                                   curve));
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (IsModifyVitalSignShowDifferent)
                                                    {
                                                        isModify = false;
                                                        if (!string.IsNullOrEmpty(row.Flag) && row.Flag.Equals("1"))
                                                        {
                                                            isModify = true;
                                                        }

                                                        curve.Points.Add(new MedVitalSignPoint(row.TIME_POINT, row.ITEM_VALUE, curve, isModify));
                                                    }
                                                    else
                                                    {
                                                        curve.Points.Add(new MedVitalSignPoint(row.TIME_POINT, row.ITEM_VALUE, curve));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToDouble(row.ITEM_VALUE) > 0)
                                                {
                                                    if (vitalSignCurveDetail.HideStartTime != DateTime.MinValue)
                                                    {
                                                        if (vitalSignCurveDetail.HideStartTime < vitalSignCurveDetail.HideEndTime)
                                                        {
                                                            if (row.TIME_POINT >= vitalSignCurveDetail.HideStartTime &&
                                                                row.TIME_POINT <= vitalSignCurveDetail.HideEndTime)
                                                            {
                                                                return;
                                                            }
                                                        }
                                                        else if (vitalSignCurveDetail.HideStartTime > vitalSignCurveDetail.HideEndTime)
                                                        {
                                                            if (row.TIME_POINT >= vitalSignCurveDetail.HideStartTime ||
                                                                row.TIME_POINT <= vitalSignCurveDetail.HideEndTime)
                                                            {
                                                                return;
                                                            }
                                                        }
                                                    }

                                                    if (IsModifyVitalSignShowDifferent)
                                                    {
                                                        isModify = false;
                                                        if (!string.IsNullOrEmpty(row.Flag) && row.Flag.Equals("1"))
                                                        {
                                                            isModify = true;
                                                        }

                                                        curve.Points.Add(new MedVitalSignPoint(row.TIME_POINT,
                                                                                               Convert.ToDouble(row.ITEM_VALUE),
                                                                                               curve,
                                                                                               isModify));
                                                    }
                                                    else
                                                    {

                                                        curve.Points.Add(new MedVitalSignPoint(row.TIME_POINT,
                                                                                               Convert.ToDouble(row.ITEM_VALUE),
                                                                                               curve));
                                                    }
                                                }
                                            }
                                        });
                                if (curve.Points.Count > 0)
                                {
                                    control.Curves.Add(curve);
                                }
                            }
                        }
                    }
                }

                // 事件标记
                if (control.HasEventMark)
                {
                    DateTime[] twStartTime = new DateTime[] { DateTime.MinValue, DateTime.MinValue, DateTime.MinValue };
                    DateTime[] twEndTime = new DateTime[] { DateTime.Now, DateTime.Now, DateTime.Now };
                    MedSymbol[] twSymbol = new MedSymbol[] { null, null, null };
                    EventMark eventMark = new EventMark();
                    eventMark.Title = "";// "标记";
                    Color color = Color.Black;
                    string alias = "";
                    MedSymbol symbol = null;
                    MedSymbolCurveDetail detail = null;

                    if (!dataSources.ContainsKey("MED_OPERATION_MASTER"))
                    {
                        throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.OperationMasterDataTable,请添加此绑定数据源!", "OperationMaster"));
                    }

                    MED_OPERATION_MASTER operationMasterDataTable = new ModelHandler<MED_OPERATION_MASTER>().FillModel(dataSources["MED_OPERATION_MASTER"].Rows[0]);
                    if (operationMasterDataTable != null)
                    {
                        if (_eventNo == "0")
                        {
                            if (operationMasterDataTable.ANES_START_TIME.HasValue)//麻醉开始
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable.ANES_START_TIME.Value, EventNames.ANESSTART);
                            }
                            if (operationMasterDataTable.START_DATE_TIME.HasValue)//手术开始
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable.START_DATE_TIME.Value, EventNames.OPERATIONSTART);
                            }
                            if (operationMasterDataTable.END_DATE_TIME.HasValue)//手术结束
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable.END_DATE_TIME.Value, EventNames.OPERATIONEND);
                            }
                            if (operationMasterDataTable.ANES_END_TIME.HasValue)//麻醉结束
                            {
                                AddAnesEventMark(control, eventMark, operationMasterDataTable.ANES_END_TIME.Value, EventNames.ANESEND);
                            }
                        }
                    }

                    string itemClass = this.GetAnesClassTypeString(AnesClassType.AnesDrug);
                    // 从事件表增加点
                    control.CPBTtimeList.Clear();
                    if (anesAllEvent != null)
                        anesAllEvent.ForEach(row =>
                        {
                            if (row.START_TIME.HasValue &&
                                !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) &&
                                !string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                                (row.EVENT_ITEM_NAME == "体外循环开始" || row.EVENT_ITEM_NAME == "体外循环结束" ||
                                 row.EVENT_ITEM_NAME == "阻断升主动脉" || row.EVENT_ITEM_NAME == "开放升主动脉")
                                && !control.CPBTtimeList.ContainsKey(row.START_TIME.Value))
                            {
                                control.CPBTtimeList.Add(row.START_TIME.Value, row.EVENT_ITEM_NAME);
                            }
                        });
                    if (anesEvent != null)
                        anesEvent.ForEach(row =>
                            {
                                if (row.START_TIME.HasValue &&
                                    !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) &&
                                    !string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                                    (row.EVENT_ITEM_NAME == "体外循环开始" || row.EVENT_ITEM_NAME == "体外循环结束" ||
                                     row.EVENT_ITEM_NAME == "阻断升主动脉" || row.EVENT_ITEM_NAME == "开放升主动脉") &&
                                     !control.CPBTtimeList.ContainsKey(row.START_TIME.Value))
                                {
                                    control.CPBTtimeList.Add(row.START_TIME.Value, row.EVENT_ITEM_NAME);
                                }

                                if (row.START_TIME.HasValue &&
                                    !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) &&
                                    !string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                                    !row.EVENT_CLASS_CODE.Equals(itemClass))
                                {
                                    ///麻醉特殊处理
                                    if (IsAnesthesiaEvent(row.EVENT_ITEM_NAME))
                                    {
                                        return;
                                    }

                                    symbol = null;
                                    detail = GetVitalSignEventMark(control, row.EVENT_ITEM_NAME);
                                    color = Color.Black;
                                    alias = "";
                                    if (detail != null)
                                    {
                                        symbol = new MedSymbol(detail.SymbolType);
                                        if (symbol.SymbolType == MedSymbolType.Text)
                                        {
                                            symbol.Text = detail.SymbolEntry;
                                        }

                                        color = detail.Color;
                                    }
                                    else
                                    {
                                        if (IsOperationEvent(row.EVENT_ITEM_NAME))
                                        {
                                            detail = GetVitalSignEventMark(control, "手术");
                                            if (detail != null)
                                            {
                                                symbol = new MedSymbol(detail.SymbolType);
                                                if (symbol.SymbolType == MedSymbolType.Text)
                                                {
                                                    symbol.Text = detail.SymbolEntry;
                                                }
                                                color = detail.Color;
                                                alias = "手术";
                                            }
                                            else
                                            {
                                                symbol = new MedSymbol(MedSymbolType.Operation);
                                            }
                                        }
                                        else if (row.EVENT_CLASS_CODE.Equals(GetAnesClassTypeString(AnesClassType.PutPipe)))
                                        {
                                            detail = GetVitalSignEventMark(control, "插管");
                                            if (detail != null)
                                            {
                                                symbol = new MedSymbol(detail.SymbolType);
                                                if (symbol.SymbolType == MedSymbolType.Text)
                                                {
                                                    symbol.Text = detail.SymbolEntry;
                                                }
                                                color = detail.Color;
                                                alias = "插管";
                                            }
                                        }
                                        else if (row.EVENT_CLASS_CODE.Equals(GetAnesClassTypeString(AnesClassType.ZhiGuan)))
                                        {
                                            detail = GetVitalSignEventMark(control, "置管");
                                            if (detail != null)
                                            {
                                                symbol = new MedSymbol(detail.SymbolType);
                                                if (symbol.SymbolType == MedSymbolType.Text)
                                                {
                                                    symbol.Text = detail.SymbolEntry;
                                                }
                                                color = detail.Color;
                                                alias = "置管";
                                            }
                                        }
                                        else if (row.EVENT_CLASS_CODE.Equals(GetAnesClassTypeString(AnesClassType.PullPipe)))
                                        {
                                            detail = GetVitalSignEventMark(control, "拔管");
                                            if (detail != null)
                                            {
                                                symbol = new MedSymbol(detail.SymbolType);
                                                if (symbol.SymbolType == MedSymbolType.Text)
                                                {
                                                    symbol.Text = detail.SymbolEntry;
                                                }
                                                color = detail.Color;
                                                alias = "拔管";
                                            }
                                        }
                                    }
                                    if (symbol != null)
                                    {
                                        symbol.Size = 8f;
                                        symbol.Pen = new Pen(color);
                                        eventMark.AddPoint(row.START_TIME.Value, 0, row.EVENT_ITEM_NAME, symbol, color, alias);
                                    }
                                }
                            });

                    // 从明细增加点
                    MedAnesSheetDetails anesDetail = null;
                    foreach (IUIElementHandler handler in this.MedicalPaperUIElementHandlers)
                    {
                        if (handler.GetControlType == typeof(MedAnesSheetDetails) && handler.GetCurrentControl != null)
                        {
                            anesDetail = handler.GetCurrentControl as MedAnesSheetDetails;
                        }
                    }

                    if (anesDetail != null)
                    {
                        foreach (MedAnesSheetDetailCollection collection in anesDetail.Collections)
                        {
                            if (collection != null && collection.Points != null)
                            {
                                foreach (MedAnesSheetDetailPoint point in collection.Points)
                                {
                                    ///麻醉特殊处理
                                    if (IsAnesthesiaEvent(point.Text)) continue;
                                    EventMarkPoint p = eventMark.Points.Find(new Predicate<EventMarkPoint>(delegate(EventMarkPoint empt)
                                    {
                                        return empt.Text.Equals(point.Text) && empt.TimePoint.Equals(point.StartTime);
                                    }));
                                    if (p == null)
                                    {
                                        eventMark.AddPoint(point.StartTime, point.Index, point.Text, null, point.Color, point.Text);
                                    }
                                }
                            }
                        }
                    }

                    eventMark.ReSort();
                    control.EventMark = eventMark;
                }

                if (!string.IsNullOrEmpty(control.BreathPara1) &&
                    !string.IsNullOrEmpty(control.BreathPara2) &&
                    !string.IsNullOrEmpty(control.BreathPara3))
                {
                    control.BreathParaName1 = DataContext.GetCurrent().GetMonitorFunctionName(control.BreathPara1);
                    control.BreathParaName2 = DataContext.GetCurrent().GetMonitorFunctionName(control.BreathPara2);
                    control.BreathParaName3 = DataContext.GetCurrent().GetMonitorFunctionName(control.BreathPara3);
                }

                // 呼吸控制
                this.ControlBreath(anesEvent, control, dict);

                // 血气记录
                control.BloodGasItems = DataContext.GetCurrent().GetBloodGasItems(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                                  ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                                  ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
            }
        }

        /// <summary>
        /// 将界面数据绑定到数据库
        /// </summary>
        public override void BindUIToData(MedVitalSignGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
        }

        /// <summary>
        /// 重写控件设置
        /// </summary>
        public override void ControlSetting(MedVitalSignGraph control)
        {
            control.Curves.Clear();
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;

            // 自定义事件，暂时注释，请勿删除
            //control.ValueChanged -= new EventHandler<VitalSignPointEventArgs>(_vitalGraph_ValueChanged);
            //control.ValueChanged += new EventHandler<VitalSignPointEventArgs>(_vitalGraph_ValueChanged);
            //control.ControlBreathStartDoubleClick -= new EventHandler(control_ControlBreathStartDoubleClick);
            //control.ControlBreathStartDoubleClick += new EventHandler(control_ControlBreathStartDoubleClick);
            control.SignPointMouseMove += new EventHandler<VitalSignPointEventArgs>(control_SignPointMouseMove);
            control.NewMonitorData = new NewMonitorData(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                        ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                        ExtendAppContext.Current.PatientInformationExtend.OPER_ID,
                                                        ExtendAppContext.Current.EventNo,
                                                        ExtendAppContext.Current.LoginUser.USER_JOB_ID);
            control.CanUpdate = true;
            control.CustomDraw += new PaintEventHandler(control_CustomDraw);
        }

        /// <summary>
        /// 自定义绘制事件
        /// </summary>
        void control_CustomDraw(object sender, PaintEventArgs e)
        {
            MedVitalSignGraph vitalGraph = sender as MedVitalSignGraph;
            if (vitalGraph != null && !string.IsNullOrEmpty(vitalGraph.BreathPara1) && !string.IsNullOrEmpty(vitalGraph.BreathPara2) && !string.IsNullOrEmpty(vitalGraph.BreathPara3))
            {
                string breathParaName1 = DataContext.GetCurrent().GetMonitorFunctionName(vitalGraph.BreathPara1);
                string breathParaName2 = DataContext.GetCurrent().GetMonitorFunctionName(vitalGraph.BreathPara2);
                string breathParaName3 = DataContext.GetCurrent().GetMonitorFunctionName(vitalGraph.BreathPara3);
                this.DrawControlBreathPara(e.Graphics, Pens.Black, vitalGraph.LegendFont,
                                           Brushes.Black, new PointF((float)(vitalGraph.OriginRect.X + vitalGraph.TitleWidth + 40),
                                           (float)(vitalGraph.OriginRect.Height - vitalGraph.EventMarkHeight / 2)), 4,
                                           new List<string>(new string[] { breathParaName1, breathParaName2, breathParaName3 }));
            }

            // 绘制标题
            e.Graphics.DrawString("标    记", vitalGraph.Font, Brushes.Black, vitalGraph.OriginRect.Width * vitalGraph.LeftWidthPercent - 65,
                                  vitalGraph.OriginRect.Height - 17);
        }

        /// <summary>
        /// 绘制呼吸曲线
        /// </summary>
        private void DrawControlBreathPara(Graphics g, Pen pen, Font font, Brush brush, PointF pointF, float lineLength, List<string> list)
        {
            g.DrawLine(pen, pointF.X, pointF.Y - lineLength, pointF.X, pointF.Y);
            string text = list[1];
            g.DrawString(text, font, brush, pointF.X - g.MeasureString(text, font).Width / 2,
                         pointF.Y - lineLength - g.MeasureString(text, font).Height);
            float lineLength1 = lineLength * (float)Math.Tan(Math.PI / 4);
            g.DrawLine(pen, pointF.X, pointF.Y, pointF.X - lineLength1, pointF.Y + lineLength1);
            text = list[0];
            g.DrawString(text, font, brush, pointF.X - lineLength1 - g.MeasureString(text, font).Width, pointF.Y + lineLength1);
            g.DrawLine(pen, pointF.X, pointF.Y, pointF.X + lineLength1, pointF.Y + lineLength1);
            text = list[2];
            g.DrawString(text, font, brush, pointF.X + lineLength1, pointF.Y + lineLength1);
        }

        /// <summary>
        /// 鼠标选中曲线节点移动
        /// </summary>
        void control_SignPointMouseMove(object sender, VitalSignPointEventArgs e)
        {
            MedVitalSignGraph control = sender as MedVitalSignGraph;
            List<MED_OPERATION_MASTER> operationMasterDataTable = null;
            try
            {
                operationMasterDataTable = new ModelHandler<MED_OPERATION_MASTER>().FillModel(base.DataSource["MED_OPERATION_MASTER"]);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, false);
            }

            if (operationMasterDataTable != null && operationMasterDataTable.Count == 1)
            {
                MED_OPERATION_MASTER masterRow = operationMasterDataTable[0];
                if (ExtendAppContext.Current.EventNo == "0")
                {
                    if (masterRow.IN_PACU_DATE_TIME.HasValue && !string.IsNullOrEmpty(masterRow.IN_PACU_DATE_TIME.ToString()))
                    {
                        if (e.Point.Time >= masterRow.IN_PACU_DATE_TIME)
                        {
                            control.SetCurrentPosMove(false);
                        }
                    }
                }
                else if (ExtendAppContext.Current.EventNo == "1")
                {
                    if (masterRow.OUT_DATE_TIME.HasValue && !string.IsNullOrEmpty(masterRow.OUT_DATE_TIME.ToString()))
                    {
                        if (e.Point.Time <= masterRow.OUT_DATE_TIME)
                        {
                            control.SetCurrentPosMove(false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 双击呼吸开始时间
        /// </summary>
        private void control_ControlBreathStartDoubleClick(object sender, EventArgs e)
        {
            MedVitalSignGraph vitalSignGraph = sender as MedVitalSignGraph;
            if (vitalSignGraph != null && vitalSignGraph.SelectedPoint != null && vitalSignGraph.SelectedBreathControlTime != null)
            {
                if (!string.IsNullOrEmpty(vitalSignGraph.BreathPara1) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara2) && !string.IsNullOrEmpty(vitalSignGraph.BreathPara3))
                {
                    UserControl_BreathParas breathParas;
                    if (vitalSignGraph.BreathParalList.ContainsKey(vitalSignGraph.SelectedPoint.Time) &&
                        !string.IsNullOrEmpty(vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para1) &&
                        !string.IsNullOrEmpty(vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para2) &&
                        !string.IsNullOrEmpty(vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para3))
                    {
                        breathParas = new UserControl_BreathParas(vitalSignGraph.SelectedPoint.Time,
                                                                  vitalSignGraph.BreathPara1,
                                                                  vitalSignGraph.BreathPara2,
                                                                  vitalSignGraph.BreathPara3,
                                                                  vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para1,
                                                                  vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para2,
                                                                  vitalSignGraph.BreathParalList[vitalSignGraph.SelectedPoint.Time].Para3);
                    }
                    else
                    {
                        breathParas = new UserControl_BreathParas(vitalSignGraph.SelectedPoint.Time,
                                                                  vitalSignGraph.BreathPara1,
                                                                  vitalSignGraph.BreathPara2,
                                                                  vitalSignGraph.BreathPara3);
                    }

                    DialogHostFormPC dialogHostForm = new DialogHostFormPC("呼吸参数", breathParas.Width, breathParas.Height);
                    dialogHostForm.Child = breathParas;
                    dialogHostForm.ShowDialog();
                    if (breathParas.ResultList != null && breathParas.ResultList.Count == 3)
                    {
                        if (DataContext.GetCurrent().SetBreathParas(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                    ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                    ExtendAppContext.Current.PatientInformationExtend.OPER_ID,
                                                                    vitalSignGraph.SelectedPoint.Time,
                                                                    vitalSignGraph.BreathPara1,
                                                                    vitalSignGraph.BreathPara2,
                                                                    vitalSignGraph.BreathPara3,
                                                                    breathParas.ResultList[0],
                                                                    breathParas.ResultList[1],
                                                                    breathParas.ResultList[2]))
                        {
                            this.RefreshData();
                            vitalSignGraph.Invalidate();
                        }
                    }
                    if (breathParas.delBreathParas)//取消呼吸模式
                    {
                        if (DataContext.GetCurrent().SetBreathParas(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                    ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                    ExtendAppContext.Current.PatientInformationExtend.OPER_ID,
                                                                    vitalSignGraph.SelectedPoint.Time,
                                                                    vitalSignGraph.BreathPara1,
                                                                    vitalSignGraph.BreathPara2,
                                                                    vitalSignGraph.BreathPara3,
                                                                    null, null, null))
                        {
                            this.RefreshData();
                            vitalSignGraph.Invalidate();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 呼吸控制
        /// </summary>
        protected void ControlBreath(List<MED_ANESTHESIA_EVENT> anesEvent,
                                     MedVitalSignGraph vitalSignGraph,
                                     Dictionary<string, MedVitalSignCurveDetail> dict)
        {
            if (anesEvent != null)
            {
                List<MED_ANESTHESIA_EVENT> rows = anesEvent.Where(x => !string.IsNullOrEmpty(x.EVENT_ITEM_NAME) &&
                                                                       x.EVENT_ITEM_NAME.Contains("呼吸")).ToList();
                if (rows.Count == 0)
                {
                    return;
                }

                // 最大体征时间
                DateTime maxVitalSignTime = DateTime.MaxValue;
                // 控制呼吸时间列表
                List<MedVitalSignBreathControlTime> listControlTime = new List<MedVitalSignBreathControlTime>();
                // 获取体征当前时间 及 呼吸曲线
                MedVitalSignCurve curveBreath = null;
                for (int i = 0; i < vitalSignGraph.Curves.Count; i++)
                {
                    if (vitalSignGraph.Curves[i].Text.Contains("呼吸"))
                    {
                        curveBreath = vitalSignGraph.Curves[i];
                        continue;
                    }
                    for (int j = 0; j < vitalSignGraph.Curves[i].Points.Count; j++)
                    {
                        if (maxVitalSignTime == DateTime.MaxValue)
                        {
                            maxVitalSignTime = vitalSignGraph.Curves[i].Points[j].Time;
                        }
                        else if (maxVitalSignTime < vitalSignGraph.Curves[i].Points[j].Time)
                        {
                            maxVitalSignTime = vitalSignGraph.Curves[i].Points[j].Time;
                        }
                    }
                }

                // 生成曲线
                if (curveBreath == null)
                {
                    foreach (MedVitalSignCurveDetail detail in vitalSignGraph.CurveDetails)
                    {
                        if (detail.CurveName.Contains("呼吸"))
                        {
                            curveBreath = CreateCurve(detail);
                            vitalSignGraph.Curves.Add(curveBreath);
                            break;
                        }
                    }
                }

                if (curveBreath != null)
                {
                    curveBreath.LineMaxscale = 20;
                    vitalSignGraph.BreathControlTime.Clear();
                    vitalSignGraph.BreathParalList.Clear();
                    listControlTime.AddRange(BreathTimeList("自主呼吸", anesEvent, vitalSignGraph, dict));
                    listControlTime.AddRange(BreathTimeList("控制呼吸", anesEvent, vitalSignGraph, dict));
                    listControlTime.AddRange(BreathTimeList("辅助呼吸", anesEvent, vitalSignGraph, dict));

                    // 排序 listControlTime
                    listControlTime.Sort(new Comparison<MedVitalSignBreathControlTime>
                        (delegate(MedVitalSignBreathControlTime controlTime1,
                                  MedVitalSignBreathControlTime controlTime2)
                        {
                            return controlTime1.oStartTime.CompareTo(controlTime2.oStartTime);
                        }));

                    // 调整  listControlTime ，使得时间无重叠 
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

                    // 删除所有时间段内的点
                    MedVitalSignPoint point = null;
                    for (int kk = 0; kk < listControlTime.Count; kk++)
                    {
                        DateTimeRange range = new DateTimeRange(listControlTime[kk].startTime, listControlTime[kk].endTime);
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
                        while (dt <= range.EndDateTime)
                        {
                            point = new MedVitalSignPoint(dt, listControlTime[kk].breathValue, curveBreath);
                            curveBreath.Points.Add(point);
                            dt = dt.AddMinutes(listControlTime[kk].showTimeInterval);
                        }

                        curveBreath.Points.Sort(new Comparison<MedVitalSignPoint>(delegate(MedVitalSignPoint point1, MedVitalSignPoint point2)
                        {
                            return point1.Time.CompareTo(point2.Time);
                        }));
                    }
                }

                vitalSignGraph.BreathControlTimeList = listControlTime;
            }
        }

        /// <summary>
        /// 获取呼吸时间列表
        /// </summary>
        private List<MedVitalSignBreathControlTime> BreathTimeList(string breathType,
                                                                   List<MED_ANESTHESIA_EVENT> anesEvent,
                                                                   MedVitalSignGraph vitalSignGraph,
                                                                   Dictionary<string, MedVitalSignCurveDetail> dict)
        {
            double dBreathValue = -1;
            DateTime controlStartTime = DateTime.MinValue;
            DateTime controlEndTime = DateTime.MaxValue;
            List<MED_ANESTHESIA_EVENT> rows = anesEvent.Where(x => x.EVENT_ITEM_NAME.Contains(breathType)).ToList();

            // 控制呼吸时间列表
            List<MedVitalSignBreathControlTime> listControlTime = new List<MedVitalSignBreathControlTime>();
            DateTime sysDatetTime = GetSysDateTime();
            if (rows != null)
            {
                rows.ForEach(anesthesiaEventRow =>
                    {
                        // 初始化值
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

                        // 有开始时间  并且有体征数据 并且有呼吸值
                        if (controlStartTime != DateTime.MinValue && dBreathValue >= 0)
                        {
                            // 没有结束时间
                            if (controlEndTime == DateTime.MaxValue)
                            {
                                controlEndTime = (sysDatetTime < PagerSetting.PageTimeSpan.OrigiEndDateTime) ? sysDatetTime : PagerSetting.PageTimeSpan.OrigiEndDateTime;
                            }

                            DateTimeRange range = new DateTimeRange(controlStartTime, controlEndTime);
                            AdjustDateTimeRange(TimeScaleType.FiveMinute, ref range);

                            //控制呼吸
                            MedVitalSignBreathControlTime breathControlTime = new MedVitalSignBreathControlTime();
                            breathControlTime.startTime = range.StartDateTime;
                            breathControlTime.endTime = range.EndDateTime;
                            breathControlTime.oStartTime = controlStartTime;
                            breathControlTime.oEndTime = controlEndTime;
                            breathControlTime.breathValue = dBreathValue;

                            int timeSpan = 10;
                            string breathName = "呼吸";
                            Color color = Color.Magenta;
                            // 设置初始值
                            foreach (MedVitalSignCurveDetail detail in dict.Values)
                            {
                                if (detail.CurveName.Equals("呼吸"))
                                {
                                    color = detail.Color;
                                    break;
                                }
                            }

                            foreach (MedVitalSignCurveDetail detail in dict.Values)
                            {
                                if (breathType == "自主呼吸")
                                {
                                    breathName = "呼吸";
                                }
                                else
                                {
                                    breathName = breathType;
                                }

                                if (detail.CurveName.Equals(breathName))
                                {
                                    color = detail.Color;
                                    switch (detail.ShowTimeInterval)
                                    {
                                        case MedShowTimeInterval.Five:
                                            timeSpan = 5;
                                            break;
                                        case MedShowTimeInterval.Fifiteen:
                                            timeSpan = 15;
                                            break;
                                        case MedShowTimeInterval.Ten:
                                            timeSpan = 10;
                                            break;
                                        case MedShowTimeInterval.Twenty:
                                            timeSpan = 20;
                                            break;
                                        case MedShowTimeInterval.HalfHour:
                                            timeSpan = 30;
                                            break;
                                        case MedShowTimeInterval.Hour:
                                            timeSpan = 60;
                                            break;
                                    }
                                }
                            }

                            breathControlTime.showTimeInterval = timeSpan;
                            breathControlTime.curveColor = color;
                            if (breathType.Contains("控制呼吸"))
                            {
                                breathControlTime.BreathType = BreathControlType.ControlBreath;
                                if (!string.IsNullOrEmpty(vitalSignGraph.BreathPara1) &&
                                    !string.IsNullOrEmpty(vitalSignGraph.BreathPara2) &&
                                    !string.IsNullOrEmpty(vitalSignGraph.BreathPara3))
                                {
                                    List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable =
                                        AnesInfoService.ClientInstance.GetPatMonitorExtList(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                                            ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                                            ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                                    if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
                                    {
                                        List<MED_PAT_MONITOR_DATA_EXT> rows1 = patMonitorDataExtDataTable.Where(x => x.ITEM_CODE == vitalSignGraph.BreathPara1 ||
                                                                                                                     x.ITEM_CODE == vitalSignGraph.BreathPara2 ||
                                                                                                                     x.ITEM_CODE == vitalSignGraph.BreathPara3).ToList();
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
                            {
                                breathControlTime.BreathType = BreathControlType.HelpBreath;
                            }
                            else if (breathType.Contains("自主呼吸"))
                            {
                                breathControlTime.BreathType = BreathControlType.FreeBreath;
                            }

                            listControlTime.Add(breathControlTime);
                        }
                    });
            }

            return listControlTime;
        }

        /// <summary>
        /// 创建体征曲线
        /// </summary>
        private MedVitalSignCurve CreateCurve(MedVitalSignCurveDetail vitalSignCurveDetail)
        {
            Color color;
            bool isDigit = false;
            MedVitalSignCurve curve = null;
            MedSymbol symbol = null;
            if (vitalSignCurveDetail != null)
            {
                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Image)
                {
                    try
                    {
                        symbol = new MedSymbol(Image.FromStream(Sundries.DecodeWithString(vitalSignCurveDetail.SymbolEntry)));
                    }
                    catch
                    {
                        symbol = new MedSymbol(MedSymbolType.None);
                    }
                }
                else
                {
                    symbol = new MedSymbol(vitalSignCurveDetail.SymbolType);
                }
                if (vitalSignCurveDetail.SymbolType == MedSymbolType.Text)
                {
                    symbol.Text = vitalSignCurveDetail.SymbolEntry;
                }

                color = vitalSignCurveDetail.Color;
                isDigit = vitalSignCurveDetail.ShowType == MedCurveShowType.Digit;
                curve = new MedVitalSignCurve(vitalSignCurveDetail.CurveName,
                                              vitalSignCurveDetail.CurveCode,
                                              vitalSignCurveDetail.YAxisIndex,
                                              color, symbol, isDigit);
                curve.DotNumber = vitalSignCurveDetail.DotNumber;
            }

            return curve;
        }

        /// <summary>
        /// ValueChanged事件响应
        /// </summary>
        private void _vitalGraph_ValueChanged(object sender, VitalSignPointEventArgs e)
        {
            MedVitalSignGraph control = sender as MedVitalSignGraph;
            if (control.NewMonitorData != null)
            {
                control.NewMonitorData.SetItem(e.Point.Time, e.Point.Curve.Text, e.Point.Value.ToString(),
                                               e.OldValue.ToString(), e.Point.Curve.Code);
                List<MED_VITAL_SIGN> _VitalSignData = new ModelHandler<MED_VITAL_SIGN>().FillModel(base.DataSource["VitalSignData"]);
                MED_VITAL_SIGN vitalSignRow = _VitalSignData.Where(x => x.TIME_POINT == e.Point.Time &&
                                                                   x.ITEM_CODE == e.Point.Curve.Code).FirstOrDefault();
                if (vitalSignRow != null)
                {
                    vitalSignRow.ITEM_VALUE = e.Point.Value.ToString();
                    base.DataSource["VitalSignData"] = new ModelHandler<MED_VITAL_SIGN>().FillDataTable(_VitalSignData);
                }

                base.HasDirty = true;
            }
        }

        #region MyRegion
        private ContextMenuStrip CreatVitalGraphMenu()
        {
#pragma warning disable 2000
            ContextMenuStrip popupMenu = new ContextMenuStrip();
            popupMenu.Items.Add("个性化体征显示", null, new EventHandler(toolStripMenuItemVitalShowSet_Click));
            // popupMenu.Items.Add("密集体征显示", null, new EventHandler(toolStripMenuItemMiJiVitalShow_Click));
            popupMenu.Items.Add("取消血气", null, new EventHandler(toolStripMenuItemCanelBloodGas_Click));
            popupMenu.Opening += new System.ComponentModel.CancelEventHandler(popupMenu_Opening);
            return popupMenu;
        }
        #endregion
        #region MyRegion

        /// <summary>
        /// 弹出菜单栏
        /// </summary>
        private void popupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
                }
            }

            if (vitalGraph == null)
            {
                return;
            }

            _currentGraph = vitalGraph;
            if (vitalGraph.IsMouseInMark)
            {
                e.Cancel = true;
                if (vitalGraph.MousePostion.X > 0 && vitalGraph.MousePostion.Y > 0 && vitalGraph.MouseTime > DateTime.MinValue)
                {
                    _currentTime = vitalGraph.MouseTime;
                    List<MED_EVENT_DICT> eventList = ApplicationModel.Instance.AllDictList.EventDictList;//ExtendAppContext.Current.CommDict.EventDict;
                    List<MED_EVENT_DICT> eventFilerList = eventList.Where(x => x.EVENT_CLASS_CODE == "1" ||
                                                                          x.EVENT_CLASS_CODE == "7" ||
                                                                          x.EVENT_CLASS_CODE == "8" ||
                                                                          x.EVENT_CLASS_CODE == "9" ||
                                                                          x.EVENT_CLASS_CODE == "A" ||
                                                                          x.EVENT_CLASS_CODE == "U" ||
                                                                          x.EVENT_CLASS_CODE == "Y").ToList();
                    eventFilerList = eventFilerList.OrderBy(x => x.EVENT_CLASS_CODE).OrderBy(x => x.EVENT_ITEM_CODE).ToList();
                    DataTable sourceTable = new ModelHandler<MED_EVENT_DICT>().FillDataTable(eventFilerList);
                    PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, _currentGraph.MousePostion, _currentTime, this, "事件", "0");
                }
            }
            else
            {
                if (vitalGraph.MouseTime >= vitalGraph.StartTime && vitalGraph.MouseTime <= vitalGraph.EndTime && vitalGraph.SelectedBlood != null)
                {
                    vitalGraph.ContextMenuStrip.Items[1].Visible = true; ;
                }
                else
                {
                    vitalGraph.ContextMenuStrip.Items[1].Visible = false;
                }
            }
        }

        /// <summary>
        /// 血气菜单栏
        /// </summary>
        private void toolStripMenuItemCanelBloodGas_Click(object sender, EventArgs e)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
                }
            }

            if (DataContext.GetCurrent().CancelBloodGas(vitalGraph))
            {
                RefreshData();
                vitalGraph.Invalidate();
            }
        }

        /// <summary>
        /// 密集体征菜单栏
        /// </summary>
        private void toolStripMenuItemMiJiVitalShow_Click(object sender, EventArgs e)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
                }
            }

            // 个性化功能，暂时注释，请勿删除
            if (vitalGraph != null)
            {
                //XtraForm form = new XtraForm();
                //form.StartPosition = FormStartPosition.CenterScreen;
                //form.Width = 1000;
                //form.Height = 700;
                //MijiVitalSign mijiVitalSign = new MijiVitalSign(vitalGraph, _eventNo);
                //mijiVitalSign.Dock = DockStyle.Fill;
                //form.Controls.Add(mijiVitalSign);
                //form.Text = "密集体征显示";
                //form.ShowDialog();
            }
        }

        /// <summary>
        /// 个性化体征显示设置
        /// </summary>
        private void toolStripMenuItemVitalShowSet_Click(object sender, EventArgs e)
        {
            List<MedVitalSignCurveDetail> list = GetUserVitalShowSet(_eventNo);
            Dictionary<string, MedVitalSignCurveDetail> dict = new Dictionary<string, MedVitalSignCurveDetail>();
            List<MED_VITAL_SIGN> _VitalSignData = new ModelHandler<MED_VITAL_SIGN>().FillModel(base.DataSource["VitalSignData"]);
            foreach (MedVitalSignCurveDetail vitalSet in list)
            {
                if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !dict.ContainsKey(vitalSet.CurveCode))
                {
                    dict.Add(vitalSet.CurveCode, vitalSet);
                }
                else if (string.IsNullOrEmpty(vitalSet.CurveCode) && !string.IsNullOrEmpty(vitalSet.CurveName))
                {
                    foreach (MED_VITAL_SIGN vrow in _VitalSignData)
                    {
                        if (vrow.ITEM_NAME.Equals(vitalSet.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                        {
                            dict.Add(vrow.ITEM_CODE, vitalSet);
                            break;
                        }
                    }
                }
            }

            MedVitalSignGraph _vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    _vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
                }
            }

            if (_vitalGraph != null)
            {
                foreach (MedVitalSignCurve curve in _vitalGraph.Curves)
                {
                    if (!string.IsNullOrEmpty(curve.Code) && !dict.ContainsKey(curve.Code))
                    {
                        MedVitalSignCurveDetail vitalSet = new MedVitalSignCurveDetail();
                        vitalSet.CurveName = curve.Text;
                        vitalSet.CurveCode = string.IsNullOrEmpty(curve.Code) ? curve.Text : curve.Code;
                        vitalSet.Color = curve.Color;
                        if (GetVitalSignDetail(_vitalGraph, vitalSet.CurveCode) != null)
                        {
                            vitalSet.ShowTimeInterval = GetVitalSignDetail(_vitalGraph, vitalSet.CurveCode).ShowTimeInterval;
                        }
                        if (curve.IsDigit)
                        {
                            vitalSet.ShowType = MedCurveShowType.Digit;
                        }
                        vitalSet.SymbolType = curve.Symbol.SymbolType;
                        if (vitalSet.SymbolType == MedSymbolType.Text)
                        {
                            vitalSet.SymbolEntry = curve.Symbol.Text;
                        }
                        vitalSet.YAxisIndex = curve.YAxisIndex;
                        vitalSet.DotNumber = curve.DotNumber;
                        if (!dict.ContainsKey(vitalSet.CurveCode))
                        {
                            dict.Add(vitalSet.CurveCode, vitalSet);
                            list.Add(vitalSet);
                        }
                    }
                }
            }

            MedVitalSignCurveDetail breath = null;
            MedVitalSignCurveDetail contrlbreath = null;
            MedVitalSignCurveDetail helpbreath = null;
            foreach (MedVitalSignCurveDetail vitalSet in list)
            {
                if (vitalSet.CurveName == "呼吸")
                {
                    breath = vitalSet;
                }
                else if (vitalSet.CurveName == "控制呼吸")
                {
                    contrlbreath = vitalSet;
                }
                else if (vitalSet.CurveName == "辅助呼吸")
                {
                    helpbreath = vitalSet;
                }
            }

            if (breath != null && contrlbreath == null)
            {
                MedVitalSignCurveDetail vitalSet = new MedVitalSignCurveDetail();
                vitalSet.CurveName = "控制呼吸";
                vitalSet.Color = breath.Color;
                vitalSet.CurveCode = "kzhx";
                vitalSet.DotNumber = breath.DotNumber;
                vitalSet.ShowTimeInterval = breath.ShowTimeInterval;
                vitalSet.SymbolEntry = breath.SymbolEntry;
                vitalSet.SymbolType = breath.SymbolType;
                vitalSet.Visible = breath.Visible;
                vitalSet.YAxisIndex = breath.YAxisIndex;
                list.Add(vitalSet);
            }

            if (breath != null && helpbreath == null)
            {
                MedVitalSignCurveDetail vitalSet = new MedVitalSignCurveDetail();
                vitalSet.CurveName = "辅助呼吸";
                vitalSet.Color = breath.Color;
                vitalSet.CurveCode = "fzhx";
                vitalSet.DotNumber = breath.DotNumber;
                vitalSet.ShowTimeInterval = breath.ShowTimeInterval;
                vitalSet.SymbolEntry = breath.SymbolEntry;
                vitalSet.SymbolType = breath.SymbolType;
                vitalSet.Visible = breath.Visible;
                vitalSet.YAxisIndex = breath.YAxisIndex;
                list.Add(vitalSet);
            }

            DialogResult result = DialogResult.Cancel;
            using (VitalSignShowEditor vitalSignShowEditor = new VitalSignShowEditor(list))
            {
                using (DialogHostFormPC dialogHostForm = new DialogHostFormPC(vitalSignShowEditor.Caption,
                                                                              vitalSignShowEditor.Width,
                                                                              vitalSignShowEditor.Height))
                {
                    dialogHostForm.Child = vitalSignShowEditor;
                    dialogHostForm.Text = "个性化体征显示设置";
                    result = dialogHostForm.ShowDialog();
                }
            }

            if (result == DialogResult.OK)
            {
                string tableName = "UserVitalShowSet" + ((Convert.ToInt32(_eventNo) < 0) ? "0" : _eventNo);
                using (DataTable dataTable = new DataTable(tableName))
                {
                    //复苏单可约定数据表名称为UserVitalShowSet1,末尾与EventNo关联
                    System.Reflection.PropertyInfo[] propertyInfos = typeof(MedVitalSignCurveDetail).GetProperties();
                    foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                    {
                        dataTable.Columns.Add(propertyInfo.Name);
                    }
                    foreach (MedVitalSignCurveDetail obj in list)
                    {
                        DataRow row = dataTable.NewRow();
                        foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                        {
                            row[propertyInfo.Name] = AssemblyHelper.GetPropertyValue(propertyInfo, obj);
                        }

                        dataTable.Rows.Add(row);
                    }
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        dataTable.WriteXml(stream);
                        stream.Position = 0;
                        byte[] bytes = FileHelper.StreamToBytes(stream);
                        MED_PATIENT_MONITOR_CONFIG configRow =
                            AnesInfoService.ClientInstance.GetPatientMonitorConfig(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                                   ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                                   ExtendAppContext.Current.PatientInformationExtend.OPER_ID,
                                                                                   _eventNo);
                        if (configRow == null)
                        {
                            configRow = new MED_PATIENT_MONITOR_CONFIG();
                            configRow.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                            configRow.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                            configRow.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                            configRow.EVENT_NO = _eventNo;
                        }

                        configRow.CONTENT = bytes;
                        if (AnesInfoService.ClientInstance.updatePatMonitorConfig(configRow))
                        {
                            RefreshData();
                            _vitalGraph.Invalidate();
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 从曲线明细设置集合读取曲线明细
        /// </summary>
        private MedVitalSignCurveDetail GetVitalSignDetail(MedVitalSignGraph vitalSignGraph, string itemCode)
        {
            foreach (MedVitalSignCurveDetail detail in vitalSignGraph.CurveDetails)
            {
                if (!string.IsNullOrEmpty(detail.CurveCode))
                {
                    if (detail.CurveCode.ToLower().Trim().Equals(itemCode.ToLower().Trim()))
                    {
                        return detail;
                    }
                }
                else
                {
                    if (detail.CurveName.ToLower().Trim().Equals(itemCode.ToLower().Trim()))//兼容以前曲线以Name为唯一标示
                    {
                        return detail;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 是否为麻醉事件
        /// </summary>
        public static bool IsAnesthesiaEvent(string eventName)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(eventName))
            {
                string ev = eventName.Trim();
                result = ev.Equals(EventNames.ANESSTART) || ev.Equals(EventNames.ANESEND);
            }

            return result;
        }

        /// <summary>
        /// 获取曲线图标
        /// </summary>
        private MedSymbolCurveDetail GetVitalSignEventMark(MedVitalSignGraph vitalSignGraph, string curveText)
        {
            foreach (MedSymbolCurveDetail curveDetail in vitalSignGraph.EventMarkSettings)
            {
                string text1 = curveText.Trim();
                string text2 = curveDetail.Text.Trim();
                if (text1.ToLower().Equals(text2.ToLower()) || text1.ToLower().StartsWith(text2.ToLower() + "("))
                {
                    return curveDetail;
                }
                else if ((text2.EndsWith("%") && text1.StartsWith(text2.Substring(0, text2.Length - 2))) ||
                         (text2.StartsWith("%") && text1.EndsWith(text2.Substring(1))) ||
                         (text2.StartsWith("%") && text2.EndsWith("%") && text1.Contains(text2.Substring(1, text2.Length - 2))))
                {
                    return curveDetail;
                }
            }

            return null;
        }

        /// <summary>
        /// 判断事件是否为手术流程事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        private bool IsOperationEvent(string eventName)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(eventName))
            {
                string ev = eventName.Trim();
                result = ev.Equals(EventNames.OPERATIONSTART) || ev.Equals(EventNames.OPERATIONEND);
            }

            return result;
        }

        /// <summary>
        /// 随机标识
        /// </summary>
        private MedSymbol GetRandomSymbol()
        {
            System.Threading.Thread.Sleep(1);
            Random rand = new Random();
            return new MedSymbol((MedSymbolType)rand.Next((int)MedSymbolType.Image) - 1);

        }

        /// <summary>
        /// 增加麻醉事件
        /// </summary>
        private void AddAnesEventMark(MedVitalSignGraph vitalSignGraph, EventMark eventMark, DateTime eventTime, string anesFlag)
        {
            Color color = Color.Black;
            string alias = "";
            MedSymbol symbol = null;
            MedSymbolCurveDetail detail = GetVitalSignEventMark(vitalSignGraph, anesFlag);
            if (detail != null)
            {
                symbol = new MedSymbol(detail.SymbolType);
                if (symbol.SymbolType == MedSymbolType.Text)
                {
                    symbol.Text = detail.SymbolEntry;
                }

                symbol.Pen = new Pen(detail.Color);
                color = detail.Color;
                alias = anesFlag;
            }
            else
            {
                symbol = new MedSymbol(MedSymbolType.Anesthesia);
            }

            eventMark.AddPoint(eventTime, 0, anesFlag, symbol, color, alias);
        }

        /// <summary>
        /// 增加麻醉开始事件，个性化功能，暂时注释，请勿删除
        /// </summary>
        private void AddAnesStartEventMark(MedVitalSignGraph vitalSignGraph, EventMark eventMark)
        {
            //Color color = Color.Black;
            //string alias = "麻醉";
            //MedSymbol symbol = null;
            //MedSymbolCurveDetail detail = GetVitalSignEventMark(vitalSignGraph, alias);
            //if (detail != null)
            //{
            //    symbol = new MedSymbol(detail.SymbolType);
            //    if (symbol.SymbolType == MedSymbolType.Text)
            //    {
            //        symbol.Text = detail.SymbolEntry;
            //    }
            //    symbol.Pen = new Pen(detail.Color);
            //    color = detail.Color;
            //    alias = "麻醉";
            //}
            //else
            //{
            //    symbol = new MedSymbol(MedSymbolType.Anesthesia);
            //}
            //eventMark.AddPoint(Globals.AnesStartTime, 0, EventNames.ANESSTART, symbol, color, alias);
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

            return tmpList.OrderBy(x => x.PRINT_ITEM_NO).Select(x => x.ITEM_CODE).ToList();
        }
    }
}
