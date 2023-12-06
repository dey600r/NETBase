using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
    public static class SeedDataConfiguration
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Configuration>().HasData(new Configuration
			{ 
				Id = 1, 
				Name = Constants.CONFIGURATION_NAME_PRODUCTION, 
				Description = Constants.CONFIGURATION_DESCRIPTION_PRODUCTION,
				Master = true,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
