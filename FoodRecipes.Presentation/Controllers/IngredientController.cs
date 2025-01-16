using FoodRecipes.Application.Dto;
using FoodRecipes.Application.Ingredients.Commands.CreateIngredient;
using FoodRecipes.Application.Ingredients.Commands.DeleteIngredient;
using FoodRecipes.Application.Ingredients.Commands.UpdateIngredient;
using FoodRecipes.Application.Ingredients.Queries.GetAllIngredients;
using FoodRecipes.Application.Ingredients.Queries.GetIngredient;
using FoodRecipes.Application.Ingredients.Queries.SearchIngredientByName;
using FoodRecipes.Presentation.Abstractions;
using FoodRecipes.Presentation.Contracts.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Controllers;

[Route("api/ingredients")]
public class IngredientController : ApiController
{
    // Constructor to initialize the sender
    public IngredientController(ISender sender) : base(sender)
    {
    }

    // Endpoint to get an ingredient by its ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredientById(Guid id)
    {
        var query = new GetIngredientQuery(id);

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(DtoConverter.IngredientDtoConvert(result.Value)) : BadRequest(result.Error);
    }

    // Endpoint to get all ingredients
    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        var query = new GetAllIngredientsQuery();

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(DtoConverter.IngredientDtoConvert(result.Value)) : BadRequest(result.Error);
    }

    // Endpoint to search ingredients by name
    [HttpGet("search")]
    public async Task<IActionResult> SearchIngredients([FromQuery] string name)
    {
        var query = new SearchIngredientsByNameQuery(name);

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(DtoConverter.IngredientDtoConvert(result.Value)) : BadRequest(result.Error);
    }

    // Endpoint to create a new ingredient
    [HttpPost]
    public async Task<IActionResult> CreateIngredient([FromBody] IngredientCreationRequest request)
    {
        var command = new CreateIngredientCommand(
            request.Name,
            request.Description);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    // Endpoint to update an existing ingredient
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

    // Endpoint to delete an ingredient by its ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(Guid id)
    {
        var command = new DeleteIngredientCommand(id);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
