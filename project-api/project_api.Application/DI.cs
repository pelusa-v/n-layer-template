using project_api.Application.Mapper;
using project_api.Application.Services;
using project_api.Application.Services.Impl;

namespace project_api.Application;

public static class DI
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterAutoMapper()
            .AddApplicationServices(configuration)
            .AddUtils(configuration)
            .RegisterBroker(configuration);
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IVetService, VetService>();
        return services;
    }

    public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Marker));
        return services;
    }

    // Extension method
    private static IServiceCollection AddUtils(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection RegisterBroker(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}