/*******************************
 * 文件名称：PatientModel.cs
 * 文件说明：患者实体类，继承ObservableObject，可以实现属性绑定界面
 * 作    者：许文龙
 * 日    期：2017-04-07
 * *****************************/
using GalaSoft.MvvmLight;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.Model.WorkListModel
{
    public class PatientModel : ObservableObject
    {
        private MED_PAT_INFO med_Pat_Info;                // 对应的数据表
        private string patientID;                         // 患者ID
        private int visitID;                              // 患者ID
        private int operID;                               // 患者ID
        private string deptCode;                          // 患者所在科室
        private string deptCodeName;                      // 患者所在科室名称
        private string operDeptCode;                      // 手术科室，即手术医生所在的科室
        private string operDeptName;                      // 手术科室名称
        private string operRoom;                          // 手术室
        private string operRoomNo;                        // 手术间
        private string operClass;                         // 手术类型：1-一般手术，2-急抢救手术，3-术中急抢救
        private string diagBeforeOperation;               // 术前诊断
        private string patientCondition;                  // 病情说明
        private string diagAfterOperation;                // 术后诊断
        private string bedNo;                             // 床号
        private string name;                              // 患者姓名
        private string sex;                               // 患者性别
        private string operationName;                     // 手术名称
        private string anesDoctor;                        // 麻醉医生
        private string anesDoctorName;                    // 麻醉医生姓名
        private string firstAnesAssistant;                // 第一麻醉助手
        private string firstAnesAssistantName;            // 第一麻醉助手姓名
        private string secondAnesAssistant;               // 第二麻醉助手
        private string secondAnesAssistantName;           // 第二麻醉助手姓名
        private string anesDocAndAss;                     // 麻醉者 = 主麻 + 第一麻醉助手
        private string cpbDoctor;                         // 灌注医生
        private string firstCPBAssistant;                 // 灌注医生助手1
        private string firstOperNurse;                    // 第一台上护士
        private string secondOperNurse;                   // 第二台上护士
        private string firstSupplyNurse;                  // 第一供应护士
        private string secondSupplyNurse;                 // 第二巡回护士
        private string pacuDoctor;                        // PACU医生
        private string anesMethod;                        // 麻醉方法
        private DateTime reqDateTime;                     // 手术申请时间
        private DateTime scheduledDateTime;               // 手术安排时间
        private DateTime inDateTime;                      // 入手术室时间
        private DateTime outDateTime;                     // 出手术室时间
        private DateTime startDateTime;                   // 手术开始时间
        private DateTime endDateTime;                     // 手术结束时间
        private DateTime inPacuDateTime;                  // 入PACU时间
        private DateTime outPacuDateTime;                 // 出PACU时间
        private DateTime anesStartTime;                   // 麻醉开始时间
        private DateTime anesEndTime;                     // 麻醉结束时间
        private OperationStatus operStatusCode;           // 手术状态
        private string operStatusCodeDescription;         // 手术状态描述
        private string operPosition;                      // 手术体位
        private string surgeon;                           // 手术医生
        private string surgeonName;                       // 手术医生姓名
        private string firstOperAssistant;                // 第一手术助手
        private string firstOperAssistantName;            // 第一手术助手姓名
        private string secondOperAssistant;               // 第二手术助手
        private string secondOperAssistantName;           // 第二手术助手姓名
        private string thirdOperAssistant;                // 第三手术助手
        //private string thirdOperAssistantName;            // 第三手术助手姓名
        private string fourthOperAssistant;               // 第四手术助手
        //private string fourthOperAssistantName;           // 第四手术助手姓名
        private string surgeonAndAss;                     // 术者=手术医生+手术助手，主要显示在界面中
        private string woundType;                         // 切口类型
        private string patWhereaborts;                    // 患者去向
        private string operScale;                         // 手术等级
        private string asaGrade;                          // asa等级
        private string inpNo;                             // 住院号
        private string sequence;                          // 台次
        private DateTime dateOfBirth;                     // 出生日期
        private string age;                               // 年龄
        private int radiateInd;                           // 放射标志:1 正常 ，2 感染
        private int isolationInd;                         // 隔离标志：指手术是否需要隔离。1-正常 2-隔离
        private int emergencyInd;                         // 急诊标志:0-择期 1-急诊
        private string strPatInfo;                        // 显示在搜索界面中的信息
        private string strOutDateTimeMessage;             // 当出手术室时，在床头卡显示出室时间

        private string _showColor;                        // 用以区分术前术中术后状态

        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientID
        {
            get { return this.patientID; }
            set
            {
                this.patientID = value;
                this.RaisePropertyChanged("PatientID");
            }
        }

        /// <summary>
        /// 患者ID
        /// </summary>
        public int VisitID
        {
            get { return this.visitID; }
            set
            {
                this.visitID = value;
                this.RaisePropertyChanged("VisitID");
            }
        }

        /// <summary>
        /// 患者ID
        /// </summary>
        public int OperID
        {
            get { return this.operID; }
            set
            {
                this.operID = value;
                this.RaisePropertyChanged("OperID");
            }
        }

        /// <summary>
        /// 患者所在科室
        /// </summary>
        public string DeptCode
        {
            get { return this.deptCode; }
            set
            {
                this.deptCode = value;
                this.RaisePropertyChanged("DeptCode");
                if (null != ApplicationModel.Instance.AllDictList.DeptDictList)
                {
                    MED_DEPT_DICT tempDeptDict = null;
                    if (ApplicationModel.Instance.DeptDictCache == null)
                    {
                        ApplicationModel.Instance.DeptDictCache.TryGetValue(this.deptCode, out tempDeptDict);
                    }
                    if (tempDeptDict == null)
                        tempDeptDict = ApplicationModel.Instance.AllDictList.DeptDictList.Where(x => x.DEPT_CODE.Equals(this.deptCode)).FirstOrDefault();
                    if (tempDeptDict != null)
                    {
                        this.DeptCodeName = tempDeptDict.DEPT_NAME;
                    }
                }
            }
        }

        /// <summary>
        /// 患者所在科室的名称
        /// </summary>
        public string DeptCodeName
        {
            get { return this.deptCodeName; }
            set
            {
                this.deptCodeName = value;
                this.RaisePropertyChanged("DeptCodeName");
            }
        }

        /// <summary>
        /// 手术科室，即手术医生所在的科室
        /// </summary>
        public string OperDeptCode
        {
            get { return this.operDeptCode; }
            set
            {
                this.operDeptCode = value;
                this.RaisePropertyChanged("OperDeptCode");
                if (null != ApplicationModel.Instance.AllDictList.DeptDictList)
                {
                    MED_DEPT_DICT tempDeptDict = null;
                    if (ApplicationModel.Instance.DeptDictCache == null)
                    {
                        ApplicationModel.Instance.DeptDictCache.TryGetValue(this.deptCode, out tempDeptDict);
                    }
                    if (tempDeptDict == null)
                        tempDeptDict = ApplicationModel.Instance.AllDictList.DeptDictList.Where(x => x.DEPT_CODE.Equals(this.operDeptName)).FirstOrDefault();
                    if (tempDeptDict != null)
                    {
                        this.OperDeptName = tempDeptDict.DEPT_NAME;
                    }
                }
            }
        }

        /// <summary>
        /// 手术科室名称
        /// </summary>
        public string OperDeptName
        {
            get { return this.operDeptName; }
            set
            {
                this.operDeptName = value;
                this.RaisePropertyChanged("OperDeptName");
            }
        }

        /// <summary>
        /// 手术状态
        /// </summary>
        public OperationStatus OperStatusCode
        {
            get { return this.operStatusCode; }
            set
            {
                this.operStatusCode = value;
                this.RaisePropertyChanged("OperStatusCode");
            }
        }

        /// <summary>
        /// 手术状态描述
        /// </summary>
        public string OperStatusCodeDescription
        {
            get { return this.operStatusCodeDescription; }
            set
            {
                this.operStatusCodeDescription = value;
                this.RaisePropertyChanged("OperStatusCodeDescription");
            }
        }

        /// <summary>
        /// 手术室
        /// </summary>
        public string OperRoom
        {
            get { return this.operRoom; }
            set
            {
                this.operRoom = value;
                this.RaisePropertyChanged("OperRoom");
            }
        }

        /// <summary>
        /// 手术间
        /// </summary>
        public string OperRoomNo
        {
            get { return this.operRoomNo; }
            set
            {
                this.operRoomNo = value;
                this.RaisePropertyChanged("OperRoomNo");
            }
        }

        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo
        {
            get { return this.bedNo; }
            set
            {
                this.bedNo = value;
                this.RaisePropertyChanged("BedNo");
            }
        }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// 患者性别
        /// </summary>
        public string Sex
        {
            get { return this.sex; }
            set
            {
                this.sex = value;
                this.RaisePropertyChanged("Sex");
            }
        }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OperationName
        {
            get { return this.operationName; }
            set
            {
                this.operationName = value;
                this.RaisePropertyChanged("OperationName");
            }
        }

        /// <summary>
        /// 手术位置
        /// </summary>
        public string OperPosition
        {
            get { return this.operPosition; }
            set
            {
                this.operPosition = value;
                this.RaisePropertyChanged("OperPosition");
            }
        }

        /// <summary>
        /// 麻醉医生
        /// </summary>
        public string AnesDoctor
        {
            get { return this.anesDoctor; }
            set
            {
                this.anesDoctor = value;
                this.RaisePropertyChanged("AnesDoctor");
                this.AnesDoctorName = PatientModel.IDConvertName(this.anesDoctor);
            }
        }

        /// <summary>
        /// 主麻医生姓名
        /// </summary>
        public string AnesDoctorName
        {
            get { return this.anesDoctorName; }
            set
            {
                this.anesDoctorName = value;
                this.RaisePropertyChanged("AnesDoctorName");
            }
        }

        /// <summary>
        /// 第一麻醉助手
        /// </summary>
        public string FirstAnesAssistant
        {
            get { return this.firstAnesAssistant; }
            set
            {
                this.firstAnesAssistant = value;
                this.RaisePropertyChanged("FirstAnesAssistant");
                this.FirstAnesAssistantName = PatientModel.IDConvertName(this.firstAnesAssistant);
            }
        }

        /// <summary>
        /// 第一麻醉助手姓名
        /// </summary>
        public string FirstAnesAssistantName
        {
            get { return this.firstAnesAssistantName; }
            set
            {
                this.firstAnesAssistantName = value;
                this.RaisePropertyChanged("FirstAnesAssistantName");
            }
        }

        /// <summary>
        /// 第一洗手护士
        /// </summary>
        public string FirstOperNurse
        {
            get { return this.firstOperNurse; }
            set
            {
                this.firstOperNurse = value;
                this.RaisePropertyChanged("FirstOperNurse");
            }
        }

        /// <summary>
        /// 第二洗手护士
        /// </summary>
        public string SecondOperNurse
        {
            get { return this.secondOperNurse; }
            set
            {
                this.secondOperNurse = value;
                this.RaisePropertyChanged("SecondOperNurse");
            }
        }

        /// <summary>
        /// 第一巡回护士
        /// </summary>
        public string FirstSupplyNurse
        {
            get { return this.firstSupplyNurse; }
            set
            {
                this.firstSupplyNurse = value;
                this.RaisePropertyChanged("FirstSupplyNurse");
            }
        }

        /// <summary>
        /// 第二巡回护士
        /// </summary>
        public string SecondSupplyNurse
        {
            get { return this.secondSupplyNurse; }
            set
            {
                this.secondSupplyNurse = value;
                this.RaisePropertyChanged("SecondSupplyNurse");
            }
        }

        /// <summary>
        /// 复苏室医生
        /// </summary>
        public string PACUDoctor
        {
            get { return this.pacuDoctor; }
            set
            {
                this.pacuDoctor = value;
                this.RaisePropertyChanged("PACUDoctor");
            }
        }

        /// <summary>
        /// 手术申请时间
        /// </summary>
        public DateTime ReqDateTime
        {
            get { return this.reqDateTime; }
            set
            {
                this.reqDateTime = value;
                this.RaisePropertyChanged("ReqDateTime");
            }
        }

        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string AnesMethod
        {
            get { return this.anesMethod; }
            set
            {
                this.anesMethod = value;
                this.RaisePropertyChanged("AnesMethod");
            }
        }

        /// <summary>
        /// 手术预计开始时间
        /// </summary>
        public DateTime ScheduledDateTime
        {
            get { return this.scheduledDateTime; }
            set
            {
                this.scheduledDateTime = value;
                this.RaisePropertyChanged("ScheduledDateTime");
            }
        }

        /// <summary>
        /// 入室时间
        /// </summary>
        public DateTime InDateTime
        {
            get { return this.inDateTime; }
            set
            {
                this.inDateTime = value;
                this.RaisePropertyChanged("InDateTime");
            }
        }

        /// <summary>
        /// 出手术室时间
        /// </summary>
        public DateTime OutDateTime
        {
            get { return this.outDateTime; }
            set
            {
                this.outDateTime = value;
                this.RaisePropertyChanged("OutDateTime");

                if (null != this.outDateTime && this.outDateTime != DateTime.MaxValue && this.outDateTime != DateTime.MinValue)
                {
                    this.StrOutDateTimeMessage = "出手术室时间：" + this.outDateTime.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    this.StrOutDateTimeMessage = string.Empty;
                }
            }
        }

        /// <summary>
        /// 手术开始时间
        /// </summary>
        public DateTime StartDateTime
        {
            get { return this.startDateTime; }
            set
            {
                this.startDateTime = value;
                this.RaisePropertyChanged("StartDateTime");
            }
        }

        /// <summary>
        /// 手术结束时间
        /// </summary>
        public DateTime EndDateTime
        {
            get { return this.endDateTime; }
            set
            {
                this.endDateTime = value;
                this.RaisePropertyChanged("EndDateTime");
            }
        }

        /// <summary>
        /// 入PACT时间
        /// </summary>
        public DateTime InPacuDateTime
        {
            get { return this.inPacuDateTime; }
            set
            {
                this.inPacuDateTime = value;
                this.RaisePropertyChanged("InPacuDateTime");
            }
        }

        /// <summary>
        /// 出PACU时间
        /// </summary>
        public DateTime OutPacuDateTime
        {
            get { return this.outPacuDateTime; }
            set
            {
                this.outPacuDateTime = value;
                this.RaisePropertyChanged("OutPacuDateTime");
            }
        }

        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        public DateTime AnesStartTime
        {
            get { return this.anesStartTime; }
            set
            {
                this.anesStartTime = value;
                this.RaisePropertyChanged("AnesStartTime");
            }

        }

        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public DateTime AnesEndTime
        {
            get { return this.anesEndTime; }
            set
            {
                this.anesEndTime = value;
                this.RaisePropertyChanged("AnesEndTime");
            }
        }

        /// <summary>
        /// 手术医生
        /// </summary>
        public string Surgeon
        {
            get { return this.surgeon; }
            set
            {
                this.surgeon = value;
                this.RaisePropertyChanged("Surgeon");
                this.SurgeonName = PatientModel.IDConvertName(this.surgeon);
            }
        }

        /// <summary>
        /// 手术医生姓名
        /// </summary>
        public string SurgeonName
        {
            get { return this.surgeonName; }
            set
            {
                this.surgeonName = value;
                this.RaisePropertyChanged("SurgeonName");
            }
        }

        /// <summary>
        /// 手术等级
        /// </summary>
        public string OperScale
        {
            get { return this.operScale; }
            set
            {
                this.operScale = value;
                this.RaisePropertyChanged("OperScale");
            }
        }

        /// <summary>
        /// asa等级
        /// </summary>
        public string AsaGrade
        {
            get { return this.asaGrade; }
            set
            {
                this.asaGrade = value;
                this.RaisePropertyChanged("AsaGrade");
            }
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string InpNo
        {
            get { return this.inpNo; }
            set
            {
                this.inpNo = value;
                this.RaisePropertyChanged("InpNo");
            }
        }

        /// <summary>
        /// 台次
        /// </summary>
        public string Sequence
        {
            get { return this.sequence; }
            set
            {
                this.sequence = value;
                this.RaisePropertyChanged("Sequence");
            }
        }

        /// <summary>
        /// 手术类型：1-一般手术，2-急抢救手术，3-术中急抢救
        /// </summary>
        public string OperClass
        {
            get { return this.operClass; }
            set
            {
                this.operClass = value;
                this.RaisePropertyChanged("OperClass");
            }
        }

        /// <summary>
        /// 术前诊断
        /// </summary>
        public string DiagBeforeOperation
        {
            get { return this.diagBeforeOperation; }
            set
            {
                this.diagBeforeOperation = value;
                this.RaisePropertyChanged("DiagBeforeOperation");
            }
        }

        /// <summary>
        /// 病情说明
        /// </summary>
        public string PatientCondition
        {
            get { return this.patientCondition; }
            set
            {
                this.patientCondition = value;
                this.RaisePropertyChanged("PatientCondition");
            }
        }

        /// <summary>
        /// 术后诊断
        /// </summary>
        public string DiagAfterOperation
        {
            get { return this.diagAfterOperation; }
            set
            {
                this.diagAfterOperation = value;
                this.RaisePropertyChanged("DiagAfterOperation");
            }
        }

        /// <summary>
        /// 第二麻醉助手
        /// </summary>
        public string SecondAnesAssistant
        {
            get { return this.secondAnesAssistant; }
            set
            {
                this.secondAnesAssistant = value;
                this.RaisePropertyChanged("SecondAnesAssistant");
                this.SecondAnesAssistantName = PatientModel.IDConvertName(this.secondAnesAssistant);
            }
        }

        /// <summary>
        /// 第二麻醉助手姓名
        /// </summary>
        public string SecondAnesAssistantName
        {
            get { return this.secondAnesAssistantName; }
            set
            {
                this.secondAnesAssistantName = value;
                this.RaisePropertyChanged("SecondAnesAssistantName");
            }
        }

        /// <summary>
        /// 麻醉者 = 主麻 + 第一麻醉助手
        /// </summary>
        public string AnesDocAndAss
        {
            get { return this.anesDocAndAss; }
            set
            {
                this.anesDocAndAss = value;
                this.RaisePropertyChanged("AnesDocAndAss");
            }
        }

        /// <summary>
        /// 灌注医生
        /// </summary>
        public string CPBDoctor
        {
            get { return this.cpbDoctor; }
            set
            {
                this.cpbDoctor = value;
                this.RaisePropertyChanged("CPBDoctor");
            }
        }

        /// <summary>
        /// 灌注医生助手1
        /// </summary>
        public string FirstCPBAssistant
        {
            get { return this.firstCPBAssistant; }
            set
            {
                this.firstCPBAssistant = value;
                this.RaisePropertyChanged("FirstCPBAssistant");
            }
        }

        /// <summary>
        /// 第一手术助手
        /// </summary>
        public string FirstOperAssistant
        {
            get { return this.firstOperAssistant; }
            set
            {
                this.firstOperAssistant = value;
                this.RaisePropertyChanged("FirstOperAssistant");
                this.FirstOperAssistantName = PatientModel.IDConvertName(this.firstOperAssistant);
            }
        }

        /// <summary>
        /// 第一手术助手姓名
        /// </summary>
        public string FirstOperAssistantName
        {
            get { return this.firstOperAssistantName; }
            set
            {
                this.firstOperAssistantName = value;
                this.RaisePropertyChanged("FirstOperAssistantName");
            }
        }

        /// <summary>
        /// 第二手术助手
        /// </summary>
        public string SecondOperAssistant
        {
            get { return this.secondOperAssistant; }
            set
            {
                this.secondOperAssistant = value;
                this.RaisePropertyChanged("SecondOperAssistant");
                this.SecondOperAssistantName = PatientModel.IDConvertName(this.secondOperAssistant);
            }
        }

        /// <summary>
        /// 第二手术助手姓名
        /// </summary>
        public string SecondOperAssistantName
        {
            get { return this.secondOperAssistantName; }
            set
            {
                this.secondOperAssistantName = value;
                this.RaisePropertyChanged("SecondOperAssistantName");
            }
        }

        /// <summary>
        /// 第三手术助手
        /// </summary>
        public string ThirdOperAssistant
        {
            get { return this.thirdOperAssistant; }
            set
            {
                this.thirdOperAssistant = value;
                this.RaisePropertyChanged("ThirdOperAssistant");
            }
        }

        /// <summary>
        /// 第四手术助手
        /// </summary>
        public string FourthOperAssistant
        {
            get { return this.fourthOperAssistant; }
            set
            {
                this.fourthOperAssistant = value;
                this.RaisePropertyChanged("FourthOperAssistant");
            }
        }

        /// <summary>
        /// 术者信息 = 手术医生+手术助手，主要显示在界面中
        /// </summary>
        public string SurgeonAndAss
        {
            get { return this.surgeonAndAss; }
            set
            {
                this.surgeonAndAss = value;
                this.RaisePropertyChanged("SurgeonAndAss");
            }
        }

        /// <summary>
        /// 切口类型
        /// </summary>
        public string WoundType
        {
            get { return this.woundType; }
            set
            {
                this.woundType = value;
                this.RaisePropertyChanged("WoundType");
            }
        }

        /// <summary>
        /// 患者去向
        /// </summary>
        public string PatWhereaborts
        {
            get { return this.patWhereaborts; }
            set
            {
                this.patWhereaborts = value;
                this.RaisePropertyChanged("PatWhereaborts");
            }
        }

        /// <summary>
        /// 患者出生日期
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set
            {
                this.dateOfBirth = value;
                this.RaisePropertyChanged("DateOfBirth");
            }
        }

        /// <summary>
        /// 患者年龄
        /// </summary>
        public string Age
        {
            get { return this.age; }
            set
            {
                this.age = value;
                this.RaisePropertyChanged("Age");
            }
        }

        /// <summary>
        /// 放射标志:1 正常 ，2 感染
        /// </summary>
        public int RadiateInd
        {
            get { return this.radiateInd; }
            set
            {
                this.radiateInd = value;
                this.RaisePropertyChanged("RadiateInd");
            }
        }

        /// <summary>
        /// 隔离标志：指手术是否需要隔离。1-正常 2-隔离
        /// </summary>
        public int IsolationInd
        {
            get { return this.isolationInd; }
            set
            {
                this.isolationInd = value;
                this.RaisePropertyChanged("IsolationInd");
            }
        }

        /// <summary>
        /// 急诊标志:0-择期 1-急诊
        /// </summary>
        public int EmergencyInd
        {
            get { return this.emergencyInd; }
            set
            {
                this.emergencyInd = value;
                this.RaisePropertyChanged("EmergencyInd");
            }
        }

        /// <summary>
        /// 患者的一些信息：根据手术状态的不同显示对应的信息，用再搜索界面中
        /// </summary>
        public string StrPatInfo
        {
            get { return this.strPatInfo; }
            set
            {
                this.strPatInfo = value;
                this.RaisePropertyChanged("StrPatInfo");
            }
        }

        public string ShowColor
        {
            get { return _showColor; }
            set
            {
                this._showColor = value;
                this.RaisePropertyChanged("ShowColor");
            }
        }

        /// <summary>
        /// 当出手术室时，在床头卡显示出室时间
        /// </summary>
        public string StrOutDateTimeMessage
        {
            get { return this.strOutDateTimeMessage; }
            set
            {
                this.strOutDateTimeMessage = value;
                this.RaisePropertyChanged("StrOutDateTimeMessage");
            }
        }

        /// <summary>
        /// 对应的患者数据表
        /// </summary>
        public MED_PAT_INFO Med_Pat_Info
        {
            get { return this.med_Pat_Info; }
            set { this.med_Pat_Info = value; }
        }

        /// <summary>
        /// 根据List<MED_OPERATION_MASTER> 转换成 List<PatientModel>
        /// </summary>
        public static IEnumerable<PatientModel> CreateListModel(IEnumerable<MED_PAT_INFO> patInfoList, EventHandler pageCreateList = null)
        {
            List<PatientModel> list = new List<PatientModel>();
            if (null != patInfoList)
            {
                foreach (MED_PAT_INFO patInfo in patInfoList)
                {
                    list.Add(CreateModel(patInfo));

                    // 分批次进行转换，先转换8条记录
                    if (list.Count == 8 && pageCreateList != null)
                    {
                        pageCreateList(patInfoList, null);
                        break;
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 根据MED_OPERATION_MASTER 转换成 PatientModel
        /// </summary>
        public static PatientModel CreateModel(MED_PAT_INFO patInfo)
        {
            PatientModel patModel = null;
            if (null != patInfo)
            {
                patModel = new PatientModel();
                //patModel.Age = DateDiff.CalAge((DateTime)patInfo.DATE_OF_BIRTH, DateTime.Now);
                patModel.Age = DateDiff.CalAge((DateTime)patInfo.DATE_OF_BIRTH, patInfo.SCHEDULED_DATE_TIME.Value);
                patModel.AnesDoctor = patInfo.ANES_DOCTOR;
                patModel.AnesEndTime = patInfo.ANES_END_TIME == null ? DateTime.MinValue : (DateTime)patInfo.ANES_END_TIME;
                patModel.AnesMethod = patInfo.ANES_METHOD;
                patModel.AnesStartTime = patInfo.ANES_START_TIME == null ? DateTime.MinValue : (DateTime)patInfo.ANES_START_TIME;
                patModel.AsaGrade = patInfo.ASA_GRADE;
                patModel.BedNo = patInfo.BED_NO + "床";
                patModel.CPBDoctor = patInfo.CPB_DOCTOR;
                patModel.DeptCode = patInfo.DEPT_CODE;
                patModel.DiagAfterOperation = patInfo.DIAG_AFTER_OPERATION;
                patModel.DiagBeforeOperation = patInfo.DIAG_BEFORE_OPERATION;
                patModel.EndDateTime = patInfo.END_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.END_DATE_TIME;
                patModel.FirstAnesAssistant = patInfo.FIRST_ANES_ASSISTANT;
                patModel.FirstCPBAssistant = patInfo.FIRST_CPB_ASSISTANT;
                patModel.FirstOperAssistant = patInfo.FIRST_OPER_ASSISTANT;
                patModel.FirstOperNurse = patInfo.FIRST_OPER_NURSE;
                patModel.FirstSupplyNurse = patInfo.FIRST_SUPPLY_NURSE;
                patModel.FourthOperAssistant = patInfo.FOURTH_OPER_ASSISTANT;
                patModel.InDateTime = patInfo.IN_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.IN_DATE_TIME;
                patModel.InPacuDateTime = patInfo.IN_PACU_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.IN_PACU_DATE_TIME;
                patModel.OperationName = patInfo.OPERATION_NAME;
                patModel.OperClass = patInfo.OPER_CLASS;
                patModel.OperDeptCode = patInfo.OPER_DEPT_CODE;
                patModel.OperID = patInfo.OPER_ID;
                patModel.OperPosition = patInfo.OPER_POSITION;
                patModel.OperRoom = patInfo.OPER_ROOM;
                patModel.OperRoomNo = patInfo.OPER_ROOM_NO;
                patModel.OperScale = patInfo.OPER_SCALE;
                patModel.OperStatusCode = (OperationStatus)patInfo.OPER_STATUS_CODE;
                patModel.OperStatusCodeDescription = ApplicationModel.Instance.GetEnumDescription<OperationStatus>(patModel.OperStatusCode);
                patModel.OutDateTime = patInfo.OUT_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.OUT_DATE_TIME;
                patModel.OutPacuDateTime = patInfo.OUT_PACU_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.OUT_PACU_DATE_TIME;
                patModel.PACUDoctor = patInfo.PACU_DOCTOR;
                patModel.PatientCondition = patInfo.PATIENT_CONDITION;
                patModel.PatientID = patInfo.PATIENT_ID;
                patModel.PatWhereaborts = patInfo.PAT_WHEREABORTS;
                patModel.ReqDateTime = patInfo.REQ_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.REQ_DATE_TIME;
                patModel.ScheduledDateTime = patInfo.SCHEDULED_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.SCHEDULED_DATE_TIME;
                patModel.SecondAnesAssistant = patInfo.SECOND_ANES_ASSISTANT;
                patModel.SecondOperAssistant = patInfo.SECOND_OPER_ASSISTANT;
                patModel.SecondOperNurse = patInfo.SECOND_OPER_NURSE;
                patModel.SecondSupplyNurse = patInfo.SECOND_SUPPLY_NURSE;
                patModel.Sequence = patInfo.SEQUENCE.ToString();
                patModel.StartDateTime = patInfo.START_DATE_TIME == null ? DateTime.MinValue : (DateTime)patInfo.START_DATE_TIME;
                patModel.Surgeon = patInfo.SURGEON;
                patModel.ThirdOperAssistant = patInfo.THIRD_OPER_ASSISTANT;
                patModel.VisitID = patInfo.VISIT_ID;
                patModel.WoundType = patInfo.WOUND_TYPE;
                patModel.Name = patInfo.NAME;
                patModel.Sex = patInfo.SEX;
                patModel.DateOfBirth = patInfo.DATE_OF_BIRTH;
                patModel.InpNo = patInfo.INP_NO;
                patModel.SurgeonAndAss = "术者：" + patModel.SurgeonName + (string.IsNullOrEmpty(patModel.FirstOperAssistantName) ? string.Empty : "," + patModel.FirstOperAssistantName);
                patModel.AnesDocAndAss = "主麻：" + patModel.AnesDoctorName + (string.IsNullOrEmpty(patModel.FirstAnesAssistantName) ? string.Empty : "," + patModel.FirstAnesAssistantName);
                patModel.RadiateInd = null == patInfo.RADIATE_IND ? 0 : (int)patInfo.RADIATE_IND;
                patModel.IsolationInd = null == patInfo.ISOLATION_IND ? 0 : (int)patInfo.ISOLATION_IND;
                patModel.EmergencyInd = null == patInfo.EMERGENCY_IND ? 0 : (int)patInfo.EMERGENCY_IND;

                if (patModel.operStatusCode >= OperationStatus.OutOperationRoom)
                {
                    patModel.StrPatInfo = patModel.InDateTime.ToString("HH:mm") + "-" + patModel.OutDateTime.ToString("HH:mm");

                    patModel.ShowColor = "#deda2d";
                }
                else if (patModel.operStatusCode >= OperationStatus.InOperationRoom)
                {
                    patModel.StrPatInfo = patModel.InDateTime.ToString("HH:mm") + "-";

                    patModel.ShowColor = "#df4932";
                }
                else
                {
                    patModel.StrPatInfo = "术前";

                    patModel.ShowColor = "#28a61a";
                }

                patModel.Med_Pat_Info = patInfo;
            }

            return patModel;
        }

        /// <summary>
        /// 根据编号获取姓名
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string IDConvertName(string userID)
        {
            string name = userID;
            if (!string.IsNullOrEmpty(userID))
            {
                MED_HIS_USERS tempUser = null;
                if (ApplicationModel.Instance.HisUsersCache == null)
                {
                    ApplicationModel.Instance.HisUsersCache.TryGetValue(userID, out tempUser);
                }
                if (tempUser == null)
                    tempUser = ApplicationModel.Instance.AllDictList.HisUsersList.Where<MED_HIS_USERS>(x => x.USER_JOB_ID.Equals(userID)).FirstOrDefault<MED_HIS_USERS>();
                if (null != tempUser)
                {
                    name = tempUser.USER_NAME;
                }
            }

            return name;
        }
    }
}
