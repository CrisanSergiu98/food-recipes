using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects;

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
            return Result.Failure<RecipeDescription>(new Error(
                "Error.RecipeDescription.Empty",
                "The description is empty"));
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeDescription>(new Error(
                "Error.RecipeTitle.MaxLengthExceeded",
                $"The description has more than {MaxLength} characters"));
        }

        return new RecipeDescription(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
