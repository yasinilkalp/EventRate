using EventRate.Events.Domain.Repositories.Events;
using EventRate.Events.Domain.Repositories.Users;
using System.Threading.Tasks;

namespace EventRate.Events.Domain.Base
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IEventRepository Events { get; }
        IEventGalleryRepository EventGalleries { get; }
        IEventParticipantRepository EventParticipants { get; }
        IEventQuestionRepository EventQuestions { get; }
        IEventAnswerRepository EventAnswers { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
