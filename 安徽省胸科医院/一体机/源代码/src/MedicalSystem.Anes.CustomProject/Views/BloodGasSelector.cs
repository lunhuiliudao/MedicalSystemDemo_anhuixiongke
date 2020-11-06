using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;

namespace MedicalSystem.Anes.CustomProject
{
    [ToolboxItem(false)]
    public partial class BloodGasSelector : UserControl
    {
        private string _patientID;
        private decimal _visitID;
        private decimal _operID;
        private DateTime _defaultDate = DateTime.Now.Date;

        public DateTime DefaultDate
        {
            get { return _defaultDate; }
            set { _defaultDate = value; }
        }

        private string _selectedDetailID = "";

        public string SelectedDetailID
        {
            get { return _selectedDetailID; }
            set { _selectedDetailID = value; }
        }

        public BloodGasSelector()
        {
            InitializeComponent();
        }

        public BloodGasSelector(string patientID, decimal visitID, decimal operID)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            btnOK.Enabled = false;
        }

        private string GetDisplayName(MED_BLOOD_GAS_MASTER row)
        {
            string itemText = "静脉";
            if (!string.IsNullOrEmpty(row.NURSE_MEMO1.Trim()))
            {
                itemText = row.NURSE_MEMO1;
            }
            return itemText;
        }

        private void resetListView()
        {
            btnOK.Enabled = false;
            listView1.Items.Clear();
            listView2.Items.Clear();
            List<BloodGasMaster> leftBloodGasMasters = new List<BloodGasMaster>();
            List<BloodGasMaster> rightBloodGasMasters = new List<BloodGasMaster>();
            List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = AnesInfoService.ClientInstance.GetBloodGasMasterAllList();
            if (bloodGasMasterDataTable.Count > 0)
            {
                bloodGasMasterDataTable = bloodGasMasterDataTable.Where(x => x.RECORD_DATE >= dateEdit1.DateTime && x.RECORD_DATE < dateEdit1.DateTime.AddDays(1)).ToList();
            }
            if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count > 0)
            {
                BloodGasMaster bloodGasMaster;
                foreach (MED_BLOOD_GAS_MASTER row in bloodGasMasterDataTable)
                {
                    if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.PATIENT_ID == _patientID && row.VISIT_ID == _visitID && row.OPER_ID == _operID)
                    {
                        bloodGasMaster = new BloodGasMaster();
                        bloodGasMaster.DisplayName = GetDisplayName(row);
                        bloodGasMaster.Recorddate = row.RECORD_DATE;
                        bloodGasMaster.DetailId = row.DETAIL_ID;
                        leftBloodGasMasters.Add(bloodGasMaster);
                    }
                    else if (string.IsNullOrEmpty(row.PATIENT_ID) || (row.PATIENT_ID == "0" && row.VISIT_ID == 0))
                    {
                        bloodGasMaster = new BloodGasMaster();
                        bloodGasMaster.DisplayName = GetDisplayName(row);
                        bloodGasMaster.Recorddate = row.RECORD_DATE;
                        bloodGasMaster.DetailId = row.DETAIL_ID;
                        rightBloodGasMasters.Add(bloodGasMaster);
                    }
                }
                leftBloodGasMasters.Sort(new Comparison<BloodGasMaster>(delegate(BloodGasMaster bloodGasMaster1, BloodGasMaster bloodGasMaster2)
                {
                    return bloodGasMaster1.Recorddate.CompareTo(bloodGasMaster2.Recorddate);
                }));
                rightBloodGasMasters.Sort(new Comparison<BloodGasMaster>(delegate(BloodGasMaster bloodGasMaster1, BloodGasMaster bloodGasMaster2)
                {
                    return bloodGasMaster1.Recorddate.CompareTo(bloodGasMaster2.Recorddate);
                }));
                ListViewItem item;
                foreach (BloodGasMaster blgMaster in leftBloodGasMasters)
                {
                    item = listView1.Items.Add(blgMaster.Recorddate.ToString());
                    item.Tag = blgMaster.DetailId;
                    item.ToolTipText = blgMaster.DisplayName;
                }
                foreach (BloodGasMaster blgMaster in rightBloodGasMasters)
                {
                    item = listView2.Items.Add(blgMaster.Recorddate.ToString());
                    item.Tag = blgMaster.DetailId;
                    item.ToolTipText = blgMaster.DisplayName;
                }
            }
        }

        private void BloodGasSelector_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DefaultDate;
            resetListView();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count == 1)
            {
                SelectedDetailID = listView1.SelectedItems[0].Tag.ToString();
                ParentForm.DialogResult = DialogResult.OK;
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.Items.Count == 0 || listView1.FocusedItem == null || listView1.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (listView2.Items.Count == 0 || listView2.FocusedItem == null || listView2.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = AnesInfoService.ClientInstance.GetBloodGasMasterListByID(listView1.FocusedItem.Tag.ToString());
                if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
                {
                    bloodGasMasterDataTable[0].PATIENT_ID = "0";
                    bloodGasMasterDataTable[0].VISIT_ID = 0;
                    bloodGasMasterDataTable[0].OPER_ID = 0;
                    bloodGasMasterDataTable[0].NURSE_MEMO1 = null;
                    bloodGasMasterDataTable[0].NURSE_MEMO2 = null;
                    if (AnesInfoService.ClientInstance.SaveBloodGasMaster(bloodGasMasterDataTable))
                    {
                        resetListView();
                    }
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listView2.FocusedItem != null)
            {
                List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = AnesInfoService.ClientInstance.GetBloodGasMasterListByID(listView2.FocusedItem.Tag.ToString());
                if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
                {
                    bloodGasMasterDataTable[0].PATIENT_ID = "0";
                    bloodGasMasterDataTable[0].VISIT_ID = 0;
                    bloodGasMasterDataTable[0].OPER_ID = 0;
                    bloodGasMasterDataTable[0].NURSE_MEMO1 = null;
                    bloodGasMasterDataTable[0].NURSE_MEMO2 = null;
                    if (AnesInfoService.ClientInstance.SaveBloodGasMaster(bloodGasMasterDataTable))
                    {
                        resetListView();
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count == 1)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            resetListView();
        }
    }
}
