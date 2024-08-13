using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

public sealed class StepNumber : ValueObject
{
    private StepNumber(int value)
    {
        Value = value;
    }
    public static Result<StepNumber> Create(int value)
    {
        return Result.Success(new StepNumber(value));
    }
    public int Value { get; private set; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
