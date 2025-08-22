using Microsoft.AspNetCore.Identity;

namespace Microservice.Security.Core.Persistence.Entities
{
	public class User : IdentityUser<Guid>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
	}
}
