using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using Newtonsoft.Json;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 手术监控
    /// </summary>
    [ControllerGroup("手术监控", "接口")]
    public class PlatformSurgicalMonitorController : PlatformBaseController
    {
        IPlatformSurgicalMonitorService surgicalMonitorService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="surgicalMonitorServiceParam">参数</param>
        public PlatformSurgicalMonitorController(IPlatformSurgicalMonitorService surgicalMonitorServiceParam)
        {
            surgicalMonitorService = surgicalMonitorServiceParam;
        }

        /// <summary>
        /// 获取进行中的手术信息
        /// </summary>
        /// <returns>集合</returns>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetOpertingPatientList()
        {
            return Success(surgicalMonitorService.GetOpertingPatientList());
        }

        /// <summary>
        /// 获取个性化体征配置
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <param name="operID">operID</param>
        /// <param name="eventNo">eventNo</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        {
            return Success<dynamic>(surgicalMonitorService.GetPatientMonitorConfig(patientID, visitID, operID, eventNo));
        }

        /// <summary>
        /// 保存个性化体征通用配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public RequestResult<int> UpdatePatientMonitorConfig(dynamic obj)
        {
            string patientID = (string)obj.patientID;
            int visitID = (int)obj.visitID;
            int operID = (int)obj.operID;
            string eventNo = (string)obj.eventNo;
            string content = obj.content.ToString();

            return Success<int>(surgicalMonitorService.UpdatePatientMonitorConfig(patientID, visitID, operID, eventNo, content));
        }

        // 获取公共颜色数组
        /// <summary>
        /// 获取公共颜色数组
        /// </summary>
        /// <returns></returns>
        public RequestResult<dynamic> GetColors()
        {
            List<string> colorList = new List<string>();

            foreach (var item in typeof(System.Drawing.Color).GetMembers())
            {
                //只取属性且为属性中的已知Color，剔除byte属性以及一些布尔属性等（A B G R IsKnownColor Name等）
                if (item.MemberType == System.Reflection.MemberTypes.Property && System.Drawing.Color.FromName(item.Name).IsKnownColor == true)
                {
                    colorList.Add(System.Drawing.Color.FromName(item.Name).Name);
                }
            }
            return Success<dynamic>(colorList);
        }

        //[HttpGet]
        //public RequestResult<MED_PATIENT_MONITOR_CONFIG> GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        //{
        //    MED_PATIENT_MONITOR_CONFIG patMontirConfig = surgicalMonitorService.GetPatientMonitorConfig(patientID, visitID, operID, eventNo);
        //    return Success(patMontirConfig);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <param name="isHistory"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_VITAL_SIGN>> GetVitalSignData(string patientID, int visitID, int operID, string eventNo, bool isHistory)
        {
            List<MED_VITAL_SIGN> vitalSignList = surgicalMonitorService.GetVitalSignData(patientID, visitID, operID, eventNo, isHistory);
            return Success(vitalSignList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<dynamic> GetAnesthesiaEvent(OperQueryParaModel model)
        {

            DateTime startTime = DateTime.MinValue;

            DateTime endTime = DateTime.MinValue;

            DateTime.TryParse(model.StartDate, out startTime);

            DateTime.TryParse(model.EndDate, out endTime);


            return Success<dynamic>(surgicalMonitorService.GetAnesthesiaEvent(model.PatientId, model.VisitId, model.OperId, startTime, endTime));
        }
    }
}
