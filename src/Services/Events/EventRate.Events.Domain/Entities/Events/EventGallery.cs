using EventRate.Core.Base.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRate.Events.Domain.Entities.Events
{
    [Table("EventGalleries", Schema = "events")]
    public class EventGallery : BaseEntity, IFile
    {
        public int EventId { get; set; } 


        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        
        public string Path { get; set; }

        [StringLength(10)]
        public string Extension { get; set; }

        public string Size { get; set; }

        public int Sort { get; set; }
    }
}
