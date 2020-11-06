 using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.UI;
using System.Data;
using Init;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;


namespace InitDocare
{
    /// <summary>
    /// 主要方法，用来修改注册表的
    /// </summary>
    public class PublicRegistrer
    {
        //SetValue("SIMPLIFIED CHINESE_CHINA.ZHS16GBK");
        //SetValue("AMERICAN_AMERICA.US7ASCII");
        public static bool SetValue(string temp)
        {
            try
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey softWare = rk.OpenSubKey("Software");
                Microsoft.Win32.RegistryKey microsoft = softWare.OpenSubKey("Oracle");
                Microsoft.Win32.RegistryKey windows = microsoft.OpenSubKey("Home0", true);
                windows.SetValue("NLS_LANG", temp);

                //Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software->Oracle->Home0", true);
                //object str = key.GetValue("NLS_LANG");
                ////if (str.ToString() != String.Empty)
                //key.SetValue("NLS_LANG", temp);//修改键值
                //key.Flush();
                //key.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 字符串处理
    /// </summary>
    public class PublicString
    {
        #region 汉字拼音转换
        /// <summary>
        /// 汉字转拼音首字母缩写        
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <returns>拼音缩写</returns>
        public static String GetPYString(String str)
        {
            String TempStr = "";
            foreach (char Chr in str)
            {
                if ((int)Chr >= 33 && (int)Chr <= 126)
                {
                    //字母和符号原样保留
                    TempStr += Chr.ToString();
                }
                else if ((int)Chr == 12288)
                {
                    //将全角空格转换为半角空格
                    TempStr += (char)32;
                }
                else if ((int)Chr > 65280 && (int)Chr < 65375)
                {
                    //将全角符号转换为半角符号
                    TempStr += (char)((int)Chr - 65248);
                }
                else
                {//累加拼音声母
                    TempStr += GetPYChar(Chr.ToString());
                }
            }
            return TempStr;
        }
        /// <summary>
        /// 汉字转拼音首字母缩写        
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <param name="maxLength">转换的最大长度</param>
        /// <returns>拼音缩写</returns>
        public static String GetPYString(String str, int maxLength)
        {
            String TempStr = "";
            TempStr = GetPYString(str);
            if (TempStr.Length > maxLength)
            {
                TempStr = TempStr.Substring(0, 8);
            }
            return TempStr;
        }
        /// <summary>
        /// 取单个字符的拼音声母        
        /// </summary>
        /// <param name="c">要转换的单个汉字</param>
        /// <returns>拼音声母</returns>
        public static String GetPYChar(String str)
        {
            if (str.CompareTo("吖") < 0) return str;
            if (str.CompareTo("八") < 0) return "A";
            if (str.CompareTo("嚓") < 0) return "B";
            if (str.CompareTo("咑") < 0) return "C";
            if (str.CompareTo("妸") < 0) return "D";
            if (str.CompareTo("发") < 0) return "E";
            if (str.CompareTo("旮") < 0) return "F";
            if (str.CompareTo("铪") < 0) return "G";
            if (str.CompareTo("讥") < 0) return "H";
            if (str.CompareTo("咔") < 0) return "J";
            if (str.CompareTo("垃") < 0) return "K";
            if (str.CompareTo("嘸") < 0) return "L";
            if (str.CompareTo("拏") < 0) return "M";
            if (str.CompareTo("噢") < 0) return "N";
            if (str.CompareTo("妑") < 0) return "O";
            if (str.CompareTo("七") < 0) return "P";
            if (str.CompareTo("亽") < 0) return "Q";
            if (str.CompareTo("仨") < 0) return "R";
            if (str.CompareTo("他") < 0) return "S";
            if (str.CompareTo("哇") < 0) return "T";
            if (str.CompareTo("夕") < 0) return "W";
            if (str.CompareTo("丫") < 0) return "X";
            if (str.CompareTo("帀") < 0) return "Y";
            if (str.CompareTo("咗") < 0) return "Z";
            return str;
        }
        #endregion

        /// <summary>
        /// 获取字符串的实际字节长度的方法
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>实际长度</returns>
        public static int GetRealLength(string source)
        {
            return Encoding.Default.GetByteCount(source);
        }

        /// <summary>
        /// 按字节数截取字符串的方法
        /// </summary>
        /// <param name="source">要截取的字符串</param>
        /// <param name="n">要截取的字节数</param>
        /// <param name="needEndDot">是否需要结尾的省略号</param>
        /// <returns>截取后的字符串</returns>
        public static string SubString(string source, int n, bool needEndDot)
        {
            string Result = string.Empty;
            if (GetRealLength(source) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return source;
            }
            else
            {
                int j = 0;
                char[] ChrList = source.ToCharArray();
                for (int i = 0; i < ChrList.Length && j < n; i++)
                {

                    if ((int)ChrList[i] > 127)//是否汉字
                    {
                        Result += ChrList[i];
                        j += 2;
                    }
                    else
                    {
                        Result += ChrList[i];
                        j++;
                    }
                }
                if (GetRealLength(Result) > n)
                {
                    Result = Result.Remove(Result.Length - 1, 1);
                }
                if (needEndDot)
                    Result += "...";
                return Result;
            }
        }

    }

    public class Publicini
    {
        //写ini文件
        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        //读ini文件
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        //Section参数、Key参数和IniFilePath不用再说，Value参数表明key的值，而这里的NoText对应API函数的def参数，
        //它的值由用户指定，是当在配置文件中没有找到具体的Value时，就用NoText的值来代替。

        #region 读Ini文件-字符

        public static string ReadIniDataString(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion
    }

    public class PublicParmDoamin
    {
        public static ParamInputDomain ToParaDomain(string joson)
        {
            using (MemoryStream ms2 = new MemoryStream(Encoding.UTF8.GetBytes(joson)))
            {
                string p = @"/d{4}-/d{2}-/d{2}/s/d{2}:/d{2}:/d{2}";
                MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
                Regex reg = new Regex(p);
                joson = reg.Replace(joson, matchEvaluator);    
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParamInputDomain));
                ParamInputDomain obj = serializer.ReadObject(ms2) as ParamInputDomain;
                return obj;
            }
        }

        private static string ConvertDateStringToJsonDate(Match m)
        {
            string result = string.Empty;
            DateTime dt = DateTime.Parse(m.Groups[0].Value);
            dt = dt.ToUniversalTime();
            TimeSpan ts = dt - DateTime.Parse("1970-01-01");
            result = string.Format("///Date({0}+0800)///", ts.TotalMilliseconds);
            return result;
        }

        public static string ParaDomainToString(ParamInputDomain domain)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jsonString = ser.Serialize(domain);
            string p = @"\\/Date(\d+)\+\d+\\/";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            return jsonString;  
        }

        /// <summary>   
        /// 
        /// </summary>   
        private static string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            result = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        } 
    }

    public class PublicB
    {
        /// <summary> 
        /// 反序列化 
        /// </summary> 
        /// <param name="data">数据缓冲区</param> 
        /// <returns>对象</returns> 
        public static object Deserialize(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream rems = new MemoryStream(data);
            data = null;
            return formatter.Deserialize(rems);
        }
        /// <summary> 
        /// 序列化 
        /// </summary> 
        /// <param name="data">要序列化的对象</param> 
        /// <returns>返回存放序列化后的数据缓冲区</returns> 
        public static byte[] Serialize(object data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream rems = new MemoryStream();
            formatter.Serialize(rems, data);
            return rems.GetBuffer();
        }
        public static string CaculateWeekDay(int y, int m, int d)
        {
            //一月和二月被当作前一年的
            if ((m == 1) || (m == 2))
            {
                m += 12;
                y--;
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            string weekstr = "";
            switch (week)
            {
                case 0: weekstr = "星期一"; break;
                case 1: weekstr = "星期二"; break;
                case 2: weekstr = "星期三"; break;
                case 3: weekstr = "星期四"; break;
                case 4: weekstr = "星期五"; break;
                case 5: weekstr = "星期六"; break;
                case 6: weekstr = "星期日"; break;
            }
            return weekstr;
        }
    }

    public class PublicA
    {


        /// <summary>
        /// 获取字符串的MD5摘要
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>返回字符串的MD5摘要</returns>
        public static string GetDigest(string input)
        {
            // 创建一个新的MD5加密服务对象
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static void WriteConfig(string theKey, string theValue)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //string app = System.Web.HttpContext.Current.Request.ApplicationPath + "/Web.Config";
            //xmlDoc.Load(System.Web.HttpContext.Current.Request.MapPath(app));

            //XmlNodeList nodes = xmlDoc.GetElementsByTagName("add");
            //int addCount = xmlDoc.GetElementsByTagName("add").Count;
            //for (int i = 0; i < 13; i++)
            //{
            //    XmlElement xe = (XmlElement)nodes[i];
            //    if (xe.Attributes["key"].Value.Equals(theKey))
            //        xe.Attributes["value"].Value = theValue;
            //}
            //for (int i = 13; i < 17; i++)
            //{
            //    XmlElement xe = (XmlElement)nodes[i];
            //    if (xe.Attributes["name"].Value.Equals(theKey))
            //        xe.Attributes["connectionString"].Value = theValue;
            //}
            //xmlDoc.Save(System.Web.HttpContext.Current.Request.MapPath(app));

        }

        public static String GetConfig(string theKey)
        {

            string mess = System.Configuration.ConfigurationManager.AppSettings.Get(theKey);
            return mess;
        }
    }

    public class PublicXML
    {
        /// <summary>
        /// 数据类型枚举
        /// </summary>
        public   enum InterfaceDataType
        {
            /// <summary>
            /// 手术申请数据
            /// </summary>
            OperationSchedule = 1,

            /// <summary>
            /// 检验主表
            /// </summary>
            LabTestMaster = 2,

            /// <summary>
            /// 检验明细
            /// </summary>
            LabResult = 3,

            /// <summary>
            /// 医嘱
            /// </summary>
            Orders=4,

            /// <summary>
            /// 病人信息主表
            /// </summary>
            PatMasterIndex = 5,

            /// <summary>
            /// 住院病人信息
            /// </summary>
            PatsInHospital = 6,

            /// <summary>
            /// his人员
            /// </summary>
            HisUsers=7,

            /// <summary>
            /// 科室信息
            /// </summary>
            DeptDict=8,

            /// <summary>
            /// 手术预约名称
            /// </summary>
            ScheduleOperationName = 9,

            /// <summary>
            /// 手术名称字典
            /// </summary>
            OperationDict=10,

            /// <summary>
            /// 诊断字典
            /// </summary>
            DiagnosisDict=11,
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public enum DataSoruceType
        { 
            ORACLE,
            OLEDB,
            SQLSERVER,
            XML
        }

        /// <summary>
        /// xml 转换dataset
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataSet XmlToDataSet(string xml)
        {
            string xmlInfo = xml.Replace("”", "\"").Replace("”", "\"");
            DataSet ds = new DataSet();

            using (StringReader xmlSR = new StringReader(xmlInfo))
            {
                ds.ReadXml(xmlSR, XmlReadMode.InferSchema);
            }
            return ds;
        }

        /// <summary>
        /// 转换字段名称
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="type">数据类型 枚举值</param>
        /// <returns></returns>
        public static DataTable EexcColumnName(DataTable dt, InterfaceDataType type)
        {
            Dictionary<string, string> dic = null;
            switch (type)
            {
                case InterfaceDataType.OperationSchedule:
                    dic = DicScheduleOperation;
                    break;
                case InterfaceDataType.DeptDict:
                    dic = DicDeptDict;
                    break;
                case InterfaceDataType.HisUsers:
                    dic = DicHisUsers;
                    break;
                case InterfaceDataType.LabResult:
                    dic = DicLabResult;
                    break;
                case InterfaceDataType.LabTestMaster:
                    dic = DicLabTestMaster;
                    break;
                case InterfaceDataType.Orders:
                    dic = DicOrders;
                    break;
                case InterfaceDataType.PatMasterIndex:
                    dic = DicPatMasterIndex;
                    break;
                case InterfaceDataType.PatsInHospital:
                    dic = DicPatsInHospital;
                    break;
                case InterfaceDataType.ScheduleOperationName:
                    dic = DicScheduleOperatonName;
                    break;
                case InterfaceDataType.DiagnosisDict:
                    dic = DicDiagnosisDict;
                    break;
                case InterfaceDataType.OperationDict:
                    dic = DicOperationDict;
                    break;
            }


            bool flag = false;

            foreach (KeyValuePair<string, string> kvp in dic)
            {
                flag = false;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (kvp.Value.ToUpper() == dc.ColumnName.ToUpper())
                    {
                        flag = true;
                        if (!dt.Columns.Contains(kvp.Key))
                        {
                            dc.ColumnName = kvp.Key;
                        }
                        break;
                    }
                }

                if (!flag&&!dt.Columns.Contains(kvp.Key))  //his 里面没有此字段, 创建新字段，
                {
                    dt.Columns.Add(kvp.Key);
                }
                dt.AcceptChanges();
            }
            return dt;
        }

        #region 字段对照 ，根据现场实际情况修改

        /// <summary>
        /// 手术申请 Dictionary key 是mdsd 字段名称, value 是his 字段名称
        /// </summary>
        private static Dictionary<string, string> DicScheduleOperation
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("PATIENT_ID", "PATIENTID");
                dicResult.Add("VISIT_ID", "VISITID");
                dicResult.Add("SCHEDULE_ID", "SCHEDULEID");
                dicResult.Add("DEPT_STAYED", "DEPTSTAYED");
                dicResult.Add("BED_NO", "BEDNO");
                dicResult.Add("SCHEDULED_DATE_TIME", "SCHEDULEDDATETIME");
                dicResult.Add("OPERATING_ROOM", "OPERATINGROOM");
                dicResult.Add("OPERATING_ROOM_NO", "OPERATINGROOMNO");
                dicResult.Add("SEQUENCE", "SEQUENCE");
                dicResult.Add("DIAG_BEFORE_OPERATION", "DIAGBEFOREOPERATION");
                dicResult.Add("PATIENT_CONDITION", "PATIENTCONDITION");
                dicResult.Add("OPERATION_SCALE", "OPERATIONSCALE");
                dicResult.Add("EMERGENCY_INDICATOR", "EMERGENCYINDICATOR");
                dicResult.Add("ISOLATION_INDICATOR", "ISOLATIONINDICATOR");
                dicResult.Add("OPERATING_DEPT", "OPERATINGDEPT");
                dicResult.Add("SURGEON", "SURGEON");
                dicResult.Add("FIRST_ASSISTANT", "FIRSTASSISTANT");
                dicResult.Add("SECOND_ASSISTANT", "SECONDASSISTANT");
                dicResult.Add("THIRD_ASSISTANT", "THIRDASSISTANT");
                dicResult.Add("ANESTHESIA_METHOD", "ANESTHESIAMETHOD");
                dicResult.Add("ANESTHESIA_DOCTOR", "ANESTHESIADOCTOR");
                dicResult.Add("ANESTHESIA_ASSISTANT", "ANESTHESIAASSISTANT");
                dicResult.Add("BLOOD_TRAN_DOCTOR", "BLOODTRANDOCTOR");
                dicResult.Add("FIRST_OPERATION_NURSE", "FIRSTOPERATIONNURSE");
                dicResult.Add("SECOND_OPERATION_NURSE", "SECONDOPERATIONNURSE");
                dicResult.Add("FIRST_SUPPLY_NURSE", "FIRSTSUPPLYNURSE");
                dicResult.Add("SECOND_SUPPLY_NURSE", "SECONDSUPPLYNURSE");
                dicResult.Add("NOTES_ON_OPERATION", "NOTESONOPERATION");
                dicResult.Add("ENTERED_BY", "ENTEREDBY");
                dicResult.Add("REQ_DATE_TIME", "REQDATETIME");
                dicResult.Add("STATUS", "OPER_STATUS_CODE");
                dicResult.Add("STATE", "STATE");
                dicResult.Add("RESERVED6", "RESERVED6");
                dicResult.Add("RESERVED1", "RESERVED1");
                dicResult.Add("RESERVED3", "RESERVED3");
                dicResult.Add("OPERATION_POSITION", "OPERATIONPOSITION");
                dicResult.Add("SPECIAL_EQUIPMENT", "SPECIALEQUIPMENT");
                dicResult.Add("SPECIAL_INFECT", "SPECIALINFECT");
                dicResult.Add("OPERATION_ID", "OPERATIONID");
                dicResult.Add("OPERATION_NAME", "OPERATIONNAME");
                dicResult.Add("THIRD_OPERATION_NURSE", "THIRDOPERATIONNURSE");
                dicResult.Add("THIRD_SUPPLY_NURSE", "THIRD_SUPPLY_NURSE");
                return dicResult;
            }

        }

        /// <summary>
        /// 检验主表 Dictionary key 是mdsd 字段名称, value 是lis 字段名称
        /// </summary>
        private static Dictionary<string, string> DicLabTestMaster
        {
            get
            {

                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("TEST_NO", "TESTNO");
                dicResult.Add("PRIORITY_INDICATOR", "PRIORITYINDICATOR");
                dicResult.Add("VISIT_ID", "VISITID");
                dicResult.Add("PATIENT_ID", "PATIENTID");
                dicResult.Add("NAME", "NAME");
                dicResult.Add("WORKING_ID", "WORKINGID");
                dicResult.Add("TEST_CAUSE", "TESTCAUSE");
                dicResult.Add("SPECIMEN", "SPECIMEN");
                dicResult.Add("SPCM_RECEIVED_DATE_TIME", "SPCMRECEIVEDDATETIME");
                dicResult.Add("ORDERING_DEPT", "ORDERINGDEPT");
                dicResult.Add("ORDERING_PROVIDER", "ORDERINGPROVIDER");
                dicResult.Add("PERFORMED_BY", "PERFORMEDBY");
                dicResult.Add("RESULT_STATUS", "RESULTSTATUS");
                dicResult.Add("RESULTS_RPT_DATE_TIME", "RESULTSRPTDATETIME");
                dicResult.Add("TRANSCRIPTIONIST", "TRANSCRIPTIONIST");
                dicResult.Add("VERIFIED_BY", "VERIFIEDBY");
                dicResult.Add("RELEVANT_CLINIC_DIAG", "RELEVANTCLINICDIAG");
                dicResult.Add("RESULT_DATE_TIME", "RESULTDATETIME");
                dicResult.Add("AGE", "AGE");
                dicResult.Add("Barcode", "Barcode");
                return dicResult;
            }
        }

        /// <summary>
        /// 检验明细 Dictionary key 是mdsd 字段名称, value 是lis 字段名称
        /// </summary>
        private static Dictionary<string, string> DicLabResult
        {
            get
            {

                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("TEST_NO", "TESTNO");
                dicResult.Add("Item_No", "ItemNo");
                dicResult.Add("REPORT_ITEM_NAME", "REPORTITEMNAME");
                dicResult.Add("REPORT_ITEM_CODE", "REPORTITEMCODE");
                dicResult.Add("ABNORMAL_INDICATOR", "ABNORMALINDICATOR");
                dicResult.Add("RESULT", "RESULT");
                dicResult.Add("UNITS", "UNITS");
                dicResult.Add("REFERENCE_RESULT", "REFERENCERESULT");
                dicResult.Add("RESULT_DATE_TIME", "RESULTDATETIME");
                dicResult.Add("InstrumentId", "InstrumentId");

                return dicResult;
            }
        }

        /// <summary>
        /// 病人信息主表 Dictionary key 是mdsd 字段名称, value 是his 字段名称
        /// </summary>
        private static Dictionary<string, string> DicPatMasterIndex
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("PATIENT_ID", "PatientID");
                dicResult.Add("NAME", "Name");
                dicResult.Add("NAME_PHONETIC", "NAME_PHONETIC");
                dicResult.Add("SEX", "SEX");
                dicResult.Add("DATE_OF_BIRTH", "DateOfBirth");
                dicResult.Add("BIRTH_PLACE", "BirthPlace");
                dicResult.Add("CITIZENSHIP", "Citizenship");
                dicResult.Add("NATION", "NATION");
                dicResult.Add("ID_NO", "IDNO");
                dicResult.Add("CHARGE_TYPE", "ChargeType");
                dicResult.Add("MAILING_ADDRESS", "MailingAddress");
                dicResult.Add("ZIP_CODE", "ZipCode");
                dicResult.Add("PHONE_NUMBER_HOME", "PhoneNumberHome");
                dicResult.Add("PHONE_NUMBER_BUSINESS", "PHONE_NUMBER_BUSINESS ");
                dicResult.Add("NEXT_OF_KIN", "NEXT_OF_KIN");
                dicResult.Add("RELATIONSHIP", "RelationShip");
                dicResult.Add("NEXT_OF_KIN_ADDR", "NEXT_OF_KIN_ADDR");
                dicResult.Add("NEXT_OF_KIN_ZIP_CODE", "NEXT_OF_KIN_ZIP_CODE");
                dicResult.Add("NEXT_OF_KIN_PHONE", "NEXT_OF_KIN_PHONE");
                dicResult.Add("LAST_VISIT_DATE", "LAST_VISIT_DATE");
                dicResult.Add("VIP_INDICATOR", "VIP_INDICATOR");
                dicResult.Add("CREATE_DATE", "CREATE_DATE");
                dicResult.Add("OPERATOR", "InpNO");
                dicResult.Add("IDENTITY", "Identity");
                dicResult.Add("UNIT_IN_CONTRACT", "UNIT_IN_CONTRACT");
                return dicResult;
            }
        }

        /// <summary>
        /// 住院病人信息表 Dictionary key 是mdsd 字段名称, value 是his 字段名称
        /// </summary>
        private static Dictionary<string, string> DicPatsInHospital
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("PATIENT_ID", "PatientId");
                dicResult.Add("INP_NO", "INP_NO");
                dicResult.Add("VISIT_ID", "VisitId");
                dicResult.Add("PATIENT_SOURCE", "PATIENT_SOURCE");
                dicResult.Add("WARD_CODE", "WardCode");
                dicResult.Add("DEPT_CODE", "DeptCode");
                dicResult.Add("BED_NO", "BedNO");
                dicResult.Add("ADMISSION_DATE_TIME", "AdmissionDateTime");
                dicResult.Add("ADM_WARD_DATE_TIME", "AdmWardDateTime");
                dicResult.Add("DIAGNOSIS", "Diagnosis");
                dicResult.Add("HOSP_BRANCH", "HOSP_BRANCH");//
                dicResult.Add("BLOOD_TYPE", "BLOOD_TYPE");
                dicResult.Add("BLOOD_TYPE_RH", "BLOOD_TYPE_RH");
                dicResult.Add("BODY_HEIGHT", "BODY_HEIGHT");
                dicResult.Add("BODY_WEIGHT", "BODY_WEIGHT");
                dicResult.Add("NURSING_CLASS", "NURSING_CLASS");
                dicResult.Add("DOCTOR_IN_CHARGE", "DOCTORINCHARGE");
                dicResult.Add("NURSE_IN_CHARGE", "NURSE_IN_CHARGE");
                dicResult.Add("PATIENT_CONDITION", "PATIENT_CONDITION");
                dicResult.Add("DEP_ID", "DEP_ID");
                dicResult.Add("DEPT_FROM", "DEPT_FROM");
                dicResult.Add("ALERGY_DRUGS", "ALERGY_DRUGS");
                dicResult.Add("SPECIAL_MARK", "SPECIAL_MARK");
                return dicResult;
            }
        }

        /// <summary>
        /// 医嘱 Dictionary key 是mdsd 字段名称, value 是his 字段名称
        /// </summary>
        private static Dictionary<string, string> DicOrders
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("PATIENT_ID", "PatientID");
                dicResult.Add("VISIT_ID", "VisitID");
                dicResult.Add("ORDER_NO", "OrderNo");
                dicResult.Add("ORDER_SUB_NO", "OrderSubNo");
                dicResult.Add("REPEAT_INDICATOR", "RepeatIndicator");
                dicResult.Add("ORDER_CLASS", "OrderClass");
                dicResult.Add("ORDER_TEXT", "OrderText");
                dicResult.Add("ORDER_CODE", "OrderCode");
                dicResult.Add("DOSAGE", "Dosage");
                dicResult.Add("DOSAGE_UNITS", "DosageUnits");
                dicResult.Add("ADMINISTRATION", "Administration");
                dicResult.Add("START_DATE_TIME", "StartDateTime");
                dicResult.Add("STOP_DATE_TIME", "StopDateTime");
                dicResult.Add("DURATION", "Duration");
                dicResult.Add("DURATION_UNITS", "DurationUnits");
                dicResult.Add("FREQUENCY", "Frequency");
                dicResult.Add("FREQ_COUNTER", "FreqCounter");
                dicResult.Add("FREQ_INTERVAL", "FREQ_INTERVAL");
                dicResult.Add("FREQ_INTERVAL_UNIT", "FreqIntervalUnit");
                dicResult.Add("FREQ_DETAIL", "FREQ_DETAIL");

                dicResult.Add("PERFORM_SCHEDULE", "PerfromSchedule");
                dicResult.Add("PERFORM_RESULT", "PERFORM_RESULT");
                dicResult.Add("ORDERING_DEPT", "OrderingDept");
                dicResult.Add("DOCTOR", "Doctor");
                dicResult.Add("STOP_DOCTOR", "STOP_DOCTOR");
                dicResult.Add("NURSE", "NURSE");
                dicResult.Add("STOP_NURSE", "STOP_NURSE");
                dicResult.Add("ENTER_DATE_TIME", "ENTER_DATE_TIME");
                dicResult.Add("STOP_ORDER_DATE_TIME", "StopOrderDateTime");
                dicResult.Add("ORDER_STATUS", "OrderStatus");
                dicResult.Add("BILLING_ATTR", "BILLING_ATTR");

                dicResult.Add("LAST_PERFORM_DATE_TIME", "LAST_PERFORM_DATE_TIME");
                dicResult.Add("LAST_ACCTING_DATE_TIME", "LAST_ACCTING_DATE_TIME");
                dicResult.Add("DRUG_DILLING_ATTR", "DRUG_DILLING_ATTR");
                dicResult.Add("TREAT_SHEET_FLAG", "TREAT_SHEET_FLAG");
                dicResult.Add("PHAM_STD_CODE", "PHAM_STD_CODE");
                dicResult.Add("AMOUNT", "AMOUNT");
                dicResult.Add("CURRENT_PRESC_NO", "OrderFillNo");
                dicResult.Add("QTY", "QTY");
                return dicResult;
            }
        }

        /// <summary>
        /// his 人员 Dictionary key 是mdsd 字段名称, value 是his 字段名称
        /// </summary>
        private static Dictionary<string, string> DicHisUsers
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("USER_ID", "USERID");
                dicResult.Add("USER_NAME", "USERNAME");
                dicResult.Add("USER_DEPT", "USERDEPT");
                dicResult.Add("USER_JOB", "USERJOB");
                dicResult.Add("CREATE_DATE", "CREATEDATE");

                return dicResult;
            }
        }

        /// <summary>
        /// 科室信息 Dictionary key 是mdsd 字段名称, value 是his 字段名称
        /// </summary>
        private static Dictionary<string, string> DicDeptDict
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                //dicResult.Add("Sort_No", "SERIALNO");
                //dicResult.Add("DEPT_CODE", "DEPTCODE");
                //dicResult.Add("DEPT_NAME", "DEPTNAME");
                //dicResult.Add("INPUT_CODE", "INPUTCODE");

                return dicResult;
            }
        }


        private static Dictionary<string, string> DicScheduleOperatonName
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("PATIENT_ID", "PATIENTID");
                dicResult.Add("VISIT_ID", "VISITID");
                dicResult.Add("SCHEDULE_ID", "SCHEDULEID");
                dicResult.Add("OPERATION_NO", "OPERATIONNO");
                dicResult.Add("OPERATION", "OPERATION");
                dicResult.Add("OPERATION_SCALE", "OPERATIONSCALE");
                dicResult.Add("OPERATION_CODE", "OPERATIONCODE");
                dicResult.Add("RESERVED2", "RESERVED2");
                dicResult.Add("RESERVED3", "RESERVED3");
                dicResult.Add("RESERVED4", "RESERVED4");
                return dicResult;
            }
        }

        //OPERATION_CODE OPERATION_NAME OPERATION_SCALE STD_INDICATOR  APPROVED_INDICATOR INPUT_CODE
        /// <summary>
        /// KEY 是mdsd 字段，Value 是His 字段
        /// </summary>
        private static Dictionary<string, string> DicOperationDict
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("OPERATION_CODE", "OPERATIONCODE");
                dicResult.Add("OPERATION_NAME", "OPERATIONNAME");
                dicResult.Add("OPERATION_SCALE", "OPERATIONSCALE");
                dicResult.Add("STD_INDICATOR", "STDINDICATOR");
                dicResult.Add("APPROVED_INDICATOR", "APPROVEDINDICATOR");
                dicResult.Add("INPUT_CODE", "INPUTCODE");
                return dicResult;
            }
        }

        /// <summary>  DIAGNOSIS_CODE DIAGNOSIS_NAME STD_INDICATOR APPROVED_INDICATOR INPUT_CODE
        /// KEY 是mdsd 字段，Value 是His 字段
        /// </summary>
        private static Dictionary<string, string> DicDiagnosisDict
        {
            get
            {
                Dictionary<string, string> dicResult = new Dictionary<string, string>();
                dicResult.Add("DIAGNOSIS_CODE", "DIAGNOSISCODE");
                dicResult.Add("DIAGNOSIS_NAME", "DIAGNOSISNAME");
                dicResult.Add("STD_INDICATOR", "STDINDICATOR");
                dicResult.Add("APPROVED_INDICATOR", "APPROVEDINDICATOR");
                dicResult.Add("INPUT_CODE", "INPUTCODE");
                return dicResult;
            }
        }
        #endregion
    }

    /// <summary>
    /// 枚举常量类
    /// </summary>
    public class EmunLog
    {
        /// <summary>
        ///  接口日志模块枚举常量
        /// </summary>
        public  enum EnumTypeModule
        {
            手术申请同步,
            手术名称同步,
            科室同步,
            人员同步,
            检验主表同步,
            检验明细同步,
            医嘱同步,
            排版回写,
            手术回写,
            收费回写,
            其他补充,
            手术字典,
            诊断字典
        }

        /// <summary>
        /// 接口日志 等级枚举
        /// </summary>
        public   enum EnumTypeGrade
        {
            提示,
            警告,
            异常,
            奔溃,
        }

        /// <summary>
        /// 系统日志错误来源
        /// </summary>
        public  enum EnumTypeSource
        {
            通用,
            麻醉,
            ICU,
            数字化,
            临床,
            其他,
        }

        /// <summary>
        /// 系统日志记录错误类型
        /// </summary>
        public  enum EnumTypeCategory
        {
            数据库异常,
            HIS数据异常,
            程序错误,
            HIS,
            LIS,
            EMR,
            PACS
        }
    }

   
}
