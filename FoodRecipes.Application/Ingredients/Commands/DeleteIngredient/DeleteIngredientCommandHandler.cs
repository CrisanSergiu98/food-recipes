using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.DeleteIngredient;

internal class DeleteIngredientCommandHandler : ICommandHandler<DeleteIngredientCommand, Result>
{
    private readonly IIngredientRepository _ingredientRepository;
    public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<Result> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        var result = _ingredientRepository.Delete(request.Id);

        return result;
    }
}
