using System;
using System.Collections.Generic;
using System.Text;
using Action.Guards.Exceptions;

namespace Action.Guards.Enforcers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ObjectEnforcers
    {
        /// <summary>
        /// Ares the equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' must be equal!</exception>
        public void AreEqual<T>(T obj1, T obj2, string message) where T : IComparable
        {
            if (!Check.Object.AreEqual(obj1, obj2))
                throw new EnforcerException("'" + message + "' must be equal!", message);
        }

        /// <summary>
        /// Ares the not equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' must be equal!</exception>
        public void AreNotEqual<T>(T obj1, T obj2, string message) where T : IComparable
        {
            if (Check.Object.AreEqual(obj1, obj2))
                throw new EnforcerException("'" + message + "' must be equal!", message);

        }

        /// <summary>
        /// Determines whether [is not null or default] [the specified variable].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variable">The variable.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' cannot be null or default!</exception>
        public void IsNotNullOrDefault<T>(T variable, string message)
        {
            if (Check.Object.IsNull(variable) || Check.Object.IsDefault(variable))
                throw new EnforcerException("'" + message + "' cannot be null or default!", message);
        }

        /// <summary>
        /// Determines whether [is null or default] [the specified variable].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variable">The variable.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' must be null or default!</exception>
        public void IsNullOrDefault<T>(T variable, string message)
        {
            if (!Check.Object.IsNull(variable) && !Check.Object.IsDefault(variable))
                throw new EnforcerException("'" + message + "' must be null or default!", message);
        }

        /// <summary>
        /// Determines whether the specified variable is defined.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variable">The variable.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' is not defined!</exception>
        public void IsDefined<T>(T variable, string message) where T : struct
        {
            if (!Check.Object.IsDefined(variable))
                throw new EnforcerException("'" + message + "' is not defined!", message);

        }


        /// <summary>
        /// Determines whether [is not defined] [the specified variable].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variable">The variable.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' is not defined!</exception>
        public void IsNotDefined<T>(T variable, string message) where T : struct
        {
            if (Check.Object.IsDefined(variable))
                throw new EnforcerException("'" + message + "' is not defined!", message);

        }
    }
}
