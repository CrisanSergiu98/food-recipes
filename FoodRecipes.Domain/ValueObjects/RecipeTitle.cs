using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects;

public sealed class RecipeTitle : ValueObject
{
    private const int MaxLength = 100;

    private RecipeTitle(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static Result<RecipeTitle> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RecipeTitle>(new Error(
                "Error.RecipeTitle.Empty",
                "The title is empty"));
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeTitle>(new Error(
                "Error.RecipeTitle.MaxLengthExceeded",
                $"The title has more than {MaxLength} characters"));
        }

        return new RecipeTitle(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
