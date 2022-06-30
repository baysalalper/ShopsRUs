namespace Application;

using Builders;
using Microsoft.Extensions.DependencyInjection;
using Services;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IBillService, BillService>();
        return services;
    }
}