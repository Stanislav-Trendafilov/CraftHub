using Microsoft.AspNetCore.Identity;
using static CraftHub.Core.Constants.RoleConstants;
namespace CraftHub
{
	public static class ApplicationBuilderExtensions
	{
		public 	static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
			var roleManager=scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			if(roleManager != null && userManager != null&&await roleManager.RoleExistsAsync(AdminRole)==false)
			{
				var role = new IdentityRole(AdminRole);
				await roleManager.CreateAsync(role);

				var admin = await userManager.FindByEmailAsync("admin@mail.com");

				if(admin!=null)
				{
					await userManager.AddToRoleAsync(admin, role.Name);
				}
			}

		}
	}
}
