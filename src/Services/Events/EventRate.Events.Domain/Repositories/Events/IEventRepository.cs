using EventRate.Core.Base.Repositories;
using EventRate.Events.Domain.Entities.Events;

namespace EventRate.Events.Domain.Repositories.Events
{
    public interface IEventRepository : IRepository<Event>, IUniqueNameRepository<Event>
    {
    }
}
