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

DependencyInjection.ConfigureSwagger(builder.Services);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

DependencyInjection.ConfigureDBContext(builder.Services, builder.Configuration);
DependencyInjection.ConfigureJWT(builder.Services, builder.Configuration);
DependencyInjection.AddMyDependencyGroup(builder.Services, builder.Configuration);
DependencyInjection.ConfigureCORS(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(Constants.CORS_RULE);

// HABILITAR PARA UTILIZAR EL HTTPCONTEXT CLAIMS (TOKEN)
app.UseAuthentication();
// HABILITAR PARA EL LOGIN
app.UseAuthorization();

app.MapControllers();

DependencyInjection.ConfigureDBMigration(app.Services, logger);

app.Run();