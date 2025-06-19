using Microsoft.EntityFrameworkCore;
using MicroVShop.Context;

namespace MicroVShop.Services;

public static class ServicesExtension
{
    public static void ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("Developer"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Developer"))
            )
        );
        
    }
}