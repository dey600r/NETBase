using Microservice.IoC.Utils;
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
				Code = AppConstants.VEHICLE_TYPE_CODE_MOTO, 
				Description = AppConstants.VEHICLE_TYPE_DESCRIPTION_MOTO,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 2,
				Code = AppConstants.VEHICLE_TYPE_CODE_CAR, 
				Description = AppConstants.VEHICLE_TYPE_DESCRIPTION_CAR,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 3, 
				Code = AppConstants.VEHICLE_TYPE_CODE_OTHER, 
				Description = AppConstants.VEHICLE_TYPE_DESCRIPTION_OTHER,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
		}
	}
}
