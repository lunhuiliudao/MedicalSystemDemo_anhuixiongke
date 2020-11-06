using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateEntity
{
    /// <summary>
    /// 本机信息
    /// </summary>
    public class MachineInfoEntity
    {
        private string _SystemName;
        /// <summary>
        /// 本机系统名称
        /// </summary>
        public string SystemName
        {
            get { return _SystemName; }
            set { _SystemName = value; }
        }

        private string _IP;
        /// <summary>
        /// 本机IP地址
        /// </summary>
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        private string _AppKey;
        /// <summary>
        /// 更新应用程序主键
        /// </summary>
        public string AppKey
        {
            get { return _AppKey; }
            set { _AppKey = value; }
        }

        private int _VerionNo;
        /// <summary>
        /// 更新版本号
        /// </summary>
        public int VerionNo
        {
            get { return _VerionNo; }
            set { _VerionNo = value; }
        }

        private int _IsDownload;
        /// <summary>
        /// 是否下载完成
        /// </summary>
        public int IsDownload
        {
            get { return _IsDownload; }
            set { _IsDownload = value; }
        }

        private DateTime _DownloadTime;
        /// <summary>
        /// 下载完成时间
        /// </summary>
        public DateTime DownloadTime
        {
            get { return _DownloadTime; }
            set { _DownloadTime = value; }
        }

        private int _IsUpdated;
        /// <summary>
        /// 是否更新完成
        /// </summary>
        public int IsUpdated
        {
            get { return _IsUpdated; }
            set { _IsUpdated = value; }
        }

        private DateTime _UpdatedTime;
        /// <summary>
        /// 更新完成时间
        /// </summary>
        public DateTime UpdatedTime
        {
            get { return _UpdatedTime; }
            set { _UpdatedTime = value; }
        }

        private int _IsRollBack;
        /// <summary>
        /// 是否回退
        /// </summary>
        public int IsRollBack
        {
            get { return _IsRollBack; }
            set { _IsRollBack = value; }
        }

        private DateTime _RollBackTime;
        /// <summary>
        /// 回退完成回退时间
        /// </summary>
        public DateTime RollBackTime
        {
            get { return _RollBackTime; }
            set { _RollBackTime = value; }
        }
    }
}
