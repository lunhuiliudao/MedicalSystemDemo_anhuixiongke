using MedicalSytem.Soft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedEmr103:HospitalBase
    {
        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("begin EMR103");
                MedPatsInHospital hos = SelectMedPatsInHospital(domain.Patient.PatientId, domain.Patient.VisitId.Value);

                if (hos == null)
                {
                    return "非住院患者";
                }

                MedHisUsers users = SelectMedHisUsers(hos.DoctorInCharge);
                if (users == null)
                {
                    users = SelectMedHisUsersName(hos.DoctorInCharge);
                }

                string url = "http://10.64.5.34:8080/winsso/c/" + users.UserJobId + "/0/2/0/" + hos.InpNo + "/0/0/" + hos.PatientId + "/lisclient";
                InitDocare.LogA.Debug("url：" + url);
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
