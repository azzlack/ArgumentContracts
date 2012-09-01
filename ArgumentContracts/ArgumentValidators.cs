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
        private static readonly IList<IArgumentValidator> Singleton = new List<IArgumentValidator>()
            {
                new StringArgumentValidator()
            };

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
        public static IList<IArgumentValidator> Instance
        {
            get
            {
                return Singleton;
            }
        } 
    }
}