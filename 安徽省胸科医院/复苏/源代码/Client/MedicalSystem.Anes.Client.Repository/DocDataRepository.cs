using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class DocDataRepository : BaseRepository
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        List<MED_SAFETY_CHECKS> _safetyChecksList = null;
        public MED_SAFETY_CHECKS GetSafetyCheckData(string patientID, int visitID, int operID, ref bool isNewDate)
        {
            MED_SAFETY_CHECKS safetyChecksRow = new MED_SAFETY_CHECKS();

            _safetyChecksList = operationInfoRepository.GetSafetyCheckLists(patientID, visitID, operID).Data;

            if (_safetyChecksList != null)
            {
                if (_safetyChecksList.Count == 0)
                {
                    MED_SAFETY_CHECKS newRow = new MED_SAFETY_CHECKS();
                    newRow.PATIENT_ID = patientID;
                    newRow.VISIT_ID = visitID;
                    newRow.OPER_ID = operID;
                    newRow.PATIENT_CONFIRM1 = "是";
                    newRow.OPERATION_CONFIRM1 = "是";
                    newRow.OPERATION_POSITION_CONFIRM1 = "是";
                    newRow.OPERATION_APPROVAL_CONFIRM = "是";
                    newRow.ANESTHESIA_METHOD_CONFIRM = "是";
                    newRow.ANESTHESIA_APPROVAL_CONFIRM = "是";
                    newRow.SKIN_INTEGRITY_CONFIRM1 = "是";
                    newRow.VENOUS_ROUTE = "是";
                    newRow.ALERGY_HISTORY_CONFIRM = "否";
                    newRow.SKIN_TEST_RESULT = "是";
                    newRow.INFECTED_CONFIRM = "是";
                    newRow.BLOOD_PREPARATION = "是";
                    newRow.PROTHESIS = "是";
                    newRow.IMPLANTED = "是";
                    newRow.IMAGING_DATA1 = "是";
                    newRow.PATIENT_CONFIRM2 = "是";
                    newRow.OPERATION_CONFIRM2 = "是";
                    newRow.OPERATION_POSITION_CONFIRM2 = "是";
                    newRow.ESTIMATED_TIME = "是";
                    newRow.ESTIMATED_BLOOD_LOSS = "是";
                    newRow.OPER_DOCTOR_FOCUSES = "是";
                    newRow.OPER_DOCTOR_OTHER = "是";
                    newRow.ANES_DOCTOR_FOCUSES = "是";
                    newRow.ANES_DOCTOR_OTHER = "是";
                    newRow.STERILISATION_CONFIRM = "是";
                    newRow.EQUIPMENT = "是";
                    newRow.SPECIFIC_MEDICATIONS = "是";
                    newRow.ANTIBIOTICS = "是";
                    newRow.NURSE_OTHER = "是";
                    newRow.IMAGING_DATA2 = "是";
                    newRow.PATIENT_CONFIRM3 = "是";
                    newRow.OPERATION_CONFIRM3 = "是";
                    newRow.MEDICATION_CONFIRM = "是";
                    newRow.PECIMENS = "是";
                    newRow.SKIN_INTEGRITY_CONFIRM3 = "是";
                    newRow.OPERATION_EQUIP_INDICATOR = "是";
                    newRow.CENTRAL_VENOUS = "有";
                    newRow.ARTERY_PATH = "有";
                    newRow.RACHEA_CANNULA = "有";
                    newRow.SUCTION_DRAINAGE = "有";
                    newRow.STOMACH_TUBE = "有";
                    newRow.URINE_TUBE = "有";
                    isNewDate = true;
                    _safetyChecksList.Add(newRow);
                    if (operationInfoRepository.SaveSafetyCheckList(_safetyChecksList).Result == ResultStatus.Success)
                    {
                        _safetyChecksList = operationInfoRepository.GetSafetyCheckLists(patientID, visitID, operID).Data;
                    }
                }
                else
                {
                    isNewDate = false;
                }
                safetyChecksRow = _safetyChecksList[0];
            }
            return safetyChecksRow;
        }
        public MED_ANESTHESIA_RECOVER GetAnesRecoverData(string patientID, int visitID, int operID)
        {
            MED_ANESTHESIA_RECOVER anesRecover = operationInfoRepository.GetAnesRecoverData(patientID, visitID, operID).Data;
            if (anesRecover == null)
            {
                anesRecover = new MED_ANESTHESIA_RECOVER();
                anesRecover.PATIENT_ID = patientID;
                anesRecover.VISIT_ID = visitID;
                anesRecover.OPER_ID = operID;
                anesRecover.RECORD_DATE = accountRepository.GetServerTime().Data;
            }
            return anesRecover;

        }
        public MED_ANESTHESIA_INQUIRY GetAnesInquiry(string patientID, int visitID, int operID, bool isAdd)
        {
            List<MED_ANESTHESIA_INQUIRY> inquiryList = operationInfoRepository.GetAnesInquiryList(patientID, visitID, operID).Data;
            MED_ANESTHESIA_INQUIRY anesInquiry = null;
            int index = 0;
            if (inquiryList != null && inquiryList.Count > 0)
            {
                inquiryList.ForEach(row =>
                {
                    if (row.INQUIRY_NO > index)
                    {
                        index = row.INQUIRY_NO;
                        anesInquiry = row;
                    }
                });
            }
            if (isAdd || index == 0)
            {
                anesInquiry = new MED_ANESTHESIA_INQUIRY();
                anesInquiry.PATIENT_ID = patientID;
                anesInquiry.VISIT_ID = visitID;
                anesInquiry.OPER_ID = operID;
                anesInquiry.INQUIRY_NO = index + 1;
                anesInquiry.INQUIRY_DATE = accountRepository.GetServerTime().Data;
            }
            return anesInquiry;
        }
        public MED_SAFETY_CHECKS GetSafetyCheckData(string patientID, int visitID, int operID)
        {
            MED_SAFETY_CHECKS safetyChecksRow = new MED_SAFETY_CHECKS();
            _safetyChecksList = operationInfoRepository.GetSafetyCheckLists(patientID, visitID, operID).Data;
            if (_safetyChecksList != null)
            {
                if (_safetyChecksList.Count == 0)
                {
                    MED_SAFETY_CHECKS newRow = new MED_SAFETY_CHECKS();
                    newRow.PATIENT_ID = patientID;
                    newRow.VISIT_ID = visitID;
                    newRow.OPER_ID = operID;
                    _safetyChecksList.Add(newRow);
                    if (operationInfoRepository.SaveSafetyCheckList(_safetyChecksList).Result == ResultStatus.Success)
                    {
                        _safetyChecksList = operationInfoRepository.GetSafetyCheckLists(patientID, visitID, operID).Data;
                    }
                }
                safetyChecksRow = _safetyChecksList[0];
            }
            return safetyChecksRow;
        }
        public MED_ANESTHESIA_PLAN GetAnesthesiaPlan(string patientID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN anesPlan = operationInfoRepository.GetAnesPlan(patientID, visitID, operID).Data;
            if (anesPlan == null)
            {
                anesPlan = new MED_ANESTHESIA_PLAN();
                anesPlan.PATIENT_ID = patientID;
                anesPlan.VISIT_ID = visitID;
                anesPlan.OPER_ID = operID;
            }
            if (string.IsNullOrEmpty(anesPlan.OPERATION_NAME))
            {
                anesPlan.OPERATION_NAME = GetOperationNamePlan(patientID, visitID, operID);
            }
            return anesPlan;
        }
        public MED_ANESTHESIA_PLAN_PMH GetAnesthesiaPlanPMH(string patientID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN_PMH anesPlanPMH = operationInfoRepository.GetAnesPlanPmh(patientID, visitID, operID).Data;
            if (anesPlanPMH == null)
            {
                anesPlanPMH = new MED_ANESTHESIA_PLAN_PMH();
                anesPlanPMH.PATIENT_ID = patientID;
                anesPlanPMH.VISIT_ID = visitID;
                anesPlanPMH.OPER_ID = operID;
            }
            return anesPlanPMH;
        }
        public MED_ANESTHESIA_PLAN_EXAM GetAnesthesiaPlanEXAM(string patientID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN_EXAM anesPlanEXAM = operationInfoRepository.GetAnesPlanExam(patientID, visitID, operID).Data;
            if (anesPlanEXAM == null)
            {
                anesPlanEXAM = new MED_ANESTHESIA_PLAN_EXAM();
                anesPlanEXAM.PATIENT_ID = patientID;
                anesPlanEXAM.VISIT_ID = visitID;
                anesPlanEXAM.OPER_ID = operID;
            }
            return anesPlanEXAM;
        }
        public MED_PAT_VISIT GetPatVisit(string patientID, int visitID)
        {
            MED_PAT_VISIT patVisit = operationInfoRepository.GetPatVisit(patientID, visitID).Data;
            if (patVisit == null)
            {
                patVisit = new MED_PAT_VISIT();
                patVisit.PATIENT_ID = patientID;
                patVisit.VISIT_ID = visitID;
            }
            return patVisit;
        }
        public MED_OPERATION_ANALGESIC_MASTER GetAnalgesicMaster(string patientid, int visitID, int operID)
        {
            MED_OPERATION_ANALGESIC_MASTER analMaster = operationInfoRepository.GetAnalgesicMaster(patientid, visitID, operID).Data;
            if (analMaster == null)
            {
                analMaster = new MED_OPERATION_ANALGESIC_MASTER();
                analMaster.PATIENT_ID = patientid;
                analMaster.VISIT_ID = visitID;
                analMaster.OPER_ID = operID;
            }
            return analMaster;
        }
        public MED_ANESTHESIA_INPUT_DATA GetAnesthestaInputData(string patientid, int visitid, int oprtid)
        {
            MED_ANESTHESIA_INPUT_DATA inputData = operationInfoRepository.GetAnesInputData(patientid, visitid, oprtid).Data;
            if (inputData == null)
            {
                inputData = new MED_ANESTHESIA_INPUT_DATA();
                inputData.PATIENT_ID = patientid;
                inputData.VISIT_ID = visitid;
                inputData.OPER_ID = oprtid;
            }
            return inputData;
        }
        public MED_OPER_RISK_ESTIMATE GetRickEstimate(string patientID, int visitID, int operID)
        {
            MED_OPER_RISK_ESTIMATE riskEstimater = operationInfoRepository.GetRickEstimate(patientID, visitID, operID).Data;
            if (riskEstimater == null)
            {
                riskEstimater = new MED_OPER_RISK_ESTIMATE();
                riskEstimater.PATIENT_ID = patientID;
                riskEstimater.VISIT_ID = visitID;
                riskEstimater.OPER_ID = operID;
            }
            return riskEstimater;
        }
        public MED_PATS_IN_HOSPITAL GetPatsInHospital(string patientID, int visitID)
        {
            MED_PATS_IN_HOSPITAL patsInHosptial = operationInfoRepository.GetPatsInHospitalByID(patientID, visitID).Data;
            if (patsInHosptial == null)
            {
                patsInHosptial = new MED_PATS_IN_HOSPITAL();
                patsInHosptial.PATIENT_ID = patientID;
                patsInHosptial.VISIT_ID = visitID;
            }
            return patsInHosptial;
        }
        private string GetOperationNamePlan(string patientId, int visitId, int operId)
        {
            string operationName = "";
            List<MED_OPERATION_SCHEDULE_NAME> scheduledName = null;
            List<MED_OPERATION_SCHEDULE> scheduleDT = operationInfoRepository.GetOperScheduleList(patientId, visitId).Data;
            scheduleDT = scheduleDT.Where(x => x.OPER_ID == operId).ToList();
            if (scheduleDT != null && scheduleDT.Count > 0)
            {
                scheduledName = operationScheduleRepository.GetOperationScheduleNameListByPatientInfo(patientId, visitId, scheduleDT[0].SCHEDULE_ID).Data;
            }
            else
            {
                scheduledName = operationScheduleRepository.GetOperationScheduleNameListByPatientInfo(patientId, visitId, operId).Data;
            }
            if (scheduledName != null && scheduledName.Count > 0)
            {
                List<string> operationNames = new List<string>();
                foreach (MED_OPERATION_SCHEDULE_NAME row in scheduledName)
                {
                    if (!string.IsNullOrEmpty(row.OPER_NAME))
                    {
                        operationNames.Add(row.OPER_NAME);
                    }
                }
                if (operationNames.Count > 0)
                {
                    operationName = string.Join(",", operationNames.ToArray());
                }
            }
            return operationName;
        }

        private string GetOperationName(string patientId, int visitId, int operId)
        {
            string operationName = "";
            List<MED_OPERATION_NAME> operNameList = operationInfoRepository.GetOperNameList(patientId, visitId, operId).Data;

            if (operNameList != null && operNameList.Count > 0)
            {
                List<string> operationNames = new List<string>();
                foreach (MED_OPERATION_NAME row in operNameList)
                {
                    if (!string.IsNullOrEmpty(row.OPER_NAME))
                    {
                        operationNames.Add(row.OPER_NAME);
                    }
                }
                if (operationNames.Count > 0)
                {
                    operationName = string.Join(",", operationNames.ToArray());
                }
            }
            return operationName;
        }

    }
}
