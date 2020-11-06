using GalaSoft.MvvmLight;
using MedicalSystem.Anes.Document.Constants;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    /// <summary>
    /// 标识
    /// </summary>
    public class EventMarkViewModel : ViewModelBase
    {
        private List<MED_ANESTHESIA_EVENT> _anesEventList = null;
        private MED_OPERATION_MASTER _operMaster = null;
        private MedVitalSignGraph _vitalSignGraph = null;
        private EventMarkModel _eventMark;
        public EventMarkModel EventMark
        {
            get
            {
                return _eventMark;
            }
            set
            {
                _eventMark = value;
                RaisePropertyChanged("EventMark");
            }
        }
        public EventMarkViewModel(List<MED_ANESTHESIA_EVENT> anesEventList, MED_OPERATION_MASTER operMaster, MedVitalSignGraph vitalSignGraph)
        {
            _anesEventList = anesEventList;
            _operMaster = operMaster;
            _vitalSignGraph = vitalSignGraph;
        }
        public EventMarkModel GetEventMark()
        {
            EventMarkModel mark = new EventMarkModel();
            EventMarkModel mark1 = new EventMarkModel();
            EventMarkModel mark2 = new EventMarkModel();
            EventMarkModel mark3 = new EventMarkModel();
            mark.Title = ""; mark1.Title = ""; mark2.Title = ""; mark3.Title = "";
            AddAnesEventMark(mark1, DateTime.MinValue, "----- 事件 -----", EventNames.INDATETIME);
            AddAnesEventMark(mark2, DateTime.MinValue, "----- 麻药 -----", EventNames.INDATETIME);
            AddAnesEventMark(mark3, DateTime.MinValue, "----- 用药 -----", EventNames.INDATETIME);
            if (_operMaster != null)
            {
                if (_operMaster.IN_DATE_TIME.HasValue)
                {
                    AddAnesEventMark(mark1, _operMaster.IN_DATE_TIME.Value, EventNames.INDATETIME, EventNames.INDATETIME);
                }
                if (_operMaster.ANES_START_TIME.HasValue)//麻醉开始
                {
                    AddAnesEventMark(mark1, _operMaster.ANES_START_TIME.Value, EventNames.ANESSTART, EventNames.ANESSTART);
                }
                if (_operMaster.START_DATE_TIME.HasValue)//手术开始
                {
                    AddAnesEventMark(mark1, _operMaster.START_DATE_TIME.Value, EventNames.OPERATIONSTART, EventNames.OPERATIONSTART);
                }
                if (_operMaster.END_DATE_TIME.HasValue)//手术结束
                {
                    AddAnesEventMark(mark1, _operMaster.END_DATE_TIME.Value, EventNames.OPERATIONEND, EventNames.OPERATIONEND);
                }
                if (_operMaster.ANES_END_TIME.HasValue)//麻醉结束
                {
                    AddAnesEventMark(mark1, _operMaster.ANES_END_TIME.Value, EventNames.ANESEND, EventNames.ANESEND);
                }
                if (_operMaster.OUT_DATE_TIME.HasValue)
                {
                    AddAnesEventMark(mark1, _operMaster.OUT_DATE_TIME.Value, EventNames.OUTDATETIME, EventNames.OUTDATETIME);
                }
            }
            if (_anesEventList != null && _anesEventList.Count > 0)
            {
                _anesEventList.ForEach(row =>
                {
                    if (row.START_TIME.HasValue && !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) && !string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                           (row.EVENT_ITEM_NAME == "体外循环开始" || row.EVENT_ITEM_NAME == "体外循环结束" || row.EVENT_ITEM_NAME == "阻断升主动脉" || row.EVENT_ITEM_NAME == "开放升主动脉"))
                    {
                        AddAnesEventMark(mark1, row.START_TIME.Value, row.EVENT_ITEM_NAME, "体外循环");//体外循环数据
                    }
                    else if (row.EVENT_CLASS_CODE.Equals("7"))//插管数据
                    {
                        AddAnesEventMark(mark1, row.START_TIME.Value, row.EVENT_ITEM_NAME, "插管");
                    }
                    else if (row.EVENT_CLASS_CODE.Equals("8"))//插管数据
                    {
                        AddAnesEventMark(mark1, row.START_TIME.Value, row.EVENT_ITEM_NAME, "拔管");
                    }
                    else if (row.EVENT_CLASS_CODE.Equals("1"))
                    {
                        AddAnesEventMark(mark1, row.START_TIME.Value, row.EVENT_ITEM_NAME, "");
                    }
                    else if (row.EVENT_CLASS_CODE.Equals("Z"))
                    {
                        AddAnesEventMark(mark1, row.START_TIME.Value, row.EVENT_ITEM_NAME, "");
                    }
                    //else if (row.EVENT_CLASS_CODE.Equals("2") && (!row.DURATIVE_INDICATOR.HasValue || row.DURATIVE_INDICATOR == 0))
                    else if (row.EVENT_CLASS_CODE.Equals("2") && (!row.DURATIVE_INDICATOR.HasValue || row.DURATIVE_INDICATOR != 1))// 单点用药只要不是1,就是单点，都要出现在备注栏
                    {
                        string text = row.EVENT_ITEM_NAME + " " + row.DOSAGE + row.DOSAGE_UNITS + " " + row.ADMINISTRATOR;
                        AddAnesEventMark(mark2, row.START_TIME.Value, text, "");
                    }
                    //else if (row.EVENT_CLASS_CODE.Equals("C") && (!row.DURATIVE_INDICATOR.HasValue || row.DURATIVE_INDICATOR == 0))
                      else if (row.EVENT_CLASS_CODE.Equals("C") && (!row.DURATIVE_INDICATOR.HasValue || row.DURATIVE_INDICATOR != 1))
                    {
                        string text = row.EVENT_ITEM_NAME + " " + row.DOSAGE + row.DOSAGE_UNITS + " " + row.ADMINISTRATOR;
                        AddAnesEventMark(mark3, row.START_TIME.Value, text, "");
                    }
                });
            }

            List<MED_OPERATION_SHIFT_RECORD> shiftRecordList = AnesInfoService.ClientInstance.GetOperShiftRecord(
                    ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                    ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                    ExtendAppContext.Current.PatientInformationExtend.OPER_ID).Where(x => x.SHIFT_PERSON != null && x.END_DATE_TIME != null).ToList();
            if (shiftRecordList.Count > 0)
            {
                foreach (var item in shiftRecordList)
                {
                    string text = item.PERSON_NAME + "交班给" + item.SHIFT_PERSON_NAME;
                    AddAnesEventMark(mark1, item.END_DATE_TIME.Value, text, "");
                }
            }

            mark1.ReSort();
            mark2.ReSort();
            mark3.ReSort();

            if (mark1.Points != null && mark1.Points.Count > 1)
            {
                for (int i = 1; i <= mark1.Points.Count; i++)
                {
                    if (i != 1)
                    {
                        mark1.Points[i - 1].Index = i - 1;
                    }
                    mark.AddPoint(mark1.Points[i - 1].TimePoint, mark1.Points[i - 1].Index, mark1.Points[i - 1].Text, mark1.Points[i - 1].Symbol, mark1.Points[i - 1].Color, mark1.Points[i - 1].LengenedText);

                }
            }
            if (mark2.Points != null && mark2.Points.Count > 1)
            {
                for (int i = 1; i <= mark2.Points.Count; i++)
                {
                    if (i != 1)
                    {
                        mark2.Points[i - 1].Index = i - 1;
                    }
                    mark.AddPoint(mark2.Points[i - 1].TimePoint, mark2.Points[i - 1].Index, mark2.Points[i - 1].Text, mark2.Points[i - 1].Symbol, mark2.Points[i - 1].Color, mark2.Points[i - 1].LengenedText);

                }
            }

            if (mark3.Points != null && mark3.Points.Count > 1)
            {
                for (int i = 1; i <= mark3.Points.Count; i++)
                {
                    if (i != 1)
                    {
                        mark3.Points[i - 1].Index = i - 1;
                    }
                    mark.AddPoint(mark3.Points[i - 1].TimePoint, mark3.Points[i - 1].Index, mark3.Points[i - 1].Text, mark3.Points[i - 1].Symbol, mark3.Points[i - 1].Color, mark3.Points[i - 1].LengenedText);

                }
            }
            if (mark.Points != null && mark.Points.Count > 0)
            {
                int j = 0;
                for (int i = 1; i <= mark.Points.Count; i++)
                {
                    if (mark.Points[i - 1].Index == 0) { j++; }
                    else
                        mark.Points[i - 1].Index = i - j;
                }
            }

            EventMark = mark;
            return EventMark;
        }
        /// <summary>
        /// 增加麻醉事件
        /// </summary>
        /// <param name="vitalSignGraph"></param>
        /// <param name="eventMark"></param>
        private void AddAnesEventMark(EventMarkModel eventMark, DateTime eventTime, string text, string anesFlag)
        {
            Color color = Color.Black;
            string alias = "";
            SymbolModel symbol = null;
            MedSymbolCurveDetail detailFlag = GetVitalSignEventMark(anesFlag);
            SymbolCurveDetailModel detail = null;
            if (detailFlag != null)
                detail = ConvertToDetailModel(GetVitalSignEventMark(anesFlag));
            if (detail != null)
            {
                symbol = new SymbolModel(detail.SymbolType);
                if (symbol.SymbolType == SymbolType.Text)
                {
                    symbol.Text = detail.SymbolEntry;
                }
                symbol.Pen = new Pen(detail.Color);
                color = detail.Color;
                alias = anesFlag;
            }
            eventMark.AddPoint(eventTime, 0, text, symbol, color, alias);

        }
        private MedSymbolCurveDetail GetVitalSignEventMark(string curveText)
        {
            MedSymbolCurveDetail detail = null;
            foreach (MedSymbolCurveDetail curveDetail in _vitalSignGraph.EventMarkSettings)
            {
                string text1 = curveText.Trim();
                string text2 = curveDetail.Text.Trim();
                if (text1.ToLower().Equals(text2.ToLower()) || text1.ToLower().StartsWith(text2.ToLower() + "("))
                {
                    detail = curveDetail;
                }
                else if ((text2.EndsWith("%") && text1.StartsWith(text2.Substring(0, text2.Length - 2))) ||
                    (text2.StartsWith("%") && text1.EndsWith(text2.Substring(1))) ||
                    (text2.StartsWith("%") && text2.EndsWith("%") && text1.Contains(text2.Substring(1, text2.Length - 2))))
                {
                    detail = curveDetail;
                }
            }
            return detail;
        }
        private SymbolCurveDetailModel ConvertToDetailModel(MedSymbolCurveDetail curveDetailList)
        {
            SymbolCurveDetailModel detailModel = new SymbolCurveDetailModel();
            detailModel.Text = curveDetailList.Text;
            detailModel.SymbolEntry = curveDetailList.SymbolEntry;
            detailModel.Color = curveDetailList.Color;
            string type = curveDetailList.SymbolType.ToString();
            detailModel.SymbolType = (SymbolType)Enum.Parse(typeof(SymbolType), type);
            return detailModel;

        }
    }
}
