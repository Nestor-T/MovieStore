using FluentValidation.AspNetCore;
using Mapster;
using MovieStoreB.BL;
using MovieStoreB.DL;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDataDependencies()
    .AddBusinessDependencies();

var logger = new LoggerConfiguration().Enrich.FromLogContext()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

builder.Services.AddMapster();

builder.Services.AddFluentValidation();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
