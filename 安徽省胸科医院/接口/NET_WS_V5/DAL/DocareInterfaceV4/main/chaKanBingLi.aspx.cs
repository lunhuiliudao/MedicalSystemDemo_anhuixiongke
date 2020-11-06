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

namespace Emr_bs.main
{
    public partial class chaKanBingLi : InitDocare.BasePager
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
              
            }
        }
        public void BindData()
        {
    
            string patient_id = this.GetRequest("patient_id");
            string visit_id = this.GetRequest("visit_id");
            string Archive_Key = this.GetRequest("Archive_Key");
            if (patient_id.Length < 1 || visit_id.Length < 1)
            {
                Response.Write("没有要查询的人员！");
                return;
            }
            DataTable dtARCHIVE = this.Db.GetTable("select MR_CLASS,TOPIC,ARCHIVE_KEY,EMR_FILE_NAME,PATIENT_ID from MED_EMR_ARCHIVE_DETIAL where PATIENT_ID=:PATIENT_ID and VISIT_ID=:VISIT_ID and Archive_Key=:Archive_Key and ARCHIVE_TYPE<>'作废' and lower(emr_type)='pdf' order by MR_CLASS,TOPIC asc", this.Db.MakeParameters("PATIENT_ID", patient_id, "VISIT_ID", visit_id, "Archive_Key", Archive_Key));
            TreeView1.Nodes.Add(new TreeNode("病历文书", "", "image/folder1.gif"));
            DataTable dt = this.Db.GetTable("select distinct mr_Class from MED_EMR_CLASS_DICT where MR_CLASS=:MR_CLASS", this.Db.MakeParameters("MR_CLASS", Server.UrlDecode(GetRequest("MR_CLASS"))));
            int i=0;
            foreach (DataRow dr in dt.Rows)
            {
                this.TreeView1.Nodes[0].ChildNodes.Add(new TreeNode(Convert.ToString(dr["mr_Class"]), "", "image/folder1.gif"));
                foreach (DataRow drtemp in dtARCHIVE.Select("MR_CLASS='" + Convert.ToString(dr["mr_Class"]) + "'"))
                {
                    this.TreeView1.Nodes[0].ChildNodes[i].ChildNodes.Add(new TreeNode(Convert.ToString(drtemp["TOPIC"]), "", "image/tree_icon3.gif", string.Format("view.aspx?patient_id={0}&visit_id={1}&pdfpath={2}", Convert.ToString(drtemp["patient_id"]), visit_id, Convert.ToString(drtemp["EMR_FILE_NAME"])), "workAreaFame"));
                }
                i++;
            }
        }

        protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
            //e.Node.ImageUrl = "image/folder1.gif";
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            //e.Node.ImageUrl = "image/folder2.gif";
        }
    }
}
