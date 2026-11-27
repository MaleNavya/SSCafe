using Microsoft.EntityFrameworkCore;
using SSCafe.UserManagement.Domain.Interfaces;
using SSCafe.UserManagement.Infrastructure.Data;
using SSCafe.UserManagement.Infrastructure.Repositories;
using SSCafe.UserManagement.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Controllers
builder.Services.AddControllers();

// Register Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register PostgreSQL Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Register Repository
builder.Services.AddScoped<IMenuRepository, MenuRepository>();

// Register Service
builder.Services.AddScoped<MenuService>();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();