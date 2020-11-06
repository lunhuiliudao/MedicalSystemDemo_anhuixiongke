using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class DocPictureController : BaseController
    {
        [HttpGet]
        public RequestResult<string[]> GetAnesDocImageList(string patientID, int visitID, int operID, string docName)
        {
            List<string> docPicName = new List<string>();
            string name = HttpUtility.UrlDecode(docName);
            if (System.Diagnostics.Process.GetProcessesByName("MedicalSystem.AnesWorkStation.View").ToList().Count <= 0)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = HttpContext.Current.Server.MapPath("~/程序/MedicalSystem.AnesWorkStation.View.exe"); ;// @"E:\WPF一体机\源代码\src\MedicalSystem.AnesWorkStation.View\bin\Debug\MedicalSystem.AnesWorkStation.View.exe";// 
                info.Arguments = "autologin" + " " + "mdsd" + " " + "mdsdss";
                info.WindowStyle = ProcessWindowStyle.Minimized;
                Process pro = Process.Start(info);
            }
            while (System.Diagnostics.Process.GetProcessesByName("MedicalSystem.AnesWorkStation.View").ToList().Count > 0)
            {
                string path = string.Format(@"http://localhost:6466/?patientID={0}&visitID={1}&operID={2}&docName={3}", patientID, visitID, operID, HttpUtility.UrlEncode(name));
                System.Diagnostics.Process.Start(path);
                break;
            }
            string fileName = patientID + "_" + visitID + "_" + operID;
            string jpgPath = HttpContext.Current.Server.MapPath(string.Format("~/程序/文书图片/{0}/{1}", fileName, name));
            if (System.IO.Directory.Exists(jpgPath))
            {
                var files = Directory.GetFiles(jpgPath, "*.jpg");

                foreach (var file in files)
                {
                    string address = file.Replace(HttpContext.Current.Server.MapPath("/"), "");
                    docPicName.Add(address);
                }

            }

            return Success(docPicName.ToArray());
        }
        [HttpGet]
        public RequestResult<string[]> GetAnesDocImageAddressList(string patientID, int visitID, int operID, string docName)
        {
            List<string> docPicName = new List<string>();
            string fileName = patientID + "_" + visitID + "_" + operID;
            string name = HttpUtility.UrlDecode(docName);
            string jpgPath = HttpContext.Current.Server.MapPath(string.Format("~/程序/文书图片/{0}/{1}", fileName, name));
            if (System.IO.Directory.Exists(jpgPath))
            {
                var files = Directory.GetFiles(jpgPath, "*.jpg");
                foreach (var file in files)
                {
                    string address = file.Replace(HttpContext.Current.Server.MapPath("/"), "");
                    docPicName.Add(address);
                }
            }

            return Success(docPicName.ToArray());
        }
    }
}