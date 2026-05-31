using MetalERP.Application.Contracts;
using MetalERP.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MetalERP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<ISetorRepository, SetorRepository>();

        return services;
    }
}