namespace ArgumentContracts
{
    using System.Collections.Generic;

    using ArgumentContracts.Core.Interfaces;
    using ArgumentContracts.Validators;

    /// <summary>
    /// Singleton class for argument validators
    /// </summary>
    public class ArgumentValidators
    {
        /// <summary>
        /// Gets or sets the validators.
        /// </summary>
        /// <value>
        /// The validators.
        /// </value>
        private static readonly ArgumentValidatorCollection Singleton = new ArgumentValidatorCollection();

        /// <summary>
        /// Prevents a default instance of the <see cref="ArgumentValidators" /> class from being created.
        /// </summary>
        private ArgumentValidators()
        {
        }

        /// <summary>
        /// Gets the argument validators.
        /// </summary>
        /// <value>
        /// The argument validators.
        /// </value>
        public static ArgumentValidatorCollection Instance
        {
            get
            {
                return Singleton;
            }
        } 
    }
}