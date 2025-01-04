using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging;

// Defines a command in the CQRS pattern.
// A command represents an operation that changes the state of the application.
// This interface is for commands that do not return any response.
public interface ICommand : IBaseCommand, IRequest
{
}

// Defines a command in the CQRS pattern.
// A command represents an operation that changes the state of the application.
// This interface is for commands that return a response of type TResponse.
public interface ICommand<TResponse> : IBaseCommand, IRequest<TResponse>
{
}

// Base interface for all command interfaces in the CQRS pattern.
// All specific command interfaces should inherit from this interface.
// This can be used to enforce a common type or to group all command types together.
public interface IBaseCommand
{
}
