using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRate.Core.Base.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 95)]
        public DateTimeOffset? CreatedDate { get; set; }

        [Column(Order = 96)]
        public int? CreatedBy { get; set; }

        [Column(Order = 97)]
        public DateTimeOffset? UpdatedDate { get; set; }

        [Column(Order = 98)]
        public int? UpdatedBy { get; set; }

        [Column(Order = 99)]
        public bool IsDelete { get; set; }

    }
}
