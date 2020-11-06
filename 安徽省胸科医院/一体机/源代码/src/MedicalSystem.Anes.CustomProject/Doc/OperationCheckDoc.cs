// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperationCheckDoc.cs
// 功能描述(Description)：    手术清点单对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 手术清点单
    /// </summary>
    public partial class OperationCheckDoc : CustomBaseDoc
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public OperationCheckDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = true;
        }

        /// <summary>
        /// 初始化自定义的UIElementHandler
        /// </summary>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            // 去除通用的表格Handler，使用OperCheckGridViewHandler，个性化处理表格内部的数据
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

        /// <summary>
        /// 数据源绑定
        /// </summary>
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

        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            // 手术清点单添加多表格保存功能
            MED_QIXIE_QINGDIAN row = null;
            List<MED_QIXIE_QINGDIAN> dataTable = new ModelHandler<MED_QIXIE_QINGDIAN>().FillModel(dataSource["MED_QIXIE_QINGDIAN"]);
            string patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            if (dataTable == null)
            {
                dataTable = CareDocService.ClientInstance.GetOperCheckList(patientID, visitID, operID);
            }

            List<MedGridView> grids = base.GetControls<MedGridView>();
            foreach (MedGridView grid in grids)
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    for (int j = 0; j < grid.ColumnCount; j++)
                    {
                        DataGridViewCell cell = grid[j, i];
                        List<MED_QIXIE_QINGDIAN> rows = null;
                        rows = dataTable.Where(x => x.PATIENT_ID == patientID && 
                                                    x.VISIT_ID == visitID && 
                                                    x.OPER_ID == operID && 
                                                    x.X_POSITION == j && 
                                                    x.Y_POSITION == i && 
                                                    x.TABLETAG == grid.Name).ToList();
                        if (rows != null && rows.Count > 0)
                        {
                            row = rows[0];
                        }
                        else
                        {
                            row = null;
                        }

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

            

            List<MED_QIXIE_QINGDIAN> operCheck = dataTable;
            if (operCheck != null)
                CareDocService.ClientInstance.SaveOperCheckList(operCheck);

            bool result = this.SaveDocDataPars(dataSource);
            return result;
        }
    }
}
