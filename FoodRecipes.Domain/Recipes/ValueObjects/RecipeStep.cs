using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

public sealed class RecipeStep : ValueObject
{
    private const int MaxLength = 300;
    
    public RecipeStep(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }
    
    public static Result<RecipeStep> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RecipeStep>(RecipeErrors.StepDescriptionIsEmpty);
        }
        
        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeStep>(RecipeErrors.StepDescriptionMaxLengthExceeded);
        }

        return new RecipeStep(value);
    }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static int GetMaxLength() => MaxLength;
}
