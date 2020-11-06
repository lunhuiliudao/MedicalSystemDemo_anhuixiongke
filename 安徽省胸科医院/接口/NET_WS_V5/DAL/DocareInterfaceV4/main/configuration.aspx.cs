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
    public partial class configuration : InitDocare.BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BtUpdate.Attributes.Add("onclick", "return checkPass()");
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {
            string tempOldPass = this.TbOldPass.Text.Trim();
            string tempNewPass = this.TbNewPass.Text.Trim();
            if (this.Db.GetOne("select LOGIN_PWD from med_emr_users where USER_ID=:USER_ID", this.Db.MakeParameters("USER_ID", this.userInfo.UserCode)).Trim() == tempOldPass.Trim())
            {
                if (this.Db.GetState("update med_emr_users set LOGIN_PWD=:LOGIN_PWD where USER_ID=:USER_ID", this.Db.MakeParameters("LOGIN_PWD", tempNewPass, "USER_ID", userInfo.UserCode)))
                {
                    //this.ShowMessage("修改密码成功！");
                    this.ShowMessage("成功修改密码！", "history.go(-1)");
                }
                else
                {
                   // this.ShowMessage("数据错误请联系管理员!");
                    this.ShowMessage("数据错误请联系管理员！", "history.go(-1)");
                }
            }
            else
            {
                this.ShowMessage("您输入的愿密码不正确！");
            }
        }

    }
}
