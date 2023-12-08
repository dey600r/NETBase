using AutoMapper;
using FluentValidation;
using MediatR;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Dto;
using Microservice.Security.Core.Persistence;
using Microservice.Security.Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using static Microservice.Security.Core.Application.Mediator.Query.LoginQueryHandler;

namespace Microservice.Security.Core.Application.Mediator.Query
{
	public class LoginQueryHandler
	{
		public class UserLogin : IRequest<UserDto>
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}

		public class UserLoginValidation : AbstractValidator<UserLogin>
		{
			public UserLoginValidation()
			{
				RuleFor(x => x.Email).NotEmpty();
				RuleFor(x => x.Password).NotEmpty();
			}
		}

		public class UsuarioLoginHandler : IRequestHandler<UserLogin, UserDto>
		{
			private readonly SecurityContext _context;
			private readonly UserManager<User> _userManager;
			private readonly IMapper _mapper;
			private readonly IJwtGenerator _jwtGenerator;
			private readonly SignInManager<User> _signInManager;

			public UsuarioLoginHandler(SecurityContext context, UserManager<User> userManager, IMapper mapper, 
				IJwtGenerator jwtGenerator, SignInManager<User> signInManager)
			{
				_context = context;
				_userManager = userManager;
				_mapper = mapper;
				_jwtGenerator = jwtGenerator;
				_signInManager = signInManager;
			}

			public async Task<UserDto> Handle(UserLogin request, CancellationToken cancellationToken)
			{

				var user = await _userManager.FindByEmailAsync(request.Email);
				if (user == null)
					user = await _userManager.FindByNameAsync(request.Email);
				if (user == null)
					throw new Exception("The email doesn't exist");

				var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
				if (result.Succeeded)
				{
					var roles = (from u in _context.Users
								 let r = (from ur in _context.UserRoles
										  join ro in _context.Roles on ur.RoleId equals ro.Id
										  where ur.UserId == u.Id
										  select ro).ToList()
								 where u.Email == user.Email || u.UserName == user.UserName
								 select r).FirstOrDefault();
					var userDTO = _mapper.Map<User, UserDto>(user);
					userDTO.Token = _jwtGenerator.CreateToken(user, roles);
					userDTO.Roles = roles.Select(x => x.Name).ToList();
					return userDTO;
				}

				throw new Exception("Login failed !!");
			}

		}
	}
}
