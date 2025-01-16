using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.DeleteRecipe;

// Command handler for deleting a recipe
internal sealed class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand, Result>
{
    private readonly IRecipeRepository _recipeRepository;

    // Constructor to initialize the recipe repository
    public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    // Handles the delete recipe command
    public async Task<Result> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the recipe by ID
        var recipeResult = await _recipeRepository.GetById(request.Id);

        // Check if the recipe exists
        if (recipeResult is null)
            return Result.Failure(RecipeErrors.RecipeNotFound);

        // Delete the recipe
        _recipeRepository.Delete(recipeResult);

        return Result.Success();
    }
}
