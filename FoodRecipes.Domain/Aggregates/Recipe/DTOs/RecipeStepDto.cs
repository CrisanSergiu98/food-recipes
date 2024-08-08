using FoodRecipes.Domain.ValueObjects;

namespace FoodRecipes.Domain.Aggregates.Recipe.DTOs;

public record RecipeStepDto(
    StepNumber StepNumber,
    StepDescription Description);
