using Microsoft.EntityFrameworkCore;
using MicroVShop.Models;

namespace MicroVShop.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(500)
                .IsRequired();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(12,2)");

            entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);

            entity.Property(e => e.Stock)
                .HasColumnName("Stock")
                .HasColumnType("bigint");

            entity.Property(e => e.ImageURL)
                .HasColumnName("ImageURL")
                .HasMaxLength(255);

            entity.Property(e => e.CategoryId)
                .HasColumnName("CategoryId");

            // Relacionamento com Category
            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Products_Categories_CategoryId");
        });
    }

}