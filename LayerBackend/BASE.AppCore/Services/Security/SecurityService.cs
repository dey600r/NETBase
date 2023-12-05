using AutoMapper;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Security;
using BASE.Common.Dtos.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppCore.Services.Security
{
    public class SecurityService : ISecurityService
    {
		private readonly DBContext _dbContext;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IJwtGenerator _jwtGenerator;
		private readonly SignInManager<User> _signInManager;

		public SecurityService(DBContext dBContext, UserManager<User> userManager, IMapper mapper, IJwtGenerator jwtGenerator, 
			SignInManager<User> signInManager) 
		{
			_dbContext = dBContext;
			_userManager = userManager;
			_mapper = mapper;
			_jwtGenerator = jwtGenerator;
			_signInManager = signInManager;
		}

		public async Task<UserModel> Login(UserLoginModel userLogin)
		{
			var user = await _userManager.FindByEmailAsync(userLogin.Email);
			if (user == null)
				throw new Exception("The email doesn't exists");

			var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);
			if (result.Succeeded)
			{
				var usuarioDTO = _mapper.Map<User, UserModel>(user);
				usuarioDTO.Token = _jwtGenerator.CreateToken(user);
				return usuarioDTO;
			}

			throw new Exception("Login failed !!");
		}

		public async Task<UserModel> GetCurrentUser()
		{
			//var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == "username")?.Value;
			var user = await _userManager.FindByNameAsync(_jwtGenerator.GetUserSesion());
			if (user != null)
			{
				var usuarioDTO = _mapper.Map<User, UserModel>(user);
				usuarioDTO.Token = _jwtGenerator.CreateToken(user);
				return usuarioDTO;
			}

			throw new Exception("The user doesn't exists");
		}

		public async Task<UserModel> SignupUser(UserSignupModel newUser)
		{
			if (await _dbContext.Users.Where(x => x.Email == newUser.Email).AnyAsync())
				throw new Exception("The email has already exists on the system");

			if (await _dbContext.Users.Where(x => x.UserName == newUser.Username).AnyAsync())
				throw new Exception("The username has already exists on the system");

			var user = new User
			{
				FirstName = newUser.FirstName,
				LastName = newUser.LastName,
				Email = newUser.Email,
				UserName = newUser.Username,
				Country = newUser.Country
			};

			var resultado = await _userManager.CreateAsync(user, newUser.Password);

			if (resultado.Succeeded)
			{
				var usuarioDTO = _mapper.Map<User, UserModel>(user);
				usuarioDTO.Token = _jwtGenerator.CreateToken(user);
				return usuarioDTO;
			}
			else
				throw new Exception("Sign up failed!!");
		}



		public void Dispose()
		{
		}
	}
}
