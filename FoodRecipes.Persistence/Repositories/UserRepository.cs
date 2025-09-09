using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Users;
using FoodRecipes.Domain.Users.ValueObjects;

using Microsoft.EntityFrameworkCore;

namespace FoodRecipes.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
    public async Task<User?> GetByEmail(UserEmail email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Email.Value == email.Value, cancellationToken);
    }

    public async Task Insert(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}