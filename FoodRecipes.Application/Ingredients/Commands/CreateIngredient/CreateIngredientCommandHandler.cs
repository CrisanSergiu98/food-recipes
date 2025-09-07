using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.CreateIngredient;

// Command handler for creating a new ingredient
internal class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand, Result<Guid>>
{
    private readonly IIngredientRepository _ingredientRepository;

    // Constructor to initialize the ingredient repository
    public CreateIngredientCommandHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    // Handles the create ingredient command
    public async Task<Result<Guid>> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        // Check if the ingredient name already exists
        var nameResult = _ingredientRepository.NameExists(request.Name, cancellationToken);

        if (nameResult.Result)
            return Result.Failure<Guid>(IngredientErrors.NameAlreadyExists);

        // Create value object for ingredient name
        var name = IngredientName.Create(request.Name);

        if (name.IsFailure)
            return Result.Failure<Guid>(name.Error);

        // Create value object for ingredient description
        var description = IngredientDescription.Create(request.Description);

        if (description.IsFailure)
            return Result.Failure<Guid>(description.Error);

        // Create the ingredient with new values
        var ingredient = Ingredient.Create(
            Guid.NewGuid(),
            name.Value,
            description.Value);

        // Save the new ingredient
        await _ingredientRepository.Insert(ingredient.Value, cancellationToken);

        return Result.Success<Guid>(ingredient.Value.Id);
    }
}
