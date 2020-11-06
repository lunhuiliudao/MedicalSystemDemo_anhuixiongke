using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;


namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuAnesEventDataService
    {
        /// <summary>
        /// 获取麻醉事件字典表
        /// </summary>
        /// <returns></returns>
        List<MED_EVENT_DICT> GetAnesEventDict();
        List<MED_EVENT_DICT> GetAnesEventDictByItemClass(string eventItemClass);
        List<MED_EVENT_DICT> GetAnesEventDictByhuxi();
        /// <summary>
        /// 获取麻醉事件字典扩展表
        /// </summary>
        /// <returns></returns>
        List<MED_EVENT_DICT_EXT> GetAnesEventDictExt();

        /// <summary>
        /// 删除麻醉事件
        /// </summary>
        /// <returns></returns>
        bool DelAnesEvent(MED_ANESTHESIA_EVENT item);
    }

    public class PacuAnesEventService : BaseService<PacuAnesEventService>, IPacuAnesEventDataService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuAnesEventService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuAnesEventService(IDapperContext context)
            : base(context)
        {
        }


        /// <summary>
        /// 获得麻醉字典表
        /// </summary>
        /// <returns></returns>
        public List<MED_EVENT_DICT> GetAnesEventDict()
        {
            List<MED_EVENT_DICT> data = dapper.Set<MED_EVENT_DICT>().Select();
            return data;
        }
        public List<MED_EVENT_DICT> GetAnesEventDictByItemClass(string eventItemClass)
        {
            List<MED_EVENT_DICT> data = dapper.Set<MED_EVENT_DICT>().Select(x => x.EVENT_ITEM_CODE == eventItemClass);
            return data;
        }
        public List<MED_EVENT_DICT> GetAnesEventDictByhuxi()
        {
            string sqlText = "select * from medsurgery.med_event_dict where EVENT_CLASS_CODE IN ('9', 'A', 'Y') OR EVENT_ITEM_NAME IN ('辅助呼吸', '控制呼吸', '自主呼吸') ";
            List<MED_EVENT_DICT> data = dapper.Set<MED_EVENT_DICT>().Query(sqlText) as List<MED_EVENT_DICT>;
            return data;
        }
        /// <summary>
        /// 获得麻醉字典扩展表
        /// </summary>
        /// <returns></returns>
        public List<MED_EVENT_DICT_EXT> GetAnesEventDictExt()
        {
            List<MED_EVENT_DICT_EXT> data = dapper.Set<MED_EVENT_DICT_EXT>().Select();
            return data;
        }


        /// <summary>
        /// 删除麻醉事件
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public bool DelAnesEvent(MED_ANESTHESIA_EVENT item)
        {
            bool result = dapper.Set<MED_ANESTHESIA_EVENT>().Delete(item);

            dapper.SaveChanges();

            return result;
        }
    }
}
