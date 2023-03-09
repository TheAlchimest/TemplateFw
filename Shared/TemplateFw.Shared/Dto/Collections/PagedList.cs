using System;
using System.Collections.Generic;

namespace TemplateFw.Shared.Dtos.Collections
{
    public class Pager
    {
        public int PageNo { get; set; }
        public int PageIndex { get { return PageNo - 1; } }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get { return PageNo > 1; } }
        public bool HasNextPage { get { return PageNo < TotalPages; } }
        public bool IsVisible { get { return TotalPages > 1; } }
        public int PaggingCount { get; set; } = 5;
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int PreviousPageNo { get; set; }
        public int NextPageNo { get; set; }
        public int FirstItemNo { get; set; }

        public Pager()
        {

        }

        public Pager(int pageNo, int pageSize, int count)
        {
            InitializePagination(pageNo, pageSize, count);
        }

        private void InitializePagination(int pageNo, int pageSize, int totalCount)
        {

            PageNo = pageNo;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            if (this.PageSize > this.TotalCount)
            {
                PageSize = TotalCount;
            }
            if (this.PaggingCount > this.TotalPages)
            {
                this.PaggingCount = this.TotalPages;
            }
            int previousPages = (int)Math.Ceiling(PaggingCount / (double)2);
            if (PageNo > previousPages + 1)
            {
                StartPage = PageNo - previousPages;
            }
            if (StartPage < 1)
            {
                StartPage = 1;
            }

            EndPage = StartPage + PaggingCount - 1;

            if (EndPage > TotalPages)
            {
                EndPage = TotalPages;
            }

            if (EndPage - StartPage < PaggingCount)
            {
                StartPage = EndPage - PaggingCount + 1;
            }

            if (HasPreviousPage)
            {
                PreviousPageNo = PageNo - 1;
            }

            if (HasNextPage)
            {
                NextPageNo = PageNo + 1;
            }

            FirstItemNo = ((pageNo - 1) * pageSize) + 1;
        }
    }
    public class PagedList<T> : Pager
    {
        public PagedList()
        {

        }

        public IEnumerable<T> Items { get; set; }
        public PagedList(IEnumerable<T> source, int pageNo, int pageSize, int count) : base(pageNo, pageSize, count)
        {
            Items = source;
        }
    }
}
