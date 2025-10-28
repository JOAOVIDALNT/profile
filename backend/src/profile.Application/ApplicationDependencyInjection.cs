using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using profile.Application.Services.User;

namespace profile.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        
        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}