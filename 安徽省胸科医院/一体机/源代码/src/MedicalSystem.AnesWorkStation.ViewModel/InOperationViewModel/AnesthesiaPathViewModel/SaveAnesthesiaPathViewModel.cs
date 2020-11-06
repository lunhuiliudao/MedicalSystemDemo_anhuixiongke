//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      SaveAnesthesiaPathViewModel.cs
//功能描述(Description)：    麻醉路径名称保存ViewModel
//数据表(Tables)：		    MED_ANESTHESIA_DICT
//                          MED_ANESTHESIA_EVENT
//                          MED_OPERATION_MASTER
//                          MED_ANESTHESIA_EVENT_TEMPLET
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Command;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.AnesthesiaPathViewModel
{
    public class SaveAnesthesiaPathViewModel : BaseViewModel
    {
        private List<MED_ANESTHESIA_DICT> _medAnesthesiaDict;
        public new List<MED_ANESTHESIA_DICT> MED_ANESTHESIA_DICT
        {
            get
            {
                return this._medAnesthesiaDict;
            }
            set
            {
                this._medAnesthesiaDict = value;
                RaisePropertyChanged("MED_ANESTHESIA_DICT");
            }
        }

        private string _ANES_METHOD_NAME;
        public string ANES_METHOD_NAME
        {
            get
            {
                return _ANES_METHOD_NAME;
            }
            set
            {
                this._ANES_METHOD_NAME = value;
                RaisePropertyChanged("ANES_METHOD_NAME");
            }
        }

        private string _ANES_METHOD;
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANES_METHOD
        {
            get
            {
                return _ANES_METHOD;
            }
            set
            {
                this._ANES_METHOD = value;
                RaisePropertyChanged("ANES_METHOD");
            }
        }

        private string _TEMPLET_NAME;
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string TEMPLET_NAME
        {
            get
            {
                return _TEMPLET_NAME;
            }
            set
            {
                this._TEMPLET_NAME = value;
                RaisePropertyChanged("TEMPLET_NAME");
            }
        }

        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _eventNo;

        public SaveAnesthesiaPathViewModel()
        {
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            _eventNo = "0";
            MED_OPERATION_MASTER _operMaster = AnesInfoService.ClientInstance.GetOperationMaster(_patientID, _visitID, _operID);
            _ANES_METHOD_NAME = _operMaster.ANES_METHOD;
            MED_ANESTHESIA_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaDictList;
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            bool result = false;
            SaveResult saveResult = SaveResult.Fail;
            List<MED_ANESTHESIA_EVENT> _anesEvent = AnesInfoService.ClientInstance.
                GetAnesthesiaEventByEventNo(_patientID, _visitID, _operID, _eventNo).
                OrderBy(x => x.START_TIME).ToList();
            if (_anesEvent.Count == 0)
            {
                ShowMessageBox("此病人没有用药信息。", MessageBoxButton.OK, MessageBoxImage.Error);
                saveResult = SaveResult.CancelMessageBox;
            }
            else
            {
                MED_OPERATION_MASTER _operMaster = AnesInfoService.ClientInstance.GetOperationMaster(_patientID, _visitID, _operID);
                List<MED_ANESTHESIA_EVENT_TEMPLET> list = new List<MED_ANESTHESIA_EVENT_TEMPLET>();
                for (int i = 0; i < _anesEvent.Count; i++)
                {
                    MED_ANESTHESIA_EVENT_TEMPLET item = new MED_ANESTHESIA_EVENT_TEMPLET();
                    item.TEMPLET_NAME = TEMPLET_NAME;
                    item.CREATE_BY = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                    item.TEMPLET_CLASS = "2";  //模板类别	;	1/PACU、2/手术室、0/通用，默认0 
                    item.ANESTHESIA_METHOD = _ANES_METHOD_NAME;
                    item.EVENT_ITEM_CLASS = _anesEvent[i].EVENT_CLASS_CODE;
                    item.EVENT_ITEM_NO = _anesEvent[i].ITEM_NO;
                    item.EVENT_ITEM_NAME = _anesEvent[i].EVENT_ITEM_NAME;
                    item.EVENT_ITEM_CODE = _anesEvent[i].EVENT_ITEM_CODE;
                    item.EVENT_ITEM_SPEC = _anesEvent[i].EVENT_ITEM_SPEC;
                    item.DOSAGE = _anesEvent[i].DOSAGE;
                    item.DOSAGE_UNITS = _anesEvent[i].DOSAGE_UNITS;
                    item.ADMINISTRATOR = _anesEvent[i].ADMINISTRATOR;
                    item.DURATIVE_INDICATOR = _anesEvent[i].DURATIVE_INDICATOR;
                    item.METHOD = _anesEvent[i].METHOD;
                    item.METHOD_PARENT_NO = _anesEvent[i].METHOD_PARENT_NO;
                    item.PERFORM_SPEED = _anesEvent[i].PERFORM_SPEED;
                    item.SPEED_UNIT = _anesEvent[i].SPEED_UNIT;
                    item.CONCENTRATION = _anesEvent[i].CONCENTRATION;
                    item.CONCENTRATION_UNIT = _anesEvent[i].CONCENTRATION_UNIT;
                    item.EVENT_ATTR = _anesEvent[i].EVENT_ATTR;
                    item.PARENT_ITEM_NO = _anesEvent[i].PARENT_ITEM_NO;
                    item.START_AFTER_INPUT = (decimal)Math.Round((_anesEvent[i].START_TIME.Value - _operMaster.IN_DATE_TIME.Value).TotalMinutes, 0);
                    if (_anesEvent[i].END_TIME != null)
                    {
                        item.DURATIVE = (decimal)Math.Round((_anesEvent[i].END_TIME.Value - _anesEvent[i].START_TIME.Value).TotalMinutes, 0);
                    }
                    item.ModelStatus = ModelStatus.Add;
                    list.Add(item);
                }
                result = AnesInfoService.ClientInstance.SaveAnesEventTemplet(list);
            }
            if (result)
                saveResult = SaveResult.Success;

            return saveResult;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    PublicKeyBoardMessage(KeyCode.AppCode.Save);
                });
            }
        }
    }
}
