using MedicalSystem.AnesIcuQuery.Common;
using MedicalSystem.AnesIcuQuery.Models;
using System.Data;

namespace MedicalSystem.MedScreen.Common
{
    public class QueryParmHelper
    {
        public static QueryParams GetCommQueryObject()
        {
            QueryParams anesQueryPar = new QueryParams();
            //构造报表列
            DataTable dt = CommHelper.CreateConfigTable();
            string[] fieldName = new string[] { "PATIENT_ID", "NAME", "OPER_DATE", "SURGEON", "OPERATION_NAME", "ANESTHESIA_DOCTOR" };//绑定字段
            string[] Title = new string[] { "患者ID", "患者姓名", "手术日期", "手术医生", "手术名称", "麻醉医师" };//标题
            int[] Width = new int[] { 100, 100, 100, 100, 100, 100, };
            string[] IsSHow = new string[] { "是", "是", "是", "是", "是", "是" };//是否显示
            for (int i = 0; i < fieldName.Length; i++)
            {
                DataRow newrow = dt.NewRow();
                newrow["FieldName"] = fieldName[i];
                newrow["Title"] = Title[i];
                newrow["Width"] = Width[i];
                newrow["IsSHow"] = IsSHow[i];
                dt.Rows.Add(newrow);
            }
            anesQueryPar.LoadColumnDefines(dt);

            return anesQueryPar;
        }
    }
}
