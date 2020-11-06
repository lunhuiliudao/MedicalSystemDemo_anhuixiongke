using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 账号接口
    /// </summary>
    public interface IScheduleSyncInfoService
    {
        /// <summary>
        /// 手术排版信息回传OPER501W(HIS202)
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="scheduleId">scheduleId</param>
        /// <returns></returns>
        string SyncWrite_OPER501W(string patientID, int visitID, int scheduleId);
        /// <summary>
        /// 手术取消OPER504W(HIS212)
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="scheduleId">scheduleId</param>
        /// <returns></returns>
        string SyncWrite_OPER504W(string patientID, int visitID, int scheduleId);
        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <returns></returns>
        string SyncWrite_OPER101(DateTime operDateTime);
        /// <summary>
        /// 同步患者的LIS检验信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        string SyncWrite_LIS101(string patientID, int visitID);
        /// <summary>
        /// 医嘱信息接口同步ORDER103(HIS103)
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        string SyncWrite_ORDER103(string patientID, int visitID);
        string SyncWrite_OPER503W(string patientID, int visitID, int operId, int OperStatus);

    }

    public class ScheduleSyncInfoService : BaseService<ScheduleSyncInfoService>, IScheduleSyncInfoService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScheduleSyncInfoService()
            : base() { }

        public ScheduleSyncInfoService(IDapperContext context)
            : base(context)
        {
        }
        /// <summary>
        /// 手术排版信息回传OPER501W(HIS202)
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="scheduleId">scheduleId</param>
        /// <returns></returns>
        public string SyncWrite_OPER501W(string patientID, int visitID, int scheduleId)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "OPER501W";
                paramIn.App = "排班系统";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                paramIn.Operation.OperId = scheduleId;
                return InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
            }
            else
            {
                return "空的患者ID";
            }
        }
        /// <summary>
        /// 手术取消OPER504W(HIS212)
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="scheduleId">scheduleId</param>
        /// <returns></returns>
        public string SyncWrite_OPER504W(string patientID, int visitID, int scheduleId)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "OPER504W";
                paramIn.App = "排班系统";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                paramIn.Operation.OperId = scheduleId;
                return InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
            }
            else
            {
                return "空的患者ID";
            }
        }
        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <returns></returns>
        public string SyncWrite_OPER101(DateTime operDateTime)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "OPER101";
            paramIn.App = "排班系统";
            paramIn.OperatorBase.Operator = "操作人";
            paramIn.OperatorBase.OperatorDept = "操作人所属科室";

            paramIn.Operation.StartDataTime = DateTime.Parse(operDateTime.ToString("yyyy-MM-dd") + " 00:00:00"); ;
            paramIn.Operation.StopDataTime = DateTime.Parse(operDateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            return InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
        }
        /// <summary>
        /// 同步患者的LIS检验信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        public string SyncWrite_LIS101(string patientID, int visitID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "LIS101";
                paramIn.App = "排班系统";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                return InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
            }
            else
            {
                return "空的患者ID";
            }
        }
        /// <summary>
        /// 医嘱信息接口同步ORDER103(HIS103)
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        public string SyncWrite_ORDER103(string patientID, int visitID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "ORDER103";
                paramIn.App = "排班系统";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                return InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
            }
            else
            {
                return "空的患者ID";
            }
        }
        /// <summary>
        /// 手术状态回传OPER503W
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncWrite_OPER503W(string patientID, int visitID, int operId,int OperStatus)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "OPER503W";
                paramIn.App = "排班系统";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                paramIn.Operation.OperId = operId;
                paramIn.Operation.OperStatus = OperStatus;
                string ret = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

    }
}
