namespace FoodRecipes.Application.Dto;

public record RecipeDto(
    Guid Id,
    string Title,
    string Description,
    List<RecipeIngredientDto> Ingredients,
    List<string> Steps);
