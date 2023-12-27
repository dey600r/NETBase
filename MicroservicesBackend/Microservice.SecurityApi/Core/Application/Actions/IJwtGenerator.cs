using Microservice.Security.Core.Persistence.Entities;

namespace Microservice.Security.Core.Application.Actions
{
	public interface IJwtGenerator
	{
		public string CreateToken(User user, List<Role> roles);
	}
}
