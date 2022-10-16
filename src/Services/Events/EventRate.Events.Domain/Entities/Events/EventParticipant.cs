using EventRate.Core.Base.Entities;
using EventRate.Events.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;
using static EventRate.Events.Domain.Enums.EventEnums;

namespace EventRate.Events.Domain.Entities.Events
{
    [Table("EventParticipants", Schema = "events")]
    public class EventParticipant : BaseEntity
    {

        public int EventId { get; set; }

        public int UserId { get; set; }

        public ParticipantType Status { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
