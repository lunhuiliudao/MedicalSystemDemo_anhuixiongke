using System;
using System.Collections.Generic;
using System.Text;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Configurations;
using System.Data;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Documents
{
   public class LabelHandler:UIElementHandler<MLabel>
    {
       public override void BindDataToUI(MLabel control, Dictionary<string, System.Data.DataTable> dataSources)
       {
           if (control.Text.Contains("<%=DeptName%>"))
           {
               control.Text = control.Text.Replace("<%=DeptName%>", GetDeptName());
           }
           if (control.Name == "PageIndex")
           {
               control.Text = string.Format("{0}/{1}", PagerSetting.CurrentPageIndex + 1, PagerSetting.TotalPageCount);
           }
           
       }
       public override void ControlSetting(MLabel control)
       {
           control.BackColor = Color.White;
       }
       private string GetDeptName()
       {
           //string patientID =ExtendAppContext.Current.PatientContext.PatientID;
           //int visitID =ExtendAppContext.Current.PatientContext.VisitID;
           //int operID =ExtendAppContext.Current.PatientContext.OperID; 

           //string deptCode = GetDeptCode(patientID, visitID, operID);
           //if (string.IsNullOrEmpty(deptCode))
           //{
           //    deptCode = "";
           //}
           //else
           //{
              
           //   if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("MED_DEPT_DICT"))
           //       throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", "MED_DEPT_DICT"));

           //   //Dict.MedDeptDictDataTable deptDict =ExtendAppContext.Current.CodeTables["MED_DEPT_DICT"] as Dict.MedDeptDictDataTable;
           //   DataTable deptDict =ExtendAppContext.Current.CodeTables["MED_DEPT_DICT"];
           //    DataRow[] rows = deptDict.Select("DEPT_CODE = '" + deptCode + "'");
           //    if (rows != null && rows.Length > 0)
           //    {
           //        object obj = rows[0]["DEPT_NAME"];
           //        if (obj != System.DBNull.Value)
           //        {
           //            return obj.ToString();
           //        }
           //    }
           //}
           //return deptCode;
           return "";
       }

       private   string GetDeptCode(string patientID, int visitID, int operID)
       {
           //if (!DataSource.ContainsKey("MED_OPERATION_MASTER"))
           //    throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.OperationMasterDataTable,请添加此绑定数据源!", "MED_OPERATION_MASTER"));

           //AnesInformations.OperationMasterDataTable operationMaster = base.DataSource["MED_OPERATION_MASTER"] as AnesInformations.OperationMasterDataTable;

           //if (operationMaster != null && operationMaster.Count > 0)
           //{
           //    PatientInformationsDA patientInformationsDA = new PatientInformationsDA();
           //    PatientBaseInformations.PatsInHospitalDataTable dt = patientInformationsDA.GetPatsInHospital(operationMaster[0].PATIENT_ID, operationMaster[0].VISIT_ID);
           //    if (dt != null && dt.Count > 0 && !dt[0].IsDEPT_CODENull())
           //    {
           //        return dt[0].DEPT_CODE;
           //    }
           //}

           //return ApplicationConfiguration.OpertionDeptCode;
           return "";
       }

       
    }
}
