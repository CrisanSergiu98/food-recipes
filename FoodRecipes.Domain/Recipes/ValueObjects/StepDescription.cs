using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

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
            return Result.Failure<StepDescription>(RecipeErrors.StepDescriptionIsEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<StepDescription>(RecipeErrors.StepDescriptionMaxLengthExceeded);
        }

        return new StepDescription(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static int GetMaxLength() => MaxLength;
}
