using Microsoft.AspNetCore.Identity;
using BASE.AppInfrastructure.Entities.Security;
using BASE.Common.Helper;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public class SeedDataRole
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			// ROLES
			modelBuilder.Entity<Role>().HasData(new Role
			{
				Id = 1,
				Name = ConstantsSecurity.ADMIN_ROLE_NAME,
				Description = ConstantsSecurity.ADMIN_ROLE_NAME,
				NormalizedName = ConstantsSecurity.ADMIN_ROLE_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
			});

			modelBuilder.Entity<Role>().HasData(new Role
			{
				Id = 2,
				Name = ConstantsSecurity.MANAGER_ROLE_NAME,
				Description = ConstantsSecurity.MANAGER_ROLE_NAME,
				NormalizedName = ConstantsSecurity.MANAGER_ROLE_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
			});

			modelBuilder.Entity<Role>().HasData(new Role
			{
				Id = 3,
				Name = ConstantsSecurity.CUSTOMER_ROLE_NAME,
				Description = ConstantsSecurity.CUSTOMER_ROLE_NAME,
				NormalizedName = ConstantsSecurity.CUSTOMER_ROLE_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
			});

			// USERS
			var user = new User
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
			var password = new PasswordHasher<User>();
			var hashed = password.HashPassword(user, CommonHelper.Decrypt(ConstantsSecurity.ADMIN_USER_PWD, ConstantsSecurity.ENCRIPT_KEY));
			user.PasswordHash = hashed;
			modelBuilder.Entity<User>().HasData(user);

			var manager = new User
			{
				Id = 2,
				FirstName = ConstantsSecurity.MANAGER_USER_NAME,
				LastName = ConstantsSecurity.MANAGER_USER_NAME,
				Email = ConstantsSecurity.MANAGER_USER_EMAIL,
				UserName = ConstantsSecurity.MANAGER_USER_NAME,
				Country = ConstantsSecurity.CONFIG_SCENARY_COUNTRY_ADMIN,
				NormalizedEmail = ConstantsSecurity.MANAGER_USER_EMAIL.ToUpper(),
				NormalizedUserName = ConstantsSecurity.MANAGER_USER_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString(),
				EmailConfirmed = true
			};
			manager.PasswordHash = hashed;
			modelBuilder.Entity<User>().HasData(manager);

			// RELATIONS USERS & ROLES
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { RoleId = 1, UserId = 1 });
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { RoleId = 2, UserId = 1 });
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { RoleId = 3, UserId = 1 });
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { RoleId = 2, UserId = 2 });

		}
	}
}
