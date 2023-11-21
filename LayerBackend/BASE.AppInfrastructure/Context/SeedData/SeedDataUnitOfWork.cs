using BASE.AppInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public static class SeedDataUnitOfWork
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			SeedDataVehicleType.Seed(modelBuilder);
			SeedDataConfiguration.Seed(modelBuilder);
		}
	}
}
