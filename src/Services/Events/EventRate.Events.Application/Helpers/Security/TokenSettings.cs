namespace EventRate.Events.Application.Helpers.Security
{
    public class TokenSettings : ITokenSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ProviderKey { get; set; }

        public int AccessTokenExpiration { get; set; }
        public string AccessTokenSecurityKey { get; set; }

        public int RefreshTokenExpiration { get; set; }
        public string RefreshTokenSecurityKey { get; set; }
    }

    public interface ITokenSettings
    {
        string Issuer { get; set; }
        string Audience { get; set; }
        string ProviderKey { get; set; }

        int AccessTokenExpiration { get; set; }
        string AccessTokenSecurityKey { get; set; }

        int RefreshTokenExpiration { get; set; }
        string RefreshTokenSecurityKey { get; set; }
    }
}
