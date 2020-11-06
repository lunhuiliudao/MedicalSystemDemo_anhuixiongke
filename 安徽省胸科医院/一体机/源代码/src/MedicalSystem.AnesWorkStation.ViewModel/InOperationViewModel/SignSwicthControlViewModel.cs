//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      SignSwicthControlViewModel.cs
//功能描述(Description)：    个性化体征项目配置ViewModel（1）
//数据表(Tables)：		    MED_PATIENT_MONITOR_CONFIG 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:30
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class SignSwicthControlViewModel : BaseViewModel
    {
        public SignSwicthControlViewModel()
        { }

        private List<LegendItemEx> _Symbols;

        public List<LegendItemEx> Symbols
        {
            get { return _Symbols; }
            set
            {
                _Symbols = value;
                this.RaisePropertyChanged("Symbols");
            }
        }
        private int _rowCount;
        public int RowCount
        {
            get { return _rowCount; }
            set
            {
                _rowCount = RowCount;
                this.RaisePropertyChanged("RowCount");
            }
        }
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();

            List<VitalSignCurveDetailModel> lvcd = Args[0] as List<VitalSignCurveDetailModel>;

            var result = lvcd.Select(r => new LegendItemEx()
            {
                LineColor = r.Color,
                Visible = r.Visible,
                Code = r.LegendList.First().Code,
                DisplayName = r.LegendList.First().DisplayName,
                Symbol = r.LegendList.First().Symbol
            }).ToList();

            //设置默认颜色
            result.ForEach(r =>
            {
                if (r.Symbol.Brush == null)
                {
                    SolidBrush brush = new SolidBrush(r.LineColor);
                    r.Symbol.Brush = brush;
                }
            });

            //默认要显示12个（UI要求）
            if (result.Count > 12)
            {
                _rowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(result.Count) / 6.0));
                int allCount = RowCount * 6;
                while (result.Count < allCount)
                {
                    result.Add(new LegendItemEx());
                }
            }
            else
            {
                _rowCount = 2;
                while (result.Count < 12)
                {
                    result.Add(new LegendItemEx());
                }
            }


            Symbols = result;
        }
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

            return detailMode;
        }
        public ICommand SureCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    List<VitalSignCurveDetailModel> list = Args[0] as List<VitalSignCurveDetailModel>;
                    foreach (LegendItemEx item in Symbols)
                    {
                        if (item.Code != null)
                        {
                            foreach (VitalSignCurveDetailModel detail in list)
                            {
                                if (item.Code == detail.CurveCode)
                                    detail.Visible = item.Visible;
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
                    byte[] bytes = FileHelper.StreamToBytes(stream); //StringHelper.Str2Arr(jsonStr);//
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
                        this.CloseContentWindow();
                    }
                });
            }
        }
    }

    public class LegendItemEx : LegendItem
    {
        public bool Visible { get; set; }

        public System.Drawing.Color LineColor { get; set; }
    }
}
