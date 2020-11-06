using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuCoordinationService
    {
        string GetCurrentMessageID();

        void MoveToNextMessageID();

        List<MED_CLIENT_COMPUTER> GetClientComputerList();

        List<MED_MESSAGE_TEMPLET> GetMessageTempletList();

        bool AddMessageLog(MED_MESSAGE_LOG item);

        List<MED_MESSAGE_LOG> GetMessageList(string client_id);

        List<MED_MESSAGE_LOG> GetMessageListByID(string clientID);

        bool SaveMessageLog(List<MED_MESSAGE_LOG> item);

        bool SaveCoordination(dynamic item);
    }


    public class PacuCoordinationService : BaseService<PacuCoordinationService>, IPacuCoordinationService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuCoordinationService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuCoordinationService(IDapperContext context)
            : base(context)
        {
        }

        public readonly static object SerialNoLock = new object();
        private static DateTime CurrentDate;
        private static int CurrentSerialNo;
        private static bool IsCacheSerialNo;
        const string DateFormat = "yyyyMMdd";

        public string GetCurrentMessageID()
        {
            if (!IsCacheSerialNo)
            {
                var data = dapper.Set<MED_MESSAGE_LOG>().Query(@"SELECT * FROM(SELECT * FROM MED_MESSAGE_LOG
WHERE SEND_TIME >= :SDATE AND SEND_TIME < :EDATE
ORDER BY SEND_TIME DESC)
WHERE ROWNUM = 1", new
                {
                    SDATE = DateTime.Now.Date,
                    EDATE = DateTime.Now.AddDays(1).Date
                }).FirstOrDefault();

                if (data == null || string.IsNullOrEmpty(data.MESSAGE_ID))
                {
                    CurrentDate = DateTime.Now;
                    CurrentSerialNo = 1;
                }
                else
                {
                    CurrentDate = data.SEND_TIME;
                    if (string.IsNullOrEmpty(data.MESSAGE_ID) || !int.TryParse(data.MESSAGE_ID.Substring(DateFormat.Length), out CurrentSerialNo))
                    {
                        CurrentSerialNo = 1;
                    }
                    else
                    {
                        CurrentSerialNo++;
                    }
                }
                IsCacheSerialNo = true;
            }
            if (CurrentDate.Date != DateTime.Now.Date)
            {
                CurrentDate = DateTime.Now;
                CurrentSerialNo = 1;
            }

            return CurrentDate.ToString(DateFormat) + CurrentSerialNo.ToString("D6");
        }

        public void MoveToNextMessageID()
        {
            CurrentSerialNo++;
        }

        public List<MED_CLIENT_COMPUTER> GetClientComputerList()
        {
            var data = dapper.Set<MED_CLIENT_COMPUTER>().Query(@"SELECT DISTINCT C.*,
       NVL(US.USER_NAME, M.ANES_DOCTOR) AS ANES_DOCTOR,
       NVL(FAA.USER_NAME, M.FIRST_ANES_ASSISTANT) AS FIRST_ANES_ASSISTANT
  FROM MED_CLIENT_COMPUTER C
  LEFT JOIN MED_OPERATING_ROOM R
    ON C.ROOM_NO = R.ROOM_NO
  LEFT JOIN MED_OPERATION_MASTER M
    ON M.PATIENT_ID = R.PATIENT_ID
   AND M.VISIT_ID = R.VISIT_ID
   AND M.OPER_ID = R.OPER_ID
  LEFT JOIN MED_HIS_USERS US
    ON M.ANES_DOCTOR = US.USER_JOB_ID
  LEFT JOIN MED_HIS_USERS FAA
    ON M.FIRST_ANES_ASSISTANT = FAA.USER_JOB_ID") as List<MED_CLIENT_COMPUTER>;
            return data;
        }

        public List<MED_MESSAGE_TEMPLET> GetMessageTempletList()
        {
            return dapper.Set<MED_MESSAGE_TEMPLET>().Select();
        }

        public bool AddMessageLog(MED_MESSAGE_LOG item)
        {
            bool result = dapper.Set<MED_MESSAGE_LOG>().Insert(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_MESSAGE_LOG> GetMessageList(string client_id)
        {
            return dapper.Set<MED_MESSAGE_LOG>().Select(d => d.RECEIVE_CLIENT_ID == client_id && d.RECEIVE_CONFIRM == 0);
        }

        public List<MED_MESSAGE_LOG> GetMessageListByID(string clientID)
        {
            return dapper.Set<MED_MESSAGE_LOG>().Select(d => d.RECEIVE_CLIENT_ID == clientID && d.SEND_CLIENT_ID == clientID);
        }

        public bool SaveMessageLog(List<MED_MESSAGE_LOG> item)
        {
            item.ForEach(x =>
            {
                x.RECEIVE_TIME = DateTime.Now;
                x.RECEIVE_CONFIRM = 1;

            });

            bool result = dapper.Set<MED_MESSAGE_LOG>().Save(item) > 0 ? true : false;

            dapper.SaveChanges();

            return result;
        }

        public bool SaveCoordination(dynamic item)
        {
            int result = 0;

            List<MED_CLIENT_COMPUTER> newAndUpdateList = null;
            List<MED_CLIENT_COMPUTER> delList = null;
            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_CLIENT_COMPUTER>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_CLIENT_COMPUTER>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_CLIENT_COMPUTER>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_CLIENT_COMPUTER>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }
    }
}
