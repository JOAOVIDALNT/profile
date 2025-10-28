using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using profile.Domain.Interfaces.Repositories;
using profile.Infrastructure.Data;
using profile.Infrastructure.Data.Repositories;

namespace profile.Infrastructure;

public static class InfrastructureDependencyInjection 
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddRepositories();

        if (config.GetValue<bool>("InMemoryTest"))
            return;

        services.AddDatabase(config);
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
        });
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ISubscriberRepository, SubscriberRepository>();
    }
}