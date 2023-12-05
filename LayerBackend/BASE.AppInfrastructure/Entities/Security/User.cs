using Microsoft.AspNetCore.Identity;

namespace BASE.AppInfrastructure.Entities.Security
{
	public class User : IdentityUser<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
	}
}
