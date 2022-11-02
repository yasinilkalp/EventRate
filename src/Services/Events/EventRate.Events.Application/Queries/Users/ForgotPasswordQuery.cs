using EventRate.Core.Base.Responses;
using EventRate.Events.Application.Responses.Users;
using MediatR;

namespace EventRate.Events.Application.Queries.Users
{
    public record ForgotPasswordQuery(string Email) : IRequest<ApiResponse<UserResponse>>;
}
