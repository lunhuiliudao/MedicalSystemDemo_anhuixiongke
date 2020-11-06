using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    public partial class MED_COMM_VITAL_REC
    {
        public List<MED_VITAL_SIGN> ToVitalSignList()
        {
            List<MED_VITAL_SIGN> tmpList = new List<MED_VITAL_SIGN>();
            if (NIBP_SYS.HasValue && NIBP_DIA.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "89",
                    ITEM_NAME = "收缩压",
                    ITEM_VALUE = NIBP_SYS.Value.ToString()
                });
            }

            if (NIBP_DIA.HasValue && NIBP_DIA.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "90",
                    ITEM_NAME = "舒张压",
                    ITEM_VALUE = NIBP_DIA.Value.ToString()
                });
            }

            if (IBP_SYS.HasValue && IBP_SYS.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "65",
                    ITEM_NAME = "有创收缩压",
                    ITEM_VALUE = IBP_SYS.Value.ToString()
                });
            }

            if (IBP_DIA.HasValue && IBP_DIA.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "66",
                    ITEM_NAME = "有创舒张压",
                    ITEM_VALUE = IBP_DIA.Value.ToString()
                });
            }

            if (IBP_MEAN.HasValue && IBP_MEAN.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "67",
                    ITEM_NAME = "有创平均压",
                    ITEM_VALUE = IBP_MEAN.Value.ToString()
                });
            }

            if (CVP.HasValue && CVP.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "71",
                    ITEM_NAME = "中心静脉压",
                    ITEM_VALUE = CVP.Value.ToString()
                });
            }

            if (PULSE.HasValue && PULSE.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "44",
                    ITEM_NAME = "脉搏",
                    ITEM_VALUE = PULSE.Value.ToString()
                });
            }

            if (HR.HasValue && HR.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "40",
                    ITEM_NAME = "心率",
                    ITEM_VALUE = HR.Value.ToString()
                });
            }

            if (RESP.HasValue && RESP.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "92",
                    ITEM_NAME = "呼吸",
                    ITEM_VALUE = RESP.Value.ToString()
                });
            }

            if (BODY_TEMP.HasValue && BODY_TEMP.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "100",
                    ITEM_NAME = "体温",
                    ITEM_VALUE = BODY_TEMP.Value.ToString()
                });
            }

            if (RECTAL_TEMP.HasValue && RECTAL_TEMP.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "104",
                    ITEM_NAME = "直肠温",
                    ITEM_VALUE = RECTAL_TEMP.Value.ToString()
                });
            }

            if (SPO2.HasValue && SPO2.Value > 0)
            {
                tmpList.Add(new MED_VITAL_SIGN()
                {
                    TIME_POINT = this.TIME_POINT,
                    ITEM_CODE = "188",
                    ITEM_NAME = "血氧饱和度",
                    ITEM_VALUE = SPO2.Value.ToString()
                });
            }
            return tmpList;
        }
    }
}
