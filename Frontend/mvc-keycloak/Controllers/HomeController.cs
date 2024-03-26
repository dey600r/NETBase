using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc_keycloak.Models;
using System.Diagnostics;

namespace mvc_keycloak.Controllers
{
	public class DataModel
	{
		public string name { get; set; }
		public string description { get; set; }
	}

	
	//[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

        [CustomeAuthorization("adios")]
        public async Task<IActionResult> Index()
		{
            var authResult = await HttpContext.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme);
            if (!User.Identity.IsAuthenticated)          // <-- always false
            {
                //HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
                //{
                //    RedirectUri = Url.Action("Index", "Home")
                //}, "keycloak_auth");
                //return new HttpUnauthorizedResult();
            }
            List<DataModel> dataModels = new List<DataModel>()
			{
				new DataModel() { name = "David", description = "hola" },
				new DataModel() { name = "Ana", description = "buenos dias" }
			};

            HttpContext.Session.SetString("TokenDavid", dataModels.ToString());
            var token = HttpContext.Session.GetString("keycloak.cookie");


            return View(dataModels);
		}

        [CustomeAuthorization("adios")]
        public IActionResult Privacy()
        {
            return View();
		}

        [CustomeAuthorization("adios")]
        public IActionResult Logout()
        {
            return new SignOutResult(
            new[] {
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            });

            //SignOut("Cookies", "oidc");
            //HttpContext.SignOutAsync("Identity.Application");

            //return Redirect("/signout-callback-oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
