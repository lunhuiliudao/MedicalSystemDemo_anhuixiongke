using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class BaseRepository
    {
        public static void SetWebApiAddress(string remoteAddress, int remotePort)
        {
            WebApiVisitor.BaseAddress = "http://" + remoteAddress + ":" + remotePort.ToString() + "/api/";//192.168.0.17:8081/////localhost:8031;
            WebApiVisitor.WebApiUri = "http://" + remoteAddress + ":" + remotePort.ToString() + "/";//192.168.0.17:8081/////localhost:8031;
        }

        public static RequestResult<T> GetCallApi<T>(string address, bool runInBackgroud = false)
        {
            if (address.Contains("?"))
            {
                try
                {
                    var urlArr = address.Split('?');
                    var parmStr = urlArr[1];
                    var parmArr = parmStr.Split('&').Select(x => x.Split('=').ToArray()).ToList();
                    parmArr.ForEach(x => x[1] = System.Web.HttpUtility.UrlEncode(x[1]));
                    urlArr[1] = string.Join("&", parmArr.Select(x => string.Join("=", x)).ToArray());
                    address = string.Join("?", urlArr);
                }
                catch { }
            }
            //address = string.Join('?', address.Split('?').se
            Logger.Error(address);
            var result = WebApiVisitor.GetAccessApi<T>(address, runInBackgroud);
            Logger.Error("测试result" + result == null ? ":null" : result.Result.ToString());
            if (result.Result == ResultStatus.Success)
            {
                return result;
            }
            else
            {
                Logger.Error(result.Message);

                return null;
            }
        }

        public static RequestResult<int> PostCallApi<T>(string address, T t, bool runInBackgroud = false)
        {
            return PostCallApi<T, int>(address, t, runInBackgroud);
        }

        public static RequestResult<string> PostCallApi2<T>(string address, T t, bool runInBackgroud = false)
        {
            return PostCallApi<T, string>(address, t, runInBackgroud);
        }

        public static RequestResult<T_Result> PostCallApi<T, T_Result>(string address, T t, bool runInBackgroud = false)
        {
            var result = WebApiVisitor.PostAccessApi<T, T_Result>(address, t, runInBackgroud);
            if (result.Result == ResultStatus.Success)
            {
                return result;
            }
            else
            {
                Logger.Error(result.Message);

                return null;
            }
        }

    }
}
