namespace ArgumentContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using ArgumentContracts.Core.Interfaces;
    using ArgumentContracts.Validators;

    /// <summary>
    /// Functions for method argument validation.
    /// </summary>
    public class Argument
    {
        /// <summary>
        /// Gets or sets the validators.
        /// </summary>
        /// <value>
        /// The validators.
        /// </value>
        public static IList<IArgumentValidator> Validators { get; set; }

        /// <summary>
        /// Validates that the argument exists.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="expr">The object.</param>
        /// <param name="callerMethod">The caller method.</param>
        public static void Require<T>(Func<T> expr, [CallerMemberName] string callerMethod = "")
        {
            var validator = GetArgumentValidator<T>();
            var argumentName = GetArgumentName(expr);
            
            if (!validator.Require(expr()))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Gets an argument validator.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <returns>An argument validator for the specified type.</returns>
        private static ITypedArgumentValidator<T> GetArgumentValidator<T>()
        {
            // Find validator that handles this type
            var validator = (ITypedArgumentValidator<T>)Validators.FirstOrDefault(x => x.HandlesTypes.Contains(typeof(T)));

            if (validator != null)
            {
                return validator;
            }

            // Return default validator
            return new DefaultArgumentValidator<T>();
        }

        /// <summary>
        /// Gets the argument name of the expression.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="expr">The expression.</param>
        /// <returns>
        /// The argument name.
        /// </returns>
        private static string GetArgumentName<T>(Func<T> expr)
        {
            // Get IL code behind the delegate
            var methodBody = expr.Method.GetMethodBody();

            if (methodBody != null)
            {
                var il = methodBody.GetILAsByteArray();

                // Bytes 2-6 represent the field handle
                var fieldHandle = BitConverter.ToInt32(il, 2);
            
                // Resolve the handle
                var field = expr.Target.GetType().Module.ResolveField(fieldHandle);

                return field.Name;
            }

            throw new ArgumentException("Could not get argument name for expression.");
        }
    }
}