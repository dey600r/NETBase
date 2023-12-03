using BASE.AppCore.Services;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace BASE.WebApiTest
{
    public class UnitTest1 : TestBed<TestFixture>
	{
		public UnitTest1(ITestOutputHelper testOutputHelper, TestFixture fixture) : base(testOutputHelper, fixture)
		{
			var dbContext = _fixture.GetService<DBContext>(_testOutputHelper);

			//dbContext.Database.EnsureDeleted();
			//dbContext.Database.EnsureCreated();
			dbContext.AddRange(
				new VehicleType { Code = "Test1", Description = "Test1", CreatedUser = "Test", CreatedDate = DateTime.UtcNow }
			);
			dbContext.SaveChanges();
		}

		[Fact]
		public void Test1()
		{
			var vehicleTypeService = _fixture.GetService<IVehicleTypeService>(_testOutputHelper);

			var result = vehicleTypeService.GetAll().ToList();

			Assert.True(result.Any());
		}

		[Fact]
		public void Test2()
		{
			var vehicleTypeService = _fixture.GetService<IVehicleTypeService>(_testOutputHelper);

			var result = vehicleTypeService.GetAll().ToList();

			Assert.True(result.Any());
		}
	}
}