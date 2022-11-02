using AutoMapper;
using EventRate.Core.Base.Responses;
using EventRate.Events.Application.Queries.Users;
using EventRate.Events.Application.Responses.Users;
using EventRate.Events.Domain.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventRate.Events.Application.Handlers.Users
{
    internal sealed class ForgotPasswordHandler : IRequestHandler<ForgotPasswordQuery, ApiResponse<UserResponse>>
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public ForgotPasswordHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserResponse>> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.Users.GetAsync(new(u => u.Email.Equals(request.Email)));

            if (user == null)
                return new ErrorApiResponse<UserResponse>("Kullanıcı bulunamadı, girilen bilgileri kontrol edin.");

            var mapped = _mapper.Map<UserResponse>(user);

            return new SuccessApiResponse<UserResponse>(mapped, message: "Şifre yenileme iletiniz e-posta adresinize gönderilmiştir.");
        }
    }
}
