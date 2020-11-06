using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Common.SecretManage;
using Newtonsoft.Json;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Pacu
{
    public class PacuShiftOperationInfoController : BaseController
    {

        IPacuShiftOperationInfoService _pacuShiftOperationInfoService = null;

        public PacuShiftOperationInfoController(IPacuShiftOperationInfoService pacuShiftOperationInfoService)
        {
            _pacuShiftOperationInfoService = pacuShiftOperationInfoService;
        }

        [HttpGet]
        public RequestResult<MED_SHIFT_OPERATION_SIGN> GetShiftOperationSign(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            return Success(_pacuShiftOperationInfoService.GetShiftOperationSign(patientID, visitID, operID, shiftType, shiftDivision));
        }

        [HttpGet]
        public RequestResult<List<SHIFT_OPERATION_INFO>> GetShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType)
        {
            return Success(_pacuShiftOperationInfoService.GetShiftOperationInfoList(shiftDate, timeOffset, operRoom, shiftType));
        }

        [HttpGet]
        public RequestResult<List<SHIFT_OPERATION_INFO>> GetUnShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType, int shiftDivision)
        {
            return Success(_pacuShiftOperationInfoService.GetUnShiftOperationInfoList(shiftDate, timeOffset, operRoom, shiftType, shiftDivision));
        }

        [HttpGet]
        public RequestResult<List<SHIFT_OPERATION_INFO>> GetShiftOperationInfoExtList(DateTime startDate, DateTime endDate, string inpNo, string patientName, string dept, string keyWords, string operRoom, int shiftType)
        {
            return Success(_pacuShiftOperationInfoService.GetShiftOperationInfoExtList(startDate, endDate, inpNo, patientName, dept, keyWords, operRoom, shiftType));
        }

        [HttpGet]
        public RequestResult<List<MED_SHIFT_OPERATION_FILES>> GetShiftOperationFiles(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            return Success(_pacuShiftOperationInfoService.GetShiftOperationFiles(patientID, visitID, operID, shiftType, shiftDivision));
        }

        [HttpGet]
        public RequestResult<bool> FileIsExist(string patientID, int visitID, int operID, int shiftType, int shiftDivision, string fileName)
        {
            return Success(_pacuShiftOperationInfoService.FileIsExist(patientID, visitID, operID, shiftType, shiftDivision, fileName));
        }


        [HttpPost]
        public RequestResult<bool> SaveShiftFileInfo(MED_SHIFT_OPERATION_FILES item)
        {
            return Success(_pacuShiftOperationInfoService.SaveShiftFileInfo(item));
        }
        [HttpPost]
        public RequestResult<bool> DeleteShiftFileInfo(MED_SHIFT_OPERATION_FILES item)
        {
            return Success(_pacuShiftOperationInfoService.DeleteShiftFileInfo(item));
        }

        [HttpGet]
        public RequestResult<int> GetRecordNo(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            return Success(_pacuShiftOperationInfoService.GetRecordNo(patientID, visitID, operID, shiftType, shiftDivision));
        }

        [HttpGet]
        public RequestResult<List<MED_SHIFT_OPERATION_DATA>> GetShiftOperationData(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            return Success(_pacuShiftOperationInfoService.GetShiftOperationData(patientID, visitID, operID, shiftType, shiftDivision));
        }

        [HttpPost]
        public RequestResult<bool> SaveShiftOperationData(MED_SHIFT_OPERATION_DATA item)
        {
            return Success(_pacuShiftOperationInfoService.SaveShiftOperationData(item));
        }
        [HttpPost]
        public RequestResult<bool> DeleteSehiftOperationData(MED_SHIFT_OPERATION_DATA item)
        {
            return Success(_pacuShiftOperationInfoService.DeleteSehiftOperationData(item));
        }

        [HttpPost]
        public RequestResult<bool> SaveShiftOperationSign(MED_SHIFT_OPERATION_SIGN item)
        {
            return Success(_pacuShiftOperationInfoService.SaveShiftOperationSign(item));
        }

        [HttpPost]
        public RequestResult<int> DeleteAllShiftFileInfo(List<MED_SHIFT_OPERATION_FILES> item)
        {
            return Success(_pacuShiftOperationInfoService.DeleteAllShiftFileInfo(item));
        }

        [HttpPost]
        public RequestResult<int> DeleteAllShiftSignData(List<MED_SHIFT_OPERATION_DATA> item)
        {
            return Success(_pacuShiftOperationInfoService.DeleteAllShiftSignData(item));
        }

        [HttpPost]
        public RequestResult<bool> DeleteShiftSignData(MED_SHIFT_OPERATION_SIGN item)
        {
            return Success(_pacuShiftOperationInfoService.DeleteShiftSignData(item));
        }
    }
}
