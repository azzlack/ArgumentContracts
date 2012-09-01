namespace ArgumentContracts.Validators
{
    using System;

    using ArgumentContracts.Core.Interfaces;

    /// <summary>
    /// Validator for string arguments.
    /// </summary>
    public class StringArgumentValidator : ITypedArgumentValidator<string>
    {
        /// <summary>
        /// Gets the argument types the validator handles.
        /// </summary>
        /// <value>
        /// The the argument types the validator handles.
        /// </value>
        public Type[] HandlesTypes
        {
            get
            {
                return new[] { typeof(string) };
            }
        }

        /// <summary>
        /// Required validation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>True if valid. Otherwise false.</returns>
        public bool Require(string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return false;
            }

            return true;
        }
    }
}