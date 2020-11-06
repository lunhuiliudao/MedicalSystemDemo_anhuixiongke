using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Xml;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
//using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformSurgicalMonitorService
    {
        /// <summary>
        /// 获取进行中的手术信息
        /// </summary>
        /// <returns>集合</returns>
        List<MED_OPERATION_MASTER> GetOpertingPatientList();

        /// <summary>
        /// 获取个性化体征配置
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="operID">operID</param>
        /// <param name="eventNo">eventNo</param>
        /// <returns></returns>
        dynamic GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo);

        /// <summary>
        /// 设置个性化体征通用配置
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        int UpdatePatientMonitorConfig(string patientID, int visitID, int operID, string eventNo, string content);


        //MED_PATIENT_MONITOR_CONFIG GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo);
        List<MED_VITAL_SIGN> GetVitalSignData(string patientID, int visitID, int operID, string eventNo, bool isHistory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        dynamic GetAnesthesiaEvent(string patientID, int visitID, int operID, DateTime startTime, DateTime endTime);

    }

    public class PlatformSurgicalMonitorService : BaseService<PlatformSurgicalMonitorService>, IPlatformSurgicalMonitorService
    {
        protected PlatformSurgicalMonitorService()
            : base() { }

        public PlatformSurgicalMonitorService(IDapperContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 获取进行中的手术信息
        /// </summary>
        /// <returns>集合</returns>
        public List<MED_OPERATION_MASTER> GetOpertingPatientList()
        {
            string sql = sqlDict.GetSQLByKey("OPERTINGPATIENTFOR");
            return dapper.Set<MED_OPERATION_MASTER>().Query(sql);
        }

        /// <summary>
        /// 获取个性化体征配置
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="operID">operID</param>
        /// <param name="eventNo">eventNo</param>
        /// <returns></returns>
        public dynamic GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        {
            MED_PATIENT_MONITOR_CONFIG patMonitorConfigList = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Single(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_NO == eventNo);
            //获取默认体征
            if (patMonitorConfigList == null)
            {
                patMonitorConfigList = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Single(
                x => x.PATIENT_ID == "999" && x.VISIT_ID == 0 && x.OPER_ID == 0 && x.EVENT_NO == eventNo);
            }
            if (patMonitorConfigList != null)
            {
                if (patMonitorConfigList.CONTENT != null)
                {
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(patMonitorConfigList.CONTENT))
                    {
                        stream.Position = 0;
                        using (DataSet ds = new DataSet())
                        {
                            ds.ReadXml(stream);
                            if (ds.Tables.Count > 0)
                            {
                                string tableName = "UserVitalShowSet" + ((Convert.ToInt32(eventNo) < 0) ? "0" : eventNo);
                                DataTable dataTable = ds.Tables[tableName];
                                return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dataTable));
                            }
                        }
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// 保存个性化体征通用配置
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="operID">operID</param>
        /// <param name="eventNo">eventNo</param>
        /// <returns></returns>
        public int UpdatePatientMonitorConfig(string patientID, int visitID, int operID, string eventNo, string content)
        {
            int type = 0;

            byte[] bytes;

            DataTable dataTable = JsonToDataTable(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content)));

            string tableName = "UserVitalShowSet" + ((Convert.ToInt32(eventNo) < 0) ? "0" : eventNo);

            dataTable.TableName = tableName;

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                dataTable.WriteXml(stream);
                stream.Position = 0;

                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
            }


            MED_PATIENT_MONITOR_CONFIG patMonitorConfigList = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Single(
            x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_NO == eventNo);

            if (patMonitorConfigList != null)
            {
                patMonitorConfigList.CONTENT = bytes;
                patMonitorConfigList.ModelStatus = ModelStatus.Modeified;

                type = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Update(patMonitorConfigList) > 0 ? 1 : 0;

            }
            else
            {
                patMonitorConfigList = new MED_PATIENT_MONITOR_CONFIG();

                patMonitorConfigList.PATIENT_ID = "999";
                patMonitorConfigList.VISIT_ID = 0;
                patMonitorConfigList.OPER_ID = 0;
                patMonitorConfigList.EVENT_NO = "0";

                patMonitorConfigList.CONTENT = bytes;
                patMonitorConfigList.ModelStatus = ModelStatus.Add;

                type = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Insert(patMonitorConfigList) ? 1 : 0;
            }

            dapper.SaveChanges();


            return type;
        }

        #region 获取体征数据

        //public virtual MED_PATIENT_MONITOR_CONFIG GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        //{
        //    MED_PATIENT_MONITOR_CONFIG patMonitorConfigList = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Single(
        //        x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_NO == eventNo);
        //    return patMonitorConfigList;
        //}

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
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList = GetPatMonitorExtList(patientID, visitID, operID);
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
                            nrow.ITEM_VALUE = extRow.ITEM_VALUE.Equals("/") ? "" : extRow.ITEM_VALUE;
                            nrow.Flag = "1";
                        }
                        else
                        {
                            nrow = new MED_VITAL_SIGN();
                            nrow.ITEM_NAME = extRow.ITEM_NAME;
                            nrow.ITEM_CODE = extRow.ITEM_CODE;
                            nrow.TIME_POINT = extRow.TIME_POINT;
                            nrow.ITEM_VALUE = extRow.ITEM_VALUE.Equals("/") ? "" : extRow.ITEM_VALUE;
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
            List<MED_PAT_MONITOR_DATA> monitorData = GetPatMonitorDataListByEvent(patientID, visitID, operID, eventNo);
            if (monitorData != null && monitorData.Count > 0)
            {
                foreach (MED_PAT_MONITOR_DATA row in monitorData)
                {
                    row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
                }
            }
            return monitorData;
        }

        /// <summary>
        /// 获取最新的病人体征
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <param name="eventNo">手术类型</param>
        /// <returns></returns>
        public List<MED_PAT_MONITOR_DATA> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA> monitorDataList = dapper.Set<MED_PAT_MONITOR_DATA>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.DATA_TYPE == eventNo).OrderBy(p => p.TIME_POINT).ToList();
            return monitorDataList;
        }

        /// <summary>
        /// 获取体征扩展表
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        public List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtList(string patientID, int visitID, int operID)
        {
            List<MED_PAT_MONITOR_DATA_EXT> monitorDataList = dapper.Set<MED_PAT_MONITOR_DATA_EXT>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(p => p.TIME_POINT).ToList();
            return monitorDataList;
        }

        /// <summary>
        /// 密集体征
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public List<MED_COMM_VITAL_REC> GetCommVitalRecList(string patientID, int visitID, int operID)
        {
            List<MED_COMM_VITAL_REC> vitalRecList = dapper.Set<MED_COMM_VITAL_REC>().Select(
             x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(p => p.TIME_POINT).ToList();
            return vitalRecList;
        }

        public List<MED_COMM_VITAL_REC> GetCommVitalRec(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC> commVitalData = GetCommVitalRecListByEventNo(patientID, visitID, operID, eventNo);
            //if (commVitalData != null && commVitalData.Count > 0)
            //{
            //    foreach (MED_COMM_VITAL_REC row in commVitalData)
            //    {
            //        row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
            //    }
            //}此处存在30秒数据 所以不能这么写
            return commVitalData;
        }

        /// <summary>
        /// 密集体征
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        public List<MED_COMM_VITAL_REC> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC> vitalRecList = dapper.Set<MED_COMM_VITAL_REC>().Select(
              x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.DATA_TYPE == eventNo).OrderBy(p => p.TIME_POINT).ToList();
            return vitalRecList;
        }

        public List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtend(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC_EXTEND> commVitalExtendData = GetCommVitalRecExtendListByEventNo(patientID, visitID, operID, eventNo);
            //if (commVitalExtendData != null && commVitalExtendData.Count > 0)
            //{
            //    foreach (MED_COMM_VITAL_REC_EXTEND row in commVitalExtendData)
            //    {
            //        row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
            //    }
            //}此处存在30秒数据 所以不能这么写
            return commVitalExtendData;
        }

        /// <summary>
        /// 密集提振扩展
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        public List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC_EXTEND> vitalRecList = dapper.Set<MED_COMM_VITAL_REC_EXTEND>().Select(
              x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.DATA_TYPE == eventNo).OrderBy(p => p.TIME_POINT).ToList();
            return vitalRecList;
        }


        public List<MED_VITAL_SIGN> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_PAT_MONITOR_DATA> patMonitorDataDataTables, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            List<MED_VITAL_SIGN> vitalSignList = vitalSignDataTable;
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
                        vitalSignList.Add(nrow);
                    }
                });
            }
            return vitalSignList;
        }
        public List<MED_VITAL_SIGN> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_COMM_VITAL_REC> patMonitorHistoryList, List<MED_COMM_VITAL_REC_EXTEND> commVitalRecListExtend, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            List<MED_VITAL_SIGN> vitalSignList = vitalSignDataTable;
            if (patMonitorHistoryList != null && patMonitorHistoryList.Count > 0)
            {
                patMonitorHistoryList.ForEach(row =>
                {
                    row.ToVitalSignList().ForEach(item =>
                    {
                        bool exist = patMonitorExtList.Exists(x => x.TIME_POINT.Equals(item.TIME_POINT) && x.ITEM_CODE.Equals(item.ITEM_CODE));
                        if (!exist)
                        {
                            vitalSignList.Add(item);
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
                        vitalSignList.Add(nrow);
                    }
                });
            }
            return vitalSignList;
        }

        /// <summary>
        /// startTime
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public dynamic GetAnesthesiaEvent(string patientID, int visitID, int operID, DateTime startTime, DateTime endTime)
        {
            string sql = sqlDict.GetSQLByKey("GetAnesEventQuery");

            List<MED_ANESTHESIA_EVENT> eventList = dapper.Set<MED_ANESTHESIA_EVENT>().Query(sql, new
            {
                patientID = patientID,
                visitID = visitID,
                operID = operID,
            });

            if (startTime != DateTime.MinValue && startTime != DateTime.MaxValue && endTime != DateTime.MinValue && endTime != DateTime.MaxValue)
            {
                eventList = eventList.FindAll(t => (t.START_TIME >= startTime && t.START_TIME <= endTime) || (t.END_TIME >= startTime && t.END_TIME <= endTime))
                    .OrderBy(t => t.EVENT_CLASS_CODE).ThenBy(t => t.EVENT_ITEM_NAME).ThenBy(t => t.START_TIME).ToList();
            }

            List<PlatformSurgicalEvent> data = new List<PlatformSurgicalEvent>();

            foreach (var item in eventList)
            {

                if (item.EVENT_CLASS_CODE == "2" || item.EVENT_CLASS_CODE == "3"
                    || item.EVENT_CLASS_CODE == "4" || item.EVENT_CLASS_CODE == "B"
                    || item.EVENT_CLASS_CODE == "C" || item.EVENT_CLASS_CODE == "D")
                {
                    var find = data.Find(t => t.name == item.EVENT_ITEM_NAME);

                    if (find == null)
                    {
                        if (item.DOSAGE > 0)
                        {
                            data.Add(new PlatformSurgicalEvent
                            {
                                name = item.EVENT_ITEM_NAME,

                                jl = item.DOSAGE + "(" + item.ADMINISTRATOR + ")",

                                iscx = (item.DURATIVE_INDICATOR != null && item.DURATIVE_INDICATOR == 1) ? true : false,

                                startTime = Convert.ToDateTime(item.START_TIME.Value.ToString("yyyy-MM-dd HH:mm")),

                                endTime = item.END_TIME != null ? Convert.ToDateTime(item.END_TIME.Value.ToString("yyyy-MM-dd HH:mm")) : item.END_TIME
                            });
                        }
                    }
                }
            }


            return data;
        }

        #endregion

        #region 将json转换为DataTable
        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        private DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));
            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');
                //创建表   0
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');
                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }
                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }
        #endregion
    }

    public class PlatformSurgicalEvent
    {

        public string name { get; set; }

        public string jl { get; set; }

        public bool iscx { get; set; }

        public DateTime? startTime { get; set; }

        public DateTime? endTime { get; set; }
    }
}
