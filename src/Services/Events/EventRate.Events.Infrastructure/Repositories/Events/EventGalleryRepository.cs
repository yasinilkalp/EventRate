using EventRate.Core.Base.Repositories;
using EventRate.Events.Domain.Entities.Events;
using EventRate.Events.Domain.Repositories.Events;

namespace EventRate.Events.Infrastructure.Repositories.Events
{
    public class EventGalleryRepository : BaseRepository<EventGallery>, IEventGalleryRepository
    {
        public EventGalleryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
