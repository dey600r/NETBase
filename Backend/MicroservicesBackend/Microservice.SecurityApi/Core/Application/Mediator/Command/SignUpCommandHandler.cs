using AutoMapper;
using FluentValidation;
using MediatR;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Mapping.Dto;
using Microservice.Security.Core.Application.Utils;
using Microservice.Security.Core.Persistence;
using Microservice.Security.Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Microservice.Security.Core.Application.Mediator.Command
{
    public class SignUpCommandHandler
	{
		public class UserSignUp : IRequest<UserDto> 
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string UserName { get; set; }
			public string Location { get; set; }
			public string Email { get; set; }	
			public string Password { get; set; }
		}

		public class UserSignUpValidation: AbstractValidator<UserSignUp>
		{
			public UserSignUpValidation()
			{
				RuleFor(x => x.FirstName).NotEmpty();
				RuleFor(x => x.LastName).NotEmpty();
				RuleFor(x => x.UserName).NotEmpty();
				RuleFor(x => x.Email).NotEmpty();
				RuleFor(x => x.Password).NotEmpty();
				RuleFor(x => x.Location).Empty();
			}
		}

		public class UserSignUpHandler : IRequestHandler<UserSignUp, UserDto>
		{
			private readonly SecurityContext _context;
			private readonly UserManager<User> _userManager;
			private readonly RoleManager<Role> _roleManager;
			private readonly IUserSession _userSession;

			public UserSignUpHandler(SecurityContext context, UserManager<User> userManager, RoleManager<Role> roleManager,
				IUserSession userSession)
			{
				_context = context;
				_userManager = userManager;
				_roleManager = roleManager;
				_userSession = userSession;
			}

			public async Task<UserDto> Handle(UserSignUp request, CancellationToken cancellationToken)
			{
				if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
					throw new Exception("The email has already exists on the system");

				if (await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
					throw new Exception("The username has already exists on the system");

				var user = new User
				{
					FirstName = request.FirstName,
					LastName = request.LastName,
					Email = request.Email,
					UserName = request.UserName,
					Location = request.Location
				};

				using var dbContextTransaction = _context.Database.BeginTransaction();
				try
				{
					var resultado = await _userManager.CreateAsync(user, request.Password);

					if (resultado.Succeeded)
					{
						var role = _roleManager.Roles.First(x => x.Name == Constants.CUSTOMER_ROLE_NAME);
						var userDB = _userManager.Users.First(x => x.UserName == request.UserName);
						await _userManager.AddToRoleAsync(userDB, role.Name);

						var userDto = _userSession.GetUser(user);

						dbContextTransaction.Commit();

						return userDto;
					}
				}
				catch (Exception ex)
				{
					dbContextTransaction.Rollback();
				}
				finally
				{
					dbContextTransaction.Dispose();
				}

				throw new Exception("Sign up failed!!");
			}
		}
	}
}
