using BASE.AppInfrastructure.Entities.Security;

namespace BASE.AppInfrastructure.Repository.Security
{
	public interface ISecurityRepository
	{
		public Role GetUserRole(string userNameOrEmail);
	}
}
