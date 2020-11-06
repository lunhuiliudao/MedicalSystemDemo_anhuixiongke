using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public static class WebApiVisitor
    {
        /// <summary>
        /// 令牌
        /// </summary>
        private static string __Token { get; set; }
        public static string BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];
        public static string WebApiUri = ConfigurationManager.AppSettings["WebApiUri"];
        /// <summary>
        /// 令牌
        /// </summary>
        public static string Token
        {
            get
            {
                if (System.Web.HttpContext.Current == null)
                    return __Token;
                else if (System.Web.HttpContext.Current.Request.Cookies[WebApiSetting.TOKENKEY] != null)
                    return System.Web.HttpContext.Current.Request.Cookies[WebApiSetting.TOKENKEY].Value;
                else
                    return null;
            }
            private set
            {
                if (System.Web.HttpContext.Current == null)
                    __Token = value;
                else
                {
                    System.Web.HttpCookie aCookie = new System.Web.HttpCookie(WebApiSetting.TOKENKEY);
                    aCookie.Value = value;
                    //aCookie.Expires = DateTime.Now.AddHours(1);
                    aCookie.Expires = DateTime.Parse("9999-01-01");
                    System.Web.HttpContext.Current.Response.Cookies.Add(aCookie);
                }
            }
        }
        public static RequestResult<T> GetAccessApi<T>(string baseAddress, string webAddress, string address, bool runInBackgroud = false)
        {
            BaseAddress = baseAddress;
            WebApiVisitor.WebApiUri = webAddress;
            string result = string.Empty;
            RequestResult<T> obj = null;
            MyHttpClienHanlder handler = new MyHttpClienHanlder();
            HttpClient client = new HttpClient(handler);
            Uri uri = new Uri(BaseAddress + address);

            try
            {
                if (ApiStartRequest != null && !runInBackgroud)
                    ApiStartRequest(uri, null);

                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<RequestResult<T>>(result);

                    if (obj.Result == ResultStatus.Success)
                    {

                    }
                    else
                    {
                        Logger.Error("获取服务器数据失败,地址=" + address + " :", new Exception(obj.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("获取服务器数据失败,地址=" + address + " :", ex);
                throw;
            }
            finally
            {
                if (ApiEndRequest != null && !runInBackgroud)
                    ApiEndRequest(uri, null);
            }
            return obj;
        }
        /// <summary>
        /// GET方式访问WebApi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="runInBackgroud">在后台执行，除非响应事件</param>
        /// <returns></returns>
        public static RequestResult<T> GetAccessApi<T>(string address, bool runInBackgroud = false)
        {
            string result = string.Empty;
            RequestResult<T> obj = null;
            MyHttpClienHanlder handler = new MyHttpClienHanlder();
            HttpClient client = new HttpClient(handler);
            Uri uri = new Uri(BaseAddress + address);

            try
            {
                if (ApiStartRequest != null && !runInBackgroud)
                    ApiStartRequest(uri, null);

                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<RequestResult<T>>(result);
                    if (obj.Result == ResultStatus.Success)
                    {

                    }
                    else
                    {
                        Logger.Error("获取服务器数据失败,地址=" + address + " :", new Exception(obj.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("获取服务器数据失败,地址=" + address + " :", ex);
                throw;
            }
            finally
            {
                if (ApiEndRequest != null && !runInBackgroud)
                    ApiEndRequest(uri, null);
            }
            return obj;
        }

        /// <summary>
        /// POST方式访问WebApi
        /// </summary>
        /// <typeparam name="T_Request"></typeparam>
        /// <typeparam name="T_Result"></typeparam>
        /// <param name="address"></param>
        /// <param name="t"></param>
        /// <param name="runInBackgroud">在后台执行，除非响应事件</param>
        /// <returns></returns>
        public static RequestResult<T_Result> PostAccessApi<T_Request, T_Result>(string address, T_Request t, bool runInBackgroud = false)
        {
            string result = string.Empty;
            RequestResult<T_Result> obj = null;
            MyHttpClienHanlder handler = new MyHttpClienHanlder();
            HttpClient client = new HttpClient(handler);
            Uri uri = new Uri(BaseAddress + address);

            try
            {
                if (ApiStartRequest != null && !runInBackgroud)
                    ApiStartRequest(uri, null);

                HttpContent content = new StringContent(JsonConvert.SerializeObject(t));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync(uri, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<RequestResult<T_Result>>(result);
                    
                    if (obj.Result == ResultStatus.Success)
                    {

                    }
                    else
                    {
                        Logger.Error("保存服务器数据失败,地址=" + address, new Exception(obj.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("保存服务器数据失败,地址=" + address, ex);

                throw new Exception("连接服务器失败，请检查网络。", ex);
            }
            finally
            {
                if (ApiEndRequest != null && !runInBackgroud)
                    ApiEndRequest(uri, null);
            }
            return obj;
        }

        public static event EventHandler ApiStartRequest;
        public static event EventHandler ApiEndRequest;
    }

}
