using CodeJournalApi.Data;
using CodeJournalApi.Data.Interfaces;
using CodeJournalApi.Data.Repositories;
using CodeJournalApi.Data.Services;
using CodeJournalApi.DTOs;
using CodeJournalApi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<Context>();
builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Project>, ProjectRepository>();
builder.Services.AddScoped<IService<ProjectDTO>, ProjectService>();
builder.Services.AddScoped<IRepository<Post>, PostRepository>();
builder.Services.AddScoped<IService<PostDTO>, PostService>();

var app = builder.Build();

{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<Context>();
    await context.Init();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
