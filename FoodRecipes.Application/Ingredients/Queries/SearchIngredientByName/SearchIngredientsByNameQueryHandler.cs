using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.SearchIngredientByName;

// Query handler for searching ingredients by name
internal class SearchIngredientsByNameQueryHandler : IQueryHandler<SearchIngredientsByNameQuery, Result<IEnumerable<Ingredient>>>
{
    private readonly IIngredientRepository _ingredientRepository;

    // Constructor to initialize the ingredient repository
    public SearchIngredientsByNameQueryHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    // Handles the search ingredients by name query
    public async Task<Result<IEnumerable<Ingredient>>> Handle(SearchIngredientsByNameQuery request, CancellationToken cancellationToken)
    {
        // Search for ingredients by name
        var searchResult = await _ingredientRepository.SearchByName(request.Name, cancellationToken);

        // Check if any ingredients were found
        if (searchResult.Count == 0)
            return Result.Failure<IEnumerable<Ingredient>>(IngredientErrors.NoIngredientFound);

        return Result.Success<IEnumerable<Ingredient>>(searchResult);
    }
}
