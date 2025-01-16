using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.SearchRecipesByTitle;

// Query handler for searching recipes by title
internal class SearchRecipesByTitleQueryHandler : IQueryHandler<SearchRecipesByTitleQuery, Result<IEnumerable<Recipe>>>
{
    private readonly IRecipeRepository _recipeRepository;

    // Constructor to initialize the recipe repository
    public SearchRecipesByTitleQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    // Handles the search recipes by title query
    public async Task<Result<IEnumerable<Recipe>>> Handle(SearchRecipesByTitleQuery request, CancellationToken cancellationToken)
    {
        // Search for recipes by title
        var searchResult = _recipeRepository.SearchByTitle(request.Title, cancellationToken).Result;

        // Check if any recipes were found
        if (searchResult is null)
            return Result.Failure<IEnumerable<Recipe>>(RecipeErrors.NoRecipesFound);

        return Result.Success<IEnumerable<Recipe>>(searchResult);
    }
}
