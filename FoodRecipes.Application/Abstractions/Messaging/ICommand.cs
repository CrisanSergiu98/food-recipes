namespace FoodRecipes.Application.Abstractions.Messaging
{
    /// <summary>
    /// Defines a command in the CQRS (Command Query Responsibility Segregation) pattern.
    /// A command represents an operation that modifies the state of the application.
    /// This interface is used for commands that do not return any response.
    /// </summary>
    public interface ICommand : IBaseCommand
    {
    }

    /// <summary>
    /// Defines a command in the CQRS (Command Query Responsibility Segregation) pattern.
    /// A command represents an operation that modifies the state of the application.
    /// This interface is used for commands that return a response of type <typeparamref name="TResponse"/>.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response returned by the command.</typeparam>
    public interface ICommand<TResponse> : IBaseCommand
    {
    }

    /// <summary>
    /// Serves as the base interface for all command interfaces in the CQRS (Command Query Responsibility Segregation) pattern.
    /// All specific command interfaces should inherit from this interface.
    /// This can be used to enforce a common type or to group all command types together.
    /// </summary>
    public interface IBaseCommand
    {
    }
}
