using FootyConnect.Application.Abstractions;
using FootyConnect.CrossCuttingConcerns.DateTimes;
using FootyConnect.Domain.Entities;
using FootyConnect.Infrastructure.ConfigurationOptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FootyConnect.Infrastructure.Authentication;

public class JwtProvider(IDateTimeProvider dateTimeProvider, 
    IOptions<AppSettings> _appSettings) : IJwtProvider
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly JwtOptions _jwtOptions = _appSettings.Value.JwtOptions;

    public string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            _dateTimeProvider.UtcNow.AddHours(1),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;  
    }
}
