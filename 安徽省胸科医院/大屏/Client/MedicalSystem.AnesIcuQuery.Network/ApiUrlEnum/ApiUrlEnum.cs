//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      	ApiUrlEnum.cs
//功能描述(Description)：    API枚举类
//数据表(Tables)：		    
//作者(Author)：             李维祥
//日期(Create Date)：        2015/09/18
//R1:
//    修改作者:
//    修改日期：
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System.ComponentModel;

namespace MedicalSystem.AnesIcuQuery.Network
{
    /// <summary>
    /// API功能模块
    /// </summary>
    public enum ApiUrlEnum
    {
        /// <summary>
        /// 空
        /// </summary>
        Null,

        #region Common
        /// <summary>
        /// 测试网络
        /// </summary>
        [Description("ScreenCommon/TestNet")]
        TestNet,
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        [Description("ScreenCommon/GetServerDateTime")]
        GetServerDateTime,

        /// <summary>
        /// 获取手术室配置
        /// </summary>
        [Description("Common/GetOperationRoom")]
        OperationRoom,
        /// <summary>
        /// 麻醉数据库版本
        /// </summary>
        [Description("Common/GetAnesVersion")]
        AnesVersion,
        /// <summary>
        /// 麻醉医生科室代码
        /// </summary>
        [Description("Common/GetAnesthesiaWardCode")]
        AnesthesiaWardCode,
        /// <summary>
        /// 手术医生科室代码
        /// </summary>
        [Description("Common/GetOperDoctorWardCode")]
        OperDoctorWardCode,
        /// <summary>
        /// 手术护士科室代码
        /// </summary>
        [Description("Common/GetOperNurseWardCode")]
        OperNurseWardCode,
        /// <summary>
        /// 1台麻醉是否多台手术
        /// </summary>
        [Description("Common/GetOneAnesIsMoreOperation")]
        GetOneAnesIsMoreOperation,
        /// <summary>
        /// 说明文档-指标说明
        /// </summary>
        [Description("Common/GetHelperDoc")]
        HelperDoc,
        /// <summary>
        /// 保存HelperDoc.xml
        /// </summary>
        [Description("Common/SavHelperDoc")]
        SavHelperDoc,
        /// <summary>
        /// 获取配置常量配置
        /// </summary>
        [Description("AnesQC/GetConstStr")]
        GetConstStr,
        /// <summary>
        /// 获取DataFormat.xml
        /// </summary>
        [Description("DataSync/GetDataFormatDict")]
        GetDataFormatDict,
        /// <summary>
        /// 保存DataFormat.xml
        /// </summary>
        [Description("DataSync/SaveDataFormatDict")]
        SaveDataFormatDict,
        /// <summary>
        /// 获取数据库连接类型
        /// </summary>
        [Description("Common/GetDbType")]
        GetDbType,
        /// <summary>
        /// 获取报表配置信息
        /// </summary>
        [Description("DataSync/GetReportData")]
        GetReportData,

        /// <summary>
        /// 获取报表导出模板
        /// </summary>
        [Description("DataSync/GetExcelExportModel")]
        GetExcelExportModel,

        /// <summary>
        /// 获取Excel文件报表
        /// </summary>
        [Description("DataSync/GetReportDataForExcel")]
        GetReportDataForExcel,
        #endregion

        #region 同步数据
        [Description("DataSync/GetVAnesInfoForSync")]
        GetVAnesInfoForSync,
        /// <summary>
        /// 获取同步配置
        /// </summary>
        [Description("DataSync/GetSyncSqlDict")]
        GetSyncSqlDict,
        /// <summary>
        /// 保存同步配置
        /// </summary>
        [Description("DataSync/SaveSyncSqlDict")]
        SaveSyncSqlDict,
        /// <summary>
        /// 同步数据
        /// </summary>
        [Description("DataSync/SyncData")]
        SyncData,
        /// <summary>
        /// 获取进度条
        /// </summary>
        [Description("DataSync/SyncDataProcess")]
        SyncDataProcess,
        /// <summary>
        /// 停止同步
        /// </summary>
        [Description("DataSync/StopSyncProcess")]
        StopSyncProcess,
        /// <summary>
        /// 获取同步配置
        /// </summary>
        [Description("DataSync/GetSyncAnesMethod")]
        GetSyncAnesMethod,
        [Description("DataSync/GetAllSyncAnesMethod")]
        GetAllSyncAnesMethod,
        /// <summary>
        /// 保存同步配置
        /// </summary>
        [Description("DataSync/SaveSyncAnesMethod")]
        SaveSyncAnesMethod,

        #endregion

        #region 麻醉相关典
        /// <summary>
        /// 麻醉方法字典
        /// </summary>
        [Description("AnesQC/GetAnaesthesiaDict")]
        AnaesthesiaDict,
        /// <summary>
        /// 麻醉事件字典
        /// </summary>
        [Description("AnesQC/GetAnesEventDict")]
        GetAnesEventDict,
        /// <summary>
        /// 用户字典HISUSERS
        /// </summary>
        [Description("AnesQC/GetHisUserDict")]
        GetHisUserDict,
        /// <summary>
        /// 获取科室字典
        /// </summary>
        [Description("AnesQC/GetDeptDict")]
        GetDeptDict,
        /// <summary>
        /// 质控上报科室对照表
        /// </summary>
        [Description("AnesQC/GetQCDeptDict")]
        GetQCDeptDict,
        /// <summary>
        /// 获取手术间字典
        /// </summary>
        [Description("AnesQC/GetOperatingRoomDic")]
        GetOperatingRoom,
        /// <summary>
        /// 获取XML中ASA分级定义
        /// </summary>
        [Description("Common/GetASADict")]
        GetASADict,
        /// <summary>
        /// 获取XML中手术等级定义
        /// </summary>
        [Description("Common/GetOperScaleDict")]
        GetOperScaleDict,
        /// <summary>
        /// 获取XML中切口等级定义
        /// </summary>
        [Description("Common/GetWoundGradeDict")]
        GetWoundGradeDict,
        /// <summary>
        /// 手术名称字典
        /// </summary>
        [Description("AnesQC/GetOperationName")]
        GetOperationName,
        /// <summary>
        ///获取麻醉InputDict字典
        /// </summary>
        [Description("AnesQC/GetAnesthesiaInputDict")]
        GetAnesthesiaInputDict,
        /// <summary>
        /// 获取XML中麻醉事件类型定义
        /// </summary>
        [Description("Common/GetAnesEventTypeDict")]
        GetAnesEventTypeDict,
        /// <summary>
        /// 获取XML中镇痛方式定义
        /// </summary>
        [Description("Common/GetPumpDict")]
        GetPumpDict,
        /// <summary>
        /// 获取XML中手术取消类型定义
        /// </summary>
        [Description("Common/GetOperCancelDict")]
        GetOperCancelDict,
        #endregion

        #region 快速查询
        /// <summary>
        /// 快速查询，根据配置脚本文件中的节点，查找到SQL，并赋值给筛选条件，查询并返回DataTable。
        /// </summary>
        /// <example>
        /// var queryParams = new QueryParams()
        /// {
        ///     SqlKey = "sql.key",
        ///     QueryDefines = new List<QueryDefine>()
        /// };
        /// DataTable result = EasyQuery(queryParams);
        /// </example>
        [Description("Common/EasyQuery")]
        EasyQuery,
        #endregion


        #region 快速查询
        /// <summary>
        /// 快速查询，根据配置脚本SQL语句，并赋值给筛选条件，查询并返回DataTable。
        /// </summary>
        /// <example>
        /// var queryParams = new QueryParams()
        /// {
        ///     SqlKey = "sql语句",
        ///     QueryDefines = new List<QueryDefine>()
        /// };
        /// DataTable result = EasyQuery(queryParams);
        /// </example>
        [Description("Common/EasyQueryBySQL")]
        EasyQueryBySQL,

        [Description("Common/EasyQueryBySQLToFieldName")]
        EasyQueryBySQLToFieldName,
        #endregion


        #region 麻醉七项
        /// <summary>
        /// 手术麻醉综合信息查询
        /// </summary>
        [Description("AnesQC/GetOperAnesInfoQuery")]
        GetOperAnesInfoQuery,
        /// <summary>
        /// 取消类手术查询
        /// </summary>
        [Description("AnesQC/GeCancelOperQuery")]
        GeCancelOperQuery,
        /// <summary>
        /// 取消类手术查询4.0一台手术多台麻醉
        /// </summary>
        [Description("AnesQC/GeCancelOperQueryFor4")]
        GeCancelOperQueryFor4,
        /// <summary>
        /// 取消类手术查询4.0一台手术一台麻醉
        /// </summary>
        [Description("AnesQC/GeCancelOperQueryFor4OneOnOne")]
        GeCancelOperQueryFor4OneOnOne,
        /// <summary>
        /// 术后镇痛手术查询
        /// </summary>
        [Description("AnesQC/GetAfterOperPumpQuery")]
        GetAfterOperPumpQuery,
        /// <summary>
        /// 入PACU手术查询
        /// </summary>
        [Description("AnesQC/GePacuOperQuery")]
        GePacuOperQuery,
        /// <summary>
        /// ASA分组统计
        /// </summary>
        [Description("AnesQC/EasyQueryForAsa")]
        EasyQueryForAsa,
        #endregion

        #region 麻醉--护理统计，手术报表
        /// <summary>
        /// 手术综合信息查询
        /// </summary>
        [Description("AnesQC/GetOperAnesInfoForOper")]
        GetOperAnesInfoForOper,
        /// <summary>
        /// 手术综合信息查询
        /// </summary>
        [Description("AnesQC/GetOperAnesInfoForOperOneOnOne")]
        GetOperAnesInfoForOperOneOnOne,
        /// <summary>
        /// 每天第一台手术查询
        /// </summary>
        [Description("AnesQC/GetFirstOperation")]
        GetFirstOperation,
        /// <summary>
        /// 重返手术查询
        /// </summary>
        [Description("AnesQC/GetReturnOperation")]
        GetReturnOperation,
        /// <summary>
        /// 术中用血查询
        /// </summary>
        [Description("AnesQC/GetOperationBlood")]
        GetOperationBlood,
        /// <summary>
        /// 手术日报表统计
        /// </summary>
        [Description("AnesQC/GetOperationReport")]
        GetOperationReport,
        /// <summary>
        /// 手术日报表统计 1台麻醉对应1台手术
        /// </summary>
        [Description("AnesQC/GetOperationReportOneOnOne")]
        GetOperationReportOneOnOne,
        /// <summary>
        /// 临床科室手术月报
        /// </summary>
        [Description("AnesQC/GetOperMonthly")]
        GetOperMonthly,
        /// <summary>
        /// 临床科室手术月报 1台麻醉对应1台手术
        /// </summary>
        [Description("AnesQC/GetOperMonthlyOneOnOne")]
        GetOperMonthlyOneOnOne,
        #endregion

        #region ICU 质控指标
        /// <summary>
        /// ICU收治患者总数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetICUPatient")]
        ICU_QC_GetICUPatient,

        /// <summary>
        /// ICU收治患者总床日数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetICUPatientsBedDay")]
        ICU_QC_GetICUPatientsBedDay,

        /// <summary>
        /// 医院收治患者总数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetHospitalReceivePatient")]
        ICU_QC_GetHospitalReceivePatient,

        /// <summary>
        /// 医院收治患者总床日数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetHospitalPatientsBedDay")]
        ICU_QC_GetHospitalPatientsBedDay,

        /// <summary>
        /// （APACHEⅡ评分）≥15分患者收治率（入ICU24小时内）
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetICU24ApacheIIMore15")]
        ICU_QC_GetICU24ApacheIIMore15,

        /// <summary>
        /// ICU感染性休克并全部完成3h bundle的患者数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetComplete3hCount")]
        ICU_QC_GetComplete3hCount,

        /// <summary>
        /// ICU感染性休克3h bundle的患者数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetAll3hCount")]
        ICU_QC_GetAll3hCount,

        /// <summary>
        /// ICU感染性休克并全部完成6h bundle的患者数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetComplete6hCount")]
        ICU_QC_GetComplete6hCount,

        /// <summary>
        /// ICU感染性休克6h bundle的患者数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetAll6hCount")]
        ICU_QC_GetAll6hCount,

        /// <summary>
        /// 使用抗菌药物前病原学检验标本送检病例数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetSubmitForCensorshipCount")]
        ICU_QC_GetSubmitForCensorshipCount,

        /// <summary>
        /// 使用抗菌药物治疗病例总数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetUseAntibacterialDrugCount")]
        ICU_QC_GetUseAntibacterialDrugCount,

        /// <summary>
        /// 进行深静脉血栓（DVT）预防的ICU患者数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetUseDVTCount")]
        ICU_QC_GetUseDVTCount,

        /// <summary>
        /// ICU收治患者预计病死率总和
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetICUEstimateDeathRateSum")]
        ICU_QC_GetICUEstimateDeathRateSum,

        /// <summary>
        /// ICU实际死亡人数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetICUDeathCount")]
        ICU_QC_GetICUDeathCount,

        /// <summary>
        /// ICU实际病死率
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetICUDeathRate")]
        ICU_QC_GetICUDeathRate,

        /// <summary>
        /// ICU患者预计病死率
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetICUEstimateDeathRate")]
        ICU_QC_GetICUEstimateDeathRate,

        /// <summary>
        /// 非计划气管插管拔管例数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetUnplannedTracheaCount")]
        ICU_QC_GetUnplannedTracheaCount,

        /// <summary>
        /// ICU患者气管插管拔管总数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetTracheaCount")]
        ICU_QC_GetTracheaCount,

        /// <summary>
        /// 气管插管计划拔管后48h内再插管例数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetIn48HoursIntubationCount")]
        ICU_QC_GetIn48HoursIntubationCount,

        /// <summary>
        /// 非计划转入ICU患者数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetUnplannedInIcuCount")]
        ICU_QC_GetUnplannedInIcuCount,

        /// <summary>
        /// 转入ICU患者总数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetInICUPatientCount")]
        ICU_QC_GetInICUPatientCount,

        /// <summary>
        /// 转出ICU后48h内重返ICU的患者数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetReturn48HourInIcuCount")]
        ICU_QC_GetReturn48HourInIcuCount,

        /// <summary>
        /// 转出ICU患者总数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetOutICUPatientCount")]
        ICU_QC_GetOutICUPatientCount,

        /// <summary>
        /// 呼吸机相关肺炎（VAP）感染例数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetIsVapCount")]
        ICU_QC_GetIsVapCount,

        /// <summary>
        /// ICU患者有创机械通气总天数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetVAPDay")]
        ICU_QC_GetVAPDay,

        /// <summary>
        /// 血管内导管相关血流感染（CRBSI）例数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetIsCrbsiCount")]
        ICU_QC_GetIsCrbsiCount,

        /// <summary>
        /// ICU患者血管内导管留置总天数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetCRBSIDay")]
        ICU_QC_GetCRBSIDay,

        /// <summary>
        /// 导尿管相关泌尿系感染（CAUTI）例数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetIsCautiCount")]
        ICU_QC_GetIsCautiCount,

        /// <summary>
        /// ICU患者导尿管留置总天数
        /// 参数: DateTime startTime, DateTime endTime, string wardCode
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetCAUTIDay")]
        ICU_QC_GetCAUTIDay,

        /// <summary>
        /// ICU获取在科或出科人
        /// 参数:动态参数
        /// 返回：ApiResult《IcuQCDataEntity》
        /// </summary>
        [Description("IcuQC/GetInOrOutPat")]
        ICU_QC_GetInOrOutPat,

        /// <summary>
        /// 根据患者获取质控维护信息
        /// 参数:动态参数
        /// 返回：ApiResult《ICUSelfAssessment》
        /// </summary>
        [Description("IcuQC/GetIcuSelfAssessmentByPatID")]
        ICU_QC_GetIcuSelfAssessmentByPatID,

        /// <summary>
        /// 插入患者质控维护信息
        /// 参数:动态参数
        /// 返回：ApiResult《int》
        /// </summary>
        [Description("IcuQC/InsertSelfAssessmentByPatID")]
        ICU_QC_InsertSelfAssessmentByPatID,

        /// <summary>
        /// 更新患者质控维护信息
        /// 参数:动态参数
        /// 返回：ApiResult《int》
        /// </summary>
        [Description("IcuQC/UpdateSelfAssessmentByPatID")]
        ICU_QC_UpdateSelfAssessmentByPatID,
        #endregion

        #region 等级评审
        /// <summary>
        /// 三甲评审-麻醉总例数
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetAnesCaseNum")]
        AnesCaseNum,
        /// <summary>
        /// 三甲评审-麻醉总例数明细
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetAnesCaseNumDetail")]
        AnesCaseNumDetail,
        /// <summary>
        /// 三甲评审-实施镇痛治疗例数
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetPumpPain")]
        PumpPain,
        /// <summary>
        /// 三甲评审-实施心肺复苏治疗例数
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetCardioRescue")]
        CardioRescue,
        /// <summary>
        /// 三甲评审-麻醉复苏（steward苏醒评分）管理例数
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetAnesPACU")]
        AnesPACU,
        /// <summary>
        /// 三甲评审-麻醉非预期的相关事件例数
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetNotExpectedEvents")]
        NotExpectedEvents,
        /// <summary>
        /// 三甲评审-麻醉分级（ASA病情分级）管理例数
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetAnesGradeASAManage")]
        AnesGradeASAManage,
        /// <summary>
        /// 三甲评审-六项指标合并的综合报表
        /// params: DateTime startTime, DateTime endTime, string wardCode, int dateType
        /// </summary>
        [Description("AnesQC/GetAnesAAAQC")]
        AnesAAAQC,
        #endregion

        #region  麻醉质控17项指标

        /// <summary>
        ///麻醉开始后手术开始前手术取消的数
        /// CANCELED_TYPE字段
        /// </summary>
        [Description("AnesQC/GetAnesQCCanceled")]
        GetAnesQCCanceled,
        /// <summary>
        /// 入PACU第一次测量体温低于35.5℃
        /// PACU_TEMPERATURE字段
        /// </summary>
        [Description("AnesQC/GetAnesQCPacuTemperaure")]
        GetAnesQCPacuTemperaure,
        /// <summary>
        /// 转入ICU患者总数
        /// IN_ICU字段
        /// </summary>
        [Description("AnesQC/GetAnesQCInICU")]
        GetAnesQCInICU,
        /// <summary>
        /// 患者术后气管插管拔除后6小时内，非计划再次行气管插管术
        /// TRACHEA_6H字段
        /// </summary>
        [Description("AnesQC/GetAnesQCTrachea6H")]
        GetAnesQCTrachea6H,
        /// <summary>
        /// 术后气管插管拔除患者总数
        /// TRACHEA_REMOVE字段
        /// </summary>
        [Description("AnesQC/GetAnesQCTracheaRMove")]
        GetAnesQCTracheaRMove,
        /// <summary>
        /// 麻醉开始后24小时内死亡患者数（死亡原因）
        /// ANES_START_24H_DEATH字段
        /// </summary>
        [Description("AnesQC/GetAnesQCStart24HDeath")]
        GetAnesQCStart24HDeath,
        /// <summary>
        /// 麻醉开始后24小时内心跳骤停患者（死亡原因）
        /// ANES_START_24H_STOP字段
        /// </summary>
        [Description("AnesQC/GetAnesQCStart24HStop")]
        GetAnesQCStart24HStop,
        /// <summary>
        /// 麻醉期间严重过敏反应发生例数
        /// ANES_ANAPHYLAXIS字段
        /// </summary>
        [Description("AnesQC/GetAnesQCAnaphylaxis")]
        GetAnesQCAnaphylaxis,
        /// <summary>
        /// 椎管内麻醉后严重神经并发症发生例数
        /// SPINAL_ANES_COMP字段
        /// </summary>
        [Description("AnesQC/GetAnesQCSpinalComp")]
        GetAnesQCSpinalComp,
        /// <summary>
        /// 椎管内麻醉总例次数
        /// SPINAL_ANES字段
        /// </summary>
        [Description("AnesQC/GetAnesQCSpinal")]
        GetAnesQCSpinal,
        /// <summary>
        /// 中心静脉穿刺严重并发症发生例数
        /// CENTRAL_VENOUS字段
        /// </summary>
        [Description("AnesQC/GetAnesQCCentralVenouns")]
        GetAnesQCCentralVenouns,
        /// <summary>
        /// 全麻气管插管拔管后声音嘶哑发生例数
        /// TRACHEA_HOARSE字段
        /// </summary>
        [Description("AnesQC/GetAnesQCTracheaHoarse")]
        GetAnesQCTracheaHoarse,
        /// <summary>
        /// 全麻气管插管总例数
        /// GEN_ANES_TRACHEA字段
        /// </summary>
        [Description("AnesQC/GetAnesQCGenTrachea")]
        GetAnesQCGenTrachea,
        /// <summary>
        /// 麻醉后新发昏迷发生例数
        /// AFTER_ANES_COMA字段
        /// </summary>
        [Description("AnesQC/GetAnesQCAfterComa")]
        GetAnesQCAfterComa,
        /// <summary>
        /// 获取急诊非择期EMERGENCY_INDICATOR=1
        /// </summary>
        [Description("AnesQC/GetAnesQCEmergencyInd")]
        GetAnesQCEmergencyInd,
        /// <summary>
        /// 入PACU超过3小时的患者
        /// </summary>
        [Description("AnesQC/GetAnesQCINPACU3H")]
        GetAnesQCINPACU3H,
        /// <summary>
        /// 在开始麻醉诱导前并无术后转入ICU的计划，而术中或术后决定转入ICU 
        /// NO_PLAN_IN_ICU=1
        /// </summary>
        [Description("AnesQC/GetAnesQCNoPlanInIcu")]
        GetAnesQCNoPlanInIcu,
        /// <summary>
        /// 麻醉方式ANESTHESIA_METHOD
        /// </summary>
        [Description("AnesQC/GetAnesQCAnesthesiaMerhod")]
        GetAnesQCAnesthesiaMerhod,
        /// <summary>
        /// 根据患者获取麻醉质控维护信息
        /// 参数:动态参数 string:PATIENT_ID,decimal:VISIT_ID,decimal:OPER_ID
        /// 返回：ApiResult《AnesthesiaInputData》
        /// </summary>
        [Description("AnesQC/GetAnesInputDataByPatID")]
        Anes_QC_GetAnesInputDataByPatID,
        /// <summary>
        /// 插入患者麻醉质控维护信息
        /// 参数:动态参数（按列名来）
        /// 返回：ApiResult《int》
        /// </summary>
        [Description("AnesQC/InsertAnesInputDataByPatID")]
        Anes_QC_InsertAnesInputDataByPatID,
        /// <summary>
        /// 更新患者麻醉质控维护信息
        /// 参数:动态参数（按列名来）
        /// 返回：ApiResult《int》
        /// </summary>
        [Description("AnesQC/UpdateAnesInputDataByPatID")]
        Anes_QC_UpdateAnesInputDataByPatID,
        /// <summary>
        /// 麻醉ASA分级
        /// </summary>
        [Description("AnesQC/GetAnesQCAnesASA")]
        GetAnesQCAnesASA,
        /// <summary>
        ///麻醉事件输血
        /// </summary>
        [Description("AnesQC/GetAnesEventForBlood")]
        GetAnesEventForBlood,
        /// <summary>
        /// 麻醉事件质控自体血
        /// </summary>
        [Description("AnesQC/GetAnesEventForSelfBlood")]
        GetAnesEventForSelfBlood,
        /// <summary>
        /// 麻醉事件质控中心静脉穿刺
        /// </summary>
        [Description("AnesQC/GetAnesEventForCuanCi")]
        GetAnesEventForCuanCi,
        /// <summary>
        /// 获取手术类型
        /// </summary>
        [Description("AnesQC/GetOperEindicator")]
        GetOperEindicator,

        #endregion

        #region 登录和权限
        /// <summary>
        /// 获取XML中手术取消类型定义
        /// </summary>
        [Description("Common/GetUserByNameAndPwd")]
        GetUserByNameAndPwd,
        /// <summary>
        /// 根据用户名获取权限列表
        /// </summary>
        [Description("Common/GetActionByLoginName")]
        GetActionByLoginName,
        #endregion

        #region 医患协同大屏
        #region 大屏配置相关
        /// <summary>
        /// 大屏字典表
        /// </summary>
        //获取
        [Description("ScreenConfig/GetScreenDict")]
        GetScreenDict,
        //更新
        [Description("ScreenConfig/UpdateScreenDict")]
        UpdateScreenDict,
        //插入
        [Description("ScreenConfig/InsertScreenDict")]
        InsertScreenDict,
        //删除
        [Description("ScreenConfig/DeleteScreenDict")]
        DeleteScreenDict,
        /// <summary>
        /// 大屏配置表
        /// </summary>
        //获取
        [Description("ScreenConfig/GetScreenConfig")]
        GetScreenConfig,
        //插入
        [Description("ScreenConfig/InsertScreenNormalConfig")]
        InsertScreenNormalConfig,
        //更新
        [Description("ScreenConfig/UpdateScreenNormalConfig")]
        UpdateScreenNormalConfig,

        /// <summary>
        /// 显示内容配置
        /// </summary>
        //列出全部字段的对照字典
        [Description("ScreenConfig/GetAllFieldList")]
        GetAllFields,
        //列出视图的所有列
        [Description("ScreenConfig/GetViewColumnList")]
        GetViewColumnList,
        //获取已分配的字段列表
        [Description("ScreenConfig/GetScreenFieldsData")]
        GetScreenFieldsData,
        //插入
        [Description("ScreenConfig/InsertScreenFields")]
        InsertScreenFields,
        //删除
        [Description("ScreenConfig/DeleteScreenFields")]
        DeleteScreenFields,
        //修改
        [Description("ScreenConfig/UpdateScreenFields")]
        UpdateScreenFields,

        /// <summary>
        /// 大屏通告信息
        /// </summary>
        //获取大屏通告信息
        [Description("ScreenConfig/GetMsgData")]
        GetMsgData,
        //插入
        [Description("ScreenConfig/InsertScreenMsg")]
        InsertScreenMsg,
        //删除
        [Description("ScreenConfig/DeleteScreenMsg")]
        DeleteScreenMsg,
        //修改
        [Description("ScreenConfig/UpdateScreenMsg")]
        UpdateScreenMsg,
        #endregion

        #region 获取大屏显示数据
        //获取大屏视图数据
        [Description("Screen/GetScreenViewNormal")]
        GetScreenViewNormal,
        //获取大屏静态通告信息
        [Description("Screen/GetValidMsgData")]
        GetValidMsgData,
        //获取大屏播报通告信息
        [Description("Screen/GetNoticeMsgData")]
        GetNoticeMsgData,
        //更新大屏播报通告信息
        [Description("Screen/UpdateNoticeMsgData")]
        UpdateNoticeMsgData,
        #endregion
        #endregion

        #region 通用信息
        //获取今日手术主表信息，排班大屏用
        [Description("ScreenCommon/GetTodayInfo")]
        GetTodayInfo,
        //获取手术间字典表数据
        [Description("ScreenCommon/GetOperRoomDict")]
        GetOperRoomDict,
        //获取手术间字典表数据
        [Description("ScreenCommon/GetAllOperRoomDict")]
        GetAllOperRoomDict,
        #endregion

        #region 主任工作站-当前手术进程大屏
        //获取今日手术主表信息
        [Description("OperProgress/GetTodayOperInfo")]
        GetTodayOperInfo,
        //根据手术间获取今日手术主表信息
        [Description("OperProgress/GetOperInfoByOperRoom")]
        GetOperInfoByOperRoom,
        //获取昨日手术主表信息
        [Description("OperProgress/GetYesterdayOperInfo")]
        GetYesterdayOperInfo,
        //获取昨日入PACU≥2小时信息
        [Description("OperProgress/GetYesterdayPacuOtInfo")]
        GetYesterdayPacuOtInfo,
        //获取明日手术预约信息
        [Description("OperProgress/GetTomorrowSchduleInfo")]
        GetTomorrowSchduleInfo,
        //获取当前正在进行的手术信息
        [Description("OperProgress/GetOperProgressViewData")]
        GetOperProgressViewData,
        //获取当前手术的台次信息
        [Description("OperProgress/GetOperSeqenceInfo")]
        GetOperSeqenceInfo,
        //获取当前手术间的预警信息
        [Description("OperProgress/GetMonitorAlarmInfo")]
        GetMonitorAlarmInfo,
        #endregion

        #region 医务工作站-整体手术进程大屏
        //获取医务站手术进程信息
        [Description("OperProgress/GetTotalProInfo")]
        GetTotalProInfo,
        #endregion

        #region 与统计查询整合的部分

        ///// <summary>
        ///// 转入ICU患者总数
        ///// IN_ICU字段
        ///// </summary>
        //[Description("AnesQC/GetAnesQCInICU")]
        //GetAnesQCInICU,


        #endregion

        #region 院长工作站

        /// <summary>
        /// 麻醉人次变化（近10日）
        /// </summary>
        [Description("DeanScreen/GetOperCountDT")]
        GetOperCountDT,
        /// <summary>
        /// ASA分级分布
        /// </summary>
        [Description("DeanScreen/GetAsa")]
        GetAsa,
        /// <summary>
        /// 手术分级分布
        /// </summary>
        [Description("DeanScreen/GetOperScale")]
        GetOperScale,
        /// <summary>
        /// 手术间开台率
        /// </summary>
        [Description("DeanScreen/GetFirstOperCount")]
        GetFirstOperCount,
        /// <summary>
        /// 总台数
        /// </summary>
        [Description("DeanScreen/GetOperCount")]
        GetOperCount,
        /// <summary>
        /// 麻醉人次科室分布
        /// </summary>
        [Description("DeanScreen/GetDeptAnesCount")]
        GetDeptAnesCount,
        /// <summary>
        /// 麻醉方法分布
        /// </summary>
        [Description("DeanScreen/GetAnesMethods")]
        GetAnesMethods

        #endregion

    }
}
