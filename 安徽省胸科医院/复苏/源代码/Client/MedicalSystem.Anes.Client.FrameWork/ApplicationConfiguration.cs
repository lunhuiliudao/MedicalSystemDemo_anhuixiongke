using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MedicalSystem.Anes.Document.Configurations;
using System.Configuration;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class ApplicationConfiguration
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
        /// <summary>
        /// 持续用药自动结束
        /// </summary>
        public static bool DrugAutoStop
        {
            get
            {
                string key = "DrugAutoStop";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    bool ret = false;
                    if (!bool.TryParse(text, out ret))
                    {
                        ret = false;
                    }
                    return ret;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DrugAutoStop", value.ToString());
            }
        }


        /// <summary>
        /// 文书是否双击显示下拉
        /// </summary>
        public static bool DoubleSelect
        {
            get
            {
                bool tempResult = true;
                string key = "DoubleSelect";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!bool.TryParse(text, out tempResult))
                {
                    tempResult = false;
                }

                return tempResult;
            }
            set
            {
                string key = "DoubleSelect";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
            }
        }

        /// <summary>
        /// 是否手术过程中完成三方核查单
        /// </summary>
        public static bool IsVerificationAudit
        {
            get
            {
                string key = "IsVerificationAudit";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    bool ret = false;
                    if (!bool.TryParse(text, out ret))
                    {
                        ret = false;
                    }
                    return ret;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsVerificationAudit", value.ToString());
            }
        }
        public static string ApplicationVision
        {
            get { return "ANES6"; }
            set { }
        }
        /// <summary>
        /// 持续用药自动结束时的手术状态
        /// </summary>
        public static string DrugAutoStopOperationStatus
        {
            get
            {
                string key = "DrugAutoStopOperationStatus";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {

                    return text;
                }
                else
                {
                    return "出手术室";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DrugAutoStopOperationStatus", value.ToString());
            }
        }
        /// <summary>
        /// 诱导室名称
        /// </summary>
        public static string YouDaoRoomTitle
        {
            get
            {
                return "诱导室";
            }
            set
            {
            }
        }
        public static int DrugShow
        {
            get
            {
                string key = "DrugShow";

                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationManager.AppSettings[key];
                }
                int ret = 0;
                if (!int.TryParse(s, out ret))
                {
                    ret = 0;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "DrugShow";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        public static int ProLonged
        {
            get
            {
                string key = "ProLonged";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToInt32(_configurCache[key]);

                string s = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationManager.AppSettings[key];
                }
                int ret = 0;
                if (!int.TryParse(s, out ret))
                {
                    ret = 0;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, ret);

                return ret;
            }
            set
            {
                string key = "ProLonged";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }

        }

        public static Color YouDaoColor
        {
            get
            {
                return Color.Black;
            }
            set
            {
            }
        }
        /// <summary>
        /// 标记修改过的体征项
        /// </summary>
        public static bool IsModifyVitalSignShowDifferent
        {
            get
            {
                string text = ConfigurationHelper.Read("IsModifyVitalSignShowDifferent");
                bool result = false;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsModifyVitalSignShowDifferent", value.ToString());
            }
        }
        public static string GetAppSetting(string key)
        {
            return "";
        }
        /// <summary>
        /// 默认体征项目
        /// </summary>
        public static string DefaultMonitorItems
        {
            get
            {
                return "";
            }
            set
            {
                //string key = "DefaultMonitorItems";
            }
        }
        /// <summary>
        /// 麻醉医生开始交班时间
        /// </summary>
        public static string AnesShiftOperationStatus
        {
            get
            {
                return "麻醉开始";
            }
            set
            {

            }
        }
        /// <summary>
        /// 护士开始交班时间
        /// </summary>
        public static string NurseShiftOperationStatus
        {
            get
            {
                return "手术开始";
            }
            set
            {

            }
        }
        /// <summary>
        /// 刷新时间间隔
        /// </summary>
        public static int RefreshTimeSpan
        {
            get
            {
                return 120;
            }
            set
            {

            }
        }
        public static MedicalDocucementElement GetMedicalDocument(string documentName)
        {
            MedicalDocucementElement medicalDocElement = new MedicalDocucementElement();
            string key = "MedicalDocument." + documentName;
            string text = ApplicationConfiguration.GetFromConfigTable(key);
            if (!string.IsNullOrEmpty(text))
            {
                List<string> list = new List<string>(text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                medicalDocElement.FromList(list);
            }
            else
            {
                List<string> list = new List<string>();
                Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();
                foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                {
                    if (keyValuePair.Key.Trim() == documentName.Trim())
                    {
                        medicalDocElement.Caption = keyValuePair.Value.Caption;
                        medicalDocElement.Key = keyValuePair.Value.Key;
                        medicalDocElement.Path = keyValuePair.Value.Path;
                        medicalDocElement.Type = keyValuePair.Value.Type;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(medicalDocElement.Key))
                {
                    docKeyValuePairs = MedicalDocSettings.GetMedicalFormsNameAndPath();
                    foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                    {
                        if (keyValuePair.Key.Trim() == documentName.Trim())
                        {
                            medicalDocElement.Caption = keyValuePair.Value.Caption;
                            medicalDocElement.Key = keyValuePair.Value.Key;
                            medicalDocElement.Path = keyValuePair.Value.Path;
                            medicalDocElement.Type = keyValuePair.Value.Type;
                            break;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(medicalDocElement.Key))
            {
                medicalDocElement.Key = documentName;
            }
            return medicalDocElement;
        }
        public static string GetFromConfigTable(string key)
        {
            var configTable = ExtendApplicationContext.Current.CommDict.ConfigDict;// ;
            if (!string.IsNullOrEmpty(key) && configTable != null)
            {
                var configRow = configTable.FirstOrDefault(x => x.PARAKEY == key);
                if (configRow != null && configRow.PARAVALUE != null && configRow.PARAVALUE.Length != 0)
                {
                    string ret = StringHelper.Arr2Str(configRow.PARAVALUE);
                    if (ret == "�") ret = string.Empty;
                    return ret;
                }
                else
                {
                    return string.Empty;
                }
            }
            return null;
        }
        public static void ModifyConfigTable(string key, string value)
        {
            if (!string.IsNullOrEmpty(key))
            {
                List<MED_CONFIG> configList = ExtendApplicationContext.Current.CommDict.ConfigDict;
                configList = configList.Where(x => x.PARAKEY == key).ToList();
                MED_CONFIG configRow = null;
                if (configList != null && configList.Count > 0)
                {
                    configRow = configList[0];
                }
                if (configRow == null)
                {
                    configRow = new MED_CONFIG();
                    configRow.PARAKEY = key;
                    ExtendApplicationContext.Current.CommDict.ConfigDict.Add(configRow);
                }
                if (string.IsNullOrEmpty(value))
                {
                    configRow.PARAVALUE = new byte[] { 0 };
                }
                else
                {
                    configRow.PARAVALUE = StringHelper.Str2Arr(value);
                }
            }
        }


        public static string InRoomDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("InRoomDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("InRoomDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string AnesthesiaStartDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("AnesthesiaStartDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaStartDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OperationStartDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("OperationStartDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OperationStartDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OperationEndDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单,麻醉总结单";
                }
                else
                {
                    string key = GetAppTypeKey("OperationEndDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OperationEndDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaEndDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单,麻醉总结单";
                }
                else
                {
                    string key = GetAppTypeKey("AnesthesiaEndDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaEndDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutRoomDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单,麻醉总结单";
                }
                else
                {
                    string key = GetAppTypeKey("OutRoomDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OutRoomDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InPACUDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "复苏单";
                }
                else
                {
                    string key = GetAppTypeKey("InPACUDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("InPACUDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToPACUDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "复苏单";
                }
                else
                {
                    string key = GetAppTypeKey("TurnToPACUDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("TurnToPACUDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToSickRoomDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("TurnToSickRoomDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("TurnToSickRoomDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutPACUocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "";
                }
                else
                {
                    string key = GetAppTypeKey("OutPACUocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("OutPACUocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToPACUActions
        {
            get
            {
                string key = GetAppTypeKey("TurnToPACUActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("TurnToPACUActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string TurnToSickRoomActions
        {
            get
            {
                string key = GetAppTypeKey("TurnToSickRoomActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("TurnToSickRoomActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string InRoomActions
        {
            get
            {
                string key = GetAppTypeKey("InRoomActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    //text = ConfigurationHelper.Read(key);
                    text = "设备采集,麻醉记录单";
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("InRoomActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaStartActions
        {
            get
            {
                string key = GetAppTypeKey("AnesthesiaStartActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaStartActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OperationStartActions
        {
            get
            {
                string key = GetAppTypeKey("OperationStartActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OperationStartActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OperationEndActions
        {
            get
            {
                string key = GetAppTypeKey("OperationEndActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OperationEndActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaEndActions
        {
            get
            {
                string key = GetAppTypeKey("AnesthesiaEndActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaEndActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutRoomActions
        {
            get
            {
                string key = GetAppTypeKey("OutRoomActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutRoomActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InPACUActions
        {
            get
            {
                string key = GetAppTypeKey("InPACUActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("InPACUActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutPACUActions
        {
            get
            {
                string key = GetAppTypeKey("OutPACUActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutPACUActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InYouDaoActions
        {
            get
            {
                string key = GetAppTypeKey("InYouDaoActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("InYouDaoActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string IsReadyActions
        {
            get
            {
                string key = GetAppTypeKey("IsReadyActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("IsReadyActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutYouDaoActions
        {
            get
            {
                string key = GetAppTypeKey("OutYouDaoActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutYouDaoActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string DoneActions
        {
            get
            {
                string key = GetAppTypeKey("DoneActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("DoneActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string InYouDaoDocuments
        {
            get
            {
                string key = GetAppTypeKey("InYouDaoDocuments");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("InYouDaoDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string IsReadyDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "同意书,术前访视单";
                }
                else
                {
                    string key = GetAppTypeKey("IsReadyDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsReadyDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }


        public static string TurnToICUDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "同意书,术前访视单";
                }
                else
                {
                    string key = GetAppTypeKey("TurnToICUDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("TurnToICUDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string OutYouDaoDocuments
        {
            get
            {
                string key = GetAppTypeKey("OutYouDaoDocuments");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("OutYouDaoDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string DoneDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "同意书,术前访视单,麻醉单,麻醉总结单,术后随访单";
                }
                else
                {
                    string key = GetAppTypeKey("DoneDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("DoneDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static bool AutoGenDocument
        {
            get
            {
                string key = "AutoGenDocument";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AutoGenDocument", value.ToString());
            }
        }
        public static string NoPatientDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("NoPatientDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("NoPatientDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string PeroperativePatientDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("PeroperativePatientDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        string[] buttons = ApplicationConfiguration.PeroperativePatientButtons.Split(new char[] { ';' }, StringSplitOptions.None);
                        text = buttons[1];
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("PeroperativePatientDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaRecordDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单";
                }
                else
                {
                    string key = GetAppTypeKey("AnesthesiaRecordDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        string[] buttons = ApplicationConfiguration.AnesthesiaRecordButtons.Split(new char[] { ';' }, StringSplitOptions.None);
                        text = buttons[1];
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaRecordDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string PACURecordEndDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单,麻醉总结单";
                }
                else
                {
                    string key = GetAppTypeKey("PACURecordEndDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        string[] buttons = ApplicationConfiguration.PACUButtons.Split(new char[] { ';' }, StringSplitOptions.None);
                        text = buttons[1];
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("PACURecordEndDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string CPBReportDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单,麻醉总结单";
                }
                else
                {
                    string key = GetAppTypeKey("CPBReportDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        text = ConfigurationHelper.Read(key);
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("CPBReportDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string PostoperativePatientDocuments
        {
            get
            {
                if (AutoGenDocument)
                {
                    return "术前访视单,麻醉单,麻醉总结单";
                }
                else
                {
                    string key = GetAppTypeKey("PostoperativePatientDocuments");
                    string text = ApplicationConfiguration.GetFromConfigTable(key);
                    if (string.IsNullOrEmpty(text))
                    {
                        string[] buttons = ApplicationConfiguration.PostoperativePatientButtons.Split(new char[] { ';' }, StringSplitOptions.None);
                        text = buttons[1];
                    }
                    return text;
                }
            }
            set
            {
                string key = GetAppTypeKey("PostoperativePatientDocuments");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string NoPatientActions
        {
            get
            {
                string key = GetAppTypeKey("NoPatientActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("NoPatientActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string PeroperativePatientActions
        {
            get
            {
                string key = GetAppTypeKey("PeroperativePatientActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "术前访视";
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("PeroperativePatientActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesthesiaRecordActions
        {
            get
            {
                string key = GetAppTypeKey("AnesthesiaRecordActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "麻醉记录单,设备采集";
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("AnesthesiaRecordActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string PACURecordActions
        {
            get
            {
                string key = GetAppTypeKey("PACURecordActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "复苏记录单,设备采集";
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("PACURecordActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string CPBReportActions
        {
            get
            {
                string key = GetAppTypeKey("CPBReportActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("CPBReportActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string PostoperativePatientActions
        {
            get
            {
                string key = GetAppTypeKey("PostoperativePatientActions");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "术后访视";
                }
                return text;
            }
            set
            {
                string key = GetAppTypeKey("PostoperativePatientActions");
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        /// <summary>
        /// 是否复苏管理程序
        /// </summary>
        public static bool IsPACUProgram
        {
            get
            {
                string key = "IsPACUProgram";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsPACUProgram", value.ToString());
            }
        }
        /// <summary>
        /// 办公模式 0-手术间模式；1-办公室模式;
        /// </summary>
        public static string ApplicationPatterns
        {
            get
            {
                string key = "ApplicationPatterns";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text)) text = "0";
                return text;
            }
            set
            {
                ModifyConfigTable("ApplicationPatterns", value);
            }
        }
        /// <summary>
        /// 是否诱导室管理程序
        /// </summary>
        public static bool IsYouDaoProgram
        {
            get
            {
                string key = "IsYouDaoProgram";
                string text = ConfigurationHelper.Read(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsYouDaoProgram", value.ToString());
            }
        }
        public static bool ShowYouDao
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("ShowYouDao"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("ShowYouDao", value.ToString());
            }
        }
        public static string AppTitle
        {
            get
            {
                string text = GetAppTitleDefault();
                return text;
            }
            set
            {
                string key = GetAppTitleKey();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string AnesDocName
        {
            get
            {
                return "麻醉单";
            }
            set
            {
            }
        }
        public static string CustomSettingProvider
        {
            get
            {
                string key = "CustomSettingProvider";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                ModifyConfigTable("CustomSettingProvider", value);
            }
        }
        public static string NoPatientButtons
        {
            get
            {
                string[] buttons = new string[] { ""
                    , "", "字典,HIS同步,查询统计,急诊登记,麻醉评分,手术概览,模板管理,系统配置,修改密码,锁定系统,关于" };
                string key = "NoPatientButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "NoPatientButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string PatientStatusButtons
        {
            get
            {
                string key = GetPatientStatusButtonsKey();
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = GetPatientStatusButtonsDefault();
                }
                if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
                {
                    text = GetPatientStatusButtonsDefault();
                }
                else if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.YouDao))
                {
                    text = GetPatientStatusButtonsDefault();
                }
                return text;
            }
            set
            {
                string key = GetPatientStatusButtonsKey();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        private static string GetPatientStatusButtonsDefault()
        {
            string text = "入手术室,麻醉开始,手术开始,手术结束,麻醉结束,出手术室";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    text = "入诱导室,出诱导室";
                    break;
                case ApplicationType.PACU:
                    text = "入复苏室, 出复苏室";
                    break;
                case ApplicationType.OperationSchedule:
                    text = "";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    text = "";
                    break;
                case ApplicationType.Nurse:
                    text = "";
                    break;
                case ApplicationType.Director:
                    text = "";
                    break;
            }
            return text;
        }
        private static string GetPatientStatusButtonsKey()
        {
            string key = "PatientStatusButtons";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YouDaoPatientStatusButtons";
                    break;
                case ApplicationType.PACU:
                    key = "PACUPatientStatusButtons";
                    break;
                case ApplicationType.Nurse:
                    key = "NursePatientStatusButtons";
                    break;
                case ApplicationType.Director:
                    key = "DirectorPatientStatusButtons";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperSchePatientStatusButtons";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBStatusButtons";
                    break;
            }
            return key;
        }
        private static string GetAppTitleDefault()
        {
            string text = "DoCare麻醉临床信息系统";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    text = "DoCare麻醉临床信息系统—诱导管理子系统";
                    break;
                case ApplicationType.PACU:
                    text = "DoCare麻醉临床信息系统V—复苏子系统";
                    break;
                case ApplicationType.OperationSchedule:
                    text = "DoCare麻醉临床信息系统V—排班子系统";
                    break;
                case ApplicationType.Nurse:
                    text = "DoCare手术护理工作站";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    text = "DoCare体外循环临床信息系统";
                    break;
                case ApplicationType.Director:
                    text = "DoCare麻醉科主任工作站";
                    break;
            }
            return text;
        }
        private static string GetAppTitleKey()
        {
            string key = "AppTitle";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YouDaoTitle";
                    break;
                case ApplicationType.PACU:
                    key = "PACUAppTitle";
                    break;
                case ApplicationType.Nurse:
                    key = "NurseAppTitle";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperScheAppTitle";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBAppTitle";
                    break;
                case ApplicationType.Director:
                    key = "DirectorAppTitle";
                    break;
            }
            return key;
        }
        private static string GetAppTypeKey(string initKey)
        {
            string prefix = "";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.CardiopulmonaryBypass:
                    prefix = "CPB";
                    break;
                case ApplicationType.Nurse:
                    prefix = "Nurse";
                    break;
                case ApplicationType.Director:
                    prefix = "Director";
                    break;
                default:
                    break;
            }
            return prefix + initKey;
        }
        private static string GetNoPatientButtonsKey()
        {
            string key = "NoPatientButtons";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YaoDaoNoPatientButtons";
                    break;
                case ApplicationType.PACU:
                    key = "PACUNoPatientButtons";
                    break;
                case ApplicationType.Nurse:
                    key = "NurseNoPatientButtons";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperScheNoPatientButtons";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBNoPatientButtons";
                    break;
                case ApplicationType.Director:
                    key = "DirectorNoPatientButtons";
                    break;
            }
            return key;
        }
        private static string GetNoPatientButtonsDefault()
        {
            string text = string.Join(";", new string[] { "字典", "HIS同步", "查询统计", "急诊登记", "麻醉评分", "手术概览", "模板管理", "系统配置", "修改密码", "锁定系统", "关于" });
            return text;
        }
        private static string GetSelectPatientButtonsKey()
        {
            string key = "SelectPatientButtons";
            switch (ExtendApplicationContext.Current.AppType)
            {
                case ApplicationType.YouDao:
                    key = "YouDaoSelectPatientButtons";
                    break;
                case ApplicationType.PACU:
                    key = "PACUSelectPatientButtons";
                    break;
                case ApplicationType.Nurse:
                    key = "NurseSelectPatientButtons";
                    break;
                case ApplicationType.OperationSchedule:
                    key = "OperScheSelectPatientButtons";
                    break;
                case ApplicationType.CardiopulmonaryBypass:
                    key = "CPBSelectPatientButtons";
                    break;
                case ApplicationType.Director:
                    key = "DirectorSelectPatientButtons";
                    break;
            }
            return key;
        }
        public static string MedicalRecordButtons
        {
            get
            {
                string[] buttons = new string[] { "检验信息", "检查结果", "医嘱信息", "病历病程" };
                string key = "MedicalRecordButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "MedicalRecordButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }

        }
        public static string OperationDuringButtons
        {
            get
            {
                string[] buttons = new string[] { "设备采集", "手术信息", "术后登记", "取消手术", "病案提交" };
                string key = "OperationDuringButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "OperationDuringButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string AnesthesiaRecordButtons
        {
            get
            {
                string[] buttons = new string[] { "检验信息,检查结果,医嘱信息,病历病程"
                    , "麻醉记录单,术前访视,安全核查表,麻醉计划,复苏记录单,恢复室记录单,麻醉同意书,术后随访,镇痛观察,镇痛记录单,麻醉总结单,手术清点单,手术风险评估单", "设备采集,手术信息,麻醉交班,护士交班,手术交班,术后登记,取消手术,病案提交" };
                string key = "AnesthesiaRecordButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "AnesthesiaRecordButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string PACUButtons
        {
            get
            {
                string[] buttons = new string[] { "检验信息,检查结果,医嘱信息,病历病程"
                    , "麻醉记录单,患者交接单,复苏记录单", "家属通告" };
                //string key = "PACUButtons";
                string text = "";// ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "PACUButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string PeroperativePatientButtons
        {
            get
            {
                string[] buttons = new string[] { "检验信息,检查结果,医嘱信息,病历病程"
                    , "麻醉记录单,患者交接单,复苏记录单", "家属通告" };
                string key = "PeroperativePatientButtons";
                string text = "";// ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "PeroperativePatientButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string PostoperativePatientButtons
        {
            get
            {
                string[] buttons = new string[] { "检验信息,检查结果,医嘱信息,病历病程"
                    , "麻醉记录单,患者交接单,复苏记录单", "家属通告" };
                string key = "PostoperativePatientButtons";
                string text = "";// ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "PostoperativePatientButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static string CPBReportButtons
        {
            get
            {
                string[] buttons = new string[]  {"事  件,输  液,输  血,用  药,灌  注,出  液,其  他", "", "手术信息,转前检查,预充信息,穿刺管理,转中登记,采集数据,血气分析,灌注总结"
                , "锁定系统,血流动力,仪器设置,字    典,模板管理","", "系统配置,关    于" };
                string key = "CPBReportButtons";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(";", buttons);
                }
                return text;
            }
            set
            {
                string key = "CPBReportButtons";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string AnesEventButtons
        {
            get
            {
                string[] buttons = new string[] { "麻药", "用药", "事件", "输液", "出量", "插管", "拔管", "输血", "输氧", "呼吸", "诱导", "其他" };//{ "输血", "输液","麻药", "吸入麻药", "局部麻药","静脉麻药", "事件", "用药", "输氧",  "呼吸", "插管",  "拔管", "诱导" , "其他"};
                string key = "AnesEventButtons" + ExtendApplicationContext.Current.EventNo.ToString();
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = string.Join(",", buttons);
                }
                if (!ShowYouDao)
                {
                    text = text.Replace("诱导,", "").Replace(",诱导", "");
                }
                return text;
            }
            set
            {
                string key = "AnesEventButtons" + ExtendApplicationContext.Current.EventNo.ToString();
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string LiquidAttrs
        {
            get
            {
                string[] buttons = new string[] { "晶体", "胶体", "其他" };
                string text = ConfigurationHelper.Read("LiquidAttrs");
                if (string.IsNullOrEmpty(text))
                {
                    text = "晶体,胶体,其他";
                }
                return text;
            }
            set
            {
                ConfigurationHelper.Save("LiquidAttrs", value);
            }
        }

        public static int DosageButtonsCount
        {
            get
            {
                return 4;
                //string key = "DosageButtonsCount";
                //if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
                //{
                //    key = "CPBDosageButtonsCount";
                //}
                //string s = GetFromServer(key);
                //dosageButtonsCount=string.IsNullOrEmpty(s)?0:int.Parse(s);
                //if (dosageButtonsCount == 0 || dosageButtonsCount>15)
                //{
                //    dosageButtonsCount = 4;
                //}
                //return Configurations.dosageButtonsCount; 
            }
            set
            {
                //string key = "DosageButtonsCount";
                //if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
                //{
                //    key = "CPBDosageButtonsCount";
                //}
                //Configurations.dosageButtonsCount = value;
                //ApplicationConfiguration.ModifyConfigTable(key, dosageButtonsCount.ToString());
            }
        }
        public static string PermissionProvider
        {
            get
            {
                string key = "PermissionProvider";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                ModifyConfigTable("PermissionProvider", value);
            }
        }
        public static string BloodGasTempletNames
        {
            get
            {
                string key = "BloodGasTempletNames";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = "BloodGasTempletNames";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        public static bool DisplayLastMonitorData
        {
            get
            {
                string key = "DisplayLastMonitorData";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DisplayLastMonitorData", value.ToString());
            }
        }

        public static bool AllRights
        {
            get
            {
                string key = "AllRights";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AllRights", value.ToString());
            }
        }

        /// <summary>
        /// 开启同步
        /// </summary>
        public static bool SyncOpen
        {
            get
            {
                string key = "SyncOpen";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("SyncOpen", value.ToString());
            }
        }

        public static bool CheckDictInput
        {
            get
            {
                string key = "CheckDictInput";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("CheckDictInput", value.ToString());
            }
        }

        /// <summary>
        /// 密码类型
        /// </summary>
        public enum PassWordTypes
        {
            UpCase,
            CaseSensitive,
            LowCase,
        }

        public static PassWordTypes PassWordType
        {
            get
            {
                PassWordTypes passWordType = PassWordTypes.UpCase;
                //string key = "PassWordType";
                //string text = GetFromServer(key);
                //if (string.IsNullOrEmpty(text))
                //{
                //    text = ConfigurationHelper.Read(key);
                //}
                //if (!string.IsNullOrEmpty(text))
                //{
                //    object obj = Enum.Parse(typeof(PassWordTypes), text);
                //    if (obj != null && obj is PassWordTypes)
                //    {
                //        passWordType = (PassWordTypes)obj;
                //    }
                //}
                return passWordType;
            }
            set
            {
                //ApplicationConfiguration.ModifyConfigTable("PassWordType", value.ToString());
            }
        }
        public static string CustomDllName
        {
            get
            {
                string key = "CustomDllName";
                string text = GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "";
                }
                return text;
            }
            set
            {
                ModifyConfigTable("CustomDllName", value);
                //ConfigurationHelper.Save("CustomSettingProvider", value.ToString());
            }
        }

        public static List<string> MedicalDocumentList
        {
            get
            {
                string key = "MedicalDocumentList";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!string.IsNullOrEmpty(text))
                {
                    return new List<string>(text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    List<string> list = new List<string>();
                    Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();
                    foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                    {
                        list.Add(keyValuePair.Key);
                    }
                    return list;
                }
            }
            set
            {
                string key = "MedicalDocumentList";
                ApplicationConfiguration.ModifyConfigTable(key, string.Join(",", value.ToArray()));
            }
        }

        public static bool IsConnACS
        {
            get
            {
                bool result;
                if (bool.TryParse(ConfigurationHelper.Read("IsConnACS"), out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ConfigurationHelper.Save("IsConnACS", value.ToString());
            }
        }

        public static string AcsAddress
        {
            get
            {
                string startAcsAddress = ConfigurationHelper.Read("AcsAddress");
                if (string.IsNullOrEmpty(startAcsAddress)) startAcsAddress = "..";
                return startAcsAddress;
            }
            set
            {
                ConfigurationHelper.Save("AcsAddress", value.ToString());
            }
        }

        /// <summary>
        /// 麻醉单单页时间长度
        /// </summary>
        public static int AnesDocRange
        {
            get
            {
                string key = "AnesDocRange";
                string text = ConfigurationHelper.Read("AnesDocRange");
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 5;
                    }
                    if (ret <= 0)
                        ret = 5;
                    return ret;
                }
                else
                {

                    return 5;
                }
            }
            set
            {
                ConfigurationHelper.Save("AnesDocRange", value.ToString());
            }
        }

        /// <summary>
        /// PACU单单页时间长度
        /// </summary>
        public static int PACUDocRange
        {
            get
            {
                string key = "PACUDocRange";
                string text = ConfigurationHelper.Read("PACUDocRange");
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 4;
                    }
                    if (ret <= 0)
                        ret = 4;
                    return ret;
                }
                else
                {
                    return 4;
                }
            }
            set
            {
                ConfigurationHelper.Save("PACUDocRange", value.ToString());
            }
        }

        public static bool IsShowUnDonePatientList
        {

            get
            {
                string key = "IsShowUnDonePatientList";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {


                ApplicationConfiguration.ModifyConfigTable("IsShowUnDonePatientList", value.ToString());

            }
        }

        /// <summary>
        /// 是否启用PACU管理
        /// </summary>
        public static bool IsPACUProcess
        {
            get
            {
                string key = GetAppTypeKey("IsPACUProcess");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsPACUProcess");
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }

        static Dictionary<string, object> _configurCache = new Dictionary<string, object>();

        /// <summary>
        /// 合并所有采集数据
        /// </summary>
        public static bool MergeMonitorData
        {
            get
            {
                string key = "MergeMonitorData";
                if (_configurCache.ContainsKey(key))
                    return Convert.ToBoolean(_configurCache[key]);

                string s = GetFromConfigTable(key);

                bool result;
                if (!bool.TryParse(s, out result))
                {
                    result = false;
                }

                if (!_configurCache.ContainsKey(key))
                    _configurCache.Add(key, result);

                return result;
            }
            set
            {
                string key = "MergeMonitorData";
                ModifyConfigTable(key, value.ToString());
                if (_configurCache.ContainsKey(key))
                    _configurCache[key] = value;
            }
        }

        /// <summary>
        /// 显示主界面状态栏
        /// </summary>
        public static bool ShowDocumentScrollBar
        {
            get
            {
                string key = "ShowDocumentScrollBar";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    return true;
                }
                else
                {
                    bool result;
                    if (bool.TryParse(text, out result))
                    {
                        return result;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("ShowDocumentScrollBar", value.ToString());
            }
        }

        public static bool UseDefaultOperatingRoom
        {
            get
            {
                string key = "UseDefaultOperatingRoom";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    return false;
                }
                else
                {
                    bool result;
                    if (bool.TryParse(text, out result))
                    {
                        return result;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("UseDefaultOperatingRoom", value.ToString());
            }
        }

        /// <summary>
        /// joysola 用于获取“用药显示”的字符串(和名字并不对应)
        /// </summary>
        public static string PassedDrugPointFormat
        {
            get
            {
                string key = "DrugShow";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    //text = ConfigurationHelper.Read(key);
                    // 默认给一个初始值       剂量  剂量单位 ( 流速  流速单位 + 浓度  浓度单位 ) 用药途径  途径换行 
                    text = "DOSAGE,DOSAGE_UNITS,(,PERFORM_SPEED,SPEED_UNIT,+,CONCENTRATION,CONCENTRATION_UNIT,C3,ADMINISTRATOR,)";


                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DrugShow", value.ToString());
            }
        }

        /// <summary>
        /// joysola 用于获取“持续用药显示”的字符串(和名字并不对应)
        /// </summary>
        public static string PassedDrugProLongedFormat
        {
            get
            {
                string key = "ProLonged";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    //text = ConfigurationHelper.Read(key);
                    // 默认给一个初始值       剂量  剂量单位 ( 流速  流速单位 + 浓度  浓度单位 ) 用药途径  途径换行 
                    text = "DOSAGE,DOSAGE_UNITS,(,PERFORM_SPEED,SPEED_UNIT,+,CONCENTRATION,CONCENTRATION_UNIT,C3,ADMINISTRATOR,)";


                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("ProLonged", value.ToString());
            }
        }

        /// <summary>
        /// joysola 用于获取“用药名称显示”字符串（名字不统一）
        /// </summary>
        public static string PassedDrugNameFormat
        {
            get
            {
                string key = "DrugLegend";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    //text = ConfigurationHelper.Read(key);
                    // 默认给一个初始值         药名 ( 剂量单位 )
                    text = "EVENT_ITEM_NAME,(,DOSAGE_UNITS,),,,,,,,,,";

                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("DrugLegend", value.ToString());
            }
        }


        /// <summary>
        /// joysola 用于获取“输液输血显示格式”的字符串
        /// </summary>
        public static string PassedInLiquidInBloodFormat
        {
            get
            {
                string key = "BloodLiquidShow";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    //text = ConfigurationHelper.Read(key);
                    // 默认初始值 输血3行
                    text = "BloodInThree";
                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("BloodLiquidShow", value.ToString());
            }
        }

        /// <summary>
        /// 是否更新排班程序状态
        /// </summary>
        public static bool IsUpdateScheduleStatus
        {
            get
            {
                string key = GetAppTypeKey("IsUpdateScheduleStatus");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsUpdateScheduleStatus");
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }
        /// <summary>
        /// 是否更新HIS手术状态
        /// </summary>
        public static bool IsUpdateHisStatus
        {
            get
            {
                string key = "IsUpdateHisStatus";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsUpdateHisStatus");
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }
        /// <summary>
        /// 是否回传麻醉收费信息
        /// </summary>
        public static bool IsUpdateAnesCharge
        {
            get
            {
                string key = GetAppTypeKey("IsUpdateAnesCharge");
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = GetAppTypeKey("IsUpdateAnesCharge");
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }
        public static string GetCustomConfig(string key)
        {
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetCustomForms();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == key)
                {
                    return keyValuePair.Value.Type;
                }
            }
            return "";
        }

        /// <summary>
        /// 麻醉编号
        /// </summary>
        public static int AnesthesiaNumber
        {
            get
            {
                string key = "AnesthesiaNumber";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 120000;
                    }
                    return ret;
                }
                else
                {
                    return 120000;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("AnesthesiaNumber", value.ToString());
            }
        }

        /// <summary>
        /// 手术申请同步方式
        /// </summary>
        public static int SyncScheduleInfoMode
        {
            get
            {
                string key = "SyncScheduleInfoMode";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 0;
                    }
                    return ret;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("SyncScheduleInfoMode", value.ToString());
            }
        }

        /// <summary>
        /// 手术申请时间同步时时间差
        /// </summary>
        public static int SyncDateDiff
        {
            get
            {
                string key = "SyncDateDiff";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    int ret = 0;
                    if (!int.TryParse(text, out ret))
                    {
                        ret = 3;
                    }
                    return ret;
                }
                else
                {
                    return 3;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("SyncDateDiff", value.ToString());
            }
        }
        /// PDFLocalUrl
        /// </summary>
        public static string PDFLocalUrl
        {
            get
            {
                string key = "PDFLocalUrl";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return @"D:\PDF\";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PDF_LocalUrl", value);
            }
        }

        /// <summary>
        /// 打印纸张
        /// </summary>
        public static string PDFServerUrl
        {
            get
            {
                string key = "PDFServerUrl";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "192.168.0.241";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PDF_ServerUrl", value);
            }
        }
        public static bool IsDeleteAfterCommitDoc
        {
            get
            {
                string key = "IsDeleteAfterCommitDoc";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsDeleteAfterCommitDoc", value.ToString());
            }
        }

        public static string PostPDF_Names
        {
            get
            {
                string key = "PostPDF_Names";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = "PostPDF_Names";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }
        /// <summary>
        /// 是否支持自动归档
        /// </summary>
        public static bool IsAutomaticArchiving
        {
            get
            {
                string key = "IsAutomaticArchiving";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                bool result;
                if (bool.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("IsAutomaticArchiving", value.ToString());
            }
        }

        /// <summary>
        /// 自动归档期限
        /// </summary>
        public static int ArchivOperAfterDay
        {
            get
            {
                string key = "ArchivOperAfterDay";
                string text = ConfigurationHelper.Read(key);
                int result;
                if (int.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return 30;
                }
            }
            set
            {
                ConfigurationHelper.Save("ArchivOperAfterDay", value.ToString());
            }
        }
        /// <summary>
        /// 文书完整性检查清单
        /// </summary>
        public static string DocNameCheckList
        {
            get
            {
                string key = "DocNameCheckList";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                return text;
            }
            set
            {
                string key = "DocNameCheckList";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        /// <summary>
        /// 打印纸张
        /// </summary>
        public static string PrintPageName
        {
            get
            {
                string key = "PrintPageName";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "A4";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PrintPageName", value);
            }
        }

        /// <summary>
        /// 打印纸张 长度
        /// </summary>
        public static float PrintPaperHeight
        {
            get
            {
                string key = "PrintPaperHeight";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 0;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 29.7f;
                    }
                    return ret;
                }
                else
                {
                    return 29.7f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PrintPaperHeight", value.ToString());
            }
        }

        /// <summary>
        /// 打印纸张  宽度
        /// </summary>
        public static float PrintPaperWidth
        {
            get
            {
                string key = "PrintPaperWidth";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 0;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 21.0f;
                    }
                    return ret;
                }
                else
                {
                    return 21.0f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PrintPaperWidth", value.ToString());
            }
        }
        /// <summary>
        /// 打印纸张  左侧预留
        /// </summary>
        public static float PaperLeftOff
        {
            get
            {
                string key = "PaperLeftOff";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 0.5f;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 0.5f;
                    }
                    return ret;
                }
                else
                {
                    return 0.5f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PaperLeftOff", value.ToString());
            }
        }
        /// <summary>
        /// 打印纸张 上方预留
        /// </summary>
        public static float PaperTopOff
        {
            get
            {
                string key = "PaperTopOff";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    float ret = 1.0f;
                    if (!float.TryParse(text, out ret))
                    {
                        ret = 1.0f;
                    }
                    return ret;
                }
                else
                {
                    return 1.0f;
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PaperTopOff", value.ToString());
            }
        }
        public static Image GetSkinImage(string imgName)
        {
            string imgPath = ExtendApplicationContext.Current.AppPath + "\\Skins\\" + imgName.Trim();

            //加载皮肤
            Image image = null;
            try
            {
                image = Image.FromFile(imgPath);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                ExceptionHandler.Handle(ex);
            }
            catch (System.OutOfMemoryException ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return image;
        }
        public static int EarlyWarningTime
        {
            get
            {
                string key = "EarlyWarningTime";
                string text = ConfigurationHelper.Read(key);
                int result;
                if (int.TryParse(text, out result))
                {
                    return result;
                }
                else
                {
                    return 30;
                }
            }
            set
            {
                ConfigurationHelper.Save("EarlyWarningTime", value.ToString());
            }
        }
    }
}
