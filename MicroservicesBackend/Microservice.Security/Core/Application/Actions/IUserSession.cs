using Microservice.Security.Core.Application.Mapping.Dto;
using Microservice.Security.Core.Persistence.Entities;

namespace Microservice.Security.Core.Application.Actions
{
	public interface IUserSession
	{
		public string GetUserSession();
		public UserDto GetUser(User user);
	}
}
