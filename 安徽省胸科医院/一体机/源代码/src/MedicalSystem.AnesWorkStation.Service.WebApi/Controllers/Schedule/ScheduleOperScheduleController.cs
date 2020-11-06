using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain.ViewModule;
using System;
using System.Collections.Generic;
using System.Web.Http;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Schedule
{
    public class ScheduleOperScheduleController : BaseController
    {
        IScheduleOperScheduleService OperSchedule;
        IScheduleSyncInfoService SyncInfoService;
        public ScheduleOperScheduleController(IScheduleOperScheduleService OperScheduleParam, IScheduleSyncInfoService SyncInfoServiceParam)
        {
            OperSchedule = OperScheduleParam;
            SyncInfoService = SyncInfoServiceParam;
        }

        [HttpGet]
        public RequestResult<IList<MED_OPERATION_SCHEDULE>> GetOperList(DateTime ScheduleDateTime)
        {
            return Success(OperSchedule.GetOperList(ScheduleDateTime, AppSettings.OperDeptCode));
        }

        [HttpGet]
        public RequestResult<IList<MED_OPERATING_ROOM>> GetOperRoomByDeptCode()
        {
            return Success(OperSchedule.GetOperRoomByDeptCode(AppSettings.OperDeptCode));
        }

        [HttpPost]
        public RequestResult UpdateOperationSchedule(MED_OPERATION_SCHEDULE operationSchedule)
        {
            return Success(OperSchedule.UpdateOperationSchedule(operationSchedule, d => new { d.OPER_ROOM_NO, d.SEQUENCE, d.OPER_STATUS_CODE, d.SCHEDULED_DATE_TIME, d.OPERATING_TIME }));
        }

        [HttpPost]
        public RequestResult UpdateOperationScheduleList(List<MED_OPERATION_SCHEDULE> operationScheduleList)
        {
            return Success(OperSchedule.UpdateOperationScheduleList(operationScheduleList, d => new {  d.SEQUENCE, d.SCHEDULED_DATE_TIME, d.OPERATING_TIME }));
        }

        [HttpPost]
        public RequestResult UpdateOperationNurse(MED_OPERATION_SCHEDULE operationSchedule)
        {
            return Success(OperSchedule.UpdateOperationSchedule(operationSchedule, d => new { d.FIRST_OPER_NURSE,d.FIRST_SUPPLY_NURSE }));
        }

        [HttpPost]
        public RequestResult UpdateOperationDoctor(MED_OPERATION_SCHEDULE operationSchedule)
        {
            return Success(OperSchedule.UpdateOperationSchedule(operationSchedule, d => new { d.ANES_DOCTOR, d.FIRST_ANES_ASSISTANT }));
        }

        [HttpPost]
        public RequestResult SubmitOperationScheduleList(List<MED_OPERATION_SCHEDULE> operationScheduleList)
        {
            return Success(OperSchedule.SubmitOperationScheduleList(operationScheduleList));
        }

        [HttpGet]
        public RequestResult SyncScheduleInfo(DateTime ScheduleDateTime)
        {
            return Success(SyncInfoService.SyncWrite_OPER101(ScheduleDateTime));
        }

        [HttpPost]
        public RequestResult CancelOperationSchedule(OperCancelAndDetailEntity operationCanceled)
        {
            return Success(OperSchedule.CancelOperationSchedule(operationCanceled));
        }


        [HttpPost]
        public RequestResult IsCanRevokedOpertionSchedule(MED_OPERATION_SCHEDULE operationSchedule)
        {
            return Success(OperSchedule.IsCanRevokedOpertionSchedule(operationSchedule));
        }

        [HttpPost]
        public RequestResult RevokedOpertionSchedule(MED_OPERATION_SCHEDULE operationSchedule)
        {
            return Success(OperSchedule.RevokedOpertionSchedule(operationSchedule));
        }

        [HttpPost]
        public RequestResult UpdateOperDetailInfo(MED_OPERATION_SCHEDULE operationSchedule)
        {
            int count = 0;
            if (operationSchedule.OPER_STATUS_CODE == 0)
            {
                count = OperSchedule.UpdateOperationSchedule(operationSchedule, d => new {d.SCHEDULED_DATE_TIME, d.OPERATING_TIME, d.SURGEON, d.ANES_METHOD, d.ANES_DOCTOR, d.FIRST_ANES_ASSISTANT, d.SECOND_ANES_ASSISTANT, d.FIRST_OPER_NURSE, d.SECOND_OPER_NURSE, d.FIRST_SUPPLY_NURSE, d.SECOND_SUPPLY_NURSE, d.NOTES_ON_OPERATION });
            }
            else
            {
               count = OperSchedule.UpdateOperationSchedule(operationSchedule, d => new { d.OPERATING_TIME, d.SURGEON, d.ANES_METHOD, d.ANES_DOCTOR, d.FIRST_ANES_ASSISTANT, d.SECOND_ANES_ASSISTANT, d.FIRST_OPER_NURSE, d.SECOND_OPER_NURSE, d.FIRST_SUPPLY_NURSE, d.SECOND_SUPPLY_NURSE, d.NOTES_ON_OPERATION });
            }

            if (count > 0)
            {
                return Success(new { count = count, operDetail = OperSchedule.GetOperDetail(operationSchedule) });
            }
            else
            {
                return Success(new { count = count });
            }
        }

        /// <summary>
        /// 批量排班
        /// </summary>
        /// <param name="operationScheduleList"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult BatchUpdateOperationScheduleList(List<MED_OPERATION_SCHEDULE> operationScheduleList)
        {
            return Success(OperSchedule.UpdateOperationScheduleList(operationScheduleList, d => new { d.OPER_STATUS_CODE, d.OPER_ROOM_NO, d.SEQUENCE, d.OPERATING_TIME, d.SCHEDULED_DATE_TIME }));
        }

        /// <summary>
        /// 批量安排护士 麻醉医生
        /// </summary>
        /// <param name="operationScheduleList"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult UpdateOperationNurseList(List<MED_OPERATION_SCHEDULE> operationScheduleList)
        {
            return Success(OperSchedule.UpdateOperationScheduleList(operationScheduleList, d => new { d.FIRST_OPER_NURSE, d.FIRST_SUPPLY_NURSE, d.ANES_DOCTOR, d.FIRST_ANES_ASSISTANT }));
        }

        /// <summary>
        /// 获取医嘱信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<dynamic>> GetMedOrdersList(string patientID, int visitID)
        {
            return Success(OperSchedule.GetMedOrdersList(patientID, visitID));
        }
    }
}
