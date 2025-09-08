using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Users.ValueObjects;

namespace FoodRecipes.Domain.Users;

public class User : AggregateRoot
{
    public User() : base(Guid.Empty)
    {
        // Required for EF Core
    }

    private User(
        Guid id,
        UserEmail email,
        UserPassword password
        ) : base(id)
    {
        Email = email;
        Password = password;
    }

    public UserEmail Email { get; private set; }
    public UserPassword Password { get; private set; }

    public static Result<User> Create(
        Guid id,
        UserEmail email,
        UserPassword password)
    {
        return new User(
            id,
            email,
            password);
    }
}