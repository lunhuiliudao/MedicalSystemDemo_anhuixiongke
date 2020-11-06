// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      CustomSetting.cs
// 功能描述(Description)：    加载文书配置信息
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.Document;
using System;
using System.Xml;

namespace MedicalSystem.Anes.CustomProject
{
    public class CustomSetting : ICustomSetting
    {
        /// <summary>
        /// 可以上传PDF的文书列表
        /// </summary>
        public static string[] PostPDF_Names = null;                             

        /// <summary>
        /// 需要检查的文书列表
        /// </summary>
        public static string[] DocNameCheckList = null;

        /// <summary>
        /// 监测项目默认持续配置
        /// </summary>
        public static string MedSheetContinue = null;

        /// <summary>
        /// 初始化方法
        /// </summary>
        public void InitCustomSetting()
        {
            // 病历病程是否窗口显示
            ExtendAppContext.Current.CustomSettingContext.IsCheckInfoShowDialog = false;

            // 检查结果是否窗口显示
            ExtendAppContext.Current.CustomSettingContext.IsHisCheckInfo = false;

            // 文书中切换使用DEV日期控件
            ExtendAppContext.Current.CustomSettingContext.IsShowDevDateTimeEditor = true;

            // 文书中同步手术申请
            ExtendAppContext.Current.CustomSettingContext.IsSyncScheduleInfo = true;

            // 加载自定义文书模板标识(模板管理-文书模板列表)
            XmlDocument xmlDoc = new XmlDocument();
            // 其他医院打版本需求，不写死医院文件夹
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(ExtendAppContext.Current.AppPath + @"\DocTemplate\");
            System.IO.FileInfo[] fileInfos = dir.GetFiles("CustomDocTempletFlags.xml", System.IO.SearchOption.AllDirectories);
            if (fileInfos != null && fileInfos.Length > 0)
            {
                xmlDoc.Load(fileInfos[0].FullName);
            }

            if (xmlDoc.ChildNodes.Count > 0)
            {
                foreach (XmlNode xmlNode in xmlDoc.ChildNodes[0].ChildNodes)
                {
                    if (xmlNode is XmlComment)
                    {
                        continue;
                    }

                    ExtendAppContext.Current.CustomSettingContext.CustomTempletFlagNames.Add(xmlNode.Name);
                }
            }
            
            //  获取上传PDF配置
            if (!string.IsNullOrEmpty(ApplicationConfiguration.PostPDF_Names))
            {
                PostPDF_Names = ApplicationConfiguration.PostPDF_Names.Split(new char[] { ',' }, StringSplitOptions.None);
            } 

            ExtendAppContext.Current.CustomSettingContext.IsCheckDocCompelete = true;

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
