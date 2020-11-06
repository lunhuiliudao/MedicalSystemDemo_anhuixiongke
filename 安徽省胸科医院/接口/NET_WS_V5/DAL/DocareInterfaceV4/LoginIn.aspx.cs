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
using InitDocare;
public partial class LoginIn : System.Web.UI.Page
{
    private string LoginConName;

    private string loginConPwd;
    /// <summary>
    /// 初始界面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginConName = ConfigurationManager.AppSettings["loginName"];
        loginConPwd = ConfigurationManager.AppSettings["LoginPwd"];
    }
    /// <summary>
    /// 登录按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void loginServer_Click(object sender, EventArgs e)
    {
        if (this.loginName.Text.Length < 1 || this.loginPwd.Text.Length < 1)
            return;
        if (this.loginName.Text.ToUpper() == LoginConName.ToUpper())
        {
            if (loginConPwd == PublicA.GetDigest(this.loginPwd.Text.ToUpper()))
            {
                Session["Name"] = LoginConName;
                //Response.Write("登录成功");
                Response.Redirect("~/Admin/Default.aspx");
            }
        }
    }

    protected void lookWebService_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/WebServices.asmx");
    }
    protected void MainServer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage/index.aspx");
    }
    protected void Login_emr_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/main/mainFrame.htm");

    }
}
