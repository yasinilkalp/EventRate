using System;
using System.Collections.Generic;

namespace EventRate.Core.Base.Helpers.Pagination
{
    public static class PagedHelper
    {
        public static PagedResponse<IEnumerable<T>> CreatePagedResponse<T>(IEnumerable<T> pagedData, PaginationFilterQuery validFilter, int totalRecords)
        {
            var response = new PagedResponse<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize, validFilter.Filters, validFilter.Sort);

            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);

            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            response.TotalPages = roundedTotalPages;

            response.TotalRecords = totalRecords;

            return response;
        }

    }
}
