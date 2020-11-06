
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using MedicalSystem.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.DataServices.WebApi
{
    public static class WebApiVisitor
    {
        /// <summary>
        /// 令牌
        /// </summary>
        private static string __Token { get; set; }
        public static string BaseAddress = System.Configuration.ConfigurationManager.AppSettings["BaseAddress"];
        public static string WebApiUri = System.Configuration.ConfigurationManager.AppSettings["WebApiUri"];
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

        /// <summary>
        /// GET方式访问WebApi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public static RequestResult<dynamic> GetAccessApi<dynamic>(string address)
        {
            string result = string.Empty;
            RequestResult<dynamic> obj = null;
            MyHttpClienHanlder handler = new MyHttpClienHanlder();
            HttpClient client = new HttpClient(handler);
            Uri uri = new Uri(address);

            try
            {
                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<RequestResult<dynamic>>(result);

                }
            }
            catch (Exception ex)
            {
                throw ex;
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
        /// <returns></returns>
        public static RequestResult<dynamic> PostAccessApi<T_Request, T_Result>(string address, T_Request t)
        {
            string result = string.Empty;
            RequestResult<dynamic> obj = null;
            MyHttpClienHanlder handler = new MyHttpClienHanlder();
            HttpClient client = new HttpClient(handler);
            Uri uri = new Uri(address);

            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(t));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync(uri, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<RequestResult<dynamic>>(result);

                }
            }
            catch (Exception ex)
            {
                throw ex;
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
        /// <returns></returns>
        public static bool PostAccessApi(string address, dynamic t)
        {
            bool result = false;
            RequestResult<dynamic> obj = null;
            MyHttpClienHanlder handler = new MyHttpClienHanlder();
            HttpClient client = new HttpClient(handler);
            Uri uri = new Uri(address);

            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(t));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync(uri, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }

                string result1 = response.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<RequestResult<dynamic>>(result1);

                Logger.Error("异常信息", new Exception(obj.Data + ";" + obj.Result + ";" + obj.Message));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }

}
