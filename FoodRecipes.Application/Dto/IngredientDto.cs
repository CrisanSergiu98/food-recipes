namespace FoodRecipes.Application.Dto;

public record IngredientDto(
    Guid Id,
    string Name,
    string Description);
