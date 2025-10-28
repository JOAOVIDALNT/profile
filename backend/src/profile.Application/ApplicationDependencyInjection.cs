using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using profile.Application.Services.User;

namespace profile.Application;

public static class ApplicationDependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}