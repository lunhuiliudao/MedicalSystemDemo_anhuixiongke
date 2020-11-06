using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 病案管理service   add by xiapei.y@2017-06-08 16:57:06
    /// </summary>
    public interface IPlatformPatientRecordService
    {
        /// <summary>
        /// 病例病程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperPatientProgressEntity QueryOperPatientProgress(OperQueryParaModel model);

        /// <summary>
        /// 查询文书PDF列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<AnesDocumentPDFSrcEntity> QueryAnesDocumentPDF(OperQueryParaModel model);

        /// <summary>
        /// 统计-手术查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<OperQuerytForAnesQueryEntity> GetOperList(OperQueryParaModel model);
    }

    public class PlatformPatientRecordService : BaseService<PlatformPatientRecordService>, IPlatformPatientRecordService
    {
        IMdkConfiguration mdkConfig;
        protected PlatformPatientRecordService()
            : base()
        { }
        public PlatformPatientRecordService(IDapperContext context)
            : base(context)
        {
            MdkConfiguration.AddCustomConfig<XmlDictConfig>();
            mdkConfig = MdkConfiguration.GetConfig();
        }
        /// <summary>
        /// 病例病程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperPatientProgressEntity QueryOperPatientProgress(OperQueryParaModel model)
        {
//            string sql = @"select a.patient_id,
//                           a.visit_id,
//                           a.oper_id,
//                           b.Name,
//                           b.Sex,
//                           ROUND((a.SCHEDULED_DATE_TIME - b.DATE_OF_BIRTH) / 365, 0) AS AGE,
//                           a.Bed_No,
//                           e.Inp_No,
//                           e.ADMISSION_DATE_TIME,
//                           c.Dept_Name,
//                           nvl(d.User_Name, a.Anes_Doctor) AnesDoctor,
//                           nvl(d1.User_Name, a.Surgeon) Surgeon,
//                           DIAG_BEFORE_OPERATION,
//                           OPERATION_NAME,
//                           OPER_POSITION,
//                           A.Oper_Scale,
//                           a.Scheduled_Date_Time,
//                           f.Height,
//                           f.Weight,
//                           g.item_value before_BP1,
//                           g1.Item_Value before_BP2,
//                           g2.Item_Value before_P,
//                           g3.Item_Value brfore_R,
//                           g4.Item_Value before_XDT,
//                           decode(g5.Item_Value, '0', '有', '1', '无', '无') before_YWGMS,
//                           a.ANES_METHOD,
//                           a.Asa_Grade,
//                           TO_CHAR(TRUNC((NVL((a.End_Date_Time - a.Start_Date_Time) * 24, 0) * 60) / 60,
//                                         0)) || '小时' ||
//                           TO_CHAR(ROUND(MOD((NVL((a.End_Date_Time - a.Start_Date_Time) * 24, 0) * 60),
//                                             60),
//                                         0)) || '分钟' AS OPERTIME,
//                           a.In_Date_Time,
//                           a.Out_Date_Time,
//                           a.Start_Date_Time,
//                           a.End_Date_Time,
//                           a.Anes_Start_Time,
//                           a.Anes_End_Time,
//                           a.In_Pacu_Date_Time,
//                           a.Out_Pacu_Date_Time,  nvl(mead.Docs,'无') Docs
//                      from Med_Operation_Master a
//                      left join Med_Pat_Master_Index b
//                        on a.Patient_Id = b.Patient_Id
//                      left join Med_Dept_Dict c
//                        on a.Dept_Code = c.Dept_Code
//                      left join Med_His_Users d
//                        on a.Anes_Doctor = d.User_Job_Id
//                      left join Med_His_Users d1
//                        on a.Surgeon = d1.User_Job_Id
//                      left join Med_Pats_In_Hospital e
//                        on a.Patient_Id = e.Patient_Id
//                       and a.Visit_Id = e.Visit_Id
//                      left join MED_ANESTHESIA_PLAN_PMH f
//                        on a.Patient_Id = f.Patient_Id
//                       and a.Visit_Id = f.Visit_Id
//                       and a.Oper_Id = f.Oper_Id

//                      left join MED_PREOPERATIVE_EXPANSION g
//                        on a.Patient_Id = g.Patient_Id
//                       and a.Visit_Id = g.Visit_Id
//                       and a.Oper_Id = g.Oper_Id
//                       and g.item_name = '术前访视_BP'
//                      left join MED_PREOPERATIVE_EXPANSION g1
//                        on a.Patient_Id = g1.Patient_Id
//                       and a.Visit_Id = g1.Visit_Id
//                       and a.Oper_Id = g1.Oper_Id
//                       and g1.item_name = '术前访视单_低压'
//                      left join MED_PREOPERATIVE_EXPANSION g2
//                        on a.Patient_Id = g2.Patient_Id
//                       and a.Visit_Id = g2.Visit_Id
//                       and a.Oper_Id = g2.Oper_Id
//                       and g2.item_name = '术前访视_P'
//                      left join MED_PREOPERATIVE_EXPANSION g3
//                        on a.Patient_Id = g3.Patient_Id
//                       and a.Visit_Id = g3.Visit_Id
//                       and a.Oper_Id = g3.Oper_Id
//                       and g3.item_name = '术前访视_R'
//                      left join MED_PREOPERATIVE_EXPANSION g4
//                        on a.Patient_Id = g4.Patient_Id
//                       and a.Visit_Id = g4.Visit_Id
//                       and a.Oper_Id = g4.Oper_Id
//                       and g4.item_name = '术前访视_心电图'
//                      left join MED_PREOPERATIVE_EXPANSION g5
//                        on a.Patient_Id = g5.Patient_Id
//                       and a.Visit_Id = g5.Visit_Id
//                       and a.Oper_Id = g5.Oper_Id
//                       and g5.item_name = '术前访视_药物过敏史'
// left join (select patient_id,visit_id,archive_key Oper_Id ,to_char(replace(wm_concat(Mr_Sub_Class),',',';')) Docs from Med_Emr_Archive_Detial
//group by patient_id,visit_id,archive_key)  mead  on a.Patient_Id=mead.Patient_Id and a.Visit_Id=mead.Visit_Id and a.Oper_Id=mead.Oper_Id
//                    where a.patient_id = :PatientId and a.visit_Id =:VisitId and a.oper_Id=:OperId
//                    ";
           string  sql = sqlDict.GetSQLByKey("QueryOperPatientProgress");
            return dapper.Set<OperPatientProgressEntity>().Query(sql, new
            {
                PatientId = model.PatientId,
                VisitId = model.VisitId,
                OperId = model.OperId
            }).FirstOrDefault();
        }

        /// <summary>
        /// 查询文书PDF列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<AnesDocumentPDFSrcEntity> QueryAnesDocumentPDF(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("QueryAnesDocumentPDF");
            return dapper.Set<AnesDocumentPDFSrcEntity>().Query(sql, new
            {
                PatientId = model.PatientId,
                VisitId = model.VisitId,
                OperId = model.OperId,
                DocName = model.SearchMark
            });
        }

       /// <summary>
       /// 手术查询
       /// </summary>
       /// <param name="model">对象</param>
       /// <returns></returns>
        public IList<OperQuerytForAnesQueryEntity> GetOperList(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetOperListForAnesQuery");
            DateTime? startTime = null;
            DateTime? endTime = null;
            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                startTime = Convert.ToDateTime(model.StartDate);
                endTime = Convert.ToDateTime(model.EndDate).AddDays(1);
            }
            return dapper.Set<OperQuerytForAnesQueryEntity>().Query(sql, new
            {
                PatName = model.PatName,
                InpNo = model.InpNo,
                AnesDoctor = model.AnesDoctor,
                model.OperDept,
                model.OperRoomNo,
                StartDate = startTime,
                EndDate = endTime,
            });
        }

    }
}