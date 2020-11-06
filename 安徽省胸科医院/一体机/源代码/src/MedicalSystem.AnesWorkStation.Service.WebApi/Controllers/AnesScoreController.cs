using MedicalSystem.AnesWorkStation.DataServices;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class AnesScoreController : BaseController
    {
        IAnesScoreService _anesScoreService;
        public AnesScoreController(IAnesScoreService anesScoreService)
        {
            _anesScoreService = anesScoreService;
        }

        [HttpGet]
        public RequestResult<List<MED_APACHE2_SCORING_RESULT>> GetApache2ScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_APACHE2_SCORING_RESULT> list = _anesScoreService.GetApache2ScoringResultDt(patientID, visitID, depID, scoringDateTime);
            return Success(list);
        }
        [HttpGet]
        public RequestResult<List<MED_BALTHAZAR_SCORING_RESULT>> GetBalthazar(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_BALTHAZAR_SCORING_RESULT> list = _anesScoreService.GetBalthazar(patientID, visitID, depID, scoringDateTime);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_CHILDPUGH_SCORING_RESULT>> GetChildPugh(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_CHILDPUGH_SCORING_RESULT> list = _anesScoreService.GetChildPugh(patientID, visitID, depID, scoringDateTime);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_APACHE2_SCORING_RESULT>> GetDataApache2(string patientID, decimal visitID, decimal depID)
        {
            List<MED_APACHE2_SCORING_RESULT> list = _anesScoreService.GetDataApache2(patientID, visitID, depID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_BALTHAZAR_SCORING_RESULT>> GetDataBalthazar(string patientID, decimal visitID, decimal depID)
        {
            List<MED_BALTHAZAR_SCORING_RESULT> list = _anesScoreService.GetDataBalthazar(patientID, visitID, depID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_CHILDPUGH_SCORING_RESULT>> GetDataChildPugh(string patientID, decimal visitID, decimal depID)
        {
            List<MED_CHILDPUGH_SCORING_RESULT> list = _anesScoreService.GetDataChildPugh(patientID, visitID, depID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_GOLDMAN_SCORING_RESULT>> GetDataGoldman(string patientID, decimal visitID, decimal depID)
        {
            List<MED_GOLDMAN_SCORING_RESULT> list = _anesScoreService.GetDataGoldman(patientID, visitID, depID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_LUTZ_SCORING_RESULT>> GetDataLutz(string patientID, decimal visitID, decimal depID)
        {
            List<MED_LUTZ_SCORING_RESULT> list = _anesScoreService.GetDataLutz(patientID, visitID, depID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_PARS_SCORING_RESULT>> GetDataPars(string patientID, decimal visitID, decimal depID)
        {
            List<MED_PARS_SCORING_RESULT> list = _anesScoreService.GetDataPars(patientID, visitID, depID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_TISS_SCORING_RESULT_DETAIL>> GetDataTiss(string patientID, decimal visitID, decimal depID)
        {
            List<MED_TISS_SCORING_RESULT_DETAIL> list = _anesScoreService.GetDataTiss(patientID, visitID, depID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_GOLDMAN_SCORING_RESULT>> GetGoldman(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_GOLDMAN_SCORING_RESULT> list = _anesScoreService.GetGoldman(patientID, visitID, depID, scoringDateTime);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_LUTZ_SCORING_RESULT>> GetLutz(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_LUTZ_SCORING_RESULT> list = _anesScoreService.GetLutz(patientID, visitID, depID, scoringDateTime);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_PARS_SCORING_RESULT>> GetPars(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_PARS_SCORING_RESULT> list = _anesScoreService.GetPars(patientID, visitID, depID, scoringDateTime);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_PATIENT_SCORING_RESULT>> GetPatientScoringResultDt(string patientID, decimal visitID, decimal depID, string scoringMethod)
        {
            List<MED_PATIENT_SCORING_RESULT> list = _anesScoreService.GetPatientScoringResultDt(patientID, visitID, depID, scoringMethod);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_TISS_SCORING_RESULT_DETAIL>> GetTissScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            List<MED_TISS_SCORING_RESULT_DETAIL> list = _anesScoreService.GetTissScoringResultDt(patientID, visitID, depID, scoringDateTime);
            return Success(list);
        }

        [HttpPost]
        public RequestResult<bool> UpdateApache2ScoringResult(List<MED_APACHE2_SCORING_RESULT> list)
        {
            return Success(_anesScoreService.UpdateApache2ScoringResult(list));
        }
        [HttpPost]
        public RequestResult<bool> UpdateBalthazar(List<MED_BALTHAZAR_SCORING_RESULT> list)
        {
            return Success(_anesScoreService.UpdateBalthazar(list));
        }
        [HttpPost]
        public RequestResult<bool> UpdateChildPugh(List<MED_CHILDPUGH_SCORING_RESULT> list)
        {
            return Success(_anesScoreService.UpdateChildPugh(list));
        }
        [HttpPost]
        public RequestResult<bool> UpdateGoldman(List<MED_GOLDMAN_SCORING_RESULT> list)
        {
            return Success(_anesScoreService.UpdateGoldman(list));
        }
        [HttpPost]
        public RequestResult<bool> UpdateLutzScore(List<MED_LUTZ_SCORING_RESULT> list)
        {
            return Success(_anesScoreService.UpdateLutzScore(list));
        }
        [HttpPost]
        public RequestResult<bool> UpdateParsScore(List<MED_PARS_SCORING_RESULT> list)
        {
            return Success(_anesScoreService.UpdateParsScore(list));
        }

        [HttpPost]
        public RequestResult<bool> UpdatePatientScoringResult(List<MED_PATIENT_SCORING_RESULT> list)
        {
            return Success(_anesScoreService.UpdatePatientScoringResult(list));
        }
        [HttpPost]
        public RequestResult<bool> UpdateTissScoringResult(List<MED_TISS_SCORING_RESULT_DETAIL> list)
        {
            return Success(_anesScoreService.UpdateTissScoringResult(list));
        }
    }
}