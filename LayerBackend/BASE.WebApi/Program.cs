using Autofac.Core;
using BASE.Common.Constants;
using BASE.IoC;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("--------- Initializing Server ----------");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerExtensionConfiguration();

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddDBContextExtensionConfiguration(builder.Configuration);
builder.Services.AddJWTExtensionConfiguration(builder.Configuration);
builder.Services.AddAppDependenciesExcensionConfiguration(builder.Configuration);
builder.Services.AddCORSExtensionConfiguration();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(ConstantsSecurity.CORS_RULE);

// HABILITAR PARA UTILIZAR EL HTTPCONTEXT CLAIMS (TOKEN)
app.UseAuthentication();
// HABILITAR PARA EL LOGIN
app.UseAuthorization();

app.MapControllers();

app.Services.ConfigureDBMigration(logger);

app.Run();