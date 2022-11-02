using EventRate.Core.Base.Responses;
using EventRate.Events.Application.Responses.Users;
using MediatR;

namespace EventRate.Events.Application.Commands.Users
{
    public class UserUpdate : IRequest<ApiResponse<UserResponse>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
