using Application;
using Core;
using Infrastructure;
using Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddCoreServices();
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();