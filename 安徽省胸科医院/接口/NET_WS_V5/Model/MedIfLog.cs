/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:56:34
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
    public class MedIfLog
    {
        private string _id;
        private string _date;
        private string _time;
        private string _title;
        private string _module;
        private string _grade;
        private string _content;
        private string _source;
        private string _category;
        private string _isShow;
        private string _currentUser;

        public string IsShow
        {
            get { return _isShow; }
            set { _isShow = value; }
        }
        public string CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        /// <summary>
        /// 随机函数GUID
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 产生日期
        /// </summary>
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// 产生时间
        /// </summary>
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 模块 (手术信息，科室同步，检验，等等)
        /// </summary>
        public string Module
        {
            get { return _module; }
            set { _module = value; }
        }

        /// <summary>
        /// 等级，(提示，警告，异常，毁灭性)
        /// </summary>
        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        /// <summary>
        //堆栈内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
            
        }

        /// <summary>
        /// /来源  (麻醉,ICU，数字化)   
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        /// <summary>
        /// 类别，数据库异常，HIS 数据异常，程序异常
        /// </summary>
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

    }
}
