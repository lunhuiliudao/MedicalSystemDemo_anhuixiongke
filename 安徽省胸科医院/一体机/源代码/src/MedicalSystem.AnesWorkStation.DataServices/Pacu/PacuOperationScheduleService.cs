using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuOperationScheduleService
    {

        List<MED_OPERATION_SCHEDULE> GetOperationScheduleList(DateTime startTime, DateTime endTime, string emergencyFlg, string hospBranch, string operRoom);

        int GetMaxOperID(string patientID, int visitID);

        bool UpdateOperationScheduleByPatientInfo(MED_OPERATION_SCHEDULE item, string type);

        bool UpdateOperationSchedule(List<MED_OPERATION_SCHEDULE> item, string type);

        int GetMaxOperationNo(string patientID, int visitID, int operID);

        MED_OPERATION_SCHEDULE GetOperationScheduleListByPatientInfo(string patientID, int visitID, int scheduleID);

        List<MED_OPERATION_SCHEDULE_NAME> GetOperationScheduleNameListByPatientInfo(string patientID, int visitID, int scheduleID);
    }
    public class PacuOperationScheduleService : BaseService<PacuOperationScheduleService>, IPacuOperationScheduleService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuOperationScheduleService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuOperationScheduleService(IDapperContext context)
            : base(context)
        {


        }
        public List<MED_OPERATION_SCHEDULE> GetOperationScheduleList(DateTime startTime, DateTime endTime, string emergencyFlg, string hospBranch, string operRoom)
        {
            string sqlText = @"select a.*,n.sort_no, b.dept_name as oper_dept_name,c.name,c.date_of_birth,c.sex, l.inp_no,
fun_get_pat_age(c.date_of_birth,a.SCHEDULED_DATE_TIME) as age,
nvl(d.user_name,a.surgeon) as surgeon_name,nvl(e.user_name,a.first_oper_assistant) as first_oper_assistant_name,
nvl(f.user_name,a.anes_doctor) as anes_doctor_name,
nvl(d.user_name,a.surgeon) || ' '|| nvl(e.user_name,a.first_oper_assistant) AS SURGEON_ALL_NAME,
nvl(f.user_name,a.anes_doctor) || ' '|| nvl(g.user_name,a.first_anes_assistant) AS ANES_ALL_DOCTOR_NAME,
nvl(g.user_name,a.first_anes_assistant) as first_anes_assistant_name , nvl(h.user_name,a.first_oper_nurse) as first_oper_nurse_name,
nvl(i.user_name,a.second_oper_nurse) as second_oper_nurse_name,nvl(j.user_name,a.first_supply_nurse) as first_supply_nurse_name,
nvl(k.user_name,a.second_supply_nurse) as second_supply_nurse_name
  from med_operation_schedule a
  left join med_dept_dict b
    on a.oper_dept_code = b.dept_code
  left join med_pat_master_index c
    on a.patient_id = c.patient_id
    left join med_his_users d on a.surgeon = d.User_Job_Id
    left join med_his_users e on a.first_oper_assistant = e.user_job_id
    left join med_his_users f on a.anes_doctor = f.user_job_id
    left join med_his_users g on a.first_anes_assistant = g.user_job_id
    left join med_his_users h on a.first_oper_nurse = h.user_job_id
    left join med_his_users i on a.second_oper_nurse = i.user_job_id
    left join med_his_users j on a.first_supply_nurse = j.user_job_id
    left join med_his_users k on a.second_supply_nurse = k.user_job_id
    left join med_operating_room n on a.oper_room_no=n.room_no
    left join MED_PATS_IN_HOSPITAL l on a.patient_id = l.patient_id and a.visit_id = l.visit_id 
where (a.oper_status_code = '0' or a.oper_status_code = '2') ";
            sqlText += " and TO_CHAR(a.SCHEDULED_DATE_TIME,'yyyy-MM-dd') >= '" + startTime.ToString("yyyy-MM-dd")
                + "' and TO_CHAR(a.SCHEDULED_DATE_TIME,'yyyy-MM-dd') <= '" + endTime.ToString("yyyy-MM-dd")
                + "' ";
            if (!string.IsNullOrEmpty(emergencyFlg))
            {
                sqlText = sqlText + " AND (a.emergency_ind = '" + emergencyFlg + "' or '" + emergencyFlg + "' is null)";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND a.HOSP_BRANCH ='" + hospBranch + "'";
            }
            if (!string.IsNullOrEmpty(operRoom) && operRoom != "All")
            {
                sqlText = sqlText + " AND a.OPER_ROOM = '" + operRoom + "' ";
            }
            return dapper.Set<MED_OPERATION_SCHEDULE>().Query(sqlText);

        }

        public MED_OPERATION_SCHEDULE GetOperationScheduleListByPatientInfo(string patientID, int visitID, int scheduleID)
        {
            string sqlText = @"select a.*,n.sort_no, b.dept_name as oper_dept_name,c.name,c.date_of_birth,c.sex, l.inp_no,
fun_get_pat_age(c.date_of_birth,a.SCHEDULED_DATE_TIME) as age,
nvl(d.user_name,a.surgeon) as surgeon_name,nvl(e.user_name,a.first_oper_assistant) as first_oper_assistant_name,
nvl(f.user_name,a.anes_doctor) as anes_doctor_name,
nvl(g.user_name,a.first_anes_assistant) as first_anes_assistant_name , nvl(h.user_name,a.first_oper_nurse) as first_oper_nurse_name,
nvl(i.user_name,a.second_oper_nurse) as second_oper_nurse_name,nvl(j.user_name,a.first_supply_nurse) as first_supply_nurse_name,
nvl(k.user_name,a.second_supply_nurse) as second_supply_nurse_name
  from med_operation_schedule a
  left join med_dept_dict b
    on a.oper_dept_code = b.dept_code
  left join med_pat_master_index c
    on a.patient_id = c.patient_id
    left join med_his_users d on a.surgeon = d.User_Job_Id
    left join med_his_users e on a.first_oper_assistant = e.user_job_id
    left join med_his_users f on a.anes_doctor = f.user_job_id
    left join med_his_users g on a.first_anes_assistant = g.user_job_id
    left join med_his_users h on a.first_oper_nurse = h.user_job_id
    left join med_his_users i on a.second_oper_nurse = i.user_job_id
    left join med_his_users j on a.first_supply_nurse = j.user_job_id
    left join med_his_users k on a.second_supply_nurse = k.user_job_id
    left join med_operating_room n on a.oper_room_no=n.room_no
    left join MED_PATS_IN_HOSPITAL l on a.patient_id = l.patient_id and a.visit_id = l.visit_id 
where a.patient_id = '" + patientID + "' and a.visit_id = '" + visitID + "' and a.schedule_id = '" + scheduleID + "' ";

            return dapper.Set<MED_OPERATION_SCHEDULE>().Query(sqlText).FirstOrDefault();

        }

        public int GetMaxOperID(string patientID, int visitID)
        {
            string sqlText = @"SELECT NVL(MAX(OPER_ID),0) AS OPER_ID FROM MED_OPERATION_MASTER WHERE PATIENT_ID = '" + patientID + "' AND VISIT_ID = '" + visitID + "' ";
            return dapper.Set<MED_OPERATION_MASTER>().Query(sqlText).Select(x => x.OPER_ID).FirstOrDefault();
        }

        public bool UpdateOperationScheduleByPatientInfo(MED_OPERATION_SCHEDULE item, string type)
        {
            bool flg = true;
            if (type == "1")
            {
                flg = dapper.Set<MED_OPERATION_SCHEDULE>().Update(item, p => new
                {
                    p.OPER_ROOM_NO,
                    p.SEQUENCE,
                    p.SCHEDULED_DATE_TIME,
                    p.FIRST_OPER_NURSE,
                    p.SECOND_OPER_NURSE,
                    p.FIRST_SUPPLY_NURSE,
                    p.SECOND_SUPPLY_NURSE,
                    p.OPER_STATUS_CODE,
                    p.NURSE_CONFIRM
                }) > 0 ? true : false;
            }
            else
            {
                flg = dapper.Set<MED_OPERATION_SCHEDULE>().Update(item, p => new
                {
                    p.ANES_METHOD,
                    p.ANES_DOCTOR,
                    p.FIRST_ANES_ASSISTANT,
                    p.SECOND_ANES_ASSISTANT,
                    p.THIRD_ANES_ASSISTANT,
                    p.FOURTH_ANES_ASSISTANT,
                    p.OPER_STATUS_CODE,
                    p.ANES_CONFIRM
                }) > 0 ? true : false;
            }
            dapper.SaveChanges();
            return flg;
        }

        public bool UpdateOperationSchedule(List<MED_OPERATION_SCHEDULE> item, string type)
        {
            bool flg = true;

            if (type == "1")
            {
                foreach (var data in item)
                {
                    flg = flg & dapper.Set<MED_OPERATION_SCHEDULE>().Update(data, p => new
                    {
                        p.OPER_ROOM_NO,
                        p.SEQUENCE,
                        p.SCHEDULED_DATE_TIME,
                        p.FIRST_OPER_NURSE,
                        p.SECOND_OPER_NURSE,
                        p.FIRST_SUPPLY_NURSE,
                        p.SECOND_SUPPLY_NURSE,
                        p.OPER_STATUS_CODE,
                        p.NOTES_ON_OPERATION
                    }) > 0 ? true : false;
                }
            }
            else
            {
                foreach (var data in item)
                {
                    flg = flg & dapper.Set<MED_OPERATION_SCHEDULE>().Update(data, p => new
                    {
                        p.ANES_METHOD,
                        p.ANES_DOCTOR,
                        p.FIRST_ANES_ASSISTANT,
                        p.SECOND_ANES_ASSISTANT,
                        p.THIRD_ANES_ASSISTANT,
                        p.FOURTH_ANES_ASSISTANT,
                        p.OPER_STATUS_CODE
                    }) > 0 ? true : false;
                }
            }
            if (flg)
            {
                dapper.SaveChanges();
            }

            return flg;
        }

        public int GetMaxOperationNo(string patientID, int visitID, int operID)
        {
            string sqlText = @"SELECT NVL(MAX(OPER_NO),0) AS OPER_NO FROM MED_OPERATION_NAME WHERE PATIENT_ID = '" + patientID + "' AND VISIT_ID = '" + visitID + "' AND OPER_ID = '" + operID + "' ";
            int? data = dapper.Set<MED_OPERATION_NAME>().Query(sqlText).Select(x => x.OPER_NO).FirstOrDefault();
            return data == null ? 0 : (int)data;
        }



        public List<MED_OPERATION_SCHEDULE_NAME> GetOperationScheduleNameListByPatientInfo(string patientID, int visitID, int scheduleID)
        {
            return dapper.Set<MED_OPERATION_SCHEDULE_NAME>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.SCHEDULE_ID == scheduleID).OrderBy(t => t.OPER_NO).ToList();
        }
    }
}
