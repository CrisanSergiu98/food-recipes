using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetAllRecipes;

// Query handler for getting all recipes
internal class GetAllRecipesQueryHandler : IQueryHandler<GetAllRecipesQuery, Result<List<Recipe>>>
{
    private readonly IRecipeRepository _recipeRepository;

    // Constructor to initialize the recipe repository
    public GetAllRecipesQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    // Handles the get all recipes query
    public async Task<Result<List<Recipe>>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all recipes
        var result = _recipeRepository.GetAll(cancellationToken);

        // Check if any recipes were found
        if (result is null)
            return Result.Failure<List<Recipe>>(RecipeErrors.NoRecipesFound);

        return Result.Success(result.Result);
    }
}
