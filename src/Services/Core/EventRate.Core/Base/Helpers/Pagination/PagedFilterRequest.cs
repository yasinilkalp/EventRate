using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventRate.Core.Base.Helpers.Pagination
{
    public class PagedFilterRequest<T>
    {
        public PagedFilterRequest(PaginationFilterQuery filterQuery,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includePaths = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            FilterQuery = filterQuery;  
            Predicate = predicate;
            IncludePaths = includePaths;
            OrderBy = orderBy;
        }

        public PaginationFilterQuery  FilterQuery { get; set; }
        public Expression<Func<T, bool>> Predicate { get; set; }
        public Func<IQueryable<T>, IIncludableQueryable<T, object>> IncludePaths { get; set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; set; }
    } 
}
