using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System.Data;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = txtSql.Text.Trim();
            if (!string.IsNullOrEmpty(sql))
            {
                CommonBC bc = new CommonBC("OracleConnectionString");
                DataTable dt = bc.GetDataTable(null, ref sql);
                foreach (DataColumn c in dt.Columns)
                {
                    string name = GetPropName(c.ColumnName);
                    string type = GetPropType(c.DataType);
                    if(type.Equals("String"))
                    {
                        type = "string";
                    }

                    string info = string.Format(@"public {0} {1} {{ get; set; }} <br/>", type, name.ToUpper());
                    Response.Write(info);
//                    Response.Write("public " + type + " " + name + @"<br/>
//{<br/>
//    get { return (" + type + ")this[\"" + name + "\"]; }" + @"<br/>
//" + "    set { this[\"" + name + "\"] = value; }" + @"<br/>
//}<br/>");
                }
            }
        }

        private string GetPropName(string name)
        {
            bool isFirst = true;
            string propName = "";
            foreach (var c in name.ToLower())
            {
                string con = "qwertyuiopasdfghjklzxcvbnm";
                if (con.Contains(c))
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        propName += c.ToString().ToUpper();
                    }
                    else
                    {
                        propName += c.ToString();
                    }
                }
                else
                {
                    isFirst = true;
                    propName += c.ToString();
                }
            }

            return propName;
        }

        private string GetPropType(Type type)
        {
            switch (type.FullName)
            {
                case "System.String":
                    return "String";
                case "System.Decimal":
                    return "Decimal?";
                case "System.DateTime":
                    return "DateTime?";
                default:
                    return "Unknown";
            }
        }

    }
}