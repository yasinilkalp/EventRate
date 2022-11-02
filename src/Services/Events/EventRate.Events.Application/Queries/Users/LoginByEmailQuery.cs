using EventRate.Core.Base.Responses;
using EventRate.Events.Application.Responses.Users;
using MediatR;

namespace EventRate.Events.Application.Queries.Users
{
    public record LoginByEmailQuery(string Email, string Password) : IRequest<ApiResponse<TokenResponse>>;
}
