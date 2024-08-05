namespace FoodRecipes.Domain.Shared
{
    /// <summary>
    /// Represents an error with a specific code and message.
    /// This class provides mechanisms for defining and comparing errors in a domain.
    /// </summary>
    public class Error : IEquatable<Error>
    {
        /// <summary>
        /// Represents a default error indicating no error condition.
        /// This is typically used to represent a successful state or a lack of an error.
        /// </summary>
        public static readonly Error None = new Error(string.Empty, string.Empty);

        /// <summary>
        /// Represents an error where a specified value is null.
        /// This is a predefined error instance used to indicate null values in results or operations.
        /// </summary>
        public static readonly Error NullValue = new Error("Error.NullValue", "The specified result value is null");

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class with a specific code and message.
        /// </summary>
        /// <param name="code">A string representing the error code. This code uniquely identifies the type of error.</param>
        /// <param name="message">A string containing the error message that describes the error in more detail.</param>
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets the error code which uniquely identifies the type of error.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the error message which provides a description of the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Implicitly converts an <see cref="Error"/> object to its code as a string.
        /// This operator provides a convenient way to extract the error code from an <see cref="Error"/> instance.
        /// </summary>
        /// <param name="error">The <see cref="Error"/> instance to convert.</param>
        public static implicit operator string(Error error) => error.Code;

        /// <summary>
        /// Determines whether two <see cref="Error"/> instances are equal.
        /// Two errors are considered equal if they have the same error code.
        /// </summary>
        /// <param name="a">The first <see cref="Error"/> instance to compare.</param>
        /// <param name="b">The second <see cref="Error"/> instance to compare.</param>
        /// <returns><c>true</c> if both errors are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Error? a, Error? b)
        {
            // Both are null, hence equal
            if (a is null && b is null)
            {
                return true;
            }

            // One is null and the other is not, hence not equal
            if (a is null || b is null)
            {
                return false;
            }

            // Both are not null, compare their codes
            return a.Code == b.Code;
        }

        /// <summary>
        /// Determines whether two <see cref="Error"/> instances are not equal.
        /// This is the negation of the equality operator.
        /// </summary>
        /// <param name="a">The first <see cref="Error"/> instance to compare.</param>
        /// <param name="b">The second <see cref="Error"/> instance to compare.</param>
        /// <returns><c>true</c> if both errors are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Error? a, Error? b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Error"/> is equal to the current <see cref="Error"/>.
        /// This method provides a type-safe way to compare two <see cref="Error"/> instances.
        /// </summary>
        /// <param name="other">The <see cref="Error"/> to compare with the current <see cref="Error"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Error"/> is equal to the current <see cref="Error"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Error? other)
        {
            // Use the equality operator to compare
            return this == other;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Error"/>.
        /// This method overrides the default <see cref="Object.Equals"/> method to handle <see cref="Error"/> comparisons.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Error"/>.</param>
        /// <returns><c>true</c> if the specified object is equal to the current <see cref="Error"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            // Check if the object is of type Error and use the Equals method
            return obj is Error error && Equals(error);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// This method generates a hash code for the current <see cref="Error"/> based on its code.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Error"/>.</returns>
        public override int GetHashCode()
        {
            // Hash code based on the error code
            return Code.GetHashCode();
        }
    }
}
