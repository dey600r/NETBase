using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context.SeedData
{
	public static class SeedDataUnitOfWork
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			SeedDataConfiguration.Seed(modelBuilder);
			SeedDataMaintenanceFreq.Seed(modelBuilder);
		}
	}
}
