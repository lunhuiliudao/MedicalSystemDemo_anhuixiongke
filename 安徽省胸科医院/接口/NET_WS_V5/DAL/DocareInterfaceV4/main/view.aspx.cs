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

namespace DoCareEmr
{
    public partial class view : InitDocare.BasePager
    {
        public string pdfpath = "";

        public string Web_Path = "";
        public string Menu_Type = "";
        public string WebServer_IP = "";
        public string Emr_Path = "";
        public string IP_Address = "";
        // public PDFVIEWLib.PDFView pdf = new PDFVIEWLib.PDFView();
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
            }
            if (!IsAjax())
            {
                string sessionID = Session.SessionID;
                //�ж��ļ�
                string localfile = string.Format("{0}{1}\\{2}", Web_Path, "pdftemp", sessionID + GetRequest("pdfpath"));//����·��
                string userFolderName = GetRequest("pdfpath");//�ļ���
                int ErrorLog = InitDocare.ImportDll.getfile(IP_Address, userFolderName, localfile, 1, 1);

                if (ErrorLog == 0)
                {
                    pdfpath = string.Format("{0}/pdftemp/{1}", WebServer_IP, sessionID + GetRequest("pdfpath"));
                }
                else
                {
                    string ErrorString = ErrorDisplay(ErrorLog);
                    //Response.Write("������ʾ:" + ErrorString);
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "key", "<script>alert('EMRServer����PDF�ļ�ʧ��!�������" + ErrorString + "');</script>", false);
                }

            }
        }
        public bool IsAjax()
        {
            string isAjax = this.GetRequest("isAjax").ToLower();
            if (isAjax == "true")
            {
                string pdfpath = this.GetRequest("pdfpath");
                pdfpath = string.Format("{0}pdftemp\\{1}", Web_Path, pdfpath);
                if (System.IO.File.Exists(pdfpath))
                {
                    try
                    {

                        DirectoryInfo di = new DirectoryInfo(string.Format("{0}pdftemp\\", Web_Path));
                        foreach (FileInfo fi in di.GetFiles(string.Format("{0}*.pdf", Session.SessionID)))
                        {
                            if (fi.Name != GetRequest("pdfpath"))
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
                    ErrorString = "ERR_OK[�����ɹ�]0";
                    break;
                case "-1":
                    ErrorString = "ERR_CREATE_SOCKET_FAILED[��ʼ����������ʧ��]-1";
                    break;
                case "-2":
                    ErrorString = "ERR_CONNECT_FAILED[���ӷ�����ʧ��]-2";
                    break;
                case "-3":
                    ErrorString = "ERR_NETWORK_ERROR[����ͨ�Ŵ���]-3";
                    break;
                case "-4":
                    ErrorString = "ERR_FILE_NOT_FOUND[�ļ�δ�ҵ�]-4";
                    break;
                case "-5":
                    ErrorString = "ERR_BAD_FILENAME[��Ч���ļ���]-5";
                    break;
                case "-6":
                    ErrorString = "ERR_READ_FILE_FAILED[��ȡ�ļ�ʧ��]-6";
                    break;
                case "-7":
                    ErrorString = "ERR_CREATE_FILE_FAILED[�����ļ�ʧ��]-7";
                    break;
                case "-8":
                    ErrorString = "ERR_WRITE_FILE_FAILED[д�ļ�ʧ��]-8";
                    break;
                case "-9":
                    ErrorString = "ERR_FILE_EXISTS [�ļ��Ѵ���]-9";
                    break;
                case "-10":
                    ErrorString = "ERR_DELETE_FILE_FAILED [ɾ���ļ�����Ŀ¼��ʧ��]";
                    break;
                case "-11":
                    ErrorString = " ERR_CREATE_DIR_FAILED [����Ŀ¼ʧ��]";
                    break;
                case "-12":
                    ErrorString = "ERR_NO_POPEDOM [û��Ȩ�޷��ʸ�·��]";
                    break;
                case "-13":
                    ErrorString = "ERR_CHECKSUM_ERROR [У�����]";
                    break;
                case "-14":
                    ErrorString = "ERR_INVALID_PARAMETER [��Ч�Ĳ���]";
                    break;
                case "-15":
                    ErrorString = "ERR_COMMAND_CANCELED [���ȡ���������Ƿ���������]-15";
                    break;
                case "-16":
                    ErrorString = " ERR_LOCAL_OP_FAILED[���������ļ�ʧ��]-16";
                    break;
                case "-17":
                    ErrorString = "ERR_OVERWRITE_FILE_FAILED[�����ļ�ʧ��]-17";
                    break;
                case "-18":
                    ErrorString = "ERR_BAD_FILENAME_FORMAT[�����ļ����Ƹ�ʽ]-18";
                    break;
                default:
                    ErrorString = "ERR_OK[�����ɹ�]";
                    break;
            }
            return ErrorString;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Write();
        }
        protected void bt_print_Click(object sender, EventArgs e)
        {
           // pdf.Print(pdfpath, "", 3, 1);
        }
}

}