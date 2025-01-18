using BloodDonationManagement.Domain.Extensions;

namespace BloodDonationManagement.Infrastructure.AuthorizationAndAuthentication.Services;

public class JwtTokenService(IOptions<JwtSettings> settings)
{
    private readonly JwtSettings _jwtSettings = settings.Value;

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.JwtKey!);
        var claims = user.GetClaims();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
            Issuer = _jwtSettings.Emissary,
            Audience = _jwtSettings.ValidOn,
            SigningCredentials = new SigningCredentials(
                key: new SymmetricSecurityKey(key),
                algorithm: SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}