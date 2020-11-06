using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Dapper.Data;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.Configurations;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 数据服务接口
    /// </summary>
    public interface IBaseService { }

    /// <summary>
    /// 数据服务类，客户端采用AOP获取当前的请求，所有方法都必须是虚方法，否则无法请求，必须手动操作。
    /// </summary>
    /// <typeparam name="T">服务</typeparam>
    public class BaseService<T> : BaseDataService<T>, IBaseService
        where T : BaseService<T>
    {
        /// <summary>
        /// Dapper数据库对象
        /// </summary>
        protected IDapperContext dapper;

        /// <summary>
        /// 获取SQL语句
        /// </summary>
        protected XmlDictConfig sqlDict = null;

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected BaseService() : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public BaseService(IDapperContext context)
        {
            dapper = context;
            sqlDict = MdkConfiguration.GetConfig().XmlDict;
        }

        /// <summary>
        /// 设置配置信息
        /// </summary>
        protected override void LoadServiceConfig()
        {
            var config = AnesWorkStationInstaller.GetConfig();
            if (!string.IsNullOrWhiteSpace(config.WebApiUri) || !string.IsNullOrWhiteSpace(config.ConnectionName))
            {
                DataServiceConfig = config;
            }

            if (CommonService.ClientInstance.TestNet())
            {
                Logger.Debug("网络测试成功");
                if (CommonService.ClientInstance.TestDbConn())
                {
                    Logger.Debug("数据库连接成功");
                }
                else
                {
                    Logger.Debug("数据库连接失败");
                }
            }
            else
            {
                Logger.Debug("网络测试失败");
            }
        }

        #region List<Table>对象操作保存

        /// <summary>
        /// 对数据对象批量处理更新。
        /// </summary>
        /// <typeparam name="T">表名</typeparam>
        /// <param name="list">结果记录集</param>
        /// <returns>true:成功。</returns>
        protected bool UpdateWholeList<T>(List<T> list)
            where T : BaseModel
        {
            int num = 0;
            foreach (var item in list)
            {
                switch (item.ModelStatus)
                {
                    case ModelStatus.Default:
                    case ModelStatus.Modeified:
                        num += dapper.Set<T>().Save(item) ? 1 : 0;
                        break;
                    case ModelStatus.Add:
                        num += dapper.Set<T>().Save(item) ? 1 : 0;
                        break;
                    case ModelStatus.Deleted:
                        num += dapper.Set<T>().Delete(item) ? 1 : 0;
                        break;
                    default:
                        break;
                }
            }
            return list.Count() == num;
        }
        

        #endregion

    }
}
