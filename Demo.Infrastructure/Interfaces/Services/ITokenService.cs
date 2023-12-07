using System.Security.Claims;

namespace Demo.Infrastructure.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
