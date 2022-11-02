﻿using AutoMapper;
using EventRate.Core.Base.Responses;
using EventRate.Events.Application.Commands.Users;
using EventRate.Events.Application.Responses.Users;
using EventRate.Events.Domain.Base;
using EventRate.Events.Domain.Entities.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventRate.Events.Application.Handlers.Users
{
    internal sealed class UserRegisterHandler : IRequestHandler<UserRegister, ApiResponse<UserResponse>>
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public UserRegisterHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserResponse>> Handle(UserRegister request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<User>(request);

            bool isUserEmailUnique = await _repo.Users.IsUniqueEmail(mapped);
            if (isUserEmailUnique)
                return new ErrorApiResponse<UserResponse>("E-posta adresi başka bir kullanıcı tarafından kullanılmaktadır.");

            var response = await _repo.Users.AddAsync(mapped);

            if (response == null)
                return new ErrorApiResponse<UserResponse>("Kullanıcı Oluşturulamadı.");

            var userResponse = _mapper.Map<UserResponse>(response);

            return new SuccessApiResponse<UserResponse>(userResponse);
        }
    }
}
