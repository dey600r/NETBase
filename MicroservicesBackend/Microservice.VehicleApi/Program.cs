
using Microservice.VehicleApi.Core.Constants;
using Microservice.VehicleApi.Ioc;

var builder = WebApplication.CreateBuilder(args);

// APP BUILD ------------------------------------------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

bool keycloakEnabled = builder.Configuration["keycloakEnabled"] == "true";

// SWAGGER
//if (keycloakEnabled)
//	builder.Services.AddSwaggerKeycloakExtensionConfiguration(builder.Configuration);
//else
	builder.Services.AddSwaggerJWTExtensionConfiguration();

// CONFIG CONTEXT
builder.Services.AddDBContextExtensionConfiguration(builder.Configuration);

// MASS TRANSIG - RABBITMQ
builder.Services.AddRabbitMqExtensionConfiguration(builder.Configuration);

// INJECT SERVICES
builder.Services.AddAppDependenciesExtensionConfiguration(builder.Configuration);

// SECURITY
if (keycloakEnabled)
	builder.Services.AddKeycloakExtensionConfiguration(builder.Configuration);
else
	builder.Services.AddJWTExtensionConfiguration(builder.Configuration);

// CORS
builder.Services.AddCORSExtensionConfiguration();

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

app.Services.ConfigureDBMigration();

app.Run();

