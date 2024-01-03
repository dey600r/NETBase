using Microservice.Gateway.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddOcelot();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice Gateway", Version = "v1" }));

// CONFIG APPSETTING JWT
var configJWT = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
//builder.Services.AddSingleton(config);

// JWT
builder.Services
	.AddHttpContextAccessor()
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
			ValidIssuer = configJWT.Issuer,
			ValidAudience = configJWT.Audience,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configJWT.Key))
		};
	});

// CORS
builder.Services.AddCors(opt => {
	opt.AddPolicy(name: "CorsRule", rule => {
		rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*").AllowAnyOrigin();
	});
});


// APP BUILT ----------------------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsRule");

// HABILITAR PARA UTILIZAR EL HTTPCONTEXT CLAIMS (TOKEN)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();
app.Run();
