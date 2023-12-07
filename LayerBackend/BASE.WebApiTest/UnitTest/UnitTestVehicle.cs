using BASE.AppCore.Services;
using BASE.AppCore.Services.Security;
using BASE.AppInfrastructure.Entities.Core;
using BASE.AppInfrastructure.Entities.Security;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Constants;
using BASE.Common.Dtos;
using BASE.WebApi.Controllers;
using BASE.WebApiTest.DependencyInjection;
using BASE.WebApiTest.DependencyInjection.Fake;
using BASE.WebApiTest.DependencyInjection.Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace BASE.WebApiTest.UnitTest
{
    public class UnitTestVehicle : TestBed<TestDependencyInjectionFixture>
    {
        public UnitTestVehicle(ITestOutputHelper testOutputHelper, TestDependencyInjectionFixture fixture) : base(testOutputHelper, fixture)
        {
            //var dbContext = _fixture.GetService<DBContext>(_testOutputHelper);
        }

        [Fact]
        public void TestVehicleTypeServiceGet()
        {
            var vehicleTypeService = _fixture.GetService<IVehicleTypeService>(_testOutputHelper);

            var result = vehicleTypeService?.GetAll().ToList();

            Assert.True(result?.Count == 3);
        }

        [Theory]
        [InlineData("Yamaha")]
        public void TestVehicleServiceGet(string brand)
        {
            var vehicleService = _fixture.GetService<IVehicleService>(_testOutputHelper);

            var result = vehicleService?.GetAll().ToList();

            Assert.Contains(result, x => x.Brand == brand);
        }

        [Fact]
        public void TestVehicleControllerGet()
        {
            var vehicleService = _fixture.GetService<IVehicleService>(_testOutputHelper);
			var httpContext = _fixture.GetService<IHttpContextAccessor>(_testOutputHelper);
			var logger = new Mock<ILogger<BaseController>>();

            var vehicleController = new VehicleController(vehicleService, logger.Object, httpContext);

            var result = vehicleController?.Get().Result as OkObjectResult;

            Assert.True((result?.Value as IEnumerable<VehicleModel>)?.Any());
        }

		[Fact]
		public void TestVehicleControllerAdd()
		{
			var vehicleRepository = _fixture.GetService<IVehicleRepository>(_testOutputHelper);
			var vehicleService = _fixture.GetService<IVehicleService>(_testOutputHelper);
			var httpContext = _fixture.GetService<IHttpContextAccessor>(_testOutputHelper);
			var logger = new Mock<ILogger<BaseController>>();

			var vehicleController = new VehicleController(vehicleService, logger.Object, httpContext);

			var result = vehicleController?.Add(new VehicleModel
			{
				Brand = "Honda",
				Model = "CBR",
				Km = 50000,
				Year = 2008,
				DateKms = DateTime.UtcNow,
				KmsPerMonth = 100,
				Active = true,
				VehicleTypeId = 1,
				ConfigurationId = 1,
			}).Result as OkObjectResult;

			var newVehicle = (result?.Value as VehicleModel);
			var checkNewVehicle = vehicleRepository.GetById(newVehicle.Id);

			Assert.True(checkNewVehicle.CreatedUser == ConstantsSecurity.ADMIN_ROLE_NAME);
			Assert.True(checkNewVehicle.Brand == "Honda");
		}
	}
}