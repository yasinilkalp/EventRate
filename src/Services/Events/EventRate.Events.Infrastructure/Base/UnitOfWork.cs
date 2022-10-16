using EventRate.Events.Domain.Base;
using EventRate.Events.Domain.Repositories.Events;
using EventRate.Events.Domain.Repositories.Users;
using EventRate.Events.Infrastructure.Repositories.Events;
using EventRate.Events.Infrastructure.Repositories.Users;
using System.Threading.Tasks;

namespace EventRate.Events.Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IUserRepository _users;
        private IEventRepository _events;
        private IEventGalleryRepository _eventsGalleries;
        private IEventParticipantRepository _eventsParticipants;
        private IEventQuestionRepository _eventsQuestions;
        private IEventAnswerRepository _eventsAnswers;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);

        public IEventRepository Events => _events ??= new EventRepository(_context);

        public IEventGalleryRepository EventGalleries => _eventsGalleries ??= new EventGalleryRepository(_context);

        public IEventParticipantRepository EventParticipants => _eventsParticipants ??= new EventParticipantRepository(_context);

        public IEventQuestionRepository EventQuestions => _eventsQuestions ??= new EventQuestionRepository(_context);

        public IEventAnswerRepository EventAnswers => _eventsAnswers ??= new EventAnswerRepository(_context);

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Task.Run(() => _context.SaveChanges());
        }
    }
}
