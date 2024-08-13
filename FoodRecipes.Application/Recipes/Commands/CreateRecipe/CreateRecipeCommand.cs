using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes.DTOs;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    string Title, 
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<RecipeStepDto> Steps
    ):ICommand<Result>;
