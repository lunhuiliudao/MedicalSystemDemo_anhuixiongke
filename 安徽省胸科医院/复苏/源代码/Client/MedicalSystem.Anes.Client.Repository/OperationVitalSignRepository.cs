using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class OperationVitalSignRepository : BaseRepository
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        /// <summary>
        /// 获取监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>监测数据表</returns>
        /// DATA_MARK 0-删除；1新增OR修改（手工录入）
        public List<MED_VITAL_SIGN> GetVitalSignData(string patientID, int visitID, int operID, string eventNo, bool isHistory)
        {
            List<MED_VITAL_SIGN> vitalSignList = new List<MED_VITAL_SIGN>();
            List<MED_PAT_MONITOR_DATA> patMonitorDataList = null;
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList = operationInfoRepository.GetPatMonitorExtList(patientID, visitID, operID).Data;
            List<MED_COMM_VITAL_REC> commVitalRecList = null;
            List<MED_PAT_MONITOR_DATA_EXT> monitorExtDeleteList = null;
            if (isHistory)
            {
                commVitalRecList = GetCommVitalRec(patientID, visitID, operID, eventNo);
                List<MED_COMM_VITAL_REC_EXTEND> commVitalRecListExtend = GetCommVitalRecExtend(patientID, visitID, operID, eventNo);
                monitorExtDeleteList = patMonitorExtList.Where(x => x.DATA_MARK == 0 && x.DATA_TYPE == eventNo).ToList();
                TransVitalSignData(vitalSignList, commVitalRecList, commVitalRecListExtend, monitorExtDeleteList);
            }
            else
            {
                patMonitorDataList = GetPatMonitorList(patientID, visitID, operID, eventNo);
                monitorExtDeleteList = patMonitorExtList.Where(x => x.DATA_MARK == 0 && x.DATA_TYPE == eventNo).ToList();
                TransVitalSignData(vitalSignList, patMonitorDataList, monitorExtDeleteList);
            }
            if (patMonitorDataList == null) patMonitorDataList = new List<MED_PAT_MONITOR_DATA>();
            if (patMonitorExtList != null && patMonitorExtList.Count > 0)
            {
                List<MED_PAT_MONITOR_DATA_EXT> monitorExtAddList = patMonitorExtList.Where(x => x.DATA_MARK == 1 && x.DATA_TYPE == eventNo).ToList();
                if (monitorExtAddList != null)
                    monitorExtAddList.ForEach(extRow =>
                    {
                        MED_VITAL_SIGN nrow = vitalSignList.FirstOrDefault(x => x.TIME_POINT.Equals(extRow.TIME_POINT) && x.ITEM_CODE.Equals(extRow.ITEM_CODE));
                        if (nrow != null)
                        {
                            nrow.ITEM_VALUE = extRow.ITEM_VALUE;
                            nrow.Flag = "1";
                        }
                        else
                        {
                            nrow = new MED_VITAL_SIGN();
                            nrow.ITEM_NAME = extRow.ITEM_NAME;
                            nrow.ITEM_CODE = extRow.ITEM_CODE;
                            nrow.TIME_POINT = extRow.TIME_POINT;
                            nrow.ITEM_VALUE = extRow.ITEM_VALUE;
                            nrow.Flag = "2";
                            vitalSignList.Add(nrow);
                        }
                    });
            }
            if (vitalSignList != null && vitalSignList.Count > 0)
            {
                vitalSignList = vitalSignList.OrderBy(x => x.TIME_POINT).ToList();
            }
            return vitalSignList;
        }
        public List<MED_PAT_MONITOR_DATA> GetPatMonitorList(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA> monitorData = operationInfoRepository.GetPatMonitorDataListByEvent(patientID, visitID, operID, eventNo).Data;
            if (monitorData != null && monitorData.Count > 0)
            {
                foreach (MED_PAT_MONITOR_DATA row in monitorData)
                {
                    row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
                }
            }
            return monitorData;
        }
        public List<MED_COMM_VITAL_REC> GetCommVitalRec(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC> commVitalData = operationInfoRepository.GetCommVitalRecListByEventNo(patientID, visitID, operID, eventNo).Data;
            if (commVitalData != null && commVitalData.Count > 0)
            {
                foreach (MED_COMM_VITAL_REC row in commVitalData)
                {
                    row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
                }
            }
            return commVitalData;
        }
        public List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtend(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC_EXTEND> commVitalExtendData = operationInfoRepository.GetCommVitalRecExtendListByEventNo(patientID, visitID, operID, eventNo).Data;
            if (commVitalExtendData != null && commVitalExtendData.Count > 0)
            {
                foreach (MED_COMM_VITAL_REC_EXTEND row in commVitalExtendData)
                {
                    row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
                }
            }
            return commVitalExtendData;
        }
        /// <summary>
        /// 取采集项目code和名称字典
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        public string[] GetVitalSignTitles(string patientID, int visitID, int operID, string eventNo)
        {
            //string[] monitorValues = null;
            List<string> monitorValueList = new List<string>();
            Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();
            //现 麻醉、复苏 检测采集项目，只取数据表中第一行 作为依据 ,固定为 0 ，
            List<MED_PAT_MONITOR_DATA> patMonitorDateDataTable = GetPatMonitorTitleRow(patientID, visitID, operID, eventNo);
            if (patMonitorDateDataTable != null && patMonitorDateDataTable.Count > 0)
            {
                foreach (MED_PAT_MONITOR_DATA row in patMonitorDateDataTable)
                {
                    if (!string.IsNullOrEmpty(row.ITEM_VALUE) && !string.IsNullOrEmpty(row.ITEM_NAME) && !monitorValueList.Contains(row.ITEM_CODE))
                    {
                        monitorValueList.Add(row.ITEM_CODE);
                    }
                }
            }
            if (monitorValueList.Count == 0)
            {
                List<MED_MONITOR_DICT> mointorDictDataTable = comnDictRepository.GetMonitorDictList(eventNo).Data;
                if (mointorDictDataTable != null)
                {
                    foreach (MED_MONITOR_DICT row in mointorDictDataTable)
                    {
                        if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.VISIT_ID.HasValue && row.OPER_ID.HasValue && row.PATIENT_ID.Equals(patientID)
                            && row.VISIT_ID.Equals(visitID) && row.OPER_ID.Equals(operID) && !string.IsNullOrEmpty(row.CURRENT_RECV_ITEMS))
                        {
                            string[] strs = row.CURRENT_RECV_ITEMS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string str in strs)
                            {
                                if (!string.IsNullOrEmpty(str.Trim()) && !monitorValueList.Contains(str.Trim()))
                                {
                                    monitorValueList.Add(str.Trim());
                                }
                            }
                        }
                    }
                }
            }
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable = operationInfoRepository.GetPatMonitorExtList(patientID, visitID, operID, eventNo).Data;

            if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
            {
                foreach (MED_PAT_MONITOR_DATA_EXT row in patMonitorDataExtDataTable)
                {
                    if (!string.IsNullOrEmpty(row.ITEM_VALUE) && !string.IsNullOrEmpty(row.ITEM_NAME) && !monitorValueList.Contains(row.ITEM_CODE))
                    {
                        monitorValueList.Add(row.ITEM_CODE);
                    }
                }
            }
            if (monitorValueList.Count == 0)
            {
                monitorValueList = new List<string>(new string[] { "40", "44", "65", "66", "71", "92", "188", "112", "148", "89", "90" });
            }

            return monitorValueList.ToArray();
        }
        public List<MED_MONITOR_FUNCTION_CODE> GetMonitorFunctionCodeList()
        {
            return comnDictRepository.GetMonitorFuctionCodeList().Data;
        }
        public List<MED_PAT_MONITOR_DATA> GetPatMonitorTitleRow(string patientID, int visitID, int operID, string eventNo)
        {
            return operationInfoRepository.GetPatMonitorDataListByEvent(patientID, visitID, operID, eventNo).Data;
        }
        private void TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_PAT_MONITOR_DATA> patMonitorDataDataTables, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            if (patMonitorDataDataTables != null && patMonitorDataDataTables.Count > 0)
            {
                patMonitorDataDataTables.ForEach(row =>
                {
                    List<MED_PAT_MONITOR_DATA_EXT> deleteList = patMonitorExtList.Where(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();
                    if (deleteList.Count == 0)
                    {
                        MED_VITAL_SIGN nrow = new MED_VITAL_SIGN();
                        nrow.ITEM_NAME = row.ITEM_NAME;
                        nrow.ITEM_CODE = row.ITEM_CODE;
                        nrow.TIME_POINT = row.TIME_POINT;
                        nrow.ITEM_VALUE = row.ITEM_VALUE;
                        vitalSignDataTable.Add(nrow);
                    }
                });
            }
        }
        private void TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_COMM_VITAL_REC> patMonitorHistoryList, List<MED_COMM_VITAL_REC_EXTEND> commVitalRecListExtend, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            if (patMonitorHistoryList != null && patMonitorHistoryList.Count > 0)
            {
                patMonitorHistoryList.ForEach(row =>
                {
                    row.ToVitalSignList().ForEach(item =>
                    {
                        bool exist = patMonitorExtList.Exists(x => x.TIME_POINT.Equals(item.TIME_POINT) && x.ITEM_CODE.Equals(item.ITEM_CODE));
                        if (!exist)
                        {
                            vitalSignDataTable.Add(item);
                        }
                    });
                });
            }
            if (commVitalRecListExtend != null && commVitalRecListExtend.Count > 0)
            {
                commVitalRecListExtend.ForEach(row =>
                {
                    bool exist = patMonitorExtList.Exists(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_CODE.Equals(row.ITEM_CODE));
                    if (!exist)
                    {
                        MED_VITAL_SIGN nrow = new MED_VITAL_SIGN();
                        nrow.ITEM_NAME = row.VITAL_SIGNS;
                        nrow.ITEM_CODE = row.ITEM_CODE;
                        nrow.TIME_POINT = row.TIME_POINT;
                        nrow.ITEM_VALUE = row.VITAL_SIGNS_VALUES;
                        vitalSignDataTable.Add(nrow);
                    }
                });
            }
        }
        /// <summary>
        /// 所有采集项目字典
        /// </summary>
        public Dictionary<string, string> GetMonitorFunctionCodeDict()
        {
            Dictionary<string, string> monitorFunctionCodeDict = new Dictionary<string, string>();
            List<MED_MONITOR_FUNCTION_CODE> monitorFunctionCodeDataTable = comnDictRepository.GetMonitorFuctionCodeList().Data;
            if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
            {
                monitorFunctionCodeDataTable.ForEach(codeRow =>
                {
                    if (!monitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                    {
                        if (!string.IsNullOrEmpty(codeRow.ITEM_NAME))
                            monitorFunctionCodeDict.Add(codeRow.ITEM_CODE, codeRow.ITEM_NAME);
                    }
                });

            }
            if (!monitorFunctionCodeDict.ContainsKey("ECG"))
            {
                monitorFunctionCodeDict.Add("ECG", "ECG");
            }
            return monitorFunctionCodeDict;
        }
    }
}
