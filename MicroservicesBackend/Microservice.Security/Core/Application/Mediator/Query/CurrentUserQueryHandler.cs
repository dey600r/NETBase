using AutoMapper;
using FluentValidation;
using MediatR;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Dto;
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
			private readonly IJwtGenerator _jwtGenerator;
			private readonly IMapper _mapper;
			private readonly SecurityContext _context;

			public CurrentUserHandler(UserManager<User> userManager, IUserSession userSession, IJwtGenerator jwtGenerator,
				IMapper mapper, SecurityContext context)
			{
				_userManager = userManager;
				_userSession = userSession;
				_jwtGenerator = jwtGenerator;
				_mapper = mapper;
				_context = context;
			}
			public async Task<UserDto> Handle(CurrentUser request, CancellationToken cancellationToken)
			{
				var user = await _userManager.FindByNameAsync(_userSession.GetUserSession());
				if (user != null)
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

				throw new Exception("The user doesn't exist");
			}
		}
	}
}
