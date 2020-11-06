using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class OperCheckGridViewHandler : GridViewHandler
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        public override void BindDataToUI(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            control.EnableHeadersVisualStyles = false;
            base.BindDataToUI(control, dataSources);
            control.Rows.Clear();
            //自动生成列
            control.AutoCreateColumns();
            InitGridSource(control, dataSources);
            for (int j = 0; j < control.Columns.Count; j++)
            {
                control.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            List<MED_QIXIE_QINGDIAN> dataTable = ModelHelper<MED_QIXIE_QINGDIAN>.ConvertDataTableToList(dataSources["MED_QIXIE_QINGDIAN"]); 
            int rowCount = control.LinesPerPage;
            for (int i = 0; i < rowCount; i++)
            {
                int index = control.Rows.Add();
                control.Rows[i].Tag = i;
            }
            if (dataTable!=null && dataTable.Count > 0)
            {
                foreach (MED_QIXIE_QINGDIAN row in dataTable)
                {
                    if (control.Name == row.TABLETAG) 
                    { 
                            if (row.Y_POSITION >= rowCount || row.Y_POSITION < 0) continue;
                            int x, y;
                            x = Convert.ToInt16(row.X_POSITION);
                            y = Convert.ToInt16(row.Y_POSITION);
                            control[x, y].Value = row.POSITION_VALUE;
                            control[x, y].Tag = row.POSITION_VALUE; 
                    }
                }
            }
        }

        private void InitGridSource(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            List<MED_QIXIE_QINGDIAN> dataTable = ModelHelper<MED_QIXIE_QINGDIAN>.ConvertDataTableToList(dataSources["MED_QIXIE_QINGDIAN"]);
            List<MED_QIXIE_QINGDIAN> qiXierows = null;
            if (dataTable != null && dataTable.Count > 0)
            {
                qiXierows = dataTable.Where(x => x.TABLETAG == control.Name).ToList(); ;
            }
            if (qiXierows == null || qiXierows.Count == 0)
            {
                if (dataTable == null)
                {
                    dataTable = operationInfoRepository.GetOperCheckList(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, 
                        ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                }
                if (string.IsNullOrEmpty(control.DefaultDatas)) return;
                string defaultDatas = control.DefaultDatas;
                string[] rows = defaultDatas.Split(new string[] { "{}" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < rows.Length; i++)
                {
                    string[] rowdatas = rows[i].Split(new string[] { "[]" }, StringSplitOptions.None);
                    for (int j = 0; j < rowdatas.Length; j++)
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(rowdatas[j])) continue;
                            MED_QIXIE_QINGDIAN row = new MED_QIXIE_QINGDIAN();
                            row.PATIENT_ID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
                            row.VISIT_ID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
                            row.OPER_ID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
                            row.X_POSITION = j;
                            row.Y_POSITION = i;
                            row.POSITION_VALUE = rowdatas[j];
                            row.TABLETAG = control.Name;
                            dataTable.Add(row);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }
                dataSources["MED_QIXIE_QINGDIAN"] = ModelHelper<MED_QIXIE_QINGDIAN>.ConvertListToDataTable(dataTable); 
            }
        }

        public override void RefreshData()
        { 
            base.RefreshData();
        }
    }
}
