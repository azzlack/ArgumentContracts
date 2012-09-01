namespace ArgumentContracts.Core.Interfaces
{
    /// <summary>
    /// Interface for argument validators
    /// </summary>
    /// <typeparam name="T">The argument type.</typeparam>
    public interface ITypedArgumentValidator<in T> : IArgumentValidator
    {
        /// <summary>
        /// Required validation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>True if valid. Otherwise false.</returns>
        bool Require(T obj);
    }
}