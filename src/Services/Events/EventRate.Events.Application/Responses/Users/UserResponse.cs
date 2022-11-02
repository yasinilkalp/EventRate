using EventRate.Core.Base.Responses;
using System.Collections.Generic;

namespace EventRate.Events.Application.Responses.Users
{
    public class UserResponse : BaseResponse
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
