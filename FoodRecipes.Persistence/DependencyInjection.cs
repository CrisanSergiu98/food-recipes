using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipes.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services) 
    {
        services.AddTransient<IRecipeRepository,RecipeRepository>();
        services.AddTransient<IIngredientRepository, IngredientRepository>();

        return services;
    }
}
