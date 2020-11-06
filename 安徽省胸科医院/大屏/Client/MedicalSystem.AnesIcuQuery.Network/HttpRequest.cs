using MedicalSystem.AnesIcuQuery.Common;
using MedicalSystem.AnesIcuQuery.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MedicalSystem.MedScreen.Network;
using System.Net;
using System.Net.Sockets;

namespace MedicalSystem.AnesIcuQuery.Network
{
    public class HttpRequest : Singleton<HttpRequest>
    {
        private static readonly string host = AppConfiguration.Instance.GetWebHostUrl;

        private static HttpClient _httpClient;
        protected HttpClient httpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri(host + (host.EndsWith("/") ? "" : "/"));
                    //_httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                    _httpClient.Timeout = new TimeSpan(0, 1, 0);
                    try
                    {
                        // https://news.cnblogs.com/n/553217/
                        // 借助 ServicePointManager，你可以告诉 HttpClient 自动回收连接。
                        var sp = ServicePointManager.FindServicePoint(new Uri(host));
                        sp.ConnectionLeaseTimeout = 60 * 1000; // 1 分钟
                        //帮HttpClient热身
                        _httpClient.SendAsync(new HttpRequestMessage
                        {
                            Method = new HttpMethod("HEAD"),
                            RequestUri = _httpClient.BaseAddress
                        }).Result.EnsureSuccessStatusCode();
                    }
                    catch (Exception ex)
                    {
                        Logger.Write("HttpClient初始化加载异常。");
                        string logEntity = ExceptionHandler.ExtractLogEntityFromException(ex);
                        Logger.Write(logEntity);
                    }
                }
                return _httpClient;
            }
        }

        public ApiResult<T> SerializerResult<T>(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<ApiResult<T>>(json);
            }
            else
            {
                throw new NetworkException("JSON转换的字符串不能为空。");
            }
        }

        public T SerializerObject<T>(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                throw new NetworkException("JSON转换的字符串不能为空。");
            }
        }

        #region WebApi Http

        public string HttpPostJson(string controller, string action, object paramObj = null)
        {
            string url = string.Format("/{0}/{1}", controller, action);
            return HttpPostJson(url, paramObj);
        }

        #endregion

        #region Http 请求

        /// <summary>
        /// Http Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paramters"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string HttpPostJson(string url, object paramters = null)
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(host + (host.EndsWith("/") ? "" : "/"));
            var requestJson = paramters == null ? "" : JsonConvert.SerializeObject(paramters,
                new IsoDateTimeConverter()
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                });
            HttpContent httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Task<HttpResponseMessage> task = httpClient.PostAsync(url, httpContent);
            task.Wait(-1);

            return Response(task.Result);
            //}

        }

        /// <summary>
        /// 返回处理
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string Response(HttpResponseMessage response)
        {
            Task<string> t = response.Content.ReadAsStringAsync();
            t.Wait();

            if (response.IsSuccessStatusCode)
            {
                return t.Result;
            }

            //如果访问出错了，则继续丢出错误日志，并记录下来。
            var ex = new NetworkException(t.Result, t.Exception);
            string logEntity = ExceptionHandler.ExtractLogEntityFromException(ex);
            Logger.Write(logEntity);

            throw ex;
        }

        #endregion

    }
}
