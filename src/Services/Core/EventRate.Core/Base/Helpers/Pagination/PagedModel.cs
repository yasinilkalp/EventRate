using System.Collections.Generic;

namespace EventRate.Core.Base.Helpers.Pagination
{
    public class PagedModel<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> PagedData { get; set; }

        public PagedModel(IEnumerable<T> pagedData, int totalRecords)
        {
            PagedData = pagedData;
            TotalRecords = totalRecords;
        }
    }

    
}
