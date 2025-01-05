using FoodRecipes.Application.Ingredients.Commands.CreateIngredient;
using FoodRecipes.Application.Ingredients.Commands.DeleteIngredient;
using FoodRecipes.Application.Ingredients.Commands.UpdateIngredient;
using FoodRecipes.Application.Ingredients.Queries.GetAllIngredients;
using FoodRecipes.Application.Ingredients.Queries.GetIngredient;
using FoodRecipes.Presentation.Abstractions;
using FoodRecipes.Presentation.Contracts.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Controllers;

[Route("api/ingredient")]
public class IngredientController: ApiController
{
    public IngredientController(ISender sender) : base(sender)
    {
    }

    [HttpPost("getById")]
    public async Task<IActionResult> GetIngredientById(IngredinetGetByIdRequest request)
    {
        var query = new GetIngredientQuery(request.Id);

        var result = await Sender.Send(query);

        return result.IsSuccess? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("getAll")]
    public async Task<IActionResult> GetAllIngredients()
    {
        var query = new GetAllIngredientsQuery();

        var result = await Sender.Send(query);

        return result.IsSuccess? Ok(result) : BadRequest(result.Error);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateIngredient(IngredientCreationRequest request)
    {
        var command = new CreateIngredientCommand(
            request.Name,
            request.Description);

        var result = await Sender.Send(command);

        return result.IsSuccess? Ok(result): BadRequest(result.Error);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateIngredient(IngredientUpdateRequest request)
    {
        var command = new UpdateIngredientCommand(
            request.Id,
            request.Name,
            request.Description);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteIngredient(IngredientDeletionRequest request)
    {
        var command = new DeleteIngredientCommand(request.Id);

        var result = await Sender.Send(command);

        return result.IsSuccess? Ok(result) : BadRequest(result.Error);
    }
}
