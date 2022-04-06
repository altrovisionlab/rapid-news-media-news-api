using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using rapid_news_media_news_api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NewsDBContext>(opt => opt.UseInMemoryDatabase("NewsDB"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Initialize Seed for In Memory Database 
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<NewsDBContext>();
    dbcontext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
