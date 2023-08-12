namespace Common.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public string EncryptKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int NotBeforeMinutes { get; set; }
    public int ExpirationDay { get; set; }
}
