using Common.Settings;
using Core.UserSchema;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.ApplicationServices;

public interface IJwtService
{
    string Generate(User user,List<Role> userRoles);
}

public class JwtService : IJwtService
{
    private readonly SiteSettings _siteSettings;
    public JwtService(IOptionsSnapshot<SiteSettings> settings)
    {
        _siteSettings = settings.Value;
    }

    public string Generate(User user,List<Role> userRoles)
    {
        var secretKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.SecretKey); // longer that 16 character
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

        var encryptionkey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.EncryptKey); //must be 16 character
        var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

        var claims = _getClaimsIdentity(user,userRoles);

        var descriptor = new SecurityTokenDescriptor()
        {
            Issuer = _siteSettings.JwtSettings.Issuer,
            Audience = _siteSettings.JwtSettings.Audience,
            IssuedAt = DateTime.Now,
            NotBefore = DateTime.Now,
            Expires = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.NotBeforeMinutes),
            SigningCredentials = signingCredentials,
            EncryptingCredentials = encryptingCredentials,
            Subject = new ClaimsIdentity(claims)
        };

        #region for avoiding name conversion from DotNet Standards to Jwt Standards
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
        #endregion

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(descriptor);
        var jwt = tokenHandler.WriteToken(securityToken);

        return jwt;
    }

    private IEnumerable<Claim> _getClaimsIdentity(User user,List<Role> userRoles)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
        };

        foreach (var role in userRoles)
            claims.Add(new Claim(ClaimTypes.Role, role.Name));

        return claims;
    }
}
