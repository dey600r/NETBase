using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public static class SeedDataUnitOfWork
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			SeedDataVehicleType.Seed(modelBuilder);
			SeedDataConfiguration.Seed(modelBuilder);
			SeedDataRole.Seed(modelBuilder);
		}
	}
}
