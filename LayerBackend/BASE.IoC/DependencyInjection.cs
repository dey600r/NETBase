﻿
using BASE.AppCore.Mappers;
using BASE.AppCore.Services;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.AppInfrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BASE.IoC
{
	public static class DependencyInjection
	{

		public static void ConfigureDBContext(IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContext<DBContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("SqlServer")),
				ServiceLifetime.Scoped
			);
		}

		public static void ConfigureDBMigration(IServiceProvider service)
		{
			using (var scope = service.CreateScope())
			{
				var dataContext = scope.ServiceProvider.GetRequiredService<DBContext>();
				dataContext.Database.Migrate();
			}
		}

		public static void AddMyDependencyGroup(
			 this IServiceCollection services)
		{
			// AUTOMAPPER
			services.AddAutoMapper(typeof(BusinessProfile));

			// SERVICES
			//services.AddScoped(typeof(IBaseRepository<VehicleType, int>), typeof(BaseRepository<VehicleType, int>));
			//services.AddScoped(typeof(IBaseRepository<VehicleType, int>), typeof(VehicleRepository));
			//services.AddScoped<IBaseRepository<VehicleType, int>, VehicleRepository>();
			//services.AddScoped<IBaseRepository<VehicleType, int>, BaseRepository<VehicleType, int>>();
			services.AddScoped<IVehicleRepository, VehicleRepository>();
			services.AddScoped<IVehicleService, VehicleService>();


		}
	}
}