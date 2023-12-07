using Microsoft.EntityFrameworkCore;

namespace Microservice.Security.Core.Persistence.Context.SeedData
{
	public static class SeedDataUnitOfWork
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			SeedDataUserRole.Seed(modelBuilder);
		}
	}
}
