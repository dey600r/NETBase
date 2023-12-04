using BASE.AppCore.Mappers;
using BASE.AppCore.Services;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Constants;
using BASE.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using NLog;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using BASE.WebApiTest.DependencyInjection.Moq;
using BASE.WebApiTest.DependencyInjection.Fake;

namespace BASE.WebApiTest.DependencyInjection
{
	public class TestDependencyInjectionFakeFixture : TestBedFixture
	{
		public TestDependencyInjectionFakeFixture()
		{
			// Only called once before all tests
		}

		protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
		{
			// CONFIGURE AUTOMAPPER
			services.AddAutoMapper(typeof(BusinessProfile));

			// CONFIGURE SERVICES
			services.AddScoped<IVehicleFakeService, VehicleFakeService>();
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
			// Only called once after all tests
		}
	}
}