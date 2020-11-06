using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;
using System.Linq.Expressions;
using System.Data;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 麻醉信息接口
    /// </summary>
    public interface IAnesScoreService
    {
        List<MED_PATIENT_SCORING_RESULT> GetPatientScoringResultDt(string patientID, decimal visitID, decimal depID, string scoringMethod);
        bool UpdatePatientScoringResult(List<MED_PATIENT_SCORING_RESULT> dataList);

        List<MED_APACHE2_SCORING_RESULT> GetApache2ScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);

        List<MED_APACHE2_SCORING_RESULT> GetDataApache2(string patientID, decimal visitID, decimal depID);

        bool UpdateApache2ScoringResult(List<MED_APACHE2_SCORING_RESULT> dataList);

        List<MED_TISS_SCORING_RESULT_DETAIL> GetTissScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);

        List<MED_TISS_SCORING_RESULT_DETAIL> GetDataTiss(string patientID, decimal visitID, decimal depID);

        bool UpdateTissScoringResult(List<MED_TISS_SCORING_RESULT_DETAIL> list);

        List<MED_BALTHAZAR_SCORING_RESULT> GetBalthazar(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);

        bool UpdateBalthazar(List<MED_BALTHAZAR_SCORING_RESULT> list);

        bool UpdateChildPugh(List<MED_CHILDPUGH_SCORING_RESULT> list);

        bool UpdateGoldman(List<MED_GOLDMAN_SCORING_RESULT> list);

        List<MED_LUTZ_SCORING_RESULT> GetLutz(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);

        List<MED_LUTZ_SCORING_RESULT> GetDataLutz(string patientID, decimal visitID, decimal depID);

        bool UpdateLutzScore(List<MED_LUTZ_SCORING_RESULT> list);

        List<MED_PARS_SCORING_RESULT> GetPars(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);

        List<MED_PARS_SCORING_RESULT> GetDataPars(string patientID, decimal visitID, decimal depID);

        bool UpdateParsScore(List<MED_PARS_SCORING_RESULT> list);

        List<MED_GOLDMAN_SCORING_RESULT> GetGoldman(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);

        List<MED_GOLDMAN_SCORING_RESULT> GetDataGoldman(string patientID, decimal visitID, decimal depID);

        List<MED_CHILDPUGH_SCORING_RESULT> GetChildPugh(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);

        List<MED_BALTHAZAR_SCORING_RESULT> GetDataBalthazar(string patientID, decimal visitID, decimal depID);

        List<MED_CHILDPUGH_SCORING_RESULT> GetDataChildPugh(string patientID, decimal visitID, decimal depID);
    }

    /// <summary>
    /// 麻醉信息
    /// </summary>
    public class AnesScoreService : BaseService<AnesScoreService>, IAnesScoreService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>

        IDictService _dictService;
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        public AnesScoreService()
            : base() { }


        public AnesScoreService(IDapperContext context, IDictService dictService)
            : base(context)
        {
            _dictService = dictService;
        }
        [HttpGet]
        public virtual List<MED_APACHE2_SCORING_RESULT> GetApache2ScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_APACHE2_SCORING_RESULT> list = dapper.Set<MED_APACHE2_SCORING_RESULT>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_DATE_TIME == scoringDateTime).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_BALTHAZAR_SCORING_RESULT> GetBalthazar(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_BALTHAZAR_SCORING_RESULT> list = dapper.Set<MED_BALTHAZAR_SCORING_RESULT>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_DATE_TIME == scoringDateTime).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_CHILDPUGH_SCORING_RESULT> GetChildPugh(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_CHILDPUGH_SCORING_RESULT> list = dapper.Set<MED_CHILDPUGH_SCORING_RESULT>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_DATE_TIME == scoringDateTime).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_APACHE2_SCORING_RESULT> GetDataApache2(string patientID, decimal visitID, decimal depID)
        {
            List<MED_APACHE2_SCORING_RESULT> list = dapper.Set<MED_APACHE2_SCORING_RESULT>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_BALTHAZAR_SCORING_RESULT> GetDataBalthazar(string patientID, decimal visitID, decimal depID)
        {
            List<MED_BALTHAZAR_SCORING_RESULT> list = dapper.Set<MED_BALTHAZAR_SCORING_RESULT>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_CHILDPUGH_SCORING_RESULT> GetDataChildPugh(string patientID, decimal visitID, decimal depID)
        {
            List<MED_CHILDPUGH_SCORING_RESULT> list = dapper.Set<MED_CHILDPUGH_SCORING_RESULT>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_GOLDMAN_SCORING_RESULT> GetDataGoldman(string patientID, decimal visitID, decimal depID)
        {
            List<MED_GOLDMAN_SCORING_RESULT> list = dapper.Set<MED_GOLDMAN_SCORING_RESULT>().Select(
                  x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_LUTZ_SCORING_RESULT> GetDataLutz(string patientID, decimal visitID, decimal depID)
        {
            List<MED_LUTZ_SCORING_RESULT> list = dapper.Set<MED_LUTZ_SCORING_RESULT>().Select(
                  x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_PARS_SCORING_RESULT> GetDataPars(string patientID, decimal visitID, decimal depID)
        {
            List<MED_PARS_SCORING_RESULT> list = dapper.Set<MED_PARS_SCORING_RESULT>().Select(
                  x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_TISS_SCORING_RESULT_DETAIL> GetDataTiss(string patientID, decimal visitID, decimal depID)
        {
            List<MED_TISS_SCORING_RESULT_DETAIL> list = dapper.Set<MED_TISS_SCORING_RESULT_DETAIL>().Select(
                   x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_GOLDMAN_SCORING_RESULT> GetGoldman(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_GOLDMAN_SCORING_RESULT> list = dapper.Set<MED_GOLDMAN_SCORING_RESULT>().Select(
                    x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_DATE_TIME == scoringDateTime).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_LUTZ_SCORING_RESULT> GetLutz(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_LUTZ_SCORING_RESULT> list = dapper.Set<MED_LUTZ_SCORING_RESULT>().Select(
                    x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_DATE_TIME == scoringDateTime).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_PARS_SCORING_RESULT> GetPars(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_PARS_SCORING_RESULT> list = dapper.Set<MED_PARS_SCORING_RESULT>().Select(
                    x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_DATE_TIME == scoringDateTime).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_PATIENT_SCORING_RESULT> GetPatientScoringResultDt(string patientID, decimal visitID, decimal depID, string scoringMethod)
        {
            List<MED_PATIENT_SCORING_RESULT> list = dapper.Set<MED_PATIENT_SCORING_RESULT>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_METHOD == scoringMethod).ToList();
            return list;
        }
        [HttpGet]
        public virtual List<MED_TISS_SCORING_RESULT_DETAIL> GetTissScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_TISS_SCORING_RESULT_DETAIL> list = dapper.Set<MED_TISS_SCORING_RESULT_DETAIL>().Select(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.DEP_ID == depID && x.SCORING_DATE_TIME == scoringDateTime).ToList();
            return list;
        }
        [HttpPost]
        public virtual bool UpdateApache2ScoringResult(List<MED_APACHE2_SCORING_RESULT> dataList)
        {
            bool flag = false;
            flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool UpdateBalthazar(List<MED_BALTHAZAR_SCORING_RESULT> list)
        {
            bool flag = false;
            flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool UpdateChildPugh(List<MED_CHILDPUGH_SCORING_RESULT> list)
        {
            bool flag = false;
            flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool UpdateGoldman(List<MED_GOLDMAN_SCORING_RESULT> list)
        {
            bool flag = false;
            flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool UpdateLutzScore(List<MED_LUTZ_SCORING_RESULT> list)
        {
            bool flag = false;
            flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool UpdateParsScore(List<MED_PARS_SCORING_RESULT> list)
        {
            bool flag = false;
            flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool UpdatePatientScoringResult(List<MED_PATIENT_SCORING_RESULT> dataList)
        {
            bool flag = false;
            flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool UpdateTissScoringResult(List<MED_TISS_SCORING_RESULT_DETAIL> list)
        {
            bool flag = false;
            flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }
    }
}
