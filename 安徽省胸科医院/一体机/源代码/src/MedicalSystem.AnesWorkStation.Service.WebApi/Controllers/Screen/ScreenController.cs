using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// 大屏数据获取
    /// </summary>
    public class ScreenController : BaseApiController
    {


        IScreenService bc;
        public ScreenController(IScreenService accountService)
        {
            bc = accountService;
        }
        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetScreenViewNormal([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetScreenViewNormal(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetValidMsgData([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetValidMsgData(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetNoticeMsgData([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetNoticeMsgData(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> UpdateNoticeMsgData([FromBody]QueryParams queryParams)
        {
            return Success(bc.UpdateNoticeMsgData(queryParams));
        }
    }
}