using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes.Enums;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    string Title, 
    string Description,
    HashSet<(Guid, float, string)> Ingredients,
    HashSet<(int, string)> Steps
    ):ICommand<Result>;
