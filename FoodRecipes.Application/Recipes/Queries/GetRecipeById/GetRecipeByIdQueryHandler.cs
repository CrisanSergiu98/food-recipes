using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetRecipeById;

internal sealed class GetRecipeByIdQueryHandler : IQueryHandler<GetRecipeByIdQuery, Result<Recipe>>
{
    private readonly IRecipeRepository _recipeRepository;
    public GetRecipeByIdQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public async Task<Result<Recipe>> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var recipeResult = _recipeRepository.GetById(request.Id);

        if (recipeResult is null)
            return Result.Failure<Recipe>(RecipeErrors.RecipeNotFound);

        return Result.Success<Recipe>(recipeResult.Result);
    }
}
