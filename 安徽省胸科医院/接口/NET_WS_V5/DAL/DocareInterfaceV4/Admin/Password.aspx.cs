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
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using InitDocare;
public partial class Admin_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string NameCmd = Request.QueryString["User"];
            if (NameCmd==null || NameCmd.Length < 1)
                Response.Redirect("~/LoginIn.aspx");
            this.user.Text = NameCmd;
        }

    }
    protected void save_Click(object sender, EventArgs e)
    {
        if (this.pwd.Text == this.pwd2.Text && PublicA.GetDigest(this.oldPwd.Text.ToUpper()) == ConfigurationManager.AppSettings["LoginPwd"])
        {
            PublicA.WriteConfig("LoginPwd", PublicA.GetDigest(this.pwd.Text.ToUpper()));
            Response.Write("<script>alert('�ɹ��޸��û�����,�����µ�¼,лл!');</script>");
            Response.Redirect("~/LoginIn.aspx");
        }
    }
    protected void cannel_Click(object sender, EventArgs e)
    {
        //string txt = "����";
        //Response.Write("<script>alert('" + txt + "');history.go(-1);</script>");
        Response.Write("<script>window.history.back();history.go(-1);</script>");
        //Response.Write("<script>location.href=location.href   ;</script>");  
    }

}
