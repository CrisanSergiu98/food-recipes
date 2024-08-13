using FoodRecipes.Domain.Recipes.ValueObjects;

namespace FoodRecipes.Domain.Recipes.DTOs;

public record RecipeStepDto(
    StepNumber StepNumber,
    StepDescription Description);
