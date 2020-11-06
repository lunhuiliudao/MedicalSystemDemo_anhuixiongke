using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_LAB_TEST_MASTER
    {
        [NotMapped]
        public virtual string SPCM_RECEIVED_DATE_TIME_SHOW
        {
            get 
            {
                if(SPCM_RECEIVED_DATE_TIME.HasValue)
                {
                    return ((DateTime)SPCM_RECEIVED_DATE_TIME).ToString("yyyy-MM-dd");
                }

                return string.Empty;
            }
        }
    }
}
