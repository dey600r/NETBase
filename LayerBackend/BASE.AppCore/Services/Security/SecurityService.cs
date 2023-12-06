using AutoMapper;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Security;
using BASE.AppInfrastructure.Repository.Security;
using BASE.Common.Constants;
using BASE.Common.Dtos.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppCore.Services.Security
{
    public class SecurityService : ISecurityService
    {
		private readonly DBContext _dbContext;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly IMapper _mapper;
		private readonly IJwtGenerator _jwtGenerator;
		private readonly SignInManager<User> _signInManager;
		private readonly ISecurityRepository _securityRepository;

		public SecurityService(DBContext dBContext, UserManager<User> userManager, IMapper mapper, IJwtGenerator jwtGenerator, 
			SignInManager<User> signInManager, RoleManager<Role> roleManager, ISecurityRepository securityRepository) 
		{
			_dbContext = dBContext;
			_userManager = userManager;
			_roleManager = roleManager;
			_mapper = mapper;
			_jwtGenerator = jwtGenerator;
			_signInManager = signInManager;
			_securityRepository = securityRepository;
		}

		private UserModel GetUser(User user)
		{
			var roles = _securityRepository.GetUserRole(user.Email);
			var userDTO = _mapper.Map<User, UserModel>(user);
			userDTO.Token = _jwtGenerator.CreateToken(user, roles);
			userDTO.Role = roles.Select(x => x.Name).ToList();
			return userDTO;
		}

		public async Task<UserModel> Login(UserLoginModel userLogin)
		{
			var user = await _userManager.FindByEmailAsync(userLogin.Email);
			if (user == null)
				user = await _userManager.FindByNameAsync(userLogin.Email);
			if (user == null)
				throw new Exception("The email doesn't exists");

			var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);
			if (result.Succeeded)
				return GetUser(user);

			throw new Exception("Login failed !!");
		}

		public async Task<UserModel> GetCurrentUser()
		{
			var user = await _userManager.FindByNameAsync(_jwtGenerator.GetUserSesion());
			if (user != null)
				return GetUser(user);

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

			using var dbContextTransaction = _dbContext.Database.BeginTransaction();
			try
			{
				var resultado = await _userManager.CreateAsync(user, newUser.Password);

				if (resultado.Succeeded)
				{
					var role = _roleManager.Roles.First(x => x.Name == ConstantsSecurity.CUSTOMER_ROLE_NAME);
					var userDB = _userManager.Users.First(x => x.UserName == newUser.Username);
					_userManager.AddToRoleAsync(userDB, role.Name);

					dbContextTransaction.Commit();

					return GetUser(user);
				}
			} catch(Exception ex)
			{
				dbContextTransaction.Rollback();
			} finally
			{
				dbContextTransaction.Dispose();
			}

			throw new Exception("Sign up failed!!");
		}



		public void Dispose()
		{
		}
	}
}
