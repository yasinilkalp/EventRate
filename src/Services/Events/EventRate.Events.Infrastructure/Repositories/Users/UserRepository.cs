using EventRate.Core.Base.Repositories;
using EventRate.Events.Domain.Entities.Users;
using EventRate.Events.Domain.Repositories.Users;
using System.Threading.Tasks;

namespace EventRate.Events.Infrastructure.Repositories.Users
{ 
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationContext Context;
        public UserRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public Task<bool> IsUniqueEmail(User entity) => entity.IsUniqueEmail<User>(Context);

         
    }
}
