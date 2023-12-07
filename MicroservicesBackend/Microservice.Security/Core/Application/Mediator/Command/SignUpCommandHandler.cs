using AutoMapper;
using FluentValidation;
using MediatR;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Dto;
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
			private readonly IMapper _mapper;
			private readonly IJwtGenerator _jwtGenerator;

			public UserSignUpHandler(SecurityContext context, UserManager<User> userManager, RoleManager<Role> roleManager,
				IMapper mapper, IJwtGenerator jwtGenerator)
			{
				_context = context;
				_userManager = userManager;
				_roleManager = roleManager;
				_mapper = mapper;
				_jwtGenerator = jwtGenerator;
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
						_userManager.AddToRoleAsync(userDB, role.Name);

						var roles = (from u in _context.Users
									 let r = (from ur in _context.UserRoles
											  join ro in _context.Roles on ur.RoleId equals ro.Id
											  where ur.UserId == u.Id
											  select ro).ToList()
									 where u.Email == request.Email || u.UserName == request.UserName
									 select r).FirstOrDefault(); ;
						var userDto = _mapper.Map<User, UserDto>(user);
						userDto.Token = _jwtGenerator.CreateToken(user, roles);
						userDto.Roles = roles.Select(x => x.Name).ToList();

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
