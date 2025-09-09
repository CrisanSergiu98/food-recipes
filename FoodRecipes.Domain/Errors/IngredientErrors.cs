using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

public static class IngredientErrors
{
    private static readonly int NameMaxLength = IngredientName.GetMaxLength();
    private static readonly int DescriptionMaxLength = IngredientDescription.GetMaxLength();

    public static Error NameMaxLengthExceeded = new(
        "Error.Ingredient.NameMaxLengthExceeded",
        $"Name longer than {NameMaxLength} characters.");

    public static Error NameIsEmpty = new(
        "Error.Ingredient.NameIsEmpty",
        "Name is empty.");

    public static Error DescriptionMaxLengthExceeded = new(
        "Error.Ingredient.DescriptionMaxLengthExceeded",
        $"Description longer than {DescriptionMaxLength} characters.");

    public static Error DescriptionIsEmpty = new(
        "Error.Ingredient.DescriptionIsEmpty",
        "Description is empty.");

    public static Error NotFound = new(
        "Error.Ingredient",
        "Ingredient not found.");

    public static Error NameAlreadyExists = new(
        "Error.Ingredient",
        "Ingredient name already used.");

    public static Error NoIngredientFound = new(
        "Error.Ingredient",
        "No Ingredient found.");
}
