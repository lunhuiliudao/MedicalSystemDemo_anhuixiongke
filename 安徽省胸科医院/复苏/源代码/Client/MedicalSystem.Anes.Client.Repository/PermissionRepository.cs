using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class PermissionRepository : BaseRepository 
    {
        public RequestResult<List<MED_PERMISSION_LOGINNAME>> GetUserByUserName(string appID, string loginName)
        {
            string address = "PacuPermission/GetUserByUserName?appID=" + appID + "&loginName=" + loginName;
            return BaseRepository.GetCallApi<List<MED_PERMISSION_LOGINNAME>>(address);
        }
    }
}
