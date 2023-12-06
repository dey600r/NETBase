using BASE.AppInfrastructure.Entities.Security;
using BASE.Common.Constants;
using BASE.Common.Dtos.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BASE.AppCore.Services.Security
{
	public class JwtGenerator : IJwtGenerator
	{
		private readonly JwtSettings _jwtConfig;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public JwtGenerator(JwtSettings jwtConfig, IHttpContextAccessor httpContextAccessor) 
		{
			_jwtConfig = jwtConfig;
			_httpContextAccessor = httpContextAccessor;
		}

		public string GetUserSesion()
		{
			var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == nameof(User.UserName));
			return (userName == null ? ConstantsSecurity.USER_UNKNOWN_AUDIT : userName.Value);
		}

		public string CreateToken(User newUser, Role role)
		{
			var claims = new List<Claim>
			{
				new Claim(nameof(newUser.UserName), newUser.UserName),
				new Claim(nameof(newUser.FirstName), newUser.FirstName),
				new Claim(nameof(newUser.LastName), newUser.LastName),
				new Claim(nameof(newUser.Country), newUser.Country),
				new Claim(ClaimTypes.Role, role.Name)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
			var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescription = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Audience = _jwtConfig.Audience,
				Issuer = _jwtConfig.Issuer,
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = credential,
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescription);
			return tokenHandler.WriteToken(token);
		}
	}
}
