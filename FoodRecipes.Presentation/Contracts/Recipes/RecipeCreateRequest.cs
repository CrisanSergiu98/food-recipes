using FoodRecipes.Application.Recipes.Dto;

namespace FoodRecipes.Presentation.Contracts.Recipes;

public record RecipeCreateRequest(
    string Title,
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<string> Steps);
