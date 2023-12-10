using AutoMapper;
using FluentValidation;
using MediatR;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Mapping.Dto;
using Microservice.Security.Core.Persistence;
using Microservice.Security.Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace Microservice.Security.Core.Application.Mediator.Query
{
    public class CurrentUserQueryHandler
	{
		public class CurrentUser : IRequest<UserDto> { }
		public class CurrentUserValidation : AbstractValidator<CurrentUser> {}

		public class CurrentUserHandler : IRequestHandler<CurrentUser, UserDto>
		{
			private readonly UserManager<User> _userManager;
			private readonly IUserSession _userSession;

			public CurrentUserHandler(UserManager<User> userManager, IUserSession userSession)
			{
				_userManager = userManager;
				_userSession = userSession;
			}
			public async Task<UserDto> Handle(CurrentUser request, CancellationToken cancellationToken)
			{
				var user = await _userManager.FindByNameAsync(_userSession.GetUserSession());
				if (user != null)
					return _userSession.GetUser(user);

				throw new Exception("The user doesn't exist");
			}
		}
	}
}
