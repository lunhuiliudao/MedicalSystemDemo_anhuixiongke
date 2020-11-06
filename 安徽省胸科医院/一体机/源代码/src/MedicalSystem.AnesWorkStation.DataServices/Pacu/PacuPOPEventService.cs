using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuPOPEventService
    {
        /// <summary>
        /// 新增围术期事件配置
        /// </summary>
        /// <param name="POPEventConfig"></param>
        /// <returns></returns>
        bool AddPOPEventConfig(MED_PERIOPERATIVE_EVENT_CONFIG POPEventConfig);
        /// <summary>
        /// 修改围术期事件配置
        /// </summary>
        /// <param name="POPEventConfig"></param>
        /// <returns></returns>
        bool UpdatePOPEventConfig(MED_PERIOPERATIVE_EVENT_CONFIG POPEventConfig);
        /// <summary>
        /// 删除围术期事件配置
        /// </summary>
        /// <param name="EVENT_ID"></param>
        /// <returns></returns>
        bool DeletePOPEventConfig(string EVENT_ID);
        /// <summary>
        /// 获取围术期事件配置
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        MED_PERIOPERATIVE_EVENT_CONFIG GetPOPEventConfig(string EVENT_ID);


        List<MED_PERIOPERATIVE_EVENT_CONFIG> GetPOPEventConfigs();


        /// <summary>
        /// 采集手术CDR
        /// </summary>
        /// <param name="Operation">手术信息</param>
        /// <returns></returns>
        bool SampleCDR(MED_OPERATION_MASTER Operation);

        /// <summary>
        /// 新增围术期事件索引
        /// </summary>
        /// <param name="POPEventIndex"></param>
        /// <returns></returns>
        bool AddPOPEventIndex(MED_PERIOPERATIVE_EVENT_INDEX POPEventIndex);
        /// <summary>
        /// 修改围术期事件索引
        /// </summary>
        /// <param name="POPEventIndex"></param>
        /// <returns></returns>
        bool UpdatePOPEventIndex(MED_PERIOPERATIVE_EVENT_INDEX POPEventIndex);
        /// <summary>
        /// 删除围术期事件索引
        /// </summary>
        /// <param name="INDEX_ID"></param>
        /// <returns></returns>
        bool DeletePOPEventIndex(string INDEX_ID);
        /// <summary>
        /// 获取围术期事件索引
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        MED_PERIOPERATIVE_EVENT_INDEX GetPOPEventIndex(string INDEX_ID);

        List<MED_PERIOPERATIVE_EVENT_INDEX> GetPOPEventIndexList();

        List<MED_PERIOPERATIVE_EVENT_CONFIG> GetPOPEventConfigList();
    }


    public class PacuPOPEventService : BaseService<PacuPOPEventService>, IPacuPOPEventService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuPOPEventService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuPOPEventService(IDapperContext context)
            : base(context)
        {
        }

        public bool AddPOPEventConfig(MED_PERIOPERATIVE_EVENT_CONFIG POPEventConfig)
        {
            try
            {
                POPEventConfig.EVENT_ID = Guid.NewGuid().ToString();

                var flag = dapper.Set<MED_PERIOPERATIVE_EVENT_CONFIG>().Insert(POPEventConfig);

                dapper.SaveChanges();

                return flag;
            }
            catch (Exception ex)
            {
                Logger.Error("新增围术期事件配置异常：" + ex.Message);

                return false;
            }
        }

        public bool UpdatePOPEventConfig(MED_PERIOPERATIVE_EVENT_CONFIG POPEventConfig)
        {
            try
            {
                var flag = dapper.Set<MED_PERIOPERATIVE_EVENT_CONFIG>().Update(POPEventConfig);

                dapper.SaveChanges();

                return flag > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Logger.Error("修改围术期事件配置异常：" + ex.Message);

                return false;
            }
        }

        public bool DeletePOPEventConfig(string EVENT_ID)
        {
            var ret = dapper.Set<MED_PERIOPERATIVE_EVENT_CONFIG>().Delete(p => p.EVENT_ID == EVENT_ID);

            dapper.SaveChanges();

            return ret >= 0;
        }

        public MED_PERIOPERATIVE_EVENT_CONFIG GetPOPEventConfig(string EVENT_ID)
        {
            return dapper.Set<MED_PERIOPERATIVE_EVENT_CONFIG>().Select(d => d.EVENT_ID == EVENT_ID).FirstOrDefault();
        }

        public bool SampleCDR(MED_OPERATION_MASTER Operation)
        {
            throw new NotImplementedException();
        }

        public bool AddPOPEventIndex(MED_PERIOPERATIVE_EVENT_INDEX POPEventIndex)
        {
            try
            {
                POPEventIndex.INDEX_ID = Guid.NewGuid().ToString();
                var flag = dapper.Set<MED_PERIOPERATIVE_EVENT_INDEX>().Insert(POPEventIndex);
                dapper.SaveChanges();
                return flag;
            }
            catch (Exception ex)
            {
                Logger.Error("新增围术期事件索引异常：" + ex.Message);
                return false;
            }
        }

        public bool UpdatePOPEventIndex(MED_PERIOPERATIVE_EVENT_INDEX POPEventIndex)
        {
            try
            {
                var flag = dapper.Set<MED_PERIOPERATIVE_EVENT_INDEX>().Update(POPEventIndex);
                dapper.SaveChanges();
                return flag > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Logger.Error("修改围术期事件索引异常：" + ex.Message);
                return false;
            }
        }

        public bool DeletePOPEventIndex(string INDEX_ID)
        {
            var ret = dapper.Set<MED_PERIOPERATIVE_EVENT_INDEX>().Delete(p => p.INDEX_ID == INDEX_ID);
            dapper.SaveChanges();
            return ret >= 0;
        }

        public MED_PERIOPERATIVE_EVENT_INDEX GetPOPEventIndex(string INDEX_ID)
        {
            return dapper.Set<MED_PERIOPERATIVE_EVENT_INDEX>().Select(d => d.INDEX_ID == INDEX_ID).FirstOrDefault();
        }

        public List<MED_PERIOPERATIVE_EVENT_INDEX> GetPOPEventIndexList()
        {
            return dapper.Set<MED_PERIOPERATIVE_EVENT_INDEX>().Select();
        }


        public List<MED_PERIOPERATIVE_EVENT_CONFIG> GetPOPEventConfigList()
        {
            return dapper.Set<MED_PERIOPERATIVE_EVENT_CONFIG>().Select();
        }

        public List<MED_PERIOPERATIVE_EVENT_CONFIG> GetPOPEventConfigs()
        {
            return dapper.Set<MED_PERIOPERATIVE_EVENT_CONFIG>().Select();
        }
    }
}
