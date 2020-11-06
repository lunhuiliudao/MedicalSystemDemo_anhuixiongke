using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    [XmlRoot("DICT")]
    public class QcDictXMLHelper
    {
        public class QcDictModel
        {
            [XmlElement("groupname")]
            public string GroupName
            {
                get;
                set;
            }

            [XmlElement("group")]
            public System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup> Group
            {
                get;
                set;
            }
        }

        public class QcDictGroup
        {
            [XmlElement("key")]
            public string Key
            {
                get;
                set;
            }

            [XmlElement("keyname")]
            public string KeyName
            {
                get;
                set;
            }

            [XmlElement("value")]
            public string Value
            {
                get;
                set;
            }

            [XmlElement("valuename")]
            public string ValueName
            {
                get;
                set;
            }
        }

        [XmlElement("model")]
        public System.Collections.Generic.List<QcDictXMLHelper.QcDictModel> Model
        {
            get;
            set;
        }

        [XmlIgnore]
        public System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup> Group
        {
            get
            {
                if (this.Model == null)
                {
                    return null;
                }
                return this.Model.SelectMany((QcDictXMLHelper.QcDictModel x) => x.Group).ToList<QcDictXMLHelper.QcDictGroup>();
            }
        }

        public System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup> GetGroups(string groupname)
        {
            if (this.Model != null)
            {
                return (from x in this.Model
                        where x.GroupName == groupname
                        select x.Group).FirstOrDefault<System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup>>();
            }
            return null;
        }

        public string GetValue(string key)
        {
            if (!string.IsNullOrEmpty(key) && key.Contains("\r\n"))
            {
                key = key.Split(new string[]
                {
                    "\r\n"
                }, System.StringSplitOptions.None)[1];
            }
            if (this.Group != null)
            {
                return (from x in this.Group
                        where x.Key == key
                        select x.Value).FirstOrDefault<string>();
            }
            return null;
        }

        public bool ExistsKey(string key)
        {
            if (!string.IsNullOrEmpty(key) && key.Contains("\r\n"))
            {
                key = key.Split(new string[]
                {
                    "\r\n"
                }, System.StringSplitOptions.None)[1];
            }
            if (this.Group != null)
            {
                return this.Group.Exists((QcDictXMLHelper.QcDictGroup x) => x.Key == key);
            }
            return false;
        }

        public void SetValue(string key,string keyname, string value,string valuename)
        {
            if (this.Group != null)
            {
                System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup> list = (from x in this.Group
                                                                                     where x.Key == key
                                                                                     select x).ToList<QcDictXMLHelper.QcDictGroup>();
                if (list != null && list[0].Key == key)
                {
                    list[0].KeyName = keyname;

                    list[0].Value = value;

                    list[0].ValueName = valuename;
                }
            }
        }

        public string XmlPath
        {
            get;
            set;
        }

        public System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup> GetGroupByName(string groupname)
        {
            System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup> result;
            try
            {
                QcDictXMLHelper dictXML = this.GetDictXML(this.XmlPath);
                if (dictXML != null && dictXML.Model != null)
                {
                    result = (from x in dictXML.Model
                              where x.GroupName == groupname
                              select x.Group).FirstOrDefault<System.Collections.Generic.List<QcDictXMLHelper.QcDictGroup>>();
                }
                else
                {
                    result = null;
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.InnerException.Message, ex);
            }
            return result;
        }


        public QcDictXMLHelper GetDictXML(string path)
        {
            QcDictXMLHelper result;
            try
            {
                string xml = System.IO.File.ReadAllText(path);
                QcDictXMLHelper dictXML = Deserialize<QcDictXMLHelper>(xml);
                result = dictXML;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.InnerException.Message, ex);
            }
            return result;
        }


        public static T Deserialize<T>(string xml) where T : class
        {
            return Deserialize(typeof(T), xml) as T;
        }

        private static object Deserialize(System.Type type, string xml)
        {
            object result;
            try
            {
                using (System.IO.StringReader stringReader = new System.IO.StringReader(xml))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(type);
                    result = xmlSerializer.Deserialize(stringReader);
                }
            }
            catch (System.Exception ex)
            {
                result = ex;
            }
            return result;
        }

        public bool SaveDataFormatDict(QcDictXMLHelper dictXml)
        {
            bool result;
            try
            {
                string contents = Serializer(typeof(QcDictXMLHelper), dictXml);
                System.IO.File.WriteAllText(this.XmlPath, contents);
                result = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.InnerException.Message, ex);
            }
            return result;
        }

        public static string Serializer(System.Type type, object obj)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            try
            {
                xmlSerializer.Serialize(memoryStream, obj);
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
            memoryStream.Position = 0L;
            System.IO.StreamReader streamReader = new System.IO.StreamReader(memoryStream);
            string result = streamReader.ReadToEnd();
            streamReader.Dispose();
            memoryStream.Dispose();
            return result;
        }
    }
}
