using EventRate.Core.Base.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRate.Events.Domain.Entities.Users
{
    [Table("Users", Schema = "users")]
    public class User : BaseEntity, IUniqueEmail
    {

        [StringLength(64)]
        public string FirstName { get; set; }

        [StringLength(64)]
        public string LastName { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }
    }
}
