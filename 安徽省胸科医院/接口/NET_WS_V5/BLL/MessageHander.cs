using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Init;

namespace BLL
{
    public class MessageHander
    {
        public static HospitalBase MessageSwitch(ParamInputDomain domian)
        {

            InitDocare.LogA.Debug("CODExxxoooo:" + domian.Code);
            HospitalBase hosBase = null;
            switch (domian.Code.ToUpper())
            {
                //字典信息同步---------------------------------------------------
                case "DICT101":   //科室字典同步
                    hosBase = new BMedDeptDict();
                    break;
                case "DICT102":   //员工字典同步
                    hosBase = new BMedHisUsers();
                    break;
                case "DICT103":   //手术名称字典同步
                    hosBase = new BMedOperationDict();
                    break;
                case "DICT104":   //诊断字典同步
                    break;
                case "DICT105":   //价表同步
                    break;
                case "DICT106":  //药品字典同步
                    hosBase = new BMedDrugDict();
                    break;
                case "DICT107":  //耗材字典
                    hosBase = new BMedMtrlDict();
                    break;
                case "DICT108":  //设备字典
                    break;
                case "DICT109":  //考勤记录
                    break;
                //患者信息(PAT) --------------------------------------------------------------------------
                case "PAT101":   //根据患者id 同步患者信息
                    hosBase = new BMedPatsMasterIndex();
                    break;
                case "PAT102":  //根据住院号同步患者信息
                    hosBase = new BMedPatMasterIndexByInpNo();
                    break;
                //case "PAT103":  //同步患者在院信息，根据patientid 或者 inpno
                //    hosBase = new BMedPatInHospitalByWarcode();
                //    break;
                case "PAT104":  //单患者历史就诊信息同步
                    break;
                case "PAT105":  //根据病区同步患者在院信息 wardcode
                    hosBase = new BMedPatInHospitalByWardCode();
                    break;
                case "PAT106": //根据院区同步患者在院信息 hospitalBranch
                    break;
                case "PAT107": //同步患者转科记录 patientid,inpno
                    break;
                case "PAT108":
                    hosBase = new BMedPatientOperatingInfo();
                    break;
                case "PAT109":
                    hosBase = new BMedPatOperation();
                    break;
                case "PAT501W":  //患者出科、转科信息回写	参2：patientID、visitID、inpNo、depID
                    break;
                case "PAT502W":  //患者护理信息回写	参2：patientID、visitID、inpNo、depID
                    break;
                case "PAT201":   // 同步患者的术前访视单中的体征数据：体温，呼吸，脉搏，体重，血压信息
                    hosBase = new BAnesVisitClinicalInfo();
                    break;
                //手术信息-----------------------------------------------------------------------------------------
                case "OPER101"://同步手术申请patientID、opertingRoom,startDateTime、stopDateTime
                    hosBase = new BOperationSchedule();
                    break;
                case "OPER102":  //术后信息（新手术）同步patientID、startDateTime、stopDateTime
                    break;
                case "OPER103": //门诊同步手术预约patientID、startDateTime、stopDateTime
                    break;
                case "OPER104":  //急诊手术预约信息同步patientID、startDateTime、stopDateTime
                    break;
                case "OPER105": //取消手术信息同步patientID、visitID
                    break;
                case "OPER106": //手术名称
                    hosBase = new BMedScheduleOperationName();
                    break;
                case "OPER501W": //手术排版信息回传
                    break;
                case "OPER502W":  //术后信息回写
                    break;
                case "OPER503W": //手术状态回传
                    break;
                case "OPER504W"://排版取消回传
                    break;
                case "OPER507W": //手术取消回传
                    break;
                case "OPER505W"://手麻文书回传
                    break;
                case "OPER506W"://麻醉用药，麻醉事件回传
                    break;

                //医嘱信息同步
                case "ORDER101":　　//医嘱信息同步 patientID、visitID
                    hosBase = new BMedOrders();
                    break;
                case "ORDER102":   //执行后医嘱信息同步patientID、visitID
                    break;
                case "ORDER103":
                    hosBase = new BMedOrder103();
                    break;
                case "ORDER501W":  //医嘱执行回传patientID、visitID、depID ,XML 
                    break;
                case "ORDER502W":  //护理信息回传patientID、visitID、depID ,XML 
                    break;
                case "ORDER503W":  //体征信息回传patientID、visitID、depID ,XML 
                    break;
                case "ORDER504W":   //ICU病历类信息回写(特护单等)patientID、visitID、depID ,XML 
                    break;
                //收费信息回传-----------------
                case "BILL501W":
                    break;
                //检验信息同步-----------------
                case "LIS101":  //常规检验信息同步
                    hosBase = new BMedLabTestMaster();
                    break;
                case "LIS102":  //血气
                    break;
                case "LIS103":  //微生物
                    break;
                //PACS检查信息同步 
                case "PACS01":
                    hosBase = new BPacsByInpNo();
                    break;
                case "EMR101":
                    hosBase = new BMedEmr();
                    break;
                case "EMR102":
                    hosBase = new BMedPatientDiagnosis();
                    break;
                case "EMR103":
                    hosBase = new BMedEmr103();
                    break;
                //器械包信息同步
                case "CSSD101":  //耗材信息同步
                    break;
                case "CSSD501W":  //耗材信息回传
                    break;
                case "ICU0101":
                    hosBase = new BMedCopyBackWDSJ();
                    break;
                case "ICU0102":
                    hosBase = new BMedCopyBackLCWD();
                    break;
                default:
                    hosBase = new HospitalBase();
                    break;
            }
            return hosBase;
        }
    }
}
