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

public partial class Admin_GuanYuVerion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null)
        {

        }
        else
        {
            Response.Redirect("../LoginIn.aspx");
        }
    }
    protected void forInfo1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Default.aspx");
    }
    protected void dataConn1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/DataBaseConfig.aspx");
    }
    /// <summary>
    /// 测试HIS的信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void guanyu1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/HisFromInfo.aspx");
    }
}
