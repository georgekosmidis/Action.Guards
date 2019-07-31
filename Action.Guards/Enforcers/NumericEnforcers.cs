using System;
using System.Collections.Generic;
using System.Text;
using Action.Guards.Exceptions;

namespace Action.Guards.Enforcers
{
    /// <summary>
    /// 
    /// </summary>
    public class NumericEnforcers
    {
        /// <summary>
        /// Determines whether the <paramref name="value"/> is greater than the <paramref name="than"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="than">The than.</param>
        /// <param name="value">The variable.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="EnforcerException">
        /// '" + message + "' must be greater than " + than + "!
        /// </exception>
        public void IsGreaterThan<T>(T value, T than, string message) where T : IComparable
        {
            if (!Check.Numeric.IsGreaterThan(value, than))
                throw new EnforcerException("'" + message + "' must be greater than " + than + "!", message);
        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> is greater or equal to the <paramref name="than"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="than">The than.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="GuardNumericException">
        /// '" + message + "' must be greater or equal to " + than + "!
        /// </exception>
        public void IsGreaterOrEqualThan<T>(T value, T than, string message) where T : IComparable
        {
            if (!Check.Numeric.IsGreaterThan(value, than) && !Check.Numeric.AreEqual(than, value))
                throw new EnforcerException("'" + message + "' must be greater or equal to " + than + "!", message);
        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> is smaller than the <paramref name="than"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="than">The than.</param>
        /// <param name="value">The variable.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="EnforcerException">
        /// '" + message + "' must be smaller than " + than + "!
        /// </exception>
        public void IsSmallerThan<T>(T value, T than, string message) where T : IComparable
        {
            if (!Check.Numeric.IsSmallerThan(value, than))
                throw new EnforcerException("'" + message + "' must be smaller than " + than + "!", message);

        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> is smaller or equal than the <paramref name="than"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="than">The than.</param>
        /// <param name="value">The variable.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="GuardNumericException">
        /// '" + message + "' must be smaller or equal to " + than + "!
        /// </exception>
        public void IsSmallerOrEqualThan<T>(T value, T than, string message) where T : IComparable
        {
            if (!Check.Numeric.IsSmallerThan(value, than) && !Check.Numeric.AreEqual(value, than))
                throw new EnforcerException("'" + message + "' must be smaller or equal to " + than + "!", message);

        }


        /// <summary>
        /// Determines whether the <paramref name="value"/> is between <paramref name="from"/> and <paramref name="to"/>, including those limits
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="value">The variable.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="GuardNumericException">
        /// '" + message + "' must be between (including) " + from + " and " + to + "!
        /// </exception>
        public void IsBetweenInclusive<T>(T value, T from, T to, string message) where T : IComparable
        {
            if (Check.Numeric.IsGreaterThan(value, to) || Check.Numeric.IsSmallerThan(value, from))
                throw new EnforcerException("'" + message + "' must be between " + from + " and " + to + ", including those limits !", message);

        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> is between <paramref name="from"/> and <paramref name="to"/>, excluding those limits
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="value">The variable.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="EnforcerException">
        /// '" + message + "' must be between (excluding) " + from + " and " + to + "!
        /// </exception>
        public void IsBetweenExclusive<T>(T value, T from, T to, string message) where T : IComparable
        {
            if (Check.Numeric.IsGreaterThan(value, to) || Check.Numeric.AreEqual(value, to) || Check.Numeric.IsSmallerThan(value, from) || Check.Numeric.AreEqual(value, from))
                throw new EnforcerException("'" + message + "' must be between " + from + " and " + to + ", including those limits !", message);
        }
    }
}
