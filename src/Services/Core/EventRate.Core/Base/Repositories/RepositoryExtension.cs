using EventRate.Core.Base.Context;
using EventRate.Core.Base.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventRate.Core.Base.Repositories
{
    public static class RepositoryExtension
    { 

        public static async Task<bool> IsUniqueEmail<T>(this IUniqueEmail entity, BaseContext Context) where T : BaseEntity, IUniqueEmail
        {
            if (entity.Id > 0)
            {
                return await Context.Set<T>().AnyAsync(a => a.Id != entity.Id && a.Email == entity.Email);
            }
            return await Context.Set<T>().AnyAsync(a => a.Email == entity.Email);
        } 

        public static async Task<bool> IsUniqueName<T>(this IUniqueName entity, BaseContext Context) where T : BaseEntity, IUniqueName
        {
            if (entity.Id > 0)
            {
                return await Context.Set<T>().AnyAsync(a => a.Id != entity.Id && a.Name == entity.Name);
            }
            return await Context.Set<T>().AnyAsync(a => a.Name == entity.Name);
        }
    }
}
