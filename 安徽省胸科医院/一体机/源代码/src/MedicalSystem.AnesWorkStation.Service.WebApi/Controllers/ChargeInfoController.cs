using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class ChargeInfoController : BaseController
    {
        IChargeInfoService _chargeInfoService;
        public ChargeInfoController(IChargeInfoService chargeInfoService)
        {
            _chargeInfoService = chargeInfoService;
        }
        /// <summary>
        /// 获取病人计价单列表
        /// </summary>
        /// <param name="patID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANES_VALUATION_LIST>> GetValuationList(string patientID, int visitID, int operID)
        {
            List<MED_ANES_VALUATION_LIST> Data = _chargeInfoService.GetValuationList(patientID, visitID, operID);
            if (Data == null)
            {
                return Failed<List<MED_ANES_VALUATION_LIST>>("获取病人计价单列表错误。");
            }
            else
            {
                return Success(Data);
            }
        }

        /// <summary>
        /// 获取收费模板列表
        /// </summary>
        /// <param name="templetName"></param> 
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANES_BILL_TEMPLET>> GetBillTempletList(string templetType, string name)
        {
            List<MED_ANES_BILL_TEMPLET> Data = _chargeInfoService.GetBillTempletList(templetType, name);
            if (Data == null)
            {
                return Failed<List<MED_ANES_BILL_TEMPLET>>("获取收费模板列表错误。");
            }
            else
            {
                return Success(Data);
            }
        }
        /// <summary>
        /// 获取收费模板列表
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANES_BILL_TEMPLET>> GetBillTempletList()
        {
            List<MED_ANES_BILL_TEMPLET> Data = _chargeInfoService.GetBillTempletList();
            return Success(Data);
        }
        /// <summary>
        /// 获取收费模板名称列表
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_BILL_TEMPLET_MASTER>> GetTempletMaster()
        {
            List<MED_BILL_TEMPLET_MASTER> Data = _chargeInfoService.GetTempletMaster();
            return Success(Data);
        }
        /// <summary>
        /// 获取计价单项目列表
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_VALUATION_ITEM_LIST>> GetValuationItemList()
        {
            List<MED_VALUATION_ITEM_LIST> Data = _chargeInfoService.GetValuationItemList();
            return Success(Data);
        }
        /// <summary>
        /// 获取麻醉事件对应计价单项目表信息
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_EVENT_VS_VALUATION>> GetEventVsValuation()
        {
            List<MED_EVENT_VS_VALUATION> Data = _chargeInfoService.GetEventVsValuation();
            return Success(Data);
        }

        /// <summary>
        /// 获取当前患者事件表里课收费的项目
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_CHARGE_VS_EVENT>> GetChargeEventInfo(string patientID, int visitID, int operID)
        {
            List<MED_CHARGE_VS_EVENT> Data = _chargeInfoService.GetChargeEventInfo(patientID, visitID, operID);
            return Success(Data);
        }

        /// <summary>
        /// 保存病人计价单列表
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> SaveValuationList(List<MED_ANES_VALUATION_LIST> dataList)
        {
            return Success(_chargeInfoService.SaveValuationList(dataList));
        }
        /// <summary>
        /// 保存收费模板列表
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> SaveBillTempletList(List<MED_ANES_BILL_TEMPLET> dataList)
        {
            return Success(_chargeInfoService.SaveBillTempletList(dataList));
        }
    }
}
