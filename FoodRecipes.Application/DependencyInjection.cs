using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FoodRecipes.Application;

// Static class for configuring dependency injection
public static class DependencyInjection
{
    // Extension method to add application services to the IServiceCollection
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register MediatR services from the executing assembly
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
