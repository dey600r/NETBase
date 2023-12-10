using Microservice.VehicleApi.Core.Constants;
using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Context.SeedData
{
    public static class SeedDataVehicleType
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 1, 
				Code = Constants.VEHICLE_TYPE_CODE_MOTO, 
				Description = Constants.VEHICLE_TYPE_DESCRIPTION_MOTO,
				CreatedUser = Constants.USER_UNKNOWN_AUDIT,
				CreatedDate = Constants.DATE_AUDIT
			});
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 2,
				Code = Constants.VEHICLE_TYPE_CODE_CAR, 
				Description = Constants.VEHICLE_TYPE_DESCRIPTION_CAR,
				CreatedUser = Constants.USER_UNKNOWN_AUDIT,
				CreatedDate = Constants.DATE_AUDIT
			});
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 3, 
				Code = Constants.VEHICLE_TYPE_CODE_OTHER, 
				Description = Constants.VEHICLE_TYPE_DESCRIPTION_OTHER,
				CreatedUser = Constants.USER_UNKNOWN_AUDIT,
				CreatedDate = Constants.DATE_AUDIT
			});
		}
	}
}
