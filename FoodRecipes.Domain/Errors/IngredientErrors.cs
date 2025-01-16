using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

// Static class for defining ingredient-related errors
public static class IngredientErrors
{
    private static readonly int NameMaxLength = IngredientName.GetMaxLength();
    private static readonly int DescriptionMaxLength = IngredientDescription.GetMaxLength();

    // Error for ingredient name exceeding maximum length
    public static Error NameMaxLengthExceeded = new Error(
        "Error.Ingredient.NameMaxLengthExceeded",
        $"Name longer than {NameMaxLength} characters.");

    // Error for ingredient name being empty
    public static Error NameIsEmpty = new Error(
        "Error.Ingredient.NameIsEmpty",
        "Name is empty.");

    // Error for ingredient description exceeding maximum length
    public static Error DescriptionMaxLengthExceeded = new Error(
        "Error.Ingredient.DescriptionMaxLengthExceeded",
        $"Description longer than {DescriptionMaxLength} characters.");

    // Error for ingredient description being empty
    public static Error DescriptionIsEmpty = new Error(
        "Error.Ingredient.DescriptionIsEmpty",
        "Description is empty.");

    // Error for ingredient not being found
    public static Error NotFound = new Error(
        "Error.Ingredient",
        "Ingredient not found.");

    // Error for ingredient name already being used
    public static Error NameAlreadyExists = new Error(
        "Error.Ingredient",
        "Ingredient name already used.");

    // Error for no ingredients being found
    public static Error NoIngredientFound = new Error(
        "Error.Ingredient",
        "No Ingredient found.");
}
