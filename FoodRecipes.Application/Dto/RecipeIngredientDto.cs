namespace FoodRecipes.Application.Dto;

public record RecipeIngredientDto(
Guid IngredientId,
float Quantity,
string Unit);
