using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.UpdateRecipe;

public record UpdateRecipeCommand(
    Guid Id,
    string Title,
    string Description,
    HashSet<(Guid, float, string)> Ingredients,
    HashSet<(int, string)> Steps
    ) : ICommand<Result>;
