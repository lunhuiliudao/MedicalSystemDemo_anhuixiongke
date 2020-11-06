<%@ Application Language="C#" %>
<%@ Import Namespace="System" %> 
<%@ Import Namespace="System.Collections" %> 
<%@ Import Namespace="System.Configuration" %> 
<%@ Import Namespace="System.Data" %> 
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.Security" %> 
<%@ Import Namespace="System.Web.SessionState" %> 
<%@ Import Namespace=" System.IO " %>
<%@ Import Namespace=" InitDocare " %>

<script runat="server">

public class Global : System.Web.HttpApplication
{
    public static string Emr_Path = "";
    public static string IP_Address = "";
    public static string Web_Path = "";
    public static string WebServer_IP = "http://{0}";
    public static string Menu_Type = "";
    
    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码
        Session.Timeout = 60;  
    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。
        DeleteFiles(Session.SessionID);
    }

    public void DeleteFiles(string sessionid)
    {
        DirectoryInfo di = new DirectoryInfo(string.Format("{0}pdftemp\\", Web_Path));
        foreach (FileInfo fi in di.GetFiles(string.Format("{0}*.pdf", sessionid)))
        {
            try
            {
                fi.Delete();
            }
            catch
            {
                continue;
            }

        }
    }

}
</script>
