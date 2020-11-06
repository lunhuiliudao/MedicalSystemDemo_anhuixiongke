using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
     public partial  class MED_LAB_RESULT
     {
         [NotMapped]
         public virtual string ABNORMAL_INDICATOR_TXT { get; set; }

         [NotMapped]
         public virtual string RESULT_SYMBOL
         {
             get
             {
                 string strSymbol = string.Empty;
                 if(!string.IsNullOrEmpty(RESULT) && !string.IsNullOrEmpty(REFERENCE_RESULT))
                 {
                     // 检验结果
                     string strResult = RESULT.ToString();
                     // 参考值
                     string strReferenceResult = REFERENCE_RESULT.ToString();
                     string[] strRefResultArr = strReferenceResult.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                     decimal result = 0;     // 检验结果
                     decimal refResMin = 0;  // 参考值最小值
                     decimal refResMax = 0;  // 参考值最大值
                     if (decimal.TryParse(strResult, out result) && strRefResultArr.Length == 2 &&
                         decimal.TryParse(strRefResultArr[0], out refResMin) &&
                         decimal.TryParse(strRefResultArr[1], out refResMax))
                     {
                         if (result < refResMin)           // 偏低
                         {
                             strSymbol = "↓";
                         }
                         else if (result > refResMax)      // 偏高
                         {
                             strSymbol = "↑";
                         }
                     }
                 }

                 return strSymbol;
             }
         }
    }
}
