using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetAllRecipes;

internal class GetAllRecipesQueryHandler : IQueryHandler<GetAllRecipesQuery, Result<List<Recipe>>>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetAllRecipesQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public async Task<Result<List<Recipe>>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
    {
        var result = _recipeRepository.GetAll(cancellationToken);

        if (result is null)
            return Result.Failure<List<Recipe>>(new Error("", ""));

        return Result.Success<List<Recipe>>(result.Result);
    }
}
