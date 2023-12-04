
using BASE.AppCore.Mappers;
using BASE.AppCore.Services;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Constants;
using BASE.Common.Dtos.Utils;
using BASE.Common.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace BASE.IoC
{
    public static class DependencyInjection
	{

		public static void ConfigureDBContext(IServiceCollection service, IConfiguration configuration)
		{
			var secrets = Boolean.Parse(configuration.GetConnectionString("Secrets"));

			string connectionString = string.Empty;
			if (secrets)
				connectionString = configuration["ConnectionString:SqlServer"];
			else
				connectionString = configuration.GetConnectionString("SqlServer");

			if (Boolean.Parse(configuration.GetConnectionString("Encripted")))
				connectionString = CommonHelper.Decrypt(connectionString, Constants.ENCRIPT_KEY);
			
			service.AddDbContext<DBContext>(options =>
				options.UseSqlServer(connectionString),
				ServiceLifetime.Scoped
			);
		}

		public static void ConfigureDBMigration(IServiceProvider service, Logger logger)
		{
			try
			{
				using (var scope = service.CreateScope())
				{
					var dataContext = scope.ServiceProvider.GetRequiredService<DBContext>();
					dataContext.Database.Migrate();
				}
			} catch(Exception ex)
			{
				logger.Error($"ERROR MIGRATING DB: {ex.Message}");
			}
		}

		public static void AddMyDependencyGroup(
			 this IServiceCollection services, IConfiguration configuration)
		{
			var config = configuration.GetSection("ConfigEnvironment").Get<ConfigSettings>();
			// AUTOMAPPER
			services.AddAutoMapper(typeof(BusinessProfile));

			// SERVICES
			services.AddScoped<IVehicleRepository, VehicleRepository>();
			services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
			services.AddScoped<IVehicleTypeService, VehicleTypeService>();

			// CONFIG SERVICES DEPENDING ON THE COUNTRY
			if(config.Country == Constants.CONFIG_SCENARY_COUNTRY_SPAIN)
				services.AddScoped<IVehicleService, VehicleSpainService>();
			else
				services.AddScoped<IVehicleService, VehicleService>();

		}
	}
}
