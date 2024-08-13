using FoodRecipes.Domain.Aggregates.Recipes.Enums;
using FoodRecipes.Domain.Common.ValueObjects;

namespace FoodRecipes.Domain.Recipes.DTOs;

public record RecipeIngredientDto(
    Guid IngredientId,
    float Quantity,
    Unit Measurement);