using Microservice.VehicleApi.Core.Mapping;
using Microservice.VehicleApi.Infraestructure.Context;
using Microservice.VehicleApi.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Ioc
{
	public static class DependencyInjection
	{
		/// <summary>
		/// Configure BD CONTEXT
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		public static IServiceCollection AddDBContextExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContext<DBContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("SqlServer")),
				ServiceLifetime.Scoped
			);
			return service;
		}

		/// <summary>
		/// INJECT SERVICES
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		public static IServiceCollection AddAppDependenciesExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			// AUTOMAPPER
			service.AddAutoMapper(typeof(BusinessProfile));

			// REPOSITORIES
			service.AddScoped<IVehicleRepository, VehicleRepository>();
			service.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
			service.AddScoped<IConfigurationRepository, ConfigurationRepository>();

			return service;
		}

		/// <summary>
		/// CONFIGURE MIGRATION DB
		/// </summary>
		/// <param name="service"></param>
		/// <param name="logger"></param>
		public static void ConfigureDBMigration(this IServiceProvider service)
		{
			try
			{
				using (var scope = service.CreateScope())
				{
					var dataContext = scope.ServiceProvider.GetRequiredService<DBContext>();
					dataContext.Database.Migrate();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR MIGRATING DB: {ex.Message}");
			}
		}
	}
}
