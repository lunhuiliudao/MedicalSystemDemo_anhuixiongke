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
using BLL;
using InitDocare;
public partial class Manage_index : System.Web.UI.Page
{

    private bool connAll = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        Refurbish();
    }

    private void Refurbish()
    {
        DocareTest_Click(null, null);
    }

    protected void DocareTest_Click(object sender, EventArgs e)
    {
        
        this.DocareAttendMode.Text = PublicA.GetConfig("DataServerType") + "  访问方式!";
        if (PublicA.GetConfig("DataServerType").ToString().Trim().Contains("SQLSERVER"))
        {
            connAll = ConnectionTestInfo.ConnectionSQLTest(PublicA.GetConfig("SQLClientConnString"));

            string[] temp1 = PublicA.GetConfig("SQLClientConnString").Split(new char[2] { '=', ';' });
            this.DocareConnInfo.Text = "  连接的数据库服务名为:" + temp1[1] + "数据库为:" + temp1[3] + "登录名为:" + temp1[7] + "密码为: " + temp1[5];
            this.DocareAdviceMode.Text = "检查服务器的--NET8 配置和用户名密码配置网络等等!";
        }
        else
        {
            connAll = ConnectionTestInfo.ConnectionOracleTest(PublicA.GetConfig("OraClientConnString"));

            string[] temp1 = PublicA.GetConfig("OraClientConnString").Split(new char[2] { '=', ';' });
            this.DocareConnInfo.Text = "  连接的数据库为:" + temp1[3] + "登录名为:" + temp1[7] + "密码为: " + temp1[5];
            this.DocareAdviceMode.Text = "检查服务器的--IP 配置和用户名密码配置网络等等!";
        }
        if (connAll)
        {
            this.DocareAttendMode.Text += "--访问数据库正确!请进行其他测试!";
            this.DocareAdviceMode.Text = "";

            HISTest_Click(null, null);
            LISTest_Click(null, null);
            PACSTest_Click(null, null);
        }
        else
        {
            this.DocareAttendMode.Text += "--访问数据库连接错误!请配置数据库连接!";
            this.DocareAttendMode.ForeColor = System.Drawing.Color.Red;
        }
        
        
    }

    protected void HISTest_Click(object sender, EventArgs e)
    {
        //if (!connAll)
        //    return;
        //iniAnes("HIS");
        //hoppitalSelect = hospitalbaseSelect.SelectHospital(anesDict.AnesHisSupply);
        //bool conn = false;
        //this.HISAttendMode.Text = hoppitalSelect.GetDataModeHIS() + "  访问方式!";
        //if (hoppitalSelect.GetDataModeHIS() == "")
        //    return;
        //if (hoppitalSelect.GetDataModeHIS().Trim().ToUpper() == "WEBSERVICES")
        //{
        //    this.HISConnInfo.Text = "WebServices地址为: " + PublicA.GetConfig("WebServerUrl");

        //    if (UrlExistsUsingSockets(PublicA.GetConfig("WebServerUrl")))
        //    {
        //        this.HISAttendMode.Text += "WebServices地址连接成功!";
        //    }
        //    else
        //    {
        //        this.HISAttendMode.Text += "--访问WebServices地址出错!请配置WebServices地址!";
        //        this.HISAttendMode.ForeColor = System.Drawing.Color.Red;
        //        this.HISAdviceMode.Text = "检查服务器地址,更新WebServices地址!";
        //    }
        //    return;
        //}
        //if (anesDict.Dbms.Trim().ToUpper().Contains("SQLSERVER") || anesDict.Dbms.Trim().Contains("MSS Microsoft SQL Server"))
        //{
        //    conn = ConnectionTestInfo.ConnectionSQLTest(anesConfig.HisConnection);

        //    string[] temp1 = anesConfig.HisConnection.Split(new char[2] { '=', ';' });
        //    this.HISConnInfo.Text = "  连接的数据库服务名为:" + temp1[1] + "数据库为:" + temp1[3] + "登录名为:" + temp1[7] + "密码为: " + temp1[5];
        //    this.HISAdviceMode.Text = "检查服务器的--NET8 配置和用户名密码配置网络等等!";
        //}
        //else
        //{
        //    conn = ConnectionTestInfo.ConnectionOracleTest(anesConfig.HisConnection);

        //    string[] temp1 = anesConfig.HisConnection.Split(new char[2] { '=', ';' });
        //    this.HISConnInfo.Text = "  连接的数据库为:" + temp1[3] + "登录名为:" + temp1[7] + "密码为: " + temp1[5];
        //    this.HISAdviceMode.Text = "检查服务器的--IP 配置和用户名密码配置网络等等!";
        //}
        //if (conn)
        //{
        //    this.HISAttendMode.Text += "--访问数据库正确!请进行其他测试!";
        //    this.HISAdviceMode.Text = "";
            
        //}
        //else
        //{
        //    this.HISAttendMode.Text += "--访问数据库连接错误!请配置数据库连接!";
        //    this.HISAttendMode.ForeColor = System.Drawing.Color.Red;
        //}
    }

    protected void LISTest_Click(object sender, EventArgs e)
    {
        //if (!connAll)
        //    return;
        //iniAnes("LIS");
        //bool conn = false;
        //this.LISAttendMode.Text = hoppitalSelect.GetDataModeLIS() + "  访问方式!";
        //if (hoppitalSelect.GetDataModeLIS() == "")
        //    return;
        //if (hoppitalSelect.GetDataModeLIS().Trim().ToUpper() == "WEBSERVICES")
        //{
        //    this.LISConnInfo.Text = "WebServices地址为: " + PublicA.GetConfig("WebServerUrl");

        //    if (UrlExistsUsingSockets(PublicA.GetConfig("WebServerUrl")))
        //    {
        //        this.LISAttendMode.Text += "WebServices地址连接成功!";
        //    }
        //    else
        //    {
        //        this.LISAttendMode.Text += "--访问WebServices地址出错!请配置WebServices地址!";
        //        this.LISAttendMode.ForeColor = System.Drawing.Color.Red;
        //        this.LISAdviceMode.Text = "检查服务器地址,更新WebServices地址!";
        //    }
        //    return;
        //}
        //if (anesDict.Dbms.Trim().ToUpper().Contains("SQLSERVER") || anesDict.Dbms.Trim().Contains("MSS Microsoft SQL Server"))
        //{
        //    conn = ConnectionTestInfo.ConnectionSQLTest(anesConfig.LisConnection);

        //    string[] temp1 = anesConfig.LisConnection.Split(new char[2] { '=', ';' });
        //    this.LISConnInfo.Text = "  连接的数据库服务名为:" + temp1[1] + "数据库为:" + temp1[3] + "登录名为:" + temp1[7] + "密码为: " + temp1[5];
        //    this.LISAdviceMode.Text = "检查服务器的--NET8 配置和用户名密码配置网络等等!";
        //}
        //else
        //{
        //    conn = ConnectionTestInfo.ConnectionOracleTest(anesConfig.LisConnection);

        //    string[] temp1 = anesConfig.LisConnection.Split(new char[2] { '=', ';' });
        //    this.LISConnInfo.Text = "  连接的数据库为:" + temp1[3] + "登录名为:" + temp1[7] + "密码为: " + temp1[5];
        //    this.LISAdviceMode.Text = "检查服务器的--IP 配置和用户名密码配置网络等等!";
        //}
        //if (conn)
        //{
        //    this.LISAttendMode.Text += "--访问数据库正确!请进行其他测试!";
        //    this.LISAdviceMode.Text = "";

        //}
        //else
        //{
        //    this.LISAttendMode.Text += "--访问数据库连接错误!请配置数据库连接!";
        //    this.LISAttendMode.ForeColor = System.Drawing.Color.Red;
        //}
    }

    protected void PACSTest_Click(object sender, EventArgs e)
    {
        if (!connAll)
            return;
    }

    /// <summary>
    /// 初始化ICU链接字符串(参数)
    /// </summary>
    public void iniIcu(string strSystemClass)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {
            //if (DateType.Contains("OLE"))
            //{
            //    icuDict = DALBASE.MedDict.SelectTransDictOLE(strSystemClass, "ICU");
            //}
            //else
            //{
            //    if (DateType.Contains("SQLServer"))
            //    {
            //        icuDict = DALBASE.MedDict.SelectTransDictSQL(strSystemClass, "ICU");
            //    }
            //    else
            //    {
            //        icuDict = DALBASE.MedDict.SelectTransDict(strSystemClass, "ICU");
            //    }
            //}
            //icuConfig = new Model.Config(strSystemClass, DateType, icuDict.Dbms, icuDict.IcuHisSupply, icuDict.ServerName, icuDict.Database, icuDict.LogId, icuDict.LogPass);
        }
        catch (Exception ex)
        {
            throw new Exception("请配置连接数据库！ " + ex.Message);
        }
    }
    /// <summary>
    /// 初始化ANES链接字符串(参数)
    /// </summary>
    public void iniAnes(string strSystemClass)
    {
        string DateType = PublicA.GetConfig("DataServerType");
        try
        {
            //if (DateType.Contains("OLE"))
            //{
            //    anesDict = DALBASE.MedDict.SelectTransDictOLE(strSystemClass, "ANES");
            //}
            //else
            //{
            //    if (DateType.Contains("SQLServer"))
            //    {
            //        anesDict = DALBASE.MedDict.SelectTransDictSQL(strSystemClass, "ANES");
            //    }
            //    else
            //    {
            //        anesDict = DALBASE.MedDict.SelectTransDict(strSystemClass, "ANES");
            //    }
            //}
            //anesConfig = new Model.Config(strSystemClass, DateType, anesDict.Dbms, anesDict.AnesHisSupply, anesDict.ServerName, anesDict.Database, anesDict.LogId, anesDict.LogPass);
        }
        catch (Exception ex)
        {
            throw new Exception("请配置连接数据库！ " + ex.Message);
        }

    }

    private bool UrlExistsUsingSockets(string url)
    {
        if (url.StartsWith("http://")) url = url.Remove(0, "http://".Length);
        try
        {
            bool br = false;
            System.Net.HttpWebRequest myRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            myRequest.Method = "HEAD";
            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)myRequest.GetResponse();
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                br = true;
            }
            return br; 
        }
        catch (System.Net.Sockets.SocketException se)
        {
            System.Diagnostics.Trace.Write(se.Message);
            return false;
        }
    }
}
