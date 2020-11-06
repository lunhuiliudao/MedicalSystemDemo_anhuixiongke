using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace MedicalSytem.Soft.Model
{
    public static class Extensions
    {

	 #region XML

        /// <summary>
        /// 判断XML字符格式是否正确
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static bool IsValidXml(this string xml)
        {
            try
            {
                // Check we actually have a value
                if (xml.IsNotNullOrEmpty())
                {
                    // Try to load the value into a document
                    XmlDocument xmlDoc = new XmlDocument();

                    xmlDoc.LoadXml(xml);

                    // If we managed with no exception then this is valid XML!
                    return true;
                }
                else
                {
                    // A blank value is not valid xml
                    return false;
                }
            }
            catch (System.Xml.XmlException)
            {
                return false;
            }
        }

        #endregion
	
	
        #region  DataSet

        /// <summary>
        /// 转换成DataTable
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this string str, string tableName)
        {
			if (!str.IsValidXml())
            {
                return null;
            }
			
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(str))
            {
                ds.ReadXml(sr);
            }

            if (ds.Tables.Count == 0)
            {
                return null;
            }

            if (tableName.IsNullOrEmpty())
            {
                return ds.Tables[0];
            }
            else
            {
                if (ds.Tables.Contains(tableName))
                {
                    return ds.Tables[tableName];
                }
            }

            return null;
        }

        /// <summary>
        /// 判断是否有值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsNotNull(this DataRow row, string name)
        {
            return !row.IsNull(name);
        }

		 /// <summary>
        /// 获取指定列名的值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetValue(this DataRow row, string name)
        {
            if (name.IsNotNullOrEmpty() && row.IsNotNull(name))
            {
                return row[name].ToString().Trim();
            }
            return string.Empty;
        }
		
        #endregion


        #region Main

		///字典获取Value
		 public static T GetDicValue<TKey, T>(this Dictionary<TKey, T> dic, TKey key)
        {
            if (dic != null && dic.ContainsKey(key))
            {
                return dic[key];
            }
            return default(T);
        }
		
        /// <summary>
        /// 不包含数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool NoContains<T>(this IEnumerable<T> list, T item)
        {
            return !list.Contains(item);
        }

        /// <summary>
        /// 去除HTML
        /// </summary>
        /// <param name="html"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RemoveHtmlTag(this string html, int length = 0)
        {
            if (html.IsNullOrEmpty()) return string.Empty;
            var strText = Regex.Replace(html, "<[^>]+>", "", RegexOptions.IgnoreCase);
            strText = Regex.Replace(strText, "&[^;]+;", "", RegexOptions.IgnoreCase);

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText.Trim();
        }

        /// <summary>
        /// 指定标识删除
        /// </summary>
        /// <param name="str">原字符</param>
        /// <param name="flag">标识</param>
        /// <param name="isInclude">是否保留</param>
        /// <returns></returns>
        public static string RemoveFlag(this string str, string flag, bool isInclude = false)
        {
            if (str.IsNotNullOrEmpty() && flag.IsNotNullOrEmpty() && str.Contains(flag))
            {
                var flagIndex = str.IndexOf(flag, StringComparison.Ordinal);
                if (isInclude)
                {
                    var length = flagIndex + 1;
                    if (length < str.Length)
                        str = str.Remove(length);
                }
                else
                {
                    str = str.Remove(flagIndex);
                }

            }
            return str;
        }

        /// <summary>
        /// 指定格式转换成时间类型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, string format)
        {
            DateTime result;
            if (DateTime.TryParseExact(str, format, System.Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            return new DateTime(1970, 1, 1, 0, 0, 0);
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        public static string GetStatusValue(this Dictionary<decimal?, string> dic, decimal? key)
        {
            if (dic.IsNotNullOrEmpty() && key.HasValue && dic.ContainsKey(key))
            {
                return dic[key];
            }
            return null;
        }

        /// <summary>
        /// 通过标识截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="flag"></param>
        /// <param name="isLast"></param>
        /// <returns></returns>
        public static string SubStringByFlag(this string str, string flag, bool isLast = true)
        {
            if (str.IsNotNullOrEmpty() && flag.IsNotNullOrEmpty())
            {
                var index = isLast ? str.LastIndexOf(flag, StringComparison.Ordinal) : str.IndexOf(flag, StringComparison.Ordinal);
                if (index >= 0)
                {
                    return str.Substring(index);
                }
            }

            return null;
        }

        /// <summary>
        /// 判断集合不为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        /// <summary>
        /// 判断集合为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return !source.IsNotNullOrEmpty();
        }

        /// <summary>
        /// 判断字符串不为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 判断字符串为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 判断没有值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasNoValue<T>(this Nullable<T> value) where T : struct
        {
            return !value.HasValue;
        }

        /// <summary>
        /// 通过枚举值获取枚举名
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns>枚举名</returns>
        public static T ParseToEnum<T>(this byte value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
        /// <summary>
        /// 通过枚举名获取枚举值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="name">枚举名</param>
        /// <returns>枚举值</returns>
        public static T ParseToEnum<T>(this string name)
        {
            return (T)Enum.Parse(typeof(T), name, true);
        }
        /// <summary>
        /// 根据枚举值进行转换枚举类型
        /// </summary>
        /// <typeparam name="T">转换成枚举类型</typeparam>
        /// <param name="value">枚举名</param>
        /// <param name="parsed">被转换枚举类型</param>
        /// <returns>是否成功</returns>
        public static bool ParseTryToEnum<T>(this byte value, out T parsed)
        {
            if (Enum.IsDefined(typeof(T), value))
            {
                parsed = (T)Enum.ToObject(typeof(T), value);
                return true;
            }
            parsed = (T)Enum.Parse(typeof(T), Enum.GetNames(typeof(T))[0]);
            return false;
        }
        /// <summary>
        /// 根据枚举名进行转换枚举类型
        /// </summary>
        /// <typeparam name="T">转换成枚举类型</typeparam>
        /// <param name="name">枚举名</param>
        /// <param name="parsed">被转换枚举类型</param>
        /// <returns>是否成功</returns>
        public static bool ParseTryToEnum<T>(this string name, out T parsed)
        {
            if (Enum.IsDefined(typeof(T), name))
            {
                parsed = (T)Enum.Parse(typeof(T), name, true);
                return true;
            }
            parsed = (T)Enum.Parse(typeof(T), Enum.GetNames(typeof(T))[0]);
            return false;
        }

        /// <summary>
        /// 泛型转换
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="val">Object</param>
        /// <returns>泛型</returns>
        public static T ParseConvertType<T>(this object val)
        {
            if ((val != null) && (val != DBNull.Value))
            {
                Type type = typeof(T);
                if (type.IsGenericType)
                {
                    type = type.GetGenericArguments()[0];
                }
                if (type.Name.Equals("String"))
                {
                    return (T)val;
                }
                ParameterModifier[] modifiers = new ParameterModifier[] { new ParameterModifier(2) };
                MethodInfo info = type.GetMethod("TryParse", BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder, new Type[] { typeof(string), type.MakeByRefType() }, modifiers);
                object[] parameters = new object[] { val, Activator.CreateInstance(type) };
                if ((bool)info.Invoke(null, parameters))
                {
                    return (T)parameters[1];
                }
            }
            return default(T);
        }

        /// <summary>
        /// Object转换成整形
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>int</returns>
        public static int ParseToInt(this object val)
        {
            return val.ParseToInt(0);
        }
        /// <summary>
        /// Object转换成整形
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>int</returns>
        public static int ParseToInt(this object val, int defaultValue)
        {
            int num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is int)
            {
                return (int)val;
            }
            if (!int.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成整形(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>int?</returns>
        public static int? ParseToIntNullable(this object val)
        {
            int num = val.ParseToInt();
            if (num.Equals(0))
            {
                return null;
            }
            return new int?(num);
        }

        /// <summary>
        /// Object转换成字符
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>string</returns>
        public static string ParseToString(this object val)
        {
            if ((val == null) || (val == DBNull.Value))
            {
                return string.Empty;
            }
            if (val.GetType() == typeof(byte[]))
            {
                return Encoding.ASCII.GetString((byte[])val, 0, ((byte[])val).Length);
            }
            return val.ToString();
        }
        /// <summary>
        /// Object转换成字符
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="replace">为空替换</param>
        /// <returns>string</returns>
        public static string ParseToString(this object val, string replace)
        {
            string str = val.ParseToString();
            return (string.IsNullOrEmpty(str) ? replace : str);
        }
        /// <summary>
        /// Object转换成字符(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>string</returns>
        public static string ParseToStringNullable(this object val)
        {
            string str = val.ParseToString();
            return (string.IsNullOrEmpty(str) ? null : str);
        }

        /// <summary>
        /// Object转换成uint
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>uint</returns>
        public static uint ParseToUint(this object val)
        {
            return val.ParseToUint(0);
        }
        /// <summary>
        /// Object转换成uint
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>uint</returns>
        public static uint ParseToUint(this object val, uint defaultValue)
        {
            uint num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is uint)
            {
                return (uint)val;
            }
            if (!uint.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成uint(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>uint?</returns>
        public static uint? ParseToUintNullable(this object val)
        {
            uint num = val.ParseToUint();
            if (num.Equals((uint)0))
            {
                return null;
            }
            return new uint?(num);
        }

        /// <summary>
        /// Object转换成布尔
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>bool</returns>
        public static bool ParseToBool(this object val)
        {
            if ((val == null) || (val == DBNull.Value))
            {
                return false;
            }
            if (val is bool)
            {
                return (bool)val;
            }
            return ((val.ToString().ToLower() == "true") || (val.ToString() == "1"));
        }
        /// <summary>
        /// Object转换成布尔
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>Boolean</returns>
        public static bool ParseToBoolean(this object val)
        {
            if ((val == null) || (val == DBNull.Value))
            {
                return false;
            }
            if (val is bool)
            {
                return (bool)val;
            }
            return ((val.ToString().ToLower() == "true") || (val.ToString() == "1"));
        }

        /// <summary>
        /// Object转换成日期
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>DateTime</returns>
        public static DateTime ParseToDateTime(this object val)
        {
            DateTime time;
            if ((val == null) || (val == DBNull.Value))
            {
                return DateTime.MinValue;
            }
            if (val is DateTime)
            {
                return (DateTime)val;
            }
            if (!DateTime.TryParse(val.ToString(), out time))
            {
                return DateTime.MinValue;
            }
            return time;
        }
        /// <summary>
        /// Object转换成日期(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>DateTime?</returns>
        public static DateTime? ParseToDateTimeNullable(this object val)
        {
            DateTime time = val.ParseToDateTime();
            if (time.Equals(DateTime.MinValue))
            {
                return null;
            }
            return new DateTime?(time);
        }

        /// <summary>
        /// Object转换成Byte
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>Byte</returns>
        public static byte ParseToByte(this object val)
        {
            return val.ParseToByte(0);
        }
        /// <summary>
        /// Object转换成Byte
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Byte</returns>
        public static byte ParseToByte(this object val, byte defaultValue)
        {
            byte num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is byte)
            {
                return (byte)val;
            }
            if (!byte.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成Byte(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>Byte?</returns>
        public static byte? ParseToByteNullable(this object val)
        {
            byte num = val.ParseToByte();
            if (num.Equals((byte)0))
            {
                return null;
            }
            return new byte?(num);
        }

        /// <summary>
        /// Object转换成short
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>short</returns>
        public static short ParseToShort(this object val)
        {
            return val.ParseToShort(0);
        }
        /// <summary>
        /// Object转换成short
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>short</returns>
        public static short ParseToShort(this object val, short defaultValue)
        {
            short num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is short)
            {
                return (short)val;
            }
            if (!short.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成short(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>short?</returns>
        public static short? ParseToShortNullable(this object val)
        {
            short num = val.ParseToShort();
            if (num.Equals((short)0))
            {
                return null;
            }
            return new short?(num);
        }

        /// <summary>
        /// Object转换成long
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>long</returns>
        public static long ParseToLong(this object val)
        {
            return val.ParseToLong(0);
        }
        /// <summary>
        /// Object转换成long
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>long</returns>
        public static long ParseToLong(this object val, long defaultValue)
        {
            long num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is long)
            {
                return (long)val;
            }
            if (!long.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成long(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>long?</returns>
        public static long? ParseToLongNullable(this object val)
        {
            long num = val.ParseToLong();
            if (num.Equals((long)0))
            {
                return null;
            }
            return new long?(num);
        }

        /// <summary>
        /// Object转换成sbyte
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>sbyte</returns>
        public static sbyte ParseToSbyte(this object val)
        {
            return val.ParseToSbyte(0);
        }
        /// <summary>
        /// Object转换成sbyte
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>sbyte</returns>
        public static sbyte ParseToSbyte(this object val, sbyte defaultValue)
        {
            sbyte num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is sbyte)
            {
                return (sbyte)val;
            }
            if (!sbyte.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成sbyte(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>sbyte?</returns>
        public static sbyte? ParseToSbyteNullable(this object val)
        {
            sbyte num = val.ParseToSbyte();
            if (num.Equals((sbyte)0))
            {
                return null;
            }
            return new sbyte?(num);
        }

        /// <summary>
        /// Object转换成decimal
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>decimal</returns>
        public static decimal ParseToDecimal(this object val)
        {
            return val.ParseToDecimal(0M, 2);
        }
        /// <summary>
        /// Object转换成decimal
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="decimals">小数位数</param>
        /// <returns>decimal</returns>
        public static decimal ParseToDecimal(this object val, int decimals)
        {
            return val.ParseToDecimal(0M, decimals);
        }
        /// <summary>
        /// Object转换成decimal
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns>decimal</returns>
        public static decimal ParseToDecimal(this object val, decimal defaultValue, int decimals)
        {
            decimal num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is decimal)
            {
                return Math.Round((decimal)val, decimals);
            }
            if (!decimal.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return Math.Round(num, decimals);
        }
        /// <summary>
        /// Object转换成decimal(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>decimal?</returns>
        public static decimal? ParseToDecimalNullable(this object val)
        {
            decimal num = val.ParseToDecimal();
            if (num.Equals((decimal)0.0M))
            {
                return null;
            }
            return new decimal?(num);
        }

        /// <summary>
        /// Object转换成double
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>double</returns>
        public static double ParseToDouble(this object val)
        {
            return val.ParseToDouble(0.0, 2);
        }
        /// <summary>
        /// Object转换成double
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="digits">精度小数位数</param>
        /// <returns>double</returns>
        public static double ParseToDouble(this object val, int digits)
        {
            return val.ParseToDouble(0.0, digits);
        }
        /// <summary>
        /// Object转换成double
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="digits">精度小数位数</param>
        /// <returns>double</returns>
        public static double ParseToDouble(this object val, double defaultValue, int digits)
        {
            double num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is double)
            {
                return Math.Round((double)val, digits);
            }
            if (!double.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return Math.Round(num, digits);
        }
        /// <summary>
        /// Object转换成double(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>double?</returns>
        public static double? ParseToDoubleNullable(this object val)
        {
            double num = val.ParseToDouble();
            if (num.Equals((double)0.0))
            {
                return null;
            }
            return new double?(num);
        }

        /// <summary>
        /// Object转换成float
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>float</returns>
        public static float ParseToFloat(this object val)
        {
            return val.ParseToFloat(0f);
        }
        /// <summary>
        /// Object转换成float
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>float</returns>
        public static float ParseToFloat(this object val, float defaultValue)
        {
            float num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is float)
            {
                return (float)val;
            }
            if (!float.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成float(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>float?</returns>
        public static float? ParseToFloatNullable(this object val)
        {
            float num = val.ParseToFloat();
            if (num.Equals((float)0f))
            {
                return null;
            }
            return new float?(num);
        }

        /// <summary>
        /// Object转换成Single
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>Single</returns>
        public static float ParseToSingle(this object val)
        {
            return val.ParseToSingle(0);
        }
        /// <summary>
        /// Object转换成Single
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Single</returns>
        public static float ParseToSingle(this object val, float defaultValue)
        {
            float num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is float)
            {
                return (float)val;
            }
            if (!float.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成Single(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>Single?</returns>
        public static float? ParseToSingleNullable(this object val)
        {
            float num = val.ParseToSingle();
            if (num.Equals((float)0))
            {
                return null;
            }
            return new float?(num);
        }

        /// <summary>
        /// Object转换成Guid
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>Guid</returns>
        public static Guid ParseToGuid(this object val)
        {
            Guid guid;
            if ((val == null) || (val == DBNull.Value))
            {
                return Guid.Empty;
            }
            if (val is Guid)
            {
                return (Guid)val;
            }
            if (!Guid.TryParse(val.ToString(), out guid))
            {
                return Guid.Empty;
            }
            return guid;
        }

        /// <summary>
        /// Object转换成ulong
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>ulong</returns>
        public static ulong ParseToUlong(this object val)
        {
            return val.ParseToUlong(0);
        }
        /// <summary>
        /// Object转换成ulong
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>ulong</returns>
        public static ulong ParseToUlong(this object val, ulong defaultValue)
        {
            ulong num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is long)
            {
                return (ulong)val;
            }
            if (!ulong.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成ulong(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>ulong?</returns>
        public static ulong? ParseToUlongNullable(this object val)
        {
            ulong num = val.ParseToUlong();
            if (num.Equals((ulong)0))
            {
                return null;
            }
            return new ulong?(num);
        }

        /// <summary>
        /// Object转换成ushort
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>ushort</returns>
        public static ushort ParseToUshort(this object val)
        {
            return val.ParseToUshort(0);
        }
        /// <summary>
        /// Object转换成ushort
        /// </summary>
        /// <param name="val">Object</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>ushort</returns>
        public static ushort ParseToUshort(this object val, ushort defaultValue)
        {
            ushort num;
            if ((val == null) || (val == DBNull.Value))
            {
                return defaultValue;
            }
            if (val is ushort)
            {
                return (ushort)val;
            }
            if (!ushort.TryParse(val.ToString(), out num))
            {
                return defaultValue;
            }
            return num;
        }
        /// <summary>
        /// Object转换成ushort(允许null)
        /// </summary>
        /// <param name="val">Object</param>
        /// <returns>ushort?</returns>
        public static ushort? ParseToUshortNullable(this object val)
        {
            ushort num = val.ParseToUshort();
            if (num.Equals((ushort)0))
            {
                return null;
            }
            return new ushort?(num);
        }

        /// <summary>
        /// Object转换成Byte序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ParseToByteArray(this object value)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream rems = new MemoryStream();
                formatter.Serialize(rems, value);
                return rems.GetBuffer();
            }
            catch
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// Byte序列化转换成Object
        /// </summary>
        /// <param name="value">Byte[]</param>
        /// <returns>Object</returns>
        public static object ParseToObject(this byte[] value)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream rems = new MemoryStream(value);
                return formatter.Deserialize(rems);
            }
            catch
            {
                return new object();
            }
        }
        /// <summary>
        /// Object转换
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns>Object</returns>
        public static object ParseToObject(this object value)
        {
            if (value == null) return new object();
            return value;
        }
        /// <summary>
        /// guid转Raw（oracle）
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ParseGuidToRaw16(this Guid? val)
        {
            if (val == null) return string.Empty;
            return ParseGuidToRaw16(val.ParseToGuid());
        }
        /// <summary>
        /// guid转Raw（oracle）
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ParseGuidToRaw16(this Guid val)
        {
            return BitConverter.ToString(val.ParseToGuid().ToByteArray()).Replace("-", "");
        }
        /// <summary> 
        /// 扩展方法：根据枚举值得到属性Description中的描述, 如果没有定义此属性则返回空串 
        /// </summary> 
        /// <param name="value"></param> 
        /// <param name="enumType"></param> 
        /// <returns></returns> 
        public static string ToEnumDescriptionString(this int value, Type enumType)
        {
            NameValueCollection nvc = GetNVCFromEnumValue(enumType);
            return nvc[value.ToString()];
        }

        /// <summary> 
        /// 根据枚举类型得到其所有的 值 与 枚举定义Description属性 的集合 
        /// </summary> 
        /// <param name="enumType"></param> 
        /// <returns></returns> 
        public static NameValueCollection GetNVCFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            Type typeDescription = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        strText = aa.Description;
                    }
                    else
                    {
                        strText = "";
                    }
                    nvc.Add(strValue, strText);
                }
            }
            return nvc;
        }

        /// <summary>
        /// Object转换
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>Object</returns>
        public static bool IsEmailFormat(this string emailAddress)
        {
            Regex r = new Regex("^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
            if (r.IsMatch(emailAddress))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion



    }
}
