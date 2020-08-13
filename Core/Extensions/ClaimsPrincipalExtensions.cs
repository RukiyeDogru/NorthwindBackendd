using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace Core.Extensions
{ //bir kullanıcının rollerine ulaşabilmeliyim

   public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
         
        public static List<string> ClaimsRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(claimType: ClaimTypes.Role);
        }
    }
}
