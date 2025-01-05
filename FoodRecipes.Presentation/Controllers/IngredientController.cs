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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredientById(Guid id)
    {
        var query = new GetIngredientQuery(id);

        var result = await Sender.Send(query);

        return result.IsSuccess? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        var query = new GetAllIngredientsQuery();

        var result = await Sender.Send(query);

        return result.IsSuccess? Ok(result) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateIngredient([FromBody] IngredientCreationRequest request)
    {
        var command = new CreateIngredientCommand(
            request.Name,
            request.Description);

        var result = await Sender.Send(command);

        return result.IsSuccess? Ok(result): BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateIngredient([FromBody] IngredientUpdateRequest request)
    {
        var command = new UpdateIngredientCommand(
            request.Id,
            request.Name,
            request.Description);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(Guid id)
    {
        var command = new DeleteIngredientCommand(id);

        var result = await Sender.Send(command);

        return result.IsSuccess? Ok(result) : BadRequest(result.Error);
    }
}
