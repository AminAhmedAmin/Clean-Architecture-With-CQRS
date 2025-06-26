namespace VuexyBase.Application.Common.Results
{
    public class Paging<T>
    {
        public PagingDetails Pagination { get; set; }
        public List<T> Result { get; set; } = [];
    }

    public class PagingDetails
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int recordsTotal { get; set; }

        public int TotalPages => (int)Math.Ceiling(recordsTotal / (double)PageSize);

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
        public int Draw { get; set; }
        public int recordsFiltered { get; set; }
    }
}
