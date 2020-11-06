
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class OperProgressController : BaseApiController //,IOperProgress
    {
        IOperProgressService bc;
        public OperProgressController(IOperProgressService accountService)
        {
            bc = accountService;
        }

        #region 主任工作站大屏，当前手术进程信息

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetOperProgressViewData([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetOperProgressViewData(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetOperSeqenceInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetOperSeqenceInfo(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetMonitorAlarmInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetMonitorAlarmInfo(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetYesterdayOperInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetYesterdayOperInfo(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetYesterdayPacuOtInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetYesterdayPacuOtInfo(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetTodayOperInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetTodayOperInfo(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetTomorrowSchduleInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetTomorrowSchduleInfo(queryParams));
        }
        #endregion

        #region 医务工作站，整体手术进程信息

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetTotalProInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetTotalProInfo(queryParams));
        }

        #endregion

        #region 手术间详情大屏

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetOperInfoByOperRoom([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetOperInfoByOperRoom(queryParams));
        }
        
        #endregion
    }
}