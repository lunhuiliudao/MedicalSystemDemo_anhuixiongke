
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 处理第三方数据
    /// </summary>
    public class AsyncHandleData
    {
        public static string Get(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                if (request != null)
                {
                    string retval = null;
                    init_Request(ref request);
                    using (var Response = request.GetResponse())
                    {
                        using (var reader = new System.IO.StreamReader(Response.GetResponseStream(), System.Text.Encoding.UTF8))
                        {
                            retval = reader.ReadToEnd();
                        }
                    }
                    return retval;
                }
            }
            catch
            {

            }
            return null;
        }

        public static string Post(string url, string data)
        {
            new HttpRequestHeader();
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                if (request != null)
                {
                    string retval = null;
                    init_Request(ref request);
                    request.Method = "POST";
                    request.ServicePoint.Expect100Continue = false;
                    request.ContentType = "application/json";

                    var bytes = System.Text.UTF8Encoding.UTF8.GetBytes(data);
                    request.ContentLength = bytes.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    using (var response = request.GetResponse())
                    {
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            retval = reader.ReadToEnd();
                        }
                    }
                    return retval;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        public static string Post(string url, string data, string token)
        {
            new HttpRequestHeader();
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                if (request != null)
                {
                    string retval = null;
                    init_Request(ref request);
                    request.Method = "POST";
                    request.ServicePoint.Expect100Continue = false;
                    request.ContentType = "application/json";

                    request.Headers.Add("MedAuth:" + token);

                    var bytes = System.Text.UTF8Encoding.UTF8.GetBytes(data);
                    request.ContentLength = bytes.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    using (var response = request.GetResponse())
                    {
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            retval = reader.ReadToEnd();
                        }
                    }
                    return retval;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        public static RequestResult<int> PostFileData(string url, Dictionary<string, string> dicFormData, Dictionary<string, string> dicFiles, string token)
        {
            RequestResult<int> returnResult = new RequestResult<int>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("MedAuth", token);//设定要响应的数据格式

                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));//设定要响应的数据格式

                client.DefaultRequestHeaders.Add("Accept-Language", "en,zh");

                client.DefaultRequestHeaders.Add("Accept-Charset", "iso-8859-5");

                //client.DefaultRequestHeaders.

                using (var content = new MultipartFormDataContent())//表明是通过multipart/form-data的方式上传数据
                {
                    var formDatas = GetFormDataByteArrayContent(GetNameValueCollection(dicFormData));//获取键值集合对应的ByteArrayContent集合


                    var files = GetFileByteArrayContent(dicFiles);//获取文件集合对应的ByteArrayContent集合

                    Action<List<ByteArrayContent>> act = (dataContents) =>
                    {
                        //声明一个委托，该委托的作用就是将ByteArrayContent集合加入到MultipartFormDataContent中
                        foreach (var byteArrayContent in dataContents)
                        {
                            content.Add(byteArrayContent);
                        }
                    };

                    act(formDatas);//执行act

                    act(files);//执行act

                    try
                    {
                        var result = client.PostAsync(url, content).Result;//post请求

                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            string mes = result.Content.ReadAsStringAsync().Result;

                            var jsonData = JsonConvert.DeserializeObject<ResponseResult>(JsonConvert.DeserializeObject(mes).ToString());

                            if (jsonData.Status == 1)
                            {

                                returnResult.Data = 1;

                                returnResult.Message = jsonData.Message + "|" + jsonData.Entity;

                                returnResult.Result = ResultStatus.Success;
                            }
                        }
                        else
                        {
                            string mes = result.Content.ReadAsStringAsync().Result;

                            var jsonData = JsonConvert.DeserializeObject<ResponseResult>(JsonConvert.DeserializeObject(mes).ToString());

                            if (jsonData.Status == -1)
                            {
                                returnResult.Data = 0;

                                returnResult.Message = jsonData.Message;

                                returnResult.Result = ResultStatus.Failed;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return returnResult;
        }

        public static RequestResult<int> PostFileData(string url, Dictionary<string, string> dicFormData, Dictionary<string, string> dicFiles, string patientId, decimal visitId, decimal operId)
        {
            RequestResult<int> returnResult = new RequestResult<int>();

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));//设定要响应的数据格式

                client.DefaultRequestHeaders.Add("Accept-Language", "en,zh");

                client.DefaultRequestHeaders.Add("Accept-Charset", "iso-8859-5");

                client.DefaultRequestHeaders.Add("PATIENT_ID", patientId);
                client.DefaultRequestHeaders.Add("VISIT_ID", visitId.ToString());
                client.DefaultRequestHeaders.Add("OPER_ID", operId.ToString());

                //client.DefaultRequestHeaders.

                using (var content = new MultipartFormDataContent())//表明是通过multipart/form-data的方式上传数据
                {
                    var formDatas = GetFormDataByteArrayContent(GetNameValueCollection(dicFormData));//获取键值集合对应的ByteArrayContent集合


                    var files = GetFileByteArrayContent(dicFiles);//获取文件集合对应的ByteArrayContent集合

                    Action<List<ByteArrayContent>> act = (dataContents) =>
                    {
                        //声明一个委托，该委托的作用就是将ByteArrayContent集合加入到MultipartFormDataContent中
                        foreach (var byteArrayContent in dataContents)
                        {
                            content.Add(byteArrayContent);
                        }
                    };

                    act(formDatas);//执行act

                    act(files);//执行act

                    try
                    {
                        var result = client.PostAsync(url, content).Result;//post请求

                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            string mes = result.Content.ReadAsStringAsync().Result;

                            var jsonData = JsonConvert.DeserializeObject<ResponseResult>(JsonConvert.DeserializeObject(mes).ToString());

                            if (jsonData.Status == 1)
                            {

                                returnResult.Data = 1;

                                returnResult.Message = jsonData.Message + "|" + jsonData.Entity;

                                returnResult.Result = ResultStatus.Success;
                            }
                        }
                        else
                        {
                            string mes = result.Content.ReadAsStringAsync().Result;

                            var jsonData = JsonConvert.DeserializeObject<ResponseResult>(JsonConvert.DeserializeObject(mes).ToString());

                            if (jsonData.Status == -1)
                            {
                                returnResult.Data = 0;

                                returnResult.Message = jsonData.Message;

                                returnResult.Result = ResultStatus.Failed;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return returnResult;
        }

        /// <summary>
        /// 获取文件集合对应的ByteArrayContent集合
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private static List<ByteArrayContent> GetFileByteArrayContent(Dictionary<string, string> dicFiles)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach (var file in dicFiles)
            {
                var fileContent = new ByteArrayContent(File.ReadAllBytes(file.Value));

                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = HttpUtility.UrlEncode(file.Key.Trim('"').Split('.')[0], System.Text.Encoding.UTF8) + "." + file.Key.Trim('"').Split('.')[1]
                };


                list.Add(fileContent);
            }
            return list;
        }

        /// <summary>
        /// 获取键值集合对应的ByteArrayContent集合
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private static List<ByteArrayContent> GetFormDataByteArrayContent(NameValueCollection collection)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach (var key in collection.AllKeys)
            {
                var dataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(collection[key]));
                dataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    Name = key
                };
                list.Add(dataContent);
            }
            return list;
        }

        /// <summary>
        /// 从DataGridView中获取键值对集合
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        private static NameValueCollection GetNameValueCollection(Dictionary<string, string> dic)
        {
            NameValueCollection collection = new NameValueCollection();

            foreach (KeyValuePair<string, string> keyValue in dic)
            {
                try
                {
                    if (keyValue.Key != null)
                    {


                        collection.Add(keyValue.Key,
                            keyValue.Value == null ? string.Empty : keyValue.Value);
                    }
                }
                catch { }//忽略异常，不检测是否存在重复的键值
            }
            return collection;
        }
        /// <summary>
        /// 从DataGridView中获取选择的文件集合
        /// </summary>
        /// <param name = "gv" ></ param >
        /// < returns ></ returns >
        private static HashSet<string> GetHashSet(Dictionary<string, string> dic)
        {
            HashSet<string> hash = new HashSet<string>();

            foreach (KeyValuePair<string, string> keyValue in dic)
            {
                if (keyValue.Value != null)
                {
                    hash.Add(keyValue.Value);
                }
            }
            return hash;
        }


        private static void init_Request(ref System.Net.HttpWebRequest request)
        {
            request.Accept = "text/json,*/*;q=0.5";
            request.Headers.Add("Accept-Charset", "utf-8;q=0.7,*;q=0.7");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, x-gzip, identity; q=0.9");
            request.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
            request.Timeout = 8000;
        }
    }

    public class ResponseResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 额外数据
        /// </summary>
        public string Entity { get; set; }

    }
}
