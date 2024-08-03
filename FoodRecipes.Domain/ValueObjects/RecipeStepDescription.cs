using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects;

public sealed class RecipeStepDescription: ValueObject
{
    private const int MaxLength = 100;

    private RecipeStepDescription(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static Result<RecipeStepDescription> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RecipeStepDescription>(new Error(
                "Error.RecipeStepDescription.Empty",
                "The description is empty"));
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeStepDescription>(new Error(
                "Error.RecipeStepDescription.MaxLengthExceeded",
                $"The description has more than {MaxLength} characters"));
        }

        return new RecipeStepDescription(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
