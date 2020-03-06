using System.Threading.Tasks;
using System.Security.Claims;

namespace Authentication.AuthenticationFactory
{
    /// <summary>
    /// Authentication Factory Interface by using Json Web Token security
    /// </summary>
    public interface IJwtAuthenticationFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}
