using FoodRecipes.Application.Recipes.Queries.GetAllUnits;
using FoodRecipes.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Controllers;

[Route("api/metadata")]
public class MetadataController : ApiController
{
    public MetadataController(ISender sender) : base(sender)
    {
    }
    
    [HttpGet("units")]
    public async Task<IActionResult> GetUnits()
    {
        var query = new GetAllUnitsQuery();

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
