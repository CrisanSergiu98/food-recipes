using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Presentation.Abstractions;

// Base API controller class
[ApiController]
public class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    // Constructor to initialize the sender
    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}
