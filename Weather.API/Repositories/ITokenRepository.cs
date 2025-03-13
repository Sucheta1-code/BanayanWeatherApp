using Microsoft.AspNetCore.Identity;

namespace Weather.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
