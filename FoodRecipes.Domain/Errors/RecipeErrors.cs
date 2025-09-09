using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

public static class RecipeErrors
{
    private static readonly int RecipeTitleMaxLength = RecipeTitle.GetMaxLength();
    private static readonly float RecipeIngredientQuantityMinValue = IngredientQuantity.GetMinValue();
    private static readonly float RecipeIngredientQuantityMaxValue = IngredientQuantity.GetMaxValue();
    private static readonly int DescriptionMaxLength = RecipeDescription.GetMaxLength();
    private static readonly int StepDescriptionMaxLength = RecipeStep.GetMaxLength();

    public static readonly Error IngredientNotFound = new(
        "Error.Recipe.RecipeIngredientNotFound",
        "Ingredient not found.");

    public static readonly Error IngredientAlreadyExists = new(
        "Error.Recipe.RecipeIngredientAlreadyExists",
        "Ingredient already exists.");

    public static readonly Error StepAlreadyExists = new(
        "Error.Recipe.RecipeStepAlreadyExists",
        "Step already exists.");

    public static readonly Error StepNotFound = new(
        "Error.Recipe.RecipeStepNotFound",
        "Step not found.");

    public static readonly Error RecipeIngredientQuanityLessThanMinValue = new(
        "Error.RecipeIngredient.QuanityLessThanMinValue",
        $"Quantity is less than {RecipeIngredientQuantityMinValue}.");

    public static readonly Error RecipeIngredientQuanityHigherThanMaxValue = new(
        "Error.RecipeIngredient.QuanityHigherThanMaxValue",
        $"Quantity is more than {RecipeIngredientQuantityMaxValue}.");

    public static readonly Error RecipeTitleMaxLengthExceeded = new(
        "Error.Recipe.RecipeTitleMaxLengthExceeded",
        $"Title has more than {RecipeTitleMaxLength} characters.");

    public static readonly Error RecipeTitleIsEmpty = new(
        "Error.Recipe.RecipeTitleIsEmpty",
        "Title is empty.");

    public static readonly Error DescriptionMaxLengthExceeded = new(
        "Error.RecipeTitle.MaxLengthExceeded",
        $"Description has more than {DescriptionMaxLength} characters.");

    public static readonly Error DescriptionIsEmpty = new(
        "Error.Recipe.DescriptionIsEmpty",
        "Description is empty.");

    public static readonly Error StepDescriptionMaxLengthExceeded = new(
        "Error.RecipeTitle.StepMaxLengthExceeded",
        $"Step description has more than {StepDescriptionMaxLength} characters.");

    public static readonly Error StepDescriptionIsEmpty = new(
        "Error.Recipe.StepDescriptionIsEmpty",
        "Step description is empty.");

    public static readonly Error UnitIsNotValid = new(
        "Error.Recipe.UnitIsNotValid",
        "Unit is not valid.");

    public static readonly Error TitleAlreadyExists = new(
        "Error.Recipe.TitleAlreadyExists",
        "Title already exists.");

    public static readonly Error RecipeNotFound = new(
        "Error.Recipe.RecipeNotFound",
        "Recipe not found.");

    public static readonly Error NoRecipesFound = new(
        "Error.Recipe.NoRecipesFound",
        "No recipes found.");
}
