using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Data
{
	public class CraftHubDbContext : IdentityDbContext
	{
		public CraftHubDbContext(DbContextOptions<CraftHubDbContext> options)
			: base(options)
		{
		}
	}
}