using Microservice.Security.Core.Persistence.Entities;

namespace Microservice.Security.Core.Persistence.Repository
{
	public interface IUserSessionRepository
	{
		public List<Role> GetUserRole(string userNameOrEmail);
	}
}
