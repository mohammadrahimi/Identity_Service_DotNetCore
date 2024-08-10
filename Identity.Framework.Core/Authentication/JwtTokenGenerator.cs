

using Identity.Framework.Core.Utility;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Framework.Core.Authentication;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(
        IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(Guid userId, List<string> roles)
    {
        var singingCredentials = new SigningCredentials(
             new SymmetricSecurityKey(
                 Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
             SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        };

        foreach (string role in roles)
            claims.Add(new(CustomClaims.Roles, role));


        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issure,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: singingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
