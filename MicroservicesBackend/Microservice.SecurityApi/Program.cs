
using FluentValidation;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Mapping;
using Microservice.Security.Core.Persistence;
using Microservice.Security.Core.Persistence.Entities;
using Microservice.Security.Core.Persistence.Repository;
using Microservice.SecurityApi.Core.Application.Exceptions;
using Microservice.Ioc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microservice.Security.Core.Application.Mediator.Command.SignUpCommandHandler;
using static Microservice.Security.Core.Application.Mediator.Query.LoginQueryHandler;


var builder = WebApplication.CreateBuilder(args);

// CONFIGURE BUILDER -------------------------------------------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerJWTExtensionConfiguration("Security", "v1.0.0");

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
builder.Services.AddScoped<IUserSession, UserSession>();
builder.Services.AddScoped<IUserSessionRepository, UserSessionRepository>();

// FLUENT API
builder.Services.AddScoped<IValidator<UserSignUp>, UserSignUpValidation>();
builder.Services.AddScoped<IValidator<UserLogin>, UserLoginValidation>();

// JWT
builder.Services.AddJWTExtensionConfiguration(builder.Configuration);

// CORS
builder.Services.AddCORSExtensionConfiguration();



// APPLICATION BUILT------------------------------------------------------------------------------------------------
var app = builder.Build();

app.UseMiddleware<GlobalRequestExceptionHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsRule");

// HABILITAR PARA UTILIZAR EL HTTPCONTEXT CLAIMS (TOKEN)
app.UseAuthentication();
app.UseAuthorization();

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
