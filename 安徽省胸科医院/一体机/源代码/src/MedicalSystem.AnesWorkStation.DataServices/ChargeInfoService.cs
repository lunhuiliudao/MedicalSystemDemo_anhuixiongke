using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IChargeInfoService
    {
        List<MED_ANES_VALUATION_LIST> GetValuationList(string patientID, int visitID, int operID);
        List<MED_ANES_BILL_TEMPLET> GetBillTempletList(string templetType, string name);
        List<MED_ANES_BILL_TEMPLET> GetBillTempletList();
        List<MED_BILL_TEMPLET_MASTER> GetTempletMaster();
        List<MED_VALUATION_ITEM_LIST> GetValuationItemList();
        List<MED_EVENT_VS_VALUATION> GetEventVsValuation();
        List<MED_CHARGE_VS_EVENT> GetChargeEventInfo(string patientID, int visitID, int operID);
        bool SaveValuationList(List<MED_ANES_VALUATION_LIST> dataList);
        bool SaveBillTempletList(List<MED_ANES_BILL_TEMPLET> dataList);
    }
    /// <summary>
    /// 账号类
    /// </summary>
    public class ChargeInfoService : BaseService<ChargeInfoService>, IChargeInfoService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ChargeInfoService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ChargeInfoService(IDapperContext context)
            : base(context)
        {
        }
        /// <summary>
        /// 获取病人计价单列表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANES_VALUATION_LIST> GetValuationList(string patientID, int visitID, int operID)
        {
            List<MED_ANES_VALUATION_LIST> dataList = dapper.Set<MED_ANES_VALUATION_LIST>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();

            return dataList;
        }
        /// <summary>
        /// 获取收费模板列表
        /// </summary>
        /// <param name="templetName"></param> 
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANES_BILL_TEMPLET> GetBillTempletList(string templetType, string name)
        {
            List<MED_ANES_BILL_TEMPLET> dataList = dapper.Set<MED_ANES_BILL_TEMPLET>().Select(
                x => x.TEMPLET == name && x.ANESTHESIA_METHOD == templetType).ToList();
            return dataList;
        }
        /// <summary>
        /// 获取收费模板名称列表
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_BILL_TEMPLET_MASTER> GetTempletMaster()
        {
            List<MED_BILL_TEMPLET_MASTER> dataList = new List<MED_BILL_TEMPLET_MASTER>();
            List<MED_ANES_BILL_TEMPLET> templetList = GetBillTempletList();
            foreach (MED_ANES_BILL_TEMPLET row in templetList)
            {
                MED_BILL_TEMPLET_MASTER bill = dataList.Where(x => x.TEMPLET == row.TEMPLET).FirstOrDefault();
                if (bill == null)
                {
                    bill = new MED_BILL_TEMPLET_MASTER();
                    bill.TEMPLET = row.TEMPLET;
                    bill.TEMPLET_CLASS = row.TEMPLET_CLASS;
                    bill.INPUT_CODE = StringManage.GetPYString(bill.TEMPLET);
                    dataList.Add(bill);
                }
            }
            return dataList;
        }
        /// <summary>
        /// 获取收费模板列表
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANES_BILL_TEMPLET> GetBillTempletList()
        {
            List<MED_ANES_BILL_TEMPLET> dataList = dapper.Set<MED_ANES_BILL_TEMPLET>().Select().OrderBy(x => x.ANESTHESIA_METHOD).OrderBy(x => x.TEMPLET).ToList(); ;
            return dataList;
        }
        /// <summary>
        /// 获取计价单项目列表
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_VALUATION_ITEM_LIST> GetValuationItemList()
        {
            List<MED_VALUATION_ITEM_LIST> dataList = dapper.Set<MED_VALUATION_ITEM_LIST>().Select();
            if (dataList != null)
            {
                foreach (MED_VALUATION_ITEM_LIST row in dataList)
                    row.INPUT_CODE = StringManage.GetPYString(row.ITEM_NAME);
            }
            return dataList;
        }

        /// <summary>
        /// 获取麻醉事件对应计价单项目表信息
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_EVENT_VS_VALUATION> GetEventVsValuation()
        {
            List<MED_EVENT_VS_VALUATION> dataList = dapper.Set<MED_EVENT_VS_VALUATION>().Select();
            return dataList;
        }

        /// <summary>
        /// 获取当前患者事件表里课收费的项目
        /// </summary>
        [HttpGet]
        public virtual List<MED_CHARGE_VS_EVENT> GetChargeEventInfo(string patientID, int visitID, int operID)
        {
            string sql = string.Format(@"SELECT A.ITEM_CALSS,
       A.ITEM_CODE,
       A.ITEM_NAME,
       A.ITEM_SPEC ,
       B.EVENT_CLASS_CODE,
       B.EVENT_ITEM_CODE,
       B.VS_NO,
       B.AMOUNT,
       DICT.BILL_CLASS_NAME AS ITEM_CLASS_NAME,
       A.UNITS,C.DOSAGE
  FROM MED_VALUATION_ITEM_LIST A
  LEFT JOIN MED_EVENT_VS_VALUATION B ON A.ITEM_CALSS = B.VT_ITEM_CLASS
                                    AND A.ITEM_CODE = B.VT_ITEM_CODE
                                    LEFT JOIN MED_BILL_ITEM_CLASS_DICT DICT ON DICT.BILL_CLASS_CODE=A.ITEM_CALSS
  LEFT JOIN (SELECT PATIENT_ID,VISIT_ID,OPER_ID, EVENT_CLASS_CODE,EVENT_ITEM_NAME,EVENT_ITEM_CODE ,SUM(DOSAGE) AS DOSAGE from med_anesthesia_event
GROUP BY  PATIENT_ID,VISIT_ID,OPER_ID,EVENT_CLASS_CODE,EVENT_ITEM_NAME,EVENT_ITEM_CODE) C ON B.EVENT_CLASS_CODE=C.EVENT_CLASS_CODE AND B.EVENT_ITEM_CODE=C.EVENT_ITEM_CODE
  WHERE C.PATIENT_ID='{0}' AND C.VISIT_ID={1} AND C.OPER_ID={2}", patientID, visitID, operID);
            List<MED_CHARGE_VS_EVENT> list = dapper.Query<MED_CHARGE_VS_EVENT>(sql, null);
            return list;
        }

        /// <summary>
        /// 保存病人计价单列表
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public virtual bool SaveValuationList(List<MED_ANES_VALUATION_LIST> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        /// <summary>
        /// 保存收费模板列表
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public virtual bool SaveBillTempletList(List<MED_ANES_BILL_TEMPLET> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
    }
}
