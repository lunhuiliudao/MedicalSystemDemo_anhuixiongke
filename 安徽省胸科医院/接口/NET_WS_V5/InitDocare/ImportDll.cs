using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Runtime.InteropServices;

namespace InitDocare
{
    public class ImportDll
    {
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="SerIPAddr">服务器地址</param>
        /// <param name="RemoteFileName">文件名</param>
        /// <param name="protocol">0写数据库1不写数据库2参数RemoteFileName带路径上传不写数据库</param>
        /// <param name="LocalFileName">客户端存在的文件具体地址</param>
        /// <param name="append">是否覆盖1覆盖0不能覆盖</param>
        /// <returns></returns>
        [DllImport("EMRFSRV.dll")]
        public static extern int getfile(string SerIPAddr, string RemoteFileName, string LocalFileName, int protocol, int append);
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="SerIPAddr">服务器地址</param>
        /// <param name="LocalFileName">客户端文件存在的具体地址</param>
        /// <param name="RemoteFileName">文件名</param>
        /// <param name="protocol">0 1 参数LocalFileName使用格式名称 2参数LocalFileName带路径文件名称</param>
        /// <param name="append">是否覆盖1覆盖0不能覆盖</param>
        /// <returns></returns>
        [DllImport("EMRFSRV.dll")]
        public static extern int putfile(string SerIPAddr, string LocalFileName, string RemoteFileName, int protocol, int append);
    }
}
