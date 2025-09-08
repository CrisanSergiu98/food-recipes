using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Users.ValueObjects;

public class UserEmail : ValueObject
{
    private static int MaxLength = 100;
    public UserEmail(string value)
    {
        Value = value;
    }
    public string Value { get; private set; }
    public Result<UserEmail> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<UserEmail>(UserErrors.UserEmailIsEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<UserEmail>(UserErrors.UserEmailMaxLengthExceeded);
        }

        return new UserEmail(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public int GetMaxLength()
    {
        return MaxLength;
    }
}