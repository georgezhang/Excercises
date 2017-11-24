using System.Security.Claims;

namespace Excercises.Models.ModelHelpers
{
    public static class UserExtension
    {
        public static string GetNickName(this System.Security.Principal.IPrincipal usr)
        {
            var nickNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("NickName");
            if (nickNameClaim != null)
                return nickNameClaim.Value;

            return "";
        }
    }
}