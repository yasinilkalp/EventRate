namespace EventRate.Events.Application.Responses.Users
{
    public class TokenResponse
    {

        public UserResponse User { get; set; } 

        public string AccessToken { get; set; }

        public long AccessTokenExpires { get; set; }

        public string RefreshToken { get; set; }

        public long RefreshTokenExpires { get; set; }
    }
}
