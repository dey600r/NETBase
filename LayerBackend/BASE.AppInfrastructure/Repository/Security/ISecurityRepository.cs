using BASE.AppInfrastructure.Entities.Security;

namespace BASE.AppInfrastructure.Repository.Security
{
	public interface ISecurityRepository
	{
		public List<Role> GetUserRole(string userNameOrEmail);
	}
}
