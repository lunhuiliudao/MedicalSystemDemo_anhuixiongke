using MedicalSystem.Anes.Client.Service;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class PermissionProvider
    {

        /// <summary>
        /// 核查病案归档后医疗文书是否可修改
        /// </summary>
        /// <returns></returns>
        public bool CheckDoneDocumentRight()
        {
            if (ExtendApplicationContext.Current.OperationStatus == OperationStatus.Done)
            {
                if (!((CheckRight(PermissionContext.MODIFYDOCUMENTFOREVER) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 根据权限key检查权限
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual PermissionContext.RightType CheckRight(string text)
        {
            PermissionContext.RightType result = PermissionContext.RightType.None;

            //判读是否超级用户
            if (ExtendApplicationContext.Current.LoginUser.isMDSD)
            {
                return PermissionContext.RightType.Browse | PermissionContext.RightType.Modify | PermissionContext.RightType.Import | PermissionContext.RightType.Export;
            }

            //判断是否有浏览
            if (AccessControl.CheckPermission(text) || AccessControl.CheckPermission(text + "_bro"))
            {
                result = PermissionContext.RightType.Browse;
            }

            //判断是否可编辑
            if (AccessControl.CheckPermission(text) || AccessControl.CheckPermission(text + "_mod"))
            {
                result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
            }

            if (!string.IsNullOrEmpty(text))
            {
                switch (text.Trim())
                {
                    case PermissionContext.MODIFYDOCUMENTFOREVER:
                        if (AccessControl.CheckPermission(PermissionContext.MODIFYDOCUMENTFOREVER))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse | PermissionContext.RightType.Import | PermissionContext.RightType.Export;
                        }
                        break;
                    case PermissionContext.MODIFYDOCUMENT:
                        if (AccessControl.CheckPermission(PermissionContext.MODIFYDOCUMENT) && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse | PermissionContext.RightType.Import | PermissionContext.RightType.Export;
                        }
                        else
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case PermissionContext.ANESRECORDOPER:
                        if (AccessControl.CheckPermission(PermissionContext.ANESRECORDOPER) && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case PermissionContext.MonitorDataEdit:
                        if (AccessControl.CheckPermission(PermissionContext.MonitorDataEdit + "_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission(PermissionContext.MonitorDataEdit + "_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case PermissionContext.PublicTempletEdit:
                        if (AccessControl.CheckPermission(PermissionContext.PublicTempletEdit))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case PermissionContext.ModifyPrintedDoc:
                        if (AccessControl.CheckPermission(PermissionContext.ModifyPrintedDoc))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;

                    #region 基本功能
                    case PermissionContext.LockSystem:
                    case "锁定系统":
                        if (AccessControl.CheckPermission("LockSystem_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "字典":
                    case "字典浏览":
                    case "字典维护":
                    case "字典配置":
                        if (AccessControl.CheckPermission("EditDict_mod") || AccessControl.CheckPermission("CPBDict_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("EditDict_bro") || AccessControl.CheckPermission("CPBDict_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "His同步":
                    case "同步His":
                    case "HIS同步":
                    case "同步HIS":
                        if (AccessControl.CheckPermission("SyncHis_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }

                        break;
                    case "查询统计":
                        if (AccessControl.CheckPermission("QueryStatistics_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("QueryStatistics_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "急诊登记":
                        if (AccessControl.CheckPermission("EmergencyRegistration_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉评分":
                        if (AccessControl.CheckPermission("麻醉评分"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("AnesthesiaScore_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("AnesthesiaScore_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "手术概览":
                        if (AccessControl.CheckPermission("OperationRoomPandect_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("OperationRoomPandect_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "模板维护":
                    case "药物模板":
                    case "模板管理":
                        if (AccessControl.CheckPermission("NewModelManager_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("NewModelManager_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "参数配置":
                    case "系统配置":
                    case "配置浏览":
                        if (AccessControl.CheckPermission("ParameterConfig_mod") || AccessControl.CheckPermission("CPBConfig_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("ParameterConfig_bro") || AccessControl.CheckPermission("CPBConfig_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "修改口令":
                    case "口令修改":
                    case "修改密码":
                    case "密码修改":
                        if (AccessControl.CheckPermission("ChangePassword_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "关于":
                        result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse | PermissionContext.RightType.Import | PermissionContext.RightType.Export;
                        break;
                    #endregion

                    #region 术中操作
                    case "监护仪设置":
                    case "监护仪":
                    case "设备采集":
                        if (AccessControl.CheckPermission("SetMonitor_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("SetMonitor_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "手术信息":
                        if (AccessControl.CheckPermission("SurgeryInfo_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("SurgeryInfo_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "术后登记":
                        if (AccessControl.CheckPermission("RegisterAfterOperation_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("RegisterAfterOperation_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "取消手术":
                        if (AccessControl.CheckPermission("CancelOperation_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("CancelOperation_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "病案提交":
                    case "病案归档":
                        if (CheckDoneDocumentRight())
                        {
                            if (AccessControl.CheckPermission("LockPatient_mod"))
                            {
                                result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                            }
                            else if (AccessControl.CheckPermission("LockPatient_bro"))
                            {
                                result = PermissionContext.RightType.Browse;
                            }
                        }
                        break;
                    case "血气分析":
                        if (AccessControl.CheckPermission("BloodGasDataEditor_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("BloodGasDataEditor_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "手术交班":
                    case "麻醉交班":
                    case "护士交班":
                        if (AccessControl.CheckPermission("OperationShift_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("OperationShift_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    #endregion

                    #region 检验类别
                    case "检验信息":
                        if (AccessControl.CheckPermission("CheckTest_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("CheckTest_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "检查结果":
                        if (AccessControl.CheckPermission("CheckResult_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("CheckResult_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "医嘱信息":
                        if (AccessControl.CheckPermission("PrescriptionInfo_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("PrescriptionInfo_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "病历病程":
                        if (AccessControl.CheckPermission("MedicalCourse_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("MedicalCourse_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    #endregion
                    #region 医疗文书
                    case "麻醉记录":
                    case "麻醉记录单":
                    case "麻醉单":
                        if (AccessControl.CheckPermission("AnesthesiaRecord_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("AnesthesiaRecord_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("AnesthesiaRecord_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("AnesthesiaRecord_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "术前访视":
                    case "术前访视单":
                        if (AccessControl.CheckPermission("ViewBeforeOperation_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("ViewBeforeOperation_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("ViewBeforeOperation_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("ViewBeforeOperation_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "安全核查单":
                    case "安全核查表":
                    case "手术安全核查单":
                    case "手术安全核查表":
                        if (AccessControl.CheckPermission("SafetyVerification_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("SafetyVerification_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉计划":
                    case "麻醉计划书":
                        if (AccessControl.CheckPermission("AnesPlan_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("AnesPlan_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "复苏单":
                    case "复苏记录单":
                    case "PACU":
                    case "PACU单":
                    case "PACU记录单":
                        if (AccessControl.CheckPermission("PACURecord_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse | PermissionContext.RightType.Import | PermissionContext.RightType.Export;
                        }
                        break;
                    case "知情同意书":
                    case "同意书":
                    case "麻醉同意书":
                    case "麻醉知情同意书":
                        if (AccessControl.CheckPermission("AnesAgreementDoc_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse | PermissionContext.RightType.Import | PermissionContext.RightType.Export;
                        }
                        break;
                    case "术后随访":
                    case "术后访视":
                    case "术后访视单":
                    case "术后随访单":
                        if (AccessControl.CheckPermission("ViewAfterOperation_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("ViewAfterOperation_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("ViewAfterOperation_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("ViewAfterOperation_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "镇痛观察":
                        if (AccessControl.CheckPermission("AnalgesiaObservation_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "镇痛单":
                    case "镇痛记录":
                    case "镇痛记录单":
                    case "镇痛访视":
                    case "镇痛管理":
                    case "镇痛登记":
                        if (AccessControl.CheckPermission("PainManagement_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("PainManagement_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉总结":
                    case "麻醉总结随访":
                    case "麻醉总结单":
                        if (AccessControl.CheckPermission("AnesthesiaSummary_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("AnesthesiaSummary_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("AnesthesiaSummary_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("AnesthesiaSummary_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "手术清点记录":
                    case "手术清点单":
                    case "器械清点":
                    case "器械辅料":
                    case "器械管理":
                        if (AccessControl.CheckPermission("DressingEquipmentInventory_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("DressingEquipmentInventory_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("DressingEquipmentInventory_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("DressingEquipmentInventory_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "风险评估":
                    case "风险评估单":
                    case "手术风险评估":
                    case "手术风险评估单":
                    case "手术风险评估表":
                        if (AccessControl.CheckPermission("RiskEvaluation_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("RiskEvaluation_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "手术护理":
                    case "手术护理单":
                    case "手术护理记录单":
                    case "护理信息":
                        if (AccessControl.CheckPermission("NursingInfo_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("NursingInfo_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("NursingInfo_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("NursingInfo_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉前小结":
                        if (AccessControl.CheckPermission("SummaryBeforeAnes_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("SummaryBeforeAnes_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("SummaryBeforeAnes_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("SummaryBeforeAnes_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉单反面":
                        if (AccessControl.CheckPermission("麻醉单反面") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉质控指标单":
                        if (AccessControl.CheckPermission("AnesQualityControl_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    #endregion
                    #region 收费相关权限
                    case "手术收费记录":
                        if (AccessControl.CheckPermission("OperationChargeRecord_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("OperationChargeRecord_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("OperationChargeRecord_imp"))
                        {
                            result = result | PermissionContext.RightType.Import | PermissionContext.RightType.Browse;
                        }
                        if (AccessControl.CheckPermission("OperationChargeRecord_exp"))
                        {
                            result = result | PermissionContext.RightType.Export | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉收费":
                        if (AccessControl.CheckPermission("AnesthesiaCharge_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "手术收费":
                        if (AccessControl.CheckPermission("OperationCharge_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "麻醉退费":
                        if (AccessControl.CheckPermission("AnesthesiaRefund_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    case "手术退费":
                        if (AccessControl.CheckPermission("OperationRefund_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        break;
                    #endregion

                    #region 待开发功能权限
                    case "手术进程":
                    case "进程管理":
                        if (AccessControl.CheckPermission("OperationProcess_mod"))
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("OperationProcess_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "家属通告":
                    case "不良事件":
                        result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        break;

                    case "麻醉质控单":
                    case "麻醉质控":
                        if (AccessControl.CheckPermission("SingleAnesthesiaControl_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("SingleAnesthesiaControl_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;

                    case "文书质控":
                        if (AccessControl.CheckPermission("DocumentControl_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("DocumentControl_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "复苏进程":
                        if (AccessControl.CheckPermission("PACUProcess_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("PACUProcess_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    case "PACU进程":
                    case "PACU状态":
                        if (AccessControl.CheckPermission("PACUStatus_mod") && CheckDoneDocumentRight())
                        {
                            result = PermissionContext.RightType.Modify | PermissionContext.RightType.Browse;
                        }
                        else if (AccessControl.CheckPermission("PACUStatus_bro"))
                        {
                            result = PermissionContext.RightType.Browse;
                        }
                        break;
                    #endregion

                    default:
                        break;
                }
            }
            return result;
        }



        /// <summary>
        /// 常用按钮-检查是否有编辑权限
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual bool CheckModifyRight(string text)
        {



            if ((CheckRight(text) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 常用按钮-检查是否有浏览权限
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual bool CheckBrowseRight(string text)
        {
            if ((CheckRight(text) & PermissionContext.RightType.Browse) == PermissionContext.RightType.Browse)
            {
                return true;
            }
            return false;
        }

        // 获取麻醉收费权限 只有该患者的麻醉医生
        public PermissionContext.RightType GetAnesBillRightType(string rightKey)
        {
            if ((CheckRight("所有麻醉收费") & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return PermissionContext.RightType.Modify;
            }

            PermissionContext.RightType rightType = CheckRight(rightKey);
            //判读是否超级用户
            if (ExtendApplicationContext.Current.LoginUser.isMDSD)
            {
                return rightType;
            }
            MED_OPERATION_MASTER operationMasterRow = OperationInfoService.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
            List<MED_OPERATION_SHIFT_RECORD> operationShift = OperationInfoService.GetShiftRecordListByID(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);

            try
            {
                //检查是否为 麻醉医生
                if (operationMasterRow != null)
                {

                    bool find = false;
                    if (!find && !string.IsNullOrEmpty(operationMasterRow.ANES_DOCTOR) && (IsLoginUser(operationMasterRow.ANES_DOCTOR)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.FIRST_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.FIRST_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.SECOND_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.SECOND_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.THIRD_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.THIRD_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.FOURTH_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.FOURTH_ANES_ASSISTANT)))
                    {
                        find = true;
                    }

                    if (!find)
                        return PermissionContext.RightType.Browse;
                }
                else//麻醉主记录为空
                {
                    rightType = PermissionContext.RightType.Browse;
                }

                return rightType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return PermissionContext.RightType.Browse;

        }


        // 获取手术收费权限 只有该患者的护士可以
        public PermissionContext.RightType GetOperBillRightType(string rightKey)
        {
            if ((CheckRight("所有手术收费") & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return PermissionContext.RightType.Modify;
            }

            PermissionContext.RightType rightType = CheckRight(rightKey);
            //判读是否超级用户
            if (ExtendApplicationContext.Current.LoginUser.isMDSD)
            {
                return rightType;
            }


            //获取手术表
            MED_OPERATION_MASTER operationMasterRow = OperationInfoService.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
            List<MED_OPERATION_SHIFT_RECORD> operationShift = OperationInfoService.GetShiftRecordListByID(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);


            try
            {
                //检查是否为 护士
                if (operationMasterRow != null)
                {

                    bool find = false;
                    if (!find && !string.IsNullOrEmpty(operationMasterRow.FIRST_SUPPLY_NURSE) && (IsLoginUser(operationMasterRow.FIRST_SUPPLY_NURSE)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.SECOND_SUPPLY_NURSE) && (IsLoginUser(operationMasterRow.SECOND_SUPPLY_NURSE)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.THIRD_SUPPLY_NURSE) && (IsLoginUser(operationMasterRow.THIRD_SUPPLY_NURSE)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.FIRST_OPER_NURSE) && (IsLoginUser(operationMasterRow.FIRST_OPER_NURSE)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.SECOND_OPER_NURSE) && (IsLoginUser(operationMasterRow.SECOND_OPER_NURSE)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.THIRD_OPER_NURSE) && (IsLoginUser(operationMasterRow.THIRD_OPER_NURSE)))
                    {
                        find = true;
                    }

                    if (!find)
                        rightType = PermissionContext.RightType.Browse;
                }
                else//麻醉主记录为空
                {
                    rightType = PermissionContext.RightType.Browse;
                }

                return rightType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return PermissionContext.RightType.Browse; ;

        }

        /// <summary>
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        private PermissionContext.RightType GetOperatorDocRightType(string rightKey, string someCondition)
        {
            return GetOperatorDocRightType(rightKey);
        }
        /// <summary>
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        private PermissionContext.RightType GetOperatorDocRightType(string rightKey)
        {
            if ((CheckRight(PermissionContext.MODIFYDOCUMENTFOREVER) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return PermissionContext.RightType.Modify;
            }
            if ((CheckRight(PermissionContext.MODIFYDOCUMENT) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return PermissionContext.RightType.Modify;
            }
            PermissionContext.RightType rightType = CheckRight(rightKey);
            //判读是否超级用户
            if (ExtendApplicationContext.Current.LoginUser.isMDSD)
            {
                return rightType;
            }


            //获取手术表
            MED_OPERATION_MASTER operationMasterRow = OperationInfoService.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
            List<MED_OPERATION_SHIFT_RECORD> operationShift = OperationInfoService.GetShiftRecordListByID(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);

            try
            {
                //检查是否为 麻醉医生、手术医生
                if (operationMasterRow != null)
                {

                    bool find = false;
                    if (!find && !string.IsNullOrEmpty(operationMasterRow.ANES_DOCTOR) && (IsLoginUser(operationMasterRow.ANES_DOCTOR)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.FIRST_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.FIRST_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.SECOND_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.SECOND_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.THIRD_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.THIRD_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    else if (!find && !string.IsNullOrEmpty(operationMasterRow.FOURTH_ANES_ASSISTANT) && (IsLoginUser(operationMasterRow.FOURTH_ANES_ASSISTANT)))
                    {
                        find = true;
                    }
                    if (!find)
                    {
                        //检查是否为 交班医生
                        if (operationShift != null && operationShift.Count > 0)
                        {
                            foreach (MED_OPERATION_SHIFT_RECORD row in operationShift)
                            {
                                if (!find && !string.IsNullOrEmpty(row.PERSON) && (IsLoginUser(row.PERSON)))
                                {
                                    find = true;
                                }
                            }
                        }
                        if (!find)
                        {
                            rightType = PermissionContext.RightType.Browse;
                        }
                    }

                }
                else//麻醉主记录为空
                {
                    rightType = PermissionContext.RightType.Browse;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rightType;
        }

        /// <summary>
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        public virtual PermissionContext.RightType GetDocRightTypeForOperator(string rightKey)
        {
            return GetOperatorDocRightType(rightKey);
        }
        /// <summary>
        /// 获取文书操作员权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有编辑权限，否则浏览
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        public virtual PermissionContext.RightType GetDocRightTypeForOperator(string rightKey, string checkCondition)
        {
            return GetOperatorDocRightType(rightKey, checkCondition);
        }
        /// <summary>
        /// 判断该用户是否在用户表中
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserInHisUser(string user)
        {
            List<MED_HIS_USERS> hisUserDict = ExtendApplicationContext.Current.CommDict.HisUsersDict.Where(x => x.USER_NAME == user || x.USER_JOB_ID == user).ToList();

            if (hisUserDict.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断该用户是否为登录用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsLoginUser(string user)
        {
            user = user.ToUpper().Trim();
            if (user.Contains(ExtendApplicationContext.Current.LoginUser.LOGIN_NAME) || user.Contains(ExtendApplicationContext.Current.LoginUser.USER_JOB_ID) || user.Contains(ExtendApplicationContext.Current.LoginUser.USER_NAME))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取文书操作员是否有修改权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有返回true，否则false
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        public virtual bool CheckModifyRightForOperator(string text)
        {
            if ((GetDocRightTypeForOperator(text) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取文书操作员是否有修改权限，如果该文书的麻醉医生、手术医生、交班医生是自己的话，则有返回true，否则false
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        public virtual bool CheckModifyRightForOperator(string text, string checkCondition)
        {
            if ((GetDocRightTypeForOperator(text, checkCondition) & PermissionContext.RightType.Modify) == PermissionContext.RightType.Modify)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取文书操作员是否有浏览权限
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        public virtual bool CheckBrowseRightForOperator(string text)
        {
            if ((GetDocRightTypeForOperator(text) & PermissionContext.RightType.Browse) == PermissionContext.RightType.Browse)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取是否有--修改已打印的医疗文书--的权限
        /// </summary>
        /// <param name="rightKey"></param>
        /// <returns></returns>
        public virtual bool CheckModifyPrintedDoc()
        {
            return CheckModifyRight(PermissionContext.ModifyPrintedDoc);
        }


    }
}
