using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Dto;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.UpdateRecipe;

public record UpdateRecipeCommand(
    Guid Id,
    string Title,
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<string> Steps
    ) : ICommand<Result>;
