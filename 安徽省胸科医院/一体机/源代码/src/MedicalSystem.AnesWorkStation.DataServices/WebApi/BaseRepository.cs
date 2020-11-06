
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.DataServices.WebApi
{
    public class BaseRepository
    {
        public static void SetWebApiAddress(string remoteAddress,int remotePort)
        {
            WebApiVisitor.BaseAddress = "http://" + remoteAddress + ":" + remotePort.ToString() + "/api/";//192.168.0.17:8081/////localhost:8031;
            WebApiVisitor.WebApiUri = "http://" + remoteAddress + ":" + remotePort.ToString() + "/";//192.168.0.17:8081/////localhost:8031;
        }

        public static RequestResult<T> GetCallApi<T>(string address)
        {
            var result = WebApiVisitor.GetAccessApi<T>(address);
            if(result.Result== ResultStatus.Success)
            {
                return result;
            }
            else
            {
                throw new Exception( result.Message );
            }
        }

        public static RequestResult<dynamic> PostCallApi<T>(string address, T t)
        {
            var result = WebApiVisitor.PostAccessApi<T, string>(address, t);
            if (result.Result == ResultStatus.Success)
            {
                return result;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }
    }
}
