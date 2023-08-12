namespace Common.Settings;

public class SiteSettings
{
    public string WebSiteUrl { get; set; } = string.Empty;
    public JwtSettings JwtSettings { get; set; } = new JwtSettings();
}
