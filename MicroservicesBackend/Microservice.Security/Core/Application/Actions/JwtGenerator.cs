using Microservice.Security.Core.Application.Dto.Settings;
using Microservice.Security.Core.Persistence.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservice.Security.Core.Application.Actions
{
    public class JwtGenerator : IJwtGenerator
	{
		private readonly JwtSettings _jwtConfig;

		public JwtGenerator(JwtSettings jwtConfig)
		{
			_jwtConfig = jwtConfig;
		}

		public string CreateToken(User user, List<Role> roles)
		{
			var claims = new List<Claim>
			{
				new Claim(nameof(user.UserName), user.UserName),
				new Claim(nameof(user.FirstName), user.FirstName),
				new Claim(nameof(user.LastName), user.LastName)
			};

			roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x.Name)));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
			var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescription = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Audience = _jwtConfig.Audience,
				Issuer = _jwtConfig.Issuer,
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = credential
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescription);
			return tokenHandler.WriteToken(token);
		}
	}
}
