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

public partial class LoginEMR : InitDocare.BasePager
{
    InitDocare.UserInfo userinfo = new InitDocare.UserInfo();
    string DateType = PublicA.GetConfig("DataServerType");
    protected void Page_Load(object sender, EventArgs e)
    {
        this.loginButton.Attributes.Add("onclick", "return  logintest();");
        //Response.Cookies["users"].Expires = DateTime.Now;
        //Response.Cookies.Add(Response.Cookies["users"]);
  
    }

    protected void loginButton_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    public bool LoginTest(string username, string userpass)
    {
        //登录代码
        MedicalSytem.Soft.DAL.DALMedEmrUsers oneMedEmrUsers = new MedicalSytem.Soft.DAL.DALMedEmrUsers();
        MedicalSytem.Soft.Model.MedEmrUsers ExistUser = null;
        if (DateType.ToUpper() == "ORACLE")
        {
             ExistUser = oneMedEmrUsers.SelectMedEmrUsersForPwd(username, userpass);
        }
        else if (DateType.ToUpper() == "SQLSERVER")
        {
             ExistUser = oneMedEmrUsers.SelectMedEmrUsersForPwdSQL(username, userpass);
        }
        else
        {
            ExistUser = oneMedEmrUsers.SelectMedEmrUsersForPwd(username, userpass);
        }

       
        if (ExistUser != null)
        {
            userinfo.UserName = ExistUser.LoginName;
            userinfo.UserCode = ExistUser.UserId;
            this.userInfo = userinfo;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        if (LoginTest(this.TbUsername.Text.Trim(), this.TbUserpass.Text.Trim()))
        {

            Response.Redirect("main/mainFrame.htm");
        }
        else
        {
            this.ShowMessage("用户名或密码有误！请注意字母大小写重试", "document.getElementById('TbUsername').focus();");
            //   ScriptManager.RegisterClientScriptBlock(this, typeof(string), "key", "<script type='text/javascript'>alert('用户名或密码有误！请注意字母大小写重试');document.getElementById('TbUsername').focus();</script>", false);
        }
    }
}

