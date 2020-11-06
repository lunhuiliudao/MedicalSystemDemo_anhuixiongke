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
        
        this.DocareAttendMode.Text = PublicA.GetConfig("DataServerType") + "  ���ʷ�ʽ!";
        if (PublicA.GetConfig("DataServerType").ToString().Trim().Contains("SQLSERVER"))
        {
            connAll = ConnectionTestInfo.ConnectionSQLTest(PublicA.GetConfig("SQLClientConnString"));

            string[] temp1 = PublicA.GetConfig("SQLClientConnString").Split(new char[2] { '=', ';' });
            this.DocareConnInfo.Text = "  ���ӵ����ݿ������Ϊ:" + temp1[1] + "���ݿ�Ϊ:" + temp1[3] + "��¼��Ϊ:" + temp1[7] + "����Ϊ: " + temp1[5];
            this.DocareAdviceMode.Text = "����������--NET8 ���ú��û���������������ȵ�!";
        }
        else
        {
            connAll = ConnectionTestInfo.ConnectionOracleTest(PublicA.GetConfig("OraClientConnString"));

            string[] temp1 = PublicA.GetConfig("OraClientConnString").Split(new char[2] { '=', ';' });
            this.DocareConnInfo.Text = "  ���ӵ����ݿ�Ϊ:" + temp1[3] + "��¼��Ϊ:" + temp1[7] + "����Ϊ: " + temp1[5];
            this.DocareAdviceMode.Text = "����������--IP ���ú��û���������������ȵ�!";
        }
        if (connAll)
        {
            this.DocareAttendMode.Text += "--�������ݿ���ȷ!�������������!";
            this.DocareAdviceMode.Text = "";

            HISTest_Click(null, null);
            LISTest_Click(null, null);
            PACSTest_Click(null, null);
        }
        else
        {
            this.DocareAttendMode.Text += "--�������ݿ����Ӵ���!���������ݿ�����!";
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
        //this.HISAttendMode.Text = hoppitalSelect.GetDataModeHIS() + "  ���ʷ�ʽ!";
        //if (hoppitalSelect.GetDataModeHIS() == "")
        //    return;
        //if (hoppitalSelect.GetDataModeHIS().Trim().ToUpper() == "WEBSERVICES")
        //{
        //    this.HISConnInfo.Text = "WebServices��ַΪ: " + PublicA.GetConfig("WebServerUrl");

        //    if (UrlExistsUsingSockets(PublicA.GetConfig("WebServerUrl")))
        //    {
        //        this.HISAttendMode.Text += "WebServices��ַ���ӳɹ�!";
        //    }
        //    else
        //    {
        //        this.HISAttendMode.Text += "--����WebServices��ַ����!������WebServices��ַ!";
        //        this.HISAttendMode.ForeColor = System.Drawing.Color.Red;
        //        this.HISAdviceMode.Text = "����������ַ,����WebServices��ַ!";
        //    }
        //    return;
        //}
        //if (anesDict.Dbms.Trim().ToUpper().Contains("SQLSERVER") || anesDict.Dbms.Trim().Contains("MSS Microsoft SQL Server"))
        //{
        //    conn = ConnectionTestInfo.ConnectionSQLTest(anesConfig.HisConnection);

        //    string[] temp1 = anesConfig.HisConnection.Split(new char[2] { '=', ';' });
        //    this.HISConnInfo.Text = "  ���ӵ����ݿ������Ϊ:" + temp1[1] + "���ݿ�Ϊ:" + temp1[3] + "��¼��Ϊ:" + temp1[7] + "����Ϊ: " + temp1[5];
        //    this.HISAdviceMode.Text = "����������--NET8 ���ú��û���������������ȵ�!";
        //}
        //else
        //{
        //    conn = ConnectionTestInfo.ConnectionOracleTest(anesConfig.HisConnection);

        //    string[] temp1 = anesConfig.HisConnection.Split(new char[2] { '=', ';' });
        //    this.HISConnInfo.Text = "  ���ӵ����ݿ�Ϊ:" + temp1[3] + "��¼��Ϊ:" + temp1[7] + "����Ϊ: " + temp1[5];
        //    this.HISAdviceMode.Text = "����������--IP ���ú��û���������������ȵ�!";
        //}
        //if (conn)
        //{
        //    this.HISAttendMode.Text += "--�������ݿ���ȷ!�������������!";
        //    this.HISAdviceMode.Text = "";
            
        //}
        //else
        //{
        //    this.HISAttendMode.Text += "--�������ݿ����Ӵ���!���������ݿ�����!";
        //    this.HISAttendMode.ForeColor = System.Drawing.Color.Red;
        //}
    }

    protected void LISTest_Click(object sender, EventArgs e)
    {
        //if (!connAll)
        //    return;
        //iniAnes("LIS");
        //bool conn = false;
        //this.LISAttendMode.Text = hoppitalSelect.GetDataModeLIS() + "  ���ʷ�ʽ!";
        //if (hoppitalSelect.GetDataModeLIS() == "")
        //    return;
        //if (hoppitalSelect.GetDataModeLIS().Trim().ToUpper() == "WEBSERVICES")
        //{
        //    this.LISConnInfo.Text = "WebServices��ַΪ: " + PublicA.GetConfig("WebServerUrl");

        //    if (UrlExistsUsingSockets(PublicA.GetConfig("WebServerUrl")))
        //    {
        //        this.LISAttendMode.Text += "WebServices��ַ���ӳɹ�!";
        //    }
        //    else
        //    {
        //        this.LISAttendMode.Text += "--����WebServices��ַ����!������WebServices��ַ!";
        //        this.LISAttendMode.ForeColor = System.Drawing.Color.Red;
        //        this.LISAdviceMode.Text = "����������ַ,����WebServices��ַ!";
        //    }
        //    return;
        //}
        //if (anesDict.Dbms.Trim().ToUpper().Contains("SQLSERVER") || anesDict.Dbms.Trim().Contains("MSS Microsoft SQL Server"))
        //{
        //    conn = ConnectionTestInfo.ConnectionSQLTest(anesConfig.LisConnection);

        //    string[] temp1 = anesConfig.LisConnection.Split(new char[2] { '=', ';' });
        //    this.LISConnInfo.Text = "  ���ӵ����ݿ������Ϊ:" + temp1[1] + "���ݿ�Ϊ:" + temp1[3] + "��¼��Ϊ:" + temp1[7] + "����Ϊ: " + temp1[5];
        //    this.LISAdviceMode.Text = "����������--NET8 ���ú��û���������������ȵ�!";
        //}
        //else
        //{
        //    conn = ConnectionTestInfo.ConnectionOracleTest(anesConfig.LisConnection);

        //    string[] temp1 = anesConfig.LisConnection.Split(new char[2] { '=', ';' });
        //    this.LISConnInfo.Text = "  ���ӵ����ݿ�Ϊ:" + temp1[3] + "��¼��Ϊ:" + temp1[7] + "����Ϊ: " + temp1[5];
        //    this.LISAdviceMode.Text = "����������--IP ���ú��û���������������ȵ�!";
        //}
        //if (conn)
        //{
        //    this.LISAttendMode.Text += "--�������ݿ���ȷ!�������������!";
        //    this.LISAdviceMode.Text = "";

        //}
        //else
        //{
        //    this.LISAttendMode.Text += "--�������ݿ����Ӵ���!���������ݿ�����!";
        //    this.LISAttendMode.ForeColor = System.Drawing.Color.Red;
        //}
    }

    protected void PACSTest_Click(object sender, EventArgs e)
    {
        if (!connAll)
            return;
    }

    /// <summary>
    /// ��ʼ��ICU�����ַ���(����)
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
            throw new Exception("�������������ݿ⣡ " + ex.Message);
        }
    }
    /// <summary>
    /// ��ʼ��ANES�����ַ���(����)
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
            throw new Exception("�������������ݿ⣡ " + ex.Message);
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
