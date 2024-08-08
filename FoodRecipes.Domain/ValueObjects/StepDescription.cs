using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects;

public sealed class StepDescription : ValueObject
{
    private const int MaxLength = 300;

    private StepDescription(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static Result<StepDescription> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<StepDescription>(new Error(
                "Error.RecipeStepDescription.Empty",
                "The description is empty"));
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<StepDescription>(new Error(
                "Error.RecipeStepDescription.MaxLengthExceeded",
                $"The description has more than {MaxLength} characters"));
        }

        return new StepDescription(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
