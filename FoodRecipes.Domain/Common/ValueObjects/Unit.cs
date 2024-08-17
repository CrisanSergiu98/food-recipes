using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Recipes.Enums;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Common.ValueObjects;

public class Unit : ValueObject
{
    private Unit(Recipes.Enums.Unit value)
    {
        Value = value;
    }
    public Recipes.Enums.Unit Value { get; private set; }
    public static Result<Unit> Create(string unit)
    {
        if (Enum.TryParse(typeof(Recipes.Enums.Unit), unit, out var measurementValue))
        {
            return Result.Success(new Unit((Recipes.Enums.Unit)measurementValue));
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
