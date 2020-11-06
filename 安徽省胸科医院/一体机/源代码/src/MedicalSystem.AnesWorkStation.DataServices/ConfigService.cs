using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 配置接口
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// 获取医院抬头
        /// </summary>
        List<MED_HOSPITAL_CONFIG> GetHosotalConfig();

        /// <summary>
        /// 获取配置表信息
        /// </summary>
        List<MED_CONFIG> GetConfig();

        /// <summary>
        /// 插入信息到配置表
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        bool InsertConfig(MED_CONFIG mc);
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public class ConfigService : BaseService<ConfigService>, IConfigService
    {
        protected new IDapperContext dapper;

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ConfigService()
            : base() { }

        public ConfigService(IDapperContext context)
            : base(context)
        {
            dapper = context;
        }
        /// <summary>
        /// 获取医院抬头
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_HOSPITAL_CONFIG> GetHosotalConfig()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 获取配置表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_CONFIG> GetConfig()
        {
            return dapper.Set<MED_CONFIG>().Select();
        }

        /// <summary>
        /// 插入信息到配置表
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool InsertConfig(MED_CONFIG mc)
        {
            bool flag = dapper.Set<MED_CONFIG>().Insert(mc);
            dapper.SaveChanges();
            return flag;
        }
    }
}
