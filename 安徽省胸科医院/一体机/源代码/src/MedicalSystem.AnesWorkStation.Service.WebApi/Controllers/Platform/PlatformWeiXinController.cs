
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System.Collections.Generic;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 微信公众号服务
    /// </summary>
    public class PlatformWeiXinController : PlatformBaseController
    {
        IPlatformWeiXinService WeiXinQuery;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="WeixinQueryParam"></param>
        public PlatformWeiXinController(IPlatformWeiXinService WeixinQueryParam)
        {
            WeiXinQuery = WeixinQueryParam;
        }

        #region 手术信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RequestResult<dynamic> QueryOperInfo(OperQueryParaModel model)
        {
            return Success(WeiXinQuery.GetOperInfo(model));
        }
        #endregion

        #region 统计
        /// <summary>
        /// 工作量统计
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> QueryWeiXinOperInfo(OperQueryParaModel modela)
        {
            return Success(WeiXinQuery.GetWeiXinOperInfo(modela));
        }

        /// <summary>
        /// 手术信息EChart图标统计
        /// </summary>
        /// <param name="modela"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<IList<dynamic>> QueryOperEChartReportForDirectionIndex(OperQueryParaModel modela)
        {

            IList<dynamic> list = WeiXinQuery.QueryOperEChartReportForDirectionIndex(modela);

            return Success(list);
        }


        /// <summary>
        /// 饼图EChart图标统计
        /// </summary>
        [HttpPost]
        public RequestResult<IList<dynamic>> QueryRightEChartReportForDirectionIndex(OperQueryParaModel modela)
        {

            IList<dynamic> list = WeiXinQuery.QueryRightEChartReportForDirectionIndex(modela);

            return Success(list);
        }
        #endregion

        #region 质控
        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_REPORT_IND>> GetQuanlityControlReportInd()
        {
            return Success(WeiXinQuery.GetQuanlityControlReportInd());
        }

        /// <summary>
        /// 获取质控报表备份数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_QC_REPORT_LIST>> GetQuanlityControlReportBakItemList(string reportName)
        {
            return Success(WeiXinQuery.GetQuanlityControlReportBakItemList(reportName));
        }

        #endregion
    }
}