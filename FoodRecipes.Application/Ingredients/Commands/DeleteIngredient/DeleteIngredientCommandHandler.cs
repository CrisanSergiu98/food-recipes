using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.DeleteIngredient;

// Command handler for deleting an ingredient
internal class DeleteIngredientCommandHandler : ICommandHandler<DeleteIngredientCommand, Result>
{
    private readonly IIngredientRepository _ingredientRepository;

    // Constructor to initialize the ingredient repository
    public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    // Handles the delete ingredient command
    public async Task<Result> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the ingredient by ID
        var ingredient = await _ingredientRepository.GetById(request.Id, cancellationToken);

        // Check if the ingredient exists
        if ((object)ingredient == null)
            return Result.Failure(IngredientErrors.NotFound);

        // Delete the ingredient
        _ingredientRepository.Delete(ingredient);

        return Result.Success();
    }
}
