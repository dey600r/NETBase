using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public class SeedDataOperationType
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 1,
				Code = ConstantsApp.OPERATION_TYPE_MAINTENANCE_WORKSHOP_CODE,
				Description = ConstantsApp.OPERATION_TYPE_MAINTENANCE_WORKSHOP_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 2,
				Code = ConstantsApp.OPERATION_TYPE_FAILURE_WORKSHOP_CODE,
				Description = ConstantsApp.OPERATION_TYPE_FAILURE_WORKSHOP_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 3,
				Code = ConstantsApp.OPERATION_TYPE_CLOTHES_CODE,
				Description = ConstantsApp.OPERATION_TYPE_CLOTHES_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 4,
				Code = ConstantsApp.OPERATION_TYPE_TOOLS_CODE,
				Description = ConstantsApp.OPERATION_TYPE_TOOLS_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 5,
				Code = ConstantsApp.OPERATION_TYPE_OTHER_CODE,
				Description = ConstantsApp.OPERATION_TYPE_OTHER_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 6,
				Code = ConstantsApp.OPERATION_TYPE_MAINTENANCE_HOME_CODE,
				Description = ConstantsApp.OPERATION_TYPE_MAINTENANCE_HOME_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 7,
				Code = ConstantsApp.OPERATION_TYPE_FAILURE_HOME_CODE,
				Description = ConstantsApp.OPERATION_TYPE_FAILURE_HOME_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<OperationType>().HasData(new OperationType
			{
				Id = 8,
				Code = ConstantsApp.OPERATION_TYPE_SPARE_PARTS_CODE,
				Description = ConstantsApp.OPERATION_TYPE_SPARE_PARTS_DESCRIPTION,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
