using System.Collections.Generic;

namespace EventRate.Core.Base.Helpers.Pagination
{
    public class PaginationFilterQuery
    {
        public PaginationFilterQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PaginationFilterQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }

        public PaginationFilterQuery(FilterColumnQuery filters)
        {
            this.Filters = filters;
        }

        public string Keyword { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public FilterColumnQuery Filters { get; set; }
        public SortQuery Sort { get; set; }
         
    }

    public class FilterColumnQuery
    {
        public string ColumnField { get; set; }
        public string OperatorValue { get; set; }
        public string Value { get; set; }
    }
     
    public class SortQuery
    {
        public string Field { get; set; }
        public string Sort { get; set; }
    }

    public class PaginationFilterQuery<IFilterQuery> : PaginationFilterQuery
    {
        public IFilterQuery Filter { get; set; }

    }
}
