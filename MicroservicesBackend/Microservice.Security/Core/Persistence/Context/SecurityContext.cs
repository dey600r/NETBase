using Microservice.Security.Core.Persistence.Context.SeedData;
using Microservice.Security.Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Security.Core.Persistence
{
	public class SecurityContext : IdentityDbContext<User, Role, Guid>
	{
		public SecurityContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Seed();
			base.OnModelCreating(builder);
		}
	}
}
