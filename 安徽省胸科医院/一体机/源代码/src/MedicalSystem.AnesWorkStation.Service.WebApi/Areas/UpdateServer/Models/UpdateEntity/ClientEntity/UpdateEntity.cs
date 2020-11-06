using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateEntity
{
    /// <summary>
    /// 获取更新实体
    /// </summary>
    public class UpdateInfoEntity
    {
        private int _VerionNo;
        /// <summary>
        /// 版本号
        /// </summary>
        public int VerionNo
        {
            get { return _VerionNo; }
            set { _VerionNo = value; }
        }

        private string _Description;
        /// <summary>
        /// 版本描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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

        private string _RollBackDesc;
        /// <summary>
        /// 回退原因
        /// </summary>
        public string RollBackDesc
        {
            get { return _RollBackDesc; }
            set { _RollBackDesc = value; }
        }

        private int _IsForcibly;
        /// <summary>
        /// 是否强制更新
        /// </summary>
        public int IsForcibly
        {
            get { return _IsForcibly; }
            set { _IsForcibly = value; }
        }

        private string _FilePath;
        /// <summary>
        /// 下载文件路劲
        /// </summary>
        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }
    }
}
