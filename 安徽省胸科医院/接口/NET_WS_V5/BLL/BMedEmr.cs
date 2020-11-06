using MedicalSytem.Soft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedEmr:HospitalBase
    {
        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                MedPatsInHospital hos = SelectMedPatsInHospital(domain.Patient.PatientId, domain.Patient.VisitId.Value);
                string url = "http://10.64.1.230/JHNISTempWeb/?patient_id=" + domain.Patient.PatientId + "&visit_id=" + hos.InpNo + "";
            
                return url;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return ex.Message;
            }
        }
    }
}
