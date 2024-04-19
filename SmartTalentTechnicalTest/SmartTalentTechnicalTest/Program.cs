using Domain.Repositories;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartTalentTechnicalTest.ApplicationServices;
using SmartTalentTechnicalTest.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserQueries>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductQueries>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderQueries>();
builder.Services.AddScoped<OrderServices>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/AuthController/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
