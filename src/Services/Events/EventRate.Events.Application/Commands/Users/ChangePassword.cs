using EventRate.Core.Base.Responses;
using MediatR;

namespace EventRate.Events.Application.Commands.Users
{
    public record ChangePassword(int Id, string CurrentPassword, string NewPassword) : IRequest<ApiResponse>;
}
