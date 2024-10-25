using Microsoft.Extensions.DependencyInjection;
using QuestsApi.Application.Common.Interfaces.Persistence;
using QuestsApi.Infrastructure.Persistence;

namespace QuestsApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services
            .AddScoped<IPlayerRepository, EfPlayerRepository>()
            .AddScoped<IQuestRepository, EfQuestRepository>()
            .AddScoped<IPlayerQuestRepository, EfPlayerQuestRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}