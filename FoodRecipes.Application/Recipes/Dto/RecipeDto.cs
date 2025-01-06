namespace FoodRecipes.Application.Recipes.Dto;

public record RecipeDto(
    string Title,
    string Decription,
    List<RecipeIngredientDto> Ingredients,
    List<string> Steps);
