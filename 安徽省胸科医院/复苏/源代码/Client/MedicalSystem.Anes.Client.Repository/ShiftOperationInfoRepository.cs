using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class ShiftOperationInfoRepository : BaseRepository
    {
        public RequestResult<MED_SHIFT_OPERATION_SIGN> GetShiftOperationSign(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            string address = string.Format("PacuShiftOperationInfo/GetShiftOperationSign?patientID={0}&visitID={1}&operID={2}&shiftType={3}&shiftDivision={4}", patientID, visitID, operID, shiftType, shiftDivision);
            return BaseRepository.GetCallApi<MED_SHIFT_OPERATION_SIGN>(address);
        }
        /// <summary>
        /// 获取手术交班信息
        /// </summary>
        /// <param name="shiftDate">早交班日期</param>
        /// <param name="timeOffset">时间偏移量</param>
        /// <param name="operRoom">手术间</param>
        /// <param name="shiftType">交班类型</param>
        /// <returns><![CDATA[RequestResult<string>]></returns>
        public RequestResult<List<SHIFT_OPERATION_INFO>> GetShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType)
        {
            string address = string.Format("PacuShiftOperationInfo/GetShiftOperationInfoList?shiftDate={0}&timeOffset={1}&operRoom={2}&shiftType={3}", shiftDate, timeOffset, operRoom, shiftType);
            return BaseRepository.GetCallApi<List<SHIFT_OPERATION_INFO>>(address);
        }

        /// <summary>
        /// 获取未标记交班手术信息
        /// </summary>
        /// <param name="shiftDate">日期</param>
        /// <param name="timeOffset">时间偏移量</param>
        /// <param name="operRoom">手术间</param>
        /// <param name="shiftType">交班类型</param>
        /// <param name="shiftType">交班区分</param>
        /// <returns><![CDATA[RequestResult<string>]></returns>
        public RequestResult<List<SHIFT_OPERATION_INFO>> GetUnShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType, int shiftDivision)
        {
            string address = string.Format("PacuShiftOperationInfo/GetUnShiftOperationInfoList?shiftDate={0}&timeOffset={1}&operRoom={2}&shiftType={3}&shiftDivision={4}", shiftDate, timeOffset, operRoom, shiftType, shiftDivision);
            return BaseRepository.GetCallApi<List<SHIFT_OPERATION_INFO>>(address);
        }

        /// <summary>
        /// 获取手术交班拓展信息
        /// </summary>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="inpNo">住院号</param>
        /// <param name="patientName">患者姓名</param>
        /// <param name="dept">部门</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="operRoom">手术室代码</param>
        /// <param name="shiftType">交班标识（1：麻醉交班；2：护理交班）</param>
        /// <returns></returns>
        public RequestResult<List<SHIFT_OPERATION_INFO>> GetShiftOperationInfoExtList(DateTime startDate, DateTime endDate, string inpNo, string patientName, string dept, string keyWords, string operRoom, int shiftType)
        {
            string address = string.Format("PacuShiftOperationInfo/GetShiftOperationInfoExtList?startDate={0}&endDate={1}&inpNo={2}&patientName={3}&dept={4}&keyWords={5}&operRoom={6}&shiftType={7}", startDate, endDate, inpNo, patientName, dept, keyWords, operRoom, shiftType);
            return BaseRepository.GetCallApi<List<SHIFT_OPERATION_INFO>>(address);
        }

        public RequestResult<List<MED_SHIFT_OPERATION_FILES>> GetShiftOperationFiles(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            string address = string.Format("PacuShiftOperationInfo/GetShiftOperationFiles?patientID={0}&visitID={1}&operID={2}&shiftType={3}&shiftDivision={4}", patientID, visitID, operID, shiftType, shiftDivision);
            return BaseRepository.GetCallApi<List<MED_SHIFT_OPERATION_FILES>>(address);
        }

        public RequestResult<bool> FileIsExist(string patientID, int visitID, int operID, int shiftType, int shiftDivision, string fileName)
        {
            string address = string.Format("PacuShiftOperationInfo/FileIsExist?patientID={0}&visitID={1}&operID={2}&shiftType={3}&shiftDivision={4}&fileName={5}", patientID, visitID, operID, shiftType, shiftDivision, fileName);
            return BaseRepository.GetCallApi<bool>(address);
        }

        public RequestResult<bool> SaveShiftFileInfo(MED_SHIFT_OPERATION_FILES item)
        {
            return BaseRepository.PostCallApi<MED_SHIFT_OPERATION_FILES, bool>("PacuShiftOperationInfo/SaveShiftFileInfo", item);
        }

        public RequestResult<bool> DeleteShiftFileInfo(MED_SHIFT_OPERATION_FILES item)
        {
            return BaseRepository.PostCallApi<MED_SHIFT_OPERATION_FILES, bool>("PacuShiftOperationInfo/DeleteShiftFileInfo", item);
        }

        public RequestResult<List<MED_SHIFT_OPERATION_DATA>> GetShiftOperationData(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            string address = string.Format("PacuShiftOperationInfo/GetShiftOperationData?patientID={0}&visitID={1}&operID={2}&shiftType={3}&shiftDivision={4}", patientID, visitID, operID, shiftType, shiftDivision);
            return BaseRepository.GetCallApi<List<MED_SHIFT_OPERATION_DATA>>(address);
        }

        public RequestResult<int> GetRecordNo(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            string address = string.Format("PacuShiftOperationInfo/GetRecordNo?patientID={0}&visitID={1}&operID={2}&shiftType={3}&shiftDivision={4}", patientID, visitID, operID, shiftType, shiftDivision);
            return BaseRepository.GetCallApi<int>(address);
        }
        public RequestResult<bool> SaveShiftOperationData(MED_SHIFT_OPERATION_DATA item)
        {
            return BaseRepository.PostCallApi<MED_SHIFT_OPERATION_DATA, bool>("PacuShiftOperationInfo/SaveShiftOperationData", item);
        }
        public RequestResult<bool> DeleteSehiftOperationData(MED_SHIFT_OPERATION_DATA item)
        {
            return BaseRepository.PostCallApi<MED_SHIFT_OPERATION_DATA, bool>("PacuShiftOperationInfo/DeleteSehiftOperationData", item);
        }

        public RequestResult<bool> SaveShiftOperationSign(MED_SHIFT_OPERATION_SIGN item)
        {
            return BaseRepository.PostCallApi<MED_SHIFT_OPERATION_SIGN, bool>("PacuShiftOperationInfo/SaveShiftOperationSign", item);
        }

        public RequestResult<int> DeleteAllShiftFileInfo(List<MED_SHIFT_OPERATION_FILES> item)
        {
            return BaseRepository.PostCallApi<List<MED_SHIFT_OPERATION_FILES>, int>("PacuShiftOperationInfo/DeleteAllShiftFileInfo", item);
        }
        public RequestResult<int> DeleteAllShiftSignData(List<MED_SHIFT_OPERATION_DATA> item)
        {
            return BaseRepository.PostCallApi<List<MED_SHIFT_OPERATION_DATA>, int>("PacuShiftOperationInfo/DeleteAllShiftSignData", item);
        }
        public RequestResult<bool> DeleteShiftSignData(MED_SHIFT_OPERATION_SIGN item)
        {
            return BaseRepository.PostCallApi<MED_SHIFT_OPERATION_SIGN, bool>("PacuShiftOperationInfo/DeleteShiftSignData", item);
        }
    }
}
