using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects;

public sealed class IngredientQuantity : ValueObject
{
    public float Value { get; private set; }
    private IngredientQuantity(float value)
    {
        Value = value;
    }
    public static Result<IngredientQuantity> Craete(float value)
    {
        //Add Validation

        return Result.Success(new IngredientQuantity(value));
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

}
