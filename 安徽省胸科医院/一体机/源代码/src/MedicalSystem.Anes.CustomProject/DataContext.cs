// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DataContext.cs
// 功能描述(Description)：    文书模块上下文实体类，用以文书的数据获取和保存
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 文书模块上下文实体类，用以文书的数据获取和保存
    /// </summary>
    public class DataContext
    {
        private static readonly DataContext _current = new DataContext();                                   // 单例对象
        private Dictionary<string, DataTable> _data = new Dictionary<string, DataTable>();                  // 数据字典
        private List<MED_EVENT_DICT> eventDictList = DictService.ClientInstance.GetEventDictList();         // 事件字典列表

        /// <summary>
        /// 文书需要处理的数据源表名，如果不在需要处理的表集合内就不处理
        /// </summary>
        private string _customDataTableNameList = @"MED_OPERATION_ANALGESIC,MED_PAT_MASTER_INDEX,MED_ANESTHESIA_PLAN,
                                                    MED_ANES_OPERHANDOVER,MED_OPERATION_MASTER,MED_PATS_IN_HOSPITAL,
                                                    MED_OPERATION_SCHEDULE,MED_PAT_VISIT,MED_ANESTHESIA_SUMMARY";

        /// <summary>
        /// 静态方法：获取对象实例，使用单例模式
        /// </summary>
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
        private DataTable BuildData(string tableName)
        {
            DataTable data = null;
            string patientId;
            int visitId;
            int operId;
            if (ExtendAppContext.Current.PatientInformationExtend == null)
            {
                patientId = ExtendAppContext.Current.PatientID;
                visitId = ExtendAppContext.Current.VisitID;
                operId = ExtendAppContext.Current.OperID;
            }
            else
            {
                patientId = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                visitId = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                operId = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            }


            switch (tableName)
            {
                case "MED_PAT_MONITOR_DATA_EXT":
                    data = new ModelHandler<MED_PAT_MONITOR_DATA_EXT>().FillDataTable(AnesInfoService.ClientInstance.GetPatMonitorExtList(patientId, visitId, operId));
                    if (data.Rows.Count == 0)
                    {
                        DataRow row = data.NewRow();
                        row["PATIENT_ID"] = patientId;
                        row["VISIT_ID"] = visitId;
                        row["OPER_ID"] = operId;
                        data.Rows.Add(row);
                    }
                    break;
                case "MED_OPERATION_MASTER":
                    data = new ModelHandler<MED_OPERATION_MASTER>().FillDataTable(AnesInfoService.ClientInstance.GetOperationMaster(patientId, visitId, operId));
                    if (data.Rows.Count == 0)
                    {
                        DataRow row = data.NewRow();
                        row["PATIENT_ID"] = patientId;
                        row["VISIT_ID"] = visitId;
                        row["OPER_ID"] = operId;
                        data.Rows.Add(row);
                    }
                    break;
                case "MED_OPERATION_MASTER_EXT":
                    data = new ModelHandler<MED_OPERATION_MASTER_EXT>().FillDataTable(AnesInfoService.ClientInstance.GetOperationMasterExt(patientId, visitId, operId));
                    if (data.Rows.Count == 0)
                    {
                        DataRow row = data.NewRow();
                        row["PATIENT_ID"] = patientId;
                        row["VISIT_ID"] = visitId;
                        row["OPER_ID"] = operId;
                        data.Rows.Add(row);
                    }
                    break;
                case "MED_PAT_MASTER_INDEX":
                    data = new ModelHandler<MED_PAT_MASTER_INDEX>().FillDataTable(AnesInfoService.ClientInstance.GetPatMasterIndex(patientId));
                    if (data.Rows.Count == 0)
                    {
                        DataRow row = data.NewRow();
                        row["PATIENT_ID"] = patientId;
                        data.Rows.Add(row);
                    }
                    break;
                case "MED_PAT_VISIT":
                    data = new ModelHandler<MED_PAT_VISIT>().FillDataTable(CareDocService.ClientInstance.GetPatVisit(patientId, visitId));
                    break;
                case "MED_PATS_IN_HOSPITAL":
                    data = new ModelHandler<MED_PATS_IN_HOSPITAL>().FillDataTable(AnesInfoService.ClientInstance.GetPatsInHospitalList(patientId, visitId));
                    if (data.Rows.Count == 0)
                    {
                        DataRow row = data.NewRow();
                        row["PATIENT_ID"] = patientId;
                        row["VISIT_ID"] = visitId;
                        data.Rows.Add(row);
                    }
                    break;
                case "MED_SAFETY_CHECKS":
                    data = new ModelHandler<MED_SAFETY_CHECKS>().FillDataTable(CareDocService.ClientInstance.GetSafetyCheckData(patientId, visitId, operId));
                    break;
                case "MED_ANESTHESIA_PLAN":
                    data = new ModelHandler<MED_ANESTHESIA_PLAN>().FillDataTable(AnesInfoService.ClientInstance.GetAnesthesiaPlan(patientId, visitId, operId));
                    if (data.Rows.Count == 0)
                    {
                        DataRow row = data.NewRow();
                        row["PATIENT_ID"] = patientId;
                        row["VISIT_ID"] = visitId;
                        row["OPER_ID"] = operId;
                        data.Rows.Add(row);
                    }
                    break;
                case "MED_ANESTHESIA_PLAN_PMH":
                    data = new ModelHandler<MED_ANESTHESIA_PLAN_PMH>().FillDataTable(CareDocService.ClientInstance.GetAnesthesiaPlanPMH(patientId, visitId, operId));
                    break;
                case "MED_ANESTHESIA_PLAN_EXAM":
                    data = new ModelHandler<MED_ANESTHESIA_PLAN_EXAM>().FillDataTable(CareDocService.ClientInstance.GetAnesthesiaPlanEXAM(patientId, visitId, operId));
                    break;
                case "MED_ANESTHESIA_RECOVER":
                    data = new ModelHandler<MED_ANESTHESIA_RECOVER>().FillDataTable(CareDocService.ClientInstance.GetAnesRecoverData(patientId, visitId, operId));
                    break;
                case "MED_ANESTHESIA_INQUIRY":
                    data = new ModelHandler<MED_ANESTHESIA_INQUIRY>().FillDataTable(CareDocService.ClientInstance.GetAnesInquiry(patientId, visitId, operId));
                    break;
                case "MED_OPERATION_EXTENDED":
                    data = new ModelHandler<MED_OPERATION_EXTENDED>().FillDataTable(CareDocService.ClientInstance.GetOperExtended(patientId, visitId, operId));
                    break;
                case "MED_POSTOPERATIVE_EXTENDED":
                    data = new ModelHandler<MED_POSTOPERATIVE_EXTENDED>().FillDataTable(CareDocService.ClientInstance.GetPostoperativeExtended(patientId, visitId, operId));
                    break;
                case "MED_PREOPERATIVE_EXPANSION":
                    data = new ModelHandler<MED_PREOPERATIVE_EXPANSION>().FillDataTable(CareDocService.ClientInstance.GetPreoperativeExpansion(patientId, visitId, operId));
                    break;
                case "MED_OPERATION_ANALGESIC_MASTER":
                    data = new ModelHandler<MED_OPERATION_ANALGESIC_MASTER>().FillDataTable(CareDocService.ClientInstance.GetAnalgesicMaster(patientId, visitId, operId));
                    break;
                case "MED_OPER_RISK_ESTIMATE":
                    data = new ModelHandler<MED_OPER_RISK_ESTIMATE>().FillDataTable(CareDocService.ClientInstance.GetRickEstimate(patientId, visitId, operId));
                    break;
                case "MED_OPER_ANALGESIC_MEDICINE":
                    data = new ModelHandler<MED_OPER_ANALGESIC_MEDICINE>().FillDataTable(CareDocService.ClientInstance.GetAnalgesicMedicineList(patientId, visitId, operId));
                    break;
                case "MED_OPER_ANALGESIC_TOTAL":
                    data = new ModelHandler<MED_OPER_ANALGESIC_TOTAL>().FillDataTable(CareDocService.ClientInstance.GetAnalgesicTotalList(patientId, visitId, operId));
                    break;
                case "MED_QIXIE_QINGDIAN":
                    data = new ModelHandler<MED_QIXIE_QINGDIAN>().FillDataTable(CareDocService.ClientInstance.GetOperCheckList(patientId, visitId, operId));
                    break;
                case "MED_ANESTHESIA_INPUT_DATA":
                    data = new ModelHandler<MED_ANESTHESIA_INPUT_DATA>().FillDataTable(CareDocService.ClientInstance.GetAnesthestaInputData(patientId, visitId, operId));
                    break;
                case "MED_PACU_SORCE":
                    data = new ModelHandler<MED_PACU_SORCE>().FillDataTable(CareDocService.ClientInstance.GetPACUStore(patientId, visitId, operId));
                    break;
                case "MED_BJCA_SIGN":
                    List<MED_BJCA_SIGN> caList = CareDocService.ClientInstance.GetBjcaSignList(patientId, visitId, operId, ExtendAppContext.Current.CurrentDocName);
                    data = new ModelHandler<MED_BJCA_SIGN>().FillDataTable(caList);
                    break;
                default:
                    throw new NotImplementedException(string.Format("当前未定义从表{0}中获取数据的方法!", tableName));
            }

            return data;
        }

        /// <summary>
        /// 获取处方单信息
        /// </summary>
        public DataTable GetMedChuFangRecordList(string patientID, int visitID, int operID, int chuFangClass)
        {
            DataTable data = new ModelHandler<MED_CHUFANG_RECORD>().FillDataTable(CareDocService.ClientInstance.GetMedChuFangRecordList(patientID, visitID, operID, chuFangClass));

            if (data.Rows.Count == 0)
            {
                DataRow row = data.NewRow();
                row["PATIENT_ID"] = patientID;
                row["VISIT_ID"] = visitID;
                row["OPER_ID"] = operID;
                row["CHUFANG_CLASS"] = chuFangClass;
                long maxIndex = CareDocService.ClientInstance.GetMedChuFangRecordMaxIndex();
                row["CHUFANG_INDEX"] = maxIndex;
                data.Rows.Add(row);

                // 先自动生成编号
                MED_CHUFANG_RECORD tempRecord = new MED_CHUFANG_RECORD
                {
                    PATIENT_ID = patientID,
                    VISIT_ID = visitID,
                    OPER_ID = operID,
                    CHUFANG_CLASS = chuFangClass,
                    CHUFANG_INDEX = maxIndex
                };

                CareDocService.ClientInstance.SaveMedChuFangRecord(tempRecord);
            }

            return data;
        }

        /// <summary>
        /// 根据表名获得字典表
        /// </summary>
        public DataTable GetDictDataByTableName(string tableName)
        {
            DataTable data = null;
            switch (tableName)
            {
                case "MED_MONITOR_FUNCTION_CODE":
                    data = new ModelHandler<MED_MONITOR_FUNCTION_CODE>().FillDataTable(ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList);
                    break;
                case "MED_EVENT_DICT":
                    data = new ModelHandler<MED_EVENT_DICT>().FillDataTable(DictService.ClientInstance.GetEventDictList());
                    break;
                case "MED_EVENT_DICT_EXT":
                    data = new ModelHandler<MED_EVENT_DICT_EXT>().FillDataTable(DictService.ClientInstance.GetEventDictExtList());
                    break;
                case "MED_UNIT_DICT":
                    data = new ModelHandler<MED_UNIT_DICT>().FillDataTable(DictService.ClientInstance.GetUnitDictList());
                    break;
                case "MED_ADMINISTRATION_DICT":
                    data = new ModelHandler<MED_ADMINISTRATION_DICT>().FillDataTable(DictService.ClientInstance.GetMedAdministrationDict());
                    break;
                case "MED_EVENT_SORT":
                    data = new ModelHandler<MED_EVENT_SORT>().FillDataTable(DictService.ClientInstance.GetEventSortList(ExtendAppContext.Current.LoginUser.LOGIN_NAME));
                    break;
                case "MED_HIS_USERS":
                    data = new ModelHandler<MED_HIS_USERS>().FillDataTable(DictService.ClientInstance.GetHisUsersList());
                    break;
                case "MED_DEPT_DICT":
                    data = new ModelHandler<MED_DEPT_DICT>().FillDataTable(DictService.ClientInstance.GetDeptDictList());
                    break;
                case "MED_OPERATING_ROOM":
                    data = new ModelHandler<MED_OPERATING_ROOM>().FillDataTable(DictService.ClientInstance.GetOperatingRoomListByType("0", ExtendAppContext.Current.OperDeptCode));
                    break;
                case "MED_ANESTHESIA_INPUT_DICT":
                    data = new ModelHandler<MED_ANESTHESIA_INPUT_DICT>().FillDataTable(DictService.ClientInstance.GetAnesthesiaInputDictList());
                    break;
                case "MED_BLOOD_GAS_DICT":
                    data = new ModelHandler<MED_BLOOD_GAS_DICT>().FillDataTable(ApplicationModel.Instance.AllDictList.BloodGasDictList);
                    break;
                case "MED_WARD_DICT":
                    data = new ModelHandler<MED_WARD_DICT>().FillDataTable(DictService.ClientInstance.GetWardDictList());
                    break;
                case "MED_ANESTHESIA_DICT":
                    data = new ModelHandler<MED_ANESTHESIA_DICT>().FillDataTable(DictService.ClientInstance.GetAnesthesiaDictList());
                    break;
                case "MED_MONITOR_DICT":
                    data = new ModelHandler<MED_MONITOR_DICT>().FillDataTable(DictService.ClientInstance.GetMonitorDictList());
                    break;
                case "MED_PAT_MONITOR_DATA_DICT":
                    data = new ModelHandler<MED_PAT_MONITOR_DATA_DICT>().FillDataTable(DictService.ClientInstance.GetPatMonitorDict());
                    break;
            }

            return data;
        }

        /// <summary>
        /// 根据事件类型获取麻醉事件数据
        /// </summary>
        /// <param name="eventNo">事件类型：0-麻醉 1-复苏</param>
        public List<MED_ANESTHESIA_EVENT> GetAnesthesiaEvent(string eventNo)
        {
            string patientId = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitId = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operId = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            var data = AnesInfoService.ClientInstance.GetAnesthesiaEventByEventNo(patientId, visitId, operId, eventNo);
            return data;
        }

        /// <summary>
        /// 根据患者ID获取患者的所有事件信息，包含麻醉和复苏
        /// </summary>
        public List<MED_ANESTHESIA_EVENT> GetAnesthesiaEvent()
        {
            string patientId = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitId = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operId = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            var data = AnesInfoService.ClientInstance.GetAnesthesiaEventList(patientId, visitId, operId);
            return data;
        }

        /// <summary>
        /// 根据事件类型获取体征数据
        /// </summary>
        /// <param name="eventNo">事件类型：0-麻醉 1-复苏</param>
        public List<MED_VITAL_SIGN> GetVitalSignData(string eventNo)
        {
            string patientId = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitId = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operId = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            return AnesInfoService.ClientInstance.GetVitalSignData(patientId, visitId, operId, eventNo, false);
        }

        /// <summary>
        /// 根据患者ID获取患者的所有体征信息，包含麻醉和复苏
        /// </summary>
        public List<MED_VITAL_SIGN> GetVitalSignData()
        {
            List<MED_VITAL_SIGN> anesData = GetVitalSignData("0");
            List<MED_VITAL_SIGN> pacuData = GetVitalSignData("1");
            foreach (MED_VITAL_SIGN row in pacuData)
            {
                MED_VITAL_SIGN prow = anesData.Where(x => x.TIME_POINT == row.TIME_POINT && x.ITEM_CODE == row.ITEM_CODE).FirstOrDefault();
                if (prow != null)
                    continue;
                else
                    anesData.Add(row);
            }

            return anesData;
        }

        /// <summary>
        /// 根据体征代码获取体征名称
        /// </summary>
        public string GetMonitorFunctionName(string code)
        {
            string result = code;
            if (null != ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList)
            {
                List<MED_MONITOR_FUNCTION_CODE> functionList = ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList.Where(x => x.ITEM_CODE.Equals(code)).ToList();
                if (functionList != null && functionList.Count > 0)
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
        /// 获取麻醉单血气记录,修改数据另存
        /// </summary>
        public List<BloodGasMaster> GetBloodGasItems(string patientID, int visitID, int operID)
        {
            List<BloodGasMaster> list = new List<BloodGasMaster>();
            List<MED_BLOOD_GAS_DICT> bloodGasDict = ApplicationModel.Instance.AllDictList.BloodGasDictList;
            string[] detailList = ExtendAppContext.Current.DefaultBloodGasItem.ToArray();
            List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = AnesInfoService.ClientInstance.GetBloodGasMasterList(patientID, visitID, operID);
            if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count > 0)
            {
                List<MED_BLOOD_GAS_DETAIL_SHOW> bloodGasDetailDataTable = null;
                bloodGasMasterDataTable.ForEach(row =>
                    {
                        if (!string.IsNullOrEmpty(row.NURSE_MEMO2) && row.NURSE_MEMO2.StartsWith("ok@"))
                        {
                            string typeName = "静脉";
                            if (!string.IsNullOrEmpty(row.NURSE_MEMO1))
                            {
                                typeName = row.NURSE_MEMO1;
                            }

                            BloodGasMaster item = new BloodGasMaster();
                            item.DetailId = row.DETAIL_ID;
                            item.DisplayName = typeName + "血气";
                            item.Recorddate = row.RECORD_DATE;
                            //bloodGasDetailDataTable = AnesInfoService.ClientInstance.GetBloodGasDetailList(row.DETAIL_ID);
                            bloodGasDetailDataTable = this.GetDetailShowList(row.DETAIL_ID);
                            if (bloodGasDetailDataTable != null && bloodGasDetailDataTable.Count > 0)
                            {
                                bloodGasDetailDataTable.ForEach(detailRow =>
                                {
                                    if (!string.IsNullOrEmpty(detailRow.BLG_VALUE))
                                    {
                                        //foreach (var bloodGasDictItem in bloodGasDict)
                                        //{
                                        //MED_BLOOD_GAS_DETAIL tmpItem = bloodGasDetailDataTable.Find(x => x.BLG_CODE == bloodGasDictItem.BLG_CODE);
                                        //if (bloodGasDictItem != null && !string.IsNullOrEmpty(tmpItem.BLG_VALUE))
                                        //{
                                        BloodGasDetail detail = null;
                                        detail = new BloodGasDetail();
                                        detail.DetailId = detailRow.DETAIL_ID;
                                        detail.BloodGasCode = detailRow.BLG_CODE;
                                        detail.BloodGasValue = !string.IsNullOrEmpty(detailRow.BLG_VALUE) ? detailRow.BLG_VALUE : "";
                                        item.Details.Add(detail);
                                    }
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
                        if (ExtendAppContext.Current.BloodGasItemDict.ContainsKey(detail.BloodGasCode))
                        {
                            detail.BloodGasName = ExtendAppContext.Current.BloodGasItemDict[detail.BloodGasCode];
                        }
                    }
                }
            }

            return list;
        }

        private List<MED_BLOOD_GAS_DETAIL_SHOW> GetDetailShowList(string strDetailId)
        {
            List<MED_BLOOD_GAS_DETAIL_SHOW> originList = AnesInfoService.ClientInstance.GetBloodGasDetailShowList(strDetailId);

            List<MED_BLOOD_GAS_DETAIL_SHOW> extList = AnesInfoService.ClientInstance.GetBloodGasDetailExtShowList(strDetailId);

            List<MED_BLOOD_GAS_DETAIL_SHOW> result = new List<MED_BLOOD_GAS_DETAIL_SHOW>(extList);

            originList.ForEach(x =>
            {
                if (null == extList.FirstOrDefault(row => row.DETAIL_ID.Equals(x.DETAIL_ID) &&
                                                    row.BLG_CODE.Equals(x.BLG_CODE)))
                {
                    result.Add(x);
                }
            });

            return result;
        }

        /// <summary>
        /// 创建一条新的事件记录
        /// </summary>
        public MED_ANESTHESIA_EVENT NewAnesthesiaEventRow(List<MED_ANESTHESIA_EVENT> anesthestaEventDataTable, string eventNo)
        {
            int maxItemNo = GetMaxItemNO(anesthestaEventDataTable);
            MED_ANESTHESIA_EVENT row = new MED_ANESTHESIA_EVENT();
            row.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            row.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            row.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            row.EVENT_NO = eventNo;
            row.ITEM_NO = maxItemNo;
            return row;
        }

        /// <summary>
        /// 获取最大的ItemNO
        /// </summary>
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

        /// <summary>
        /// 刷新已经修改过的数据源，与源数据对比处理并发数据的问题
        /// </summary>
        public void RefreshDataSource(Dictionary<string, DataTable> dataSource)
        {
            // 定义表名集合，用于处理字典内部的DataTable
            List<string> keyList = new List<string>();
            foreach (var item in dataSource)
            {
                keyList.Add(item.Key);
            }

            foreach (string tableName in keyList)
            {
                // 如果不在需要处理的表集合内就不处理
                if (_customDataTableNameList.Contains(tableName))
                {
                    dataSource[tableName] = this.CopyRow(dataSource[tableName], BuildData(tableName));
                }
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
                // 如果不是内存数据表新增的行就不考虑
                if (sourceRow.RowState != DataRowState.Added)
                {
                    return sourceDT;
                }

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

        /// <summary>
        /// 设置体征项：呼吸 参数
        /// </summary>
        public bool SetBreathParas(string patientID, int visitID, int operID, DateTime timePoint, string code1, string code2, string code3, string value1, string value2, string value3)
        {
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable = AnesInfoService.ClientInstance.GetPatMonitorExtList(patientID, visitID, operID);
            if (patMonitorDataExtDataTable != null)
            {
                this.UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code1, value1);
                this.UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code2, value2);
                this.UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code3, value3);
                return AnesInfoService.ClientInstance.SavePatMonitorExtList(patMonitorDataExtDataTable);
            }

            return false;
        }

        /// <summary>
        /// 更改呼吸参数值
        /// </summary>
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

        /// <summary>
        /// 取消血气
        /// </summary>
        public bool CancelBloodGas(MedVitalSignGraph vitalSignGraph)
        {
            bool n = false;
            if (vitalSignGraph != null && vitalSignGraph.MouseTime >= vitalSignGraph.StartTime &&
                vitalSignGraph.MouseTime <= vitalSignGraph.EndTime && vitalSignGraph.SelectedBlood != null)
            {
                List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = AnesInfoService.ClientInstance.GetBloodGasMasterListByID(vitalSignGraph.SelectedBlood.DetailId);
                if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
                {
                    bloodGasMasterDataTable[0].NURSE_MEMO2 = null;
                    n = AnesInfoService.ClientInstance.SaveBloodGasMaster(bloodGasMasterDataTable);
                }
            }

            return n;
        }

        /// <summary>
        /// 获取对应的时长
        /// </summary>
        public void CalTextValue(MTextBox textbox, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (textbox.SummaryName.Trim() == "病人在室时间")
            {
                double d = this.CalRoomStayedTime(dataSources);
                textbox.Text = d > 0 ? d.ToString("f0") : string.Empty;
                textbox.Data = textbox.Text;
            }
            else if (textbox.SummaryName.Trim() == "病人手术时长")
            {
                double d = this.CalOperTime(dataSources);
                textbox.Text = d > 0 ? d.ToString("f0") : string.Empty;
                textbox.Data = textbox.Text;
            }
            else
            {
                double d = CalLiquiedSum(textbox.SummaryName, dataSources);
                textbox.Text = d > 0 ? d.ToString("f0") : string.Empty;
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
            List<MED_OPERATION_MASTER> operMasterList = new ModelHandler<MED_OPERATION_MASTER>().FillModel(dataSources["MED_OPERATION_MASTER"]);
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

        /// <summary>
        /// 获取入室时间 至  出室时间的时长
        /// </summary>
        public double CalRoomStayedTime(Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("MED_OPERATION_MASTER"))
            {
                return 0;
            }

            List<MED_OPERATION_MASTER> operMasterList = new ModelHandler<MED_OPERATION_MASTER>().FillModel(dataSources["MED_OPERATION_MASTER"]);
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
        /// 获取出入量数据
        /// </summary>
        public double CalLiquiedSum(string liquiedName, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("AnesAllEvent"))
            {
                return 0;
            }

            List<MED_ANESTHESIA_EVENT> anesEventAll = new ModelHandler<MED_ANESTHESIA_EVENT>().FillModel(dataSources["AnesAllEvent"]);
            if (!ExtendAppContext.Current.CodeTables.ContainsKey("MED_EVENT_DICT"))
            {
                return 0;
            }

            double d = 0;
            if (anesEventAll == null || anesEventAll.Count == 0)
            {
                return 0;
            }

            if (liquiedName == "输液总量" || liquiedName == "总入量")
            {
                List<MED_ANESTHESIA_EVENT> anesEventRow = anesEventAll.Where(x => x.EVENT_CLASS_CODE == "3" || x.EVENT_CLASS_CODE == "B").ToList();
                foreach (MED_ANESTHESIA_EVENT row in anesEventRow)
                {
                    if (row.DOSAGE.HasValue && row.DOSAGE > 0)
                    {
                        d += (double)row.DOSAGE;
                    }
                    else
                    {
                        continue;
                    }
                }

                return d;
            }
            else if (liquiedName == "总出量")
            {
                List<MED_ANESTHESIA_EVENT> anesEventRow = anesEventAll.Where(x => x.EVENT_CLASS_CODE == "D").ToList();
                foreach (MED_ANESTHESIA_EVENT row in anesEventRow)
                {
                    if (row.DOSAGE.HasValue && row.DOSAGE > 0)
                    {
                        d += (double)row.DOSAGE;
                    }
                    else
                    {
                        continue;
                    }
                }

                return d;
            }
            foreach (MED_ANESTHESIA_EVENT row in anesEventAll)
            {
                if (row.DOSAGE.HasValue && row.DOSAGE > 0)
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
                else
                {
                    continue;
                }
            }

            return d;
        }

        /// <summary>
        /// 新增电子病历上传记录
        /// </summary>
        public bool InsertEmrArchiveRecord(string pageName, int times, string fileName, string path)
        {
            try
            {
                string patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                int visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                int operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                string user = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                List<MED_EMR_ARCHIVE_DETIAL> emrList = CareDocService.ClientInstance.GetEmrArchiveList(patientID, visitID, operID.ToString(), pageName);
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
                row.ARCHIVE_DATE_TIME = DateTime.Now;
                row.ARCHIVE_TYPE = "正常";
                row.ARCHIVE_STATUS = "已归档";
                row.EMR_OWNER = user;
                row.OPERATOR = user;
                row.ARCHIVE_MODE = "分布";
                row.ARCHIVE_ACCESS = path;
                row.ModelStatus = ModelStatus.Add;
                emrList.Add(row);
                return CareDocService.ClientInstance.SaveEmrArchiveList(emrList);
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }

            return false;
        }
    }
}
