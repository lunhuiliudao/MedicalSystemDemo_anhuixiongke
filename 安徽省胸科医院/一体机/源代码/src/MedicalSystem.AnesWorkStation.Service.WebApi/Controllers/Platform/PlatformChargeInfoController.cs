
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    public class PlatformChargeInfoController : PlatformBaseController
    {
        IPlatformChargeInfoService ChargeInfo;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ChargeInfoParam"></param> 
        public PlatformChargeInfoController(IPlatformChargeInfoService ChargeInfoParam)
        {
            ChargeInfo = ChargeInfoParam;
        }
        [HttpGet]
        public RequestResult<dynamic> GetBillDict(string type)
        {
            IList<MED_BILL_ITEM_CLASS_DICT> BillDict = ChargeInfo.GetBillDict(type);
            return Success<dynamic>(BillDict);
        }
        [HttpGet]
        public RequestResult<IList<MED_ANES_VALUATION_LIST>> GetAnesValuationList(string patientID, int visitID, decimal operID)
        {
            return Success<IList<MED_ANES_VALUATION_LIST>>(ChargeInfo.GetAnesValuationList(patientID, visitID, operID));
        }
        [HttpGet]
        public RequestResult<IList<MED_INP_BILL_DETAIL>> GetBillDetailList(string patientID, int visitID, decimal operID)
        {
            return Success<IList<MED_INP_BILL_DETAIL>>(ChargeInfo.GetBillDetailList(patientID, visitID, operID));
        }
        [HttpGet]
        public RequestResult<IList<MED_ANES_VT_VS_CHARGE>> GetAnesVsCharge()
        {
            return Success<IList<MED_ANES_VT_VS_CHARGE>>(ChargeInfo.GetAnesVsCharge());
        }

        /// <summary>
        /// 获取 计价单与价表关系表 的数据
        /// </summary>
        /// <param name="vtItemCode">计价单的Item_Code</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_ANES_VT_VS_CHARGE>> GetAnesVsCharge(string vtItemCode)
        {
            return Success<IList<MED_ANES_VT_VS_CHARGE>>(ChargeInfo.GetAnesVsCharge(vtItemCode));
        }

        /// <summary>
        /// 获取作为超时收费的计价单项目所对应的关系表数据 
        /// </summary>
        /// <param name="vtItemCode">计价单的Item_Code</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_ANES_VT_VS_CHARGE>> GetTimeoutAnesVsCharge(string vtItemCode)
        {
            return Success<IList<MED_ANES_VT_VS_CHARGE>>(ChargeInfo.GetTimeoutAnesVsCharge(vtItemCode));
        }

        /// <summary>
        /// 获取计价表列表
        /// </summary>
        /// <param name="itemClass">类型</param>
        /// <param name="itemName">名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetValuationItemList(string itemClass, string itemName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_VALUATION_ITEM_LIST> MedEventDictList = ChargeInfo.GetValuationItemList(itemClass, itemName);
            dynamic dynamicInfo = new { Total = MedEventDictList.Count, CurrentData = MedEventDictList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        [HttpGet]
        public RequestResult<IList<MED_VALUATION_ITEM_LIST>> GetValuationItemList(string itemClass)
        {
            return Success(ChargeInfo.GetValuationItemList(itemClass));
        }
        [HttpGet]
        public RequestResult<IList<MED_TEMPLET_BILL_MENU>> GetTempletBillMenu()
        {
            return Success<IList<MED_TEMPLET_BILL_MENU>>(ChargeInfo.GetTempletBillMenu());
        }
        [HttpGet]
        public RequestResult<IList<MED_ANES_BILL_TEMPLET>> GetAnesBillTemplet(string TEMPLET, string ANESTHESIA_METHOD)
        {
            return Success<IList<MED_ANES_BILL_TEMPLET>>(ChargeInfo.GetAnesBillTemplet(TEMPLET, ANESTHESIA_METHOD));
        }
        [HttpGet]
        public RequestResult<List<string>> GetTempletNameList()
        {
            return Success<List<string>>(ChargeInfo.GetTempletNameList());
        }
        [HttpGet]
        public RequestResult<IList<MED_ANESTHESIA_EVENT>> GetAnesthesiaEvent(string patientID, int visitID, int operID)
        {
            return Success<IList<MED_ANESTHESIA_EVENT>>(ChargeInfo.GetAnesthesiaEvent(patientID, visitID, operID));
        }
        [HttpGet]
        public RequestResult<IList<MED_PRICE_LIST>> GetPriceList(string itemClass)
        {
            return Success<IList<MED_PRICE_LIST>>(ChargeInfo.GetPriceList(itemClass));
        }
        [HttpPost]
        public RequestPageResult<IList<OperQuerytForAnesQueryEntity>> GetChargePatientList(OperQueryParaModel model)
        {
            IList<OperQuerytForAnesQueryEntity> list = ChargeInfo.GetChargePatientList(model);
            return PageSuccess(list, 0, 0, list.Count);
        }
        [HttpPost]
        public RequestResult<int> DeleteAnesBillTemplete(int type, MED_ANES_BILL_TEMPLET model)
        {
            return Success(ChargeInfo.DeleteAnesBillTemplete(type, model));
        }
        [HttpPost]
        public RequestResult<int> EditAnesBillTemplete(int type, MED_ANES_BILL_TEMPLET model)
        {
            return Success(ChargeInfo.EditAnesBillTemplete(type, model));
        }


        /// <summary>
        /// 编辑计价单数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedValuationItemList">计价单记录</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditMedValuationItemList(int type, MED_VALUATION_ITEM_LIST MedValuationItemList)
        {
            return Success(ChargeInfo.EditMedValuationItemList(type, MedValuationItemList));
        }
        /// <summary>
        /// 删除计价单数据
        /// </summary>
        /// <param name="MedValuationItemList">计价单记录</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedMedValuationItemList(List<MED_VALUATION_ITEM_LIST> MedValuationItemList)
        {
            return Success(ChargeInfo.DeletedMedValuationItemList(MedValuationItemList));
        }
        /// <summary>
        /// 删除收费明细数据
        /// </summary>
        /// <param name="billDetailList">收费明细</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeleteBillDetail(MED_INP_BILL_DETAIL billDetailList)
        {
            return Success(ChargeInfo.DeleteBillDetail(billDetailList));
        }
        /// <summary>
        /// 保存收费明细数据
        /// </summary>
        /// <param name="verifiedBy">审核人</param>
        /// <param name="billDetailList">收费明细</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<IList<MED_INP_BILL_DETAIL>> SaveBillDetail([FromUri]string verifiedBy, List<MED_INP_BILL_DETAIL> billDetailList)
        {
            return Success(ChargeInfo.SaveBillDetail(billDetailList, verifiedBy));
        }

        /// <summary>
        /// 编辑关系表数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="AnesVsCharge">计价单记录</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditAnesVsCharge(int type, MED_ANES_VT_VS_CHARGE AnesVsCharge)
        {
            return Success(ChargeInfo.EditAnesVsCharge(type, AnesVsCharge));
        }
        /// <summary>
        /// 批量更新关系表数据
        /// </summary>
        /// <param name="AnesVsCharge">计价单数据</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditAnesVsCharge(List<MED_ANES_VT_VS_CHARGE> AnesVsCharge)
        {
            return Success(ChargeInfo.EditAnesVsCharge(AnesVsCharge));
        }
        /// <summary>
        /// 删除关系表数据
        /// </summary>
        /// <param name="AnesVsCharge">计价单记录</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedAnesVsCharge(List<MED_ANES_VT_VS_CHARGE> AnesVsCharge)
        {
            return Success(ChargeInfo.DeletedAnesVsCharge(AnesVsCharge));
        }
    }
}