using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Ingredients;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipes.Persistence.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly ApplicationDbContext _context;

    public IngredientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Ingredients
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<List<Ingredient>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Ingredients
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Ingredient>> SearchByName(string name, CancellationToken cancellationToken)
    {
        return await _context.Ingredients
            .Where(i => EF.Property<string>(i, "Name").Contains(name))
            .ToListAsync(cancellationToken);
    }

    public async Task Insert(Ingredient ingredient, CancellationToken cancellationToken)
    {
        await _context.Ingredients.AddAsync(ingredient, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Ingredient ingredient, CancellationToken cancellationToken)
    {
        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Ingredient ingredient, CancellationToken cancellationToken)
    {
        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync(cancellationToken);
    }    

    public async Task<bool> NameExists(string name, CancellationToken cancellationToken)
    {
        return await _context.Ingredients
            .AnyAsync(i => i.Name.Value == name, cancellationToken);
    }
}
