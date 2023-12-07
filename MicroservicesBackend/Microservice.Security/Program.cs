
using FluentValidation;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Dto;
using Microservice.Security.Core.Application.Mapping;
using Microservice.Security.Core.Persistence;
using Microservice.Security.Core.Persistence.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static Microservice.Security.Core.Application.Mediator.Command.SignUpCommandHandler;


var builder = WebApplication.CreateBuilder(args);

// CONFIGURE BUILDER -------------------------------------------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONFIG CONTEXT
builder.Services.AddDbContext<SecurityContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")),
		ServiceLifetime.Scoped
	)	
	.AddIdentityCore<User>() // USERS & ROLES
	.AddRoles<Role>()
	.AddEntityFrameworkStores<SecurityContext>()
	.AddSignInManager<SignInManager<User>>();

// MEDIATOR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// MAPPER
builder.Services.AddAutoMapper(typeof(MappingProfile));

// SERVICES
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

// FLUENT API
builder.Services.AddScoped<IValidator<UserSignUp>, UserSignUpValidation>();

// CONFIG APPSETTING JWT
var config = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
builder.Services.AddSingleton(config);

// JWT
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
builder.Services.AddCors(opt => {
	opt.AddPolicy(name: "CorsRule", rule => {
		rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*").AllowAnyOrigin();
	});
});


// APPLICATION BUILT------------------------------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsRule");

// HABILITAR PARA UTILIZAR EL HTTPCONTEXT CLAIMS (TOKEN)
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

// MIGRATION DB
try
{
	using (var scope = app.Services.CreateScope())
	{
		var dataContext = scope.ServiceProvider.GetRequiredService<SecurityContext>();
		dataContext.Database.Migrate();
	}
}
catch (Exception ex)
{
	Console.WriteLine("ERROR DATABASE MIGRATION: " + ex.Message);
}

app.Run();
