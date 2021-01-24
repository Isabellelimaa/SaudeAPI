namespace SaudeAPI.Configs
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public int FinalExpiration { get; set; }
    }

    public class RefreshTokenData
    {
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
    }
}