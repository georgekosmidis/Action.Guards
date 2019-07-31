using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Guards.Checks
{
    /// <summary>
    /// 
    /// </summary>
    public class NumericChecks
    {

        /// <summary>
        /// Ares the equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool AreEqual<T>(T obj1, T obj2) where T : IComparable
        {
            return obj1.CompareTo(obj2) == 0;
        }

        /// <summary>
        /// Determines whether [is greater than] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="than">The than.</param>
        /// <returns>
        ///   <c>true</c> if [is greater than] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsGreaterThan<T>(T value, T than) where T : IComparable
        {
            return value.CompareTo(than) > 0;
        }

        /// <summary>
        /// Determines whether [is smaller than] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="than">The than.</param>
        /// <returns>
        ///   <c>true</c> if [is smaller than] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSmallerThan<T>(T value, T than) where T : IComparable
        {
            return value.CompareTo(than) < 0;
        }

        /// <summary>
        /// Determines whether [is between inclusive] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>
        ///   <c>true</c> if [is between inclusive] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsBetweenInclusive<T>(T value, T from, T to) where T : IComparable
        {
            var resultFrom = value.CompareTo(from);
            var resultTo = value.CompareTo(to);

            return !(resultFrom < 0 || resultTo > 0);
        }

        /// <summary>
        /// Determines whether [is between exclusive] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>
        ///   <c>true</c> if [is between exclusive] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsBetweenExclusive<T>(T value, T from, T to) where T : IComparable
        {
            var resultFrom = value.CompareTo(from);
            var resultTo = value.CompareTo(to);

            return !(resultFrom <= 0 || resultTo >= 0);
        }
    }
}
