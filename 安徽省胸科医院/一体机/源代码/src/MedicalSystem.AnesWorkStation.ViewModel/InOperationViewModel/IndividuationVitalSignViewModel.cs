//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      IndividuationVitalSignViewModel.cs
//功能描述(Description)：    个性化体征（二）
//数据表(Tables)：		    MED_ANESTHESIA_INPUT_DICT
//                          MED_PATIENT_MONITOR_CONFIG 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Command;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.Common.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class IndividuationVitalSignViewModel : BaseViewModel
    {
        private ObservableCollection<LegendItemEx> _detailModel = new ObservableCollection<LegendItemEx>();
        public ObservableCollection<LegendItemEx> DetailModel
        {
            get { return _detailModel; }
            set
            {
                _detailModel = value;
                this.RaisePropertyChanged("DetailModel");
            }
        }
        private LegendItemEx _selectItem;
        public LegendItemEx SelectItem
        {
            get { return _selectItem; }
            set
            {
                _selectItem = value;
            }
        }
        private List<MED_ANESTHESIA_INPUT_DICT> _selectIsVisible = new List<MED_ANESTHESIA_INPUT_DICT>();
        public List<MED_ANESTHESIA_INPUT_DICT> SelectIsVisible
        {
            get { return _selectIsVisible; }
            set
            {
                _selectIsVisible = value;
                this.RaisePropertyChanged("SelectIsVisible");
            }
        }
        private List<MED_ANESTHESIA_INPUT_DICT> _selectShowType = new List<MED_ANESTHESIA_INPUT_DICT>();
        /// <summary>
        /// 显示类型
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> SelectShowType
        {
            get { return _selectShowType; }
            set
            {
                _selectShowType = value;
                this.RaisePropertyChanged("SelectShowType");
            }
        }
        private List<MED_ANESTHESIA_INPUT_DICT> _selectSymbol = new List<MED_ANESTHESIA_INPUT_DICT>();
        /// <summary>
        /// 图标
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> SelectSymbol
        {
            get { return _selectSymbol; }
            set
            {
                _selectSymbol = value;
                this.RaisePropertyChanged("SelectSymbol");
            }
        }
        private List<MED_ANESTHESIA_INPUT_DICT> _selectShowTimeInterval = new List<MED_ANESTHESIA_INPUT_DICT>();
        /// <summary>
        /// 时间间隔
        /// </summary>
        public List<MED_ANESTHESIA_INPUT_DICT> SelectShowTimeInterval
        {
            get { return _selectShowTimeInterval; }
            set
            {
                _selectShowTimeInterval = value;
                this.RaisePropertyChanged("SelectShowTimeInterval");
            }
        }
        /// <summary>
        /// 所有默认色卡
        /// </summary>
        public List<ColorsEnum> ColorList { get; set; }

        /// <summary>
        /// 载入
        /// </summary>
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            //自定义 LookUpEditItem集合 但是不知道为什么数据绑定不到界面  只能借助这个表了，后面哪个大神看到了 可以修改下
            _selectIsVisible.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "是否", ITEM_NAME = "是", ITEM_CODE = "True" });
            _selectIsVisible.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "是否", ITEM_NAME = "否", ITEM_CODE = "False" });
            SelectIsVisible = _selectIsVisible;

            foreach (MemberDetail m in AssemblyHelper.GetEnumList(typeof(MedCurveShowType)))
            {
                _selectShowType.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "显示类型", ITEM_NAME = m.Name, ITEM_CODE = m.Value.ToString() });
            }
            SelectShowType = _selectShowType;
            foreach (MemberDetail m in AssemblyHelper.GetEnumList(typeof(MedSymbolType)))
            {
                _selectSymbol.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "图标", ITEM_NAME = m.Name, ITEM_CODE = m.Value.ToString() });
            }
            SelectSymbol = _selectSymbol;

            foreach (MemberDetail m in AssemblyHelper.GetEnumList(typeof(MedShowTimeInterval)))
            {
                _selectShowTimeInterval.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "时间间隔", ITEM_NAME = m.Name, ITEM_CODE = m.Value.ToString() });
            }
            SelectShowTimeInterval = _selectShowTimeInterval;

            ColorList = typeof(System.Windows.Media.Colors).GetProperties()
                .Select(x => new ColorsEnum(x.Name, (System.Windows.Media.Color)x.GetValue(null))).ToList();

            List<VitalSignCurveDetailModel> lvcd = Args[0] as List<VitalSignCurveDetailModel>;
            foreach (VitalSignCurveDetailModel detail in lvcd)
            {
                LegendItemEx ex = new LegendItemEx();
                ex.LineColor = detail.Color;
                ex.Visible = detail.Visible ? "是" : "否";
                ex.ShowType = detail.ShowType.GetDescription();
                ex.TimeInterval = detail.ShowTimeInterval.GetDescription();
                ex.Code = detail.LegendList.First().Code;
                ex.DisplayName = detail.LegendList.First().DisplayName;
                ex.SymbolName = detail.LegendList.First().Symbol.SymbolType.GetDescription();
                ex.Symbol = detail.LegendList.First().Symbol;
                if (detail.HideTime != null && detail.HideTime.Count > 0)
                {
                    if (detail.HideTime[0].StartDateTime != null && detail.HideTime[0].StartDateTime != DateTime.MinValue)
                    {
                        ex.HideStart = detail.HideTime[0].StartDateTime.Value;
                    }
                    if (detail.HideTime[0].EndDateTime != null && detail.HideTime[0].EndDateTime != DateTime.MinValue)
                        ex.HideEnd = detail.HideTime[0].EndDateTime.Value;
                }
                DetailModel.Add(ex);
            }
            isChange = false;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private MedVitalSignCurveDetail ConvertToCurveDetail(VitalSignCurveDetailModel detail)
        {
            MedVitalSignCurveDetail detailMode = new MedVitalSignCurveDetail();
            detailMode.CurveName = detail.CurveName;
            detailMode.CurveCode = detail.CurveCode;
            detailMode.Visible = detail.Visible;
            detailMode.SymbolType = (MedSymbolType)Enum.Parse(typeof(MedSymbolType), detail.LegendList[0].Symbol.SymbolType.ToString());
            detailMode.SymbolEntry = detail.SymbolEntry;
            detailMode.Color = detail.Color;
            detailMode.DotNumber = detail.DecimalDigits;
            string showType = detail.ShowType.ToString();
            detailMode.ShowType = (MedCurveShowType)Enum.Parse(typeof(MedCurveShowType), showType);
            detailMode.YAxisIndex = detail.YAxisIndex;
            string showTime = detail.ShowTimeInterval.ToString();
            detailMode.ShowTimeInterval = (MedShowTimeInterval)Enum.Parse(typeof(MedShowTimeInterval), showTime);
            if (detail.HideTime != null && detail.HideTime.Count > 0)
            {
                if (detail.HideTime[0].StartDateTime != null && detail.HideTime[0].StartDateTime.Value != DateTime.MinValue) detailMode.HideStartTime = detail.HideTime[0].StartDateTime.Value;
                if (detail.HideTime[0].EndDateTime != null && detail.HideTime[0].EndDateTime.Value != DateTime.MinValue) detailMode.HideEndTime = detail.HideTime[0].EndDateTime.Value;
            }
            return detailMode;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            List<VitalSignCurveDetailModel> list = Args[0] as List<VitalSignCurveDetailModel>;
            foreach (LegendItemEx item in DetailModel)
            {
                if (item.Code != null)
                {
                    foreach (VitalSignCurveDetailModel detail in list)
                    {
                        if (item.Code == detail.CurveCode)
                        {
                            detail.Visible = item.Visible.Equals("是") ? true : false;
                            detail.Color = item.LineColor;
                            string ShowTypeName = SelectShowType.Where(x => x.ITEM_NAME == item.ShowType).FirstOrDefault().ITEM_CODE;
                            detail.ShowType = (CurveShowType)Enum.Parse(typeof(CurveShowType), ShowTypeName);
                            string TimeIntervalName = SelectShowTimeInterval.Where(x => x.ITEM_NAME == item.TimeInterval).FirstOrDefault().ITEM_CODE;
                            detail.ShowTimeInterval = (ShowTimeInterval)Enum.Parse(typeof(ShowTimeInterval), TimeIntervalName);
                            detail.SymbolEntry = item.SymbolName;
                            string SymbolName = SelectSymbol.Where(x => x.ITEM_NAME == item.SymbolName).FirstOrDefault().ITEM_CODE;
                            detail.LegendList[0].Symbol.SymbolType = (SymbolType)Enum.Parse(typeof(SymbolType), SymbolName);
                            detail.HideTime[0].StartDateTime = item.HideStart == null ? null : item.HideStart;
                            detail.HideTime[0].EndDateTime = item.HideEnd == null ? null : item.HideEnd;
                        }
                    }
                }
            }
            string tableName = "UserVitalShowSet" + ((Convert.ToInt32(ExtendAppContext.Current.EventNo) < 0) ? "0" : ExtendAppContext.Current.EventNo);
            DataTable dataTable = new DataTable(tableName);
            System.Reflection.PropertyInfo[] propertyInfos = typeof(MedVitalSignCurveDetail).GetProperties();
            foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
            {
                dataTable.Columns.Add(propertyInfo.Name);
            }
            foreach (VitalSignCurveDetailModel obj in list)
            {
                MedVitalSignCurveDetail detail = ConvertToCurveDetail(obj);
                DataRow row = dataTable.NewRow();
                foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                {
                    if (propertyInfo.Name.Equals("LegendList"))
                    {
                        string symbolStr = "";
                        for (int i = 0; i < obj.LegendList.Count; i++)
                        {
                            symbolStr += obj.LegendList[i].Symbol.SymbolType.ToString();
                            symbolStr += "|";
                        }
                        row[propertyInfo.Name] = symbolStr;
                    }
                    else if (propertyInfo.Name.Equals("HideTime"))
                    {
                        string time = "";
                        for (int i = 0; i < obj.HideTime.Count; i++)
                        {
                            if (obj.HideTime[0].StartDateTime != null && obj.HideTime[0].StartDateTime != DateTime.MinValue || obj.HideTime[0].StartDateTime != DateTime.MaxValue)
                            {
                                time += obj.HideTime[0].StartDateTime.ToString() + "&" + obj.HideTime[0].EndDateTime.ToString();
                                time += "|";
                            }
                        }
                        row[propertyInfo.Name] = time;
                    }
                    else
                        row[propertyInfo.Name] = AssemblyHelper.GetPropertyValue(propertyInfo, detail);
                }
                dataTable.Rows.Add(row);
            }
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            dataTable.WriteXml(stream);
            stream.Position = 0;
            byte[] bytes = FileHelper.StreamToBytes(stream);
            MED_PATIENT_MONITOR_CONFIG configRow = AnesInfoService.ClientInstance.GetPatientMonitorConfig(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
               ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
               ExtendAppContext.Current.PatientInformationExtend.OPER_ID,
                ExtendAppContext.Current.EventNo);
            if (configRow == null)
            {
                configRow = new MED_PATIENT_MONITOR_CONFIG();
                configRow.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                configRow.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                configRow.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                configRow.EVENT_NO = ExtendAppContext.Current.EventNo;
            }
            configRow.CONTENT = bytes;
            if (AnesInfoService.ClientInstance.updatePatMonitorConfig(configRow))
            {
                return SaveResult.Success;
            }
            else { return SaveResult.Fail; }
        }
        /// <summary>
        /// 是否保存
        /// </summary>
        /// <returns></returns>
        protected override bool CheckDataChange()
        {
            return isChange;
        }
        bool isChange = false;
        public override void RaisePropertyChanged(string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            isChange = true;
        }
        public override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            base.RaisePropertyChanged<T>(propertyExpression);
            isChange = true;
        }
        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SureCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    PublicKeyBoardMessage(KeyCode.AppCode.Save);
                });
            }
        }

        /// <summary>
        /// 图例元素
        /// </summary>

        public class LegendItemEx : LegendItem
        {
            private string _visible;
            public string Visible
            {
                get { return _visible; }
                set
                {
                    _visible = value;
                    this.RaisePropertyChanged("Visible");
                }
            }
            private System.Drawing.Color _lineColor;
            public System.Drawing.Color LineColor
            {
                get { return _lineColor; }
                set
                {
                    _lineColor = value;
                    this.RaisePropertyChanged("LineColor");
                }
            }
            private string _showType;
            public string ShowType
            {
                get { return _showType; }
                set
                {
                    _showType = value;
                    this.RaisePropertyChanged("ShowType");
                }
            }
            private string _timeInterval;
            public string TimeInterval
            {
                get { return _timeInterval; }
                set
                {
                    _timeInterval = value;
                    this.RaisePropertyChanged("TimeInterval");
                }
            }
            private string _symbolName;
            public string SymbolName
            {
                get { return _symbolName; }
                set
                {
                    _symbolName = value;
                    this.RaisePropertyChanged("SymbolName");
                }
            }
            private DateTime? _hideStart;
            public DateTime? HideStart
            {
                get { return _hideStart; }
                set
                {
                    _hideStart = value;
                    this.RaisePropertyChanged("HideStart");
                }
            }
            private DateTime? _hideEnd;
            public DateTime? HideEnd
            {
                get { return _hideEnd; }
                set
                {
                    _hideEnd = value;
                    this.RaisePropertyChanged("HideEnd");
                }
            }
        }

        public class ColorsEnum
        {
            public ColorsEnum(string name, System.Windows.Media.Color color)
            {
                Name = name;
                Value = color;// Color.FromArgb(color.A, color.R, color.G, color.B);
            }
            public string Name { get; set; }
            public System.Windows.Media.Color Value { get; set; }
        }
    }
}
