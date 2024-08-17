using FoodRecipes.Application.Ingredients.Commands.CreateIngredient;
using FoodRecipes.Application.Ingredients.Commands.DeleteIngredient;
using FoodRecipes.Application.Ingredients.Commands.UpdateIngredient;
using FoodRecipes.Presentation.Abstractions;
using FoodRecipes.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Controllers;

[Route("api/Ingredient")]
public class IngredientController: ApiController
{
    protected IngredientController(ISender sender) : base(sender)
    {
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateIngredient(IngredientCreationRequest request)
    {
        var command = new CreateIngredientCommand(
            request.Name,
            request.Description);

        var result = await Sender.Send(command);

        return result.IsSuccess? Ok(result): BadRequest(result.Error);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateIngredient(IngredientUpdateRequest request)
    {
        var command = new UpdateIngredientCommand(
            request.Id,
            request.Name,
            request.Description);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteIngredient(IngredientDeletionRequest request)
    {
        var command = new DeleteIngredientCommand(request.Id);

        var result = await Sender.Send(command);

        return result.IsSuccess? Ok(result) : BadRequest(result.Error);
    }
}
