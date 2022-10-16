using EventRate.Core.Base.Context;
using EventRate.Core.Base.Entities;
using EventRate.Core.Base.Helpers.GenericExpressions;
using EventRate.Core.Base.Helpers.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRate.Core.Base.Repositories
{


    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BaseContext Context;

        public BaseRepository(BaseContext context)
        {
            Context = context;
        }


        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {

                Context.Set<T>().Add(entity);

                await Context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public virtual async Task<IList<T>> AddRangeAsync(IList<T> entities)
        {
            Context.Set<T>().AddRange(entities);

            await Context.SaveChangesAsync();

            return entities;
        }


        public virtual async Task<T> UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);

            Context.Entry(entity).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IList<T>> UpdateRangeAsync(IList<T> entities)
        {
            Context.Set<T>().UpdateRange(entities);

            entities.ToList().ForEach(a =>
            {
                Context.Entry(a).State = EntityState.Modified;
            });

            await Context.SaveChangesAsync();

            return entities;
        }


        public virtual async Task<bool> DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);

            Context.Entry(entity).State = EntityState.Deleted;

            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task DeleteRangeAsync(IList<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);

            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(GenericExpression<T> parameters = null)
        {
            IQueryable<T> query = Context.Set<T>().Where(a => !a.IsDelete);

            if (parameters == null) return query;

            if (parameters.disableTracking) query = query.AsNoTracking();

            if (parameters.includePaths != null)
                query = parameters.includePaths(query);

            if (parameters.predicate != null) query = query.Where(parameters.predicate);

            if (parameters.orderBy != null)
                return await parameters.orderBy(query).ToListAsync();

            string sql = query.ToQueryString();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetAsync(GenericExpression<T> parameters = null)
        {
            IQueryable<T> query = Context.Set<T>().Where(a => !a.IsDelete);

            if (parameters == null) return await query.FirstOrDefaultAsync();

            if (parameters.disableTracking) query = query.AsNoTracking();

            if (parameters.includePaths != null)
                query = parameters.includePaths(query);

            if (parameters.predicate != null) query = query.Where(parameters.predicate);

            if (parameters.orderBy != null)
                return await parameters.orderBy(query).FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<PagedModel<T>> GetAllPagedAsync(PagedFilterRequest<T> filterRequest)
        {
            IQueryable<T> query = Context.Set<T>().Where(a => !a.IsDelete);

            if (filterRequest.IncludePaths != null)
                query = filterRequest.IncludePaths(query);

            if (filterRequest.Predicate != null) query = query.Where(filterRequest.Predicate);

            query = filterRequest.OrderBy == null ? query.OrderByDescending(a => a.Id) : filterRequest.OrderBy(query);

            var totalRecords = await query.CountAsync();

            var pageNumber = filterRequest.FilterQuery.PageNumber;
            var pageSize = filterRequest.FilterQuery.PageSize;

            var pagedData = await query
                 .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                 .ToListAsync();

            string sql = query.ToQueryString();

            return new PagedModel<T>(pagedData, totalRecords);
        }

        public virtual async Task<IEnumerable<R>> GetGroupedAsync<R>(GenericGroupExpression<T, R> parameters)
        {
            IQueryable<T> query = Context.Set<T>().Where(a => !a.IsDelete).AsNoTracking();

            if (parameters.includePaths != null)
                query = parameters.includePaths(query);

            if (parameters.predicate != null) query = query.Where(parameters.predicate);

            var grouped = query.GroupBy(parameters.groupBy);

            if (parameters.orderBy != null) grouped = parameters.orderBy(grouped);

            var result = grouped.Select(parameters.selector);

            if (parameters.topCount.HasValue)
                result = result.Take(parameters.topCount.Value);

            string sql = result.ToQueryString();

            return await result.ToListAsync();
        }

    }
}
