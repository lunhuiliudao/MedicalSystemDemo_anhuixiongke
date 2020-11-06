// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      RegisterAfterOperation.cs
// 功能描述(Description)：    术后确认单对应的实体类
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
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 术后确认单对应的实体类
    /// </summary>
    public partial class RegisterAfterOperation : CustomBaseDoc
    {
        private MTextBox txtInRoomTime = null;                        // 入室时间文本框
        private MTextBox txtOutRoomTime = null;                       // 出室时间文本框
        private MTextBox txtOperStart = null;                         // 手术开始时间文本框
        private MTextBox txtOperEnd = null;                           // 手术结束时间文本框

        /// <summary>
        /// 无参构造
        /// </summary>
        public RegisterAfterOperation()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            List<MED_OPERATION_MASTER> operationMasterDataTable = new ModelHandler<MED_OPERATION_MASTER>().FillModel(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER masterRow = operationMasterDataTable.Count > 0 ? operationMasterDataTable[0] : null;
            if (txtOutRoomTime.Text != "" && masterRow != null)
            {
                if (!string.IsNullOrEmpty(masterRow.OPER_STATUS_CODE.ToString()) || masterRow.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                {
                    masterRow.ANES_START_TIME = masterRow.START_DATE_TIME;
                    masterRow.ANES_END_TIME = masterRow.END_DATE_TIME;
                    masterRow.OPER_STATUS_CODE = (int)OperationStatus.OutOperationRoom;
                    ExtendAppContext.Current.PatientInformationExtend.IN_DATE_TIME = masterRow.IN_DATE_TIME;
                    ExtendAppContext.Current.PatientInformationExtend.OUT_DATE_TIME = masterRow.OUT_DATE_TIME;
                    ExtendAppContext.Current.PatientInformationExtend.START_DATE_TIME = masterRow.START_DATE_TIME;
                    ExtendAppContext.Current.PatientInformationExtend.END_DATE_TIME = masterRow.END_DATE_TIME;
                    ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE = masterRow.OPER_STATUS_CODE;
                }
            }

            dataSource["MED_OPERATION_MASTER"] = new ModelHandler().FillDataTable(new List<MED_OPERATION_MASTER>() { masterRow});

            ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO = masterRow.OPER_ROOM_NO;
            bool result = this.SaveDocDataPars(dataSource);
            return result;
        }

        /// <summary>
        /// 重写保存数据前判断逻辑：必填项提示和时间节点的判断
        /// </summary>
        public override bool OnCustomCheckBeforeSave()
        {
            bool bl = base.OnCustomCheckBeforeSave();
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.GetControlType == typeof(MTextBox) && handler.GetAllControls != null)
                {
                    foreach (Control ctl in handler.GetAllControls)
                    {
                        if (ctl is MTextBox)
                        {
                            MTextBox textbox = ctl as MTextBox;
                            if (!string.IsNullOrEmpty(textbox.InputNeededMessage) && string.IsNullOrEmpty(textbox.Text.Trim()))
                            {
                                MessageBoxFormPC.Show(textbox.InputNeededMessage);
                                return false;
                            }
                        }
                    }
                    foreach (Control ctl in handler.GetAllControls)
                    {
                        if (ctl is MTextBox)
                        {
                            if (ctl.Name == "txtInRoomTime")
                            {
                                txtInRoomTime = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOutRoomTime")
                            {
                                txtOutRoomTime = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOperStart")
                            {
                                txtOperStart = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOperEnd")
                            {
                                txtOperEnd = ctl as MTextBox;
                            }
                        }
                    }

                    bl = CheckTime();
                }
            }

            return bl;
        }

        /// <summary>
        /// 对四个时间点的逻辑判断
        /// </summary>
        private bool CheckTime()
        {
            if (txtInRoomTime != null && txtOperStart != null && txtOperEnd != null && txtOutRoomTime != null)
            {
                if (txtInRoomTime.Text != "" && txtOperStart.Text != "" && 
                    DateTime.Parse(txtOperStart.Text) < DateTime.Parse(txtInRoomTime.Text))
                {
                    MessageBoxFormPC.Show("手术开始时间不可早于入室时间");
                    return false;
                }
                else if (txtOperEnd.Text != "" && txtOperStart.Text != "" && 
                         DateTime.Parse(txtOperEnd.Text) < DateTime.Parse(txtOperStart.Text))
                {
                    MessageBoxFormPC.Show("手术结束时间不可早于手术开始时间");
                    return false;
                }
                else if (txtOutRoomTime.Text != "" && txtOperEnd.Text != "" && 
                         DateTime.Parse(txtOutRoomTime.Text) < DateTime.Parse(txtOperEnd.Text))
                {
                    MessageBoxFormPC.Show("出室时间不可早于手术结束时间");
                    return false;
                }
            }

            return true;
        }
    }
}
