
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Xml;
using System.IO;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// 大屏配置数据获取
    /// </summary>
    public class ScreenConfigController : BaseApiController
    {

        IScreenConfigService bc;
        public ScreenConfigController(IScreenConfigService accountService)
        {
            bc = accountService;
        }
        #region 大屏字典表
        /// <summary>
        /// 大屏字典表
        /// </summary>
        /// <param name="queryParams">空参数</param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetScreenDict([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetScreenDict(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> UpdateScreenDict([FromBody]QueryParams queryParams)
        {
            return Success(bc.UpdateScreenDict(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> InsertScreenDict([FromBody]QueryParams queryParams)
        {
            return Success(bc.InsertScreenDict(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> DeleteScreenDict([FromBody]QueryParams queryParams)
        {
            return Success(bc.DeleteScreenDict(queryParams));
        }
        #endregion

        #region 大屏常规配置表
        /// <summary>
        /// 根据编号获取大屏配置表
        /// </summary>
        /// <param name="queryParams">大屏编号</param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetScreenConfig([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetScreenConfig(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> InsertScreenNormalConfig([FromBody]QueryParams queryParams)
        {
            return Success(bc.InsertScreenNormalConfig(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> UpdateScreenNormalConfig([FromBody]QueryParams queryParams)
        {
            return Success(bc.UpdateScreenNormalConfig(queryParams));
        }
        #endregion

        #region 显示内容
        /// <summary>
        /// 获取全部字段列表对照字典
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public ApiResult<Dictionary<string, string>> GetAllFieldList([FromBody]QueryParams queryParams)
        {
            Dictionary<string, string> retDict = new Dictionary<string, string>();
            XmlDocument xmlDoc = new XmlDocument();
            string path = Path.Combine(AppSettings.ScreenAppPath, "Config\\FieldNameDict.xml");
            if (System.IO.File.Exists(path))
            {
                xmlDoc.Load(path);
                foreach (XmlNode xmlNode in xmlDoc.ChildNodes[0].ChildNodes)
                {
                    if (!retDict.Keys.Contains(xmlNode.ChildNodes[0].InnerText))
                        retDict.Add(xmlNode.ChildNodes[0].InnerText, xmlNode.ChildNodes[1].InnerText);
                }
            }
            return Success(retDict);
        }
        /// <summary>
        /// 获取视图的所有字段列表
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public ApiResult<List<string>> GetViewColumnList([FromBody]QueryParams queryParams)
        {
            List<string> retList = new List<string>();
            DataTable viewData = bc.GetScreenViewEmptyData(queryParams);
            for(int i = 0; i< viewData.Columns.Count; i++)
            {
                retList.Add(viewData.Columns[i].ColumnName);
            }
            return Success(retList);
        }

        /// <summary>
        /// 获取大屏显示字段表数据
        /// </summary>
        /// <param name="queryParams">大屏编号</param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetScreenFieldsData([FromBody]QueryParams queryParams)
        {
            List<string> retList = new List<string>();
 
            return Success(bc.GetScreenFieldsData(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> InsertScreenFields([FromBody]QueryParams queryParams)
        {
            return Success(bc.InsertScreenFields(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> DeleteScreenFields([FromBody]QueryParams queryParams)
        {
            return Success(bc.DeleteScreenFields(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> UpdateScreenFields([FromBody]QueryParams queryParams)
        {
            return Success(bc.UpdateScreenFields(queryParams));
        }
        #endregion

        #region 大屏通告信息
        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetMsgData([FromBody]QueryParams queryParams)
        {
            List<string> retList = new List<string>();

            return Success(bc.GetMsgData(queryParams));
        }
        [HttpPost, HttpGet]
        public ApiResult<int> InsertScreenMsg([FromBody]QueryParams queryParams)
        {
            return Success(bc.InsertScreenMsg(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> DeleteScreenMsg([FromBody]QueryParams queryParams)
        {
            return Success(bc.DeleteScreenMsg(queryParams));
        }

        [HttpPost, HttpGet]
        public ApiResult<int> UpdateScreenMsg([FromBody]QueryParams queryParams)
        {
            return Success(bc.UpdateScreenMsg(queryParams));
        }
        #endregion
    }
}