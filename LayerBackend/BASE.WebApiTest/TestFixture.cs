using Autofac.Core;
using BASE.AppCore.Mappers;
using BASE.AppCore.Services;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NLog.Fluent;
using System.Reflection.Metadata;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Xunit.Sdk;

namespace BASE.WebApiTest
{
	public class TestFixture : TestBedFixture, IDisposable
	{
		public TestFixture()
		{
		}

		protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
		{

			services.AddDbContext<DBContext>(options =>
				options.UseInMemoryDatabase(databaseName: Constants.MOQ_DATABASE)
				.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)),
				ServiceLifetime.Scoped
			);

			services.AddAutoMapper(typeof(BusinessProfile));

			services.AddScoped<IVehicleRepository, VehicleRepository>();
			services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
			services.AddScoped<IVehicleService, VehicleService>();
			services.AddScoped<IVehicleTypeService, VehicleTypeService>();
		}

		protected override ValueTask DisposeAsyncCore()
			=> new();

		protected override IEnumerable<string> GetConfigurationFiles()
		{
			yield return "appsettings.json";
			//yield return new() { Filename = "appsettings.json", IsOptional = false };
		}

		protected override IEnumerable<TestAppSettings> GetTestAppSettings()
		{
			yield return new() { Filename = "appsettings.json", IsOptional = false };
		}


		public void Dispose()
		{
			// Do "global" teardown here; Only called once.
		}
	}
}