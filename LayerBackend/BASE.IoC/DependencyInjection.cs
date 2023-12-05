
using Autofac.Core;
using BASE.AppCore.Mappers;
using BASE.AppCore.Services;
using BASE.AppCore.Services.Security;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Security;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Constants;
using BASE.Common.Dtos.Utils;
using BASE.Common.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using System.Text;

namespace BASE.IoC
{
    public static class DependencyInjection
	{
		/// <summary>
		/// CONFIGURE SWAGGER WITH AUTHORIZATION
		/// </summary>
		/// <param name="service"></param>
		public static void ConfigureSwagger(IServiceCollection service)
		{
			service.AddSwaggerGen(opt => {
				opt.SwaggerDoc("v1", new OpenApiInfo { Title = "BaseAPI", Version = "v1" });
				opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
					In = ParameterLocation.Header,
					Description = "Please enter token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "bearer"
				});

				opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] { }
						}
					});
				});
		}

		/// <summary>
		/// Configure BD CONTEXT
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		public static void ConfigureDBContext(IServiceCollection service, IConfiguration configuration)
		{
			// CONFIG CONNECTION STRING
			var secrets = Boolean.Parse(configuration.GetConnectionString("Secrets"));

			string connectionString = string.Empty;
			if (secrets)
				connectionString = configuration["ConnectionString:SqlServer"]; // SECRETS
			else
				connectionString = configuration.GetConnectionString("SqlServer"); // APPSETINGS

			if (Boolean.Parse(configuration.GetConnectionString("Encripted"))) // ENCRIPTED
				connectionString = CommonHelper.Decrypt(connectionString, Constants.ENCRIPT_KEY);

			// CONFIG CONTEXT
			service.AddDbContext<DBContext>(options =>
				options.UseSqlServer(connectionString),
				ServiceLifetime.Scoped
			);
		}

		/// <summary>
		/// CONFIGURE JWT 
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		public static void ConfigureJWT(IServiceCollection service, IConfiguration configuration) {

			var config = configuration.GetSection("Jwt").Get<JwtSettings>();
			service.AddSingleton(config);

			// SECURITY
			var builder = service.AddIdentityCore<User>();
			var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
			identityBuilder.AddEntityFrameworkStores<DBContext>();
			identityBuilder.AddSignInManager<SignInManager<User>>();
			builder.Services.TryAddSingleton<ISystemClock, SystemClock>(); // AÑADIR UN RELOJ PAR LA EXPIRACION DEL TOKEN

			// JWT
			service.AddHttpContextAccessor()
				.AddAuthorization()
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = config.Issuer,
						ValidAudience = config.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key))
					};
				});

			
		}

		/// <summary>
		/// INJECT SERVICES
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		public static void AddMyDependencyGroup(
			 this IServiceCollection service, IConfiguration configuration)
		{
			// Get Config Environment from appsetings
			var config = configuration.GetSection("ConfigEnvironment").Get<ConfigSettings>();
			service.AddSingleton(config);

			// AUTOMAPPER
			service.AddAutoMapper(typeof(BusinessProfile));

			// SERVICES
			service.AddScoped<IVehicleRepository, VehicleRepository>();
			service.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
			service.AddScoped<IVehicleTypeService, VehicleTypeService>();

			// CONFIG SERVICES DEPENDING ON THE COUNTRY
			if(config.Country == Constants.CONFIG_SCENARY_COUNTRY_SPAIN)
				service.AddScoped<IVehicleService, VehicleSpainService>();
			else
				service.AddScoped<IVehicleService, VehicleService>();

			// SECURITY
			service.AddScoped<ISecurityService, SecurityService>();
			service.AddScoped<IJwtGenerator, JwtGenerator>();
		}

		/// <summary>
		/// CONFIGURE RULE CORS
		/// </summary>
		/// <param name="service"></param>
		public static void ConfigureCORS(IServiceCollection service)
		{
			service.AddCors(opt =>
			{
				opt.AddPolicy(name: Constants.CORS_RULE, rule =>
				{
					rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*").AllowAnyOrigin();
				});
			});
		}

		/// <summary>
		/// CONFIGURE MIGRATION DB
		/// </summary>
		/// <param name="service"></param>
		/// <param name="logger"></param>
		public static void ConfigureDBMigration(IServiceProvider service, Logger logger)
		{
			try
			{
				using (var scope = service.CreateScope())
				{
					var dataContext = scope.ServiceProvider.GetRequiredService<DBContext>();
					dataContext.Database.Migrate();
				}
			}
			catch (Exception ex)
			{
				logger.Error($"ERROR MIGRATING DB: {ex.Message}");
			}
		}

	}
}
