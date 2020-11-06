using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class UserRepository : BaseRepository
    {
        public RequestResult<MED_USERS> GetUser(string userID)
        {
            string address = "PacuUser/GetUser?userID=" + userID;
            return BaseRepository.GetCallApi<MED_USERS>(address);
        }

        public RequestResult<List<MED_USERS>> GetUserList(string deptCode, string loginName, string userName)
        {
            string address = "PacuUser/GetUserList?deptCode=" + deptCode + "&loginName="
                + loginName + "&userName=" + userName;
            return BaseRepository.GetCallApi<List<MED_USERS>>(address);
        }

        public RequestResult<int> SaveUser(MED_USERS item)
        {
            string address = "PacuUser/SaveUser";
            return BaseRepository.PostCallApi<MED_USERS>(address, item);
        }

        public RequestResult<List<MED_USERS>> GetUserList()
        {
            return GetUserList("", "", "");
        }

        public RequestResult<List<MED_USERS>> GetUserList(string deptCode)
        {
            return GetUserList(deptCode, "", "");
        }

        #region 用户留言记录表 成员


        public RequestResult<List<MED_USER_MESSAGES>> GetUserMessage(MED_USERS item)
        {
            string address = "PacuUser/GetUserMessage";
            return BaseRepository.PostCallApi<MED_USERS, List<MED_USER_MESSAGES>>(address, item);
        }

        public RequestResult<bool> SaveUserMessage(MED_USER_MESSAGES item)
        {
            string address = "PacuUser/SaveUserMessage";
            return BaseRepository.PostCallApi<MED_USER_MESSAGES, bool>(address, item);
        }

        #endregion

        public RequestResult<List<MED_USER_NOTE>> GetUserNote(MED_USERS item)
        {
            string address = "PacuUser/GetUserNote";
            return BaseRepository.PostCallApi<MED_USERS, List<MED_USER_NOTE>>(address, item);
        }

        public RequestResult<bool> SaveUseNote(MED_USER_NOTE item)
        {
            string address = "PacuUser/SaveUseNote";
            return BaseRepository.PostCallApi<MED_USER_NOTE, bool>(address, item);
        }
    }
}
