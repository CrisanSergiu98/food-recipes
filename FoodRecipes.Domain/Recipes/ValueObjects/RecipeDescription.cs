using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

// Value object for a recipe description
public sealed class RecipeDescription : ValueObject
{
    private const int MaxLength = 500;

    // Private constructor to initialize the recipe description
    public RecipeDescription(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    // Factory method to create a new recipe description
    public static Result<RecipeDescription> Create(string value)
    {
        // Check if the description is empty
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RecipeDescription>(RecipeErrors.DescriptionIsEmpty);
        }

        // Check if the description exceeds the maximum length
        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeDescription>(RecipeErrors.DescriptionMaxLengthExceeded);
        }

        return new RecipeDescription(value);
    }

    // Get the atomic values of the recipe description
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    // Get the maximum length of the recipe description
    public static int GetMaxLength() => MaxLength;
}
