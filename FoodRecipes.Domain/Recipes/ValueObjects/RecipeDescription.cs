using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

public sealed class RecipeDescription : ValueObject
{
    private const int MaxLength = 500;

    private RecipeDescription(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static Result<RecipeDescription> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RecipeDescription>(RecipeErrors.DescriptionIsEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeDescription>(RecipeErrors.DescriptionMaxLengthExceeded);
        }

        return new RecipeDescription(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static int GetMaxLength() => MaxLength;
}
