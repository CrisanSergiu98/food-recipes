using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Errors;

public static class UserErrors
{
    public static Error UserEmailIsEmpty = new(
        "Error.User.UserEmailIsEmpty",
        "Email provided is empty.");

    public static Error UserEmailMaxLengthExceeded = new(
        "Error.User.UserEmailMaxLengthExceeded",
        "Email provided exceeds the maximum number of characters.");

    public static Error LoginDetailsIncorrect = new(
        "Error.User.LoginDetailsIncorrect",
        "Login details provided are incorrect.");

    public static Error EmailAlreadyUsed = new(
    "Error.User.EmailAlreadyUsed",
    "Email is already being used.");


}