using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Users;
using FoodRecipes.Domain.Users.ValueObjects;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmail(UserEmail email);
    Task<Guid> InsertUser(User user);
}