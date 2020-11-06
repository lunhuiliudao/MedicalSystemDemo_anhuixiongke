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
using System.Net;
using InitDocare;

public partial class Admin_DataBaseConfig : System.Web.UI.Page
{

    public MedicalSytem.Soft.DAL.DALMedIfTransDict medIfTransDictDALBASE = new MedicalSytem.Soft.DAL.DALMedIfTransDict();

    public MedicalSytem.Soft.DAL.DALMedIfRunConfigDict medIfRunConfigDictDALBASE = new MedicalSytem.Soft.DAL.DALMedIfRunConfigDict();

    private MedicalSytem.Soft.Model.MedIfTransDict ifTransDict;

    private bool conn;

    private MedicalSytem.Soft.InitDocare.Config oneConfig;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null)
        {
            hisConn_Click(null, null);
            hisConnurl_Click(null, null);
            lisConn_Click(null, null);
            pacsConn_Click(null, null);
            pisConn_Click(null, null);
        }
        else
        {
            Response.Redirect("../LoginIn.aspx");
        }
    }


    /// <summary>
    /// ����HIS�������ݿ�1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void hisConn_Click(object sender, EventArgs e)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {

            if (DateType.Contains("OLE"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictOLE("HIS");
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
                conn = BLL.ConnectionTestInfo.ConnectionOLETest(oneConfig.HisConnection);
            }
            else if (DateType.Contains("SQLServer"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictSQL("HIS");
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
               // if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.HisConnection);
                //else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.HisConnection);
            }
            else
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDict("HIS");
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
               // if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.HisConnection);
               // else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.HisConnection);

            }

            if (conn)
            {
                this.datalogsHis.Text = "��ʾHIS������Ϣ:HIS���ݿ����ӳɹ�!";
                this.datalogsHis.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsHis.Text = "���HIS��������--���ú��û���������������ȵ�!";
                this.datalogsHis.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        catch (Exception ex)
        {
            this.datalogsHis.Text = "HIS���ݿ�����ʧ��:" + ex.Message;
        }
    }
    /// <summary>
    /// ����HIS�������ݿ�url
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void hisConnurl_Click(object sender, EventArgs e)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {
           //WebService Url
            if (UrlExistsUsingHttpWebRequest(PublicA.GetConfig("WebServerUrl").ToString().Replace("?WSDL", "").Replace("?wsdl", "").Trim()))
            {
                this.datalogsHisWebUrl.Text = "��ʾHIS����WebServices��Ϣ:HIS�ṩWebServices���ӳɹ�!";
                this.datalogsHisWebUrl.ForeColor = System.Drawing.Color.Black;

            }
            else
            {
                this.datalogsHisWebUrl.Text = "����HIS����WebServices��ַ����!������WebServices��ַ!";
                this.datalogsHisWebUrl.ForeColor = System.Drawing.Color.Red;

            }
        }
        catch (Exception ex)
        {
            this.datalogsHisWebUrl.Text = "HIS���ݿ�����ʧ��:" + ex.Message;
        }
    }
    /// <summary>
    /// ����LIS�������ݿ�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lisConn_Click(object sender, EventArgs e)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {

            if (DateType.Contains("OLE"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictOLE("LIS");
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
                conn = BLL.ConnectionTestInfo.ConnectionOLETest(oneConfig.LisConnection);
            }
            else if (DateType.Contains("SQLServer"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictSQL("LIS");
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
               // if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.LisConnection);
              //  else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.LisConnection);
            }
            else
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDict("LIS");
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
              //  if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.LisConnection);
               // else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.LisConnection);
            }
            if (conn)
            {
                this.datalogsLis.Text = "��ʾLIS������Ϣ:LIS���ݿ����ӳɹ�!";
                this.datalogsLis.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsLis.Text = "���LIS��������--���ú��û���������������ȵ�!";
                this.datalogsLis.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            this.datalogsLis.Text = "LIS���ݿ�����ʧ��:" + ex.Message;
        }
    }
    /// <summary>
    /// ����PACS�������ݿ�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void pacsConn_Click(object sender, EventArgs e)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {

            if (DateType.Contains("OLE"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictOLE("PACS");
                if (ifTransDict == null)
                {
                    this.datalogsPacs.Text = "����MED_IF_TRANS_DICT����������PACS��ؼ�¼!";
                    this.datalogsPacs.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
                conn = BLL.ConnectionTestInfo.ConnectionOLETest(oneConfig.PacsConnection);
            }
            else if (DateType.Contains("SQLServer"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictSQL("PACS");
                if (ifTransDict == null)
                {
                    this.datalogsPacs.Text = "����MED_IF_TRANS_DICT����������PACS��ؼ�¼!";
                    this.datalogsPacs.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
               // if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.PacsConnection);
               // else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.PacsConnection);
            }
            else
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDict("PACS");
                if (ifTransDict == null)
                {
                    this.datalogsPacs.Text = "����MED_IF_TRANS_DICT����������PACS��ؼ�¼!";
                    this.datalogsPacs.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
              //  if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.PacsConnection);
               // else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.PacsConnection);
            }
            if (conn)
            {
                this.datalogsPacs.Text = "��ʾPACS������Ϣ:PACS���ݿ����ӳɹ�!";
                this.datalogsPacs.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsPacs.Text = "���PACS��������--���ú��û���������������ȵ�!";
                this.datalogsPacs.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            this.datalogsPacs.Text = "PACS���ݿ�����ʧ��:" + ex.Message;
        }
    }
    /// <summary>
    /// ����PIS�������ݿ�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void pisConn_Click(object sender, EventArgs e)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {

            if (DateType.Contains("OLE"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictOLE("PIS");
                if (ifTransDict == null)
                {
                    this.datalogsPis.Text = "����MED_IF_TRANS_DICT����������PIS��ؼ�¼!";
                    this.datalogsPis.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
                conn = BLL.ConnectionTestInfo.ConnectionOLETest(oneConfig.PisConnection);
            }
            else if (DateType.Contains("SQLServer"))
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDictSQL("PIS");
                if (ifTransDict == null)
                {
                    this.datalogsPis.Text = "����MED_IF_TRANS_DICT����������PIS��ؼ�¼!";
                    this.datalogsPis.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
           //     if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.PisConnection);
             //   else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.PisConnection);
            }
            else
            {
                ifTransDict = medIfTransDictDALBASE.SelectMedIfTransDict("PIS");
                if (ifTransDict == null)
                {
                    this.datalogsPis.Text = "����MED_IF_TRANS_DICT����������PIS��ؼ�¼!";
                    this.datalogsPis.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                oneConfig = new MedicalSytem.Soft.InitDocare.Config();
             //   if (ifTransDict.Database == null || (ifTransDict.Dbms.ToUpper() == "O73" || ifTransDict.Dbms.ToUpper() == "O81" || ifTransDict.Dbms.ToUpper() == "ORACLE"))
                    conn = BLL.ConnectionTestInfo.ConnectionOracleTest(oneConfig.PisConnection);
              //  else
                    conn = BLL.ConnectionTestInfo.ConnectionSQLTest(oneConfig.PisConnection);
            }
            if (conn)
            {
                this.datalogsPis.Text = "��ʾPIS������Ϣ:PIS���ݿ����ӳɹ�!";
                this.datalogsPis.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsPis.Text = "���PIS��������--���ú��û���������������ȵ�!";
                this.datalogsPis.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            this.datalogsPis.Text = "PIS���ݿ�����ʧ��:" + ex.Message;
        }
    }

    private bool UrlExistsUsingHttpWebRequest(string url)
    {
        try
        {
            //System.Net.HttpWebRequest myRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            //myRequest.Method = "POST";
            //myRequest.ContentType = "application/x-www-form-urlencoded";
            //myRequest.Timeout = 100;
            //SetWebRequest(request);
            //System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)myRequest.GetResponse();
            //return (res.StatusCode == System.Net.HttpStatusCode.OK);
            if(url == null)
                return false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?WSDL");
            WebResponse response = request.GetResponse();
            return ((response as HttpWebResponse).StatusCode == System.Net.HttpStatusCode.OK);

        }
        catch (System.Net.WebException we)
        {
            System.Diagnostics.Trace.Write(we.Message);
            return false;
        }
    }










































}
