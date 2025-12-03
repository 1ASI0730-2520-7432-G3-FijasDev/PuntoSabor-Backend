using Microsoft.EntityFrameworkCore;
using PuntoSabor_Backend.Auth.Domain.Repositories;
using PuntoSabor_Backend.Auth.Infrastructure.Persistence.EFC.Repositories;
using PuntoSabor_Backend.Discovery.Domain.Repositories;
using PuntoSabor_Backend.Discovery.Infrastructure.Persistence.EFC.Repositories;
using PuntoSabor_Backend.Memberships.Domain.Repositories;
using PuntoSabor_Backend.Memberships.Infrastructure.Persistence.EFC.Repositories;
using PuntoSabor_Backend.Promotions.Domain.Repositories;
using PuntoSabor_Backend.Promotions.Infrastructure.Persistence.EFC.Repositories;
using PuntoSabor_Backend.Reviews.Domain.Repositories;
using PuntoSabor_Backend.Reviews.Infrastructure.Persistence.EFC.Repositories;
using PuntoSabor_Backend.Shared.Domain.Repositories;
using PuntoSabor_Backend.Shared.Infrastructure.Persistence.EFC;

var builder = WebApplication.CreateBuilder(args);

// DbContext: MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString!);
});

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, AppUnitOfWork>();

// Repositorios
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IHuariqueRepository, HuariqueRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPromoRepository, PromoRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Controllers + JSON
builder.Services.AddControllers().AddNewtonsoftJson();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS para el frontend en Vite
const string corsPolicyName = "PuntoSaborCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    db.Database.EnsureCreated();

    Console.WriteLine(">>> Ejecutando DataSeeder...");
    
    DataSeeder.Seed(db);
    
    Console.WriteLine(">>> DataSeeder terminado.");
}

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();