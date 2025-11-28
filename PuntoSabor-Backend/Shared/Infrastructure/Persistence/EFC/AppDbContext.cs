using Microsoft.EntityFrameworkCore;
using PuntoSabor_Backend.Auth.Domain.Model;
using PuntoSabor_Backend.Discovery.Domain.Model;
using PuntoSabor_Backend.Memberships.Domain.Model;
using PuntoSabor_Backend.Promotions.Domain.Model;
using PuntoSabor_Backend.Reviews.Domain.Model;

namespace PuntoSabor_Backend.Shared.Infrastructure.Persistence.EFC;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Huarique> Huariques => Set<Huarique>();
    public DbSet<Promo> Promos => Set<Promo>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Review> Reviews => Set<Review>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de tablas
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Huarique>().ToTable("Huariques");
        modelBuilder.Entity<Promo>().ToTable("Promos");
        modelBuilder.Entity<Plan>().ToTable("Plans");
        modelBuilder.Entity<Review>().ToTable("Reviews");

        modelBuilder.Entity<Plan>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Plan>()
            .Property(p => p.Id)
            .HasMaxLength(50);
    }
}