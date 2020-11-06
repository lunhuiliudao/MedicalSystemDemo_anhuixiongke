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
    /// 测试HIS连接数据库1
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
                this.datalogsHis.Text = "显示HIS配置信息:HIS数据库连接成功!";
                this.datalogsHis.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsHis.Text = "检查HIS服务器的--配置和用户名密码配置网络等等!";
                this.datalogsHis.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        catch (Exception ex)
        {
            this.datalogsHis.Text = "HIS数据库连接失败:" + ex.Message;
        }
    }
    /// <summary>
    /// 测试HIS连接数据库url
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
                this.datalogsHisWebUrl.Text = "显示HIS配置WebServices信息:HIS提供WebServices连接成功!";
                this.datalogsHisWebUrl.ForeColor = System.Drawing.Color.Black;

            }
            else
            {
                this.datalogsHisWebUrl.Text = "访问HIS配置WebServices地址出错!请配置WebServices地址!";
                this.datalogsHisWebUrl.ForeColor = System.Drawing.Color.Red;

            }
        }
        catch (Exception ex)
        {
            this.datalogsHisWebUrl.Text = "HIS数据库连接失败:" + ex.Message;
        }
    }
    /// <summary>
    /// 测试LIS连接数据库
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
                this.datalogsLis.Text = "显示LIS配置信息:LIS数据库连接成功!";
                this.datalogsLis.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsLis.Text = "检查LIS服务器的--配置和用户名密码配置网络等等!";
                this.datalogsLis.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            this.datalogsLis.Text = "LIS数据库连接失败:" + ex.Message;
        }
    }
    /// <summary>
    /// 测试PACS连接数据库
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
                    this.datalogsPacs.Text = "请在MED_IF_TRANS_DICT表里面配置PACS相关记录!";
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
                    this.datalogsPacs.Text = "请在MED_IF_TRANS_DICT表里面配置PACS相关记录!";
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
                    this.datalogsPacs.Text = "请在MED_IF_TRANS_DICT表里面配置PACS相关记录!";
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
                this.datalogsPacs.Text = "显示PACS配置信息:PACS数据库连接成功!";
                this.datalogsPacs.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsPacs.Text = "检查PACS服务器的--配置和用户名密码配置网络等等!";
                this.datalogsPacs.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            this.datalogsPacs.Text = "PACS数据库连接失败:" + ex.Message;
        }
    }
    /// <summary>
    /// 测试PIS连接数据库
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
                    this.datalogsPis.Text = "请在MED_IF_TRANS_DICT表里面配置PIS相关记录!";
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
                    this.datalogsPis.Text = "请在MED_IF_TRANS_DICT表里面配置PIS相关记录!";
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
                    this.datalogsPis.Text = "请在MED_IF_TRANS_DICT表里面配置PIS相关记录!";
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
                this.datalogsPis.Text = "显示PIS配置信息:PIS数据库连接成功!";
                this.datalogsPis.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.datalogsPis.Text = "检查PIS服务器的--配置和用户名密码配置网络等等!";
                this.datalogsPis.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            this.datalogsPis.Text = "PIS数据库连接失败:" + ex.Message;
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
