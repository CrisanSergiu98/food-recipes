using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Ingredients.ValueObjects;

// Value object for an ingredient description
public sealed class IngredientDescription : ValueObject
{
    private const int MaxLength = 200;

    // Private constructor to initialize the ingredient description
    public IngredientDescription(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    // Factory method to create a new ingredient description
    public static Result<IngredientDescription> Create(string value)
    {
        // Check if the description is empty
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<IngredientDescription>(IngredientErrors.DescriptionIsEmpty);
        }

        // Check if the description exceeds the maximum length
        if (value.Length > MaxLength)
        {
            return Result.Failure<IngredientDescription>(IngredientErrors.DescriptionMaxLengthExceeded);
        }

        return new IngredientDescription(value);
    }

    // Get the atomic values of the ingredient description
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    // Get the maximum length of the ingredient description
    public static int GetMaxLength() => MaxLength;
}
