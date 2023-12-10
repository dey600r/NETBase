using AutoMapper;
using FluentValidation;
using MediatR;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Mapping.Dto;
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
			private readonly UserManager<User> _userManager;
			private readonly SignInManager<User> _signInManager;
			private readonly IUserSession _userSession;

			public UsuarioLoginHandler(UserManager<User> userManager, SignInManager<User> signInManager, IUserSession userSession)
			{
				_userManager = userManager;
				_signInManager = signInManager;
				_userSession = userSession;
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
					return _userSession.GetUser(user);

				throw new Exception("Login failed !!");
			}

		}
	}
}
