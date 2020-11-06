using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MedicalSystem.Anes.Document.Configurations
{
   public class MedicalDocElement : ConfigurationElement
    {
       /// <summary>
       /// 医疗文书的Key
       /// </summary>
       [ConfigurationProperty("key", IsRequired = true, Options = ConfigurationPropertyOptions.IsKey)]
       public string Key
       {
           get
           {
               return this["key"] as string;
           }
           set
           {
               this["key"] = value;
           }
       }
       /// <summary>
       /// 医疗文书的Key
       /// </summary>
       [ConfigurationProperty("caption", IsRequired = false)]
       public string Caption
       {
           get
           {
               return this["caption"] as string;
           }
           set
           {
               this["caption"] = value;
           }
       }
       /// <summary>
       ///模版文件相对路径
       /// </summary>
       [ConfigurationProperty("path",IsRequired=false)]
       public string Path
       {
           get
           {
               return this["path"] as string;
           }
           set
           {
               this["path"] = value;
           }
       }
       /// <summary>
       ///医疗文书类型
       /// </summary>
       [ConfigurationProperty("type", IsRequired = true)]
       public string Type
       {
           get
           {
               return this["type"] as string;
           }
           set
           {
               this["type"] = value;
           }
       }
    }
}
