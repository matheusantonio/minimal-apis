using Microsoft.EntityFrameworkCore;
using Minimal.API.Configurations.Extensions;
using Minimal.Domain.Posts.Repositories;
using Minimal.Domain.Posts.Services;
using Minimal.Infrastructure.Persistence.Core.EntityFramework;
using Minimal.Infrastructure.Persistence.Posts.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostsContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPostRoutes();

app.Run();