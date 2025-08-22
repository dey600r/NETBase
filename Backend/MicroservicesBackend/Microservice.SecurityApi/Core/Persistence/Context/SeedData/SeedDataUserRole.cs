using Microservice.IoC.Utils;
using Microservice.Security.Core.Application.Utils;
using Microservice.Security.Core.Application.Utils.Helpers;
using Microservice.Security.Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Security.Core.Persistence.Context.SeedData
{
	public class SeedDataUserRole
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			// ROLES
			Guid idRoleAdmin = Guid.Parse("e0d76eb5-457b-4d06-b695-aa1040ee86ef");
			Guid idRoleCustomer = Guid.Parse("b554730e-0e95-4668-99d5-99b585953498");
			modelBuilder.Entity<Role>().HasData(new Role
			{
				Id = idRoleAdmin,
				Name = Constants.ADMIN_ROLE_NAME,
				Country = Constants.ADMIN_ROLE_COUNTRY,
				NormalizedName = Constants.ADMIN_ROLE_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
			});

			modelBuilder.Entity<Role>().HasData(new Role
			{
				Id = idRoleCustomer,
				Name = Constants.CUSTOMER_ROLE_NAME,
				Country = Constants.ADMIN_ROLE_COUNTRY,
				NormalizedName = Constants.CUSTOMER_ROLE_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString()
			});

			// USERS
			Guid idUserAdmin = Guid.Parse("b1c94071-920e-4a0d-9ce2-af121b23ea6f");
			var user = new User
			{
				Id = idUserAdmin,
				FirstName = Constants.ADMIN_USER_NAME,
				LastName = Constants.ADMIN_USER_NAME,
				Email = Constants.ADMIN_USER_EMAIL,
				UserName = Constants.ADMIN_USER_NAME,
				Location = Constants.ADMIN_USER_NAME,
				NormalizedEmail = Constants.ADMIN_USER_EMAIL.ToUpper(),
				NormalizedUserName = Constants.ADMIN_USER_NAME.ToUpper(),
				ConcurrencyStamp = new DateTime(2023, 10, 1).TimeOfDay.ToString(),
				EmailConfirmed = true
			};
			var password = new PasswordHasher<User>();
			var hashed = password.HashPassword(user, CommonHelper.Decrypt(Constants.ADMIN_USER_PWD, SecurityConstants.ENCRIPT_KEY));
			user.PasswordHash = hashed;
			modelBuilder.Entity<User>().HasData(user);

			// RELATIONS USERS & ROLES
			modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>() { RoleId = idRoleAdmin, UserId = idUserAdmin });
			modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>() { RoleId = idRoleCustomer, UserId = idUserAdmin });

		}
	}
}
