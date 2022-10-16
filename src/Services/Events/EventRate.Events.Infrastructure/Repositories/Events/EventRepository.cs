using EventRate.Core.Base.Repositories;
using EventRate.Events.Domain.Entities.Events;
using EventRate.Events.Domain.Repositories.Events;
using System.Threading.Tasks;

namespace EventRate.Events.Infrastructure.Repositories.Events
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly ApplicationContext Context;
        public EventRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public Task<bool> IsUniqueName(Event entity) => entity.IsUniqueName<Event>(Context);
    }
}
