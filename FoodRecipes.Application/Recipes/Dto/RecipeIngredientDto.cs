namespace FoodRecipes.Application.Recipes.Dto;

public record RecipeIngredientDto(
Guid IngredientId,
float Quantity,
string Unit);
