/**************************************************************************
模    块:        
项    目:        MedicalSystem.AnesPlatform.Domain.XmlUtil
作    者:        zhaoerye是当前登录用户名
创建时间:        2018/12/21 13:41:04
Copyright (c)    2005 麦迪斯顿(北京)医疗科技发展有限公司
修改时间：       2018/12/21 13:41:04
修 改 人：       zhaoerye
描    述：       xml文件处理
***************************************************************************/
using System;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;

namespace MedicalSystem.AnesPlatform.Domain.Utils
{
    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public class XmlUtil
    {

        public static string DEFAUT_EXCELDATA_PATH = "Config\\ExcelDataFormat.xml";

        //初始化。。。
        public XmlUtil()
        {


        }

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

        /// <summary>
        /// /
        /// </summary>
        /// <param name="fileName">要保存文件位置</param>
        /// <param name="key">要保存文件的key</param>
        /// <param name="value">要保存文件的value</param>
        /// <param name="AppPath">传入项目基本路径</param>
        /// <returns></returns>
        public static bool SaveXMLFileValue(string fileName, string key, string value, string AppPath, string nodeGroupName = "")
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string path = fileName;
            string allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path : AppPath + "\\" + path;

            XmlDocument doc = new XmlDocument();
            doc.Load(allpath);
            XmlNode root = doc.SelectSingleNode("DICT");
            XmlNodeList nodelist = root.SelectNodes("model");
            bool find = false;
            foreach (XmlNode node in nodelist)
            {
                string groupname = node.SelectSingleNode("groupname").InnerText;
                if (groupname == nodeGroupName) { 
                {
                    XmlNodeList subnodelist = node.SelectNodes("group");
                    foreach (XmlNode subnode in subnodelist)
                    {
                        if (subnode.SelectSingleNode("key").InnerText.Equals(key))
                        {
                            subnode.SelectSingleNode("value").InnerText = value;
                            find = true;
                            break;
                        }
                    }
                 
                }
                if (find)
                {
                    break;
                }
            }
            }
            ///如果xml中不存在现有节点就插入一个新的节点
            //另外插入时 一个xml 中有很多的 groupname 组  具体插入哪个组中需要根据传入的 nodeGroupName  循环遍历 ，如果传入的nodeGroupName 为空，默认插入第一个节点 
            if (!find)
            {
                if (String.IsNullOrEmpty(nodeGroupName))
                {
                    XmlNode node = nodelist[0];
                    XmlNode newNode = doc.CreateElement("group");
                    XmlNode newNode1 = doc.CreateElement("key");
                    XmlNode newNode2 = doc.CreateElement("value");
                    XmlNode newNode3 = doc.CreateElement("isShow");
                    newNode1.InnerText = key;
                    newNode2.InnerText = value;
                    newNode3.InnerText = "true";
                    newNode.AppendChild(newNode1);
                    newNode.AppendChild(newNode2);
                    newNode.AppendChild(newNode3);
                    node.AppendChild(newNode);
                }
                else
                {
                    foreach (XmlNode node in nodelist)
                    {
                        string groupname = node.SelectSingleNode("groupname").InnerText;
                        if (groupname.Equals(nodeGroupName))
                        {
                            XmlNode newNode = doc.CreateElement("group");
                            XmlNode newNode1 = doc.CreateElement("key");
                            XmlNode newNode2 = doc.CreateElement("value");
                            XmlNode newNode3 = doc.CreateElement("isShow");
                            newNode1.InnerText = key;
                            newNode2.InnerText = value;
                            newNode3.InnerText = "true";
                            newNode.AppendChild(newNode1);
                            newNode.AppendChild(newNode2);
                            newNode.AppendChild(newNode3);
                            node.AppendChild(newNode);
                        }
                    }
                }
            }
            doc.Save(allpath);
            return true;
        }


        /// <summary>
        /// /
        /// </summary>
        /// <param name="fileName">要保存文件位置</param>
        /// <param name="key">要保存文件的key</param>
        /// <param name="value">要保存文件的value</param>
        /// <param name="AppPath">传入项目基本路径</param>
        /// <returns></returns>
        public static bool UpdateModeleExecleItemVisibility(string fileName, string key, bool isShow, string AppPath, string nodeGroupName = "")
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string path = fileName;
            string allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path : AppPath + "\\" + path;

            XmlDocument doc = new XmlDocument();
            doc.Load(allpath);
            XmlNode root = doc.SelectSingleNode("DICT");
            XmlNodeList nodelist = root.SelectNodes("model");
            bool find = false;
            XmlNode searchNode = null;
            foreach (XmlNode node in nodelist)
            {
                string groupname = node.SelectSingleNode("groupname").InnerText;
                if (groupname == nodeGroupName)
                {
                    {
                        XmlNodeList subnodelist = node.SelectNodes("group");
                        foreach (XmlNode subnode in subnodelist)
                        {
                            if (subnode.SelectSingleNode("key").InnerText.Equals(key))
                            {
                              
                                find = true;
                                searchNode = subnode;
                                break;
                            }
                        }

                    }
                    if (find)
                    {
                        bool isShowNode = false;
                        foreach (XmlNode subnode in searchNode.ChildNodes)
                        {
                            if (subnode.Name.Equals("isShow"))
                            {
                                subnode.InnerText = isShow ? "true" : "false";
                                isShowNode = true;
                            }
                        }
                        if (!isShowNode)
                        {
                            XmlNode newNode1 = doc.CreateElement("isShow");
                            newNode1.InnerText = isShow ? "true" : "false";
                            searchNode.AppendChild(newNode1);
                        }
                        break;
                    }
                }
            }
          
            doc.Save(allpath);
            return true;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="fileName">要保存文件位置</param>
        /// <param name="key">要保存文件的key</param>
        /// <param name="value">要保存文件的value</param>
        /// <param name="AppPath">传入项目基本路径</param>
        /// <returns></returns>
        public static bool SaveXMLFileValue(string fileName, string key, string value, bool isShow, string AppPath, string nodeGroupName = "")
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string path = fileName;
            string allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path : AppPath + "\\" + path;

            XmlDocument doc = new XmlDocument();
            doc.Load(allpath);
            XmlNode root = doc.SelectSingleNode("DICT");
            XmlNodeList nodelist = root.SelectNodes("model");
            bool find = false;
            XmlNode searchNode = null;
            foreach (XmlNode node in nodelist)
            {
                string groupname = node.SelectSingleNode("groupname").InnerText;
                if (groupname == nodeGroupName)
                {
                    {
                        XmlNodeList subnodelist = node.SelectNodes("group");
                     
                        foreach (XmlNode subnode in subnodelist)
                        {
                            if (subnode.SelectSingleNode("key").InnerText.Equals(key))
                            {
                                subnode.SelectSingleNode("value").InnerText = value;
                                find = true;
                                searchNode = subnode;
                                break;
                            }
                        }

                    }
                    if (find)
                    {
                        bool isShowNode = false;
                        foreach (XmlNode subnode in searchNode.ChildNodes)
                        {
                            if (subnode.Name.Equals("isShow"))
                            {
                                subnode.InnerText = isShow ? "true" : "false";
                                isShowNode = true;
                            }
                        }
                        if (!isShowNode)
                        {
                            XmlNode newNode1 = doc.CreateElement("isShow");
                            newNode1.InnerText = isShow ? "true" : "false";
                            searchNode.AppendChild(newNode1);
                        }
                        break;
                    }
                }
            }
            ///如果xml中不存在现有节点就插入一个新的节点
            //另外插入时 一个xml 中有很多的 groupname 组  具体插入哪个组中需要根据传入的 nodeGroupName  循环遍历 ，如果传入的nodeGroupName 为空，默认插入第一个节点 
            if (!find)
            {
                if (String.IsNullOrEmpty(nodeGroupName))
                {
                    XmlNode node = nodelist[0];
                    XmlNode newNode = doc.CreateElement("group");
                    XmlNode newNode1 = doc.CreateElement("key");
                    XmlNode newNode2 = doc.CreateElement("value");
                    XmlNode newNode3 = doc.CreateElement("isShow");
  
                    newNode1.InnerText = key;
                    newNode2.InnerText = value;
                    newNode3.InnerText = isShow ? "true" : "false";
                    newNode.AppendChild(newNode1);
                    newNode.AppendChild(newNode2);
                    newNode.AppendChild(newNode3);
                    node.AppendChild(newNode);
                }
                else
                {
                    foreach (XmlNode node in nodelist)
                    {
                        string groupname = node.SelectSingleNode("groupname").InnerText;
                        if (groupname.Equals(nodeGroupName))
                        {
                            XmlNode newNode = doc.CreateElement("group");
                            XmlNode newNode1 = doc.CreateElement("key");
                            XmlNode newNode2 = doc.CreateElement("value");
                            XmlNode newNode3 = doc.CreateElement("isShow");
                            newNode1.InnerText = key;
                            newNode2.InnerText = value;
                            newNode3.InnerText = isShow ? "true" : "false";
                            newNode.AppendChild(newNode1);
                            newNode.AppendChild(newNode2);
                            node.AppendChild(newNode);
                        }
                    }
                }
            }
            doc.Save(allpath);
            return true;
        }


        public static bool DeleteXMLFileAndGroupName(string fileName, string GroupName, string AppPath)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();

            string path = fileName;

            string allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path  : AppPath + "\\" + path;

            XmlDocument doc = new XmlDocument();
            doc.Load(allpath);
            XmlNode root = doc.SelectSingleNode("DICT");
            XmlNodeList nodelist = root.SelectNodes("model");
            foreach (XmlNode node in nodelist)
            {
                string groupname = node.SelectSingleNode("groupname").InnerText;
                if (groupname == GroupName)
                {
                    root.RemoveChild(node);

                }

            }
            doc.Save(allpath);
            return true;

        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="key"></param>
        /// <param name="AppPath"></param>
        /// <returns></returns>
        public static bool DeleteXMLFileKey(string fileName, string key, string AppPath)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string path = fileName;

            string allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path : AppPath + "\\" + path;

            XmlDocument doc = new XmlDocument();
            doc.Load(allpath);
            XmlNode root = doc.SelectSingleNode("DICT");
            XmlNodeList nodelist = root.SelectNodes("model");
            foreach (XmlNode node in nodelist)
            {
                string groupname = node.SelectSingleNode("groupname").InnerText;
                //if (groupname == nodeText)
                {
                    XmlNodeList subnodelist = node.SelectNodes("group");
                    XmlNode deletingNode = null;
                    foreach (XmlNode subnode in subnodelist)
                    {
                        if (subnode.SelectSingleNode("key").InnerText.Equals(key))
                        {
                            deletingNode = subnode;
                            break;
                        }
                    }
                    if (deletingNode != null)
                    {
                        node.RemoveChild(deletingNode);
                        break;
                    }
                }
            }
            doc.Save(allpath);
            return true;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="AppPath"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadXMLFromFile(string fileName, string AppPath)
        {

            return ReadXMLFromFileWithGroupName(fileName, AppPath, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="AppPath"></param>
        /// <param name="nodeGroupName">某一个组中的</param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadXMLFromFileWithGroupName(string fileName, string AppPath, string nodeGroupName = "")
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string path = fileName;

            string allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path : AppPath + "\\" + path;

            XmlDocument doc = new XmlDocument();
            doc.Load(allpath);
            XmlNode root = doc.SelectSingleNode("DICT");
            XmlNodeList nodelist = root.SelectNodes("model");

            //nodeGroupName 为空时  查询第一个节点的组
            if (String.IsNullOrEmpty(nodeGroupName))
            {
                XmlNode node = nodelist[0];
                XmlNodeList subnodelist = node.SelectNodes("group");
                foreach (XmlNode subnode in subnodelist)
                {
                    if (!dic.ContainsKey(subnode.SelectSingleNode("key").InnerText))
                    {
                        dic.Add(subnode.SelectSingleNode("key").InnerText, subnode.SelectSingleNode("value").InnerText);
                    }
                }
            }
            else
            {
                foreach (XmlNode node in nodelist)
                {
                    string groupname = node.SelectSingleNode("groupname").InnerText;
                    if (groupname.Equals(nodeGroupName))
                    {
                        XmlNodeList subnodelist = node.SelectNodes("group");
                        foreach (XmlNode subnode in subnodelist)
                        {
                            if (!dic.ContainsKey(subnode.SelectSingleNode("key").InnerText))
                            {
                                dic.Add(subnode.SelectSingleNode("key").InnerText, subnode.SelectSingleNode("value").InnerText);
                            }
                        }
                    }
                }
            }



            return dic;

        }

        public static void InsertGroupNameToExcelModelXML(string groupName, string AppPath, string Path = "Config\\ExcelDataFormat.xml")
        {

            XmlDocument doc = new XmlDocument();

            doc.Load(getAllpath(AppPath, Path));
            XmlNode root = doc.SelectSingleNode("DICT");
            XmlNodeList nodelist = root.SelectNodes("model");
            //先判断现有的xml 中是否有包含 groupname 的节点
            bool isHave = false;
            foreach (XmlNode node in nodelist)
            {
                string groupname = node.SelectSingleNode("groupname").InnerText;
                if (groupName.Equals(groupname))
                {
                    isHave = true;
                    break;
                }

            }
            if (!isHave)
            {
                XmlNode newNode = doc.CreateElement("model");
                XmlNode newNode1 = doc.CreateElement("groupname");
                newNode1.InnerText = groupName;
                newNode.AppendChild(newNode1);
                root.AppendChild(newNode);

            }
            doc.Save(getAllpath(AppPath, Path));

        }

        private static string getAllpath(string AppBasePath, string Path)
        {
            string allpath = "";
            if (string.IsNullOrEmpty(Path))
            {
                string path = XmlUtil.DEFAUT_EXCELDATA_PATH;
                allpath = AppBasePath[AppBasePath.Length - 1] == '\\' ? AppBasePath + path : AppBasePath + "\\" + path;


            } else {
                allpath = AppBasePath+ Path;
            } 
          
            return allpath;
        }



        public static void InsertGroupNameToExcelModeelXML(string GroupName, string AppPath)
        {
            InsertGroupNameToExcelModelXML(GroupName, AppPath, null);
        }

        /// <summary>
        /// 读取  xml   nodeText节点下的值
        /// </summary>
        /// <param name="nodeText"></param>
        /// <param name="AppPath"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadXML(string nodeText, string AppPath)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            // string AppPath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);
            string path = "config\\AAAStatistics.xml";

            string allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path : AppPath + "\\" + path;

            XmlDocument doc = new XmlDocument();

            if (!File.Exists(allpath))
            {
                path = "config\\datafile\\AAAStatistics.xml";
                allpath = AppPath[AppPath.Length - 1] == '\\' ? AppPath + path : AppPath + "\\" + path;
                doc.Load(allpath);
            }



            XmlNode root = doc.SelectSingleNode("AAA");
            XmlNodeList nodelist = root.SelectNodes("model");
            foreach (XmlNode node in nodelist)
            {
                string groupname = node.SelectSingleNode("groupname").InnerText;
                if (groupname == nodeText)
                {
                    XmlNodeList subnodelist = node.SelectNodes("group");
                    foreach (XmlNode subnode in subnodelist)
                    {
                        dic.Add(subnode.SelectSingleNode("key").InnerText, subnode.SelectSingleNode("value").InnerText);
                    }
                    break;
                }
            }
            return dic;
        }


    }
}