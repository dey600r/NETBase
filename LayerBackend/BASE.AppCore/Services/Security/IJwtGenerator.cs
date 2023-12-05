using BASE.AppInfrastructure.Entities.Security;

namespace BASE.AppCore.Services.Security
{
	public interface IJwtGenerator
	{
		public string CreateToken(User newUser);
		public string GetUserSesion();
	}
}
