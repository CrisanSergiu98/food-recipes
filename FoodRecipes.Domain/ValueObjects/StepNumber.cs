using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects;

public sealed class StepNumber : ValueObject
{
    private StepNumber(int value)
    {
        Value = value;
    }
    public static Result<StepNumber> Create(int value)
    {
        //Add Validation

        return Result.Success(new StepNumber(value));
    }
    public int Value { get; private set; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
