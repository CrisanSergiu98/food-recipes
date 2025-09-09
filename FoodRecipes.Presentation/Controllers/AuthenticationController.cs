using FoodRecipes.Application.Users.Commands.Register;
using FoodRecipes.Application.Users.Queries.Login;
using FoodRecipes.Presentation.Abstractions;
using FoodRecipes.Presentation.Users;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Controllers;

[Route("api/authentication")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender) : base(sender)
    {
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);

        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error); ;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(request.Email, request.Password);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}