using System;
using System.IO;
using System.Data;
using System.Xml.Serialization;

namespace MedicalSystem.AnesIcuQuery.Common
{
    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public class XmlUtil
    {
        #region 反序列化

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml) where T : class
        {
            return Deserialize(typeof(T), xml) as T;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                return e;
            }
        }


        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="fileName">XML文件路径</param>
        /// <returns></returns>
        public static object DeserializeForFileName(Type type, string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader m_streamReader = new StreamReader(fs);
                string xmltext = m_streamReader.ReadToEnd();
                m_streamReader.Close();
                fs.Close();
                return Deserialize(type, xmltext);
            }
            catch (Exception e)
            {
                return e;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();
            sr.Dispose();
            Stream.Dispose();
            return str;
        }

        #endregion

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="txt">内容</param>
        /// <param name="fileName">路径</param>
        /// <returns></returns>
        public static bool SaveFile(string text, string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(text);
                sw.Close();
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将xml文件转换为DataSet
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <returns></returns>
        public static DataSet ConvertXMLFileToDataSet(string xmlFile)
        {
            try
            {
                DataSet xmlDS = new DataSet();
                xmlDS.ReadXml(xmlFile, XmlReadMode.ReadSchema);
                return xmlDS;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将DataSet转换为xml文件
        /// </summary>
        /// <param name="xmlDS"></param>
        /// <param name="xmlFile"></param>
        public static void ConvertDataSetToXMLFile(DataSet xmlDS, string xmlFile)
        {
            try
            {
                xmlDS.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}