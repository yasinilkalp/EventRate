using EventRate.Core.Base.Entities;
using EventRate.Events.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRate.Events.Domain.Entities.Events
{
    [Table("EventAnswers", Schema = "events")]
    public class EventAnswer : BaseEntity
    {
        public int EventId { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }


        public int? Rate { get; set; }

        [StringLength(512)]
        public string Comment { get; set; }


        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("QuestionId")]
        public virtual EventQuestion Question { get; set; }
    }
}
