
using Microservice.IoC.Utils;
using Microservice.Ioc;
using Microservice.VehicleApi.Ioc;

var builder = WebApplication.CreateBuilder(args);

// APP BUILD ------------------------------------------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// SWAGGER
builder.Services.AddSwaggerJWTExtensionConfiguration("Vechicle", "v1.0.0");

// CONFIG CONTEXT
builder.Services.AddDBContextExtensionConfiguration(builder.Configuration);

// MASS TRANSIG - RABBITMQ
builder.Services.AddRabbitMqExtensionConfiguration(builder.Configuration);

// INJECT SERVICES
builder.Services.AddAppDependenciesExtensionConfiguration(builder.Configuration);

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
app.UseCors(SecurityConstants.CORS_RULE);

// HABILITAR PARA UTILIZAR EL HTTPCONTEXT CLAIMS (TOKEN)
app.UseAuthentication();
// HABILITAR PARA EL LOGIN
app.UseAuthorization();
app.MapControllers();

app.Services.ConfigureDBMigration();

app.Run();

