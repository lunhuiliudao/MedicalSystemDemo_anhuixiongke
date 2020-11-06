using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuDailyScheduleService
    {
        bool AddDailySchedule(MED_DAILY_SCHEDULE item);
        bool SaveDailySchedule(MED_DAILY_SCHEDULE item);
        List<MED_DAILY_SCHEDULE> GetDayList(DateTime currentDay, string loginName);
        List<MED_DAILY_SCHEDULE> GetMonthList(DateTime currentMonth, string loginName);
    }
    public class PacuDailyScheduleService : BaseService<PacuDailyScheduleService>, IPacuDailyScheduleService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuDailyScheduleService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuDailyScheduleService(IDapperContext context)
            : base(context)
        {
        }

        public bool AddDailySchedule(MED_DAILY_SCHEDULE item)
        {

            item.CREATE_DATE = DateTime.Now;

            item.UPDATE_DATE = item.CREATE_DATE;

            var list = dapper.Set<MED_DAILY_SCHEDULE>().Select(x => x.DAILY_DAY == item.DAILY_DAY && x.DAILY_USER == item.DAILY_USER);

            if (list == null || list.Count == 0)
            {
                item.DAILY_NO = 1;
            }
            else
            {
                item.DAILY_NO = list.Max(x => x.DAILY_NO) + 1;
            }

            return dapper.Set<MED_DAILY_SCHEDULE>().Insert(item);
        }

        public bool SaveDailySchedule(MED_DAILY_SCHEDULE item)
        {
            item.UPDATE_DATE = item.CREATE_DATE;

            return dapper.Set<MED_DAILY_SCHEDULE>().Save(item);
        }

        public List<MED_DAILY_SCHEDULE> GetDayList(DateTime currentDay, string loginName)
        {
            currentDay = currentDay.Date;

            return dapper.Set<MED_DAILY_SCHEDULE>().Select(x => x.DAILY_DAY == currentDay && x.DAILY_USER == loginName);
        }

        public List<MED_DAILY_SCHEDULE> GetMonthList(DateTime currentMonth, string loginName)
        {
            currentMonth = DateTime.Parse(currentMonth.ToString("yyyy-MM-01"));
            var nextMonth = currentMonth.AddMonths(1);
            return dapper.Set<MED_DAILY_SCHEDULE>().Select(x => x.DAILY_DAY >= currentMonth && x.DAILY_DAY < nextMonth && x.DAILY_USER == loginName);
        }
    }
}
