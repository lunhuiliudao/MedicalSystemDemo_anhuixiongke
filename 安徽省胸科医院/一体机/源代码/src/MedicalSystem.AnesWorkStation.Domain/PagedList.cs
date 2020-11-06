using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [DataContract]
    public class PagedList<T> : IPagedList<T> 
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        [DataMember]
        public List<T> List { get; private set; }
        /// <summary>
        /// 当前页索引
        /// </summary>
        [DataMember]
        public int PageIndex { get; private set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        [DataMember]
        public int PageSize { get; private set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public int TotalCount { get; private set; }
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public int TotalPages { get; private set; }
        /// <summary>
        /// 是否有前页
        /// </summary>
        [DataMember]
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        /// <summary>
        /// 是否有后页
        /// </summary>
        [DataMember]
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        private PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int total = source != null ? source.Count() : 0;
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            List = new List<T>();
            if (source != null && source.Count() > 0)
                List.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>        
        private PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source != null ? source.Count : 0;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            List = new List<T>();
            if (source != null && source.Count > 0)
                List.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        [JsonConstructor]
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source != null ? source.Count() : 0;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            List = new List<T>();
            if (source != null && source.Count() > 0)
                List.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        private PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            List = new List<T>();
            if (source != null && source.Count() > 0)
                List.AddRange(source);
        }        
    }


    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T> //: IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
