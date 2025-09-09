using FoodRecipes.Application.Abstractions.Security;
using FoodRecipes.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipes.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        return services;
    }
}