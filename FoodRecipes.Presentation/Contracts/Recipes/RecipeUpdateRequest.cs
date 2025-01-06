using FoodRecipes.Application.Recipes.Dto;

namespace FoodRecipes.Presentation.Contracts.Recipes;

public record RecipeUpdateRequest(
    Guid Id,
    string Title,
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<string> Steps);