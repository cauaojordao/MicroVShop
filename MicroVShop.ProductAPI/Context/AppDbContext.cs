using Microsoft.EntityFrameworkCore;
using MicroVShop.Models;

namespace MicroVShop.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}