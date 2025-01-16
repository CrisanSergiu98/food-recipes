using FoodRecipes.Application.Dto;
using FoodRecipes.Application.Recipes.Commands.CreateRecipe;
using FoodRecipes.Application.Recipes.Commands.DeleteRecipe;
using FoodRecipes.Application.Recipes.Commands.UpdateRecipe;
using FoodRecipes.Application.Recipes.Queries.GetAllRecipes;
using FoodRecipes.Application.Recipes.Queries.GetRecipeById;
using FoodRecipes.Application.Recipes.Queries.SearchRecipesByTitle;
using FoodRecipes.Presentation.Abstractions;
using FoodRecipes.Presentation.Contracts.Recipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Controllers;

[Route("api/recipes")]
public class RecipeController : ApiController
{
    // Constructor to initialize the sender
    public RecipeController(ISender sender) : base(sender)
    {
    }

    // Endpoint to get a recipe by its ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetRecipeByIdQuery(id);

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(DtoConverter.RecipeDtoConvert(result.Value)) : BadRequest(result.Error);
    }

    // Endpoint to get all recipes
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllRecipesQuery();

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(DtoConverter.RecipesDtoConvert(result.Value)) : BadRequest(result.Error);
    }

    // Endpoint to search recipes by title
    [HttpGet("search")]
    public async Task<IActionResult> SearchRecipes([FromQuery] string name)
    {
        var query = new SearchRecipesByTitleQuery(name);

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(DtoConverter.RecipesDtoConvert(result.Value)) : BadRequest(result.Error);
    }

    // Endpoint to create a new recipe
    [HttpPost]
    public async Task<IActionResult> CreateRecipe(RecipeCreateRequest request)
    {
        var command = new CreateRecipeCommand(
            request.Title,
            request.Description,
            request.Ingredients,
            request.Steps);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    // Endpoint to update an existing recipe
    [HttpPut]
    public async Task<IActionResult> UpdateRecipe([FromBody] RecipeUpdateRequest request)
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

    // Endpoint to delete a recipe by its ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(Guid id)
    {
        var command = new DeleteRecipeCommand(id);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
