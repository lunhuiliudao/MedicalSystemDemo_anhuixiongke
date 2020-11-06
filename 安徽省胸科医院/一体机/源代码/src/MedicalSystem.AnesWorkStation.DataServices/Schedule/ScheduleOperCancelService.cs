using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.ViewModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;

namespace MedicalSystem.AnesWorkStation.DataServices
{

    public interface IScheduleOperCancelService
    {
        IList<OperCancelEntity> GetOperCancelList(DateTime ScheduleDateTime, string OperRoom);
        bool RebackCancelOper(string patientID, decimal visitID, decimal scheduleID);
    }
    public class ScheduleOperCancelService : BaseService<ScheduleOperCancelService>, IScheduleOperCancelService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScheduleOperCancelService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ScheduleOperCancelService(IDapperContext context)
            : base(context)
        {
        }

        [HttpGet]
        public virtual IList<OperCancelEntity> GetOperCancelList(DateTime ScheduleDateTime, string OperRoom)
        {
            string sql = sqlDict.GetSQLByKey("GetOperCancelList");
            return dapper.Set<OperCancelEntity>().Query(sql, new { StartDateTime = ScheduleDateTime, ENDDateTime = ScheduleDateTime.AddDays(1), OperRoom = OperRoom });
        }

        [HttpPost]
        public virtual bool RebackCancelOper(string patientID, decimal visitID, decimal scheduleID)
        {
            var num = dapper.Set<MED_OPERATION_SCHEDULE>().Update(exp => exp.PATIENT_ID == patientID && exp.VISIT_ID == (int)visitID && exp.SCHEDULE_ID == (int)scheduleID, new { OPER_STATUS_CODE = 0 });
            dapper.SaveChanges();
            return num > 0;
        }
    }
}
