using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class DailyScheduleRepository : BaseRepository
    {
        #region IDailyScheduleDataInterface 成员

        public RequestResult<bool> Add(MED_DAILY_SCHEDULE item)
        {
            string address = "PacuDailySchedule/Add";
            return BaseRepository.PostCallApi<MED_DAILY_SCHEDULE, bool>(address, item);
        }

        public RequestResult<bool> Update(MED_DAILY_SCHEDULE item)
        {
            string address = "PacuDailySchedule/Update";
            return BaseRepository.PostCallApi<MED_DAILY_SCHEDULE, bool>(address, item);
        }

        public RequestResult<List<MED_DAILY_SCHEDULE>> GetDayList(DateTime currentDay, string loginName)
        {
            string address = "PacuDailySchedule/GetDayList?loginName=" + loginName + "&currentDay=" + currentDay.ToString("yyyy-MM-dd");
            return BaseRepository.GetCallApi<List<MED_DAILY_SCHEDULE>>(address);
        }

        public RequestResult<List<MED_DAILY_SCHEDULE>> GetMonthList(DateTime currentMonth, string loginName)
        {
            string address = "PacuDailySchedule/GetMonthList?loginName=" + loginName + "&currentMonth=" + currentMonth.ToString("yyyy-MM");
            return BaseRepository.GetCallApi<List<MED_DAILY_SCHEDULE>>(address);
        }

        #endregion
    }
}
