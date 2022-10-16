using System;

namespace EventRate.Core.Base.Entities
{
    public interface IBaseEntity
    {
        public int Id { get; set; }

        DateTimeOffset? CreatedDate { get; }

        int? CreatedBy { get; }

        DateTimeOffset? UpdatedDate { get; }

        int? UpdatedBy { get; }

        public bool IsDelete { get; set; }
    }
}
