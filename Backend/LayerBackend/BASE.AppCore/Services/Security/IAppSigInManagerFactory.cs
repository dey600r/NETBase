using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE.AppInfrastructure.Entities.Security;

namespace BASE.AppCore.Services.Security
{
    public interface IAppSigInManagerFactory
    {
        Task<bool> CheckPasswordSignInAsync(User user, string password);
    }
}
