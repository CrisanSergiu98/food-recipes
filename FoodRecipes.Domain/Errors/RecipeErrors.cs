using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

public static class RecipeErrors
{
    public static readonly Error IngredientNotFound = new Error("Error.Recipe.RecipeIngredientNotFound","This ingredient was not found");
    public static readonly Error StepNotFound = new Error("Error.Recipe.RecipeStepNotFound", "This step was not found");
}
