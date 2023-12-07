using Microsoft.AspNetCore.Identity;

namespace Microservice.Security.Core.Persistence.Entities
{
	public class Role : IdentityRole<Guid>
	{
		public string Country { get; set; }
	}
}
