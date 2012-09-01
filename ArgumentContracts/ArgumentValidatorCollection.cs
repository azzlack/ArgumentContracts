namespace ArgumentContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArgumentContracts.Core.Interfaces;
    using ArgumentContracts.Validators;

    /// <summary>
    /// A collection of IArgumentValidator implementations.
    /// </summary>
    public class ArgumentValidatorCollection : List<IArgumentValidator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentValidatorCollection" /> class.
        /// </summary>
        public ArgumentValidatorCollection()
        {
            // Add default validators
            base.Add(new StringArgumentValidator());
        }

        /// <summary>
        /// Adds the specified validator.
        /// </summary>
        /// <param name="validator">The validator.</param>
        public new void Add(IArgumentValidator validator)
        {
            if (this.Any(x => x.GetType() == validator.GetType()))
            {
                throw new ArgumentException(string.Format("A validator of type '{0}' already exist. Please use Replace() instead.", validator.GetType().FullName));
            }

            base.Add(validator);
        }

        /// <summary>
        /// Replaces an old argument validator with a new one.
        /// </summary>
        /// <param name="oldValidatorType">The old argument validator type.</param>
        /// <param name="newValidator">The new argument validator.</param>
        public void Replace(Type oldValidatorType, IArgumentValidator newValidator)
        {
            if (this.All(x => x.GetType() != oldValidatorType))
            {
                throw new ArgumentException(string.Format("No validators of type '{0}' exist. Please use Add() instead.", oldValidatorType.FullName));
            }

            // Find old validator
            var i = this.FindIndex(x => x.GetType() == oldValidatorType);

            // Add new one
            this[i] = newValidator;
        } 
    }
}