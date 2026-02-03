using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE.AppInfrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity;

namespace BASE.AppCore.Services.Security
{
    public class AppSigInManagerFactory : IAppSigInManagerFactory
    {
        private readonly SignInManager<User> _signInManager;

        public AppSigInManagerFactory(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> CheckPasswordSignInAsync(User user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result.Succeeded;

        }
    }
}
