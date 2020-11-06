using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Configurations;
using MedicalSystem.DataServices.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalSystem.AnesWorkStation.Domain.Origins;


namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformChargeInfoService
    {
        IList<MED_BILL_ITEM_CLASS_DICT> GetBillDict(string type);
        IList<MED_ANES_VALUATION_LIST> GetAnesValuationList(string patientID, int visitID, decimal operID);
        IList<MED_INP_BILL_DETAIL> GetBillDetailList(string patientID, int visitID, decimal operID);
        IList<MED_ANES_VT_VS_CHARGE> GetAnesVsCharge();
        IList<MED_ANES_VT_VS_CHARGE> GetAnesVsCharge(string vtItemCode);// 计价单与价表对照关系表 
        IList<MED_ANES_VT_VS_CHARGE> GetTimeoutAnesVsCharge(string vtItemCode);// 获取作为超时收费的计价单项目所对应的关系表数据 
        IList<MED_VALUATION_ITEM_LIST> GetValuationItemList(string itemClass, string itemName);
        IList<MED_VALUATION_ITEM_LIST> GetValuationItemList(string itemClass);
        IList<MED_TEMPLET_BILL_MENU> GetTempletBillMenu();
        IList<MED_ANES_BILL_TEMPLET> GetAnesBillTemplet(string TEMPLET, string ANESTHESIA_METHOD);
        IList<MED_PRICE_LIST> GetPriceList(string itemClass);// 连接价表
        IList<OperQuerytForAnesQueryEntity> GetChargePatientList(OperQueryParaModel model);
        List<string> GetTempletNameList();
        IList<MED_ANESTHESIA_EVENT> GetAnesthesiaEvent(string patientID, int visitID, int operID);
        int DeleteAnesBillTemplete(int type, MED_ANES_BILL_TEMPLET model);
        int EditAnesBillTemplete(int type, MED_ANES_BILL_TEMPLET model);
        int EditMedValuationItemList(int type, MED_VALUATION_ITEM_LIST MedValuationItemList);// 计价单编辑数据
        int DeletedMedValuationItemList(List<MED_VALUATION_ITEM_LIST> MedValuationItemList);// 计价单删除数据
        int DeleteBillDetail(MED_INP_BILL_DETAIL billDetailList);//删除收费明细数据
        IList<MED_INP_BILL_DETAIL> SaveBillDetail(List<MED_INP_BILL_DETAIL> billDetailList, string verifiedBy);//保存收费明细数据
        int EditAnesVsCharge(int type, MED_ANES_VT_VS_CHARGE anesVsCharge);// 关系表编辑数据
        int EditAnesVsCharge(List<MED_ANES_VT_VS_CHARGE> anesVsCharge);//批量更新关系表数据
        int DeletedAnesVsCharge(List<MED_ANES_VT_VS_CHARGE> anesVsCharge);// 关系表删除数据
    }
    public class PlatformChargeInfoService : BaseService<PlatformChargeInfoService>, IPlatformChargeInfoService
    {
        IMdkConfiguration mdkConfig;
        protected PlatformChargeInfoService()
            : base()
        { }
        public PlatformChargeInfoService(IDapperContext context)
            : base(context)
        {
            MdkConfiguration.AddCustomConfig<XmlDictConfig>();
            mdkConfig = MdkConfiguration.GetConfig();
        }

        [HttpGet]
        public IList<MED_BILL_ITEM_CLASS_DICT> GetBillDict(string type)
        {
            return dapper.Set<MED_BILL_ITEM_CLASS_DICT>().Select(x => x.TYPE == type);
        }
        [HttpGet]
        /// <summary>
        /// 获取病人计价单
        /// </summary>
        /// <param name="patientID">患者ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        public IList<MED_ANES_VALUATION_LIST> GetAnesValuationList(string patientID, int visitID, decimal operID)
        {
            string sql = sqlDict.GetSQLByKey("GetAnesValuationQuery");

            return dapper.Set<MED_ANES_VALUATION_LIST>().Query(sql, new
            {
                patientID = patientID,
                visitID = visitID,
                operID = operID,
            });

        }
        public IList<AddDetailCharge> GetAddDetailCharge(string ItemCode)
        {
            string sql = sqlDict.GetSQLByKey("GetAddQuery");

            return dapper.Set<AddDetailCharge>().Query(sql, new
            {
                ItemCode = ItemCode,
            });
        }
        [HttpGet]
        /// <summary>
        /// 获取病人费用明细记录
        /// </summary>
        /// <param name="patientID">患者ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        public IList<MED_INP_BILL_DETAIL> GetBillDetailList(string patientID, int visitID, decimal operID)
        {
            List<MED_INP_BILL_DETAIL> billDetail = new List<MED_INP_BILL_DETAIL>();
            string sql = sqlDict.GetSQLByKey("GetBillDetailQuery");
            billDetail = dapper.Set<MED_INP_BILL_DETAIL>().Query(sql, new
            {
                patientID = patientID,
                visitID = visitID,
                operID = operID,
            });
            if (billDetail.Count == 0)
            {
                IList<MED_ANES_VALUATION_LIST> valuationList = GetAnesValuationList(patientID, visitID, operID);
                foreach (MED_ANES_VALUATION_LIST val in valuationList)
                {
                    MED_INP_BILL_DETAIL detail = new MED_INP_BILL_DETAIL();
                    detail.PATIENT_ID = val.PATIENT_ID;
                    detail.VISIT_ID = val.VISIT_ID;
                    detail.OPER_ID = val.OPER_ID;
                    detail.ITEM_NO = billDetail.Count + 1;
                    detail.ITEM_CLASS = val.PRICE_CLASS;
                    detail.PRICE_CLASS_NAME = val.PRICE_CLASS_NAME;
                    detail.ANES_ITEM_NAME = val.ANES_ITEM_NAME;
                    detail.ITEM_CODE = val.PRICE_CODE;
                    detail.ITEM_NAME = val.PRICE_NAME;
                    detail.ITEM_SPEC = val.PRICE_SPEC;
                    detail.UNITS = val.UNITS;
                    detail.PRICE = val.PRICE;
                    detail.AMOUNT = val.AMOUNT.HasValue ? val.AMOUNT : 1;
                    detail.METHOD = val.METHOD;
                    detail.TECHNICIAN = val.TECHNICIAN;
                    detail.ORDERED_BY = val.ORDERED_BY;
                    detail.BILLING_DATE_TIME = val.BILLING_DATE_TIME;
                    //if (!string.IsNullOrEmpty(val.PRICE_METHOD) && val.PRICE_METHOD.Equals("1"))
                    //{
                    //    detail.COSTS = val.PRICE;
                    //    detail.CHARGES = (string.IsNullOrEmpty(val.BILL_INDICATOR) || val.BILL_INDICATOR == "T") ? detail.COSTS * (val.SPEC.HasValue ? val.SPEC : 1) : 0;

                    //}
                    //else if (!string.IsNullOrEmpty(val.PRICE_METHOD) && val.PRICE_METHOD.Equals("3"))
                    //{
                    //    detail.COSTS = val.PRICE * (val.DOSAGE / val.BASE_TIME);
                    //    detail.CHARGES = (string.IsNullOrEmpty(val.BILL_INDICATOR) || val.BILL_INDICATOR == "T") ? detail.COSTS * (val.SPEC.HasValue ? val.SPEC : 1) : 0;
                    //}
                    //else
                    {
                        detail.COSTS = val.PRICE * val.AMOUNT;
                        detail.CHARGES = detail.COSTS * (val.SPEC.HasValue ? val.SPEC : 1);
                    }
                    detail.EXCHANGE_STATUS = 0;
                    billDetail.Add(detail);
                }
            }
            return billDetail;
        }
        public MED_INP_BILL_DETAIL AddInpBillDetail(AddDetailCharge val, string patientID, int visitID, int operID, int count)
        {
            MED_INP_BILL_DETAIL detail = new MED_INP_BILL_DETAIL();
            detail.PATIENT_ID = patientID;
            detail.VISIT_ID = visitID;
            detail.OPER_ID = operID;
            detail.ITEM_NO = count;
            detail.ITEM_CLASS = val.PRICE_CLASS;
            detail.PRICE_CLASS_NAME = val.PRICE_CLASS_NAME;
            detail.ANES_ITEM_NAME = val.ANES_ITEM_NAME;
            detail.ITEM_CODE = val.PRICE_CODE;
            detail.ITEM_NAME = val.PRICE_NAME;
            detail.ITEM_SPEC = val.PRICE_SPEC;
            //detail.UNITS = val.UNITS;
            //detail.PRICE = val.PRICE;
            //detail.AMOUNT = val.AMOUNT.HasValue ? val.AMOUNT : 1;
            //detail.METHOD = val.METHOD;
            //detail.TECHNICIAN = val.TECHNICIAN;
            //detail.ORDERED_BY = val.ORDERED_BY;
            //detail.BILLING_DATE_TIME = val.BILLING_DATE_TIME;
            //if (string.IsNullOrEmpty(val.BILL_INDICATOR) || val.BILL_INDICATOR == "T")
            //{
            //    detail.COSTS = val.PRICE * val.AMOUNT;
            //    detail.CHARGES = detail.COSTS * (val.SPEC.HasValue ? val.SPEC : 1);
            //}
            //if (!string.IsNullOrEmpty(val.ITEM_CODE_ADD))
            //{
            //    IList<AddDetailCharge> chargsList = GetAddDetailCharge(val.ITEM_CODE_ADD);
            //    if (chargsList.Count > 0)
            //    {

            //    }
            //}
            detail.EXCHANGE_STATUS = 0;
            return detail;
        }
        [HttpGet]
        /// <summary>
        /// 计价单与价表对照关系表
        /// </summary> 
        /// <returns></returns>
        public IList<MED_ANES_VT_VS_CHARGE> GetAnesVsCharge()
        {
            return dapper.Set<MED_ANES_VT_VS_CHARGE>().Select();
        }

        /// <summary>
        /// 通过计价单的Item_Code获取对应的“计价单与价表对照关系表”数据
        /// </summary>
        /// <param name="vtItemCode"></param>
        /// <returns></returns>
        [HttpGet]
        public IList<MED_ANES_VT_VS_CHARGE> GetAnesVsCharge(string vtItemCode)
        {
            return dapper.Set<MED_ANES_VT_VS_CHARGE>().Select(d => d.VT_ITEM_CODE == vtItemCode);
        }
        /// <summary>
        /// 获取作为超时收费的计价单项目所对应的关系表数据 
        /// </summary>
        /// <param name="vtItemCode"></param>
        /// <returns></returns>
        [HttpGet]
        public IList<MED_ANES_VT_VS_CHARGE> GetTimeoutAnesVsCharge(string vtItemCode)
        {
            return dapper.Set<MED_ANES_VT_VS_CHARGE>().Select(d => d.ITEM_CODE_ADD == vtItemCode);
        }
        [HttpGet]
        /// <summary>
        /// 获取模版菜单列表
        /// </summary>
        /// <returns></returns>
        public IList<MED_TEMPLET_BILL_MENU> GetTempletBillMenu()
        {
            string sql = "SELECT A.ANESTHESIA_METHOD,A.TEMPLET AS TEMPLET_NAME  FROM MED_ANES_BILL_TEMPLET A  GROUP BY A.ANESTHESIA_METHOD,A.TEMPLET";
            List<MED_TEMPLET_BILL_MENU> list = dapper.Query<MED_TEMPLET_BILL_MENU>(sql, null);
            return list;
        }
        [HttpGet]
        /// <summary>
        /// 获取模版列表
        /// </summary>
        /// <returns></returns>
        public IList<MED_ANES_BILL_TEMPLET> GetAnesBillTemplet(string TEMPLET, string ANESTHESIA_METHOD)
        {
            string sql = @"SELECT B.BILL_CLASS_NAME,A.*
FROM MED_ANES_BILL_TEMPLET A
LEFT JOIN MED_BILL_ITEM_CLASS_DICT B ON A.ITEM_CLASS = B.BILL_CLASS_CODE
WHERE A.TEMPLET = '" + TEMPLET + "'  AND A.ANESTHESIA_METHOD='" + ANESTHESIA_METHOD + "' ORDER BY A.ITEM_NO";
            List<MED_ANES_BILL_TEMPLET> list = dapper.Query<MED_ANES_BILL_TEMPLET>(sql, null);
            return list;
        }

        public IList<MED_VALUATION_ITEM_LIST> GetValuationItemList(string itemClass, string itemName)
        {
            bool flag = string.IsNullOrEmpty(itemName);
            return dapper.Set<MED_VALUATION_ITEM_LIST>().Select(d => d.ITEM_CLASS == itemClass && (flag || d.ITEM_NAME.Contains(itemName)));
        }
        [HttpGet]
        public IList<MED_VALUATION_ITEM_LIST> GetValuationItemList(string itemClass)
        {
            // modified by joysola on 2018-5-25、6-1 增加 查询所有计价单数据的方法
            List<MED_VALUATION_ITEM_LIST> list = new List<MED_VALUATION_ITEM_LIST>();
            if (string.IsNullOrEmpty(itemClass))
            {
                // 先按类别排序，再在统一类别下按编码排序
                list = dapper.Set<MED_VALUATION_ITEM_LIST>().Select().OrderBy(d => d.ITEM_CLASS).ThenBy(d => Convert.ToInt32(d.ITEM_CODE)).ToList();// ToList()方法不能少，否则返回null

            }
            else
            {
                list = dapper.Set<MED_VALUATION_ITEM_LIST>().Select(d => d.ITEM_CLASS == itemClass);
            }
            //modified end
            return list;
        }
        [HttpGet]
        public List<string> GetTempletNameList()
        {
            List<string> templtList = new List<string>();
            List<MED_ANES_BILL_TEMPLET> billList = new List<MED_ANES_BILL_TEMPLET>();
            foreach (MED_ANES_BILL_TEMPLET bill in billList)
            {
                if (!templtList.Contains(bill.TEMPLET)) templtList.Add(bill.TEMPLET);
            }
            return templtList;
        }
        [HttpGet]
        public IList<MED_ANESTHESIA_EVENT> GetAnesthesiaEvent(string patientID, int visitID, int operID)
        {
            string sql = sqlDict.GetSQLByKey("GetAnesEventQuery");

            return dapper.Set<MED_ANESTHESIA_EVENT>().Query(sql, new
            {
                patientID = patientID,
                visitID = visitID,
                operID = operID,
            });
        }
        [HttpGet]
        public IList<MED_PRICE_LIST> GetPriceList(string itemClass)
        {
            DapperContext context = new DapperContext("ChargeConnString");
            bool flag = string.IsNullOrEmpty(itemClass);
            List<MED_PRICE_LIST> priceList = context.Set<MED_PRICE_LIST>().Select(d => flag || d.ITEM_CLASS.Contains(itemClass));
            foreach (MED_PRICE_LIST row in priceList)
            {
                row.INPUT_CODE = StringManage.GetPYString(row.ITEM_NAME);
            }
            return priceList;
        }
        [HttpPost]
        public IList<OperQuerytForAnesQueryEntity> GetChargePatientList(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetChargePatientQuery");
            DateTime? startTime = null;
            DateTime? endTime = null;
            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                startTime = Convert.ToDateTime(model.StartDate);
                endTime = Convert.ToDateTime(model.EndDate).AddDays(1);
            }
            return dapper.Set<OperQuerytForAnesQueryEntity>().Query(sql, new
            {
                STATUS = model.StatusType.Equals("已审核") ? "2" : "1",
                PatName = model.PatName,
                InpNo = model.InpNo,
                AnesDoctor = model.AnesDoctor,
                StartDate = startTime,
                EndDate = endTime,
            });
        }
        [HttpPost]
        public int DeleteAnesBillTemplete(int type, MED_ANES_BILL_TEMPLET model)
        {
            int result = 0;

            if (model == null)
            {
                return -1;
            }
            else
            {
                if (type == 0)
                {
                    //删除模版事件
                    result = dapper.Set<MED_ANES_BILL_TEMPLET>().Delete(d => d.TEMPLET == model.TEMPLET && d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD && d.ITEM_CLASS == model.ITEM_CLASS
                    && d.ITEM_NO == model.ITEM_NO);
                }
                else
                {
                    //删除模版
                    result = dapper.Set<MED_ANES_BILL_TEMPLET>().Delete(d => d.TEMPLET == model.TEMPLET && d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD);
                }
                dapper.SaveChanges();
                return result;
            }
        }
        [HttpPost]
        public int EditAnesBillTemplete(int type, MED_ANES_BILL_TEMPLET model)
        {
            int result = 0;
            if (type == 0)   //新增
            {
                MED_ANES_BILL_TEMPLET newModel = new MED_ANES_BILL_TEMPLET();
                newModel.TEMPLET = model.TEMPLET;
                newModel.ANESTHESIA_METHOD = model.ANESTHESIA_METHOD;
                newModel.TEMPLET_CLASS = model.TEMPLET_CLASS;

                MED_ANES_BILL_TEMPLET obj = dapper.Set<MED_ANES_BILL_TEMPLET>().Select(p => p.TEMPLET == model.TEMPLET && p.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD).OrderByDescending(x => x.ITEM_NO).FirstOrDefault();
                int maxItemId = 0;
                if (obj != null)
                {
                    maxItemId = Convert.ToInt32(obj.ITEM_NO);
                }
                newModel.ITEM_NO = maxItemId + 1;
                newModel.ITEM_CLASS = model.ITEM_CLASS;
                newModel.ITEM_CODE = model.ITEM_CODE;
                newModel.ITEM_NAME = model.ITEM_NAME;
                newModel.ITEM_SPEC = model.ITEM_SPEC;
                newModel.UNITS = model.UNITS;
                newModel.AMOUNT = model.AMOUNT;
                result = dapper.Set<MED_ANES_BILL_TEMPLET>().Insert(newModel) ? 1 : 0;
            }
            else  //修改
            {
                MED_ANES_BILL_TEMPLET newModel = dapper.Set<MED_ANES_BILL_TEMPLET>().Single(d => d.TEMPLET == model.TEMPLET && d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD && d.ITEM_NO == model.ITEM_NO);
                newModel.ITEM_CLASS = model.ITEM_CLASS;
                newModel.ITEM_CODE = model.ITEM_CODE;
                newModel.ITEM_NAME = model.ITEM_NAME;
                newModel.ITEM_SPEC = model.ITEM_SPEC;
                newModel.UNITS = model.UNITS;
                newModel.AMOUNT = model.AMOUNT;
                result = dapper.Set<MED_ANES_BILL_TEMPLET>().Update(newModel, null, d => d.TEMPLET == model.TEMPLET && d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD && d.ITEM_NO == model.ITEM_NO) > 0 ? 1 : 0;

            }
            dapper.SaveChanges();
            return result;
        }


        /// <summary>
        /// 编辑计价单数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedValuationItemList"></param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int EditMedValuationItemList(int type, MED_VALUATION_ITEM_LIST MedValuationItemList)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_VALUATION_ITEM_LIST>().Single(d => d.ITEM_CODE == MedValuationItemList.ITEM_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    int maxItemCode = dapper.Set<MED_VALUATION_ITEM_LIST>().Select().Max(d => Convert.ToInt32(d.ITEM_CODE));// 获取整个计价单中最大的ITEM_CODE
                    MedValuationItemList.ITEM_CODE = (maxItemCode + 1).ToString();

                    result = dapper.Set<MED_VALUATION_ITEM_LIST>().Insert(MedValuationItemList) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_VALUATION_ITEM_LIST>().Update(MedValuationItemList) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }

        /// <summary>
        /// 删除计价单数据
        /// </summary>
        /// <param name="MedValuationItemList">要删除的计价单数据</param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int DeletedMedValuationItemList(List<MED_VALUATION_ITEM_LIST> MedValuationItemList)
        {
            int result = dapper.Set<MED_VALUATION_ITEM_LIST>().Delete(MedValuationItemList);

            //modified by joysola on 2018-6-13 联动删除 麻醉收费模板对应数据、对照表对应数据
            if (MedValuationItemList[0] != null)
            {
                // 取临时变量，用于下面的lambda表达式
                MED_VALUATION_ITEM_LIST tempData = MedValuationItemList[0];


                int temp1 = dapper.Set<MED_ANES_BILL_TEMPLET>().Delete(d => d.ITEM_CLASS == tempData.ITEM_CLASS && d.ITEM_CODE == tempData.ITEM_CODE);
                int temp2 = dapper.Set<MED_ANES_VT_VS_CHARGE>().Delete(d => d.VT_ITEM_CALSS == tempData.ITEM_CLASS && d.VT_ITEM_CODE == tempData.ITEM_CODE);

                // 以下方法会报错
                //int temp3 = dapper.Set<MED_ANES_BILL_TEMPLET>().Delete(d => d.ITEM_CLASS == MedValuationItemList[0].ITEM_CLASS && d.ITEM_CODE == MedValuationItemList[0].ITEM_CODE);
                //int temp4 = dapper.Set<MED_ANES_VT_VS_CHARGE>().Delete(d => d.VT_ITEM_CALSS == MedValuationItemList[0].ITEM_CLASS && d.VT_ITEM_CODE == MedValuationItemList[0].ITEM_CODE);
            }
            //modified end 
            dapper.SaveChanges();
            return result;
        }

        /// <summary>
        /// 保存收费明细数据
        /// </summary>
        /// <param name="billDetailList"></param>
        /// <param name="verifiedBy"></param>
        /// <returns></returns>
        public IList<MED_INP_BILL_DETAIL> SaveBillDetail(List<MED_INP_BILL_DETAIL> billDetailList, string verifiedBy)
        {
            int result = 0;
            int maxItemId = 0;
            if (billDetailList != null && billDetailList.Count > 0)
            {
                string patientID = billDetailList[0].PATIENT_ID;
                int visitID = billDetailList[0].VISIT_ID;
                int operID = billDetailList[0].OPER_ID;
                var obj = dapper.Set<MED_INP_BILL_DETAIL>().Select(p => p.PATIENT_ID == patientID && p.VISIT_ID == visitID && p.OPER_ID == operID).OrderByDescending(x => x.ITEM_NO).FirstOrDefault();
                if (obj != null)
                {
                    maxItemId = obj.ITEM_NO;
                }
            }
            foreach (MED_INP_BILL_DETAIL detail in billDetailList)
            {
                if (string.IsNullOrEmpty(detail.ITEM_NO.ToString()) || (detail.ITEM_NO == 0 && detail.EXCHANGE_STATUS != 1))
                {
                    detail.ITEM_NO = maxItemId + 1;
                    maxItemId++;
                }
                detail.VERIFIED_DATE_TIME = DateTime.Now;
                detail.VERIFIED_BY = verifiedBy;
                detail.EXCHANGE_STATUS = 1;
                switch (detail.ModelStatus)
                {
                    case ModelStatus.Default:
                    case ModelStatus.Modeified:
                        result += dapper.Set<MED_INP_BILL_DETAIL>().Save(detail) ? 1 : 0;
                        break;
                    case ModelStatus.Add:
                        result += dapper.Set<MED_INP_BILL_DETAIL>().Save(detail) ? 1 : 0;
                        break;
                    case ModelStatus.Deleted:
                        result += dapper.Set<MED_INP_BILL_DETAIL>().Delete(detail) ? 1 : 0;
                        break;
                    default: break;
                }
            }
            dapper.SaveChanges();
            return billDetailList;
        }
        /// <summary>
        /// 删除收费明细数据
        /// </summary>
        /// <param name="billDetailList"></param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int DeleteBillDetail(MED_INP_BILL_DETAIL billDetailList)
        {
            int result = dapper.Set<MED_INP_BILL_DETAIL>().Delete(d => d.PATIENT_ID == billDetailList.PATIENT_ID && d.VISIT_ID == billDetailList.VISIT_ID && d.OPER_ID == billDetailList.OPER_ID &&
            d.ITEM_NO == billDetailList.ITEM_NO);
            dapper.SaveChanges();
            return result;
        }

        /// <summary>
        /// 编辑关系表数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="anesVsCharge">关系表数据</param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int EditAnesVsCharge(int type, MED_ANES_VT_VS_CHARGE anesVsCharge)
        {
            int result = 0;
            anesVsCharge.SPEC = anesVsCharge.SPEC / 100;
            if (type == 0)
            {
                //由于 价表没有主键，所以不进行重复项区分
                //if (dapper.Set<MED_ANES_VT_VS_CHARGE>().Single(d => d.ITEM_CODE == anesVsCharge.ITEM_CODE) != null)
                //{
                //    result = 2;
                //}
                //else
                // {
                List<MED_ANES_VT_VS_CHARGE> tempList = dapper.Set<MED_ANES_VT_VS_CHARGE>().Select(d => d.VT_ITEM_CODE == anesVsCharge.VT_ITEM_CODE);
                int maxNo = tempList.Count == 0 ? 0 : tempList.Max(d => d.VS_NO);// 如果是第一项，则序号为0，不写会报错
                anesVsCharge.VS_NO = maxNo + 1;// 插入时自动序号加一
                result = dapper.Set<MED_ANES_VT_VS_CHARGE>().Insert(anesVsCharge) ? 1 : 0;
                // }
            }
            else
            {
                result = dapper.Set<MED_ANES_VT_VS_CHARGE>().Update(anesVsCharge) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        /// <summary>
        /// 批量更新关系表数据（主要是折扣）
        /// </summary>
        /// <param name="anesVsCharge">计价单数据</param>
        /// <returns</returns>
        public int EditAnesVsCharge(List<MED_ANES_VT_VS_CHARGE> anesVsCharge)
        {
            foreach (MED_ANES_VT_VS_CHARGE item in anesVsCharge)
            {
                item.SPEC = item.SPEC / 100;
            }
            int result = dapper.Set<MED_ANES_VT_VS_CHARGE>().Update(anesVsCharge);
            dapper.SaveChanges();
            return result;
        }
        /// <summary>
        /// 删除关系表数据
        /// </summary>
        /// <param name="anesVsCharge">关系表数据</param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int DeletedAnesVsCharge(List<MED_ANES_VT_VS_CHARGE> anesVsCharge)
        {
            foreach (MED_ANES_VT_VS_CHARGE item in anesVsCharge)
            {
                item.SPEC = item.SPEC / 100;
            }

            int result = dapper.Set<MED_ANES_VT_VS_CHARGE>().Delete(anesVsCharge);
            dapper.SaveChanges();
            return result;
        }
    }
}