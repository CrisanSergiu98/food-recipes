using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

// Value object for a recipe title
public sealed class RecipeTitle : ValueObject
{
    private static int MaxLength = 100;

    // Private constructor to initialize the recipe title
    public RecipeTitle(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    // Factory method to create a new recipe title
    public static Result<RecipeTitle> Create(string value)
    {
        // Check if the title is empty
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RecipeTitle>(RecipeErrors.RecipeTitleIsEmpty);
        }

        // Check if the title exceeds the maximum length
        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeTitle>(RecipeErrors.RecipeTitleMaxLengthExceeded);
        }

        return new RecipeTitle(value);
    }

    // Get the maximum length of the recipe title
    public static int GetMaxLength() => MaxLength;

    // Get the atomic values of the recipe title
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
