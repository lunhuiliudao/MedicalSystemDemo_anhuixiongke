using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Dapper.Data;
using MedicalSystem.AnesIcuQuery.Models;

namespace MedicalSystem.AnesIcuQuery.Models.Tables
{
    /// <summary>
    /// 大屏配置表：ScreenConfigDT
    /// </summary>
    [Description("ScreenConfigDT"), Serializable]
    public class ScreenConfigDT : BaseModel
    {
        [Key]
        public String SCREEN_NO
        {
            get { return (String)this["SCREEN_NO"]; }
            set { this["SCREEN_NO"] = value; }
        }
        public String SCREEN_TYPE
        {
            get { return (String)this["SCREEN_TYPE"]; }
            set { this["SCREEN_TYPE"] = value; }
        }
        public String OPER_DEPT_CODE
        {
            get { return (String)this["OPER_DEPT_CODE"]; }
            set { this["OPER_DEPT_CODE"] = value; }
        }

        public String OPERROOM_FILTER
        {
            get { return (String)this["OPERROOM_FILTER"]; }
            set { this["OPERROOM_FILTER"] = value; }
        }

        public Decimal? REFRESH_TIME
        {
            get { return (Decimal?)this["REFRESH_TIME"]; }
            set { this["REFRESH_TIME"] = value; }

        }
         
        public Decimal? ROW_COUNT
        {
            get { return (Decimal?)this["ROW_COUNT"]; }
            set { this["ROW_COUNT"] = value; }

        }

        public Decimal? VOICE_BROADCAST
        {
            get { return (Decimal?)this["VOICE_BROADCAST"]; }
            set { this["VOICE_BROADCAST"] = value; }

        }

        public String SHOW_MODE
        {
            get { return (String)this["SHOW_MODE"]; }
            set { this["SHOW_MODE"] = value; }
        }

        public Decimal? MARK_SPEC
        {
            get { return (Decimal?)this["MARK_SPEC"]; }
            set { this["MARK_SPEC"] = value; }

        }
        public Decimal? SHOW_TV
        {
            get { return (Decimal?)this["SHOW_TV"]; }
            set { this["SHOW_TV"] = value; }

        }
        public Decimal? PROTECT_PRIVATE
        {
            get { return (Decimal?)this["PROTECT_PRIVATE"]; }
            set { this["PROTECT_PRIVATE"] = value; }

        }

        public String SKIN
        {
            get { return (String)this["SKIN"]; }
            set { this["SKIN"] = value; }
        }
    }
}
