using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Reflection;
using System.Web;
using System.Runtime.InteropServices;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace InterFaceV5
{
    public partial class InterFaceV5
    {
        /// <summary>
        /// EMR001电子病历使用第三方SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicEMR"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string HisVisitId = string.Empty;
        public static string patientID = string.Empty;
        public static string visitID = string.Empty;
        public static string inpNO = string.Empty;
        public static string operID = string.Empty;
        public static string EMR001SupplySIF(string mess)
        {

            if (string.IsNullOrEmpty(mess))
            {
                MessageBox.Show("打开异常");
                return "";
            }

            System.Diagnostics.Process.Start(mess);
 
            return "";
        }
        /// <summary>
        /// EMR002电子病历使用第三方SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicEMR"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string EMR002SupplySIF(GPublicConfig lnPublicConfig, GPublicIni lnPublicEMR, ParamInputDomain  parmIn)
        {
            //医院个性化配置
            if (lnPublicEMR.DoCareHisSupply == "军惠")
            {
                //
            }
            return "";
        }
        /// <summary>
        /// EMR003 第三方SIF--为定义使用 预留
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicEMR"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string EMR003SupplySIF(GPublicConfig lnPublicConfig, GPublicIni lnPublicEMR, InterFaceV5 parmIn)
        {
            return "";
        }
        /// <summary>
        /// EMR004电子签名 一般使用HIS厂商提供的
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicEMR"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string EMR004SupplySIF(GPublicConfig lnPublicConfig, GPublicIni lnPublicEMR, InterFaceV5 parmIn)
        {
            //医院个性化配置
            if (lnPublicEMR.DoCareHisSupply == "军惠")
            {
                //
            }
            return "";
        }
        /// <summary>
        /// EMR005收费界面 使用第三方的SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicEMR"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string EMR005SupplySIF(GPublicConfig lnPublicConfig, GPublicIni lnPublicEMR, InterFaceV5 parmIn)
        {
            //医院个性化配置
            if (lnPublicEMR.DoCareHisSupply == "军惠")
            {
                //
            }
            return "";
        }
        /// <summary>
        /// 检查界面 使用第三方的SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicPACS"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string PACS001SupplySIF(string mess)
        {
            if (string.IsNullOrEmpty(mess))
            {
                MessageBox.Show("打开异常");
                return "";
            }

            System.Diagnostics.Process.Start(mess);

            return "";
        }

        /// <summary>
        /// 检查界面 使用第三方的SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicPACS"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string HEAT001SupplySIF(string mess)
        {
            if (string.IsNullOrEmpty(mess))
            {
                MessageBox.Show("打开异常");
                return "";
            }

            System.Diagnostics.Process.Start(mess);

            return "";
        }

        /// <summary>
        /// 检查界面 使用第三方的SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicPACS"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string DefaultSupplySIF(string mess)
        {
            if (string.IsNullOrEmpty(mess))
            {
                MessageBox.Show("打开异常");
                return "";
            }

            System.Diagnostics.Process.Start(mess);

            return "";
        }
        /// <summary>
        /// PACS界面 使用第三方的SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicPACS"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string PACS002SupplySIF(GPublicConfig lnPublicConfig, GPublicIni lnPublicPACS, InterFaceV5 parmIn)
        {
            //医院个性化配置
            if (lnPublicPACS.DoCareHisSupply == "军惠" || lnPublicPACS.DoCareHisSupply == "军惠307")
            {
                //
            }
            else if (lnPublicPACS.DoCareHisSupply == "解放军113医院v4")
            {
               
            }
            return "";
        }
        /// <summary>
        /// 病理界面 使用第三方的SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicPIS"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string PIS001SupplySIF(GPublicConfig lnPublicConfig, GPublicIni lnPublicPIS, InterFaceV5 parmIn)
        {
            //医院个性化配置
            if (lnPublicPIS.DoCareHisSupply == "军惠")
            {
                //
            }
            return "";
        }
        /// <summary>
        /// 检验界面 使用第三方的SIF
        /// </summary>
        /// <param name="lnPublicConfig"></param>
        /// <param name="lnPublicLIS"></param>
        /// <param name="parmIn"></param>
        /// <returns></returns>
        public static string LISSupplySIF(GPublicConfig lnPublicConfig, GPublicIni lnPublicLIS, ParamInputDomain parmIn)
        {
            //医院个性化配置
            if (lnPublicLIS.DoCareHisSupply == "河北省邯郸工程大学附属医院v4" || lnPublicLIS.DoCareHisSupply == "河北省邯郸工程大学附属医院V4")
            {

            }
            else if (lnPublicLIS.DoCareHisSupply.ToUpper() == "湖北省武汉市中心医院V4")
            {
                System.Diagnostics.Process.Start("http://192.168.0.81:8012/showReportlist.aspx?patientID=" + parmIn);
            }
            return "";
        }
      
    }
}
