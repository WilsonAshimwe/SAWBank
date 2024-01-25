using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Principal;

namespace SAWBank.API.Extensions
{
    public static class UserExtensions
    {
        //extension for finding the logged person Email 
        public static string Email(this ClaimsPrincipal claims)
        {
            return claims.FindFirst(ClaimTypes.Email).Value;
        }

        public static int Id(this ClaimsPrincipal claims)
        {
            return int.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
