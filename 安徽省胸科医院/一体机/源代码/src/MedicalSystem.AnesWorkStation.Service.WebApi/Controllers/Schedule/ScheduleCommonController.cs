using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dapper.Data;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Schedule
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class ScheduleCommonController : BaseController
    {
        IScheduleCommonService _common;
        public ScheduleCommonController(IScheduleCommonService common)
        {
            _common = common;
        }

        /// <summary>
        /// 测试网络连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<bool> TestNet()
        {
            return Success(_common.TestNet());
        }

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<bool> TestDbConn()
        {
            try
            {
                return Success(_common.TestDbConn());
            }
            catch (Exception ex)
            {
                return Failed<bool>(ex.Message);
            }
        }

        /// <summary>
        /// 获取护士
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_HIS_USERS>> GetMedHisUsersNurses()
        {
            RequestResult<IList<MED_HIS_USERS>> Result = new RequestResult<IList<MED_HIS_USERS>>();
            Result.Data = _common.GetMedHisUsers(new MED_HIS_USERS { USER_DEPT_CODE= AppSettings.OperDeptCode, USER_JOB= AppSettings.NurseUserJob });
            Result.Result = ResultStatus.Success;

            return Result;
        }

        /// <summary>
        /// 获取麻醉医生
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_HIS_USERS>> GetMedHisUsersDoctors()
        {
            RequestResult<IList<MED_HIS_USERS>> Result = new RequestResult<IList<MED_HIS_USERS>>();
            Result.Data = _common.GetMedHisUsers(new MED_HIS_USERS { USER_DEPT_CODE = AppSettings.AnesWardCode, USER_JOB = AppSettings.DoctorUserJob });
            Result.Result = ResultStatus.Success;

            return Result;
        }

        public RequestResult<IList<MED_OPERATION_DICT>> GetMedOperationDict(string inputContent) {

            return Success(_common.GetMedOperationDict(inputContent));
        }

        public RequestResult<IList<MED_ANESTHESIA_DICT>> GetMedAnesthesiaDict(string inputContent)
        {

            return Success(_common.GetMedAnesthesiaDict(inputContent));
        }

        /// <summary>
        /// 获取麻醉医生根据搜索内容
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_HIS_USERS>> GetAnesDoctorDict(string inputContent)
        {
            RequestResult<IList<MED_HIS_USERS>> Result = new RequestResult<IList<MED_HIS_USERS>>();
            Result.Data = _common.GetMedHisUsers(new MED_HIS_USERS { USER_DEPT_CODE = AppSettings.AnesWardCode, USER_JOB = AppSettings.DoctorUserJob }, inputContent);
            Result.Result = ResultStatus.Success;

            return Result;
        }


        /// <summary>
        /// 获取护士根据搜索内容
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_HIS_USERS>> GetOPerNursesDic(string inputContent)
        {
            RequestResult<IList<MED_HIS_USERS>> Result = new RequestResult<IList<MED_HIS_USERS>>();
            Result.Data = _common.GetMedHisUsers(new MED_HIS_USERS { USER_DEPT_CODE = AppSettings.OperDeptCode, USER_JOB = AppSettings.NurseUserJob },inputContent);
            Result.Result = ResultStatus.Success;

            return Result;
        }

        /// <summary>
        /// 获取手术医生
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        public RequestResult<IList<MED_HIS_USERS>> GetSurgeonDic(string inputContent)
        {
            RequestResult<IList<MED_HIS_USERS>> Result = new RequestResult<IList<MED_HIS_USERS>>();
            Result.Data = _common.GetSurgeonDic(inputContent);
            Result.Result = ResultStatus.Success;

            return Result;
        }
        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="itemClass"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_ANESTHESIA_INPUT_DICT>> GetAnesInputDict(string itemClass)
        {
            return Success(_common.GetAnesInputDict(itemClass));
        }
    }
}