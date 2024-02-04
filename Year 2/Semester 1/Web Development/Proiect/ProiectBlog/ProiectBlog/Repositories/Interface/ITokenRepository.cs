using Microsoft.AspNetCore.Identity;

namespace ProiectBlog.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<String> roles);
    }
}
