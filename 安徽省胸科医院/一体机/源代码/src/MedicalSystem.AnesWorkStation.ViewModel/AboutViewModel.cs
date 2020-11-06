using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MedicalSystem.AnesWorkStation.ViewModel
{
    public class AboutViewModel : BaseViewModel
    {
        private string FilePath = ExtendAppContext.Current.AppPath +  @"Update\UpdateVerion.xml";
        private bool hasDiff = false;
        private string mainVersionInfo = string.Empty;
        private string latestVersionInfo = string.Empty;

        /// <summary>
        /// 当前版本和最新版本是否相同
        /// </summary>
        public bool HasDiff
        {
            get { return this.hasDiff; }
            set
            {
                this.hasDiff = value;
                this.RaisePropertyChanged("HasDiff");
            }
        }

        /// <summary>
        /// 主版本信息
        /// </summary>
        public string MainVersionInfo
        {
            get { return this.mainVersionInfo; }
            set
            {
                this.mainVersionInfo = value;
                this.RaisePropertyChanged("MainVersionInfo");
            }
        }

        /// <summary>
        /// 最新版本信息
        /// </summary>
        public string LatestVersionInfo
        {
            get { return this.latestVersionInfo; }
            set
            {
                this.latestVersionInfo = value;
                this.RaisePropertyChanged("LatestVersionInfo");
            }
        }

        public AboutViewModel()
        {

        }

        public override void LoadData()
        {
            base.LoadData();
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

                this.MainVersionInfo = "当前版本程序：2.2." + version;

                // 获取版本信息
                MED_VER_INFO maxVerInfo = CommonService.ClientInstance.GetVerInfoList("ANES").Where(x => !x.ROLL_BACK.HasValue || x.ROLL_BACK.Value == 0).OrderByDescending(x => x.VER_NO).FirstOrDefault();
                if(null != maxVerInfo)
                {
                    this.HasDiff = !version.Equals(maxVerInfo.VER_NO.ToString());
                    this.LatestVersionInfo = string.Format("最新版本程序：2.2.{0}{1}", maxVerInfo.VER_NO, HasDiff ? "，请重启更新程序" : "");
                }
                else
                {
                    this.LatestVersionInfo = string.Format("最新版本程序：2.2.{0}", version);
                    this.HasDiff = false;
                }

            }
            catch(Exception e)
            {
                Logger.Error("加载关于界面错误！" + e.Message);
            }
        }
    }
}
