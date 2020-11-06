using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
//using MedicalSystem.AnesWorkStation.Domain.AnesQuery;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 病案管理service   add by xiapei.y@2017-06-08 16:57:06
    /// </summary>
    public interface IPlatformAnesInfoService
    {
        /// <summary>
        ///手术室外麻醉列表
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        IList<dynamic> GetOutOperatingAnesRecord(OperQueryParaModel model);
        List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByID(string PatientID);

        List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByInpNo(string InpNo);

        List<OutOperatingRoomAnesRecordEntity> GetOperationMaster(string InpNo);
        List<OutOperatingRoomAnesRecordEntity> GetOperationMaster(string patientID, int visitID, int operID);

        int SaveOutOperatingRoomAnesRecordData(OutOperatingRoomAnesRecordEntity model);
    }

    public class PlatformAnesInfoService : BaseService<PlatformAnesInfoService>, IPlatformAnesInfoService
    {
        IMdkConfiguration mdkConfig;
        protected PlatformAnesInfoService()
            : base()
        { }
        public PlatformAnesInfoService(IDapperContext context)
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
        public IList<dynamic> GetOutOperatingAnesRecord(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetOutOperatingAnesRecord");
            return dapper.Set<dynamic>().Query(sql, new
            {
                StartDate = Convert.ToDateTime(model.StartDate),
                EndDate = Convert.ToDateTime(model.EndDate).AddDays(1),
                INP_NO = model.InpNo,
                ANES_DOCTOR = model.AnesDoctor
            });
        }

        /// <summary>
        /// 根据PatientId获取患者信息
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public virtual List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByID(string PatientID)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = dapper.Set<MED_PATS_IN_HOSPITAL>().Select(
                 x => x.PATIENT_ID == PatientID).ToList();
            return patsInHospitalList;
        }

        /// <summary>
        /// 根据InpNo获取患者信息
        /// </summary>
        /// <param name="InpNo"></param>
        /// <returns></returns>
        public virtual List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByInpNo(string InpNo)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = dapper.Set<MED_PATS_IN_HOSPITAL>().Select(
                 x => x.INP_NO == InpNo).ToList();
            return patsInHospitalList;
        }
        /// <summary>
        /// 获取病人手术信息列表
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        public virtual List<OutOperatingRoomAnesRecordEntity> GetOperationMaster(string InpNo)
        {
            string sql = sqlDict.GetSQLByKey("GetOutOperationRoomRecordByInpNo");
            return dapper.Set<OutOperatingRoomAnesRecordEntity>().Query(sql, new
            {
                InpNo = InpNo
            });
        }

        /// <summary>
        /// 获取病人手术信息列表
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        public virtual List<OutOperatingRoomAnesRecordEntity> GetOperationMaster(string patientID, int visitID, int operID)
        {
            string sql = sqlDict.GetSQLByKey("GetOutOperationRoomRecordByPatient");
            return dapper.Set<OutOperatingRoomAnesRecordEntity>().Query(sql, new
            {
                PatientId = patientID,
                VisitId = visitID,
                OperId = operID
            });
        }
        /// <summary>
        /// 保存手术室外麻醉
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveOutOperatingRoomAnesRecordData(OutOperatingRoomAnesRecordEntity model)
        {
            if (model == null) return 0;

            try
            {
                if (string.IsNullOrEmpty(model.PATIENT_ID))
                {
                    model.PATIENT_ID = model.INP_NO;
                }
                //获取master主表是否有改挑手术
                MED_OPERATION_MASTER operationMaster = dapper.Set<MED_OPERATION_MASTER>().Single(
                    x => x.PATIENT_ID == model.PATIENT_ID && x.VISIT_ID == model.VISIT_ID && x.OPER_ID == model.OPER_ID);

                int result = 0;
                if (operationMaster != null)
                {
                    operationMaster.DEPT_CODE = model.DEPT_CODE;
                    operationMaster.DIAG_BEFORE_OPERATION = model.DIAG_BEFORE_OPERATION;
                    operationMaster.OPERATION_NAME = model.OPERATION_NAME;
                    operationMaster.ANES_METHOD = model.ANES_METHOD;
                    operationMaster.ANES_DOCTOR = model.ANES_DOCTOR;
                    operationMaster.FIRST_ANES_ASSISTANT = model.FIRST_ANES_ASSISTANT;
                    operationMaster.FIRST_OPER_NURSE = model.FIRST_OPER_NURSE;
                    operationMaster.SECOND_OPER_NURSE = model.SECOND_OPER_NURSE;
                    operationMaster.ASA_GRADE = model.ASA_GRADE;
                    operationMaster.EMERGENCY_IND = Convert.ToInt32(model.EMERGENCY_IND);
                    operationMaster.IN_DATE_TIME = model.IN_DATE_TIME;
                    operationMaster.START_DATE_TIME = model.START_DATE_TIME;
                    operationMaster.END_DATE_TIME = model.END_DATE_TIME;
                    operationMaster.OUT_DATE_TIME = model.OUT_DATE_TIME;
                    operationMaster.LOCAL_ANESTHESIA = 1;
                    operationMaster.OPER_STATUS_CODE = 35;
                    operationMaster.OPER_ROOM = model.OPER_ROOM;
                    operationMaster.OPER_ROOM_NO = model.OPER_ROOM_NO;
                    operationMaster.OPER_SCALE = model.OPER_SCALE;
                    operationMaster.SURGEON = model.SURGEON;
                    operationMaster.FIRST_OPER_ASSISTANT = model.FIRST_OPER_ASSISTANT;
                    result = dapper.Set<MED_OPERATION_MASTER>().Update(operationMaster) > 0 ? 1 : 0;
                }
                else
                {
                    MED_OPERATION_MASTER newModel = new MED_OPERATION_MASTER();
                    newModel.PATIENT_ID = model.PATIENT_ID;
                    newModel.VISIT_ID = model.VISIT_ID;
                    newModel.OPER_ID = model.OPER_ID;
                    newModel.DEPT_CODE = model.DEPT_CODE;
                    newModel.DIAG_BEFORE_OPERATION = model.DIAG_BEFORE_OPERATION;
                    newModel.OPERATION_NAME = model.OPERATION_NAME;

                    newModel.ANES_METHOD = model.ANES_METHOD;
                    newModel.ANES_DOCTOR = model.ANES_DOCTOR;
                    newModel.FIRST_ANES_ASSISTANT = model.FIRST_ANES_ASSISTANT;
                    newModel.FIRST_OPER_NURSE = model.FIRST_OPER_NURSE;
                    newModel.SECOND_OPER_NURSE = model.SECOND_OPER_NURSE;
                    newModel.ASA_GRADE = model.ASA_GRADE;
                    newModel.EMERGENCY_IND = Convert.ToInt32(model.EMERGENCY_IND);
                    newModel.IN_DATE_TIME = model.IN_DATE_TIME;
                    newModel.SCHEDULED_DATE_TIME = model.SCHEDULED_DATE_TIME;
                    newModel.START_DATE_TIME = model.START_DATE_TIME;
                    newModel.END_DATE_TIME = model.END_DATE_TIME;
                    newModel.OUT_DATE_TIME = model.OUT_DATE_TIME;
                    newModel.LOCAL_ANESTHESIA = 1;
                    newModel.OPER_STATUS_CODE = 35;
                    newModel.OPER_ROOM = model.OPER_ROOM;
                    newModel.OPER_ROOM_NO = model.OPER_ROOM_NO;
                    newModel.OPER_SCALE = model.OPER_SCALE;
                    newModel.SURGEON = model.SURGEON;
                    newModel.FIRST_OPER_ASSISTANT = model.FIRST_OPER_ASSISTANT;
                    result = dapper.Set<MED_OPERATION_MASTER>().Insert(newModel) == true ? 1 : 0;
                }

                //手术名称表（先删再增）
                //删除模版
                dapper.Set<MED_OPERATION_NAME>().Delete(d => d.PATIENT_ID == model.PATIENT_ID && d.VISIT_ID == model.VISIT_ID
                 && d.OPER_ID == model.OPER_ID);

                if (!string.IsNullOrEmpty(model.OPERATION_NAME))
                {
                    string[] operNames = model.OPERATION_NAME.Split('+');
                    for (int i = 1; i <= operNames.Length; i++)
                    {
                        MED_OPERATION_NAME operNameModel = new MED_OPERATION_NAME();
                        operNameModel.PATIENT_ID = model.PATIENT_ID;
                        operNameModel.VISIT_ID = model.VISIT_ID;
                        operNameModel.OPER_ID = model.OPER_ID;
                        operNameModel.OPER_NO = i;
                        operNameModel.OPER_NAME = operNames[i - 1];
                        dapper.Set<MED_OPERATION_NAME>().Insert(operNameModel);
                    }
                }

                //室外麻醉手术在输入出手术室时间点击保存后，需要把对应的schedule表状态改为4，
                string OPER_STATUS_CODE = ""
; MED_OPERATION_SCHEDULE scheduleModel = dapper.Set<MED_OPERATION_SCHEDULE>().Single(
                   x => x.PATIENT_ID == model.PATIENT_ID && x.VISIT_ID == model.VISIT_ID && x.OPER_ID == model.OPER_ID);
                if (scheduleModel != null)
                {
                    OPER_STATUS_CODE = scheduleModel.OPER_STATUS_CODE.ToString();
                    scheduleModel.OPER_STATUS_CODE = 4;
                    scheduleModel.ModelStatus = ModelStatus.Modeified;
                    dapper.Set<MED_OPERATION_SCHEDULE>().Update(scheduleModel);
                }


                //修改扩展 体重
                MED_ANESTHESIA_PLAN_PMH phmModel = dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Single(
                   x => x.PATIENT_ID == model.PATIENT_ID && x.VISIT_ID == model.VISIT_ID && x.OPER_ID == model.OPER_ID);
                if (phmModel != null)
                {
                    phmModel.WEIGHT = model.WEIGHT;    
                    dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Update(phmModel);
                }
                else
                {
                    phmModel = new MED_ANESTHESIA_PLAN_PMH();
                    phmModel.PATIENT_ID = model.PATIENT_ID;
                    phmModel.VISIT_ID = model.VISIT_ID;
                    phmModel.OPER_ID = model.OPER_ID;
                    phmModel.WEIGHT = model.WEIGHT;
                    dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(phmModel);
                }
                dapper.SaveChanges();

                //调用HISHIS203回写手术主表信息
                //if (OPER_STATUS_CODE != "4")  //回写之后不再回写
                //{
                //    if (SyncHIS203(model.PATIENT_ID, model.VISIT_ID,model.OPER_ID) != "")
                //    {
                //        return 2;
                //    }
                //}
            }
            catch(Exception ex)
            {
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 回传手术状态HIS203
        /// </summary>
        public string SyncHIS203(string patientID, int visitID, int operID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "OPER502W";
                paramIn.App = "手麻系统";
                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                paramIn.Operation.OperId = operID;
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