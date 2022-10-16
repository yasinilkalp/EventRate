using EventRate.Core.Base.Entities;
using EventRate.Core.Base.Helpers.GenericExpressions;
using EventRate.Core.Base.Helpers.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventRate.Core.Base.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<IList<T>> AddRangeAsync(IList<T> entities);

        Task<T> UpdateAsync(T entity);
        Task<IList<T>> UpdateRangeAsync(IList<T> entities);

        Task<bool> DeleteAsync(T entity);

        Task DeleteRangeAsync(IList<T> entities);

        Task<T> GetAsync(GenericExpression<T> parameters = null);

        Task<IEnumerable<T>> GetAllAsync(GenericExpression<T> parameters = null);

        Task<IEnumerable<R>> GetGroupedAsync<R>(GenericGroupExpression<T, R> parameters);

        Task<PagedModel<T>> GetAllPagedAsync(PagedFilterRequest<T> filterRequest);

    }

    public interface IUniqueEmailRepository<T> where T : IUniqueEmail
    {
        Task<bool> IsUniqueEmail(T entity);
    }

    public interface IUniqueNameRepository<T> where T : IUniqueName
    {
        Task<bool> IsUniqueName(T entity);
    }
}
