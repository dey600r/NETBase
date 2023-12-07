using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Core;
using BASE.AppInfrastructure.Entities.Security;
using BASE.Common.Constants;
using BASE.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
                    VehicleTypeId = 1,
					ConfigurationId = 1,
                    CreatedUser = ConstantsSecurity.MOQ_USER_DATABASE,
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

        public static User InitializeMockUser()
        {
			return new User
			{
				Id = 1,
				FirstName = ConstantsSecurity.ADMIN_USER_NAME,
				LastName = ConstantsSecurity.ADMIN_USER_NAME,
				Email = ConstantsSecurity.ADMIN_USER_EMAIL,
				UserName = ConstantsSecurity.ADMIN_USER_NAME,
				Country = ConstantsSecurity.CONFIG_SCENARY_COUNTRY_ADMIN,
				NormalizedEmail = ConstantsSecurity.ADMIN_USER_EMAIL.ToUpper(),
				NormalizedUserName = ConstantsSecurity.ADMIN_USER_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString(),
				EmailConfirmed = true
			};
		}

        public static List<Role> InitializeMockRole()
        {
			return new List<Role>() {
				new Role {
					Id = 1,
					Name = ConstantsSecurity.ADMIN_ROLE_NAME,
					Description = ConstantsSecurity.ADMIN_ROLE_NAME,
					NormalizedName = ConstantsSecurity.ADMIN_ROLE_NAME.ToUpper(),
					ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
				},
				new Role {
					Id = 2,
					Name = ConstantsSecurity.MANAGER_ROLE_NAME,
					Description = ConstantsSecurity.MANAGER_ROLE_NAME,
					NormalizedName = ConstantsSecurity.MANAGER_ROLE_NAME.ToUpper(),
					ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
				},
				new Role {
					Id = 3,
					Name = ConstantsSecurity.CUSTOMER_ROLE_NAME,
					Description = ConstantsSecurity.CUSTOMER_ROLE_NAME,
					NormalizedName = ConstantsSecurity.CUSTOMER_ROLE_NAME.ToUpper(),
					ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
				}
			};
		}
    }
}
