
using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class AccountRepository : BaseRepository
    {
        public RequestResult<MED_USERS> Login(string loginName, string password)
        {
            string address = "PacuAccount/Login?loginName=" + loginName + "&passWord=" + password;
            return BaseRepository.GetCallApi<MED_USERS>(address);
        }

        public RequestResult<DateTime> GetServerTime()
        {
            string address = "PacuAccount/GetServerTime";
            return BaseRepository.GetCallApi<DateTime>(address);
        }

        public RequestResult<List<MED_PERMISSIONS>> GetPermission(string appID, string loginName)
        {
            string address = "PacuAccount/GetPermission?appID=" + appID + "&loginName=" + loginName;
            return BaseRepository.GetCallApi<List<MED_PERMISSIONS>>(address);
        }

        private bool setLocalSystemDateSuccess = false;

        public void SetLocalSystemDate()
        {
            
            this.setLocalSystemDateSuccess = true;
        }
    }
}
