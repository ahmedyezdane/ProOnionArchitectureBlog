using Common.ApiResult;
using Common.Exceptions;
using Common.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace WebFramework.Configuration;
public static partial class ServiceCollectionExtensions
{
    public static void AddJwtAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var secretkey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
            var encryptionkey = Encoding.UTF8.GetBytes(jwtSettings.EncryptKey);


            var validationParameters = new TokenValidationParameters
            {
                // this create tolerance time for token.
                // this means that when you set expire time and in clockSkew you set time(like 3 minutes),
                // when the time expires,after 3 minute(this time set in clockskew) will be expires.
                // this also effect on notBefore time!
                ClockSkew = TimeSpan.Zero, // default 5 min
                RequireSignedTokens = true, // this means that,every token must have sign or not.

                ValidateIssuerSigningKey = true, // this means that, the sign will be validated or not.
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(secretkey), // the signing key

                RequireExpirationTime = true, // the token must not have expired or not.
                ValidateLifetime = true,

                ValidateAudience = true, // default false
                //ValidAudience = jwtSettings.Audience,
                ValidAudience = "MyApi",

                ValidateIssuer = true, // default false
                //ValidIssuer = jwtSettings.Issuer,
                ValidIssuer = "MyApi",

                TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey),
            };

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = validationParameters;

        });
    }
}
