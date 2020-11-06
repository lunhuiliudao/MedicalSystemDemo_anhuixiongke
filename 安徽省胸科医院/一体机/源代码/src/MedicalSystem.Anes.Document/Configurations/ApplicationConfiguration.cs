using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Drawing;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;
using System.Windows.Forms;
using System.IO;

namespace MedicalSystem.Anes.Document.Configurations
{
    public partial class ApplicationConfiguration
    {
        public class MedicalDocucementElement
        {
            private string _key;
            /// <summary>
            /// 医疗文书的Key
            /// </summary>
            public string Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    _key = value;
                }
            }

            private string _caption;
            /// <summary>
            /// 医疗文书的Key
            /// </summary>
            public string Caption
            {
                get
                {
                    return _caption;
                }
                set
                {
                    _caption = value;
                }
            }

            private string _path;
            /// <summary>
            ///模版文件相对路径
            /// </summary>
            public string Path
            {
                get
                {
                    return _path;
                }
                set
                {
                    _path = value;
                }
            }

            private string _type;
            /// <summary>
            ///医疗文书类型
            /// </summary>
            public string Type
            {
                get
                {
                    return _type;
                }
                set
                {
                    _type = value;
                }
            }

            public override string ToString()
            {
                return Caption + "," + Key + "," + Path + "," + Type;
            }
            static Dictionary<string, object> _configurCache = new Dictionary<string, object>();

            public static string GetFromConfigTable(string key)
            {
                //BusinessEntity.Configuration.ConfigTableDataTable configTable = ExtendApplicationContext.Current.ConfigTable;
                //if (!string.IsNullOrEmpty(key) && configTable != null)
                //{
                //    BusinessEntity.Configuration.ConfigTableRow configRow = configTable.FindByParaKey(key);
                //    if (configRow != null && configRow.ParaValue[0] != 0)
                //    {
                //        string ret = StringHelper.Arr2Str(configRow.ParaValue);
                //        if (ret == "�") ret = string.Empty;
                //        return ret;
                //    }
                //    else
                //    {
                //        return string.Empty;
                //    }
                //}
                return "";
            }

            /// <summary>
            /// 麻醉单每页显示的小时数
            /// </summary>
            public static int AnesDocPageHours
            {
                get
                {
                    string key = "AnesDocPageHours";
                    if (_configurCache.ContainsKey(key))
                        return Convert.ToInt32(_configurCache[key].ToString());

                    int text = Convert.ToInt32(ConfigurationManager.AppSettings[key]);
                    if (string.IsNullOrEmpty(text.ToString()))
                    {
                        text = Convert.ToInt32(GetFromConfigTable(key));
                    }
                    if (!string.IsNullOrEmpty(text.ToString()))
                    {
                        _configurCache[key] = text;
                        return text;
                    }
                    else
                    {
                        _configurCache[key] = 5;
                        return 5;
                    }
                }
                set
                {
                    //ModifyConfigTable("OpertionDeptCode", value);
                    string key = "AnesDocPageHours";
                    if (_configurCache.ContainsKey(key))
                        _configurCache[key] = value;
                    ConfigurationHelper.Save("AnesDocPageHours", value.ToString());
                }
            }


            
            public void FromList(List<string> list)
            {
                if (list.Count == 4 || list.Count == 5)
                {
                    Caption = list[0];
                    Key = list[1];
                    Path = list[2];
                    if (list.Count == 4)
                    {
                        Type = list[3];
                    }
                    else
                    {
                        Type = list[3] + "," + list[4];
                    }
                }
            }
        } 
    }
}
