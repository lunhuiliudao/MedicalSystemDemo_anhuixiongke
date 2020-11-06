using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using InitDocare;

public partial class _Default : System.Web.UI.Page
{
    private DataTable ConfigData = null;

    /// <summary>
    /// 字典1
    /// </summary>
    private MedicalSytem.Soft.Model.MedInitDict doCareDict1;
    /// <summary>
    /// 字典2
    /// </summary>
    private MedicalSytem.Soft.Model.MedInitDict doCareDict2;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    DropDownList dataType2TB = ((DropDownList)DetailsView1.FindControl("DataServerType2"));
        //    if (dataType2TB != null)
        //        dataType2TB.DataBind();
        //}
        if (Session["Name"] != null)
        {
            this.loginName.Text = Session["Name"].ToString();

            refash();

        }
        else
        {
            Response.Redirect("../LoginIn.aspx");
        }
    }
    /// <summary>
    /// 注销
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void zhuxiao_Click(object sender, EventArgs e)
    {
        Session["Name"] = null;
        Response.Redirect("../LoginIn.aspx");
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void password_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Password.aspx?User=" + Session["Name"].ToString());
    }
    /// <summary>
    /// 测试HIS的信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void forInfo_Click(object sender, EventArgs e)
    {

    }

    private void refash()
    {
        ConfigData = new DataTable();
        ConfigData.Columns.Add("HISDataServerType", typeof(System.String));
        ConfigData.Columns.Add("DataServerType", typeof(System.String));
        ConfigData.Columns.Add("ServerName", typeof(System.String));
        ConfigData.Columns.Add("Catalog", typeof(System.String));
        ConfigData.Columns.Add("ServerLogin", typeof(System.String));
        ConfigData.Columns.Add("ServerPwd", typeof(System.String));
        ConfigData.Columns.Add("Title", typeof(System.String));
        ConfigData.Columns.Add("WebServerUrl", typeof(System.String));

        ConfigData.Columns.Add("WebServerUrlGet", typeof(System.String));
        ConfigData.Columns.Add("WebServerUrlSet", typeof(System.String));

        string dataTypeHIS = PublicA.GetConfig("HISDataServerType");
        string dataType = PublicA.GetConfig("DataServerType");
        DataRow row = ConfigData.NewRow();
        if (dataType.Contains("ODBC"))
        {
            string conn = PublicA.GetConfig("OdbcConnString");
            string[] temp1 = conn.Split(new char[2] { '=', ';' });
            row["ServerName"] = temp1[1];
            row["ServerLogin"] = temp1[5];
            row["ServerPwd"] = temp1[3];
        }
        else if (dataType.Contains("SQLServer"))
        {
            string conn = PublicA.GetConfig("SQLClientConnString");
            string[] temp1 = conn.Split(new char[2] { '=', ';' });
            row["ServerName"] = temp1[1];
            row["Catalog"] = temp1[3];
            row["ServerLogin"] = temp1[7];
            row["ServerPwd"] = temp1[5];
        }
        else
        {
            string conn = PublicA.GetConfig("OraClientConnString");
            string[] temp1 = conn.Split(new char[2] { '=', ';' });
            row["ServerName"] = temp1[3];
            row["ServerLogin"] = temp1[7];
            row["ServerPwd"] = temp1[5];
        }
        row["Title"] = PublicA.GetConfig("Title");// GetConfig("Title");
        row["WebServerUrl"] = PublicA.GetConfig("WebServerUrl");

        row["WebServerUrlGet"] = PublicA.GetConfig("WebServerUrlGet");
        row["WebServerUrlSet"] = PublicA.GetConfig("WebServerUrlSet");

        row["HISDataServerType"] = dataTypeHIS;
        row["DataServerType"] = dataType;

        ConfigData.Rows.Add(row);

        this.DetailsView1.DataSource = ConfigData;
        this.DetailsView1.AutoGenerateRows = false;
        this.DetailsView1.DataBind();


    }

    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        //判断模式 

        if (e.NewMode == DetailsViewMode.Edit)
        {

            DetailsView1.ChangeMode(DetailsViewMode.Edit);

        }

        if (e.NewMode == DetailsViewMode.Insert)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
        }

        if (e.NewMode == DetailsViewMode.ReadOnly)
        {
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);

        }

        //绑定数据源 
        this.DetailsView1.DataBind();

    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        if (ConfigData.Rows.Count < 1)
        {
            //切换模式
            this.DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            //绑定数据源 
            refash();
            return;
        }
        //DetailsView1.DataBind();
        //---------------------------

        //TextBox dataType2TB = ((TextBox)DetailsView1.FindControl("DataServerType2"));
        DropDownList dataType2TB = ((DropDownList)DetailsView1.FindControl("DataServerType2"));

        DropDownList dataType3TB = ((DropDownList)DetailsView1.FindControl("DataServerType3"));

        TextBox serverName2TB = ((TextBox)DetailsView1.FindControl("serverName2"));

        TextBox catalog2TB = ((TextBox)DetailsView1.FindControl("Catalog2"));

        TextBox ServerLogin2TB = ((TextBox)DetailsView1.FindControl("ServerLogin2"));

        TextBox ServerPwd2TB = ((TextBox)DetailsView1.FindControl("ServerPwd2"));

        TextBox Title2TB = ((TextBox)DetailsView1.FindControl("Title2"));

        TextBox wsurl2TB = ((TextBox)DetailsView1.FindControl("wsurl2"));

        TextBox wsurlGetPT = ((TextBox)DetailsView1.FindControl("wsurlGet"));
        TextBox wsurlSetPT = ((TextBox)DetailsView1.FindControl("wsurlSet"));

        if (ConfigData.Rows[0]["HISDataServerType"].ToString().ToUpper() != dataType2TB.Text.ToUpper() ||
            ConfigData.Rows[0]["DataServerType"].ToString().ToUpper() != dataType3TB.Text.ToUpper() ||
            ConfigData.Rows[0]["ServerName"].ToString().ToUpper() != serverName2TB.Text.ToUpper() ||
            ConfigData.Rows[0]["ServerLogin"].ToString().ToUpper() != ServerLogin2TB.Text.ToUpper() ||
            ConfigData.Rows[0]["ServerPwd"].ToString().ToUpper() != ServerPwd2TB.Text.ToUpper() ||
            ConfigData.Rows[0]["Title"].ToString().ToUpper() != Title2TB.Text.ToUpper() ||
            ConfigData.Rows[0]["WebServerUrl"].ToString().ToUpper() != wsurl2TB.Text.ToUpper() ||
            ConfigData.Rows[0]["WebServerUrlGet"].ToString().ToUpper() != wsurlGetPT.Text.ToUpper() ||
            ConfigData.Rows[0]["WebServerUrlSet"].ToString().ToUpper() != wsurlSetPT.Text.ToUpper())
        {
            //保存
            string connString = "";
            string connOLEString = "";
            string connODBCString = "";
            if (dataType3TB.Text.ToUpper().Contains("ODBC"))
            {
                //ODBC数据库
                connODBCString = "Dsn=" + serverName2TB.Text + ";pwd=" + ServerPwd2TB.Text + ";uid=" + ServerLogin2TB.Text + ";";
                PublicA.WriteConfig("OdbcConnString", connODBCString);
                //<--
            }
            else if (dataType3TB.Text.ToUpper().Contains("SQLSERVER"))
            {
                //SQLServer数据库
                connString = "Data Source=" + serverName2TB.Text + ";Initial Catalog =" + catalog2TB.Text + ";Password=" + ServerPwd2TB.Text + ";User ID=" + ServerLogin2TB.Text + ";";
                connOLEString = "Provider=SQLOLEDB;Data Source=" + serverName2TB.Text + ";Initial Catalog =" + catalog2TB.Text + ";Password=" + ServerPwd2TB.Text + ";User ID=" + ServerLogin2TB.Text + ";";
                PublicA.WriteConfig("SQLClientConnString", connString);
                PublicA.WriteConfig("OLEConnString", connOLEString);
                //<--
            }
            else if (dataType3TB.Text.ToUpper().Contains("SQLSVR2008"))
            {
                //SQLServer数据库
                //connString = "Data Source=" + serverName2TB.Text + ";Initial Catalog =" + catalog2TB.Text + ";Password=" + ServerPwd2TB.Text + ";User ID=" + ServerLogin2TB.Text + ";";
                connString = "Database=" + catalog2TB.Text + ";Server=" + serverName2TB.Text + ";user id=" + ServerLogin2TB.Text + ";password=" + ServerPwd2TB.Text + ";";
                PublicA.WriteConfig("SQLClientConnString", connString);
                //<--
            }  
            else
            {
                //Oracle数据库
                connString = "Persist Security Info=True;Data Source=" + serverName2TB.Text + ";Password=" + ServerPwd2TB.Text + ";User ID=" + ServerLogin2TB.Text + ";Unicode=True;";
                if (dataType3TB.Text.ToUpper().Contains("ORAOLEDB"))
                    connOLEString = "Provider=OraOLEDB.Oracle;Data Source=" + serverName2TB.Text + ";Password=" + ServerPwd2TB.Text + ";User ID=" + ServerLogin2TB.Text + ";";
                else
                    connOLEString = "Provider=MSDAORA;Data Source=" + serverName2TB.Text + ";Password=" + ServerPwd2TB.Text + ";User ID=" + ServerLogin2TB.Text + ";";
                PublicA.WriteConfig("OraClientConnString", connString);
                PublicA.WriteConfig("OLEConnString", connOLEString);
                //<--
            }
            PublicA.WriteConfig("WebServerUrl", wsurl2TB.Text);
            PublicA.WriteConfig("WebServerUrlGet", wsurlGetPT.Text);
            PublicA.WriteConfig("WebServerUrlSet", wsurlSetPT.Text);

            PublicA.WriteConfig("Title", Title2TB.Text);

            PublicA.WriteConfig("HISDataServerType", dataType2TB.Text);
            PublicA.WriteConfig("DataServerType", dataType3TB.Text);

        }

        //切换模式
        this.DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        //绑定数据源 
        refash();

        Response.Redirect("../LoginIn.aspx");

    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        //e.Cancel = true; 
    }

    protected void DetailsView1_ItemCreated(object sender, EventArgs e)
    {

        DropDownList dropDownList = (DropDownList)DetailsView1.FindControl("DataServerType2");
        if (dropDownList != null)
        {
            dropDownList.Items.Add(new ListItem("Oracle"));
            dropDownList.Items.Add(new ListItem("OracleOLE"));
            dropDownList.Items.Add(new ListItem("SQLServer"));
            dropDownList.Items.Add(new ListItem("SQLSVR2008"));
            dropDownList.Items.Add(new ListItem("OraOLEDB"));
            dropDownList.Items.Add(new ListItem("ODBC"));
            //dropDownList.DataBind();
        }

        DropDownList dropDownList2 = (DropDownList)DetailsView1.FindControl("DataServerType3");
        if (dropDownList2 != null)
        {
            dropDownList2.Items.Add(new ListItem("Oracle"));
            dropDownList2.Items.Add(new ListItem("OracleOLE"));
            dropDownList2.Items.Add(new ListItem("SQLServer"));
            dropDownList2.Items.Add(new ListItem("SQLSVR2008"));
            dropDownList2.Items.Add(new ListItem("OraOLEDB"));
            dropDownList2.Items.Add(new ListItem("ODBC"));
            //dropDownList.DataBind();
        }
        TextBox textbox1 = (TextBox)DetailsView1.FindControl("ServerPwd2");
        if (textbox1 != null && ConfigData.Rows.Count > 0)
        {
            //textbox1.Text = ConfigData.Rows[0]["ServerPwd"].ToString();
            textbox1.Attributes["value"] = ConfigData.Rows[0]["ServerPwd"].ToString();
        }

    }
    /// <summary>
    /// 关于版本
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void guanyu_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/GuanYuVerion.aspx");
    }
    /// <summary>
    /// 测试连接HIS,LIS等医院信息接口数据库信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataConn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ConfigDataBase.aspx");
    }
    /// <summary>
    /// 设置连接HIS,LIS等医院信息接口数据库信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PZ_trans_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ConfigTransData.aspx");
    }
    /// <summary>
    /// 测试DoCare连接数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void textInfo_Click(object sender, EventArgs e)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {
            if (DateType.Contains("ODBC"))
            {
                doCareDict1 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictOdbc("HIS");
                doCareDict2 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictOdbc("HIS");
            }
            else if (DateType.Contains("OLE"))
            {
                doCareDict1 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictOLE("HIS");
                doCareDict2 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictOLE("HIS");

            }
            else if (DateType.Contains("SQLServer"))
            {
                doCareDict1 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictSQL("HIS");
                doCareDict2 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictSQL("HIS");
            }
            else if (DateType.Contains("SQLSVR2008"))
            {
                doCareDict1 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictSQL("HIS");
                doCareDict2 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDictSQL("HIS");
            }
            else
            {
                doCareDict1 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDict("HIS");
                doCareDict2 = MedicalSytem.Soft.DAL.DALMedInitDict.SelectTransDict("HIS");
            }
            this.aneshisSupply.Text = doCareDict1.DoCareHisSupply;
            this.aneslis.Text = doCareDict1.DoCareIsLabResult;
            this.anesorders.Text = doCareDict1.DoCareIsOrders;


            this.icuhisSupply.Text = doCareDict2.DoCareHisSupply;
            this.iculis.Text = doCareDict2.DoCareIsLabResult;
            this.icuorders.Text = doCareDict2.DoCareIsOrders;

            this.datalogs.Text = "显示DoCare配置信息:DoCare数据库连接成功!";
        }
        catch (Exception ex)
        {
            this.datalogs.Text = "DoCare数据库连接失败:" + ex.Message;
            InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式" + ex.StackTrace + "\r\n引发当前异常的函数为" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为" + ex.Source + "\r\n");
            this.aneshisSupply.Text = "失败!";
            this.aneslis.Text = "失败!";
            this.anesorders.Text = "失败!";

            this.icuhisSupply.Text = "失败!";
            this.iculis.Text = "失败!";
            this.icuorders.Text = "失败!";

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void loginInEmr_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/main/mainFrame.htm");
    }
    protected void WebServices_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DocareTrunDataService.asmx");
    }
}
