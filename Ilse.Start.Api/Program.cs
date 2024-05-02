using Ilse.Core.Exceptions;
using Ilse.CorrelationId.DependencyInjection;
using Ilse.CorrelationId.Middleware;
using Ilse.Cqrs.Commands;
using Ilse.Cqrs.DependencyInjection;
using Ilse.Events.DependencyInjection;
using Ilse.MinimalApi.EndPoints;
using Ilse.MultiTenant.DependencyInjection;
using Ilse.MultiTenant.Middleware;
using Ilse.Start.Api.Config;
using Ilse.Repository.DependencyInjection;
using Ilse.Start.Domain.ToDo;
using Ilse.Start.Infrastructure.Repository.ToDo.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

Config.ConfigureSwagger(builder);
Config.ConfigureSecurityPolicies(builder);

builder.Services.AddCorrelationId();
builder.Services.AddMultiTenant();
builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddEvents();
builder.Services.AddEndpoints();
builder.Services.AddRepository<IlseContext>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();


var app = builder.Build();
//app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCorrelationId();
app.UseMultiTenant();
app.MapEndpoints();
//app.UseMiddleware<LoggingMiddleware>();

app.UseExceptionHandler();

app.Run();
