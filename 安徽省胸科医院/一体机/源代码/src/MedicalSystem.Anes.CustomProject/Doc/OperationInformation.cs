// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperationInformation.cs
// 功能描述(Description)：    患者手术信息文书对应的实体类
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
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 患者手术信息文书
    /// </summary>
    public partial class OperationInformation : CustomBaseDoc
    {
        private bool isRoomnoORSequenceChanged = false;                       // 手术间或者台次有变更的标识

        /// <summary>
        /// 无参构造
        /// </summary>
        public OperationInformation()
        {
            InitializeComponent();
            base.PrintButton.Visible = false;
            base.DocKind = DocKind.Default;
            base.HideScrollBar();
        }
        
        /// <summary>
        /// 手术间和台次文本框
        /// </summary>
        private void ctl_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as MTextBox).Text))
                isRoomnoORSequenceChanged = true;
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            if (isRoomnoORSequenceChanged) Dialog.MessageBox("温馨提示：修改手术间号和台次将会影响当前已安排手术，请结合实际情况修改。");
            base.OnSaveData(dataSource);
            bool result = this.SaveDocDataPars(dataSource);

            MED_OPERATION_MASTER operationMaster = AnesInfoService.ClientInstance.GetOperationMaster(
                                                   ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                   ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                   ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
            // 重置全局变量值
            if (ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO != operationMaster.OPER_ROOM_NO)
            {
                ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO = operationMaster.OPER_ROOM_NO;
            }
            if (operationMaster.SEQUENCE.HasValue && 
                ExtendAppContext.Current.PatientInformationExtend.SEQUENCE != operationMaster.SEQUENCE)
            {
                ExtendAppContext.Current.PatientInformationExtend.SEQUENCE = operationMaster.SEQUENCE;
            }
            if (operationMaster.EMERGENCY_IND.HasValue && 
                ExtendAppContext.Current.PatientInformationExtend.EMERGENCY_IND != operationMaster.EMERGENCY_IND)
            {
                ExtendAppContext.Current.PatientInformationExtend.EMERGENCY_IND = operationMaster.EMERGENCY_IND;
            }
            if (operationMaster.ISOLATION_IND.HasValue && 
                ExtendAppContext.Current.PatientInformationExtend.ISOLATION_IND != operationMaster.EMERGENCY_IND)
            {
                ExtendAppContext.Current.PatientInformationExtend.ISOLATION_IND = operationMaster.ISOLATION_IND;
            }

            return result;
        }
    }
}
