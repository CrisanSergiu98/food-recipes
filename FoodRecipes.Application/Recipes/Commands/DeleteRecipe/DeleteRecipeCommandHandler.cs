using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.DeleteRecipe;

internal sealed class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand, Result>
{
    private readonly IRecipeRepository _recipeRepository;
    
    public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public async Task<Result> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipeResult = await _recipeRepository.GetById(request.Id, cancellationToken);
        
        if (recipeResult is null)
            return Result.Failure(RecipeErrors.RecipeNotFound);

        await _recipeRepository.Delete(recipeResult, cancellationToken);

        return Result.Success();
    }
}
