using FoodRecipes.Domain.ValueObjects;

namespace FoodRecipes.Domain.Aggregates.Recipe.DTOs;

public record RecipeStepDto(
    int StepNumber,
    RecipeStepDescription Description);
