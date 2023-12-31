
using MassTransit;
using Microservice.MaintenanceApi.Core.Constants;
using Microservice.MaintenanceApi.Core.Dtos.Utils;
using Microservice.MaintenanceApi.Core.Events;
using Microservice.MaintenanceApi.Core.Mapping;
using Microservice.MaintenanceApi.Infraestructure.Context;
using Microservice.MaintenanceApi.Infraestructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// APP BUILD ------------------------------------------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// SWAGGER
builder.Services.AddSwaggerGen(opt => {
	opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice Maintenance API", Version = "v1" });
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

// CONFIG CONTEXT
builder.Services.AddDbContext<DBContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")),
	ServiceLifetime.Scoped
);

// MASS TRANSIG - RABBITMQ
var rabbitMQSettings = builder.Configuration.GetSection("RabbitMQSettings").Get<RabbitMQSettings>();
builder.Services.AddMassTransit(x =>
{
	//x.AddConsumer<MessageEventConsumer>();
	x.AddConsumers(Assembly.GetEntryAssembly());
	x.UsingRabbitMq((context, cfg) =>
	{
		cfg.Host(rabbitMQSettings.Host, rabbitMQSettings.VHost, h =>
		{
			h.Username(rabbitMQSettings.User);
			h.Password(rabbitMQSettings.Pwd);
		});

		cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(rabbitMQSettings.ServiceName, false));
		cfg.UseMessageRetry(b =>
		{
			b.Interval(3, TimeSpan.FromSeconds(5));
		});
	});
});

// AUTOMAPPER
builder.Services.AddAutoMapper(typeof(BusinessProfile));

// REPOSITORIES
builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();

// SECURITY
var config = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
builder.Services.AddHttpContextAccessor()
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

// CORS
builder.Services.AddCors(opt =>
{
	opt.AddPolicy(name: AppConstants.CORS_RULE, rule =>
	{
		rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*").AllowAnyOrigin();
	});
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);


// APP BUILT -----------------------------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(AppConstants.CORS_RULE);

// HABILITAR PARA UTILIZAR EL HTTPCONTEXT CLAIMS (TOKEN)
app.UseAuthentication();
// HABILITAR PARA EL LOGIN
app.UseAuthorization();

app.MapControllers();

try
{
	using (var scope = app.Services.CreateScope())
	{
		var dataContext = scope.ServiceProvider.GetRequiredService<DBContext>();
		dataContext.Database.Migrate();
	}
}
catch (Exception ex)
{
	Console.WriteLine($"ERROR MIGRATING DB: {ex.Message}");
}

app.Run();

