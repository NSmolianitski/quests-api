using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuestsApi.Application;
using QuestsApi.Application.Common.Interfaces.Persistence;
using QuestsApi.Infrastructure;

namespace QuestsApi.Api;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddQuestsApi(this WebApplicationBuilder builder)
    {
        builder.Services.AddPresentation();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure();
        builder.AddDatabase();

        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies([
                typeof(Program).Assembly,
                typeof(IUnitOfWork).Assembly
            ]));

        return builder;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Quests API"
            });
        });

        return services;
    }

    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }

    private static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<QuestsApiDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("QuestsApiDb")));

        return builder;
    }
}