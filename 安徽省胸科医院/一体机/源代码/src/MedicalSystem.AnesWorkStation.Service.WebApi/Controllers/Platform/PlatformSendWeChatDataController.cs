
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 微信公众号服务
    /// </summary>
    public class PlatformSendWeChatDataController : PlatformBaseController
    {
        IPlatformSendWeChatData WeiXinQuery;
        string webFrontEndUrl = AppSettings.FontEndIP;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="WeixinQueryParam"></param>
        public PlatformSendWeChatDataController(IPlatformSendWeChatData WeixinQueryParam)
        {
            WeiXinQuery = WeixinQueryParam;
        }

        #region 手术信息

        /// <summary>
        /// 传送手术信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public void SaveWeChatCloudOperInfoData()
        {
            OperQueryParaModel model = new OperQueryParaModel();
            dynamic operinfolist = WeiXinQuery.GetOperInfo(model);
            PostObject obj = new PostObject();
            obj.Data = JsonConvert.SerializeObject(operinfolist); ;
            WebApiVisitor.PostAccessApi(webFrontEndUrl + "api/FrontEndMachine/SaveWeChatCloudOperInfoData", obj);
        }



        /// <summary>
        /// 工作量-ASA-麻醉方法
        /// </summary>
        [HttpPost]
        public void SaveWeChatCloudStatisticsData(OperQueryParaModel para)
        {
            List<PostObject> list = new List<PostObject>();  //汇总list
            OperQueryParaModel model = new OperQueryParaModel();//工作量
            if (para.StartDate == "")
            {
                model.StartDate = WeiXinQuery.GetSysDate().ToString();
            }
            else
            {
                model.StartDate = para.StartDate.ToString();
            }
            model.TimeType = "month";
            dynamic listWorkTime = WeiXinQuery.QueryOperEChartReportForDirectionIndex(model);  //获取图标
            list.Add(GetPostObject("工作量明细", JsonConvert.SerializeObject(listWorkTime), model.StartDate));
            dynamic listWorkTimeDetail = WeiXinQuery.GetWeiXinOperInfo(model);//获取图标明细
            list.Add(GetPostObject("工作量", JsonConvert.SerializeObject(listWorkTimeDetail), model.StartDate));

            model.QueryType = "ASA";
            dynamic listASA = WeiXinQuery.QueryRightEChartReportForDirectionIndex(model);//获取ASA
            list.Add(GetPostObject("ASA分级", JsonConvert.SerializeObject(listASA), model.StartDate));
            model.QueryType = "AnesMethod";
            dynamic listMethod = WeiXinQuery.QueryRightEChartReportForDirectionIndex(model);//获取麻醉方式
            list.Add(GetPostObject("麻醉方式", JsonConvert.SerializeObject(listMethod), model.StartDate));

            try
            {
                WebApiVisitor.PostAccessApi(webFrontEndUrl + "api/FrontEndMachine/SaveWeChatCloudStatisticsData", list);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 工作量-ASA-麻醉方法
        /// </summary>
        [HttpPost]
        public bool SaveWeChatCloudStatisticsDataAll(OperQueryParaModel para)
        {
            DateTime start = Convert.ToDateTime(para.StartDate);
            DateTime end = Convert.ToDateTime(para.EndDate).AddMonths(1).AddDays(-1);
            OperQueryParaModel model = new OperQueryParaModel();
            bool result = false;
            if (start < end)
            {
                do
                {
                    model.StartDate = start.ToString();
                    this.SaveWeChatCloudStatisticsData(model);
                    start = start.AddMonths(1);
                    result = true;
                }
                while (start < end);
            }
            return result;
        }

        /// <summary>
        /// 获取发送对象
        /// </summary>
        /// <returns></returns>
        public PostObject GetPostObject(string childMenu,string data,string reportMonth)
        {
            PostObject obj = new PostObject();
            obj.ChildMenu = childMenu;
            obj.Data = data;
            obj.ReportMonth = reportMonth;
            obj.HospitalId = "";
            return obj;
        }
        #endregion

        #region 质控
        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void SaveWeChatCloudQuanlityData(OperQueryParaModel para)
        {
            List<MED_QC_REPORT_IND> list = WeiXinQuery.GetQuanlityControlReportInd();

            //获取服务器时间
            DateTime dt = DateTime.Now;
            if (para.StartDate == "")
            {
                dt = WeiXinQuery.GetSysDate().AddMonths(-1);
            }
            else
            {
                dt = Convert.ToDateTime( para.StartDate);
            }
            //DateTime dt = DateTime.Now.AddMonths(-3); //WeiXinQuery.GetSysDate().AddMonths(-1);

            MED_QC_REPORT_IND find = list.Find(t => t.REPORT_MONTH == (dt.ToString("yyyyMM")));

            if (find != null)
            {
                if (!string.IsNullOrEmpty(find.REPORT_NAME))
                {
                    IList<MED_QC_REPORT_LIST> reportList = WeiXinQuery.GetQuanlityControlReportBakItemList(find.REPORT_NAME);

                    find.list = reportList;
                    PostObject obj = new PostObject();
                    obj.Data = JsonConvert.SerializeObject(find);
                    obj.ReportMonth = dt.ToString();
                    try
                    {
                        WebApiVisitor.PostAccessApi(webFrontEndUrl + "api/FrontEndMachine/SaveWeChatCloudQuanlityData", obj);
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }


        /// <summary>
        /// 工作量-ASA-麻醉方法
        /// </summary>
        [HttpPost]
        public bool SaveWeChatCloudQuanlityDataAll(OperQueryParaModel para)
        {
            DateTime start = Convert.ToDateTime(para.StartDate);
            DateTime end = Convert.ToDateTime(para.EndDate).AddMonths(1).AddDays(-1);
            OperQueryParaModel model = new OperQueryParaModel();

            bool result = false;
            if (start < end)
            {
                do
                {
                    model.StartDate = start.ToString();
                    this.SaveWeChatCloudQuanlityData(model);
                    start = start.AddMonths(1);
                    result = true;
                }
                while (start < end);
            }
            return result;

        }
        #endregion


    }

    /// <summary>
    /// post对象
    /// </summary>
    public class PostObject {
        public string ChildMenu { get; set; }
        public string Data { get; set; }
        public string ReportMonth { get; set; }
        public string HospitalId { get; set; }
    }
}