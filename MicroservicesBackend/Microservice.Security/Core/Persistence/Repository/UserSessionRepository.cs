using Microservice.Security.Core.Persistence.Entities;

namespace Microservice.Security.Core.Persistence.Repository
{
	public class UserSessionRepository : IUserSessionRepository
	{
		private readonly SecurityContext _context;

		public UserSessionRepository(SecurityContext context)
		{
			_context = context;
		}

		public List<Role> GetUserRole(string userNameOrEmail)
		{
			return (from u in _context.Users
						 let r = (from ur in _context.UserRoles
								  join ro in _context.Roles on ur.RoleId equals ro.Id
								  where ur.UserId == u.Id
								  select ro).ToList()
						 where u.Email == userNameOrEmail || u.UserName == userNameOrEmail
						 select r).FirstOrDefault();
		}
	}
}
