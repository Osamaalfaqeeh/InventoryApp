using InventoryApp.API.Extensions;
using InventoryApp.API.Middleware;
using InventoryApp.Application.Auth;
using InventoryApp.Application.Interfaces;
using InventoryApp.Infrastructure.Auth;
using InventoryApp.Infrastructure.Persistence;
using InventoryApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerWithJwt();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseRouting();
app.UseCustomExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.UseHsts();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
