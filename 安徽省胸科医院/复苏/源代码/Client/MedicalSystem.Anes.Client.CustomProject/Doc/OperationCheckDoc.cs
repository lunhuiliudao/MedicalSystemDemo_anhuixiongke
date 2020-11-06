using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class OperationCheckDoc : CustomBaseDoc
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        public OperationCheckDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = true;
        }
        /// <summary>
        /// 初始化自定义的UIElementHandler
        /// </summary>
        /// <param name="handlers"></param>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            IUIElementHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is GridViewHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }
            OperCheckGridViewHandler gridViewHandler = new OperCheckGridViewHandler();
            handlers.Add(gridViewHandler);
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            dataSource["MED_PREOPERATIVE_EXPANSION"] = DataContext.GetCurrent().GetData("MED_PREOPERATIVE_EXPANSION");
            dataSource["MED_QIXIE_QINGDIAN"] = DataContext.GetCurrent().GetData("MED_QIXIE_QINGDIAN");
        }
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            #region 手术清点单添加多表格功能
            List<MED_QIXIE_QINGDIAN> dataTable = ModelHelper<MED_QIXIE_QINGDIAN>.ConvertDataTableToList(dataSource["MED_QIXIE_QINGDIAN"]);

            MED_QIXIE_QINGDIAN row = null;
            string patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            int visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            int operID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            if (dataTable == null)
                dataTable = operationInfoRepository.GetOperCheckList(patientID, visitID, operID).Data;
            List<MedGridView> grids = base.GetControls<MedGridView>();
            foreach (MedGridView grid in grids)
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    for (int j = 0; j < grid.ColumnCount; j++)
                    {
                        DataGridViewCell cell = grid[j, i];
                        List<MED_QIXIE_QINGDIAN> rows = null;
                        rows = dataTable.Where(x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.X_POSITION == j
                         && x.Y_POSITION == i && x.TABLETAG == grid.Name).ToList();
                        if (rows != null && rows.Count > 0) row = rows[0];
                        else row = null;
                        string celltext = string.Empty;
                        if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString().Trim()))
                        {
                            celltext = cell.Value.ToString().Trim();
                        }
                        if (string.IsNullOrEmpty(celltext))
                        {
                            if (row != null)
                            {
                                row.POSITION_VALUE = "";
                            }
                        }
                        else
                        {
                            if (row == null)
                            {
                                row = new MED_QIXIE_QINGDIAN();
                                row.PATIENT_ID = patientID;
                                row.VISIT_ID = visitID;
                                row.OPER_ID = operID;
                                row.X_POSITION = j;
                                row.Y_POSITION = i;
                                row.TABLETAG = grid.Name;
                                dataTable.Add(row);
                            }
                            row.POSITION_VALUE = celltext;
                        }
                    }
                }
            }
            #endregion
            List<MED_OPERATION_MASTER> operMasterList = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER operMaster = null;
            if (operMasterList != null && operMasterList.Count > 0)
                operMaster = operMasterList[0];

            List<MED_PAT_MASTER_INDEX> patIndexList = ModelHelper<MED_PAT_MASTER_INDEX>.ConvertDataTableToList(dataSource["MED_PAT_MASTER_INDEX"]);
            MED_PAT_MASTER_INDEX patMasterIndex = null;
            if (patIndexList != null && patIndexList.Count > 0)
                patMasterIndex = patIndexList[0];

            List<MED_PAT_VISIT> patVisitList = ModelHelper<MED_PAT_VISIT>.ConvertDataTableToList(dataSource["MED_PAT_VISIT"]);
            MED_PAT_VISIT patVisit = null;
            if (patVisitList != null && patVisitList.Count > 0)
                patVisit = patVisitList[0];

            List<MED_OPERATION_EXTENDED> operExtended = ModelHelper<MED_OPERATION_EXTENDED>.ConvertDataTableToList(dataSource["MED_OPERATION_EXTENDED"]);

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = ModelHelper<MED_POSTOPERATIVE_EXTENDED>.ConvertDataTableToList(dataSource["MED_POSTOPERATIVE_EXTENDED"]);

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = ModelHelper<MED_PREOPERATIVE_EXPANSION>.ConvertDataTableToList(dataSource["MED_POSTOPERATIVE_EXTENDED"]);

            List<MED_QIXIE_QINGDIAN> operCheck = dataTable;
            if (operCheck != null)
                operationInfoRepository.SaveOperCheckList(operCheck);
            //OperationInfoService.SaveMedicalBasicDoc(operMaster, patIndex, patVisit, null, null, null, null, operExtended, postExtended, preExpansion);

            MED_PATS_IN_HOSPITAL patsInHospital = null;

            MED_ANESTHESIA_PLAN anesPlan = null;

            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;



            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });


        }
    }
}
