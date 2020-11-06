using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class BYULIU:HospitalBase
    {
       public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
       {
           return base.PreDataBase(config, domain);
       }

       public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
       {
           return base.PreReceiveMsg(config, domain);
       }

       public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
       {
           return base.PreWebServices(config, domain);
       }

       public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
       {
           return base.DoExecute(config, domain, obj);
       }
    }
}
