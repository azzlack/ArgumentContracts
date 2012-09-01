namespace ArgumentContracts.Core.Interfaces
{
    using System;

    /// <summary>
    /// Interface for argument validators
    /// </summary>
    public interface IArgumentValidator
    {
        /// <summary>
        /// Gets the argument types the validator handles.
        /// </summary>
        /// <value>
        /// The the argument types the validator handles.
        /// </value>
        Type[] HandlesTypes { get; }
    }
}