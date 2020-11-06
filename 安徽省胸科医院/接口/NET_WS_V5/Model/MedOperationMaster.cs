
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:07:24
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    ///MedOperationMaster
    /// </summary>
    [Serializable]
    public class MedOperationMaster
    {
        ///<summary>
        ///
        ///</summary>
        public string PatientId
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>
        public decimal VisitId
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>
        public decimal OperId
        {
            get;
            set;
        }

        ///<summary>
        ///院区HOSP_BRANCH
        ///</summary>
        public string HospBranch
        {
            get;
            set;
        }


        /// <summary>
        /// 病人所在病区
        /// </summary>
        public string WardCode
        {
            get;
            set;
        }


        /// <summary>
        /// 病人所在科室
        /// </summary>
        public string DeptCode
        {
            get;
            set;
        }


        /// <summary>
        /// OPERATING_DEPT实施手术的科室，即手术医生所在科室.OPER_DEPT_CODE
        /// </summary>
        public string OperDeptCode
        {
            get;
            set;
        }


        /// <summary>
        /// 手术室OPER_ROOM
        /// </summary>
        public string OperRoom
        {
            get;
            set;
        }


        /// <summary>
        /// 手术间OPER_ROOM_NO
        /// </summary>
        public string OperRoomNo
        {
            get;
            set;
        }

        /// <summary>
        /// 台次SEQUENCE
        /// </summary>
        public decimal Sequence
        {
            get;
            set;
        }

        /// <summary>
        /// 手术类型代码表。1 一般手术 ，2 急抢救手术 ，3 术中急抢救
        /// </summary>
        public string OperClass
        {
            get;
            set;
        }


        /// <summary>
        /// 术前主要诊断DIAG_BEFORE_OPERATION
        /// </summary>
        public string DiagBeforeOperation
        {
            get;
            set;
        }


        /// <summary>
        /// 病情说明	PATIENT_CONDITION
        /// </summary>
        public string PatientCondition
        {
            get;
            set;
        }

        /// <summary>
        /// Asa等级代码表，I级、ii级、iii级、iv级、Ⅴ级、Ⅵ级
        /// </summary>
        public string AsaGrade
        {
            get;
            set;
        }

        /// <summary>
        /// 第四手术助手
        /// </summary>
        public string FourthOperAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 第三手术助手
        /// </summary>
        public string ThirdOperAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 第二手术助手SECOND_OPER_ASSISTANT
        /// </summary>
        public string SecondOperAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 第一手术助手	FIRST_OPER_ASSISTANT
        /// </summary>
        public string FirstOperAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 手术医师姓名SURGEON
        /// </summary>
        public string Surgeon
        {
            get;
            set;
        }

        /// <summary>
        /// 放射标志。1 正常 ，2 感染RADIATE_IND
        /// </summary>
        public Nullable<decimal> RadiateInd
        {
            get;
            set;
        }

        /// <summary>
        /// 感染标志。1 正常 ，2 感染INFECTED_IND
        /// </summary>
        public Nullable<decimal> InfectedInd
        {
            get;
            set;
        }

        /// <summary>
        /// ISOLATION_INDICATOR指手术是否需要隔离。1-正常 2-隔离ISOLATION_IND
        /// </summary>
        public Nullable<decimal> IsolationInd
        {
            get;
            set;
        }

        /// <summary>
        /// 手术来源0 门诊，1 住院，2 急诊OPER_SOURCE
        /// </summary>
        public Nullable<decimal> OperSource
        {
            get;
            set;
        }

        /// <summary>
        /// EMERGENCY_ INDICATOR急诊标志，0-择期 1-急诊,2 门诊日间EMERGENCY_IND
        /// </summary>
        public Nullable<decimal> EmergencyInd
        {
            get;
            set;
        }


        /// <summary>
        /// 术后主要诊断
        /// </summary>
        public string DiagAfterOperation
        {
            get;
            set;
        }

        /// <summary>
        /// 切口数量
        /// </summary>
        public decimal WoundNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 切口类型代码表，I类、ii类、iii类
        /// </summary>
        public string WoundType
        {
            get;
            set;
        }

        /// <summary>
        /// OPERATION_SCALE指一次手术的综合等级。手术等级代码表，I级、ii级、iii级、iv
        /// </summary>
        public string OperScale
        {
            get;
            set;
        }


        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string AnesMethod
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉医师	
        /// </summary>
        public string AnesDoctor
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉助手1
        /// </summary>
        public string FirstAnesAssistant
        {
            get;
            set;
        }


        /// <summary>
        /// 麻醉助手2
        /// </summary>
        public string SecondAnesAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉助手3
        /// </summary>
        public string ThirdAnesAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉助手4
        /// </summary>
        public string FourthAnesAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 第一麻醉护士
        /// </summary>
        public string FirstAnesNurse
        {
            get;
            set;
        }

        /// <summary>
        /// 第二麻醉护士
        /// </summary>
        public string SecondAnesNurse
        {
            get;
            set;
        }

        /// <summary>
        ///第三醉护士
        /// </summary>
        public string ThirdAnesNurse
        {
            get;
            set;
        }


        /// <summary>
        /// 灌注医生	
        /// </summary>
        public string CpbDoctor
        {
            get;
            set;
        }

        /// <summary>
        /// 灌注医生助手1
        /// </summary>
        public string FirstCpbAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 灌注医生助手2	
        /// </summary>
        public string SecondCpbAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 灌注医生助手3	
        /// </summary>
        public string ThirdCpbAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 灌注医生助手4	
        /// </summary>
        public string FourthCpbAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// 第一台上护士
        /// </summary>
        public string FirstOperNurse
        {
            get;
            set;
        }

        /// <summary>
        /// SECOND_OPER_NURSE	第二台上护士	
        /// </summary>
        public string SecondOperNurse
        {
            get;
            set;
        }

        /// <summary>
        /// 第三台上护士
        /// </summary>
        public string ThirdOperNurse
        {
            get;
            set;
        }

        /// <summary>
        /// 第四台上护士
        /// </summary>
        public string FourthOperNurse
        {
            get;
            set;
        }

        /// <summary>
        /// 第一供应护士
        /// </summary>
        public string FirstSupplyNurse
        {
            get;
            set;
        }

        /// <summary>
        /// 第二供应护士
        /// </summary>
        public string SecondSupplyNurse
        {
            get;
            set;
        }


        /// <summary>
        /// 第三供应护士
        /// </summary>
        public string ThirdSupplyNurse
        {
            get;
            set;
        }

        /// <summary>
        ///  第四供应护士
        /// </summary>
        public string FourthSupplyNurse
        {
            get;
            set;
        }

        /// <summary>
        /// pacu助手1
        /// </summary>
        public string PacuDoctor
        {
            get;
            set;
        }

        /// <summary>
        /// pacu助手2
        /// </summary>
        public string FirstPacuAssistant
        {
            get;
            set;
        }
        public string SecondPacuAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// Pacu护士1	
        /// </summary>
        public string FirstPacuNurse
        {
            get;
            set;
        }

        /// <summary>
        /// Pacu护士2
        /// </summary>
        public string SecondPacuNurse
        {
            get;
            set;
        }

        /// <summary>
        /// 手术申请日期
        /// </summary>
        public Nullable<DateTime> ReqDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 手术安排日期
        /// </summary>
        public Nullable<DateTime> ScheduledDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 进入手术室日期及时间
        /// </summary>
        public Nullable<DateTime> InDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 离开手术室日期及时间
        /// </summary>
        public Nullable<DateTime> OutDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        public Nullable<DateTime> AnesStartTime
        {
            get;
            set;
        }


        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public Nullable<DateTime> AnesEndTime
        {
            get;
            set;
        }

        /// <summary>
        /// 手术开始日期及时间START_DATE_TIME
        /// </summary>
        public Nullable<DateTime> StartDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 手术结束日期及时间END_DATE_TIME
        /// </summary>
        public Nullable<DateTime> EndDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 进入pacu日期及时间IN_PACU_DATE_TIME
        /// </summary>
        public Nullable<DateTime> InPacuDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 离开pacu日期及时间OUT_PACU_DATE_TIME
        /// </summary>
        public Nullable<DateTime> OutPacuDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 手术状态OPER_STATUS_CODE
        /// </summary>
        public string OperStatusCode
        {
            get;
            set;
        }

        /// <summary>
        ///体位OPER_POSITION
        /// </summary>
        public string OperPosition
        {
            get;
            set;
        }

        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo
        {
            get;
            set;
        }

        /// <summary>
        /// 手术名称OPERATION_NAME
        /// </summary>
        public string OperationName
        {
            get;
            set;
        }

        /// <summary>
        /// 对应病人去向代码表，原科室、icu等等，Patient_whereabouts PAT_WHEREABORTS
        /// </summary>
        public string PatWhereaborts
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉满意程度1-满意 2-不全满意 3-改麻醉SATISFACTION_DEGREE
        /// </summary>
        public decimal SatisfactionDegree
        {
            get;
            set;
        }

        /// <summary>
        /// 手术过程顺利标志1-顺利 0-不顺利SMOOTH_INDICATOR
        /// </summary>
        public Nullable<decimal> SmoothIndicator
        {
            get;
            set;
        }

        /// <summary>
        /// 录入者	ENTERED_BY
        /// </summary>
        public string EnteredBy
        {
            get;
            set;
        }

        /// <summary>
        /// 医嘱提交ORDER_TRANSFER
        /// </summary>
        public Nullable<decimal> OrderTransfer
        {
            get;
            set;
        }

        /// <summary>
        /// 费用提交CHARGE_TRANSFER
        /// </summary>
        public Nullable<decimal> ChargeTransfer
        {
            get;
            set;
        }

        /// <summary>
        /// 完成标识 1-手术登记完成，完成后不允许再修改END_INDICATOR
        /// </summary>
        public Nullable<decimal> EndIndicator
        {
            get;
            set;
        }
        public string Memo
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉单编号ANESTHESIA_ID
        /// </summary> 
        public string AnesthesiaId
        {
            get;
            set;
        }
        public string HisPatientId
        {
            get;
            set;
        }
        public string HisVisitId
        {
            get;
            set;
        }
        public string HisScheduleId
        {
            get;
            set;
        }
        /// <summary>
        /// His申请状态HIS_OPER_STATUS
        /// </summary>
        public string HisOperStatus
        {
            get;
            set;
        }
        public string Reserved01
        {
            get;
            set;
        }
        public string Reserved02
        {
            get;
            set;
        }

        public string Reserved03
        {
            get;
            set;
        }



        /// <summary>
        /// 总出量OUT_FLUIDS_AMOUNT
        /// </summary>
        public Nullable<decimal> OutFluidsAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 总入量IN_FLUIDS_AMOUNT
        /// </summary>
        public Nullable<decimal> InFluidsAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 液体总入量INFUSION_TRAN_VOL
        /// </summary>
        public Nullable<decimal> InfusionTranVol
        {
            get;
            set;
        }

        /// <summary>
        /// OUT_REMAINDER_AMOUNT	出室余量 
        /// </summary>
        public Nullable<decimal> OutRemainderAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 失血量BLOOD_LOSSED
        /// </summary>
        public Nullable<decimal> BloodLossed
        {
            get;
            set;
        }

        /// <summary>
        /// 输血量BLOOD_TRANSFUSED
        /// </summary>
        public Nullable<decimal> BloodTransfused
        {
            get;
            set;
        }

        /// <summary>
        /// 尿量URINE_AMOUNT
        /// </summary>
        public Nullable<decimal> UrineAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 引流量DRAINAGE_AMOUNT
        /// </summary>
        public Nullable<decimal> DrainageAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 全血WHOLE_BLOOD
        /// </summary>
        public Nullable<decimal> WholeBlood
        {
            get;
            set;
        }

        /// <summary>
        /// 红细胞悬液PURE_RED_CELL
        /// </summary>
        public Nullable<decimal> PureRedCell
        {
            get;
            set;
        }

        /// <summary>
        /// 晶体CRYSTALLOIDS
        /// </summary>
        public Nullable<decimal> Crystalloids
        {
            get;
            set;
        }

        /// <summary>
        /// 胶体COLLOIDS
        /// </summary>
        public Nullable<decimal> Colloids
        {
            get;
            set;
        }

        /// <summary>
        /// 凝血因子BLOOD_COAGULATION_FACTORS
        /// </summary>
        public Nullable<decimal> BloodCoagulationFactors
        {
            get;
            set;
        }

        /// <summary>
        /// 白蛋白ALBUMIN
        /// </summary>
        public Nullable<decimal> Albumin
        {
            get;
            set;
        }

        /// <summary>
        /// 血浆PLASMA
        /// </summary>
        public Nullable<decimal> Plasma
        {
            get;
            set;
        }

        /// <summary>
        /// 血浆替代品PLASMA_SUBSTITUTE
        /// </summary>
        public Nullable<decimal> PlasmaSubstitu
        {
            get;
            set;
        }

        /// <summary>
        /// 平衡液EQUILIBRIUM_LIQUID
        /// </summary>
        public Nullable<decimal> EquilibriumLiquid
        {
            get;
            set;
        }

        /// <summary>
        /// 生理盐水ORMAL_SALINE
        /// </summary>
        public Nullable<decimal> OrmalSaline
        {
            get;
            set;
        }

        /// <summary>
        /// 万汶VOLUVEN
        /// </summary>
        public Nullable<decimal> Voluven
        {
            get;
            set;
        }

        /// <summary>
        /// 佳乐施GELOFUSINE
        /// </summary>
        public Nullable<decimal> Gelofusine
        {
            get;
            set;
        }

        /// <summary>
        /// 血小板PLATELET
        /// </summary>
        public Nullable<decimal> Platelet
        {
            get;
            set;
        }

        /// <summary>
        /// 冷沉淀COOL_THING
        /// </summary>
        public Nullable<decimal> CoolThing
        {
            get;
            set;
        }

        /// <summary>
        /// 自体回输CRY_WATHER
        /// </summary>
        public Nullable<decimal> CryWather
        {
            get;
            set;
        }

        /// <summary>
        /// 红细胞RED_BLOOD
        /// </summary>
        public Nullable<decimal> RedBlood
        {
            get;
            set;
        }


        /// <summary>
        /// 其它入量OTHER_IN_AMOUNT
        /// </summary>
        public Nullable<decimal> OtherInAmount
        {
            get;
            set;
        }


        /// <summary>
        /// 其他出量OTHER_OUT_AMOUNT
        /// </summary>
        public Nullable<decimal> OtherOutAmount
        {
            get;
            set;
        }

    }
}
