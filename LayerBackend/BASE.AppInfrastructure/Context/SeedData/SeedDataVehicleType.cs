using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
    public static class SeedDataVehicleType
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 1, 
				Code = ConstantsApp.VEHICLE_TYPE_CODE_MOTO, 
				Description = ConstantsApp.VEHICLE_TYPE_DESCRIPTION_MOTO,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 2,
				Code = 
				ConstantsApp.VEHICLE_TYPE_CODE_CAR, 
				Description = ConstantsApp.VEHICLE_TYPE_DESCRIPTION_CAR,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType { 
				Id = 3, 
				Code = ConstantsApp.VEHICLE_TYPE_CODE_OTHER, 
				Description = ConstantsApp.VEHICLE_TYPE_DESCRIPTION_OTHER,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
