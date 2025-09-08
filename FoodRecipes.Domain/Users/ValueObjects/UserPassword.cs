using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Users.ValueObjects;

public class UserPassword : ValueObject
{
    public UserPassword(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<UserPassword> Create(string value)
    {
        return new UserPassword(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}