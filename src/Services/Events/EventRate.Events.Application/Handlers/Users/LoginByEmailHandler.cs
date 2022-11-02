using AutoMapper;
using EventRate.Core.Base.Responses;
using EventRate.Events.Application.Helpers;
using EventRate.Events.Application.Helpers.Security;
using EventRate.Events.Application.Queries.Users;
using EventRate.Events.Application.Responses.Users;
using EventRate.Events.Domain.Base;
using MediatR;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;

namespace EventRate.Events.Application.Handlers.Users
{

    internal sealed class LoginByEmailHandler : IRequestHandler<LoginByEmailQuery, ApiResponse<TokenResponse>>
    {
        private readonly IUnitOfWork _repo;
        private readonly ITokenSettings _settings;
        private readonly IMapper _mapper;

        public LoginByEmailHandler(IUnitOfWork repo, ITokenSettings settings, IMapper mapper)
        {
            _repo = repo;
            _settings = settings;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TokenResponse>> Handle(LoginByEmailQuery request, CancellationToken cancellationToken)
        {
            // Kullanıcı Login için Veritabanında aranıyor. 
            var user = await _repo.Users.GetAsync(new(u => u.Email.Equals(request.Email) && u.Password.Equals(request.Password)));

            // Kullanıcı bulamadıysak bilgi dönüyoruz.
            if (user == null)
                return new ErrorApiResponse<TokenResponse>("Bilgileriniz eksik veya hatalı."); 

            // AccessToken ve RefreshToken üretiliyor. 
            JwtSecurityTokenHandler tokenHandler = new();
            var accessToken = JwtSecurity.GetAccessToken(_settings, user);
            var refreshToken = JwtSecurity.GetRefreshToken(_settings, user);
            user.RefreshToken = tokenHandler.WriteToken(refreshToken);

            // RefreshToken kullanıcı satırında güncelleniyor. 
            await _repo.Users.UpdateAsync(user);

            // User bilgisi Response eklenmesi için mapleniyor.
            var userResponse = _mapper.Map<UserResponse>(user);

            TokenResponse tokenResponse = new()
            {
                AccessToken = tokenHandler.WriteToken(accessToken),
                AccessTokenExpires = TimeSpan.FromHours(_settings.AccessTokenExpiration).Ticks,

                RefreshToken = tokenHandler.WriteToken(refreshToken),
                RefreshTokenExpires = TimeSpan.FromHours(_settings.RefreshTokenExpiration).Ticks,
                 
                User = userResponse, 
            };
            return new SuccessApiResponse<TokenResponse>(tokenResponse);
        }
    }
}
