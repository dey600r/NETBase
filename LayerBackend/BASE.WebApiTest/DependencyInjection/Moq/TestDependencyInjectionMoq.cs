using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Constants;
using BASE.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BASE.WebApiTest.DependencyInjection.Moq
{
    public static class TestDependencyInjectionMoq
    {
        public static void InitializeMockData(DBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            context.AddRange(
                new Vehicle
                {
                    Brand = "Yamaha",
                    Model = "R6",
                    Km = 100000,
                    Year = 2006,
                    DateKms = DateTime.UtcNow,
                    KmsPerMonth = 600,
                    Active = true,
                    IdVehicleType = 1,
                    IdConfiguration = 1,
                    CreatedUser = Constants.MOQ_USER_DATABASE,
                    CreatedDate = DateTime.UtcNow
                }
            );
            context.SaveChanges();
        }

        public static List<VehicleModel> InitializeFakeData()
        {
			return new List<VehicleModel>() {
				new VehicleModel() {
					Brand = "Honda"
				},
				new VehicleModel() {
					Brand = "Kawasaki"
				}
			};
		}
    }
}
