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
using System.IO;

public partial class main_ImageView : InitDocare.BasePager
{

    public string imgpath = "";
    public string Web_Path = "";
    public string Menu_Type = "";
    public string WebServer_IP = "";
    public string Emr_Path = "";
    public string IP_Address = "";


    protected override void OnInit(EventArgs e)
    {
        btnSaveAs.Click += new EventHandler(btnSaveAs_Click);
        base.OnInit(e);
    }

    void btnSaveAs_Click(object sender, EventArgs e)
    {
        //DownloadFile.aspx?file=要下载的图片url

        string url = HttpContext.Current.Request.Url.Query.ToLower();

        //file=dddd.jpg
        //  url = url.Replace("?file=", "");
        //  url = imgEmr.ImageUrl;
        //  url = url.Substring(url.IndexOf("DocareInterfaceV4") + 1);
        if (!string.IsNullOrEmpty(imgpath))
        {
            url = "~/" + imgpath.Substring(imgpath.IndexOf("imgtemp"));
        }
        else
        {
            url = imgEmr.ImageUrl;
            url = "~/" + url.Substring(url.IndexOf("imgtemp"));
        }
        Response.BufferOutput = false;
        Response.Clear();
        Response.ContentType = "application/x-msdownload";

        string fileName = System.Web.HttpUtility.UrlEncode(url, System.Text.Encoding.Unicode);//解决文件名乱码
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + url);
        Response.ContentType = "application/octstream";
        Response.CacheControl = "Private";

        System.IO.Stream stm = new System.IO.FileStream(Server.MapPath(url), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
        Response.AppendHeader("Content-length", stm.Length.ToString());

        System.IO.BinaryReader br = new System.IO.BinaryReader(stm);

        byte[] bytes;

        for (Int64 x = 0; x < (br.BaseStream.Length / 4096 + 1); x++)
        {
            bytes = br.ReadBytes(4096);
            Response.BinaryWrite(bytes);
            System.Threading.Thread.Sleep(1);  //休息一下,防止耗用带宽太多。
        }
        stm.Close();


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Web_Path))
        {
            try
            {
                string virtualPath = System.Configuration.ConfigurationManager.AppSettings["virtualPath"];
                Menu_Type = System.Configuration.ConfigurationManager.AppSettings["menutype"];

                virtualPath = string.IsNullOrEmpty(virtualPath) ? ("") : (virtualPath);
                virtualPath = virtualPath.Length > 0 ? ("/" + virtualPath) : ("");
                string tempPath = (HttpContext.Current.Request.ServerVariables["Server_Name"] + ":" + HttpContext.Current.Request.ServerVariables["Server_Port"] + virtualPath);
                WebServer_IP = string.Format("http://{0}", tempPath);
                Web_Path = HttpContext.Current.Request.PhysicalApplicationPath;
                InitDocare.DbAccess db = new InitDocare.DbAccess().GetDbAccess();
                DataTable dt = db.GetTable("select EMR_PATH,IP_ADDR from med_emr_work_path where application='DOCARE'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        Emr_Path = Convert.ToString(dt.Rows[0]["Emr_Path"]);
                        IP_Address = Convert.ToString(dt.Rows[0]["IP_ADDR"]);
                    }
                }
            }
            catch
            {
                //
            }

            if (!IsAjax())
            {
                string sessionID = Session.SessionID;
                //判断文件
                string localfile = string.Format("{0}{1}\\{2}", Web_Path, "imgtemp", sessionID + GetRequest("imgpath"));//本地路径
                string userFolderName = GetRequest("imgpath");//文件名
                int ErrorLog = InitDocare.ImportDll.getfile(IP_Address, userFolderName, localfile, 1, 1);

                if (ErrorLog == 0)
                {
                    imgpath = string.Format("{0}/imgtemp/{1}", WebServer_IP, sessionID + GetRequest("imgpath"));
                    imgEmr.ImageUrl = imgpath;
                }
                else
                {
                    string ErrorString = ErrorDisplay(ErrorLog);
                    Response.Write("错误提示:" + ErrorString);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(string), "key", "<script>alert('EMRServer下载EMR文件失败!错误代码" + ErrorString + "');</script>", false);
                }
            }
        }
    }

    public bool IsAjax()
    {
        string isAjax = this.GetRequest("isAjax").ToLower();
        if (isAjax == "true")
        {
            string imgpath = this.GetRequest("imgpath");
            imgpath = string.Format("{0}imgtemp\\{1}", Web_Path, imgpath);
            if (System.IO.File.Exists(imgpath))
            {
                try
                {

                    DirectoryInfo di = new DirectoryInfo(string.Format("{0}imgtemp\\", Web_Path));
                    foreach (FileInfo fi in di.GetFiles(string.Format("{0}*.jpg", Session.SessionID)))
                    {
                        if (fi.Name != GetRequest("imgpath"))
                            fi.Delete();
                    }
                }
                catch
                {

                }

            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public string ErrorDisplay(int ErrorValue)
    {
        string ErrorString = "";
        switch (ErrorValue.ToString())
        {
            case "0":
                ErrorString = "ERR_OK[操作成功]0";
                break;
            case "-1":
                ErrorString = "ERR_CREATE_SOCKET_FAILED[初始化网络连接失败]-1";
                break;
            case "-2":
                ErrorString = "ERR_CONNECT_FAILED[连接服务器失败]-2";
                break;
            case "-3":
                ErrorString = "ERR_NETWORK_ERROR[网络通信错误]-3";
                break;
            case "-4":
                ErrorString = "ERR_FILE_NOT_FOUND[文件未找到]-4";
                break;
            case "-5":
                ErrorString = "ERR_BAD_FILENAME[无效的文件名]-5";
                break;
            case "-6":
                ErrorString = "ERR_READ_FILE_FAILED[读取文件失败]-6";
                break;
            case "-7":
                ErrorString = "ERR_CREATE_FILE_FAILED[创建文件失败]-7";
                break;
            case "-8":
                ErrorString = "ERR_WRITE_FILE_FAILED[写文件失败]-8";
                break;
            case "-9":
                ErrorString = "ERR_FILE_EXISTS [文件已存在]-9";
                break;
            case "-10":
                ErrorString = "ERR_DELETE_FILE_FAILED [删除文件（或目录）失败]";
                break;
            case "-11":
                ErrorString = " ERR_CREATE_DIR_FAILED [创建目录失败]";
                break;
            case "-12":
                ErrorString = "ERR_NO_POPEDOM [没有权限访问改路径]";
                break;
            case "-13":
                ErrorString = "ERR_CHECKSUM_ERROR [校验出错]";
                break;
            case "-14":
                ErrorString = "ERR_INVALID_PARAMETER [无效的参数]";
                break;
            case "-15":
                ErrorString = "ERR_COMMAND_CANCELED [命令被取消，可能是服务器重启]-15";
                break;
            case "-16":
                ErrorString = " ERR_LOCAL_OP_FAILED[操作本地文件失败]-16";
                break;
            case "-17":
                ErrorString = "ERR_OVERWRITE_FILE_FAILED[覆盖文件失败]-17";
                break;
            case "-18":
                ErrorString = "ERR_BAD_FILENAME_FORMAT[错误文件名称格式]-18";
                break;
            default:
                ErrorString = "ERR_OK[操作成功]";
                break;
        }
        return ErrorString;
    }
}
