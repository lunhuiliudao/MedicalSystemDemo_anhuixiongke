using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Drawing;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Xml.Linq;
using System.Windows.Forms;


namespace MedicalSystem.AnesIcuQuery.Common
{
    /// <summary>
    /// 公共函数类，方便界面层调用
    /// </summary>
    public static class CommHelper
    {
        /// <summary>
        /// 创建报表列配置新表
        /// </summary>
        public static DataTable CreateConfigTable()
        {
            DataTable resultColumnDt = new DataTable("ConfigColumn");
            resultColumnDt.Columns.Add("FieldName", typeof(string));
            resultColumnDt.Columns.Add("Title", typeof(string));
            resultColumnDt.Columns.Add("Width", typeof(int));
            resultColumnDt.Columns.Add("IsSHow", typeof(string));
            return resultColumnDt;
        }

        /// <summary>
        /// 创建报表查询条件配置新表
        /// </summary>
        public static DataTable CreateWhereTable()
        {
            DataTable resultWhereDt = new DataTable("ConfigWhere");
            resultWhereDt.Columns.Add("Title", typeof(string));
            resultWhereDt.Columns.Add("ControlType", typeof(string));
            resultWhereDt.Columns.Add("FieldName", typeof(string));
            resultWhereDt.Columns.Add("DataDype", typeof(string));
            resultWhereDt.Columns.Add("Operation", typeof(string));
            resultWhereDt.Columns.Add("Width", typeof(int));
            resultWhereDt.Columns.Add("BindDict", typeof(string));
            resultWhereDt.Columns.Add("BindDictType", typeof(string));
            return resultWhereDt;
        }

        /// <summary>
        /// 创建报表信息表
        /// </summary>
        public static DataTable CreateReportInformationTable()
        {
            DataTable ReportInformationTable = new DataTable("ReportInformation");
            ReportInformationTable.Columns.Add("ReportKey", typeof(string));
            ReportInformationTable.Columns.Add("ReportName", typeof(string));
            ReportInformationTable.Columns.Add("AppType", typeof(string));
            ReportInformationTable.Columns.Add("SqlKey", typeof(string));
            ReportInformationTable.Columns.Add("Describe", typeof(string));
            ReportInformationTable.Columns.Add("HeadInfo", typeof(string));

            //---------2016-08-22新加入配置
            ReportInformationTable.Columns.Add("ShowSumColumn", typeof(string));//是否显示合计
            ReportInformationTable.Columns.Add("AutoWidth", typeof(string));//是否按分辨率缩放
            ReportInformationTable.Columns.Add("AllowSort", typeof(string));//是否表头允许排序
            ReportInformationTable.Columns.Add("VersionCreate", typeof(string));//创建版本号            
            ReportInformationTable.Columns.Add("VersionUpdate", typeof(string));//修改版本号           
            //---------

            return ReportInformationTable;
        }


        /// <summary>
        /// 是否包含该字段
        /// </summary>
        /// <param name="row">当前row</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="isAdd">不存在是否新增</param>
        /// <returns></returns>
        public static bool ContainsFieldName(DataRow row, string fieldName, bool isAdd)
        {
            bool result = false;
            if (row.Table.Columns.Contains(fieldName))
            {
                result = true;
            }
            else
            {
                if (isAdd)
                {
                    row.Table.Columns.Add(fieldName);
                    result = true;
                }
            }
            return result;
        }


        /// <summary>
        /// 是否包含该字段
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="rowIndex">行号</param>
        /// <returns></returns>
        public static bool ContainsFieldName(DataTable dt, string fieldName, int rowIndex)
        {
            bool result = false;
            if (dt.Columns.Contains(fieldName))
            {
                result = GetBoolean(dt.Rows[rowIndex][fieldName].ToString());
            }
            return result;
        }

        /// <summary>
        /// 获取实体属性名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<T, V>(Expression<Func<T, V>> expr)
        {
            if (expr.Body.Type.FullName.Contains("System.Decimal"))
            {
                UnaryExpression m = (UnaryExpression)expr.Body;
                return m.Operand.ToString().Split('.')[1];
            }
            else
                return ((MemberExpression)expr.Body).Member.Name;
        }

        #region 导出为EXCEL
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="dtColumn">导出列</param>
        /// <param name="title">表头</param>
        /// <param name="des">描述信息</param>
        /// <param name="path">路径</param>
        public static void ExportExcelWithAspose(DataTable dt, DataTable dtColumn, string title, string des, string path)
        {
            if (dt != null)
            {
                try
                {
                    //Aspose.Cells.License li = new Aspose.Cells.License();
                    //string lic = System.Windows.Forms.Application.StartupPath.ToString() + "\\License.lic";
                    //Stream s = new MemoryStream(ASCIIEncoding.Default.GetBytes(lic));
                    //li.SetLicense(lic);
                    Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                    Aspose.Cells.Worksheet cellSheet = workbook.Worksheets[0];

                    cellSheet.Name = dt.TableName;

                    int rowIndex = 0;
                    int colIndex = 0;
                    int colCount = dtColumn.Rows.Count;
                    int rowCount = dt.Rows.Count;

                    #region 表头
                    Aspose.Cells.Style styleHead = new Aspose.Cells.Style(); // workbook.Styles[workbook.Styles.Add()];//新增样式 
                    styleHead.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;//文字居中  
                    styleHead.Font.Name = "宋体";//文字字体 
                    styleHead.Font.Size = 12;//文字大小  
                    styleHead.Font.IsBold = true;//粗体

                    cellSheet.Cells.Merge(0, 0, 1, colCount);               //合并单元格 
                    cellSheet.Cells[0, 0].PutValue(title);   //填写内容 
                    cellSheet.Cells[0, 0].SetStyle(styleHead);            //给单元格关联样式  
                    cellSheet.Cells.SetRowHeight(0, 30);              //设置行高

                    styleHead = new Aspose.Cells.Style();
                    styleHead.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Right;
                    cellSheet.Cells.Merge(1, 0, 1, colCount);             //合并单元格 
                    cellSheet.Cells[1, 0].PutValue(des);   //填写内容
                    cellSheet.Cells[1, 0].SetStyle(styleHead);
                    //cellSheet.Cells.SetRowHeight(0, 10);                //设置行高  

                    rowIndex += 2;
                    #endregion

                    //列名的处理
                    Aspose.Cells.Style column = new Aspose.Cells.Style();
                    column.Font.Name = "宋体";
                    column.Font.IsBold = true;
                    for (int i = 0; i < colCount; i++)
                    {
                        cellSheet.Cells[rowIndex, colIndex].PutValue(dtColumn.Rows[i]["Title"].ToString());
                        cellSheet.Cells[rowIndex, colIndex].SetStyle(column);
                        //cellSheet.Cells[rowIndex, colIndex].Style.Font.IsBold = true;
                        //cellSheet.Cells[rowIndex, colIndex].Style.Font.Name = "宋体";
                        colIndex++;
                    }

                    Aspose.Cells.Style style = new Aspose.Cells.Style();// workbook.Styles[workbook.Styles.Add()];
                    style.Font.Name = "宋体";
                    style.Font.Size = 10;
                    Aspose.Cells.StyleFlag styleFlag = new Aspose.Cells.StyleFlag();
                    cellSheet.Cells.ApplyStyle(style, styleFlag);

                    rowIndex++;
                    string colName = string.Empty;
                    for (int i = 0; i < rowCount; i++)
                    {
                        colIndex = 0;
                        for (int j = 0; j < colCount; j++)
                        {
                            colName = dtColumn.Rows[j]["FieldName"].ToString();
                            if (dt.Columns.Contains(colName))
                            {
                                if (dtColumn.Rows[j]["Title"].ToString().Contains("时间"))
                                {
                                    cellSheet.Cells[rowIndex, colIndex].PutValue(string.IsNullOrEmpty(dt.Rows[i][colName].ToString()) ? "" : Convert.ToDateTime(dt.Rows[i][colName]).ToString("HH:mm"));
                                }
                                else if (dtColumn.Rows[j]["Title"].ToString().Contains("日期"))
                                {
                                    cellSheet.Cells[rowIndex, colIndex].PutValue(string.IsNullOrEmpty(dt.Rows[i][colName].ToString()) ? "" : Convert.ToDateTime(dt.Rows[i][colName]).ToString("yyyy-MM-dd"));
                                }
                                else
                                {
                                    cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Rows[i][colName].ToString());
                                }
                                colIndex++;
                            }
                        }
                        rowIndex++;
                    }
                    cellSheet.AutoFitColumns();

                    path = Path.GetFullPath(path);
                    workbook.Save(path);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 按模板导出Excle
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="model">模板流</param>
        /// <param name="path">保存路径</param>
        public static void ExportExcelForModel(DataTable dt, Stream model, string path)
        {
            try
            {
                dt.TableName = "Table";
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(model);
                Aspose.Cells.WorkbookDesigner designer = new Aspose.Cells.WorkbookDesigner();
                designer.Workbook = workbook;
                designer.SetDataSource(dt);
                designer.Process();
                workbook.Save(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        /// <summary>
        /// 获取汉字首拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留 　　 
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母 　　 
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        public static string GetPYChar(string c)
        {
            try
            {
                byte[] array = new byte[2];
                array = System.Text.Encoding.Default.GetBytes(c);
                int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
                if (i < 0xB0A1) return "*";
                if (i < 0xB0C5) return "a";
                if (i < 0xB2C1) return "b";
                if (i < 0xB4EE) return "c";
                if (i < 0xB6EA) return "d";
                if (i < 0xB7A2) return "e";
                if (i < 0xB8C1) return "f";
                if (i < 0xB9FE) return "g";
                if (i < 0xBBF7) return "h";
                if (i < 0xBFA6) return "j";
                if (i < 0xC0AC) return "k";
                if (i < 0xC2E8) return "l";
                if (i < 0xC4C3) return "m";
                if (i < 0xC5B6) return "n";
                if (i < 0xC5BE) return "o";
                if (i < 0xC6DA) return "p";
                if (i < 0xC8BB) return "q";
                if (i < 0xC8F6) return "r";
                if (i < 0xCBFA) return "s";
                if (i < 0xCDDA) return "t";
                if (i < 0xCEF4) return "w";
                if (i < 0xD1B9) return "x";
                if (i < 0xD4D1) return "y";
                if (i < 0xD7FA) return "z";
                return "*";
            }
            catch (Exception)
            {
                return "*";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool GetBoolean(string str)
        {
            bool result = false;
            switch (str.ToLower())
            {
                case "1":
                case "true":
                    result = true;
                    break;
                case "0":
                case "false":
                    result = false;
                    break;
                default:
                    result = false; break;
            }
            return result;
        }

        /// <summary>
        /// 设置GrideView颜色
        /// </summary>
        /// <param name="gridViewReportView"></param>
        public static void SetGrideColor(DevExpress.XtraGrid.Views.Grid.GridView gridViewReportView)
        {
            gridViewReportView.FocusedRowHandle = -1;
            gridViewReportView.OptionsView.EnableAppearanceEvenRow = true;
            gridViewReportView.OptionsView.EnableAppearanceOddRow = true;
            gridViewReportView.Appearance.EvenRow.BackColor = Color.FromArgb(255, 255, 255, 255);
            gridViewReportView.Appearance.OddRow.BackColor = Color.FromArgb(255, 239, 247, 255);

            gridViewReportView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridViewReportView.Appearance.FocusedRow.ForeColor = Color.White;
            gridViewReportView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridViewReportView.Appearance.FocusedRow.BackColor = Color.FromArgb(100, 170, 250);// Color.FromArgb(255, 145, 168, 218);
            gridViewReportView.ColumnPanelRowHeight = 30;
            gridViewReportView.RowHeight = 30;
            gridViewReportView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewReportView.Appearance.HeaderPanel.Font = new Font("微软雅黑", 9, FontStyle.Bold);

            gridViewReportView.OptionsSelection.EnableAppearanceFocusedCell = false;
            //gridViewReportView.Appearance.FocusedRow.Font = font;
            //gridViewReportView.Appearance.HeaderPanel.Options.UseForeColor = true;
            //this.rptGridControl1.BandGridView.Columns[1].AppearanceHeader.Options.UseBackColor = true;
            //this.rptGridControl1.BandGridView.Columns[1].AppearanceHeader.BackColor = Color.Yellow;
            //gridViewReportView.Appearance.SelectedRow.Options.UseBackColor = true;
            //gridViewReportView.Appearance.SelectedRow.Options.UseForeColor = true;
            //gridViewReportView.Appearance.SelectedRow.ForeColor = Color.White;
            //gridViewReportView.Appearance.SelectedRow.BackColor = Color.FromArgb(150, 100, 135, 206);
            //gridViewReportView.Appearance.FocusedCell.BackColor = Color.FromArgb(255, 100, 135, 206);
            //gridViewReportView.Appearance.FocusedCell.Options.UseBackColor = true;
            //gridViewReportView.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 100, 135, 206);
            //gridViewReportView.Appearance.FocusedRow.Options.UseBackColor = true;
        }

        public static class ConfigurationHelper
        {
            /// <summary>
            /// 读取设置
            /// </summary>
            /// <param name="key">主键</param>
            /// <returns>对应值</returns>
            public static string Read(string key)
            {
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    string value = config.AppSettings.Settings[key].Value;
                    return value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ConfigurationHelper Read key " + key + "  " + ex.ToString());
                    return null;
                }
            }

            /// <summary>
            /// 读取设置
            /// </summary>
            /// <param name="fileName">文件名</param>
            /// <param name="key">主键</param>
            /// <returns>对应值</returns>
            public static string Read(string fileName, string key)
            {
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
                    return config.AppSettings.Settings[key].Value;
                }
                catch
                {

                    return null;
                }
            }

            /// <summary>
            /// 保存设置
            /// </summary>
            /// <param name="key">主键</param>
            /// <param name="value">对应值</param>
            public static void Save(string key, string value)
            {
                if (Read(key) == value) return;
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove(key);
                config.AppSettings.Settings.Add(key, value);
                config.Save();
            }

            /// <summary>
            /// 保存设置
            /// </summary>
            /// <param name="fileName">文件名</param>
            /// <param name="key">主键</param>
            /// <param name="value">对应值</param>
            public static void Save(string fileName, string key, string value)
            {
                if (Read(key) == value) return;
                Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
                config.AppSettings.Settings.Remove(key);
                config.AppSettings.Settings.Add(key, value);
                config.Save();
            }

            /// <summary>
            /// 加密连接字符串配置
            /// </summary>
            /// <param name="connectionStringsSection"></param>
            //public static void ProtectSection(ConnectionStringsSection connectionStringsSection)
            //{
            //    connectionStringsSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //}

            /// <summary>
            /// 两个连接字符串配置是否相等
            /// </summary>
            /// <param name="connectionStringSettings1">连接字符串配置</param>
            /// <param name="connectionStringSettings2">连接字符串配置</param>
            /// <returns>是否相等</returns>
            public static bool IsSame(ConnectionStringSettings connectionStringSettings1, ConnectionStringSettings connectionStringSettings2)
            {
                if (connectionStringSettings1 == null || connectionStringSettings2 == null) return false;
                else
                {
                    return
                        connectionStringSettings1.Name.Equals(connectionStringSettings2.Name) &&
                        connectionStringSettings1.ConnectionString.Equals(connectionStringSettings2.ConnectionString) &&
                        (
                            (
                                string.IsNullOrEmpty(connectionStringSettings1.ProviderName) && string.IsNullOrEmpty(connectionStringSettings2.ProviderName)
                            ) ||
                            (
                                !string.IsNullOrEmpty(connectionStringSettings1.ProviderName) && connectionStringSettings1.ProviderName.Equals(connectionStringSettings2.ProviderName)
                            )
                        );
                }
            }

            /// <summary>
            /// 系统配置的连接字符串集
            /// </summary>
            public static ConnectionStringSettingsCollection ConnectionStringSettingsCollections
            {
                get
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConnectionStringSettingsCollection connectionStringSettingsCollection = config.ConnectionStrings.ConnectionStrings;
                    if (connectionStringSettingsCollection != null && connectionStringSettingsCollection.Count > 0)
                    {
                        connectionStringSettingsCollection.RemoveAt(0);
                    }
                    return connectionStringSettingsCollection;
                }
            }
        }


        #region 压缩算法

        /// <summary>
        /// 将传入字符串以GZip算法压缩后，返回Base64编码字符
        /// </summary>
        /// <param name="rawString">需要压缩的字符串</param>
        /// <returns>压缩后的Base64编码的字符串</returns>
        public static string GZipCompressString(string rawString)
        {
            if (string.IsNullOrEmpty(rawString) || rawString.Length == 0)
            {
                return "";
            }
            else
            {
                byte[] rawData = System.Text.Encoding.UTF8.GetBytes(rawString.ToString());
                byte[] zippedData = Compress(rawData);
                return (string)(Convert.ToBase64String(zippedData));
            }
        }

        /// <summary>
        /// 将传入的二进制字符串资料以GZip算法解压缩
        /// </summary>
        /// <param name="zippedString">经GZip压缩后的二进制字符串</param>
        /// <returns>原始未压缩字符串</returns>
        public static string GZipDecompressString(string zippedString)
        {
            if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
            {
                return "";
            }
            else
            {
                byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
                return (string)(System.Text.Encoding.UTF8.GetString(Decompress(zippedData)));
            }
        }

        /// <summary>
        /// 将传入字节数组以GZip算法压缩后，返回Base64编码字符
        /// </summary>
        /// <param name="rawData">需要压缩的字节</param>
        /// <returns>压缩后的Base64编码的字符串</returns>
        public static string GZipCompressByte(byte[] rawData)
        {
            if (rawData == null || (rawData != null && rawData.Length == 0))
            {
                return "";
            }
            else
            {
                byte[] zippedData = Compress(rawData);
                return (string)(Convert.ToBase64String(zippedData));
            }
        }

        /// <summary>
        /// 将传入的二进制字符串资料以GZip算法解压缩
        /// </summary>
        /// <param name="zippedString">经GZip压缩后的二进制字符串</param>
        /// <returns>原始未压缩字节数组</returns>
        public static byte[] GZipDecompressByte(string zippedString)
        {
            if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
            {
                return new byte[0];
            }
            else
            {
                byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
                return Decompress(zippedData);
            }
        }


        /// <summary>
        /// GZip压缩
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] rawData)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(rawData, 0, rawData.Length);
            compressedzipStream.Close();
            return ms.ToArray();
        }


        /// <summary>
        ///  ZIP解压
        /// </summary>
        /// <param name="zippedData"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream outBuffer = new MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }



        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {

            //创建属性的集合    
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口    

            Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列    
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例    
                DataRow row = dt.NewRow();
                //给row 赋值    
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable    
                dt.Rows.Add(row);
            }
            return dt;
        }

        #endregion

        #region XML与树转换
        /// <summary>
        /// 将TreeNode转换为XElement
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static XElement ToXElement(this TreeNode treeNode)
        {
            return new XElement(treeNode.Text, treeNode.Nodes.ToXelement());
        }

        /// <summary>
        /// 将TreeNode的Nodes转换为XElement的集合
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> ToXelement(this TreeNodeCollection nodes)
        {
            return nodes.OfType<TreeNode>().Select(n => n.ToXElement());
        }

        /// <summary>
        /// 将XElement转换为TreeNode
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TreeNode ToTreeNode(this XElement element)
        {
            return new TreeNode(element.Name.ToString(), element.Elements().ToTreeNode().ToArray());
        }

        /// <summary>
        /// 将Element的子元素转换为TreeNode的集合
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static IEnumerable<TreeNode> ToTreeNode(this IEnumerable<XElement> elements)
        {
            return elements.Select(e => e.ToTreeNode());
        }

        /// <summary>
        /// 将TreeView转换为XDocument
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public static XDocument ToXml(this TreeView treeView)
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(treeView.Name, treeView.Nodes.ToXelement()));
        }
        #endregion

        #region 文件转换

        /// <summary>
        /// 将文件转换为byte数组
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] FileToBytes(string path)
        {
            if (!File.Exists(path))
                return new byte[0];

            FileInfo fi = new FileInfo(path);
            byte[] buff = new byte[fi.Length];

            FileStream fs = fi.OpenRead();
            fs.Read(buff, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return buff;
        }

        /// <summary>
        /// 将byte数组转换为文件并保存到指定地址
        /// </summary>
        /// <param name="buff">byte数组</param>
        /// <param name="savepath">保存地址</param>
        public static void BytesToFile(byte[] buff, string savepath)
        {
            if (File.Exists(savepath))
                File.Delete(savepath);
            FileStream fs = new FileStream(savepath, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(buff, 0, buff.Length);
            bw.Close();
            fs.Close();
        }
        #endregion
    }
}
