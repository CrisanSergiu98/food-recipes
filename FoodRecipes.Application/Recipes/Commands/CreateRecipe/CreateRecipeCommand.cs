using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Recipes.Dto;
using FoodRecipes.Domain.Recipes.Enums;
using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    string Title, 
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<string> Steps
    ):ICommand<Result>;
