using AutoMapper;
using Microservice.Security.Core.Application.Mapping.Dto;
using Microservice.Security.Core.Application.Utils;
using Microservice.Security.Core.Persistence.Entities;
using Microservice.Security.Core.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Security.Core.Application.Actions
{
	public class UserSession : IUserSession
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;
		private readonly IJwtGenerator _jwtGenerator;
		private readonly IUserSessionRepository _userSessionRepository;

		public UserSession(IHttpContextAccessor httpContextAccessor, IMapper mapper, IJwtGenerator jwtGenerator, 
			IUserSessionRepository userSessionRepository)
		{
			_httpContextAccessor = httpContextAccessor;
			_mapper = mapper;
			_jwtGenerator = jwtGenerator;
			_userSessionRepository = userSessionRepository;
		}

		public string GetUserSession()
		{
			var user = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == nameof(User.UserName));
			return (user == null ? Constants.USER_UNKNOWN_AUDIT : user.Value);
		}

		public UserDto GetUser(User user)
		{
			var roles = _userSessionRepository.GetUserRole(user.Email);
			var userDTO = _mapper.Map<User, UserDto>(user);
			userDTO.Token = _jwtGenerator.CreateToken(user, roles);
			userDTO.Roles = roles.Select(x => x.Name).ToList();
			return userDTO;
		}
	}
}
