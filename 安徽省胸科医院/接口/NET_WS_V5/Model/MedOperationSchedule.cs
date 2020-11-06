
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:47:08
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedOperationSchedule
	/// </summary>
	[Serializable]
	public class MedOperationSchedule:ModelBase
	{
		 
		#region public property
		///<summary>
		///病人标识号;唯一确定手术病人，非空
		///</summary>
        public string PatientId
        {
            get;
            set;
        }

		///<summary>
		///病人本次住院标识;对门诊病人为0
		///</summary>
		public decimal VisitId
		{
            get;
            set;
		}

		///<summary>
		///手术安排标识;针对一个病人一次住院同时预约的多次手术，从1开始分配。每次预约时，在该表中取病人预约手术的最大标识数，加1作为本次标识。如果未找到该病人在本表中的预约记录，标识为1
		///</summary>
		public decimal ScheduleId
		{
            get;
            set;
		}

        /// <summary>
        /// 手术ID
        /// </summary>
        public decimal OperId
        {
            get;
            set;
        }


        /// <summary>
        /// 院区HOSP_BRANCH
        /// </summary>
        public string  HospBranch
        {
            get;
            set;
        }

        /// <summary>
        /// 病区
        /// </summary>
        public string WardCode
        {
            get;
            set;
        }

		///<summary>
        ///患者所在科室DEPT_STAYED见科室代码表。MED_DEPT_DICT
		///</summary>
        public string DeptCode
		{
            get;
            set;
		}

        ///<summary>
        ///OPERATING_DEPT实施手术的科室，即手术医生所在科室.OPERATING_DEPT
        ///</summary>
        public string OperDeptCode 
        {
            get;
            set;
        }

        /// <summary>
        /// 手术间，源 opertionroom
        /// </summary>
        public string OperRoom
        {
            get;
            set;
        }

        /// <summary>
        /// 手术间编码 源 operationroomno
        /// </summary>
        public string OperRoomNo
        {
            get;
            set;
        }

        ///<summary>
        ///台次;表示上述同一个手术间的手术台次，由手术室分配
        ///</summary>
        public decimal Sequence
        {
            get;
            set;
        }

		///<summary>
		///病人所在床号;手术申请时所在床号，由手术室录入或修改。用于病房未使用入出转系统的情况
		///</summary>
		public string BedNo
		{
            get;
            set;
		}

        /// <summary>
        /// 手术类型
        /// </summary>
        public string OperClass
        {
            get;
            set;
        }


        ///<summary>
        ///术前主要诊断;病人手术前的诊断描述
        ///</summary>
        public string DiagBeforeOperation
        {
            get;
            set;
        }

        ///<summary>
        ///病情说明;对病人体征、病情等进一步说明
        ///</summary>
        public string PatientCondition
        {
            get;
            set;
        }



        ///<summary>
        ///手术等级;指一次手术的综合等级。取值：特、大、中、小
        ///</summary>
        public string OperScale
        {
            get;
            set;
        }


        /// <summary>
        /// 切口类型代码表。I类、II类、III类WOUND_TYPE
        /// </summary>
        public string  WoundType
        {
            get;
            set;
        }

        /// <summary>
        /// ASA等级代码表。I级、II级、III级、IV级、Ⅴ级、Ⅵ级
        /// </summary>
        public string AsaGrade
        {
            get;
            set;
        }

       
        /// <summary>
        ///急诊标志。EMERGENCY INDICATOR。0-择期 1-急诊EMERGENCY_IND
        /// </summary> 
        public Nullable<decimal>  EmergencyInd
        {
            get;
            set;
        }

        /// <summary>
        ///手术来源 0 门诊，1 住院，2 急诊OPER_SOURCE
        /// </summary>
        public Nullable<decimal>  OperSource
        {
            get;
            set;
        }

        /// <summary>
        /// 指手术是否需要隔离。1-正常 2-隔离ISOLATION_IND
        /// </summary>
        public Nullable<decimal> IsolationInd
        {
            get;
            set;
        }

        /// <summary>
        /// 感染标志。1 正常 ，2 感染INFECTED_IND
        /// </summary>
        public Nullable<decimal>  InfectedInd
        {
            get;
            set;
        }

        /// <summary>
        /// 放射标志。1 正常 ，2 感染RADIATE_IND
        /// </summary>
        public Nullable<decimal>  RadiateInd
        {
            get;
            set;
        }


        ///<summary>
        ///手术者;手术医师姓名
        ///</summary>
        public string Surgeon
        {
            get;
            set;
        }
		

	 

		///<summary>
		///第一手术助手;第一手术助手姓名
		///</summary>
        public string FirstOperAssistant
		{
            get;
            set;
		}

		///<summary>
		///第二手术助手;第二手术助手姓名
		///</summary>
        public string SecondOperAssistant
		{
            get;
            set;
		}

		///<summary>
        ///第三手术助手;第三手术助手姓名ThridOperAssistant
		///</summary>
        public string ThirdOperAssistant
		{
            get;
            set;
		}

		///<summary>
		///第四手术助手;第四手术助手姓名
		///</summary>
        public string FourthOperAssistant  
		{
            get;
            set;
		}

    

		///<summary>
		///麻醉方法;使用规范名称，见4.18麻醉方法字典
		///</summary>
        public string AnesMethod
		{
            get;
            set;
		}

		///<summary>
		///麻醉医师;麻醉医师姓名
		///</summary>
        public string AnesDoctor
		{
            get;
            set;
		}


     
		///<summary>
		///麻醉助手;麻醉助手姓名
		///</summary>
        public string FirstAnesAssistant
		{
            get;
            set;
		}

        /// <summary>
        /// 麻醉助手二
        /// </summary>
        public string SecondAnesAssistant
        {
            get;
            set;
        }
        /// <summary>
        /// 麻醉助手三
        /// </summary>
        public string ThirdAnesAssistant
        {
            get;
            set;
        }
        
        /// <summary>
        /// 麻醉助手四FOURTH_ANES_ASSISTANT
        /// </summary>
          public string   FourthAnesAssistant
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
        /// 第三麻醉护士THIRD_ANES_NURSE
        /// </summary>
          public string  ThirdAnesNurse
          {
              get;
              set;
          }
            


		///<summary>
        ///灌注医生BLOOD_TRAN_DOCTOR
		///</summary>
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
        /// 灌注医生助手4FOURTH_CPB_ASSISTANT
        /// </summary>
        public string FourthCpbAssistant
        {
            get;
            set;
        }


		///<summary>
		///第一台上护士;护士姓名FIRST_OPER_NURSE
		///</summary>
        public string FirstOperNurse
		{
            get;
            set;
		}

		///<summary>
		///第二台上护士;护士姓名SECOND_OPER_NURSE
		///</summary>
        public string  SecondOperNurse
		{
            get;
            set;
		}

        ///<summary>
        ///第三台上护士;护士姓名THIRD_OPER_NURSE
        ///</summary>
        public string  ThirdOperNurse
        {
            get;
            set;
        }


        ///<summary>
        ///第四台上护士;护士姓名FOURTH_OPER_NURSE
        ///</summary> 
        public string  FourthOperNurse
        {
            get;
            set;
        }
		///<summary>
		///第一供应护士;护士姓名
		///</summary>
		public string FirstSupplyNurse
		{
            get;
            set;
		}

		///<summary>
		///第二供应护士;护士姓名
		///</summary>
		public string SecondSupplyNurse
		{
            get;
            set;
		}

        ///<summary>
        ///第三供应护士;护士姓名THIRD_SUPPLY_NURSE  ThirdSupplyNurse
        ///</summary>
        public string  ThirdSupplyNurse
        {
            get;
            set;
        }

        ///<summary>
        ///第四供应护士;护士姓名 FOURTH_SUPPLY_NURSE
        ///</summary>
        public string  FourthSupplyNurse
        {
            get;
            set;
        }

        /// <summary>
        /// Pacu医生PACU_DOCTOR
        /// </summary>
        public string PacuDoctor
        {
            get;
            set;
        }

        /// <summary>
        /// pacu第一助手FIRST_PACU_ASSISTANT
        /// </summary>
        public string FirstPacuAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// pacu第二助手 SECOND_PACU_ASSISTANT
        /// </summary>
        public string  SecondPacuAssistant
        {
            get;
            set;
        }

        /// <summary>
        /// Pacu第一护士FIRST_PACU_NURSE
        /// </summary>
        public string  FirstPacuNurse
        {
            get;
            set;
        }

        /// <summary>
        /// Pacu第二护士SECOND_PACU_NURSE
        /// </summary>
        public string SecondPacuNurse
        {
            get;
            set;
        }


        ///<summary>
        ///手术日期及时间;预约手术日期及时间，非空SCHEDULED_DATE_TIME
        ///</summary>
        public DateTime ScheduledDateTime
        {
            get;
            set;
        }

        ///<summary>
        ///申请日期及时间;提出手术申请的日期及时间
        ///</summary>
        public DateTime ReqDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 对应体位代码表，OPER_POSITION
        /// </summary>
        public string OperPosition
        {
            get;
            set;
        }

        ///<summary>
        ///手术名称OperationName
        ///</summary>
        public string OperationName
        {
            get;
            set;
        }

        ///<summary>
        /// 特殊用品 备注
        ///</summary>
        public string SpecialEquipment
        {
            get;
            set;
        }

        ///<summary>
        /// 阳性体征 感染
        ///</summary>
        public string SpecialInfect
        {
            get;
            set;
        }

        /// <summary>
        /// 麻醉排版确认ANES_CONFIRM
        /// </summary>
        public string  AnesConfirm
        {
            get;
            set;
        }

        /// <summary>
        /// 护理排版确认NURSE_CONFIRM
        /// </summary>
        public string  NurseConfirm
        {
            get;
            set;
        }

        /// <summary>
        /// STATE已分配,已提交,已作废OPER_STATUS_CODE
        /// </summary>
        public string OperStatusCode
        {
            get;
            set;
        }

		///<summary>
		///备注;手术申请时指定的手术准备条件等
		///</summary>
		public string NotesOnOperation
		{
            get;
            set;
		}

		///<summary>
		///录入者
		///</summary>
        public string Operator
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

        public string  HisOperStatus  
        {
            get;
            set;
        }

        public string Reserved1
        {
            get;
            set;
        }

        public string Reserved2
        {
            get;
            set;
        }

        public string Reserved3
        {
            get;
            set;
        }

        /// <summary>
        /// 手术时长
        /// </summary>
        public decimal OperatingTime
        {
            get;
            set;
        }
		///<summary>
	 

		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedOperationSchedule))
                return false;
            MedOperationSchedule Oper = (MedOperationSchedule)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.ScheduleId != Oper.ScheduleId)
                return false;
            
            if (this.BedNo != Oper.BedNo)
                return false;
            if (this.ScheduledDateTime != Oper.ScheduledDateTime)
                return false;
            
            if (this.Sequence != Oper.Sequence)
                return false;
            if (this.DiagBeforeOperation != Oper.DiagBeforeOperation)
                return false;
            if (this.PatientCondition != Oper.PatientCondition)
                return false;
            
            if (this.Surgeon != Oper.Surgeon)
                return false;
            
            if (this.FirstSupplyNurse != Oper.FirstSupplyNurse)
                return false;
            if (this.SecondSupplyNurse != Oper.SecondSupplyNurse)
                return false;
            if (this.NotesOnOperation != Oper.NotesOnOperation)
                return false;
           
            if (this.OperId != Oper.OperId)
                return false;
            
             
            if (this.SpecialEquipment != Oper.SpecialEquipment)
                return false;
            if (this.SpecialInfect != Oper.SpecialInfect)
                return false;
           
            if (this.OperationName != Oper.OperationName)
                return false;
            return true;
        }
	}
}
