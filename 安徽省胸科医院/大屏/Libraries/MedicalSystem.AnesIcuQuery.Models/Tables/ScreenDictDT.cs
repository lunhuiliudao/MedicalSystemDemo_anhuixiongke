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
    /// 大屏字典表：MED_SMART_SCREEN_DICT
    /// </summary>
    [Description("MED_SMART_SCREEN_DICT")]
    [Table("MED_SMART_SCREEN_DICT")]
    public class ScreenDictDT : BaseModel
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
        public String SCREEN_LABEL
        {
            get { return (String)this["SCREEN_LABEL"]; }
            set { this["SCREEN_LABEL"] = value; }
        }
        public Decimal? FULL_SCREEN
        {
            get { return (Decimal?)this["FULL_SCREEN"]; }
            set { this["FULL_SCREEN"] = value; }
        }
        public Decimal? SCREEN_WIDTH
        {
            get { return (Decimal?)this["SCREEN_WIDTH"]; }
            set { this["SCREEN_WIDTH"] = value; }
        }
        public Decimal? SCREEN_HEIGHT
        {
            get { return (Decimal?)this["SCREEN_HEIGHT"]; }
            set { this["SCREEN_HEIGHT"] = value; }
        }
    }
}
