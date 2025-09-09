using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Dto;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    string Title,
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<string> Steps
    ) : ICommand<Result<Guid>>;
