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
using MedicalSytem.Soft.Model;
using MedicalSytem.Soft.DAL;
using System.Collections.Generic;

public partial class main_Patient_history : InitDocare.BasePager
{
    private string DataServerType
    {
        get
        {
            return PublicA.GetConfig("DataServerType");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string DateType = PublicA.GetConfig("DataServerType");
            MedicalSytem.Soft.Model.MedInitDict doCareDict;
            if (DateType.Contains("OLE"))
            {
                doCareDict = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictOLE("ANESMGR");
            }
            else if (DateType.Contains("SQLServer"))
            {
                doCareDict = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictSQL("ANESMGR");
            }
            else if (DateType.Contains("ODBC"))
            {
                doCareDict = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictOdbc("ANESMGR");
            }
            else
            {
                doCareDict = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDict("ANESMGR");
            }

            BindData();
        }
    }

    public void BindData()
    {

        string  patient_id = this.GetRequest("patient_id");
        string visit_id = this.GetRequest("visit_id");


        MedVsHisPat oneMedVsHisPat = null;

        if (DataServerType.Contains("OLE"))
        {
            oneMedVsHisPat =  new DALMedVsHisPat().SelectMedVsHisPatHisOLE(patient_id, visit_id, visit_id);
        }
        else if (DataServerType.Contains("SQLServer"))
        {
            oneMedVsHisPat = new DALMedVsHisPat().SelectMedVsHisPatHisSQL(patient_id, visit_id, visit_id);
        }
        else if (DataServerType.Contains("ODBC"))
        {
            oneMedVsHisPat = new DALMedVsHisPat().SelectMedVsHisPatHisODBC(patient_id, visit_id, visit_id);
        }
        else
        {
            oneMedVsHisPat = new DALMedVsHisPat().SelectMedVsHisPatHis(patient_id, visit_id, visit_id);
        }

        if (oneMedVsHisPat == null)
        {
            InitDocare.LogA.Debug("oneMedVsHisPat is null inpara pateint_id:" + patient_id + ";visit_id:" + visit_id);
            oneMedVsHisPat = new MedVsHisPat();
            oneMedVsHisPat.HisPatientId = patient_id;
            oneMedVsHisPat.HisVisitId = visit_id;
            oneMedVsHisPat.MedPatientId = patient_id;
            decimal dc=0;
            if (decimal.TryParse(visit_id, out dc))
            {
                oneMedVsHisPat.MedVisitId = dc;
            }
            else
            {
                oneMedVsHisPat.MedVisitId = 1;
            }
        }

        string mr_class = this.GetRequest("mr_class");
        string cmd = this.GetRequest("his_no");

        DataTable dtARCHIVE = null;

        if (patient_id.Length < 1 || visit_id.Length < 1)
        {
            Response.Write("没有要查询的人员！查询[麻醉]使用代码:1001[1011] 查询[重症]使用代码:1002[1012]");
            return;
        }
        ///1001,1002 第三方查看
        if (mr_class == "1001")
        {
            mr_class = "麻醉";
            if (string.IsNullOrEmpty(cmd))//准备不使用IN
            {
                string sql = "";
                if (DataServerType.Contains("SQLServer"))
                {
                    sql = @"select a.MR_CLASS,
                                           a.MR_SUB_CLASS,
                                           a.TOPIC,
                                           a.ARCHIVE_KEY,
                                           a.EMR_FILE_NAME,
                                           a.PATIENT_ID,
                                           a.EMR_TYPE       
                                           from MED_EMR_ARCHIVE_DETIAL A, MED_VS_HIS_PAT B , (SELECT max(archive_times) archive_times ,c.mr_class,c.mr_sub_class,c.topic
                                           FROM MED_EMR_ARCHIVE_DETIAL c
                                           where MR_CLASS = @MR_CLASS
                                           and PATIENT_ID =@PATIENT_ID
                                           and VISIT_ID = @VISIT_ID
                                           and ARCHIVE_STATUS <> '作废'
                                           GROUP BY MR_CLASS, MR_SUB_CLASS, TOPIC) d
                                           where a.MR_CLASS = @MR_CLASS
                                           AND A.PATIENT_ID = B.MED_PATIENT_ID
                                           AND A.VISIT_ID = B.MED_VISIT_ID
                                           AND B.HIS_PATIENT_ID =@HIS_PATIENT_ID
                                           AND B.HIS_VISIT_ID = @HIS_VISIT_ID
                                           AND archive_status <> '作废'
                                           AND a.ARCHIVE_TIMES =d.archive_times
                                           and a.mr_class=d.mr_class 
                                           and a.mr_sub_class=d.mr_sub_class
                                           order by MR_CLASS, TOPIC asc";

                    dtARCHIVE = Db.GetTable(sql, this.Db.MakeParameters("MR_CLASS", mr_class, "PATIENT_ID", oneMedVsHisPat.MedPatientId, "VISIT_ID", oneMedVsHisPat.MedVisitId.ToString(), "HIS_PATIENT_ID", oneMedVsHisPat.HisPatientId, "HIS_VISIT_ID", oneMedVsHisPat.HisVisitId));
                }
                
                else if(DataServerType.ToUpper().Contains("OLE"))
                {

                    sql = @"select a.MR_CLASS,
                                           a.MR_SUB_CLASS,
                                           a.TOPIC,
                                           a.ARCHIVE_KEY,
                                           a.EMR_FILE_NAME,
                                           a.PATIENT_ID,
                                           a.EMR_TYPE       
                                           from MED_EMR_ARCHIVE_DETIAL A, MED_VS_HIS_PAT B , (SELECT max(archive_times) archive_times ,c.mr_class,c.mr_sub_class,c.topic
                                           FROM MED_EMR_ARCHIVE_DETIAL c
                                           where MR_CLASS =?
                                           and PATIENT_ID =?
                                           and VISIT_ID = ?
                                           and ARCHIVE_STATUS <> '作废'
                                           GROUP BY MR_CLASS, MR_SUB_CLASS, TOPIC) d
                                           where a.MR_CLASS =?
                                           AND A.PATIENT_ID = B.MED_PATIENT_ID
                                           AND A.VISIT_ID = B.MED_VISIT_ID
                                           AND B.HIS_PATIENT_ID =?
                                           AND B.HIS_VISIT_ID = ?
                                           AND archive_status <> '作废'
                                           AND a.ARCHIVE_TIMES =d.archive_times
                                           and a.mr_class=d.mr_class 
                                           and a.mr_sub_class=d.mr_sub_class
                                           order by MR_CLASS, TOPIC asc";

                    dtARCHIVE = Db.GetTable(sql, Db.MakeParameters("MR_CLASS", mr_class, "PATIENT_ID", oneMedVsHisPat.MedPatientId, "VISIT_ID", oneMedVsHisPat.MedVisitId.ToString(), "MR_CLASS1", mr_class, "HIS_PATIENT_ID", oneMedVsHisPat.HisPatientId, "HIS_VISIT_ID", oneMedVsHisPat.HisVisitId));
                   
                }
                else if (DataServerType.ToUpper().Contains("ORACLE"))
                {
                    sql = @"select a.MR_CLASS,
                                           a.MR_SUB_CLASS,
                                           a.TOPIC,
                                           a.ARCHIVE_KEY,
                                           a.EMR_FILE_NAME,
                                           a.PATIENT_ID,
                                           a.EMR_TYPE       
                                           from MED_EMR_ARCHIVE_DETIAL A, MED_VS_HIS_PAT B , (SELECT max(archive_times) archive_times ,c.mr_class,c.mr_sub_class,c.topic
                                           FROM MED_EMR_ARCHIVE_DETIAL c
                                           where MR_CLASS = :MR_CLASS
                                           and PATIENT_ID =:PATIENT_ID
                                           and VISIT_ID = :VISIT_ID
                                           and ARCHIVE_STATUS <> '作废'
                                           GROUP BY MR_CLASS, MR_SUB_CLASS, TOPIC) d
                                           where a.MR_CLASS = :MR_CLASS
                                           AND A.PATIENT_ID = B.MED_PATIENT_ID
                                           AND A.VISIT_ID = B.MED_VISIT_ID
                                           AND HIS_PATIENT_ID =:HIS_PATIENT_ID
                                           AND HIS_VISIT_ID = :HIS_VISIT_ID
                                           AND archive_status <> '作废'
                                           AND a.ARCHIVE_TIMES =d.archive_times
                                           and a.mr_class=d.mr_class 
                                           and a.mr_sub_class=d.mr_sub_class
                                           order by MR_CLASS, TOPIC asc";

                    dtARCHIVE = Db.GetTable(sql, Db.MakeParameters("MR_CLASS", mr_class, "HIS_PATIENT_ID", oneMedVsHisPat.HisPatientId, "HIS_VISIT_ID", oneMedVsHisPat.HisVisitId, "PATIENT_ID", oneMedVsHisPat.MedPatientId, "VISIT_ID", oneMedVsHisPat.MedVisitId.ToString()));
                }
            }
        }
        else if (mr_class == "1002")
        {
            mr_class = "重症";
            if (DataServerType.Contains("SQLServer"))
            {
                dtARCHIVE = Db.GetTable("select MR_CLASS,MR_SUB_CLASS,TOPIC,ARCHIVE_KEY,EMR_FILE_NAME,PATIENT_ID,EMR_TYPE from MED_EMR_ARCHIVE_DETIAL A ,MED_VS_HIS_PAT B where MR_CLASS=@MR_CLASS AND A.PATIENT_ID = B.MED_PATIENT_ID AND A.VISIT_ID = B.MED_VISIT_ID AND HIS_PATIENT_ID=@PATIENT_ID AND HIS_VISIT_ID=@VISIT_ID AND AND ARCHIVE_TYPE<>'作废' order by MR_CLASS,TOPIC asc", this.Db.MakeParameters("MR_CLASS", mr_class, "PATIENT_ID", oneMedVsHisPat.HisPatientId, "VISIT_ID", oneMedVsHisPat.HisVisitId));
            }
            else
            {
                dtARCHIVE = Db.GetTable("select MR_CLASS,MR_SUB_CLASS,TOPIC,ARCHIVE_KEY,EMR_FILE_NAME,PATIENT_ID,EMR_TYPE from MED_EMR_ARCHIVE_DETIAL A ,MED_VS_HIS_PAT B where MR_CLASS=:MR_CLASS AND A.PATIENT_ID = B.MED_PATIENT_ID AND A.VISIT_ID = B.MED_VISIT_ID AND HIS_PATIENT_ID=:PATIENT_ID and HIS_VISIT_ID=:VISIT_ID and archive_status<>'作废' order by MR_CLASS,TOPIC asc", this.Db.MakeParameters("MR_CLASS", mr_class, "PATIENT_ID", oneMedVsHisPat.HisPatientId, "VISIT_ID", oneMedVsHisPat.HisVisitId));
            }
        }

        // 1011,1012  Docare 查看
        else if (mr_class == "1011")
        {
            mr_class = "麻醉";
            if (string.IsNullOrEmpty(cmd))
            {
                string sql = "select MR_CLASS,MR_SUB_CLASS,TOPIC,ARCHIVE_KEY,EMR_FILE_NAME,PATIENT_ID,EMR_TYPE from MED_EMR_ARCHIVE_DETIAL where MR_CLASS=:MR_CLASS and PATIENT_ID=:PATIENT_ID and VISIT_ID=:VISIT_ID and archive_status<>'作废'  order by MR_CLASS,TOPIC asc";
                dtARCHIVE = Db.GetTable(sql, this.Db.MakeParameters("MR_CLASS", mr_class, "PATIENT_ID", oneMedVsHisPat.MedPatientId, "VISIT_ID", oneMedVsHisPat.MedVisitId.ToString()));
            }
            else
            {

                dtARCHIVE = Db.GetTable("select MR_CLASS,MR_SUB_CLASS,TOPIC,ARCHIVE_KEY,EMR_FILE_NAME,PATIENT_ID,EMR_TYPE from MED_EMR_ARCHIVE_DETIAL A ,MED_VS_HIS_OPER_APPLY_V2 B where MR_CLASS=:MR_CLASS AND A.PATIENT_ID = B.MED_PATIENT_ID AND A.VISIT_ID = B.MED_VISIT_ID  AND A.ARCHIVE_KEY = B.MED_SCHEDULE_ID AND HIS_PATIENT_ID=:PATIENT_ID AND HIS_VISIT_ID=:VISIT_ID AND HIS_APPLY_NO=:HIS_APPLY_NO AND archive_status<>'作废' AND ARCHIVE_TIMES = (SELECT  max(archive_times) FROM MED_EMR_ARCHIVE_DETIAL where MR_CLASS = :MR_CLASS_1 and PATIENT_ID = :PATIENTID  and VISIT_ID = :VISITID   and ARCHIVE_TYPE <> '作废'   GROUP BY MR_CLASS,MR_SUB_CLASS,TOPIC) order by MR_CLASS,TOPIC asc", this.Db.MakeParameters("MR_CLASS", mr_class, "PATIENT_ID", patient_id, "VISIT_ID", visit_id, "HIS_APPLY_NO", cmd, "MR_CLASS_1", mr_class, "PATIENTID", patient_id, "VISITID", visit_id));
            }
        }
        else if (mr_class == "1012")
        {
            mr_class = "重症";

            dtARCHIVE = Db.GetTable("select MR_CLASS,MR_SUB_CLASS,TOPIC,ARCHIVE_KEY,EMR_FILE_NAME,PATIENT_ID,EMR_TYPE  from MED_EMR_ARCHIVE_DETIAL where MR_CLASS=:MR_CLASS and PATIENT_ID=:PATIENT_ID and VISIT_ID=:VISIT_ID and ARCHIVE_TYPE<>'作废' AND ARCHIVE_TIMES = (SELECT  max(archive_times) FROM MED_EMR_ARCHIVE_DETIAL where MR_CLASS = :MR_CLASS_1 and PATIENT_ID = :PATIENTID  and VISIT_ID = :VISITID   and archive_status <> '作废'   GROUP BY MR_CLASS,MR_SUB_CLASS,TOPIC) order by MR_CLASS,TOPIC asc", this.Db.MakeParameters("MR_CLASS", mr_class, "PATIENT_ID", patient_id, "VISIT_ID", visit_id, "MR_CLASS_1", mr_class, "PATIENTID", patient_id, "VISITID", visit_id));
        }
        TreeView1.Nodes.Add(new TreeNode("病历文书", "", "image/folder1.gif"));
        this.TreeView1.Nodes[0].ChildNodes.Add(new TreeNode(mr_class, "", "image/folder1.gif"));

        try
        {
            foreach (DataRow drtemp in dtARCHIVE.Rows)
            {
                if (drtemp["EMR_TYPE"].ToString().ToUpper() == "PDF")
                {
                    this.TreeView1.Nodes[0].ChildNodes[0].ChildNodes.Add(new TreeNode(Convert.ToString(drtemp["TOPIC"]), "", "image/tree_icon3.gif", string.Format("view.aspx?patient_id={0}&visit_id={1}&pdfpath={2}", Convert.ToString(drtemp["patient_id"]), oneMedVsHisPat.HisPatientId, Convert.ToString(drtemp["EMR_FILE_NAME"])), "workAreaFame"));
                }
                else if (drtemp["EMR_TYPE"].ToString().ToUpper() == "JPG")
                {
                    this.TreeView1.Nodes[0].ChildNodes[0].ChildNodes.Add(new TreeNode(Convert.ToString(drtemp["TOPIC"]), "", "image/tree_icon3.gif", string.Format("ImageView.aspx?patient_id={0}&visit_id={1}&imgpath={2}", Convert.ToString(drtemp["patient_id"]), oneMedVsHisPat.HisPatientId, Convert.ToString(drtemp["EMR_FILE_NAME"])), "workAreaFame"));
                }
            }
        }
        catch
        {

        }
    }

    protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        //e.Node.ImageUrl = "image/folder1.gif";
    }

    protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        // e.Node.ImageUrl = "image/folder2.gif";
    }
}
