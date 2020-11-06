using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using InitDocare;

namespace DoCareEmr
{
    public partial class defaultSubClassA : InitDocare.BasePager
    {
        string DateType = PublicA.GetConfig("DataServerType");
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.BtSearch.Attributes.Add("onclick", "return dolocation();");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
       
        public void BindData()
        {
            string PATIENT_ID = this.GetRequest("PATIENT_ID");
            this.TbPatient_ID.Text = PATIENT_ID.Length > 0 ? (PATIENT_ID) : ("");
            PATIENT_ID = PATIENT_ID.Length > 0 ? (" and HIS_PATIENT_ID='" + PATIENT_ID + "'") : ("");

            string VISIT_ID = this.GetRequest("VISIT_ID");
            this.TbVisit_ID.Text = VISIT_ID.Length > 0 ? (VISIT_ID) : ("");
            VISIT_ID = VISIT_ID.Length > 0 ? (" and HIS_VISIT_ID='" + VISIT_ID + "'") : ("");

            string MR_CLASS = this.GetRequest("MR_CLASS");
            if (MR_CLASS.Length > 0)
            {
                if (MR_CLASS == "麻醉")
                {
                    this.RBanes.Checked = true;
                    MR_CLASS = MR_CLASS.Length > 0 ? (" and MR_CLASS='麻醉'") : ("");
                }
                else
                {
                    this.RBicu.Checked = true;
                    MR_CLASS = MR_CLASS.Length > 0 ? (" and MR_CLASS='重症'") : ("");
                }
            }
            else
            {
                this.RBanes.Checked = true;
                MR_CLASS = MR_CLASS.Length > 0 ? (" and MR_CLASS='麻醉'") : ("");
            }

            string ARCHIVE_KEY = this.GetRequest("ARCHIVE_KEY");
            this.TbARCHIVE_KEY.Text = ARCHIVE_KEY.Length > 0 ? (ARCHIVE_KEY) : ("");
            ARCHIVE_KEY = ARCHIVE_KEY.Length > 0 ? (" and ARCHIVE_KEY like '%" + ARCHIVE_KEY + "%'") : ("");

            this.Where = PATIENT_ID + VISIT_ID + MR_CLASS + ARCHIVE_KEY;
            this.Order = " his_patient_id desc";
            this.Columns = "*";

            if (DateType.ToUpper()=="ORACLE")
            {
                this.TableName = "(select distinct nvl(c.HIS_PATIENT_ID,a.patient_id) as HIS_PATIENT_ID, nvl(c.HIS_VISIT_ID,a.visit_id) as HIS_VISIT_ID, b.name, b.sex, (SELECT COUNT(1) FROM MED_EMR_ARCHIVE_DETIAL WHERE patient_id = A.patient_id and ARCHIVE_KEY = a.ARCHIVE_KEY) RECCOUNT, a.MR_CLASS, a.ARCHIVE_KEY, to_char(a.ARCHIVE_DATE_TIME,'yyyy-MM-dd') as ARCHIVE_DATE_TIME from MED_EMR_ARCHIVE_DETIAL a, MED_PAT_MASTER_INDEX b, MED_VS_HIS_PAT c where a.patient_id = b.patient_id and a.patient_id = c.med_patient_id(+) and a.visit_id = c.med_visit_id(+) and a.archive_status <>'作废' order by ARCHIVE_DATE_TIME desc)";
            }
            else if( DateType.ToUpper()=="SQLSERVER")
            {
                this.TableName = "(select distinct c.HIS_PATIENT_ID as HIS_PATIENT_ID,c.HIS_VISIT_ID as HIS_VISIT_ID, b.name, b.sex, (SELECT COUNT(1) FROM MED_EMR_ARCHIVE_DETIAL WHERE patient_id = A.patient_id and ARCHIVE_KEY = a.ARCHIVE_KEY) RECCOUNT, a.MR_CLASS, a.ARCHIVE_KEY,  a.ARCHIVE_DATE_TIME from MED_EMR_ARCHIVE_DETIAL a, MED_PAT_MASTER_INDEX b, MED_VS_HIS_PAT c where a.patient_id = b.patient_id and a.patient_id = c.med_patient_id and a.visit_id = c.med_visit_id and a.archive_status <>'作废' )";
            }
            else
            {
                this.TableName = "(select distinct nvl(c.HIS_PATIENT_ID,a.patient_id) as HIS_PATIENT_ID, nvl(c.HIS_VISIT_ID,a.visit_id) as HIS_VISIT_ID, b.name, b.sex, (SELECT COUNT(1) FROM MED_EMR_ARCHIVE_DETIAL WHERE patient_id = A.patient_id and ARCHIVE_KEY = a.ARCHIVE_KEY) RECCOUNT, a.MR_CLASS, a.ARCHIVE_KEY, to_char(a.ARCHIVE_DATE_TIME,'yyyy-MM-dd') as ARCHIVE_DATE_TIME from MED_EMR_ARCHIVE_DETIAL a, MED_PAT_MASTER_INDEX b, MED_VS_HIS_PAT c where a.patient_id = b.patient_id and a.patient_id = c.med_patient_id(+) and a.visit_id = c.med_visit_id(+) and a.archive_status <>'作废' order by ARCHIVE_DATE_TIME desc)";
            }
          //  this.TableName = "(select distinct nvl(c.HIS_PATIENT_ID,a.patient_id) as HIS_PATIENT_ID, nvl(c.HIS_VISIT_ID,a.visit_id) as HIS_VISIT_ID, b.name, b.sex, (SELECT COUNT(1) FROM MED_EMR_ARCHIVE_DETIAL WHERE patient_id = A.patient_id and ARCHIVE_KEY = a.ARCHIVE_KEY) RECCOUNT, a.MR_CLASS, a.ARCHIVE_KEY, to_char(a.ARCHIVE_DATE_TIME,'yyyy-MM-dd') as ARCHIVE_DATE_TIME from MED_EMR_ARCHIVE_DETIAL a, MED_PAT_MASTER_INDEX b, MED_VS_HIS_PAT c where a.patient_id = b.patient_id and a.patient_id = c.med_patient_id(+) and a.visit_id = c.med_visit_id(+) and a.archive_status <>'作废' order by ARCHIVE_DATE_TIME desc)";
            this.PageSize = 20;


          

            this.ListDataView.DataSource = this.PageData;
            this.ListDataView.DataBind();
            this.Pages1.NumCount = RecordCount;
            this.Pages1.PageSize = this.PageSize;
            this.Pages1.CurrentPage = this.CurrentPage;
        }

        protected void BtSearch_Click(object sender, EventArgs e)
        {
 
             Response.Redirect(Request.Path.ToString() + string.Format("?PATIENT_ID={0}&VISIT_ID={1}&MR_CLASS={2}&ARCHIVE_KEY={3}", this.TbPatient_ID.Text, this.TbVisit_ID.Text, this.RBanes.Checked ? ("麻醉") : (this.RBicu.Checked ? ("重症") : ("麻醉")), this.TbARCHIVE_KEY.Text));

        }
 

    }
}
            