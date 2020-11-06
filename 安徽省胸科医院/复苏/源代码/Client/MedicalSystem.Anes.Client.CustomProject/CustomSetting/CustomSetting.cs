using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class CustomSetting : ICustomSetting
    {
        public static string PostPDF_ServerURL = null;
        public static string PostPDF_LocalURL = null;
        public static string[] PostPDF_Names = null;

        public static string[] DocNameCheckList = null;

        public static string MedSheetContinue = null;

        public void InitCustomSetting()
        {


            //病历病程是否窗口显示
            ExtendApplicationContext.Current.CustomSettingContext.IsCheckInfoShowDialog = false;

            //检查结果是否窗口显示
            ExtendApplicationContext.Current.CustomSettingContext.IsHisCheckInfo = false;


            //文书中切换使用DEV日期控件
            ExtendApplicationContext.Current.CustomSettingContext.IsShowDevDateTimeEditor = true;

            //程序登入后是否弹出显示术中患者列表
            //ExtendApplicationContext.Current.CustomSettingContext.IsShowUnDonePatientListView = ApplicationConfiguration.IsShowUnDonePatientList;

            //文书中同步手术申请
            ExtendApplicationContext.Current.CustomSettingContext.IsSyncScheduleInfo = true;


            //加载自定义文书模板标识(模板管理-文书模板列表)
            XmlDocument xmlDoc = new XmlDocument();
            //if (System.IO.File.Exists(ExtendApplicationContext.Current.AppPath + @"\DocTemplate\客户化医院\CustomDocTempletFlags.xml"))
            //{
            //    xmlDoc.Load(ExtendApplicationContext.Current.AppPath + @"\DocTemplate\客户化医院\CustomDocTempletFlags.xml");
            //}
            //其他医院打版本需求，不写死医院文件夹
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(ExtendApplicationContext.Current.AppPath + @"\DocTemplate\");
            System.IO.FileInfo[] fileInfos = dir.GetFiles("CustomDocTempletFlags.xml", System.IO.SearchOption.AllDirectories);
            if (fileInfos != null && fileInfos.Length > 0)
            {
                xmlDoc.Load(fileInfos[0].FullName);
            }
            if (xmlDoc.ChildNodes.Count > 0)
            {
                foreach (XmlNode xmlNode in xmlDoc.ChildNodes[0].ChildNodes)
                {
                    if (xmlNode is XmlComment) continue;
                    ExtendApplicationContext.Current.CustomSettingContext.CustomTempletFlagNames.Add(xmlNode.Name);
                }
            }
           





            // 获取上传PDF配置 
            PostPDF_ServerURL = ApplicationConfiguration.PDFServerUrl;
            PostPDF_LocalURL = ApplicationConfiguration.PDFLocalUrl; 
           //  获取上传PDF配置
            if (!string.IsNullOrEmpty(ApplicationConfiguration.PostPDF_Names))
            {
                PostPDF_Names = ApplicationConfiguration.PostPDF_Names.Split(new char[] { ',' }, StringSplitOptions.None);
            } 
            ExtendApplicationContext.Current.CustomSettingContext.IsCheckDocCompelete = true;

            // 获取检查的文书
            if (!string.IsNullOrEmpty(ApplicationConfiguration.DocNameCheckList))
            {
                DocNameCheckList = ApplicationConfiguration.DocNameCheckList.Split(new char[] { ',' }, StringSplitOptions.None);
            }

            //监测项目默认持续配置
            MedSheetContinue = System.Configuration.ConfigurationManager.AppSettings["MedSheetContinue"];
        }
    }
}
