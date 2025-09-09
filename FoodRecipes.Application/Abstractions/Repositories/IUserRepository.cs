using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Users;
using FoodRecipes.Domain.Users.ValueObjects;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetById(Guid id, CancellationToken cancellationToken);
    Task<User?> GetByEmail(UserEmail email, CancellationToken cancellationToken);
    Task Insert(User user, CancellationToken cancellationToken);
}