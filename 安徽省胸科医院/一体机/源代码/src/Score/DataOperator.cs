using System;
using System.Data.Common;
using System.Data;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using System.Collections.Generic;
using MedicalSystem.AnesWorkStation.Domain;
using Com.MedicalSystem.Common.Utilities;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.Score
{
    public class DataOperator
    {
        public static string Operator
        {
            get
            {
                return ExtendAppContext.Current.LoginUser.USER_NAME;
            }
        }


        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器时间</returns>
        public static DateTime GetSysDate()
        {
            try
            {
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                Logger.Debug(ex.Message);
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 更新患者评分结果
        /// </summary>
        /// <param name="PatientScoringResultDt">患者评分结果强类型数据集</param>
        /// <returns>更新影响的行数</returns>
        public static int UpdatePatientScoringResult(List<MED_PATIENT_SCORING_RESULT> list)
        {
            return AnesScoreService.ClientInstance.UpdatePatientScoringResult(list) == true ? 1 : 0;
        }

        public static int UpdateApache2ScoringResult(List<MED_APACHE2_SCORING_RESULT> list)
        {
            return AnesScoreService.ClientInstance.UpdateApache2ScoringResult(list) == true ? 1 : 0;
        }


        /// <summary>
        /// 获取患者Apache2评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分时间</param>
        /// <returns>Apache2评分明细记录数据集</returns>
        public static List<MED_APACHE2_SCORING_RESULT> GetApache2ScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_APACHE2_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetApache2ScoringResultDt(patientID, visitID, depID, scoringDateTime);

            return list;
        }
        /// <summary>
        /// 获取患者评分结果强类型数据集
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分标准</param>
        /// <returns>评分结果强类型数据集</returns>
        public static List<MED_PATIENT_SCORING_RESULT> GetPatientScoringResultDt(string patientID, decimal visitID, decimal depID, string scoringMethod)
        {
            List<MED_PATIENT_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetPatientScoringResultDt(patientID, visitID, depID, scoringMethod);

            return list;
        }

        public static List<MED_APACHE2_SCORING_RESULT> GetDataApache2(string patientID, decimal visitID, decimal depID)
        {
            List<MED_APACHE2_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetDataApache2(patientID, visitID, depID);

            return list;
        }
        /// <summary>
        /// 获取患者Tiss评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分时间</param>
        /// <returns>Tiss评分明细记录数据集</returns>
        public static List<MED_TISS_SCORING_RESULT_DETAIL> GetTissScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_TISS_SCORING_RESULT_DETAIL> list = AnesScoreService.ClientInstance.GetTissScoringResultDt(patientID, visitID, depID, scoringDateTime);

            return list;
        }
        public static List<MED_TISS_SCORING_RESULT_DETAIL> GetDataTiss(string patientID, decimal visitID, decimal depID)
        {
            List<MED_TISS_SCORING_RESULT_DETAIL> list = AnesScoreService.ClientInstance.GetDataTiss(patientID, visitID, depID);

            return list;
        }
        /// <summary>
        /// 更新Tiss评分明细记录
        /// </summary>
        /// <param name="TissResultDt">Tiss评分强类型数据集</param>
        /// <returns>更新影响的行数</returns>
        public static int UpdateTissScoringResult(List<MED_TISS_SCORING_RESULT_DETAIL> list)
        {
            return AnesScoreService.ClientInstance.UpdateTissScoringResult(list) == true ? 1 : 0;
        }


        /// <summary>
        /// 获取患者Balthazar评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Balthazar评分明细表</returns>
        public static List<MED_BALTHAZAR_SCORING_RESULT> GetBalthazar(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_BALTHAZAR_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetBalthazar(patientID, visitID, depID, scoringDateTime);

            return list;
        }

        /// <summary>
        /// 更新Balthazar评分
        /// </summary>
        /// <param name="NortTable">Balthazar评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateBalthazar(List<MED_BALTHAZAR_SCORING_RESULT> balthazarDataList)
        {
            return AnesScoreService.ClientInstance.UpdateBalthazar(balthazarDataList) == true ? 1 : 0;
        }

        /// <summary>
        /// 更新Child-pugh评分
        /// </summary>
        /// <param name="NortTable">Child-pugh评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateChildPugh(List<MED_CHILDPUGH_SCORING_RESULT> list)
        {
            return AnesScoreService.ClientInstance.UpdateChildPugh(list) == true ? 1 : 0;
        }


        /// <summary>
        /// 更新Goldman评分
        /// </summary>
        /// <param name="NortTable">Goldman评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateGoldman(List<MED_GOLDMAN_SCORING_RESULT> list)
        {
            return AnesScoreService.ClientInstance.UpdateGoldman(list) == true ? 1 : 0;
        }
        /// <summary>
        /// 获取患者Lutz评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Lutz评分明细表</returns>
        public static List<MED_LUTZ_SCORING_RESULT> GetLutz(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_LUTZ_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetLutz(patientID, visitID, depID, scoringDateTime);

            return list;
        }
        /// <summary>
        /// 获取患者Lutz评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        public static List<MED_LUTZ_SCORING_RESULT> GetDataLutz(string patientID, decimal visitID, decimal depID)
        {
            List<MED_LUTZ_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetDataLutz(patientID, visitID, depID);

            return list;
        }
        /// <summary>
        /// 更新Lutz评分
        /// </summary>
        /// <param name="NortTable">Lutz评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateLutzScore(List<MED_LUTZ_SCORING_RESULT> list)
        {
            return AnesScoreService.ClientInstance.UpdateLutzScore(list) == true ? 1 : 0;
        }
        /// <summary>
        /// 获取患者Pars评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Pars评分明细表</returns>

        public static List<MED_PARS_SCORING_RESULT> GetPars(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_PARS_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetPars(patientID, visitID, depID, scoringDateTime);

            return list;
        }

        /// <summary>
        /// 获取患者Pars评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <returns>Pars评分明细表</returns>
        public static List<MED_PARS_SCORING_RESULT> GetDataPars(string patientID, decimal visitID, decimal depID)
        {
            List<MED_PARS_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetDataPars(patientID, visitID, depID);

            return list;
        }
        /// <summary>
        /// 更新Pars评分
        /// </summary>
        /// <param name="NortTable">Pars评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateParsScore(List<MED_PARS_SCORING_RESULT> list)
        {
            return AnesScoreService.ClientInstance.UpdateParsScore(list) == true ? 1 : 0;
        }
        /// <summary>
        /// 获取患者Goldman评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <returns>Goldman评分明细表</returns>

        /// <summary>
        /// 获取患者Goldman评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Goldman评分明细表</returns>
        public static List<MED_GOLDMAN_SCORING_RESULT> GetGoldman(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_GOLDMAN_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetGoldman(patientID, visitID, depID, scoringDateTime);

            return list;
        }

        public static List<MED_GOLDMAN_SCORING_RESULT> GetDataGoldman(string patientID, decimal visitID, decimal depID)
        {
            List<MED_GOLDMAN_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetDataGoldman(patientID, visitID, depID);

            return list;
        }
        /// <summary>
        /// 获取患者Child-pugh评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Child-pugh评分明细表</returns>
        public static List<MED_CHILDPUGH_SCORING_RESULT> GetChildPugh(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_CHILDPUGH_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetChildPugh(patientID, visitID, depID, scoringDateTime);

            return list;
        }
        public static List<MED_BALTHAZAR_SCORING_RESULT> GetDataBalthazar(string patientID, decimal visitID, decimal depID)
        {
            List<MED_BALTHAZAR_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetDataBalthazar(patientID, visitID, depID);

            return list;
        }

        /// <summary>
        /// 获取患者Child-pugh评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <returns>Child-pugh评分明细表</returns>
        public static List<MED_CHILDPUGH_SCORING_RESULT> GetDataChildPugh(string patientID, decimal visitID, decimal depID)
        {
            List<MED_CHILDPUGH_SCORING_RESULT> list = AnesScoreService.ClientInstance.GetDataChildPugh(patientID, visitID, depID);

            return list;
        }
    }
}
