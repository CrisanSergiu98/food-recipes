using FoodRecipes.Domain.Aggregates.Recipe.Enums;
using FoodRecipes.Domain.ValueObjects;

namespace FoodRecipes.Domain.Aggregates.Recipe.DTOs;

public record RecipeIngredientDto(
    Guid IngredientId,
    IngredientQuantity Quantity, 
    Measurement Measurement);