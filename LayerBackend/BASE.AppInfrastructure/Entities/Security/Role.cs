using Microsoft.AspNetCore.Identity;

namespace BASE.AppInfrastructure.Entities.Security
{
	public class Role: IdentityRole<int>
	{
		public string Description { get; set; }
	}
}
