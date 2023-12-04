using BASE.AppCore.Services;
using BASE.Common.Dtos;
using BASE.WebApi.Controllers;
using BASE.WebApiTest.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
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
            var logger = new Mock<ILogger<BaseController>>();

            var vehicleController = new VehicleController(vehicleService, logger.Object);

            var result = vehicleController?.Get().Result as OkObjectResult;

            Assert.True((result?.Value as IEnumerable<VehicleModel>)?.Any());
        }
    }
}