using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class NewMonitorData
    {
        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        private string _eventNo;
        private string _patientID;
        private int _visitID;
        private int _operID;
        private bool _isChanged = false;
        private string _loginUser = string.Empty;
        private List<NewMonitorDataItem> _items = new List<NewMonitorDataItem>();
        public NewMonitorData(string patientID, int visitID, int operID, string eventNo, string loginUser)
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _eventNo = eventNo;
            _loginUser = loginUser;
        }

        private NewMonitorDataItem FindItem(DateTime timePoint, string itemName, string itemCode)
        {
            foreach (NewMonitorDataItem item in _items)
            {
                if (item.TimePoint.Date.Equals(timePoint.Date) && item.TimePoint.Hour.Equals(timePoint.Hour) && item.TimePoint.Minute.Equals(timePoint.Minute) && item.ItemName.Equals(itemName) && item.ItemCode.Equals(itemCode)) return item;
            }
            return null;
        }

        public void SetItem(DateTime timePoint, string itemName, object itemValue, object oldValue, string itemCode)
        {
            NewMonitorDataItem item = FindItem(timePoint, itemName, itemCode);
            if (item == null)
            {
                _items.Add(new NewMonitorDataItem(timePoint, itemName, itemValue, oldValue, itemCode));
            }
            else
            {
                item.ItemValue = itemValue;
                //item.OldValue = oldValue;
            }
            _isChanged = true;
        }

        public bool Save()
        {
            if (_items.Count > 0)
            {
                DateTime dtServer = accountRepository.GetServerTime().Data;
                List<MED_PAT_MONITOR_DATA_EXT> patientMonitorExt = operationInfoRepository.GetPatMonitorExtList(_patientID, _visitID, _operID, _eventNo).Data;
                foreach (NewMonitorDataItem item in _items)
                {
                    string valueString = "";
                    string oldValueString = "";
                    if (item.ItemValue != null)
                    {
                        valueString = item.ItemValue.ToString();
                    }
                    if (string.IsNullOrEmpty(valueString))
                    {
                        valueString = "0";
                    }
                    if (item.OldValue != null)
                    {
                        oldValueString = item.OldValue.ToString();
                    }
                    List<MED_PAT_MONITOR_DATA_EXT> monitorExt = patientMonitorExt.Where(x => x.PATIENT_ID.Equals(_patientID) && x.VISIT_ID.Equals(_visitID) && x.OPER_ID.Equals(_operID)
                        && x.TIME_POINT.Equals(item.TimePoint) && x.ITEM_NAME.Equals(item.ItemName) && x.DATA_TYPE.Equals(_eventNo) && x.ITEM_CODE.Equals(item.ItemCode)).ToList();

                    if (monitorExt != null && monitorExt.Count > 0)
                    {
                        MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = monitorExt[0];
                        patientMonitorDataRow.ITEM_VALUE = valueString;
                        patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                        patientMonitorDataRow.OPERATOR = _loginUser;
                        patientMonitorDataRow.DATA_MARK = 1;
                    }
                    else
                    {
                        MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                        patientMonitorDataRow.PATIENT_ID = _patientID;
                        patientMonitorDataRow.VISIT_ID = _visitID;
                        patientMonitorDataRow.OPER_ID = _operID;
                        patientMonitorDataRow.TIME_POINT = item.TimePoint;
                        patientMonitorDataRow.ITEM_NAME = item.ItemName;
                        patientMonitorDataRow.ITEM_CODE = item.ItemCode;
                        patientMonitorDataRow.ITEM_VALUE = valueString;
                        patientMonitorDataRow.DATA_TYPE = _eventNo;
                        patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                        patientMonitorDataRow.OPERATOR = _loginUser;
                        patientMonitorDataRow.DATA_MARK = 1;
                        patientMonitorExt.Add(patientMonitorDataRow);
                    }
                }
                bool result = operationInfoRepository.SavePatMonitorExtList(patientMonitorExt).Data > 0 ? true : false;
                _items.Clear();
                return result;
            }
            return false;
        }

        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }

        public bool Delete(DateTime timePoint, string itemCode, string itemName, string oldValue)
        {
            bool result = false;
            DateTime dtServer = accountRepository.GetServerTime().Data;
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtList = operationInfoRepository.GetPatMonitorExtList(_patientID, _visitID, _operID, _eventNo).Data.Where(x => x.TIME_POINT == timePoint && x.ITEM_CODE == itemCode).ToList();
            if (patMonitorDataExtList.Count > 0)
            {
                patMonitorDataExtList[0].DATA_MARK = 0;
            }
            else
            {
                MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                patientMonitorDataRow.PATIENT_ID = _patientID;
                patientMonitorDataRow.VISIT_ID = _visitID;
                patientMonitorDataRow.OPER_ID = _operID;
                patientMonitorDataRow.TIME_POINT = timePoint;
                patientMonitorDataRow.ITEM_NAME = itemName;
                patientMonitorDataRow.ITEM_CODE = itemCode;
                patientMonitorDataRow.ITEM_VALUE = oldValue;
                patientMonitorDataRow.DATA_TYPE = _eventNo;
                patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                patientMonitorDataRow.OPERATOR = _loginUser;
                patientMonitorDataRow.DATA_MARK = 0;
                patMonitorDataExtList.Add(patientMonitorDataRow);
            }
            result = operationInfoRepository.SavePatMonitorExtList(patMonitorDataExtList).Data > 0 ? true : false;
            return result;
        }
        public bool Delete(DateTime timePoint)
        {
            bool result = false;
            DateTime dtServer = accountRepository.GetServerTime().Data;
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtList = operationInfoRepository.GetPatMonitorExtList(_patientID, _visitID, _operID, _eventNo).Data.Where(x => x.TIME_POINT == timePoint).ToList();
            List<MED_PAT_MONITOR_DATA> patMonitorDataList = operationInfoRepository.GetPatMonitorDataListByEvent(_patientID, _visitID, _operID, _eventNo).Data.Where(x => x.TIME_POINT == timePoint).ToList();
            if (patMonitorDataList != null && patMonitorDataList.Count > 0)
            {
                patMonitorDataList.ForEach(row =>
                    {
                        List<MED_PAT_MONITOR_DATA_EXT> extList = patMonitorDataExtList.Where(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_NAME.Equals(row.ITEM_NAME) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();
                        if (extList.Count > 0)
                        {
                            MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = extList[0];
                            patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                            patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                            patientMonitorDataRow.OPERATOR = _loginUser;
                            patientMonitorDataRow.DATA_MARK = 0;
                        }
                        else
                        {
                            MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                            patientMonitorDataRow.PATIENT_ID = _patientID;
                            patientMonitorDataRow.VISIT_ID = _visitID;
                            patientMonitorDataRow.OPER_ID = _operID;
                            patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                            patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                            patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                            patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                            patientMonitorDataRow.DATA_TYPE = _eventNo;
                            patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                            patientMonitorDataRow.OPERATOR = _loginUser;
                            patientMonitorDataRow.DATA_MARK = 0;
                            patMonitorDataExtList.Add(patientMonitorDataRow);
                        }
                    });
            }
            if (patMonitorDataExtList != null)
                patMonitorDataExtList.ForEach(row =>
                {
                    row.DATA_MARK = 0;
                });
            result = operationInfoRepository.SavePatMonitorExtList(patMonitorDataExtList).Data > 0 ? true : false;
            return result;
        }
        public bool Delete(string itemCode)
        {
            bool result = false;
            DateTime dtServer = accountRepository.GetServerTime().Data;
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtList = operationInfoRepository.GetPatMonitorExtList(_patientID, _visitID, _operID, _eventNo).Data.Where(x => x.ITEM_CODE == itemCode).ToList();
            List<MED_PAT_MONITOR_DATA> patMonitorDataList = operationInfoRepository.GetPatMonitorDataListByEvent(_patientID, _visitID, _operID, _eventNo).Data.Where(x => x.ITEM_CODE == itemCode).ToList();
            if (patMonitorDataList != null && patMonitorDataList.Count > 0)
            {
                patMonitorDataList.ForEach(row =>
                {
                    List<MED_PAT_MONITOR_DATA_EXT> extList = patMonitorDataExtList.Where(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_NAME.Equals(row.ITEM_NAME) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();
                    if (extList.Count > 0)
                    {
                        MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = extList[0];
                        patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                        patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                        patientMonitorDataRow.OPERATOR = _loginUser;
                        patientMonitorDataRow.DATA_MARK = 0;
                    }
                    else
                    {
                        MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                        patientMonitorDataRow.PATIENT_ID = _patientID;
                        patientMonitorDataRow.VISIT_ID = _visitID;
                        patientMonitorDataRow.OPER_ID = _operID;
                        patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                        patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                        patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                        patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                        patientMonitorDataRow.DATA_TYPE = _eventNo;
                        patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                        patientMonitorDataRow.OPERATOR = _loginUser;
                        patientMonitorDataRow.DATA_MARK = 0;
                        patMonitorDataExtList.Add(patientMonitorDataRow);
                    }
                });
            }
            if (patMonitorDataExtList != null)
                patMonitorDataExtList.ForEach(row =>
                {
                    row.DATA_MARK = 0;
                });

            result = operationInfoRepository.SavePatMonitorExtList(patMonitorDataExtList).Data > 0 ? true : false;

            return result;
        }

        private bool IsDateTimeEqual(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Year.Equals(dateTime2.Year) && dateTime1.Month.Equals(dateTime2.Month) && dateTime1.Day.Equals(dateTime2.Day)
                && dateTime1.Hour.Equals(dateTime2.Hour) && dateTime1.Minute.Equals(dateTime2.Minute);
        }
    }
}
