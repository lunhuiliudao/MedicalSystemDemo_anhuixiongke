// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SYRMGridViewHandler.cs
// 功能描述(Description)：    术后随访文书中表格控件对应的Handler
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
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.FrameWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject.AnesVisitDocHandlers
{
    public class SYRMGridViewHandler : GridViewHandler
    {
        private MedGridView MedGridViewScore = null;
        private MedGridView MedGridViewAldrete = null;
        public delegate void RefreshTotalScore(object sender, SYRMGridViewCellValueChangeEventArgs e);    // 刷新总分的委托事件
        public event RefreshTotalScore OnRefreshTotalScore = null ;                                       // 刷新总分的事件

        /// <summary>
        /// 控件属性事件设置
        /// </summary>
        public override void ControlSetting(MedGridView control)
        {
            base.ControlSetting(control);

            // 计算评分，绑定事件
            if (control.Name.ToUpper() == "MedGridViewScore".ToUpper())
            {
                control.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(GridView_Validating);
                control.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(GridView_CellValidated);
                control.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(GridView_CellValueChanged);
                MedGridViewScore = control;
                this.RefreshScore();
            }
            else if (control.Name.ToUpper() == "MedGridViewAldrete".ToUpper())
            {
                control.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(GridView_Validating);
                control.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(GridView_CellValidated);
                MedGridViewAldrete = control;
            }
        }

        /// <summary>
        /// 单元格验证事件
        /// </summary>
        public void GridView_Validating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        /// <summary>
        /// 单元格验证完成后触发
        /// </summary>
        public void GridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            MedGridView grid = (MedGridView)sender;
        }

        /// <summary>
        /// 单元格的值变更事件
        /// </summary>
        public void GridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MedGridView grid = (MedGridView)sender ;
            if (MedGridViewScore != null &&  (MedGridViewScore.Columns[e.ColumnIndex].HeaderText == "评分"))
            {
                decimal valueTatol = 0;
                for (int i = 0; i < MedGridViewScore.RowCount; i++)
                { 
                    if ( MedGridViewScore.Rows[i].Cells[e.ColumnIndex].Value != null)
                    {
                        decimal temp = 0 ;
                        decimal.TryParse(MedGridViewScore.Rows[i].Cells[e.ColumnIndex].Value.ToString(), out temp);
                        valueTatol += temp;
                    }
                }

                // 计算值后生成事件参数
                SYRMGridViewCellValueChangeEventArgs EventArgs = new SYRMGridViewCellValueChangeEventArgs((int)Math.Round(valueTatol)); 
                // 异步调用值变化的事件
                if (OnRefreshTotalScore != null)
                {
                    OnRefreshTotalScore(sender, EventArgs); 
                }
            }
        }

        /// <summary>
        /// 刷新总分
        /// </summary>
        public void RefreshScore()
        {
            int ColumnIndex = -1 ;
            for (int i = 0; i < MedGridViewScore.Columns.Count; i++)
            {
                if (MedGridViewScore != null && (MedGridViewScore.Columns[i].HeaderText == "评分"))
                {
                    ColumnIndex = i;
                    break;
                }
            }
            
            //如果没有找到
            if (ColumnIndex == -1)
            {
                return;
            }

            if (MedGridViewScore != null && (MedGridViewScore.Columns[ColumnIndex].HeaderText == "评分"))
            {
                decimal valueTatol = 0;
                for (int i = 0; i < MedGridViewScore.RowCount; i++)
                {
                    if (MedGridViewScore.Rows[i].Cells[ColumnIndex].Value != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(MedGridViewScore.Rows[i].Cells[ColumnIndex].Value.ToString(), out temp);
                        valueTatol += temp;
                    }
                }

                // 计算值后生成事件参数
                SYRMGridViewCellValueChangeEventArgs EventArgs = new SYRMGridViewCellValueChangeEventArgs((int)Math.Round(valueTatol));
                // 调用值变化的事件
                if (OnRefreshTotalScore != null)
                {
                    OnRefreshTotalScore(MedGridViewScore, EventArgs);
                }
            }
        }

        /// <summary>
        /// 将数据绑定到UI界面
        /// </summary>
        public override void BindDataToUI(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            control.EnableHeadersVisualStyles = false;
            base.BindDataToUI(control, dataSources);
            for (int j = 0; j < control.Columns.Count; j++)
            {
                control.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 初始化表格数据
        /// </summary>
        protected override void InitGridModelData(MedGridView control, Dictionary<string, System.Data.DataTable> datasources)
        {
            DataTable dataTable = null;
            string defaultDatas = control.DefaultDatas;
            string[] rows = defaultDatas.Split(new string[] { "{}" }, StringSplitOptions.RemoveEmptyEntries);

            if (control.Name.ToUpper() == "MedGridViewAnesScore".ToUpper())
            {
                dataTable = DataContext.GetCurrent().GetData("MED_ANES_SORCE");
            }
            else if (control.Name.ToUpper() == "MedGridViewScore".ToUpper())
            {
                dataTable = DataContext.GetCurrent().GetData("MED_PACU_SORCE");
            }
            else if (control.Name.ToUpper() == "MedGridViewAldrete".ToUpper())
            {
                dataTable = DataContext.GetCurrent().GetData("MED_PACU_ALDRETE_SORCE");

            }

            if (dataTable.Rows.Count > 0)
            {
            }
            else
            {
                // 没有记录 读取模板
                control.RowCount = rows.Length;
                for (int i = 0; i < rows.Length; i++)
                {
                    try
                    {
                        string[] rowdatas = rows[i].Split(new string[] { "[]" }, StringSplitOptions.None);
                        DataRow row = dataTable.NewRow();
                        row["PATIENT_ID"] = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                        row["VISIT_ID"] = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                        row["OPER_ID"] =  ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                        row["ORDER_ID"] = i + 1;
                        for (int j = 0; j < control.Columns.Count; j++)
                        {
                            if (!string.IsNullOrEmpty(rowdatas[j]))
                            {
                                row[control.Columns[j].DataPropertyName] = rowdatas[j];
                            }
                        }

                        control.Rows[i].Tag = i;
                        dataTable.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                }

                if (control.Name.ToUpper() == "MedGridViewAnesScore".ToUpper())
                {
                    datasources["MED_ANES_SORCE"] = dataTable;
                }
                else if (control.Name.ToUpper() == "MedGridViewScore".ToUpper())
                {
                    datasources["MED_PACU_SORCE"] = dataTable;
                }
                else if (control.Name.ToUpper() == "MedGridViewAldrete".ToUpper())
                {
                    datasources["MED_PACU_ALDRETE_SORCE"] = dataTable;
                }
            }
        }

        /// <summary>
        /// 验证数据
        /// </summary>
        public override bool Validate()
        {
            if (!base.Validate())
            {
                return false;
            }

            if (MedGridViewScore != null)
            {
                for (int j = 0; j < MedGridViewScore.Columns.Count; j++)
                {
                    if (MedGridViewScore.Columns[j].HeaderText == "评分")
                    {
                        for (int i = 0; i < MedGridViewScore.RowCount; i++)
                        {
                            object obj = MedGridViewScore.Rows[i].Cells[j].EditedFormattedValue;
                            if (obj != null)
                            {
                                string valueString = obj.ToString();
                                if (valueString.Length > 1 || !"012".Contains(valueString))
                                {
                                    string msg = "评分值只能是 0、1 、2 ，请重新输入 ";
                                    Dialog.MessageBox(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MedGridViewScore.CurrentCell = MedGridViewScore.Rows[i].Cells[j];
                                    return false;
                                }
                            }
                        }

                        break; ;
                    }
                }
            }

            return true;
        }
    }
}
