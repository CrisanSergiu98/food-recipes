using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging;

// A query retrieves data without modifying the application's state.
public interface IQuery<TResponse> : IRequest<TResponse>
{
}
