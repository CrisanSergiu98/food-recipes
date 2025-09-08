using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Recipes;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipes.Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly ApplicationDbContext _context;

    public RecipeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<List<Recipe>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Recipe>> SearchByTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .Where(r => r.Title.Value.Contains(title, StringComparison.OrdinalIgnoreCase))
            .ToListAsync(cancellationToken);
    }

    public async Task Insert(Recipe recipe, CancellationToken cancellationToken)
    {
        await _context.Recipes.AddAsync(recipe, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Recipe recipe, CancellationToken cancellationToken)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Recipe recipe, CancellationToken cancellationToken)
    {
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> TitleExists(string title, CancellationToken cancellationToken)
    {
        return await _context.Recipes
            .AnyAsync(r => r.Title.Value == title, cancellationToken);
    }
}
