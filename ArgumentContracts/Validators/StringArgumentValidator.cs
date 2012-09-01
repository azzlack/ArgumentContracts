namespace ArgumentContracts.Validators
{
    using System;

    using ArgumentContracts.Core.Interfaces;

    /// <summary>
    /// Validator for string arguments.
    /// </summary>
    public class StringArgumentValidator : ITypedArgumentValidator<string>
    {
        private bool allowEmptyStrings;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringArgumentValidator" /> class.
        /// </summary>
        /// <param name="allowEmptyStrings">if set to <c>true</c> [allow empty strings].</param>
        public StringArgumentValidator(bool allowEmptyStrings = false)
        {
            this.allowEmptyStrings = allowEmptyStrings;
        }

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