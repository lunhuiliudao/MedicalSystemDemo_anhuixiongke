using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.AutoGenerateCode
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        bool runing = false;

        private void btnGenerateClass_Click(object sender, EventArgs e)
        {
            if (runing)
                return;

            try
            {
                runing = true;
                this.btnGenerateClass.Text = "生成代码.";

                DapperContext context = new DapperContext(txtConnString.Text.Trim());
                DapperRepository db = new DapperRepository(context);

                this.btnGenerateClass.Text = "生成代码..";
                // GET ALL TABLES
                DataTable dt = db.Fill(txtAllTableSql.Text.Trim());

                this.btnGenerateClass.Text = "生成代码...";

                if (!Directory.Exists(Path.Combine(Application.StartupPath, "Code")))
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Code"));
                if (!Directory.Exists(Path.Combine(Application.StartupPath, "Code", "Origins")))
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Code", "Origins"));

                int i = 0;
                foreach (DataRow tRow in dt.Rows)
                {
                    this.btnGenerateClass.Text = string.Format("生成代码[{0}/{1}]", i, dt.Rows.Count);
                    i++;

                    string table_name = Convert.ToString(tRow["TABLE_NAME"]);
                    string comments = Convert.ToString(tRow["COMMENTS"]);
                    string sql2 = txtAllTableColumnSql.Text.Trim().Replace("{table_name}", table_name);

                    DataTable dt2 = db.Fill(sql2);
                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow cRow in dt2.Rows)
                    {
                        string COLUMN_NAME = Convert.ToString(cRow["COLUMN_NAME"]);
                        string DATA_TYPE = Convert.ToString(cRow["DATA_TYPE"]);
                        int DATA_LENGTH = Convert.ToInt32(Convert.ToString(cRow["DATA_LENGTH"]) ?? "0");
                        int DATA_PRECISION = Convert.ToInt32(string.IsNullOrWhiteSpace(Convert.ToString(cRow["DATA_PRECISION"])) ? "0" : Convert.ToString(cRow["DATA_PRECISION"]));
                        int DATA_SCALE = Convert.ToInt32(string.IsNullOrWhiteSpace(Convert.ToString(cRow["DATA_SCALE"])) ? "0" : Convert.ToString(cRow["DATA_SCALE"]));
                        string NULLABLE = Convert.ToString(cRow["NULLABLE"]);
                        string COMMENTS = Convert.ToString(cRow["COMMENTS"]);
                        string Key_Type = Convert.ToString(cRow["Key_Type"]);
                        if (!string.IsNullOrWhiteSpace(COMMENTS))
                        {
                            sb.AppendFormat(@"        /// <summary>
        /// {0}
        /// </summary>
", (Key_Type == "Y" ? "主键 " : "") + COMMENTS);
                        }
                        if (!string.IsNullOrWhiteSpace(Key_Type) && Key_Type == "Y")
                        {
                            sb.Append(@"        [Key]
");
                        }
                        sb.AppendFormat(@"        public {0} {1} {{ get; set; }}
", GetDataType(DATA_TYPE, DATA_LENGTH, DATA_PRECISION, DATA_SCALE, NULLABLE == "Y"), COLUMN_NAME);
                    }

                    string template = txtClassTemp.Text.Trim()
                        .Replace("{comments}", comments)
                        .Replace("{table_name}", table_name)
                        .Replace("{properties}", sb.ToString());

                    File.WriteAllText(Path.Combine(Application.StartupPath, "Code", "Origins", table_name + ".cs"),
                        template);
                }

                File.WriteAllText(Path.Combine(Application.StartupPath, "Code", "BaseModel.cs"),
                        new System.ComponentModel.ComponentResourceManager(typeof(MainFrm)).GetString("BaseModel"));

                this.btnGenerateClass.Text = "生成代码";
                MessageBox.Show("生成成功。");
            }
            finally
            {
                runing = false;
            }
        }
        private string GetDataType(string dataType, int dataLength, int numlength, int xiaoshu, bool nullable)
        {
            var type = this.txtDataType.Text.Trim()
.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(x => !x.Contains("<!--") && !x.Contains("ORACLE"))
            .Select(x => x.Trim())
            .ToList();

            if (dataType == "NUMBER")
            {
                if (xiaoshu == 0)
                {
                    if (numlength <= 9)
                    {
                        var datatype = "Int32";
                        if (nullable)
                        {
                            return "Nullable<" + datatype + ">";
                        }
                        return datatype;
                    }
                    else
                    {
                        var datatype = "long";
                        if (nullable)
                        {
                            return "Nullable<" + datatype + ">";
                        }
                        return datatype;
                    }
                }
                else
                {
                    string start = "<" + (dataType == "NUMBER" ? dataType + "_" + xiaoshu : dataType) + ">";
                    string end = "</" + (dataType == "NUMBER" ? dataType + "_" + xiaoshu : dataType) + ">";
                    var a = type.Where(x => x.Contains(start)).ToList();
                    if (a.Count == 1)
                    {
                        var datatype = a.FirstOrDefault().Replace(start, "").Replace(end, "").Trim();
                        if (datatype.ToLower() != "string" && datatype.ToLower() != "byte[]" && nullable)
                        {
                            return "Nullable<" + datatype + ">";
                        }
                        return datatype;
                    }
                }
            }
            else
            {
                string start = "<" + dataType + ">";
                string end = "</" + dataType + ">";
                var a = type.Where(x => x.Contains(start)).ToList();
                if (a.Count == 1)
                {
                    var datatype = a.FirstOrDefault().Replace(start, "").Replace(end, "").Trim();
                    if (datatype.ToLower() != "string" && datatype.ToLower() != "byte[]" && nullable)
                    {
                        return "Nullable<" + datatype + ">";
                    }
                    return datatype;
                }
            }
            throw new Exception("");
        }

    }

}
