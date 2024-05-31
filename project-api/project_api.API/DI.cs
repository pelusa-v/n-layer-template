namespace project_api.API;

public static class DI
{
    public static IServiceCollection AddAPILayer(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthenticationConfiguration(configuration)
            .AddAuthorizationConfiguration(configuration);
        return services;
    }

    private static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    private static IServiceCollection AddAuthorizationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddAuthorization();
        return services;
    }
}