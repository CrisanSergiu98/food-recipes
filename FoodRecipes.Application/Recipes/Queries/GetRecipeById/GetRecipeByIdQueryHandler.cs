using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetRecipeById;

// Query handler for getting a recipe by ID
internal sealed class GetRecipeByIdQueryHandler : IQueryHandler<GetRecipeByIdQuery, Result<Recipe>>
{
    private readonly IRecipeRepository _recipeRepository;

    // Constructor to initialize the recipe repository
    public GetRecipeByIdQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    // Handles the get recipe by ID query
    public async Task<Result<Recipe>> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        // Retrieve the recipe by ID
        var recipeResult = _recipeRepository.GetById(request.Id);

        // Check if the recipe exists
        if (recipeResult is null)
            return Result.Failure<Recipe>(RecipeErrors.RecipeNotFound);

        return Result.Success<Recipe>(recipeResult.Result);
    }
}
