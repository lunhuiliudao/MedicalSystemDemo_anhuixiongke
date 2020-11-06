using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    /// <summary>
    /// 麻醉单页描述
    /// </summary>
    public class PageDesc
    {
        public int PageIndex;
        public bool IsMain;
        public PageDesc(int pageIndex, bool isMain)
        {
            PageIndex = pageIndex;
            IsMain = isMain;
        }
    }
    /// <summary>
    /// 分页设置类
    /// </summary>
    public class PagerSetting
    {
        private List<PageDesc> _pageDesc = new List<PageDesc>();

        private int _currentPageIndex=0;

        private DateTimeRange _timeSpan = new DateTimeRange(DateTime.MinValue,DateTime.MinValue);
        private bool _allowPage = false; 
        /// <summary>
        ///是否允许分页
        /// </summary>
        public bool AllowPage
        {
            get
            {
                return _allowPage;
            }
            set
            {
                _allowPage = value;
            }
           
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return _currentPageIndex;
            }
            set
            {
                _currentPageIndex = value;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount
        {
            get
            {
                return _pageDesc.Count;
            }
           
        }
        /// <summary>
        /// 页面描述
        /// </summary>
        public List<PageDesc> PagerDesc
        {
            get
            {
                return _pageDesc;
            }
            
        }
        /// <summary>
        /// 一页数据的时间范围
        /// </summary>
        public DateTimeRange PageTimeSpan
        {
            get
            {
                return _timeSpan;
            }
            set
            {
                _timeSpan = value;
            }
        }
    }
}
