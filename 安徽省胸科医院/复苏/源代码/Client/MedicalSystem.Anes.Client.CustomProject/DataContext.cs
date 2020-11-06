using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.DataServices.Domain;
using Newtonsoft.Json;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class DataContext
    {
        private static readonly DataContext _current = new DataContext();
        private Dictionary<string, DataTable> _data = new Dictionary<string, DataTable>();


        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        DocDataRepository docDataRepository = new DocDataRepository();

        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        OperationVitalSignRepository operationVitalSignRepository = new OperationVitalSignRepository();

        AccountRepository accountRepository = new AccountRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        /// <summary>
        /// 根据patientKey获取当前用户的数据上下文
        /// </summary>
        /// <param name="patientKey"></param>
        /// <returns></returns>
        public static DataContext GetCurrent()
        {
            _current._data.Clear();
            return _current;
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Clear()
        {
            _data.Clear();
        }
        /// <summary>
        /// 根据表名,获取数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetData(string tableName)
        {
            DataTable dt = null;
            if (_data.ContainsKey(tableName))
            {

                dt = _data[tableName];

            }
            else
            {
                dt = BuildData(tableName);
                _data.Add(tableName, dt);
            }
            return dt;
        }
        /// <summary>
        /// 根据表名从数据库中获取数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private DataTable BuildData(string tableName)
        {
            string patientId = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            int visitId = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            int operId = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            DataTable data = null;

            switch (tableName)
            {
                case "MED_PAT_MONITOR_DATA_EXT":

                    data = ModelHelper<MED_PAT_MONITOR_DATA_EXT>.ConvertListToDataTable(operationInfoRepository.GetPatMonitorExtList(patientId, visitId, operId).Data);
                    break;
                case "MED_OPERATION_MASTER":

                    data = ModelHelper<MED_OPERATION_MASTER>.ConvertSingleToDataTable(ExtendApplicationContext.Current.MED_OPERATION_MASTER == null
                        ? new MED_OPERATION_MASTER() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId } : operationInfoRepository.GetOperMaster(patientId, visitId, operId).Data);

                    break;
                case "MED_PAT_MASTER_INDEX":

                    data = ModelHelper<MED_PAT_MASTER_INDEX>.ConvertSingleToDataTable(ExtendApplicationContext.Current.MED_PAT_MASTER_INDEX == null
                        ? new MED_PAT_MASTER_INDEX() { PATIENT_ID = patientId } : operationInfoRepository.GetPatMasterIndex(patientId).Data);

                    break;
                case "MED_OPERATION_MASTER_EXT":

                    data = ModelHelper<MED_OPERATION_MASTER_EXT>.ConvertSingleToDataTable(operationInfoRepository.GetOperMasterExt(patientId, visitId, operId).Data);

                    if (data.Rows.Count == 0)
                    {
                        MED_OPERATION_MASTER_EXT model = new MED_OPERATION_MASTER_EXT() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_OPERATION_MASTER_EXT>.ConvertSingleToDataTable(model);
                    }
                    break;
                case "MED_PAT_VISIT":

                    data = ModelHelper<MED_PAT_VISIT>.ConvertSingleToDataTable(operationInfoRepository.GetPatVisit(patientId, visitId).Data);

                    if (data.Rows.Count == 0)
                    {
                        MED_PAT_VISIT model = new MED_PAT_VISIT() { PATIENT_ID = patientId, VISIT_ID = visitId };

                        data = ModelHelper<MED_PAT_VISIT>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_PATS_IN_HOSPITAL":

                    data = ModelHelper<MED_PATS_IN_HOSPITAL>.ConvertSingleToDataTable(docDataRepository.GetPatsInHospital(patientId, visitId));

                    if (data.Rows.Count == 0)
                    {
                        MED_PATS_IN_HOSPITAL model = new MED_PATS_IN_HOSPITAL() { PATIENT_ID = patientId, VISIT_ID = visitId };

                        data = ModelHelper<MED_PATS_IN_HOSPITAL>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_SAFETY_CHECKS":
                    data = ModelHelper<MED_SAFETY_CHECKS>.ConvertSingleToDataTable(docDataRepository.GetSafetyCheckData(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_SAFETY_CHECKS model = new MED_SAFETY_CHECKS() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_SAFETY_CHECKS>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_ANESTHESIA_PLAN":
                    data = ModelHelper<MED_ANESTHESIA_PLAN>.ConvertSingleToDataTable(docDataRepository.GetAnesthesiaPlan(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_ANESTHESIA_PLAN model = new MED_ANESTHESIA_PLAN() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_ANESTHESIA_PLAN>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_ANESTHESIA_PLAN_PMH":

                    data = ModelHelper<MED_ANESTHESIA_PLAN_PMH>.ConvertSingleToDataTable(docDataRepository.GetAnesthesiaPlanPMH(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_ANESTHESIA_PLAN_PMH model = new MED_ANESTHESIA_PLAN_PMH() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_ANESTHESIA_PLAN_PMH>.ConvertSingleToDataTable(model);
                    }
                    break;
                case "MED_ANESTHESIA_PLAN_EXAM":
                    data = ModelHelper<MED_ANESTHESIA_PLAN_EXAM>.ConvertSingleToDataTable(docDataRepository.GetAnesthesiaPlanEXAM(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_ANESTHESIA_PLAN_EXAM model = new MED_ANESTHESIA_PLAN_EXAM() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_ANESTHESIA_PLAN_EXAM>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_ANESTHESIA_RECOVER":
                    data = ModelHelper<MED_ANESTHESIA_RECOVER>.ConvertSingleToDataTable(docDataRepository.GetAnesRecoverData(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_ANESTHESIA_RECOVER model = new MED_ANESTHESIA_RECOVER() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_ANESTHESIA_RECOVER>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_ANESTHESIA_INQUIRY":
                    data = ModelHelper<MED_ANESTHESIA_INQUIRY>.ConvertSingleToDataTable(docDataRepository.GetAnesInquiry(patientId, visitId, operId, false));

                    if (data.Rows.Count == 0)
                    {
                        MED_ANESTHESIA_INQUIRY model = new MED_ANESTHESIA_INQUIRY() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_ANESTHESIA_INQUIRY>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_OPERATION_EXTENDED":
                    data = ModelHelper<MED_OPERATION_EXTENDED>.ConvertListToDataTable(commonRepository.GetOperExtended(patientId, visitId, operId).Data);
                    if (data.Rows.Count == 0)
                    {
                        data.Columns.Add(new DataColumn("PATIENT_ID", typeof(string)));
                        data.Columns.Add(new DataColumn("VISIT_ID", typeof(int)));
                        data.Columns.Add(new DataColumn("OPER_ID", typeof(int)));
                        data.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
                        data.Columns.Add(new DataColumn("ITEM_VALUE", typeof(string)));
                    }

                    break;
                case "MED_POSTOPERATIVE_EXTENDED":

                    data = ModelHelper<MED_POSTOPERATIVE_EXTENDED>.ConvertListToDataTable(commonRepository.GetPostoperativeExtended(patientId, visitId, operId).Data);

                    if (data.Rows.Count == 0)
                    {
                        data.Columns.Add(new DataColumn("PATIENT_ID",typeof(string)));
                        data.Columns.Add(new DataColumn("VISIT_ID", typeof(int)));
                        data.Columns.Add(new DataColumn("OPER_ID", typeof(int)));
                        data.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
                        data.Columns.Add(new DataColumn("ITEM_VALUE", typeof(string)));
                    }

                        break;
                case "MED_PREOPERATIVE_EXPANSION":

                    data = ModelHelper<MED_PREOPERATIVE_EXPANSION>.ConvertListToDataTable(commonRepository.GetPreoperativeExpansion(patientId, visitId, operId).Data);

                    if (data.Rows.Count == 0)
                    {
                        data.Columns.Add(new DataColumn("PATIENT_ID", typeof(string)));
                        data.Columns.Add(new DataColumn("VISIT_ID", typeof(int)));
                        data.Columns.Add(new DataColumn("OPER_ID", typeof(int)));
                        data.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
                        data.Columns.Add(new DataColumn("ITEM_VALUE", typeof(string)));
                    }

                    break;
                case "MED_OPERATION_ANALGESIC_MASTER":
                    data = ModelHelper<MED_OPERATION_ANALGESIC_MASTER>.ConvertSingleToDataTable(docDataRepository.GetAnalgesicMaster(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_OPERATION_ANALGESIC_MASTER model = new MED_OPERATION_ANALGESIC_MASTER() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_OPERATION_ANALGESIC_MASTER>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_OPER_RISK_ESTIMATE":

                    data = ModelHelper<MED_OPER_RISK_ESTIMATE>.ConvertSingleToDataTable(docDataRepository.GetRickEstimate(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_OPER_RISK_ESTIMATE model = new MED_OPER_RISK_ESTIMATE() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_OPER_RISK_ESTIMATE>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_OPER_ANALGESIC_MEDICINE":

                    data = ModelHelper<MED_OPER_ANALGESIC_MEDICINE>.ConvertListToDataTable(operationInfoRepository.GetAnalgesicMedicineList(patientId, visitId, operId).Data);

                    break;
                case "MED_OPER_ANALGESIC_TOTAL":
                    data = ModelHelper<MED_OPER_ANALGESIC_TOTAL>.ConvertListToDataTable(operationInfoRepository.GetAnalgesicTotalList(patientId, visitId, operId).Data);
                    break;
                case "MED_QIXIE_QINGDIAN":
                    data = ModelHelper<MED_QIXIE_QINGDIAN>.ConvertListToDataTable(operationInfoRepository.GetOperCheckList(patientId, visitId, operId).Data);
                    break;
                case "MED_ANESTHESIA_INPUT_DATA":
                    data = ModelHelper<MED_ANESTHESIA_INPUT_DATA>.ConvertSingleToDataTable(docDataRepository.GetAnesthestaInputData(patientId, visitId, operId));

                    if (data.Rows.Count == 0)
                    {
                        MED_ANESTHESIA_INPUT_DATA model = new MED_ANESTHESIA_INPUT_DATA() { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId };

                        data = ModelHelper<MED_ANESTHESIA_INPUT_DATA>.ConvertSingleToDataTable(model);
                    }

                    break;
                case "MED_BJCA_SIGN":

                    data = ModelHelper<MED_BJCA_SIGN>.ConvertListToDataTable(commonRepository.GetBjcaSignList(patientId, visitId, operId).Data);
                    break;
                default:
                    throw new NotImplementedException(string.Format("当前未定义从表{0}中获取数据的方法!", tableName));
            }
            return data;
        }

        public DataTable GetDictDataByTableName(string tableName)
        {
            DataTable data = null;
            switch (tableName)
            {
                case "MED_MONITOR_FUNCTION_CODE":
                    data = ModelHelper<MED_MONITOR_FUNCTION_CODE>.ConvertListToDataTable(comnDictRepository.GetMonitorFuctionCodeList().Data);
                    break;
                case "MED_EVENT_DICT":
                    data = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(comnDictRepository.GetEventDictList().Data);
                    break;
                case "MED_EVENT_DICT_EXT":
                    data = ModelHelper<MED_EVENT_DICT_EXT>.ConvertListToDataTable(comnDictRepository.GetAnesEventDictExt().Data);
                    break;
                case "MED_UNIT_DICT":
                    data = ModelHelper<MED_UNIT_DICT>.ConvertListToDataTable(comnDictRepository.GetUnitDictList().Data);
                    break;
                case "MED_ADMINISTRATION_DICT":
                    data = ModelHelper<MED_ADMINISTRATION_DICT>.ConvertListToDataTable(comnDictRepository.GetAdminstrationDictList().Data);
                    break;
                case "MED_EVENT_SORT":
                    data = ModelHelper<MED_EVENT_SORT>.ConvertListToDataTable(comnDictRepository.GetEventSortList(ExtendApplicationContext.Current.LoginUser.LOGIN_NAME).Data);
                    break;
                case "MED_HIS_USERS":
                    data = ModelHelper<MED_HIS_USERS>.ConvertListToDataTable(comnDictRepository.GetHisUsersList().Data);
                    break;
                case "MED_DEPT_DICT":
                    data = ModelHelper<MED_DEPT_DICT>.ConvertListToDataTable(comnDictRepository.GetDeptDictList().Data);
                    break;
                case "MED_OPERATING_ROOM":
                    data = ModelHelper<MED_OPERATING_ROOM>.ConvertListToDataTable(comnDictRepository.GetOperatingRoomList("0").Data);
                    break;
                case "MED_ANESTHESIA_INPUT_DICT":
                    data = ModelHelper<MED_ANESTHESIA_INPUT_DICT>.ConvertListToDataTable(comnDictRepository.GetAnesInputDictList(null).Data);
                    break;
                case "MED_BLOOD_GAS_DICT":
                    data = ModelHelper<MED_BLOOD_GAS_DICT>.ConvertListToDataTable(comnDictRepository.GetBloodGasDictList().Data);
                    break;
                case "MED_WARD_DICT":
                    data = ModelHelper<MED_WARD_DICT>.ConvertListToDataTable(comnDictRepository.GetWardDictList().Data);
                    break;
                case "MED_ANESTHESIA_DICT":
                    data = ModelHelper<MED_ANESTHESIA_DICT>.ConvertListToDataTable(comnDictRepository.GetAnesMethodDictList().Data);
                    break;
                case "MED_MONITOR_DICT":
                    data = ModelHelper<MED_MONITOR_DICT>.ConvertListToDataTable(comnDictRepository.GetMonitorDictList().Data);
                    break;
                case "MED_PAT_MONITOR_DATA_DICT":
                    data = ModelHelper<MED_PAT_MONITOR_DATA_DICT>.ConvertListToDataTable(comnDictRepository.GetPatMonitorDict().Data);
                    break;
            }
            return data;
        }

        /// <summary>
        /// 获取麻醉事件数据
        /// </summary>
        /// <param name="eventNo">事件类型：0-麻醉 1-复苏</param>
        /// <returns></returns>
        public List<MED_ANESTHESIA_EVENT> GetAnesthesiaEvent(string eventNo)
        {
            string patientId = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            int visitId = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            int operId = ExtendApplicationContext.Current.PatientContextExtend.OperID;

            var data = operationInfoRepository.GetAnesEventList(patientId, visitId, operId, eventNo).Data;
            return data;

        }
        public List<MED_ANESTHESIA_EVENT> GetAnesthesiaEvent()
        {
            string patientId = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            int visitId = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            int operId = ExtendApplicationContext.Current.PatientContextExtend.OperID;

            var data = operationInfoRepository.GetAnesEventList(patientId, visitId, operId).Data;
            return data;

        }
        public List<MED_VITAL_SIGN> GetVitalSignData(string eventNo)
        {
            string patientId = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            int visitId = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            int operId = ExtendApplicationContext.Current.PatientContextExtend.OperID;

            return operationVitalSignRepository.GetVitalSignData(patientId, visitId, operId, eventNo, false);
        }
        public List<MED_VITAL_SIGN> GetVitalSignData()
        {
            List<MED_VITAL_SIGN> anesData = GetVitalSignData("0");
            List<MED_VITAL_SIGN> pacuData = GetVitalSignData("1");
            {
                foreach (MED_VITAL_SIGN row in pacuData)
                {
                    MED_VITAL_SIGN prow = anesData.Where(x => x.TIME_POINT == row.TIME_POINT && x.ITEM_CODE == row.ITEM_CODE).FirstOrDefault();
                    if (prow != null)
                        continue;
                    else
                        anesData.Add(row);
                }
            }
            return anesData;
        }
        public string GetMonitorFunctionName(string code)
        {
            string result = code;
            // if (ExtendApplicationContext.Current.CodeTables.ContainsKey("MED_MONITOR_FUNCTION_CODE"))
            {
                List<MED_MONITOR_FUNCTION_CODE> functionCode = ExtendApplicationContext.Current.CommDict.MonitorFuntionDict;
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
        /// <summary>
        /// 获取麻醉单血气记录
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public List<BloodGasMaster> GetBloodGasItems(string patientID, int visitID, int operID)
        {
            List<BloodGasMaster> list = new List<BloodGasMaster>();
            string[] detailList = ExtendApplicationContext.Current.DefaultBloodGasItem.ToArray();
            List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = operationInfoRepository.GetBloodGasMasterList(patientID, visitID, operID).Data;
            if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count > 0)
            {
                List<MED_BLOOD_GAS_DETAIL> bloodGasDetailDataTable = null;
                bloodGasMasterDataTable.ForEach(row =>
                    {
                        if (null == row.NURSE_MEMO2 || string.IsNullOrEmpty(row.NURSE_MEMO2))
                        {
                            string typeName = "静脉";
                            if (!string.IsNullOrEmpty(row.NURSE_MEMO1))
                            {
                                typeName = row.NURSE_MEMO1;
                            }
                            else
                            {
                                typeName = "静脉";
                            }
                            BloodGasMaster item = new BloodGasMaster();
                            item.DetailId = row.DETAIL_ID;
                            item.DisplayName = typeName + "血气";
                            item.Recorddate = row.RECORD_DATE;
                            bloodGasDetailDataTable = operationInfoRepository.GetBloodGasDetailList(row.DETAIL_ID).Data;
                            if (bloodGasDetailDataTable != null && bloodGasDetailDataTable.Count > 0)
                            {
                                bloodGasDetailDataTable.ForEach(gasRow =>
                                    {
                                        BloodGasDetail detail = null;
                                        detail = new BloodGasDetail();
                                        detail.DetailId = gasRow.DETAIL_ID;
                                        detail.BloodGasCode = gasRow.BLG_CODE;
                                        detail.BloodGasValue = !string.IsNullOrEmpty(gasRow.BLG_VALUE) ? gasRow.BLG_VALUE : "";
                                        item.Details.Add(detail);
                                    });
                            }
                            list.Add(item);
                        }
                    });
            }
            if (list.Count > 0)
            {
                foreach (BloodGasMaster item in list)
                {
                    foreach (BloodGasDetail detail in item.Details)
                    {
                        if (ExtendApplicationContext.Current.BloodGasItemDict.ContainsKey(detail.BloodGasCode))
                        {
                            detail.BloodGasName = ExtendApplicationContext.Current.BloodGasItemDict[detail.BloodGasCode];
                        }
                    }
                }
            }
            return list;
        }

        public MED_ANESTHESIA_EVENT NewAnesthesiaEventRow(List<MED_ANESTHESIA_EVENT> anesthestaEventDataTable, string eventNo)
        {
            int maxItemNo = GetMaxItemNO(anesthestaEventDataTable);
            MED_ANESTHESIA_EVENT row = new MED_ANESTHESIA_EVENT();
            row.PATIENT_ID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            row.VISIT_ID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            row.OPER_ID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            row.EVENT_NO = eventNo;
            row.ITEM_NO = maxItemNo;

            //anesthestaEventDataTable.Rows.Add(row);
            return row;
        }
        public int GetMaxItemNO(List<MED_ANESTHESIA_EVENT> anesthestaEventDataTable)
        {
            int maxItemNo = 0;
            if (anesthestaEventDataTable != null && anesthestaEventDataTable.Count > 0)
            {
                anesthestaEventDataTable.ForEach(eventRow =>
                {
                    if (eventRow.ITEM_NO > maxItemNo) maxItemNo = eventRow.ITEM_NO;
                });
            }
            maxItemNo++;
            return maxItemNo;
        }

        private string _customDataTableNameList = "MED_OPERATION_ANALGESIC,MED_PAT_MASTER_INDEX,MED_ANESTHESIA_PLAN,MED_ANES_OPERHANDOVER,MED_OPERATION_MASTER,MED_PATS_IN_HOSPITAL,MED_OPERATION_SCHEDULE,MED_PAT_VISIT,MED_ANESTHESIA_SUMMARY";
        /// <summary>
        /// 刷新已经修改过的数据源，与源数据对比处理并发数据的问题
        /// </summary>
        /// <param name="dataSource"></param>
        public void RefreshDataSource(Dictionary<string, DataTable> dataSource)
        {
            List<string> keyList = new List<string>();//定义表名集合，用于处理字典内部的DataTable
            foreach (var item in dataSource)
            {
                keyList.Add(item.Key);
            }
            foreach (string tableName in keyList)
            {
                if (!_customDataTableNameList.Contains(tableName)) continue;//如果不在需要处理的表集合内就不处理
                dataSource[tableName] = CopyRow(dataSource[tableName], BuildData(tableName));
            }
        }

        /// <summary>
        /// 与源数据对比处理并发数据的问题
        /// </summary>
        /// <param name="sourceDT">源数据表</param>
        /// <param name="currentDT">当前数据库的数据</param>
        /// <returns></returns>
        private DataTable CopyRow(DataTable sourceDT, DataTable currentDT)
        {
            if (sourceDT.TableName == currentDT.TableName && sourceDT.Rows.Count > 0 && currentDT.Rows.Count > 0)//表名不同或者没数据的不考虑
            {
                DataRow sourceRow = sourceDT.Rows[0];
                DataRow currentRow = currentDT.Rows[0];
                if (sourceRow.RowState != DataRowState.Added) return sourceDT;//如果不是内存数据表新增的行就不考虑
                foreach (DataColumn col in sourceDT.Columns)
                {
                    if (!sourceRow.IsNull(col.ColumnName) && !string.IsNullOrEmpty(sourceRow[col].ToString()))//遍历列数据
                    {
                        currentRow[col.ColumnName] = sourceRow[col.ColumnName];
                    }
                }
                return currentDT;//如果需要处理就返回处理过的数据表
            }
            else
            {
                return sourceDT;
            }
        }
        public bool SetBreathParas(string patientID, int visitID, int operID, DateTime timePoint, string code1, string code2, string code3, string value1, string value2, string value3)
        {
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable = operationInfoRepository.GetPatMonitorExtList(patientID, visitID, operID).Data;
            if (patMonitorDataExtDataTable != null)
            {
                UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code1, value1);
                UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code2, value2);
                UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code3, value3);
                return operationInfoRepository.SavePatMonitorExtList(patMonitorDataExtDataTable).Result == ResultStatus.Success ? true : false;
            }
            return false;
        }
        private void UpdateBreathPara(List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable, string patientID, int visitID, int operID, DateTime timePoint, string code, string value)
        {
            List<MED_PAT_MONITOR_DATA_EXT> rows = patMonitorDataExtDataTable.Where(x => x.ITEM_CODE == code && x.TIME_POINT == timePoint).ToList();
            if (rows.Count == 1)
            {
                rows[0].ITEM_VALUE = value;
            }
            else
            {
                MED_PAT_MONITOR_DATA_EXT row = new MED_PAT_MONITOR_DATA_EXT();
                row.PATIENT_ID = patientID;
                row.VISIT_ID = visitID;
                row.OPER_ID = operID;
                row.TIME_POINT = timePoint;
                row.ITEM_CODE = code;
                row.ITEM_VALUE = value;
                row.DATA_MARK = 1;
                row.DATA_TYPE = "0";
                patMonitorDataExtDataTable.Add(row);
            }
        }
        public bool CancelBloodGas(MedVitalSignGraph vitalSignGraph)
        {
            bool n = false;
            if (vitalSignGraph != null && vitalSignGraph.MouseTime >= vitalSignGraph.StartTime && vitalSignGraph.MouseTime <= vitalSignGraph.EndTime && vitalSignGraph.SelectedBlood != null)
            {
                List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = operationInfoRepository.GetBloodGasMasterListByID(vitalSignGraph.SelectedBlood.DetailId).Data;
                if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
                {
                    bloodGasMasterDataTable[0].NURSE_MEMO2 = "取消显示";
                    n = operationInfoRepository.SaveBloodGasMaster(bloodGasMasterDataTable).Data > 0 ? true : false;
                }
            }
            return n;
        }
        public bool CalTextValue(MTextBox textbox, Dictionary<string, System.Data.DataTable> dataSources)
        {
            bool isChanged = true;// 用于判断自动计算的值和原值是否有变化
            if (textbox.SummaryName.Trim() == "病人在室时间")// 移植一体机的计算方式
            {
                double d = this.CalRoomStayedTime(dataSources);
                if (d.ToString("f0").Equals(textbox.Text))
                {
                    isChanged = false;
                }
                else
                {
                    textbox.Text = d > 0 ? d.ToString("f0") : string.Empty;
                    textbox.Data = textbox.Text;
                }
            }
            else if (textbox.SummaryName.Trim() == "病人手术时长")
            {
                double d = this.CalOperTime(dataSources);
                if (d.ToString("f0").Equals(textbox.Text))
                {
                    isChanged = false;
                }
                else
                {
                    textbox.Text = d > 0 ? d.ToString("f0") : string.Empty;
                    textbox.Data = textbox.Text;
                }

            }
            else
            {
                double d = CalLiquiedSum(textbox.SummaryName, dataSources);
                if (d.ToString("f0").Equals(textbox.Text))
                {
                    isChanged = false;
                }
                else
                    textbox.Text = d > 0 ? d.ToString("f0") : string.Empty;
            }


            if (string.IsNullOrEmpty(textbox.Text))
            {
                return false;
            }
            else
            {
                return isChanged;// isChanged的值为true则说明值改变了
            }
        }

        double CalLiquiedSum(string liquiedName, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("AnesAllEvent")) return 0;
            List<MED_ANESTHESIA_EVENT> anesEventAll = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(dataSources["AnesAllEvent"]);

            if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("MED_EVENT_DICT")) return 0;
            List<MED_EVENT_DICT> eventDictList = ExtendApplicationContext.Current.CommDict.EventDict;
            double d = 0;
            if (anesEventAll == null || anesEventAll.Count == 0) return 0;
            foreach (MED_ANESTHESIA_EVENT row in anesEventAll)
            {
                if (row.DOSAGE.HasValue && row.DOSAGE > 0)
                {
                    if (liquiedName.Equals("总入量"))
                    {
                        if (row.EVENT_CLASS_CODE == "3" || row.EVENT_CLASS_CODE == "B")
                            d += (double)row.DOSAGE;
                    }
                    else if (liquiedName.Equals("总输液量"))
                    {
                        if (row.EVENT_CLASS_CODE == "3")
                            d += (double)row.DOSAGE;
                    }
                    else if (liquiedName.Equals("总输血量"))
                    {
                        if (row.EVENT_CLASS_CODE == "B")
                            d += (double)row.DOSAGE;
                    }
                    else if (liquiedName.Equals("总出量"))
                    {
                        if (row.EVENT_CLASS_CODE == "D")
                            d += (double)row.DOSAGE;
                    }
                    else if (liquiedName.Equals("其他出量"))
                    {
                        if (row.EVENT_CLASS_CODE == "D" && string.IsNullOrEmpty(row.EVENT_ATTR))
                            d += (double)row.DOSAGE;
                    }
                    else if (liquiedName.Equals("其他入量"))
                    {
                        //if ((row.EVENT_CLASS_CODE == "3" || row.EVENT_CLASS_CODE == "B") && string.IsNullOrEmpty(row.EVENT_ATTR))
                        //    d += (double)row.DOSAGE;
                    }
                    else
                    {
                        List<MED_EVENT_DICT> eventRow = eventDictList.Where(x => x.EVENT_CLASS_CODE == row.EVENT_CLASS_CODE && x.EVENT_ITEM_NAME == row.EVENT_ITEM_NAME).ToList();
                        if (eventRow != null && eventRow.Count > 0 && !string.IsNullOrEmpty(eventRow[0].EVENT_ATTR) && eventRow[0].EVENT_ATTR.Equals(liquiedName))
                        {
                            d += (double)row.DOSAGE;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return d;
        }

        /// <summary>
        /// 获取入室时间 至  出室时间的时长
        /// </summary>
        public double CalRoomStayedTime(Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("MED_OPERATION_MASTER"))
            {
                return 0;
            }

            List<MED_OPERATION_MASTER> operMasterList = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSources["MED_OPERATION_MASTER"]);
            if (operMasterList != null && operMasterList.Count == 1 &&
                operMasterList[0].IN_DATE_TIME.HasValue && operMasterList[0].OUT_DATE_TIME.HasValue)
            {
                return ((TimeSpan)(operMasterList[0].OUT_DATE_TIME - operMasterList[0].IN_DATE_TIME)).TotalMinutes;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取手术开始至手术结束的时长
        /// </summary>
        public double CalOperTime(Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("MED_OPERATION_MASTER"))
            {
                return 0;
            }
            List<MED_OPERATION_MASTER> operMasterList = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSources["MED_OPERATION_MASTER"]);
            if (operMasterList != null && operMasterList.Count == 1 &&
                operMasterList[0].START_DATE_TIME.HasValue && operMasterList[0].END_DATE_TIME.HasValue)
            {
                return ((TimeSpan)(operMasterList[0].END_DATE_TIME - operMasterList[0].START_DATE_TIME)).TotalMinutes;
            }
            else
            {
                return 0;
            }
        }

        public bool InsertEmrArchiveRecord(string pageName, int times, string fileName, string path)
        {
            try
            {
                string patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
                int visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
                int operID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
                string user = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                List<MED_EMR_ARCHIVE_DETIAL> emrList = commonRepository.GetEmrArchiveList(patientID, visitID, operID.ToString(), pageName).Data;
                if (emrList != null && emrList.Count > 0)
                {
                    foreach (MED_EMR_ARCHIVE_DETIAL list in emrList)
                    {
                        list.ARCHIVE_STATUS = "作废";
                    }
                }
                MED_EMR_ARCHIVE_DETIAL row = new MED_EMR_ARCHIVE_DETIAL();
                row.PATIENT_ID = patientID;
                row.VISIT_ID = visitID;
                row.MR_CLASS = "麻醉";
                row.MR_SUB_CLASS = pageName;
                row.ARCHIVE_KEY = operID.ToString();
                row.EMR_FILE_INDEX = 0;
                row.ARCHIVE_TIMES = times;
                row.TOPIC = pageName + "_" + operID.ToString();
                row.EMR_FILE_NAME = fileName;
                row.EMR_TYPE = "PDF";
                row.ARCHIVE_DATE_TIME = accountRepository.GetServerTime().Data;
                row.ARCHIVE_TYPE = "正常";
                row.ARCHIVE_STATUS = "已归档";
                row.EMR_OWNER = user;
                row.OPERATOR = user;
                row.ARCHIVE_MODE = "分布";
                row.ARCHIVE_ACCESS = path;
                emrList.Add(row);
                bool res = commonRepository.SaveEmrArchiveList(emrList).Data > 0 ? true : false;

                if (ApplicationConfiguration.IsUpdateHisStatus)
                {
                    string ret = syncInfoRepository.SyncOPER505W(row).Data;
                }

                return res;
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }

            return false;
        }
    }
}
