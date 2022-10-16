using EventRate.Core.Base.Context;
using EventRate.Events.Domain.Entities.Events;
using EventRate.Events.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EventRate.Events.Infrastructure
{
    public class ApplicationContext : BaseContext
    {
        public ApplicationContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventGallery> EventGalleries { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<EventQuestion> EventQuestions { get; set; }
        public DbSet<EventAnswer> EventAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ConvertToTurkeyTimezone(); 

            builder.Entity<User>().HasIndex(a => a.Email).IsUnique();

            builder.Entity<Event>().HasIndex(a => a.Name).IsUnique();

            builder.Entity<EventQuestion>().Property(a => a.QuestionType).HasConversion<string>();

            builder.Entity<EventParticipant>().Property(a => a.Status).HasConversion<string>();

            builder.Entity<EventParticipant>().HasIndex(a => new { a.EventId, a.UserId }).IsUnique();

            builder.Entity<EventAnswer>().HasIndex(a => new { a.EventId, a.QuestionId, a.UserId }).IsUnique();

            builder.Entity<EventQuestion>().HasIndex(a => new { a.EventId, a.Question }).IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
