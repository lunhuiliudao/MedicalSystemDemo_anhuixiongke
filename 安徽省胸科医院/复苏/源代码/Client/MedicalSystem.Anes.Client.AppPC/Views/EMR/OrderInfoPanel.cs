using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(false)]
    public partial class OrderInfoPanel : BaseView
    {
        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        protected string _patientId = "";
        protected int _visitId = 0;
        protected DataTable _datatable;
        IEnumerable<MED_ORDERS> OrderList = null;
        public OrderInfoPanel()
        {
            _patientId = ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitId = ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID;
            InitializeComponent();
            Caption = ViewNames.HisOrderInfo;
        }


        public OrderInfoPanel(string patientId, int visitId)
        {
            _patientId = patientId;
            _visitId = visitId;
            InitializeComponent();
            Caption = ViewNames.HisOrderInfo;
        }

        private void OrderInfoPanel_Load(object sender, EventArgs e)
        {
            try
            {
                string ret = syncInfoRepository.SyncOrderInfo(_patientId, (int)_visitId).Data;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            List<LookUpEditItem> data1 = new List<LookUpEditItem>();
            data1.Add(new LookUpEditItem("临时", 0M));
            data1.Add(new LookUpEditItem("长期", 1M));
            repositoryItemLookUpEdit1.DataSource = data1;
            GetAllOrder();
            radioGroup1.SelectedIndex = 0;
            radioGroup2.SelectedIndex = 0;
        }
        private void GetAllOrder()
        {
            string PATIENT_ID = ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID;//"454550";
            int VISIT_ID = ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID;

            DateTime ExecuteBeginTime = DateTime.Now;
            if (ExtendApplicationContext.Current.PatientInformationExtend.SCHEDULED_DATE_TIME.HasValue)
            {
                ExecuteBeginTime = accountRepository.GetServerTime().Data;
            }
            else
            {
                ExecuteBeginTime = (DateTime)ExtendApplicationContext.Current.PatientInformationExtend.SCHEDULED_DATE_TIME;
            }
            DateTime ExecuteEndTime = accountRepository.GetServerTime().Data;
            OrderList = operationInfoRepository.GetOrders(PATIENT_ID, VISIT_ID, ExecuteBeginTime, ExecuteEndTime).Data;
            gridControl1.DataSource = OrderList;
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string filter = "";
            var result = OrderList;
            if (result != null)
            {
                switch (radioGroup1.SelectedIndex)
                {
                    case 0:
                        //filter = "";
                        break;
                    case 1:
                        result = result
                     .Select(l => l)
                     .Where(l => l.REPEAT_INDICATOR == 0).ToList();
                        break;
                    case 2:
                        result = result
                     .Select(l => l)
                     .Where(l => l.REPEAT_INDICATOR == 1).ToList();
                        break;
                }
                if (radioGroup2.SelectedIndex > 0)
                {
                    result = result
                    .Select(l => l)
                    .Where(l => l.ORDER_STATUS == radioGroup2.SelectedIndex.ToString()).ToList();
                }
            }

            gridControl1.DataSource = result;
        }
    }
}
