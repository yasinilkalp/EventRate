using AutoMapper;
using EventRate.Core.Base.Responses;
using EventRate.Events.Application.Commands.Users;
using EventRate.Events.Application.Responses.Users;
using EventRate.Events.Domain.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventRate.Events.Application.Handlers.Users
{
    internal sealed class UserUpdateHandler : IRequestHandler<UserUpdate, ApiResponse<UserResponse>>
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public UserUpdateHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserResponse>> Handle(UserUpdate request, CancellationToken cancellationToken)
        {
            var model = await _repo.Users.GetAsync(new(a => a.Id == request.Id));

            if (model == null)
                return new ErrorApiResponse<UserResponse>("Kullanıcı bulunamadı.");

            var mapped = _mapper.Map(request, model);

            bool isUserEmailUnique = await _repo.Users.IsUniqueEmail(mapped);
            if (isUserEmailUnique)
                return new ErrorApiResponse<UserResponse>("E-posta adresi başka bir kullanıcı tarafından kullanılmaktadır.");

            var response = await _repo.Users.UpdateAsync(mapped);

            if (response == null)
                return new ErrorApiResponse<UserResponse>("Kullanıcı güncellenemedi.");

            var userResponse = _mapper.Map<UserResponse>(response);

            return new SuccessApiResponse<UserResponse>(userResponse);
        }
    }
}
