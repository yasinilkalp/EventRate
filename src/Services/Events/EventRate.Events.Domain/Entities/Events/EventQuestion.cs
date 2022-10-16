using EventRate.Core.Base.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using static EventRate.Events.Domain.Enums.EventEnums;

namespace EventRate.Events.Domain.Entities.Events
{
    [Table("EventQuestions", Schema = "events")]
    public class EventQuestion : BaseEntity
    {
        public int EventId { get; set; }

        public string Question { get; set; }

        public QuestionType QuestionType { get; set; }

        public int Sort { get; set; }


        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}
