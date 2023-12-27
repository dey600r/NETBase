using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Context.SeedData
{
	public static class SeedDataUnitOfWork
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			SeedDataVehicleType.Seed(modelBuilder);
			SeedDataConfiguration.Seed(modelBuilder);
			SeedDataOperationType.Seed(modelBuilder);
			SeedDataMaintenanceElement.Seed(modelBuilder);
		}
	}
}
