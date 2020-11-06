using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MedicalSystem.Anes.Document.Configurations
{
   public class MedicalDocSettings
    {
       private static Dictionary<string, MedicalDocElement> _namePathPair = new Dictionary<string, MedicalDocElement>();
       private static Dictionary<string, MedicalDocElement> _nameFormPair = new Dictionary<string, MedicalDocElement>();
       private static Dictionary<string, MedicalDocElement> _nameCustomFormPair = new Dictionary<string, MedicalDocElement>();
       private static  MedicalDocSection GetConfigurationSection()
       {
           return (MedicalDocSection)ConfigurationManager.GetSection("medicalDocSetting");
       }

       static MedicalDocSettings()
       {
           MedicalDocSection configurationSection = GetConfigurationSection();
           if (configurationSection == null)
               throw new ConfigurationErrorsException(string.Format("app.config中未找到名为'medicalDocSetting'的配置块"));

           foreach (MedicalDocElement element in configurationSection.MedicalDocs)
           {
               if (string.IsNullOrEmpty(element.Path))
                   throw new ConfigurationErrorsException(string.Format("当前名为{0}的配置项未定义模版路径", element.Key));
               if (string.IsNullOrEmpty(element.Caption))
                   element.Caption = element.Key;
               _namePathPair.Add(element.Key, element);
              
           }
           foreach (MedicalDocElement element in configurationSection.MedicalForms)
           {
               if (string.IsNullOrEmpty(element.Path))
                   throw new ConfigurationErrorsException(string.Format("当前名为{0}的配置项未定义模版路径", element.Key));
               if (string.IsNullOrEmpty(element.Caption))
                   element.Caption = element.Key;
               _nameFormPair.Add(element.Key, element);
           }
           foreach (MedicalDocElement element in configurationSection.CustomForms)
           {
               _nameCustomFormPair.Add(element.Key, element);
           }
       }
       /// <summary>
       /// 获取配置的医疗文书名称和模版路径
       /// </summary>
       /// <returns></returns>
       public static Dictionary<string, MedicalDocElement> GetMedicalDocNameAndPath()
       {
           return _namePathPair;
       }
       /// <summary>
       /// 获取普通界面设计文件名称和模版路径
       /// </summary>
       /// <returns></returns>
       public static Dictionary<string, MedicalDocElement> GetMedicalFormsNameAndPath()
       {
           return _nameFormPair;
       }
       /// <summary>
       /// 获取新增加的自定义界面配置
       /// </summary>
       /// <returns></returns>
       public static Dictionary<string, MedicalDocElement> GetCustomForms()
       {
           return _nameCustomFormPair;
       }
    }
}
