
using Microsoft.EntityFrameworkCore;
using project_api.DataAccess.Repositories;
using project_api.DataAccess.Repositories.Impl;

namespace project_api.DataAccess;

public static class DI
{
    // Extension method
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDatabase(configuration)
            .AddRepositories(configuration)
            .AddDataUtils(configuration);
        return services;
    }

    // Extension method
    private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPetRepository, PetRepository>();
        return services;
    }

    // Extension method
    private static IServiceCollection AddDataUtils(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    // Extension method
    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["Resources:Database"];

        services
            .AddDbContext<AppDbContext>(options => 
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

        return services;
    }
}