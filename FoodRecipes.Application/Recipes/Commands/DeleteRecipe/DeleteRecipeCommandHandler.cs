using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.DeleteRecipe;

internal class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand, Result>
{
    private readonly IRecipeRepository _recipeRepository;

    public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public async Task<Result> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var result = _recipeRepository.Delete(request.Id);

        if(result.IsFailure)
            return Result.Failure(result.Error);

        return Result.Success();
    }
}
