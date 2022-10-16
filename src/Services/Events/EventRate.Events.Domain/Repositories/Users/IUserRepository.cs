using EventRate.Core.Base.Repositories;
using EventRate.Events.Domain.Entities.Users;

namespace EventRate.Events.Domain.Repositories.Users
{
    public interface IUserRepository : IRepository<User>, IUniqueEmailRepository<User>
    {
    }
}
