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
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

        return services;
    }
}