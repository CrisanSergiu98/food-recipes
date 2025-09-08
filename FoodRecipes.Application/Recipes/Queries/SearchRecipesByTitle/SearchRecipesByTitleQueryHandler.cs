using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.SearchRecipesByTitle;

internal class SearchRecipesByTitleQueryHandler : IQueryHandler<SearchRecipesByTitleQuery, Result<IEnumerable<Recipe>>>
{
    private readonly IRecipeRepository _recipeRepository;
    
    public SearchRecipesByTitleQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public async Task<Result<IEnumerable<Recipe>>> Handle(SearchRecipesByTitleQuery request, CancellationToken cancellationToken)
    {
        var searchResult = _recipeRepository.SearchByTitle(request.Title, cancellationToken).Result;
        
        if (searchResult is null)
            return Result.Failure<IEnumerable<Recipe>>(RecipeErrors.NoRecipesFound);

        return Result.Success<IEnumerable<Recipe>>(searchResult);
    }
}
