using MassTransit;
using Microservice.IoC.Settings;
using Microservice.IoC.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Microservice.Ioc
{
	public static class DependencyInjection
	{
		/// <summary>
		/// SWAGGER WITH JWT
		/// </summary>
		/// <param name="service"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwaggerJWTExtensionConfiguration(this IServiceCollection service, string name, string version)
		{
			service.AddSwaggerGen(opt =>
			{
				opt.SwaggerDoc("v1", new OpenApiInfo { Title = $"Microservice {name} API", Version = version });
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
		/// SECURITY API
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddSecurityExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			if (configuration["keycloakEnabled"] == "true")
				service.AddKeycloakExtensionConfiguration(configuration);
			else
				service.AddJWTExtensionConfiguration(configuration);

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
		/// CONFIGURE JWT 
		/// </summary>
		/// <param name="service"></param>
		/// <param name="configuration"></param>
		public static IServiceCollection AddJWTExtensionConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			var config = configuration.GetSection("Jwt").Get<JwtSettings>();
			service.AddSingleton(config);
			service.AddHttpContextAccessor()
				.AddAuthorization(options =>
				{
					options.AddPolicy(SecurityConstants.SUPER_ADMIN_POLICY, policy => policy.RequireRole(SecurityConstants.ADMIN_ROLE_NAME, SecurityConstants.MANAGER_ROLE_NAME));
					options.AddPolicy(SecurityConstants.READ_WRITE_POLICY, policy => policy.RequireRole(SecurityConstants.MANAGER_ROLE_NAME));
					options.AddPolicy(SecurityConstants.READ_POLICY, policy => policy.RequireRole(SecurityConstants.CUSTOMER_ROLE_NAME));
				})
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
			var keycloackSettings = configuration.GetSection("Keycloak").Get<KeycloakSettings>();
			service
				.AddHttpContextAccessor()
				.AddAuthorization(options =>
				{
					options.AddPolicy(SecurityConstants.SUPER_ADMIN_POLICY, policy => policy.RequireRole(SecurityConstants.ADMIN_ROLE_NAME, SecurityConstants.MANAGER_ROLE_NAME));
					options.AddPolicy(SecurityConstants.READ_WRITE_POLICY, policy => policy.RequireRole(SecurityConstants.MANAGER_ROLE_NAME));
					options.AddPolicy(SecurityConstants.READ_POLICY, policy => policy.RequireRole(SecurityConstants.CUSTOMER_ROLE_NAME));
				})
				.AddAuthentication(options => {
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.Authority = keycloackSettings.Authority;
					options.MetadataAddress = keycloackSettings.AuthorizationUrl;
					options.RequireHttpsMetadata = false;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						NameClaimType = ClaimTypes.Name,
						RoleClaimType = ClaimTypes.Role,
						ValidateIssuer = true,
						ValidIssuers = new[] { keycloackSettings.Authority, keycloackSettings.ClientId },
						ValidateAudience = true,
						ValidAudiences = new[] { keycloackSettings.Audience, keycloackSettings.ClientId },
					 };
				});

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
				opt.AddPolicy(name: SecurityConstants.CORS_RULE, rule =>
				{
					rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*").AllowAnyOrigin();
				});
			});

			// CONTROLLER LOWER CASE
			service.AddRouting(options => options.LowercaseUrls = true);

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
	}
}
