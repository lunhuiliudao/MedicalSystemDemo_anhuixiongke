using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Services;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class About : Form
    {
        private string FilePath = ExtendApplicationContext.Current.AppPath + @"Update\UpdateVerion.xml";
        private bool hasDiff = false;

        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            try
            {
                string version = "1000";
                if (File.Exists(this.FilePath))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(this.FilePath);
                    if (doc.ChildNodes.Count > 1 && doc.ChildNodes[1].ChildNodes.Count > 0)
                    {
                        version = doc.ChildNodes[1].ChildNodes[0].InnerText;
                    }
                }

                this.labMainVersion.Text = "当前版本程序：2.2." + version;

                // 获取版本信息
                ComnDictRepository comn = new ComnDictRepository();
                MED_VER_INFO maxVerInfo = comn.GetVerInfoList("PACU").Data.Where(x => !x.ROLL_BACK.HasValue || x.ROLL_BACK.Value == 0).OrderByDescending(x => x.VER_NO).FirstOrDefault();
                if (null != maxVerInfo)
                {
                    this.hasDiff = !version.Equals(maxVerInfo.VER_NO.ToString());
                    this.labLatestVersion.Text = string.Format("最新版本程序：2.2.{0}{1}", maxVerInfo.VER_NO, this.hasDiff ? "，请重启更新程序" : "");
                    if(this.hasDiff)
                    {
                        this.labLatestVersion.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    this.labLatestVersion.Text = string.Format("最新版本程序：2.2.{0}", version);
                    this.hasDiff = false;
                }

            }
            catch (Exception ex)
            {
                Logger.Error("加载关于界面错误！" + ex.Message);
            }

        }
    }
}
