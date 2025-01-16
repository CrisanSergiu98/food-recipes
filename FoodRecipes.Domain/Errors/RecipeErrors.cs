using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

// Static class for defining recipe-related errors
public static class RecipeErrors
{
    private static readonly int RecipeTitleMaxLength = RecipeTitle.GetMaxLength();
    private static readonly float RecipeIngredientQuantityMinValue = IngredientQuantity.GetMinValue();
    private static readonly float RecipeIngredientQuantityMaxValue = IngredientQuantity.GetMaxValue();
    private static readonly int DescriptionMaxLength = RecipeDescription.GetMaxLength();
    private static readonly int StepDescriptionMaxLength = RecipeStep.GetMaxLength();

    // Error for ingredient not being found
    public static readonly Error IngredientNotFound = new Error(
        "Error.Recipe.RecipeIngredientNotFound",
        "Ingredient not found.");

    // Error for ingredient already existing
    public static readonly Error IngredientAlreadyExists = new Error(
        "Error.Recipe.RecipeIngredientAlreadyExists",
        "Ingredient already exists.");

    // Error for step already existing
    public static readonly Error StepAlreadyExists = new Error(
        "Error.Recipe.RecipeStepAlreadyExists",
        "Step already exists.");

    // Error for step not being found
    public static readonly Error StepNotFound = new Error(
        "Error.Recipe.RecipeStepNotFound",
        "Step not found.");

    // Error for ingredient quantity being less than the minimum value
    public static readonly Error RecipeIngredientQuanityLessThanMinValue = new Error(
        "Error.RecipeIngredient.QuanityLessThanMinValue",
        $"Quantity is less than {RecipeIngredientQuantityMinValue}.");

    // Error for ingredient quantity exceeding the maximum value
    public static readonly Error RecipeIngredientQuanityHigherThanMaxValue = new Error(
        "Error.RecipeIngredient.QuanityHigherThanMaxValue",
        $"Quantity is more than {RecipeIngredientQuantityMaxValue}.");

    // Error for recipe title exceeding the maximum length
    public static readonly Error RecipeTitleMaxLengthExceeded = new Error(
        "Error.Recipe.RecipeTitleMaxLengthExceeded",
        $"Title has more than {RecipeTitleMaxLength} characters.");

    // Error for recipe title being empty
    public static readonly Error RecipeTitleIsEmpty = new Error(
        "Error.Recipe.RecipeTitleIsEmpty",
        "Title is empty.");

    // Error for description exceeding the maximum length
    public static readonly Error DescriptionMaxLengthExceeded = new Error(
        "Error.RecipeTitle.MaxLengthExceeded",
        $"Description has more than {DescriptionMaxLength} characters.");

    // Error for description being empty
    public static readonly Error DescriptionIsEmpty = new Error(
        "Error.Recipe.DescriptionIsEmpty",
        "Description is empty.");

    // Error for step description exceeding the maximum length
    public static readonly Error StepDescriptionMaxLengthExceeded = new Error(
        "Error.RecipeTitle.StepMaxLengthExceeded",
        $"Step description has more than {StepDescriptionMaxLength} characters.");

    // Error for step description being empty
    public static readonly Error StepDescriptionIsEmpty = new Error(
        "Error.Recipe.StepDescriptionIsEmpty",
        "Step description is empty.");

    // Error for unit not being valid
    public static readonly Error UnitIsNotValid = new Error(
        "Error.Recipe.UnitIsNotValid",
        "Unit is not valid.");

    // Error for title already existing
    public static readonly Error TitleAlreadyExists = new Error(
        "Error.Recipe.TitleAlreadyExists",
        "Title already exists.");

    // Error for recipe not being found
    public static readonly Error RecipeNotFound = new Error(
        "Error.Recipe.RecipeNotFound",
        "Recipe not found.");

    // Error for no recipes being found
    public static readonly Error NoRecipesFound = new Error(
        "Error.Recipe.NoRecipesFound",
        "No recipes found.");
}
