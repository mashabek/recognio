using System.Reflection;
using ApplicationCore.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services, IConfiguration configuration)
    {
       AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        // services.AddDbContext<AppDbContext>(options => options.UseInMemory("Db"))
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddScoped<AppDbContextInitialiser>();
 
        return services;
    }
}