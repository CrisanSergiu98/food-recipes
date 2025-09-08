using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Users;
using FoodRecipes.Domain.Users.ValueObjects;

namespace FoodRecipes.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User?> GetByEmail(UserEmail email)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> InsertUser(User user)
    {
        throw new NotImplementedException();
    }
}