
using FluentValidation;
using Microservice.Security.Core.Application.Actions;
using Microservice.Security.Core.Application.Mapping;
using Microservice.Security.Core.Application.Mapping.Dto.Settings;
using Microservice.Security.Core.Persistence;
using Microservice.Security.Core.Persistence.Entities;
using Microservice.Security.Core.Persistence.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static Microservice.Security.Core.Application.Mediator.Command.SignUpCommandHandler;
using static Microservice.Security.Core.Application.Mediator.Query.LoginQueryHandler;


var builder = WebApplication.CreateBuilder(args);

// CONFIGURE BUILDER -------------------------------------------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
	opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice Security API", Version = "v1" });
	opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { 
		In = ParameterLocation.Header,
		Description = "Please enter token",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "bearer" });
	opt.AddSecurityRequirement(new OpenApiSecurityRequirement { {
							new OpenApiSecurityScheme {
								Reference = new OpenApiReference {
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer" } }, new string[] { }}});
});

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

builder.Services.AddRouting(options => options.LowercaseUrls = true);



// APPLICATION BUILT------------------------------------------------------------------------------------------------
var app = builder.Build();

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
