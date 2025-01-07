using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
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
        var searchResult = _ingredientRepository.SearchByName(request.Name, cancellationToken).Result;

        if (searchResult is null)
            return Result.Failure<IEnumerable<Ingredient>>(new Error("", ""));

        return Result.Success<IEnumerable<Ingredient>>(searchResult);
    }
}
