/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：AssemblyHelper.cs
      // 文件功能描述：程序集辅助类
      //
      // 
      // 创建标识：戴呈祥-2008-10-30
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Runtime.Serialization.Json;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 程序集辅助类
    /// </summary>
    public class AssemblyHelper
    {
        private static string AllowNullToString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        public static string GetTextUnit(object textUnitObject)
        {
            string text = "";
            PropertyInfo propertyInfo = textUnitObject.GetType().GetProperty("Text");
            if (propertyInfo != null)
            {
                text = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
            }
            if (text == null)
            {
                text = "";
            }
            string unit = "";
            propertyInfo = textUnitObject.GetType().GetProperty("Unit");
            if (propertyInfo != null)
            {
                unit = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
            }
            if (!string.IsNullOrEmpty(unit))
            {
                text += "(" + unit + ")";
            }
            string speedUnit = "";
            propertyInfo = textUnitObject.GetType().GetProperty("SpeedUnit");
            if (propertyInfo != null)
            {
                speedUnit = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
            }
            if (!string.IsNullOrEmpty(speedUnit))
            {
                text += "(" + speedUnit + ")";
            }
            string route = "";
            propertyInfo = textUnitObject.GetType().GetProperty("Route");
            if (propertyInfo != null)
            {
                route = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
            }
            if (!string.IsNullOrEmpty(route))
            {
                text += "(" + route + ")";
            }
            return text;
        }

        /// <summary>
        /// 从名称获得对象
        /// </summary>
        /// <param name="assembly">所属程序集</param>
        /// <param name="objectName">对象名称</param>
        /// <returns>对象</returns>
        public static object GetObjectFromName(Assembly assembly, string objectName)
        {
            object obj = null;
            if (objectName != null && !objectName.Trim().Equals(""))
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.Name.ToLower().Equals(objectName.ToLower()))
                    {
                        obj = assembly.CreateInstance(type.FullName);
                        break;
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// 从名称获得控件
        /// </summary>
        /// <param name="assembly">所属程序集</param>
        /// <param name="controlName">控件名称</param>
        /// <returns>控件</returns>
        public static Control GetControlFromName(Assembly assembly, string controlName)
        {
            object obj = GetObjectFromName(assembly, controlName);
            if (obj != null && obj is Control)
            {
                return obj as Control;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 从名称获得控件
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <returns>控件</returns>
        public static Control GetControlFromName(string controlName)
        {
            return GetControlFromName(Assembly.GetExecutingAssembly(), controlName);
        }

        public static Color ColorFromString(object value)
        {
            if (value is Color) return (Color)value;
            else
            {
                string valueString = value.ToString();
                if (string.IsNullOrEmpty(valueString))
                {
                    return Color.Black;
                }
                else
                {
                    if (valueString.StartsWith("Color["))
                    {
                        valueString = valueString.Remove(0, 6).Replace("]", "");
                    }
                    Color color = Color.FromName(valueString);
                    if (color.A == 0 && color.B == 0 && color.G == 0 && color.R == 0)
                    {
                        color = Color.FromArgb(Convert.ToInt32("0x" + value, 16));
                    }
                    return color;
                }
            }
        }

        public static string ConvertFontToString(Font font)
        {
            return font.ToString() + font.Style.ToString();
        }

        public static Font ConvertStringToFont(string fontString)
        {
            int index = fontString.LastIndexOf("]");
            if (index > 0 && index < fontString.Length)
            {
                string fontStr = fontString.Substring(0, index);
                string fontStyleStr = fontString.Substring(index + 1);

                return ConvertStringToFont(fontStr, fontStyleStr);
            }
            else
            {
                return ConvertStringToFont(fontString, "Regular");
            }
        }

        public static Font ConvertStringToFont(string fontString, string fontStyle)
        {
            Font Result;
            if (fontString.Length == 0)
            {
                Result = new Font("宋体", 17);
                return Result;
            }
            string FontName = string.Empty;
            float FontSize = 0;
            GraphicsUnit FontGraphicsUnit = GraphicsUnit.Millimeter;
            byte FontGdiCharSet = 0;
            bool FontGdiVerticalFont = false;
            string[] PropertyList = fontString.Replace("[Font: ", "").Replace("]", "").Split(new char[] { ',' });
            foreach (string Property in PropertyList)
            {
                string[] ValueList = Property.Split(new char[] { '=' });
                switch (ValueList[0].Trim())
                {
                    case "Name":
                        FontName = ValueList[1];
                        break;
                    case "Size":
                        FontSize = float.Parse(ValueList[1]);
                        break;
                    case "Units":
                        FontGraphicsUnit = (GraphicsUnit)System.Enum.Parse(typeof(GraphicsUnit), ValueList[1], true);
                        break;
                    case "GdiCharSet":
                        FontGdiCharSet = byte.Parse(ValueList[1]);
                        break;
                    case "GdiVerticalFont":
                        FontGdiVerticalFont = bool.Parse(ValueList[1]);
                        break;
                }
            }
            FontStyle FontStyle1;
            try
            {
                FontStyle1 = (FontStyle)System.Enum.Parse(typeof(FontStyle), fontStyle, true);
            }
            catch
            {
                FontStyle1 = FontStyle.Regular;
            }
            Result = new Font(FontName, FontSize, FontStyle1, FontGraphicsUnit, FontGdiCharSet, FontGdiVerticalFont);
            return Result;
        }

        public static void SetPropertyValue(PropertyInfo propertyInfo, object obj, object newValue)
        {
            if (propertyInfo == null) return;
            object value = null;
            if (newValue != null)
            {
                string valueString = newValue.ToString();
                if (propertyInfo.PropertyType.Equals(typeof(Color)))
                {
                    value = ColorFromString(newValue);
                }
                else if (propertyInfo.PropertyType.Equals(typeof(Font)))
                {
                    if (newValue is Font)
                    {
                        value = newValue;
                    }
                    else
                    {
                        value = ConvertStringToFont(valueString);
                    }
                }
                else if (propertyInfo.PropertyType.Equals(typeof(Image)))
                {
                    if (newValue is Image)
                    {
                        value = newValue;
                    }
                    else
                    {
                        value = Image.FromStream(Sundries.DecodeWithString(valueString));
                    }
                }
                else if (propertyInfo.PropertyType.IsEnum)
                {
                    value = Enum.Parse(propertyInfo.PropertyType, valueString);
                }
                else if (propertyInfo.PropertyType.Equals(typeof(string)))
                {
                    value = valueString;
                }
                //else if (propertyInfo.PropertyType.IsGenericType)
                //{

                //}
                else
                {
                    Type type = propertyInfo.PropertyType;
                    MethodInfo method = type.GetMethod("Parse", new Type[] { typeof(string) });
                    if (method != null)
                    {
                        value = method.Invoke(null, new object[] { valueString });
                    }
                }
            }
            propertyInfo.SetValue(obj, value, null);
        }

        public static object GetPropertyValue(PropertyInfo propertyInfo, object obj)
        {
            object value = propertyInfo.GetValue(obj, null);
            if (value != null)
            {
                if (propertyInfo.PropertyType.Name.Equals("Color"))
                {
                    value = ((Color)value).Name;
                }
                else if (propertyInfo.PropertyType.Name.Equals("Font"))
                {
                    value = ConvertFontToString((Font)value);
                }
                else if (propertyInfo.PropertyType.Name.Equals("Image"))
                {
                    value = Sundries.EncodeWithString(FileHelper.ImageToStream(value as Image));
                }
                //else if (propertyInfo.PropertyType.IsGenericType)
                //{
                //    Type objType = value.GetType();

                //    int count = Convert.ToInt32(objType.GetProperty("Count").GetValue(value, null));

                //    object listItem = objType.GetProperty("Item").GetValue(value, new object[] { 0 });

                //    Array result = Array.CreateInstance(listItem.GetType(), count);
                //    for (int i = 0; i < count; i++)
                //    {
                //        listItem = objType.GetProperty("Item").GetValue(value, new object[] { 0 });

                //        result.SetValue(listItem, i);
                //    }
                //    return result;
                //}
                else
                {
                    value = value.ToString();
                }
            }
            return value;
        }

        public static List<MemberDetail> GetMemberList(Type type, MemberTypes memberType, bool wantDescriptionAttribute)
        {
            MemberInfo[] memberInfos = type.GetMembers();
            List<MemberDetail> enumList = new List<MemberDetail>();
            foreach (MemberInfo memberInfo in memberInfos)
            {
                if (memberInfo.MemberType == memberType)
                {
                    object[] objs = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (objs != null && objs.Length > 0)
                    {
                        enumList.Add(new MemberDetail(((DescriptionAttribute)objs[0]).Description, memberInfo.Name, type));
                    }
                    else
                    {
                        if (!wantDescriptionAttribute)
                        {
                            enumList.Add(new MemberDetail(memberInfo.Name, memberInfo.Name, type));
                        }
                    }
                }
            }
            return enumList;
        }

        public static List<MemberDetail> GetPropertyList(Type type)
        {
            return GetPropertyList(type, false);
        }

        public static List<MemberDetail> GetPropertyList(Type type, bool wantDescriptionAttribute)
        {
            return GetMemberList(type, MemberTypes.Property, wantDescriptionAttribute);
        }

        public static string GetEnumDescription(Enum enumValue)
        {
            List<MemberDetail> list = GetEnumList(enumValue.GetType());
            foreach (MemberDetail member in list)
            {
                if (member.Value.ToString().Equals(enumValue.ToString()))
                {
                    return member.Name;
                }
            }
            return enumValue.ToString();
        }

        public static List<MemberDetail> GetEnumList(Type type)
        {
            return GetEnumList(type, false);
        }

        public static List<MemberDetail> GetEnumList(Type type, bool wantDescriptionAttribute)
        {
            List<MemberDetail> list = GetMemberList(type, MemberTypes.Field, wantDescriptionAttribute);
            foreach (MemberDetail member in list)
            {
                if (member.Value.Equals("value__"))
                {
                    list.Remove(member);
                    break;
                }
            }
            foreach (MemberDetail member in list)
            {
                member.Value = Enum.Parse(type, member.Value.ToString());
            }
            return list;
        }

        public static object GetValueFromString(Type type, string valueString)
        {
            if (type.Equals(typeof(string)))
            {
                return valueString;
            }
            else
            {
                object value;
                MethodInfo method = type.GetMethod("Parse", new Type[] { typeof(string) });
                if (method != null)
                {
                    try
                    {
                        value = method.Invoke(null, new object[] { valueString });
                    }
                    catch
                    {
                        value = GetDefaultValue(type);
                    }
                }
                else
                {
                    value = new object();
                }
                return value;
            }
        }

        public static object GetDefaultValue(Type type)
        {
            object value;
            if (type == typeof(string))
            {
                value = "";
            }
            else if (type == typeof(double))
            {
                value = default(double);
            }
            else if (type == typeof(int))
            {
                value = default(int);
            }
            else if (type == typeof(Single))
            {
                value = default(Single);
            }
            else if (type == typeof(decimal))
            {
                value = default(decimal);
            }
            else if (type == typeof(DateTime))
            {
                value = DateTime.Now;
            }
            else
            {
                value = new object();
            }
            return value;
        }

        private static object ReadInstanceDescriptor(XmlNode node, ArrayList errors)
        {
            XmlAttribute memberAttr = node.Attributes["member"];

            if (memberAttr == null)
            {
                errors.Add("No member attribute on instance descriptor");
                return null;
            }

            byte[] data = Convert.FromBase64String(memberAttr.Value);
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(data);
            MemberInfo mi = (MemberInfo)formatter.Deserialize(stream);
            object[] args = null;

            if (mi is MethodBase)
            {
                ParameterInfo[] paramInfos = ((MethodBase)mi).GetParameters();

                args = new object[paramInfos.Length];

                int idx = 0;

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name.Equals("Argument"))
                    {
                        object value;

                        if (!ReadValue(child, TypeDescriptor.GetConverter(paramInfos[idx].ParameterType), errors, out value))
                        {
                            return null;
                        }

                        args[idx++] = value;
                    }
                }

                if (idx != paramInfos.Length)
                {
                    errors.Add(string.Format("Member {0} requires {1} arguments, not {2}.", mi.Name, args.Length, idx));
                    return null;
                }
            }

            InstanceDescriptor id = new InstanceDescriptor(mi, args);
            object instance = id.Invoke();

            foreach (XmlNode prop in node.ChildNodes)
            {
                if (prop.Name.Equals("Property"))
                {
                    ReadProperty(prop, instance, errors);
                }
            }

            return instance;
        }

        private static bool GetConversionSupported(TypeConverter converter, Type conversionType)
        {
            return (converter.CanConvertFrom(conversionType) && converter.CanConvertTo(conversionType));
        }

        private static bool ReadValue(XmlNode node, TypeConverter converter, ArrayList errors, out object value)
        {
            try
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.NodeType == XmlNodeType.Text)
                    {
                        value = converter.ConvertFromInvariantString(node.InnerText);
                        return true;
                    }
                    else if (child.Name.Equals("Binary"))
                    {
                        byte[] data = Convert.FromBase64String(child.InnerText);

                        if (GetConversionSupported(converter, typeof(byte[])))
                        {
                            value = converter.ConvertFrom(null, CultureInfo.InvariantCulture, data);
                            return true;
                        }
                        else
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            MemoryStream stream = new MemoryStream(data);

                            value = formatter.Deserialize(stream);
                            return true;
                        }
                    }
                    else if (child.Name.Equals("InstanceDescriptor"))
                    {
                        value = ReadInstanceDescriptor(child, errors);
                        return (value != null);
                    }
                    else
                    {
                        errors.Add(string.Format("Unexpected element type {0}", child.Name));
                        value = null;
                        return false;
                    }
                }

                value = null;
                return true;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                value = null;
                return false;
            }
        }

        private static void ReadProperty(XmlNode node, object instance, ArrayList errors)
        {
            XmlAttribute nameAttr = node.Attributes["name"];

            if (nameAttr == null)
            {
                //errors.Add("Property has no name");
                //Logger.Write(string.Format("Property has no name", nameAttr.Value, instance.GetType().FullName));
                return;
            }

            PropertyDescriptor prop = TypeDescriptor.GetProperties(instance)[nameAttr.Value];

            if (nameAttr.Value.ToString().Equals("ColumnHeadersDefaultCellStyle"))
            {

            }
            if (prop == null)
            {
                //errors.Add(string.Format("Property {0} does not exist on {1}", nameAttr.Value, instance.GetType().FullName));
                //Logger.Write(string.Format("Property {0} does not exist on {1}", nameAttr.Value, instance.GetType().FullName));
                return;
            }

            bool isContent = prop.Attributes.Contains(DesignerSerializationVisibilityAttribute.Content);

            if (isContent)
            {
                object value = prop.GetValue(instance);

                if (value is IList)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.Equals("Item"))
                        {
                            object item;
                            XmlAttribute typeAttr = child.Attributes["type"];

                            if (typeAttr == null)
                            {
                                errors.Add("Item has no type attribute");
                                continue;
                            }

                            Type type = Type.GetType(typeAttr.Value);

                            if (type == null)
                            {
                                errors.Add(string.Format("Item type {0} could not be found.", typeAttr.Value));
                                continue;
                            }

                            if (ReadValue(child, TypeDescriptor.GetConverter(type), errors, out item))
                            {
                                try
                                {
                                    ((IList)value).Add(item);
                                }
                                catch (Exception ex)
                                {
                                    errors.Add(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            errors.Add(string.Format("Only Item elements are allowed in collections, not {0} elements.", child.Name));
                        }
                    }
                }
                else
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.Equals("Property"))
                        {
                            ReadProperty(child, value, errors);
                        }
                        else
                        {
                            errors.Add(string.Format("Only Property elements are allowed in content properties, not {0} elements.", child.Name));
                        }
                    }
                }
            }
            else
            {
                object value;

                if (ReadValue(node, prop.Converter, errors, out value))
                {
                    try
                    {
                        prop.SetValue(instance, value);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex.Message);
                    }
                }
            }
        }
        static Dictionary<string, Type> _typeCache = new Dictionary<string, Type>();

        public static object ReadObject(XmlNode node, ArrayList errors, object myinstance)
        {
            XmlAttribute typeAttr = node.Attributes["type"];

            if (typeAttr == null)
            {
                return null;
            }
            Type type = null;
            if (_typeCache.ContainsKey(typeAttr.Value))
                type = _typeCache[typeAttr.Value];
            else
            {
                type = Type.GetType(typeAttr.Value);
                _typeCache[typeAttr.Value] = type;
            }
            if (type == null)
            {
                return null;
            }
            XmlAttribute nameAttr = node.Attributes["name"];
            object instance;

            if (myinstance != null)
            {
                if (myinstance is IDesignerLoaderHost)
                {
                    if (nameAttr == null)
                    {
                        instance = (myinstance as IDesignerLoaderHost).CreateComponent(type);
                    }
                    else
                    {
                        instance = (myinstance as IDesignerLoaderHost).CreateComponent(type, nameAttr.Value);
                    }
                }
                else if (type.Equals(typeof(MedicalSystem.Anes.Document.Designer.ReportViewProperties)))
                {
                    //instance = Activator.CreateInstance(type);
                    instance = new MedicalSystem.Anes.Document.Designer.ReportViewProperties();
                    if ((myinstance as MedReportView) != null)
                        (myinstance as MedReportView).AddComponent(instance as MedicalSystem.Anes.Document.Designer.ReportViewProperties);
                }
                else
                {
                    instance = myinstance;
                }
            }
            //if(type.Equals(typeof(Form)))
            //{
            //    instance = this;
            //}
            else
            {
                instance = Activator.CreateInstance(type);
            }


            XmlAttribute childAttr = node.Attributes["children"];
            IList childList = null;

            if (childAttr != null)
            {
                PropertyDescriptor childProp = TypeDescriptor.GetProperties(instance)[childAttr.Value];

                if (childProp == null)
                {
                    //Logger.Write(string.Format("The children attribute lists {0} as the child collection but this is not a property on {1}", childAttr.Value, instance.GetType().FullName));

                }
                else
                {
                    childList = childProp.GetValue(instance) as IList;
                    if (childList == null)
                    {
                        //Logger.Write(string.Format("The property {0} was found but did not return a valid IList", childProp.Name));
                        //errors.Add(string.Format("The property {0} was found but did not return a valid IList", childProp.Name));
                    }
                }
            }


            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name.Equals("Object"))
                {
                    if (childAttr == null)
                    {
                        //errors.Add("Child object found but there is no children attribute");
                        //Logger.Write("Child object found but there is no children attribute");
                        continue;
                    }

                    if (childList != null)
                    {
                        object childInstance;
                        if (myinstance is IDesignerLoaderHost)
                        {
                            childInstance = ReadObject(childNode, errors, myinstance);
                            childList.Add(childInstance);
                        }
                        else
                        {
                            try
                            {
                                //DateTime a = DateTime.Now;
                                childInstance = ReadObject(childNode, errors, null);
                                //DateTime b = DateTime.Now;
                                //TimeSpan d = b - a;
                                //Logger.Write(string.Format("{1} childInstance = ReadObject(childNode, errors, null);; 共用时{0}秒", d.TotalSeconds, childInstance.GetType().FullName));
                                childList.Add(childInstance);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.Print(ex.StackTrace);
                            }
                        }
                        //DateTime ss = DateTime.Now;
                        if ((instance as Control).Name == "MedReportView")
                        {
                            //DateTime ss1 = DateTime.Now;
                            //MedReportView aa = new MedReportView();
                            //aa.Controls.Add(childInstance as Control);
                            //DateTime ss2 = DateTime.Now;
                            //TimeSpan s3 = ss2 - ss1;
                            //Form aas = new Form();
                            //aa.Dock = DockStyle.Fill;

                            //aas.Controls.Add(aa);
                            //aas.WindowState = FormWindowState.Maximized;
                            //aas.ShowDialog();
                            //Logger.Write(string.Format("{3} {1} {2} aa.Controls.Add(childInstance as Control);; 共用时{0}秒", s3.TotalSeconds, childInstance.GetType().FullName, (childInstance as Control).Name, "MedReportView aa = new MedReportView();"));


                        }


                        //DateTime sss = DateTime.Now;
                        //TimeSpan c = sss - ss;
                        //Logger.Write(string.Format("{3} {1} {2} childList.Add(childInstance); 共用时{0}秒", c.TotalSeconds, childInstance.GetType().FullName, (childInstance as Control).Name,(instance as Control).Name));
                    }
                }
                else if (childNode.Name.Equals("Property"))
                {
                    ReadProperty(childNode, instance, errors);
                }
                else if (childNode.Name.Equals("Binary"))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    instance = formatter.Deserialize(Sundries.DecodeWithString(childNode.InnerText));
                }


            }
            if (errors.Count > 0)
            {

            }
            return instance;
        }
        //static List<Control> _controls = new List<Control>();
        //private static void RemoveControl(Control c)
        //{
        //    if (c is MedTextBox || c is MedPanel )
        //        _controls.Add(c);

        //}
        public static bool WriteFile(string fileName, object theObject)
        {
            return WriteFile(fileName, WriteXmlDocument(theObject));
        }

        public static Stream XmlDocumentToStream(XmlDocument doc)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xtw = new XmlTextWriter(sw);

            xtw.Formatting = Formatting.Indented;
            doc.WriteTo(xtw);

            string cleanup = sw.ToString().Replace("<DOCUMENT_ELEMENT>", "");

            cleanup = cleanup.Replace("</DOCUMENT_ELEMENT>", "");
            xtw.Close();

            MemoryStream ms = new MemoryStream(cleanup.Length);
            StreamWriter file = new StreamWriter(ms);// (fileName);

            file.Write(cleanup);
            file.Flush();

            ms.Position = 0;
            ms = new MemoryStream(FileHelper.StreamToBytes(ms));

            file.Close();
            return ms;

        }

        public static bool WriteFile(string fileName, XmlDocument doc)
        {
            if (fileName != null)
            {
                FileHelper.WriteStreamToFile(XmlDocumentToStream(doc), fileName);
                return true;
            }
            return false;
        }

        private static object _instance = null;
        public static string ReadFile(string fileName, ArrayList errors, out XmlDocument document, object instance)
        {
            return ReadFile(new System.IO.MemoryStream(FileHelper.GetFileData(fileName)), errors, out document, instance);
        }

        public static string ReadFile(Stream stream, ArrayList errors, out XmlDocument document, object instance)
        {
            //DateTime ss = DateTime.Now;
            string baseClass = null;

            try
            {
                StreamReader sr = new StreamReader(stream);
                string cleandown = sr.ReadToEnd();

                cleandown = "<DOCUMENT_ELEMENT>" + cleandown + "</DOCUMENT_ELEMENT>";

                XmlDocument doc = new XmlDocument();

                doc.LoadXml(cleandown);

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (baseClass == null)
                    {
                        try
                        {
                            baseClass = node.Attributes["name"].Value;
                        }
                        catch { }
                    }

                    if (node.Name.Equals("Object"))
                    {
                        //DateTime a = DateTime.Now;
                        _instance = ReadObject(node, errors, instance);
                        //DateTime b = DateTime.Now;
                        //TimeSpan c = b - a;
                        //Logger.Write(string.Format("加载{0}共费时{1}秒", node.Attributes["type"].Value, c.TotalSeconds));

                    }
                    else
                    {
                        errors.Add(string.Format("Node type {0} is not allowed here.", node.Name));
                    }
                }

                document = doc;
            }
            catch (Exception ex)
            {
                document = null;
                // errors.Add(ex);
                ExceptionHandler.Handle(ex);
            }
            //DateTime sss = DateTime.Now;
            //TimeSpan ssss = sss - ss;
            //Debug.WriteLine(string.Format("加载界面共费时{0}秒", ssss.TotalSeconds));
            //Logger.Write(string.Format("加载界面共费时{0}秒", ssss.TotalSeconds));
            return baseClass;
        }

        public static void ReadFile(string fileName, object instance)
        {
            ArrayList errors = new ArrayList();
            XmlDocument doc;
            ReadFile(fileName, errors, out doc, instance);
        }

        public static void ReadFile(Stream stream, object instance)
        {
            ArrayList errors = new ArrayList();
            XmlDocument doc;
            ReadFile(stream, errors, out doc, instance);
        }

        public static object ReadFile(string fileName)
        {
            _instance = null;
            ReadFile(fileName, null);
            return _instance;
        }

        public static object ReadFile(Stream stream)
        {
            _instance = null;
            ReadFile(stream, null);
            return _instance;
        }

        private static readonly Attribute[] propertyAttributes = new Attribute[] {
			DesignOnlyAttribute.No
		};
        private static XmlNode WriteInstanceDescriptor(XmlDocument document, InstanceDescriptor desc, object value, object instance)
        {
            XmlNode node = document.CreateElement("InstanceDescriptor");
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();

            formatter.Serialize(stream, desc.MemberInfo);

            XmlAttribute memberAttr = document.CreateAttribute("member");

            memberAttr.Value = Convert.ToBase64String(stream.ToArray());
            node.Attributes.Append(memberAttr);
            foreach (object arg in desc.Arguments)
            {
                XmlNode argNode = document.CreateElement("Argument");

                if (WriteValue(document, arg, argNode, instance))
                {
                    node.AppendChild(argNode);
                }
            }

            if (!desc.IsComplete)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(value, propertyAttributes);

                WriteProperties(document, props, value, node, "Property", instance);
            }

            return node;
        }

        private static void WriteProperties(XmlDocument document, PropertyDescriptorCollection properties, object value, XmlNode parent, string elementName, object instance)
        {
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.Name == "AutoScaleBaseSize")
                {
                    string _DEBUG_ = prop.Name;
                }

                if (prop.ShouldSerializeValue(value))
                {
                    string compName = parent.Name;
                    XmlNode node = document.CreateElement(elementName);
                    XmlAttribute attr = document.CreateAttribute("name");

                    attr.Value = prop.Name;
                    node.Attributes.Append(attr);

                    DesignerSerializationVisibilityAttribute visibility = (DesignerSerializationVisibilityAttribute)prop.Attributes[typeof(DesignerSerializationVisibilityAttribute)];

                    switch (visibility.Visibility)
                    {
                        case DesignerSerializationVisibility.Visible:
                            if (!prop.IsReadOnly && WriteValue(document, prop.GetValue(value), node, instance))
                            {
                                parent.AppendChild(node);
                            }

                            break;

                        case DesignerSerializationVisibility.Content:
                            object propValue = prop.GetValue(value);

                            if (typeof(IList).IsAssignableFrom(prop.PropertyType))
                            {
                                WriteCollection(document, (IList)propValue, node, instance);
                            }
                            else
                            {
                                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(propValue, propertyAttributes);

                                WriteProperties(document, props, propValue, node, elementName, instance);
                            }

                            if (node.ChildNodes.Count > 0)
                            {
                                parent.AppendChild(node);
                            }

                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private static void WriteCollection(XmlDocument document, IList list, XmlNode parent, object instance)
        {
            foreach (object obj in list)
            {
                XmlNode node = document.CreateElement("Item");
                XmlAttribute typeAttr = document.CreateAttribute("type");

                typeAttr.Value = obj.GetType().AssemblyQualifiedName;
                node.Attributes.Append(typeAttr);
                WriteValue(document, obj, node, instance);
                parent.AppendChild(node);
            }
        }

        private static XmlNode WriteBinary(XmlDocument document, byte[] value)
        {
            XmlNode node = document.CreateElement("Binary");

            node.InnerText = Convert.ToBase64String(value);
            return node;
        }

        private static bool WriteValue(XmlDocument document, object value, XmlNode parent, object instance)
        {
            if (value == null)
            {
                return true;
            }

            TypeConverter converter = TypeDescriptor.GetConverter(value);

            if (GetConversionSupported(converter, typeof(string)))
            {
                parent.InnerText = (string)converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(string));
            }
            else if (GetConversionSupported(converter, typeof(byte[])))
            {
                byte[] data = (byte[])converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(byte[]));

                parent.AppendChild(WriteBinary(document, data));
            }
            else if (GetConversionSupported(converter, typeof(InstanceDescriptor)))
            {
                InstanceDescriptor id = (InstanceDescriptor)converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(InstanceDescriptor));

                parent.AppendChild(WriteInstanceDescriptor(document, id, value, instance));
            }
            else if (instance is IDesignerLoaderHost && value is IComponent && ((IComponent)value).Site != null && ((IComponent)value).Site.Container == ((IDesignerHost)((IDesignerLoaderHost)instance).GetService(typeof(IDesignerHost))).Container)
            {
                parent.AppendChild(WriteReference(document, (IComponent)value, instance));
            }
            else if (value.GetType().IsSerializable)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                formatter.Serialize(stream, value);


                XmlNode binaryNode = WriteBinary(document, stream.ToArray());

                parent.AppendChild(binaryNode);
            }
            else
            {
                return false;
            }

            return true;
        }

        private static XmlNode WriteReference(XmlDocument document, IComponent value, object instance)
        {
            if (instance is IDesignerLoaderHost)
            {
                IDesignerHost idh = (IDesignerHost)((IDesignerLoaderHost)instance).GetService(typeof(IDesignerHost));

                System.Diagnostics.Debug.Assert(value != null && value.Site != null && value.Site.Container == idh.Container, "Invalid component passed to WriteReference");
            }

            XmlNode node = document.CreateElement("Reference");
            XmlAttribute attr = document.CreateAttribute("name");

            attr.Value = value.Site.Name;
            node.Attributes.Append(attr);
            return node;
        }

        public static XmlDocument WriteXmlDocument(object theObject)
        {
            XmlDocument document = new XmlDocument();
            Hashtable nametable = new Hashtable(1);
            document.AppendChild(document.CreateElement("DOCUMENT_ELEMENT"));
            document.DocumentElement.AppendChild(WriteObject(document, nametable, theObject, null));
            return document;
        }

        public static XmlDocument WriteXmlDocument(IDesignerLoaderHost loaderHost)
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateElement("DOCUMENT_ELEMENT"));

            IDesignerHost idh = (IDesignerHost)loaderHost.GetService(typeof(IDesignerHost));
            IComponent root = idh.RootComponent;

            Hashtable nametable = new Hashtable(idh.Container.Components.Count);
            IDesignerSerializationManager manager = loaderHost.GetService(typeof(IDesignerSerializationManager)) as IDesignerSerializationManager;

            document.DocumentElement.AppendChild(WriteObject(document, nametable, root, loaderHost));
            foreach (IComponent comp in idh.Container.Components)
            {
                if (comp != root && !nametable.ContainsKey(comp))
                {
                    document.DocumentElement.AppendChild(WriteObject(document, nametable, comp, loaderHost));
                }
            }
            return document;
        }

        public static XmlNode WriteObject(XmlDocument document, IDictionary nametable, object value, object instance)
        {
            if (instance is IDesignerLoaderHost)
            {
                IDesignerHost idh = (IDesignerHost)((IDesignerLoaderHost)instance).GetService(typeof(IDesignerHost));
                System.Diagnostics.Debug.Assert(value != null, "Should not invoke WriteObject with a null value");
            }

            XmlNode node = document.CreateElement("Object");
            XmlAttribute typeAttr = document.CreateAttribute("type");

            typeAttr.Value = value.GetType().AssemblyQualifiedName;
            node.Attributes.Append(typeAttr);

            IComponent component = value as IComponent;

            if (component != null && component.Site != null && component.Site.Name != null)
            {
                XmlAttribute nameAttr = document.CreateAttribute("name");

                nameAttr.Value = component.Site.Name;
                node.Attributes.Append(nameAttr);
                System.Diagnostics.Debug.Assert(nametable[component] == null, "WriteObject should not be called more than once for the same object.  Use WriteReference instead");
                nametable[value] = component.Site.Name;
            }

            bool isControl = (value is Control);

            if (isControl)
            {
                XmlAttribute childAttr = document.CreateAttribute("children");

                childAttr.Value = "Controls";
                node.Attributes.Append(childAttr);
            }

            if (component != null)
            {
                if (isControl)
                {
                    foreach (Control child in ((Control)value).Controls)
                    {
                        if (instance is IDesignerLoaderHost)
                        {
                            IDesignerHost idh = (IDesignerHost)((IDesignerLoaderHost)instance).GetService(typeof(IDesignerHost));
                            if (child.Site != null && child.Site.Container == idh.Container)
                            {
                                node.AppendChild(WriteObject(document, nametable, child, instance));
                            }
                        }
                        else
                        {
                            node.AppendChild(WriteObject(document, nametable, child, instance));
                        }
                    }
                }// if isControl

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value, propertyAttributes);

                if (isControl)
                {
                    PropertyDescriptor controlProp = properties["Controls"];

                    if (controlProp != null)
                    {
                        PropertyDescriptor[] propArray = new PropertyDescriptor[properties.Count - 1];
                        int idx = 0;

                        foreach (PropertyDescriptor p in properties)
                        {
                            if (p != controlProp)
                            {
                                propArray[idx++] = p;
                            }
                        }

                        properties = new PropertyDescriptorCollection(propArray);
                    }
                }

                WriteProperties(document, properties, value, node, "Property", instance);

                EventDescriptorCollection events = TypeDescriptor.GetEvents(value, propertyAttributes);
                if (instance is IDesignerLoaderHost)
                {
                    IEventBindingService bindings = (instance as IDesignerLoaderHost).GetService(typeof(IEventBindingService)) as IEventBindingService;

                    if (bindings != null)
                    {
                        properties = bindings.GetEventProperties(events);
                        WriteProperties(document, properties, value, node, "Event", instance);
                    }
                }
            }
            else
            {
                WriteValue(document, value, node, instance);
            }

            return node;
        }
        /// <summary>  
        /// 生成Json格式  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
        public static string GetJson<T>(T obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, obj);
                string szJson = Encoding.UTF8.GetString(stream.ToArray());
                return szJson;
            }
        }
        /// <summary>  
        /// 获取Json的Model  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="szJson"></param>  
        /// <returns></returns>  
        public static T ParseFromJson<T>(string szJson)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }
        //List<T>转Json
        public static string List2Json<T>(T data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }
        // Json转List<T>
        public static Object Json2List(String json, Type t)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {

                    return serializer.ReadObject(ms);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
