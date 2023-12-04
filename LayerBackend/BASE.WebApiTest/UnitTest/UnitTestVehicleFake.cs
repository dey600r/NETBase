using BASE.AppCore.Services;
using BASE.Common.Dtos;
using BASE.WebApi.Controllers;
using BASE.WebApiTest.DependencyInjection;
using BASE.WebApiTest.DependencyInjection.Fake;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace BASE.WebApiTest.UnitTest
{
	public class UnitTestVehicleFake : TestBed<TestDependencyInjectionFakeFixture>
	{
		public UnitTestVehicleFake(ITestOutputHelper testOutputHelper, TestDependencyInjectionFakeFixture fixture) : base(testOutputHelper, fixture)
		{
		}

		[Theory]
		[InlineData("Honda")]
		public void TestVehicleFakeServiceGet(string brand)
		{
			var vehicleService = _fixture.GetService<IVehicleFakeService>(_testOutputHelper);

			var result = vehicleService?.GetAll().ToList();

			Assert.Contains(result, x => x.Brand == brand);
		}

		[Fact]
		public void TestVehicleFakeControllerGet()
		{
			var vehicleService = _fixture.GetService<IVehicleFakeService>(_testOutputHelper);
			var logger = new Mock<ILogger<BaseController>>();

			var vehicleController = new VehicleController(vehicleService, logger.Object);

			var result = vehicleController?.Get().Result as OkObjectResult;

			Assert.True((result?.Value as IEnumerable<VehicleModel>)?.Any());
		}
	}
}
