using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.UpdateIngredient;

// Command handler for updating an ingredient
internal class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand, Result>
{
    private readonly IIngredientRepository _ingredientRepository;

    // Constructor to initialize the ingredient repository
    public UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    // Handles the update ingredient command
    public async Task<Result> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the ingredient by ID
        var ingredient = await _ingredientRepository.GetById(request.Id, cancellationToken);

        // Check if the ingredient exists
        if (ingredient is null)
            return Result.Failure(IngredientErrors.NotFound);

        // Check if the ingredient name already exists
        bool nameAlreadyExists = await _ingredientRepository.NameExists(request.Name, cancellationToken);

        if (nameAlreadyExists && !(ingredient.Name.Value == request.Name))
            return Result.Failure(IngredientErrors.NameAlreadyExists);

        // Create value object for ingredient name
        var name = IngredientName.Create(request.Name);

        if (name.IsFailure)
            return Result.Failure<Guid>(name.Error);

        // Create value object for ingredient description
        var description = IngredientDescription.Create(request.Description);

        if (description.IsFailure)
            return Result.Failure<Guid>(description.Error);

        // Update the ingredient with new values
        var updateResult = ingredient.UpdateIngredient(name.Value, description.Value);

        if (updateResult.IsFailure)
        {
            return Result.Failure(updateResult.Error);
        }

        // Save the updated ingredient
        await _ingredientRepository.Update(ingredient, cancellationToken);

        return Result.Success();
    }
}
