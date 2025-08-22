using Microservice.IoC.Utils;
using Microservice.VehicleApi.Core.Constants;
using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Context.SeedData
{
	public class SeedDataOperationType
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 1,
				Code = AppConstants.OPERATION_TYPE_MAINTENANCE_WORKSHOP_CODE,
				Description = AppConstants.OPERATION_TYPE_MAINTENANCE_WORKSHOP_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 2,
				Code = AppConstants.OPERATION_TYPE_FAILURE_WORKSHOP_CODE,
				Description = AppConstants.OPERATION_TYPE_FAILURE_WORKSHOP_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 3,
				Code = AppConstants.OPERATION_TYPE_CLOTHES_CODE,
				Description = AppConstants.OPERATION_TYPE_CLOTHES_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 4,
				Code = AppConstants.OPERATION_TYPE_TOOLS_CODE,
				Description = AppConstants.OPERATION_TYPE_TOOLS_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 5,
				Code = AppConstants.OPERATION_TYPE_OTHER_CODE,
				Description = AppConstants.OPERATION_TYPE_OTHER_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 6,
				Code = AppConstants.OPERATION_TYPE_MAINTENANCE_HOME_CODE,
				Description = AppConstants.OPERATION_TYPE_MAINTENANCE_HOME_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 7,
				Code = AppConstants.OPERATION_TYPE_FAILURE_HOME_CODE,
				Description = AppConstants.OPERATION_TYPE_FAILURE_HOME_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 8,
				Code = AppConstants.OPERATION_TYPE_SPARE_PARTS_CODE,
				Description = AppConstants.OPERATION_TYPE_SPARE_PARTS_DESCRIPTION,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
		}
	}
}
