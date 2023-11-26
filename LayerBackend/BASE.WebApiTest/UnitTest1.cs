using BASE.AppCore.Services.Vehicle;
using BASE.WebApi.Controllers;

namespace BASE.WebApiTest
{
    public class UnitTest1
	{
		[Fact]
		public void Test1()
		{

			Assert.True(true);
		}
	}

	public interface IVehicleServiceMock : IVehicleService { 
	}
}