using EventRate.Core.Base.Entities;
using EventRate.Events.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRate.Events.Domain.Entities.Events
{
    [Table("Events", Schema = "events")]
    public class Event : BaseEntity, IUniqueName
    {
        public int UserId { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(512)]
        public string SummaryText { get; set; }

        public string Description { get; set; }

        public DateTimeOffset EventDate { get; set; }

        public DateTimeOffset? AnswerEndDate { get; set; }

        public string Location { get; set; }

        public Guid QrCode { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
