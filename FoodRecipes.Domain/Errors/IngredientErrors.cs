using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

public static class IngredientErrors
{
    private static readonly int NameMaxLength = IngredientName.GetMaxLength();
    private static readonly int DescriptionMaxLength = IngredientDescription.GetMaxLength();

    public static Error NameMaxLengthExceeded = new Error(
        "Error.Ingredient.NameMaxLengthExceeded",
        $"The name has to be shorter than {NameMaxLength}.");

    public static Error NameIsEmpty = new Error(
        "Error.Ingredient.NameIsEmpty",
        "The name cannot be empty");

    public static Error DescriptionMaxLengthExceeded = new Error(
        "Error.Ingredient.DescriptionMaxLengthExceeded",
        $"The description has to be shorter than {DescriptionMaxLength}.");

    public static Error DescriptionIsEmpty = new Error(
        "Error.Ingredient.DescriptionIsEmpty",
        "The description cannot be empty");

    public static Error NotFound = new Error(
        "Error.Ingredient",
        "This ingredient cannot be found");
}
