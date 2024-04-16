using System.Security.Claims;
using static CraftHub.Core.Constants.RoleConstants;

namespace CraftHub
{
	public static class ClaimsPrincipalExtensions
	{
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}
		public static bool IsAdmin(this ClaimsPrincipal user)
		{
			return user.IsInRole(AdminRole);
		}
	}
}
