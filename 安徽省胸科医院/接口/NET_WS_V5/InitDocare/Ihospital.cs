using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using MedicalSytem.Soft;
using System.Data;
 
using MedicalSytem.Soft.InitDocare;

namespace InitDocare
{
    /// <summary>
    /// 默认为oracle的Client连接数据库
    /// </summary>
    public interface Ihospital
    {

        //string InitANES(Config config, MedicalSytem.Soft.Model.MedInitDict dict, string operationRoomList);
        
        /////<summary
        ///// 集成平台下 本系统单点登陆  2011-9-3增加酒小龙
        /////</summary>
        ///// <param name="SysId">系统ID</param>
        ///// <param name="UserJob">用户角色</param>
        ///// <param name="UserNO">工号ID</param>
        ///// <param name="UserPassword">用户密码</param>
        ///// <param name="UserPasswordNew">用户新密码</param>
        ///// <returns></returns>
        //string GetLoginInfo(string UserNO, string UserPassword, string UserPasswordNew);
        ///// <summary>
        ///// 同步医院科室信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetDeptDictRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        
        ///// <summary>
        ///// 同步HIS人员信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetHisUsersRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);

        ///// <summary>
        ///// 同步手术名称字典
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetOperationDict(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);

        ///// <summary>
        ///// 同步诊断字段
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <returns></returns>
        //string GetDiagnosisDict(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 同步床位字典
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetBedRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);

        ///// <summary>
        ///// 同步价表信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetPriceListRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string deptDict);
        ///// <summary>
        ///// 收费单个项目价格
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetOnePriceListRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string itemClass, string itemCode);
        ///// <summary>
        ///// 同步价表名称信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetPriceItemNameDictRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 同步药品信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetDrugDictRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 同步药品名称信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetDrugNameDictRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 提取HIS药品申请信息-入库信息 对应HIS-出库
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetDrugImportDetailHis(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 同步物资信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetMtrlDictRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 同步药品及物资供应商信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetMtrlSupplierCatalogRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 提取HIS物资(耗材)申请信息-入库信息 对应HIS-出库
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetMtrlImportDetailHis(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 根据ID号同步单病人基本信息及住院信息--PatentId号VisitId号
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <param name="inputData">传入的结构体-参数-PatientId</param>
        ///// <returns></returns>
        //string GetPatientIDRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId);
        ///// <summary>
        ///// 根据住院号同步单病人基本信息及住院信息--InpNo号
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <param name="inputData">传入的结构体-参数-InpNo</param>
        ///// <returns></returns>
        //string GetPatientInpNoRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string inpNo);
        ///// <summary>
        ///// 提取并同步所有住院病人基本信息--wardCode代码
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <param name="inputData">传入的结构体-参数-wardCode</param>
        ///// <returns></returns>
        //string GetDeptPatientRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string wardCode);
        ///// <summary>
        ///// 提取单病人医嘱信息--PatentId号VisitId号	
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <param name="inputData">传入的结构体-参数-PatentId,VisitId</param>
        ///// <returns></returns>
        //string GetIcuPatientOrdersRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId);
        ///// <summary>
        ///// 提取单病人区间医嘱信息--PatentId号VisitId号	
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <param name="inputData">传入的结构体-参数-PatentId,VisitId</param>
        ///// <returns></returns>
        //string GetIcuPatientOrdersRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, DateTime startTime, DateTime endTime);
        ///// <summary>
        ///// 提取单病人的检验信息--PatentId号VisitId号
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <returns></returns>
        //string GetPatientLabTestMaster(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId);
        ///// <summary>
        ///// 使用的提取护理信息 -- 绍兴人民医院
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <returns></returns>
        //string GetPatientNursingDataRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId);
        ///// <summary>
        ///// 同步病人申请或预约信息
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="startdatetime"></param>
        ///// <param name="stopdatetime"></param>
        ///// <returns></returns>
        //string GetPatientOperationSchedule(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, DateTime startdatetime, DateTime stopdatetime, string wardCode);
        ///// <summary>
        ///// 更新病人手术预约和手术信息
        ///// </summary>
        ///// <param name="?"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <param name="scheduleId"></param>
        ///// <returns></returns>
        //string UpdatePatientMedOperationScheduleAndMedScheduleOperationName(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, decimal scheduleId, MedicalSytem.Soft.Model.MedOperationSchedule onePatOperationSchedule, List<MedicalSytem.Soft.Model.MedScheduledOperationName> medScheduleOperationNameList);
        ///// <summary>
        ///// 获取该病人本次手术是否有收费权限
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <param name="operId"></param>
        ///// <returns></returns>
        //string GetPatientTransConstsVerify(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, decimal operId, string enteredBy, string performedby);
        ///// <summary>
        ///// //回写病人手术预约信息(OPERATION_SCHEDULE,SCHEDULE_OPERATION_NAME)
        ///// </summary>
        ///// <param name="startTime"></param>
        ///// <param name="endTime"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <returns></returns>
        //string CopyBackOperationScheduleInformation(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, decimal operId);
        ///// <summary>
        ///// 回写病人手术预约信息(OPERATION_SCHEDULE,SCHEDULED_OPERATION_NAME)--麻醉程序术前手术安排时候回写
        ///// </summary>
        ///// <param name="startTime"></param>
        ///// <param name="endTime"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <returns></returns>
        //string CopyBackOperationInformation(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, DateTime startTime, DateTime endTime, string patientId, decimal visitId,decimal operId);
        ///// <summary>
        ///// 回写手术状态 2011-9-4　酒小龙　增加
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <param name="operId"></param>
        ///// <param name="operStatus"></param>
        ///// <returns></returns>
        //string CopyBackOperationState(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, decimal operId,string operStatus);
        ///// <summary>
        ///// 预约排班信息--手术取消
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <param name="operId"></param>
        ///// <returns></returns>
        //string CopyBackOperationChancel(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, decimal operId);
        ///// <summary>
        ///// 回写HIS收费项目，单条回写收费信息
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <param name="operId"></param>
        ///// <returns></returns>
        //string CopyBackPatientOneTransConsts(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, decimal operId);
        ///// <summary>
        ///// 回写HIS收费项目,一次回写本次所有的收费信息
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="patientId"></param>
        ///// <param name="visitId"></param>
        ///// <param name="operId"></param>
        ///// <returns></returns>
        //string CopyBackPatientAllTransConsts(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string reserved02, string patientId, decimal visitId, decimal operId, decimal itemNo, string enteredBy);
        ///// <summary>
        ///// 打印上传病历文书--提交HIS相关信息
        ///// </summary>
        ///// <param name="config">配置信息</param>
        ///// <param name="dict">配置字典</param>
        ///// <param name="patientId">病人ID号</param>
        ///// <param name="visitId">病人住院次数</param>
        ///// <param name="mrClass">类别</param>
        ///// <param name="mrSubClass">子类别</param>
        ///// <param name="archiveKey">归档主键</param>
        ///// <param name="archiveTimes">归档次数 归档次数为0则不知道归档次数需要自己到数据库里面获取</param>
        ///// <param name="emrFileIndex">页码 0为第一页 1为第二页</param>
        ///// <param name="emrFileName">归档文件名称</param>
        ///// <returns></returns>
        //string GetPatientEmrDocUpLoad(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, string mrClass, string mrSubClass, string archiveKey, decimal archiveTimes, decimal emrFileIndex, string emrFileName);
        ///// <summary>
        ///// 病人所有病历提交(无法再修改)--提交所有相关文书信息
        ///// </summary>
        ///// <param name="config">配置信息</param>
        ///// <param name="dict">配置字典</param>
        ///// <param name="patientId">病人ID号</param>
        ///// <param name="visitId">病人住院次数</param>
        ///// <param name="mrClass">类别</param>
        ///// <param name="archiveKey">归档主键</param>
        ///// <returns></returns>
        //string GetPatientAllEmrDocUpLoad(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, decimal visitId, string mrClass, string archiveKey);
        ///// <summary>
        ///// 更新XML用户字典
        ///// </summary>
        ///// <param name="xml">获取的XML</param>
        ///// <returns></returns>
        //string UpdateUsers(MedicalSytem.Soft.Model.MedInitDict dict, string appClass, string xml);
        ///// <summary>
        ///// 更新XML科室字典
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //string UpdateDeptDict(MedicalSytem.Soft.Model.MedInitDict dict, string appClass, string xml);
        ///// <summary>
        ///// 更新XML病人基本信息
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //string UpdatePatMasterIndex(MedicalSytem.Soft.Model.MedInitDict dict, string appClass, string xml);
        ///// <summary>
        ///// 更新XML在院病人信息
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //string UpdatePatsInHospital(MedicalSytem.Soft.Model.MedInitDict dict, string appClass, string xml);
        ///// <summary>
        ///// 更新XML手术预约
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //string UpdateOperationSchedule(MedicalSytem.Soft.Model.MedInitDict dict, string xml);
        ///// <summary>
        ///// 获取病人麻醉药品事件等相关信息
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //string GetAnesthesiaEvent(MedicalSytem.Soft.Model.MedInitDict dict, string xml);
        ///// <summary>
        ///// 获取病人电子病历记录
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //string GetDataPatientEmrArchiveDetial(MedicalSytem.Soft.Model.MedInitDict dict, string appClass, string xml);
        ///// <summary>
        ///// 获取病人电子病历详细文件
        ///// </summary>
        ///// <param name="appClass"></param>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //string GetDataPatientEmrArchiveDetialInfo(MedicalSytem.Soft.Model.MedInitDict dict, string appClass, string xml);
        ///// <summary>
        ///// 同步SemrHIS人员信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetSemrUsersRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict);
        ///// <summary>
        ///// 同步Semr门诊病人信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetSemrPatientsRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId);
        ///// <summary>
        ///// 同步Semr门诊挂号信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetSemrMedicalcasesRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, DateTime startdatetime, DateTime stopdatetime);
        ///// <summary>
        ///// 同步Semr单患者门诊挂号信息
        ///// </summary>
        ///// <param name="config">配置文件</param>
        ///// <param name="dict">字典文件</param>
        ///// <returns></returns>
        //string GetSemrOneMedicalcasesRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientId, string reserved01, string reserved02);
        ///// <summary>
        ///// 同步供应室消耗品信息
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="reserved01"></param>
        ///// <returns></returns>
        //string GetSupplyPackageRec(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string reserved01);
        ///// <summary>
        ///// 回写供应室物品去向信息
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="reserved01"></param>
        ///// <param name="reserved02"></param>
        ///// <param name="reserved03"></param>
        ///// <param name="reserved04"></param>
        ///// <param name="reserved05"></param>
        ///// <returns></returns>
        //string CopyBackSupplyPackageUseInfo(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string reserved01, string reserved02, string reserved03, string reserved04, string reserved05, string reserved06, string reserved07, string reserved08, string reserved09, string reserved10, decimal reserved11, decimal reserved12, DateTime reserved13, DateTime reserved14);
        ///// <summary>
        ///// 回写HIS护理信息   2013-11-26
        ///// </summary>
        ///// <param name="config"></param>
        ///// <param name="dict"></param>
        ///// <param name="reserved01"></param>
        ///// <param name="reserved02"></param>
        ///// <param name="reserved03"></param>
        ///// <param name="reserved04"></param>
        ///// <param name="reserved05"></param>
        ///// <returns></returns>
        //string CopyBackNursingInfo(MedicalSytem.Soft.InitDocare.Config config, MedicalSytem.Soft.Model.MedInitDict dict, string patientid, decimal visitid, DataSet icuDataSet);
    
    }
}
