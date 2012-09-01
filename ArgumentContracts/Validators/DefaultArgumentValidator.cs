namespace ArgumentContracts.Validators
{
    using System;

    using ArgumentContracts.Interfaces;

    /// <summary>
    /// Default argument validator.
    /// </summary>
    /// <typeparam name="T">The argument type.</typeparam>
    public class DefaultArgumentValidator<T> : ITypedArgumentValidator<T>
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
                return new Type[] { };
            }
        }

        /// <summary>
        /// Required validation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// True if valid. Otherwise false.
        /// </returns>
        public bool Require(T obj)
        {
            var o = obj as object;

            if (o == null)
            {
                return false;
            }

            return true;
        }
    }
}