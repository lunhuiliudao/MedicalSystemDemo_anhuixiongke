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

namespace DoCareEmr
{
    public partial class _default : InitDocare.BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  this.BtSearch.Attributes.Add("onclick", "return dolocation();");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            string PATIENT_ID = this.GetRequest("PATIENT_ID");
            this.TbPatient_ID.Text = PATIENT_ID.Length > 0 ? (PATIENT_ID) : ("");
            PATIENT_ID = PATIENT_ID.Length>0?(" and PATIENT_ID='"+PATIENT_ID+"'"):("");
           
            string NAME = this.GetRequest("NAME");
            this.TbName.Text = NAME.Length > 0 ? (NAME) : ("");
            NAME = NAME.Length > 0 ? (" and NAME like '%" + NAME + "%'") : ("");
            string SEX = this.GetRequest("SEX");
            //Response.Write(PATIENT_ID + SEX);
            //TbSex.Text = SEX.Length > 0 ? (SEX) : ("");
            if (SEX.Length > 0)
            {
                if (SEX == "男")
                {
                    this.RbMan.Checked = true;
                }
                else
                {
                    this.RbWomen.Checked = true;
                }
            }
            else
            {
                this.RbAll.Checked = true;
            }
            SEX = SEX.Length > 0 ? (" and SEX like '%" + Server.UrlDecode(SEX) + "%'") : ("");
            this.Where = PATIENT_ID + NAME + SEX;
            this.Order = " patient_id desc";
            this.Columns = "*";
            this.TableName = "(select distinct a.patient_id,a.visit_id, b.name,b.sex,(SELECT COUNT(1) FROM MED_EMR_ARCHIVE_DETIAL  WHERE patient_id = A.patient_id and ARCHIVE_KEY=a.ARCHIVE_KEY) RECCOUNT, a.MR_CLASS,a.ARCHIVE_KEY  from MED_EMR_ARCHIVE_DETIAL a, MED_PAT_MASTER_INDEX b  where a.patient_id = b.patient_id and lower(emr_type)='pdf')";
//            this.TableName = "(select a.patient_id,a.visit_id,b.name,b.sex,a.ARCHIVE_DATE_TIME,a.emr_file_name,a.MR_CLASS,a.Archive_Key from MED_EMR_ARCHIVE_DETIAL a,MED_PAT_MASTER_INDEX b where a.patient_id=b.patient_id and a.MR_CLASS='" + Global.Menu_Type + "')";
            this.PageSize = 20;
            this.ListDataView.DataSource = this.PageData;
            this.ListDataView.DataBind();
            this.Pages1.NumCount = RecordCount;//Common.StringOperator.GetInt(this.Db.GetOne(string.Format("select count(1) from {0}{1}", TableName, Where)));
            this.Pages1.PageSize = this.PageSize;
            this.Pages1.CurrentPage = this.CurrentPage;
        }

        protected void BtSearch_Click(object sender, EventArgs e)
        {
            //Response.Write(RBLSex.SelectedValue);
            Response.Redirect(Request.Path.ToString() + string.Format("?PATIENT_ID={0}&NAME={1}&SEX={2}", this.TbPatient_ID.Text, Server.UrlEncode(this.TbName.Text), this.RbMan.Checked?("男"):(this.RbWomen.Checked?("女"):(""))));
        }
    }
}
            