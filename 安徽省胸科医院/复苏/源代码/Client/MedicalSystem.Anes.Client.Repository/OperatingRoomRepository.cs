using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.Anes.Client.Repository
{
    public class OperatingRoomRepository
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        public bool SetOperatingRoomPatient(List<MED_OPERATING_ROOM> operatingRoomList, string roomNo, string operRoom, string patientID
                            , int visitID, int operID)
        {
            operatingRoomList = comnDictRepository.GetOperatingRoomList("1").Data;

            List<MED_OPERATING_ROOM> operList = operatingRoomList.Where(x => x.ROOM_NO.Equals(roomNo) && x.DEPT_CODE.Equals(operRoom)).ToList();
            if (operList != null && operList.Count > 0)
            {
                if (string.IsNullOrEmpty(patientID))
                {
                    operList[0].PATIENT_ID = patientID;
                    operList[0].VISIT_ID = null;
                    operList[0].OPER_ID = null;
                }
                else
                {
                    if (string.IsNullOrEmpty(operList[0].PATIENT_ID))
                    {
                        operList[0].PATIENT_ID = patientID;
                        operList[0].VISIT_ID = visitID;
                        operList[0].OPER_ID = operID;
                    }
                    else
                        return false;
                }

                return comnDictRepository.SaveOperatingRoom(operList[0]).Data > 0 ? true : false;
            }
            return false;
        }
        public void SetOperMaster(string patientID, int visitID, int operID, string updateName, DateTime time, int operStatus)
        {
            MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(patientID, visitID, operID).Data;
            if (operMaster != null)
            {
                operMaster.OPER_STATUS_CODE = operStatus;
                operMaster.OUT_PACU_WHEREABORTS = operStatus;
                if (time == DateTime.MinValue)
                    operMaster.SetValue(updateName, null);
                else
                    operMaster.SetValue(updateName, time);
                Logger.Error("master表状态以及时间:" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
                operationInfoRepository.SaveOperMaster(operMaster);
            }
        }
        public bool SetMonitorDictPatient(string wardType, string wardCode, string roomNo, string patientID, int visitID, int operID)
        {
            if (!string.IsNullOrEmpty(wardCode) && !string.IsNullOrEmpty(roomNo))
            {
                List<MED_MONITOR_DICT> monitorTable = comnDictRepository.GetMonitorDictList(wardType).Data;
                if (monitorTable != null && monitorTable.Count > 0)
                {
                    monitorTable.ForEach(row =>
                        {
                            if (!string.IsNullOrEmpty(row.WARD_CODE) && !string.IsNullOrEmpty(row.BED_NO)
                                && row.WARD_CODE.Equals(wardCode) && row.BED_NO.Equals(roomNo))
                            {
                                if (string.IsNullOrEmpty(patientID))
                                {
                                    row.PATIENT_ID = patientID;
                                    row.VISIT_ID = null;
                                    row.OPER_ID = null;
                                }
                                else
                                {
                                    row.PATIENT_ID = patientID;
                                    row.VISIT_ID = visitID;
                                    row.OPER_ID = operID;
                                }
                            }
                        });
                    if (comnDictRepository.SaveMonitorDictList(monitorTable).Data > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
