using BASE.Common.Dtos.Security;

namespace BASE.AppCore.Services.Security
{
	public interface ISecurityService : IDisposable
	{
		public Task<UserModel> SignupUser(UserSignupModel newUser);
		public Task<UserModel> GetCurrentUser();
		public Task<UserModel> Login(UserLoginModel userLogin);
	}
}
