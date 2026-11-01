using Microservice.Chatbot.Core.Logic;
using Microservice.Chatbot.DataAccess.Context;
using Microservice.Chatbot.DataAccess.Repository;
using Microservice.Chatbot.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = $"Microservice ChatBot API", Version = "1.0.0" });
});

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ChatbotContext>((sp, options) =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"), o => o.UseVector());
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IChatbotRepository, ChatbotRepository>();
builder.Services.AddScoped<IHttpChatbotRequest, HttpChatbotRequest>();
builder.Services.AddScoped<IChatbotCore, ChatbotCore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
