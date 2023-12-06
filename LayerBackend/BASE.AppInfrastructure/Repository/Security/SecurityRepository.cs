using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Security;

namespace BASE.AppInfrastructure.Repository.Security
{
	public class SecurityRepository : ISecurityRepository
	{
		private readonly DBContext _dbContext;
		
		public SecurityRepository(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Role> GetUserRole(string userNameOrEmail)
		{
			return (from u in _dbContext.Users
					let r = (from ur in _dbContext.UserRoles
							 join ro in _dbContext.Roles on ur.RoleId equals ro.Id
							 where ur.UserId == u.Id
							 select ro).ToList()
					where u.Email == userNameOrEmail || u.UserName == userNameOrEmail
					select r).FirstOrDefault();
		}

	}
}
