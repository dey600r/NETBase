using BASE.AppInfrastructure.Entities.Security;
using BASE.WebApiTest.DependencyInjection.Moq;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using System.Security.Principal;

namespace BASE.WebApiTest.DependencyInjection.Fake
{
	internal class HttpContextFakeAccessor : IHttpContextFakeAccessor
	{
		public HttpContext? HttpContext { get {
				User admin = TestDependencyInjectionMoq.InitializeMockUser();
				var claims = new List<Claim>
				{
					new Claim(nameof(admin.UserName), admin.UserName),
					new Claim(nameof(admin.FirstName), admin.FirstName),
					new Claim(nameof(admin.LastName), admin.LastName),
					new Claim(nameof(admin.Country), admin.Country)
				};

				List<Role> roles = TestDependencyInjectionMoq.InitializeMockRole();
				roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x.Name)));

				var result = new Mock<HttpContext>();
				result.Setup(h => h.User).Returns(new ClaimsPrincipal(new ClaimsIdentity(claims)));
				return result.Object;
		} set { } }
	}
}
