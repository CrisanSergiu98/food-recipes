using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Recipes.Enums;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Common.ValueObjects;

public class Unit : ValueObject
{
    private Unit(Measurement value)
    {
        Value = value;
    }
    public Measurement Value { get; private set; }
    public static Result<Unit> Create(string unit)
    {
        if (Enum.TryParse(typeof(Measurement), unit, out var measurementValue))
        {
            return Result.Success(new Unit((Measurement)measurementValue));
        }
        else
        {
            return Result.Failure<Unit>(RecipeErrors.UnitIsNotValid);
        }
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
