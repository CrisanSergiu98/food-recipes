using FoodRecipes.Domain.Aggregates.Recipe.Enums;

namespace FoodRecipes.Domain.Aggregates.Recipe.DTOs;

public record RecipeIngredientDto(
    Guid IngredientId,
    float Quantity, 
    Measurement Measurement);