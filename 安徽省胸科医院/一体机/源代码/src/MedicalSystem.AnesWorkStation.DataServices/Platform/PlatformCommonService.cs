using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain.Origins;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 通用接口
    /// </summary>
    public interface IPlatformCommonService
    {
        /// <summary>
        /// 测试连接
        /// </summary>
        bool TestNet();
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        bool TestDbConn();

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="name">字典名称</param>
        /// <param name="inputContent">输入内容</param>
        /// <returns></returns>
        dynamic GetDictList(string name, string inputContent);

        /// <summary>
        /// 获取常用术语字典
        /// </summary>
        /// <param name="ItemClass">类型</param>
        /// <returns></returns>
        IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDictByClass(string ItemClass);

        /// <summary>
        /// 给药途径字典
        /// </summary>
        /// <returns></returns>
        IList<MED_ADMINISTRATION_DICT> GetAdministrationDict();

        /// <summary>
        /// 获取医生护士人员字典
        /// </summary>
        /// <param name="UserJob">用户角色</param>
        /// <returns></returns>
        IList<MED_HIS_USERS> GetMedHisUserDict(string UserJob);

    }

    /// <summary>
    /// 通用类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PlatformCommonService : BaseService<PlatformCommonService>, IPlatformCommonService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PlatformCommonService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PlatformCommonService(IDapperContext context)
            : base(context)
        {
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual bool TestNet()
        {
            return true;
        }
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual bool TestDbConn()
        {
            dapper.Connection.Open();
            return true;
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="name">字典名称</param>
        /// <param name="inputContent">输入内容</param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDictList(string name, string inputContent)
        {
            if (name == "MED_DEPT_DICT")
            {
                if (!string.IsNullOrEmpty(inputContent))
                {
                    return dapper.Set<MED_DEPT_DICT>().Select(
                    r => r.INPUT_CODE.Contains(inputContent) ||
                    r.DEPT_NAME.Contains(inputContent) ||
                    r.DEPT_CODE.Contains(inputContent)).Select(x => new
                    {
                        Key = x.DEPT_CODE,
                        Value = x.DEPT_NAME,
                        InputCode = x.INPUT_CODE
                    }).OrderBy(d => d.Value).ToList();
                }
                else
                {
                    return dapper.Set<MED_DEPT_DICT>().Select().Select(x => new
                   {
                       Key = x.DEPT_CODE,
                       Value = x.DEPT_NAME,
                       InputCode = x.INPUT_CODE
                   }).OrderBy(d => d.Value).ToList();
                }
            }
            return null;
        }

        /// <summary>
        /// 获取常用术语字典
        /// </summary>
        /// <param name="ItemClass">类型</param>
        /// <returns></returns>
        public IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDictByClass(string ItemClass)
        {
            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(d =>d.ITEM_CLASS == ItemClass).OrderBy(x => x.ITEM_NAME).ToList();
        }

        /// <summary>
        /// 给药途径字典
        /// </summary>
        /// <returns></returns>
        public IList<MED_ADMINISTRATION_DICT> GetAdministrationDict()
        {
            return dapper.Set<MED_ADMINISTRATION_DICT>().Select();
        }

        /// <summary>
        /// 获取医生护士人员字典
        /// </summary>
        /// <param name="user_job">用户角色</param>
        /// <returns></returns>
        public IList<MED_HIS_USERS> GetMedHisUserDict(string UserJob)
        {
            return dapper.Set<MED_HIS_USERS>().Select(d => d.USER_DEPT_CODE ==UserJob).OrderBy(x => x.USER_NAME).ToList();
        }
    }
}
