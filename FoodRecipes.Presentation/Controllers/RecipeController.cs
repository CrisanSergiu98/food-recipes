using FoodRecipes.Application.Recipes.Commands.CreateRecipe;
using FoodRecipes.Application.Recipes.Commands.DeleteRecipe;
using FoodRecipes.Application.Recipes.Commands.UpdateRecipe;
using FoodRecipes.Application.Recipes.Dto;
using FoodRecipes.Application.Recipes.Queries.GetAllRecipes;
using FoodRecipes.Application.Recipes.Queries.GetRecipeById;
using FoodRecipes.Presentation.Abstractions;
using FoodRecipes.Presentation.Contracts.Recipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Controllers;
[Route("api/recipe")]
public class RecipeController : ApiController
{
    public RecipeController(ISender sender) : base(sender)
    {
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetRecipeByIdQuery(id);

        var result = await Sender.Send(query);

        return result.IsSuccess? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllRecipesQuery();

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRecipe(RecipeCreateRequest request)
    {
        var command = new CreateRecipeCommand(
            request.Title,
            request.Description,
            request.Ingredients,
            request.Steps);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
    [HttpPost("update")]
    public async Task<IActionResult> UpdateRecipe(RecipeUpdateRequest request)
    {
        var command = new UpdateRecipeCommand(
            request.Id,
            request.Title,
            request.Description,
            request.Ingredients,
            request.Steps);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteRecipe(RecipeDeleteRequest request)
    {
        var command = new DeleteRecipeCommand(request.Id);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
