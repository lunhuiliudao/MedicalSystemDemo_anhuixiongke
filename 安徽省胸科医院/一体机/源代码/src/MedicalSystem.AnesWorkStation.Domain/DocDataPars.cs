/*********************************************************
 * 文件名称(File Name)：      DocDataPars.cs
 * 功能描述(Description)：    文书保存数据类：将所有数据集合到一个类中
 *                            之前的文书保存使用dynamic，对应客户端和服务端的耦合性要求太高
 *                            例如：服务端在响应保存文书方法中，解析主表的名称是:operMaster,
 *                                  那么所有文书中涉及到主表的对象名称都必须是operMaster，要完全一致才能被服务端解析。
 *                                  耦合性太高。。。
 * 数据表(Tables)：		
 * 作者(Author)：             许文龙 
 * 日期(Create Date)：        2018-09-06 10:49:12
 * R1:
 *    修改作者:
 *    修改日期:
 *    修改理由:
 *********************************************************/
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 文书保存数据类：将所有数据集合到一个类中
    /// 之前的文书保存使用dynamic，对应客户端和服务端的耦合性要求太高，使用非常不便
    /// </summary>
    public class DocDataPars
    {
        public MED_OPERATION_MASTER OperMaster { get; set; }
        public MED_OPERATION_MASTER OriginalOperMaster { get; set; }
        public MED_OPERATION_MASTER_EXT OperMasterExt { get; set; }
        public MED_OPERATION_MASTER_EXT OriginalOperMasterExt { get; set; }
        public MED_PAT_MASTER_INDEX PatMasterIndex { get; set; }
        public MED_PAT_MASTER_INDEX OriginalPatMasterIndex { get; set; }
        public MED_PAT_VISIT PatVisit { get; set; }
        public MED_PAT_VISIT OriginalPatVisit { get; set; }
        public MED_PATS_IN_HOSPITAL PatsInHospital { get; set; }
        public MED_PATS_IN_HOSPITAL OriginalPatsInHospital { get; set; }
        public MED_ANESTHESIA_PLAN AnesPlan { get; set; }
        public MED_ANESTHESIA_PLAN OriginalAnesPlan { get; set; }
        public MED_ANESTHESIA_PLAN_EXAM AnesPlanExam { get; set; }
        public MED_ANESTHESIA_PLAN_EXAM OriginalAnesPlanExam { get; set; }
        public MED_ANESTHESIA_PLAN_PMH AnesPlanPmh { get; set; }
        public MED_ANESTHESIA_PLAN_PMH OriginalAnesPlanPmh { get; set; }
        public MED_ANESTHESIA_INPUT_DATA AnesInputData { get; set; }
        public MED_ANESTHESIA_INPUT_DATA OriginalAnesInputData { get; set; }
        public MED_OPERATION_ANALGESIC_MASTER OperAnalgesicMaster { get; set; }
        public MED_OPERATION_ANALGESIC_MASTER OriginalOperAnalgesicMaster { get; set; }
        public MED_SAFETY_CHECKS SafetyChecks { get; set; }
        public MED_SAFETY_CHECKS OriginalSafetyChecks { get; set; }
        public MED_OPER_RISK_ESTIMATE OperRiskEstimate { get; set; }
        public MED_OPER_RISK_ESTIMATE OriginalOperRiskEstimate { get; set; }
        public MED_ANESTHESIA_RECOVER AnesRecover { get; set; }
        public MED_ANESTHESIA_RECOVER OriginalAnesRecover { get; set; }
        public MED_ANESTHESIA_INQUIRY AnesInquiry { get; set; }
        public MED_ANESTHESIA_INQUIRY OriginalAnesInquiry { get; set; }
        public List<MED_PACU_SORCE> PacuSorce { get; set; }
        public List<MED_PACU_SORCE> OriginalPacuSorce { get; set; } 
        public List<MED_CHUFANG_RECORD> ChuFangRecord { get; set; }
        public List<MED_CHUFANG_RECORD> OriginalChuFangRecord { get; set; }
        public List<MED_OPER_ANALGESIC_MEDICINE> OperAnalgesicMedicine { get; set; }
        public List<MED_OPER_ANALGESIC_MEDICINE> OriginalOperAnalgesicMedicine { get; set; }
        public List<MED_OPER_ANALGESIC_TOTAL> OperAnalgesicTotal { get; set; }
        public List<MED_OPER_ANALGESIC_TOTAL> OriginalOperAnalgesicTotal { get; set; }
        public List<MED_OPERATION_EXTENDED> OperExtended { get; set; }
        public List<MED_OPERATION_EXTENDED> OriginalOperExtended { get; set; }
        public List<MED_POSTOPERATIVE_EXTENDED> PostExtended { get; set; }
        public List<MED_POSTOPERATIVE_EXTENDED> OriginalPostExtended { get; set; }
        public List<MED_PREOPERATIVE_EXPANSION> PreExpansion { get; set; }
        public List<MED_PREOPERATIVE_EXPANSION> OriginalPreExpansion { get; set; }
    }
}
