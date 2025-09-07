using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipes.Persistence;

// Static class for configuring dependency injection
public static class DependencyInjection
{
    // Extension method to add persistence services to the IServiceCollection
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        // Register the recipe repository as a singleton
        services.AddScoped<IRecipeRepository, RecipeRepository>();

        // Register the ingredient repository as a singleton
        services.AddScoped<IIngredientRepository, IngredientRepository>();

        return services;
    }
}
