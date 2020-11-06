using GalaSoft.MvvmLight;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class BreathParaViewModel : ViewModelBase
    {
        private MedVitalSignGraph _vitalSignGraph = null;
        private BreathParaModel _breathPara = null;
        public BreathParaModel BreathPara
        {
            get
            {
                return _breathPara;
            }
            set
            {
                _breathPara = value;
                RaisePropertyChanged("BreathPara");
            }
        }
        public BreathParaViewModel(MedVitalSignGraph vitalSignGraph)
        {
            _vitalSignGraph = vitalSignGraph;
        }

        public BreathParaModel GetBreathPara()
        {
            BreathParaModel breathPara = new BreathParaModel();
            if (!string.IsNullOrEmpty(_vitalSignGraph.BreathPara1) && !string.IsNullOrEmpty(_vitalSignGraph.BreathPara2) && !string.IsNullOrEmpty(_vitalSignGraph.BreathPara3))
            {
                breathPara.TopParamCode = _vitalSignGraph.BreathPara1;
                breathPara.LeftParamCode = _vitalSignGraph.BreathPara2;
                breathPara.RightParamCode = _vitalSignGraph.BreathPara3;
                breathPara.TopParamName = GetMonitorFunctionName(_vitalSignGraph.BreathPara1);
                breathPara.LeftParamName = GetMonitorFunctionName(_vitalSignGraph.BreathPara2);
                breathPara.RightParamName = GetMonitorFunctionName(_vitalSignGraph.BreathPara3);
                List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable = AnesInfoService.ClientInstance.GetPatMonitorExtList(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                    ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
                {
                    List<MED_PAT_MONITOR_DATA_EXT> breathList = patMonitorDataExtDataTable.Where(x => x.ITEM_CODE == _vitalSignGraph.BreathPara1 || x.ITEM_CODE == _vitalSignGraph.BreathPara2 || x.ITEM_CODE == _vitalSignGraph.BreathPara3).ToList();
                    if (breathList != null && breathList.Count > 0)
                    {
                        breathList.ForEach(row =>
                        {
                            if (!breathPara.BreathParalList.ContainsKey(row.TIME_POINT))
                            {
                                breathPara.BreathParalList.Add(row.TIME_POINT, new BreathParaDetail());
                            }
                            if (!string.IsNullOrEmpty(row.ITEM_VALUE))
                            {
                                if (row.ITEM_CODE.Equals(breathPara.TopParamCode))
                                {
                                    breathPara.BreathParalList[row.TIME_POINT].TopParamVal = row.ITEM_VALUE;
                                }
                                else if (row.ITEM_CODE.Equals(breathPara.LeftParamCode))
                                {
                                    breathPara.BreathParalList[row.TIME_POINT].LeftParamVal = row.ITEM_VALUE;
                                }
                                else if (row.ITEM_CODE.Equals(breathPara.RightParamCode))
                                {
                                    breathPara.BreathParalList[row.TIME_POINT].RightParamVal = row.ITEM_VALUE;
                                }
                            }
                        });
                    }
                }
            }
            BreathPara = breathPara;
            return BreathPara;
        }
        public string GetMonitorFunctionName(string code)
        {
            string result = code;
            {
                List<MED_MONITOR_FUNCTION_CODE> functionCode = ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList;
                if (functionCode == null)
                    return string.Empty;
                List<MED_MONITOR_FUNCTION_CODE> functionList = functionCode.Where(x => x.ITEM_CODE == code).ToList();
                if (functionCode != null && functionCode.Count > 0)
                {
                    functionList.ForEach(row =>
                    {
                        result = row.ITEM_NAME;
                    });
                }
            }
            return result;
        }
    }
}
