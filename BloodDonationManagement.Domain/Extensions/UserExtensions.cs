namespace BloodDonationManagement.Domain.Entities;

public static class UserExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Sid, user.Id.ToString()),
            new(ClaimTypes.Name, user.Email)
        };

        return claims;
    }
}