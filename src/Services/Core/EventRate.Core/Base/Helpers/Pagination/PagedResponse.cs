using EventRate.Core.Base.Responses;

namespace EventRate.Core.Base.Helpers.Pagination
{
    public class PagedResponse<T> : ApiResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public FilterColumnQuery Filters { get; set; }
        public SortQuery Sort { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, FilterColumnQuery filters, SortQuery sort)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Filters = filters;
            this.Sort = sort;
            this.Message = null;
            this.Success = true;
            this.Data = data;
        }

        public static PagedResponse<T> EmptyPagedResponse() => new(default, 1, 10, null, null);
    } 
}
