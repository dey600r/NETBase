using Keycloak.AuthServices.Authentication;
using MassTransit;
using Microservice.VehicleApi.Core.Constants;
using Microservice.VehicleApi.Core.Dtos.Utils;
using Microservice.VehicleApi.Core.Mapping;
using Microservice.VehicleApi.Infraestructure.Context;
using Microservice.VehicleApi.Infraestructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Microservice.VehicleApi.Ioc
{
	public static class DependencyInjection
	{
		/// <summary>
		/// SWAGGER WITH JWT
		/// </summary>
		/// <param name="service"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwaggerJWTExtensionConfiguration(this IServiceCollection service)
		{
			service.AddSwaggerGen(opt =>
			{
				opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice Vehicle API", Version = "v1" });
				opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
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
			return service;
		}

		/// <summary>
		/// SWAGGER WITH JWT
		/// </summary>
		/// <param name="service"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwaggerKeycloakExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			var keycloackSettings = configuration.GetSection("keycloak").Get<KeycloakSettings>();
			service.AddSwaggerGen(c =>
			{
				// KeyCloak
				c.CustomSchemaIds(type => type.ToString());
				var securityScheme = new OpenApiSecurityScheme
				{
					Name = "KEYCLOAK",
					Type = SecuritySchemeType.OAuth2,
					In = ParameterLocation.Header,
					BearerFormat = "JWT",
					Scheme = "bearer",
					Flows = new OpenApiOAuthFlows
					{
						AuthorizationCode = new OpenApiOAuthFlow
						{
							AuthorizationUrl = new Uri(keycloackSettings.AuthorizationUrl),
							TokenUrl = new Uri(keycloackSettings.TokenUrl),
							Scopes = new Dictionary<string, string> { }
						}
					},
					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};
				c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
				c.AddSecurityRequirement(new OpenApiSecurityRequirement{
												{securityScheme, new string[] { }}
											});
			});
			return service;
		}

		/// <summary>
		/// Configure BD CONTEXT
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		public static IServiceCollection AddDBContextExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContext<DBContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("SqlServer")),
				ServiceLifetime.Scoped
			);
			return service;
		}

		public static IServiceCollection AddRabbitMqExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			var rabbitMQSettings = configuration.GetSection("RabbitMQSettings").Get<RabbitMQSettings>();
			service.AddMassTransit(x =>
			{

				x.AddConsumers(Assembly.GetEntryAssembly());
				x.UsingRabbitMq((context, cfg) =>
				{
					cfg.Host(rabbitMQSettings.Host, rabbitMQSettings.VHost, h =>
					{
						h.Username(rabbitMQSettings.User);
						h.Password(rabbitMQSettings.Pwd);
						//h.UseSsl(s =>
						//{
						//	s.Protocol = SslProtocols.Tls12;
						//});
					});

					cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(rabbitMQSettings.ServiceName, false));
					cfg.UseMessageRetry(b =>
					{
						b.Interval(3, TimeSpan.FromSeconds(5));
					});

				});
			});

			return service;
		}

		/// <summary>
		/// CONFIGURE JWT 
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		public static IServiceCollection AddJWTExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			var config = configuration.GetSection("Jwt").Get<JwtSettings>();
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
			return service;
		}

		/// <summary>
		/// CONFIGURE KEYCLOAK 
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		public static IServiceCollection AddKeycloakExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{

			service
				.AddHttpContextAccessor()
				.AddAuthentication(options => {
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

				})
				.AddJwtBearer(options =>
				{
					options.Authority = "http://localhost:8180/realms/test";
					options.MetadataAddress = "http://localhost:8180/realms/test/.well-known/openid-configuration";
					options.RequireHttpsMetadata = false;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						NameClaimType = ClaimTypes.Name,
						RoleClaimType = ClaimTypes.Role,
						ValidateIssuer = true,
						ValidIssuers = new[] { "http://localhost:8180/realms/test", "backend" },
						ValidateAudience = true,
						ValidAudiences = new[] { "backend", "account" },
					 };
				});
			//var keycloackSettings = configuration.GetSection("Keycloak").Get<KeycloakAuthenticationOptions>();
			//service.AddHttpContextAccessor()
			//	.AddAuthorization()
			//	//.AddKeycloakAuthentication(configuration)
			//	.AddAuthentication(options =>
			//	{
			//		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			//		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			//	})
			//	.AddJwtBearer(o =>
			//	{
			//		o.Authority = configuration["Jwt:Authority"];
			//		o.Audience = configuration["Jwt:Audience"];
			//		o.RequireHttpsMetadata = false;
			//	});
			//var keycloackSettings = configuration.GetSection("keycloak").Get<KeycloakSettings>();
			//service.AddHttpContextAccessor()
			//	.AddAuthorization()
			//	.AddAuthentication(options =>
			//	{
			//		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			//		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			//	}).AddJwtBearer(o =>
			//	{
			//		o.Authority = keycloackSettings.Authority;
			//		o.Audience = keycloackSettings.Audience;
			//		o.RequireHttpsMetadata = false;
			//		o.Events = new JwtBearerEvents()
			//		{
			//			OnAuthenticationFailed = c =>
			//			{
			//				c.NoResult();

			//				c.Response.StatusCode = 500;
			//				c.Response.ContentType = "text/plain";

			//				// Debug only for security reasons
			//				// return c.Response.WriteAsync(c.Exception.ToString());

			//				return c.Response.WriteAsync("An error occured processing your authentication.");
			//			}
			//		};
			//	});
			return service;
		}

		/// <summary>
		/// INJECT SERVICES
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		public static IServiceCollection AddAppDependenciesExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			// AUTOMAPPER
			service.AddAutoMapper(typeof(BusinessProfile));

			// REPOSITORIES
			service.AddScoped<IVehicleRepository, VehicleRepository>();
			service.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
			service.AddScoped<IConfigurationRepository, ConfigurationRepository>();

			return service;
		}

		/// <summary>
		/// CONFIGURE RULE CORS
		/// </summary>
		/// <param name="service"></param>
		public static IServiceCollection AddCORSExtensionConfiguration(this IServiceCollection service)
		{
			service.AddCors(opt =>
			{
				opt.AddPolicy(name: AppConstants.CORS_RULE, rule =>
				{
					rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*").AllowAnyOrigin();
				});
			});

			return service;
		}

		/// <summary>
		/// CONFIGURE MIGRATION DB
		/// </summary>
		/// <param name="service"></param>
		/// <param name="logger"></param>
		public static void ConfigureDBMigration(this IServiceProvider service)
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
				Console.WriteLine($"ERROR MIGRATING DB: {ex.Message}");
			}
		}
	}
}
