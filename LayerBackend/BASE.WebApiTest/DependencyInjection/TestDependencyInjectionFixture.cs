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

namespace BASE.WebApiTest.DependencyInjection
{
    public class TestDependencyInjectionFixture : TestBedFixture
    {
        public TestDependencyInjectionFixture()
        {
			// Only called once before all tests
		}

        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            // CONFIGURE DATABASE MOCKED
            services.AddDbContext<DBContext>(options =>
                options.UseInMemoryDatabase(databaseName: Constants.MOQ_DATABASE)
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)),
                ServiceLifetime.Scoped
            );

            // CONFIGURE DATA MOCK
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            TestDependencyInjectionMoq.InitializeMockData(serviceProvider.GetRequiredService<DBContext>());
            serviceProvider.SetupNLogServiceLocator();
     

            // CONFIGURE LOGS
            services.AddLogging(builder => builder.AddConsole()).BuildServiceProvider();
            //services.AddScoped(typeof(ILogger<BaseController>));
			//Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
   //         services.<ILogger<BaseController>>();

			// CONFIGURE AUTOMAPPER
			services.AddAutoMapper(typeof(BusinessProfile));

            // CONFIGURE SERVICES
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
            // Only called once after all tests
        }
    }
}