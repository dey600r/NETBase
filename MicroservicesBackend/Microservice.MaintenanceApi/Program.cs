
using Microservice.MaintenanceApi.Core.Constants;
using Microservice.MaintenanceApi.Core.Mapping;
using Microservice.MaintenanceApi.Infraestructure.Context;
using Microservice.MaintenanceApi.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microservice.Ioc;

var builder = WebApplication.CreateBuilder(args);

// APP BUILD ------------------------------------------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// SWAGGER
builder.Services.AddSwaggerJWTExtensionConfiguration("Maintenance", "v1.0.0");

// CONFIG CONTEXT
builder.Services.AddDbContext<DBContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")),
	ServiceLifetime.Scoped
);

// MASS TRANSIG - RABBITMQ
builder.Services.AddRabbitMqExtensionConfiguration(builder.Configuration);

// AUTOMAPPER
builder.Services.AddAutoMapper(typeof(BusinessProfile));

// REPOSITORIES
builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();

// SECURITY
builder.Services.AddSecurityExtensionConfiguration(builder.Configuration);

// CORS
builder.Services.AddCORSExtensionConfiguration();


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

