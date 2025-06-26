using Microsoft.EntityFrameworkCore;
using MicroVShop.Context;
using MicroVShop.DTOs.Mappings;
using MicroVShop.Repositories;

namespace MicroVShop.Services;

public static class ServicesExtension
{
    public static void ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection"); 
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString)
            )
        );
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }
}