using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Dapper.Data;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 通用接口
    /// </summary>
    public interface IScheduleCommonService
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
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        IList<MED_HIS_USERS> GetMedHisUsers(MED_HIS_USERS hisUser);

        /// <summary>
        /// 获取手术名称字典根据inputcode
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        IList<MED_OPERATION_DICT> GetMedOperationDict(string inputContent);

        /// <summary>
        /// 获取麻醉方法字典根据inputcode
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        IList<MED_ANESTHESIA_DICT> GetMedAnesthesiaDict(string inputContent);

        /// <summary>
        /// 获取人员信息根据输入信息
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        IList<MED_HIS_USERS> GetMedHisUsers(MED_HIS_USERS hisUser, string inputContent);

        /// <summary>
        /// 获取手术医生
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        IList<MED_HIS_USERS> GetSurgeonDic(string inputContent);

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="itemClass"></param>
        /// <returns></returns>
        IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDict(string itemClass);
    }

    /// <summary>
    /// 通用类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ScheduleCommonService : BaseService<ScheduleCommonService>, IScheduleCommonService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScheduleCommonService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ScheduleCommonService(IDapperContext context)
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
            if (dapper.Connection.State != System.Data.ConnectionState.Open)
            {
                dapper.Connection.Open();
            }
            return true;
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public IList<MED_HIS_USERS> GetMedHisUsers(MED_HIS_USERS hisUser)
        {
            return dapper.Set<MED_HIS_USERS>().Select(d => d.USER_DEPT_CODE == hisUser.USER_DEPT_CODE && d.USER_JOB.Contains(hisUser.USER_JOB)).OrderBy(d => d.INPUT_CODE).ToList<MED_HIS_USERS>();
        }

        /// <summary>
        /// 获取手术名称字典根据inputcode
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        public IList<MED_OPERATION_DICT> GetMedOperationDict(string inputContent)
        {
            if (!string.IsNullOrEmpty(inputContent))
            {
                inputContent = inputContent.ToUpper();
            }
            return dapper.Set<MED_OPERATION_DICT>().Select(d => new { d.OPER_NAME, d.INPUT_CODE }, c => c.INPUT_CODE.StartsWith(inputContent) || c.OPER_NAME.StartsWith(inputContent));
        }

        /// <summary>
        /// 获取麻醉方法字典根据inputcode
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        public IList<MED_ANESTHESIA_DICT> GetMedAnesthesiaDict(string inputContent)
        {
            if (!string.IsNullOrEmpty(inputContent))
            {
                inputContent = inputContent.ToUpper();
            }
            return dapper.Set<MED_ANESTHESIA_DICT>().Select(d => new { d.ANAESTHESIA_NAME, d.INPUT_CODE }, c => c.INPUT_CODE.StartsWith(inputContent) || c.ANAESTHESIA_NAME.StartsWith(inputContent));
        }

        /// <summary>
        /// 获取人员信息根据输入信息
        /// </summary>
        /// <param name="hisUser"></param>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        public IList<MED_HIS_USERS> GetMedHisUsers(MED_HIS_USERS hisUser, string inputContent)
        {
            if (!string.IsNullOrEmpty(inputContent))
            {
                inputContent = inputContent.ToUpper();
            }
            return dapper.Set<MED_HIS_USERS>().Select(r => new { r.USER_NAME, r.USER_JOB_ID, r.INPUT_CODE }, d => d.USER_DEPT_CODE == hisUser.USER_DEPT_CODE && d.USER_JOB.Contains(hisUser.USER_JOB) && (d.INPUT_CODE.StartsWith(inputContent) || d.USER_NAME.StartsWith(inputContent) || d.USER_JOB_ID == inputContent));
        }

        /// <summary>
        /// 获取手术医生
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        public IList<MED_HIS_USERS> GetSurgeonDic(string inputContent)
        {
            if (!string.IsNullOrEmpty(inputContent))
            {
                inputContent = inputContent.ToUpper();
            }
            string doctorUserJob = AppSettings.DoctorUserJob;
            return dapper.Set<MED_HIS_USERS>().Select(r => new { r.USER_NAME, r.USER_JOB_ID, r.INPUT_CODE }, d => d.USER_JOB.Contains(doctorUserJob) && (d.INPUT_CODE.StartsWith(inputContent) || d.USER_NAME.StartsWith(inputContent) || d.USER_JOB_ID == inputContent));
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="itemClass"></param>
        /// <returns></returns>
        public IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDict(string itemClass)
        {
            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(r => r.ITEM_CLASS == itemClass);
        }
    }
}
