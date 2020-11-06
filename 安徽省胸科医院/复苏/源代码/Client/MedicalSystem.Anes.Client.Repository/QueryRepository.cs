using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class QueryRepository : BaseRepository
    {
        #region IQueryDataInterface 成员

        public RequestResult<System.Data.DataTable> GetOperationList(DateTime startTime, DateTime endTime, string inpNo, string name, string operationName, string oper_scale, string surgeon, string oper_dept_code, string anes_doctor, string anes_method, string asa_grade, int emergency_ind)
        {
            string address = "PacuQuery/GetOperationList?startTime=" + startTime.ToString("yyyy-MM-dd")
                + "&endTime=" + endTime.ToString("yyyy-MM-dd")
                + "&inpNo=" + inpNo
                + "&name=" + name
                + "&operationName=" + operationName
                + "&oper_scale=" + oper_scale
                + "&surgeon=" + surgeon
                + "&oper_dept_code=" + oper_dept_code
                + "&anes_doctor=" + anes_doctor
                + "&anes_method=" + anes_method
                + "&asa_grade=" + asa_grade
                + "&emergency_ind=" + emergency_ind;
            return BaseRepository.GetCallApi<System.Data.DataTable>(address);
        }

        #endregion

        #region IQueryDataInterface 成员


        /// <summary>
        /// 工作量统计
        /// </summary>
        /// <param name="startTime">报表时间</param>
        /// <param name="report">报表类型,1:日报；2:月报；3:年报</param>
        /// <returns>报表结果</returns>
        public RequestResult<System.Data.DataTable> GetOperationReport(DateTime startTime, int report)
        {
            string address = "PacuQuery/GetOperationReport?startTime=" + startTime.ToString("yyyy-MM-dd")
                + "&report=" + report;
            return BaseRepository.GetCallApi<System.Data.DataTable>(address);
        }

        #endregion
    }
}
