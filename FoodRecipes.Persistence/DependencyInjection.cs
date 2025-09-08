using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipes.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IRecipeRepository, RecipeRepository>();        
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
