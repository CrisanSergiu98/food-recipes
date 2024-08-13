using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

public static class RecipeErrors
{
    private static readonly int RecipeTitleMaxLength = RecipeTitle.GetMaxLength();
    private static readonly float RecipeIngredientQuantityMinValue = IngredientQuantity.GetMinValue();
    private static readonly float RecipeIngredientQuantityMaxValue = IngredientQuantity.GetMaxValue();
    private static readonly int DescriptionMaxLength = RecipeDescription.GetMaxLength();
    private static readonly int StepDescriptionMaxLength = StepDescription.GetMaxLength();

    public static readonly Error IngredientNotFound = new Error(
        "Error.Recipe.RecipeIngredientNotFound",
        "This ingredient was not found");

    public static readonly Error StepNotFound = new Error(
        "Error.Recipe.RecipeStepNotFound", 
        "This step was not found");

    public static readonly Error RecipeIngredientQuanityLessThanMinValue = new Error(
        "Error.RecipeIngredient.QuanityLessThanMinValue",
        $"The quantity cannot be lower than {RecipeIngredientQuantityMinValue}.");

    public static readonly Error RecipeIngredientQuanityHigherThanMaxValue = new Error(
        "Error.RecipeIngredient.QuanityHigherThanMaxValue",
        $"The quantity cannot be higher than {RecipeIngredientQuantityMaxValue}");

    public static readonly Error RecipeTitleMaxLengthExceeded = new Error(
        "Error.Recipe.RecipeTitleMaxLengthExceeded",
        $"The title has more than {RecipeTitleMaxLength} characters");

    public static readonly Error RecipeTitleIsEmpty = new Error(
        "Error.Recipe.RecipeTitleIsEmpty",
        "The title provided is empty)");

    public static readonly Error DescriptionMaxLengthExceeded = new Error(
        "Error.RecipeTitle.MaxLengthExceeded",
        $"The description has more than {DescriptionMaxLength} characters");

    public static readonly Error DescriptionIsEmpty = new Error(
        "Error.Recipe.DescriptionIsEmpty",
        "The description cannot be empty");

    public static readonly Error StepDescriptionMaxLengthExceeded = new Error(
        "Error.RecipeTitle.StepMaxLengthExceeded",
        $"The step description has more than {StepDescriptionMaxLength} characters");

    public static readonly Error StepDescriptionIsEmpty = new Error(
        "Error.Recipe.StepDescriptionIsEmpty",
        "The step description cannot be empty");

    public static readonly Error UnitIsNotValid = new Error(
        "Error.Recipe.UnitIsNotValid",
        "The unit provided is not valid.");
}
