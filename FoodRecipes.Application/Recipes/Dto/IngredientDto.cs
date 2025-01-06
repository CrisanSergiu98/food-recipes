namespace FoodRecipes.Application.Recipes.Dto;

public record IngredientDto(
    Guid Id,
    string Name,
    string Description);
