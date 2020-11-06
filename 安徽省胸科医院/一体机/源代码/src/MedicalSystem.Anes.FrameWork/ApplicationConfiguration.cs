using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MedicalSystem.Anes.Document.Configurations;
using System.Configuration;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using System.Windows.Forms;
using MedicalSystem.AnesWorkStation.Model;
using System.Reflection;

namespace MedicalSystem.Anes.FrameWork
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

        /// <summary>
        /// 标记修改过的体征项
        /// </summary>
        public static bool IsModifyVitalSignShowDifferent
        {
            get
            {
                bool tempResult = false;
                string key = "IsModifyVitalSignShowDifferent";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!bool.TryParse(text, out tempResult))
                {
                    tempResult = false;
                }

                return tempResult;
            }
            set
            {
                string key = "IsModifyVitalSignShowDifferent";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
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
            var configTable = ApplicationModel.Instance.AllDictList.ConfigList;
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
                List<MED_CONFIG> configList = DictService.ClientInstance.GetConfigList();
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
                    configRow.ModelStatus = ModelStatus.Add;
                    configList.Add(configRow);
                    //ExtendAppContext.Current.CommDict.ConfigDict = configList;
                    ApplicationModel.Instance.AllDictList.ConfigList = configList;
                }
                else
                {
                    configRow.ModelStatus = ModelStatus.Modeified;
                }

                if (string.IsNullOrEmpty(value))
                {
                    configRow.PARAVALUE = new byte[] { 0 };
                }
                else
                {
                    configRow.PARAVALUE = StringHelper.Str2Arr(value);
                }

                DictService.ClientInstance.UpdateConfigList(configList);
            }
        }
        /// <summary>
        /// 是否启用PACU管理
        /// </summary>
        public static bool IsPACUProcess
        {
            get
            {
                string key = "IsPACUProcess";
                string text = ApplicationConfiguration.GetFromConfigTable("IsPACUProcess");
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
                string key = "IsPACUProcess";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
            }
        }

        static Dictionary<string, object> _configurCache = new Dictionary<string, object>();

        /// <summary>
        /// 是否更新排班程序状态
        /// </summary>
        public static bool IsUpdateScheduleStatus
        {
            get
            {
                string key = "IsUpdateScheduleStatus";
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
                string key = "IsUpdateScheduleStatus";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
                ConfigurationHelper.Save(key, value.ToString());
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
                    text = "BloodInOne";
                }
                return text;
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("BloodLiquidShow", value.ToString());
            }
        }




        /// <summary>
        /// joysola 用于获取 用药名称的格式 字符串”
        /// </summary>
        //public static string DrugNameMarkFormat
        //{
        //    get
        //    {
        //        string key = "DrugNameMarkFormat";
        //        string text = ApplicationConfiguration.GetFromConfigTable(key);
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            text = ConfigurationHelper.Read(key);
        //        }
        //        return text;
        //    }
        //    set
        //    {
        //        ApplicationConfiguration.ModifyConfigTable("DrugNameMarkFormat", value.ToString());
        //    }
        //}
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
                string key = "IsUpdateHisStatus";
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
                string key = "IsUpdateAnesCharge";
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
                string key = "IsUpdateAnesCharge";
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
        /// PDF本地生成地址
        /// </summary>
        public static string PDFLocalUrl
        {
            get
            {
                string key = "PDFLocalUrl";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
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
                ApplicationConfiguration.ModifyConfigTable("PDFLocalUrl", value);
            }
        }

        /// <summary>
        /// PDF上传服务器地址
        /// </summary>
        public static string PDFServerUrl
        {
            get
            {
                string key = "PDFServerUrl";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "192.168.15.45";
                }
            }
            set
            {
                ApplicationConfiguration.ModifyConfigTable("PDFServerUrl", value);
            }
        }

        /// <summary>
        /// 文书上传后否删除本地文件
        /// </summary>
        public static bool IsDeleteAfterCommitDoc
        {
            get
            {
                bool result = false;
                string key = "IsDeleteAfterCommitDoc";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
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

        /// <summary>
        /// 文书是否上传列表
        /// </summary>
        public static string PostPDF_Names
        {
            get
            {
                string key = "PostPDF_Names";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
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
                bool result = false;
                string key = "IsAutomaticArchiving";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
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
                int result = 30;
                string key = "ArchivOperAfterDay";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
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
        /// <summary>
        /// 未进手术间的列表
        /// </summary>
        public static string SignleBottomMenuControlListBeforeOperationByNotPatienting
        {
            get
            {
                string key = "SignleBottomMenuControlListBeforeOperation";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "麻醉记录单,术前访视单,麻醉同意书,不良后果告知书,术后随访单,麻醉总结单,麻醉计费,手术信息,仪器设置,术后登记";

                }

                return text;
            }
            set
            {
                string key = "SignleBottomMenuControlListBeforeOperation";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string BottomMenuFunctionListBeforeOperation
        {
            get
            {
                string key = "BottomMenuFunctionListBeforeOperation";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if (!text.Contains("批量归档"))
                //{
                //    text += ",批量归档";
                //}
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "麻醉记录单,术前访视单,麻醉同意书,不良后果告知书,术后随访单,麻醉总结单,麻醉计费,手术信息,仪器设置,术后登记";

                }

                return text;
            }
            set
            {
                string key = "BottomMenuFunctionListBeforeOperation";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        /// <summary>
        /// 术中工具栏按钮列表
        /// </summary>
        public static string SignleBottomMenuControlListInOperation
        {
            get
            {
                string key = "SignleBottomMenuControlListInOperation";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "麻醉记录单,术后随访单,术前访视单,麻醉同意书,检验结果,麻醉总结单,麻醉计费,手术信息,仪器设置,保存模板,更换手术间,手术交接班";//,个性化体征
                }

                return text;
            }
            set
            {
                string key = "SignleBottomMenuControlListInOperation";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string BottomMenuFunctionListInOperation
        {
            get
            {

                string key = "BottomMenuFunctionListInOperation";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                //if(!text.Contains("批量归档"))
                //{
                //    text += ",批量归档";
                //}
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "血气分析,手术跳转,手术取消,家属协同,麻醉同意书,麻醉总结单,麻醉计费,手术信息,仪器设置,保存模板,更换手术间,手术交接班,检验结果";
                }

                return text;
            }
            set
            {
                string key = "BottomMenuFunctionListInOperation";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        /// <summary>
        /// 术后工具栏按钮列表
        /// </summary>
        public static string SignleBottomMenuControlListAfterOperation
        {
            get
            {
                string key = "SignleBottomMenuControlListAfterOperation";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "术后随访单,麻醉记录单,术前访视单,麻醉同意书,麻醉总结单,麻醉计费,手术信息,检验结果,麻醉计费";

                    if (null == ExtendAppContext.Current.CurntOpenForm || !ExtendAppContext.Current.CurntOpenForm.FormName.Equals("InOperationWindow"))
                    {
                        text += ",查看术中";
                    }
                }

                return text;
            }
            set
            {
                string key = "SignleBottomMenuControlListAfterOperation";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        public static string BottomMenuFunctionListAfterOperation
        {
            get
            {

                string key = "BottomMenuFunctionListAfterOperation";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = ConfigurationHelper.Read(key);
                }
                if (string.IsNullOrEmpty(text))
                {
                    text = "术后随访单,麻醉记录单,术前访视单,麻醉同意书,麻醉总结单,麻醉计费,手术信息,检验结果,手术跳转";

                    if (null == ExtendAppContext.Current.CurntOpenForm || !ExtendAppContext.Current.CurntOpenForm.FormName.Equals("InOperationWindow"))
                    {
                        text += ",查看术中";
                    }
                }

                return text;
            }
            set
            {
                string key = "BottomMenuFunctionListAfterOperation";
                ApplicationConfiguration.ModifyConfigTable(key, value);
            }
        }

        /// <summary>
        /// 是否启用患者核对模块
        /// </summary>
        public static bool IsOpenPatConfirm
        {
            get
            {
                bool result = false;
                string key = "IsOpenPatConfirm";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!bool.TryParse(text, out result))
                {
                    result = false;
                }

                return result;
            }
            set
            {
                string key = "IsOpenPatConfirm";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
            }
        }

        /// <summary>
        /// 麦迪斯顿跨平台通信的服务端地址
        /// </summary>
        public static string MedicalSystemMessageServerURL
        {
            get
            {
                string key = "MedicalSystemMessageServerURL";
                string value = ApplicationConfiguration.GetFromConfigTable(key);

                if (string.IsNullOrEmpty(value))
                {
                    value = ConfigurationHelper.Read(key);
                }

                if (string.IsNullOrEmpty(value))
                {
                    value = "localhost:9999";
                }

                return value;
            }
        }

        /// <summary>
        /// 双面打印的文书列表
        /// </summary>
        public static string[] DoublePrintDocNames
        {
            get
            {
                string key = "DoublePrintDocNames";
                string value = ApplicationConfiguration.GetFromConfigTable(key);
                // value = "麻醉记录单,麻醉同意书;麻醉处方单,术前访视单;";
                if (!string.IsNullOrEmpty(value))
                {
                    string[] result = value.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// 是否调用接口同步
        /// </summary>
        public static bool IsSync
        {
            get
            {
                bool tempResult = false;
                string key = "IsSync";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!bool.TryParse(text, out tempResult))
                {
                    tempResult = false;
                }

                return tempResult;
            }
            set
            {
                string key = "IsSync";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
            }
        }

        /// <summary>
        /// 急诊根据住院号同步
        /// </summary>
        public static bool IsSyncByInpNo
        {
            get
            {
                bool tempResult = false;
                string key = "IsSyncByInpNo";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!bool.TryParse(text, out tempResult))
                {
                    tempResult = false;
                }

                return tempResult;
            }
            set
            {
                string key = "IsSyncByInpNo";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
            }
        }

        /// <summary>
        /// 麻醉单每页显示的小时数
        /// </summary>
        public static int AnesDocPageHours
        {
            get
            {
                int result = 4;
                string key = "AnesDocPageHours";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!int.TryParse(text, out result))
                {
                    result = 4;
                }

                return result;
            }
            set
            {
                string key = "AnesDocPageHours";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
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
        /// 是否加载视频组件
        /// </summary>
        public static bool IsOpenCoordinationCall
        {
            get
            {
                bool tempResult = false;
                string key = "IsOpenCoordinationCall";
                string text = ApplicationConfiguration.GetFromConfigTable(key);
                if (!bool.TryParse(text, out tempResult))
                {
                    tempResult = false;
                }

                return tempResult;
            }
            set
            {
                string key = "IsOpenCoordinationCall";
                ApplicationConfiguration.ModifyConfigTable(key, value.ToString());
            }
        }

        private static Dictionary<string, string> shortCuts = null;

        /// <summary>
        /// 快捷键(M1-M8)对应的功能配置
        /// </summary>
        public static Dictionary<string, string> ShortCuts
        {
            get
            {
                if (shortCuts != null)
                {
                    return shortCuts;
                }

                shortCuts = new Dictionary<string, string>();

                List<FieldInfo> fileInfos = typeof(KeyCode.AppCode).GetFields().ToList();
                string key = "ShortCuts";
                string value = ApplicationConfiguration.GetFromConfigTable(key);
                // ApplicationConfiguration.ModifyConfigTable(key, "M2:麻醉记录单;M3:麻醉总结单;M4:安全核查单;M5:麻醉同意书;M6:会诊记录单;");

                string[] arrValue = value.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in arrValue)
                {
                    string[] tempArr = item.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (tempArr.Length == 2)
                    {
                        string tempKey = tempArr[0];
                        // 找到对应的按键代码
                        FieldInfo tempInfo = fileInfos.FirstOrDefault(x => x.Name.Equals(tempKey));
                        if (tempInfo != null)
                        {
                            object tempValue = tempInfo.GetValue(new KeyCode.AppCode());
                            if (tempValue != null && !shortCuts.ContainsKey(tempValue.ToString()))
                            {
                                shortCuts.Add(tempValue.ToString(), tempArr[1]);
                            }
                        }
                        else if (!shortCuts.ContainsKey(tempKey))
                        {
                            shortCuts.Add(tempKey, tempArr[1]);
                        }
                    }
                }

                return shortCuts;
            }
        }
    }
}
