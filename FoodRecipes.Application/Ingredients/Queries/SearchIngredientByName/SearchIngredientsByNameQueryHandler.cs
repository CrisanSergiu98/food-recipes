using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;
using System.Collections.Generic;

namespace FoodRecipes.Application.Ingredients.Queries.SearchIngredientByName;

internal class SearchIngredientsByNameQueryHandler : IQueryHandler<SearchIngredientsByNameQuery, Result<IEnumerable<Ingredient>>>
{
    private readonly IIngredientRepository _ingredientRepository;

    public SearchIngredientsByNameQueryHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<Result<IEnumerable<Ingredient>>> Handle(SearchIngredientsByNameQuery request, CancellationToken cancellationToken)
    {
        var searchResult = await _ingredientRepository.SearchByName(request.Name, cancellationToken);

        if (searchResult.Count == 0)
            return Result.Failure<IEnumerable<Ingredient>>(IngredientErrors.NoIngredientFound);

        return Result.Success<IEnumerable<Ingredient>>(searchResult);
    }
}
