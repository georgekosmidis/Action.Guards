using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Guards.Checks
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectChecks
    {
        /// <summary>
        /// Ares the equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public bool AreEqual<T>(T value1, T value2) where T : IComparable
        {
            return value1.CompareTo(value2) == 0;
        }

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is null; otherwise, <c>false</c>.
        /// </returns>
        public bool IsNull<T>(T value)
        {
            return value == null;
        }

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is null; otherwise, <c>false</c>.
        /// </returns>
        public bool IsNull<T>(T? value) where T : struct
        {
            return value == null;
        }

        /// <summary>
        /// Determines whether the specified value is default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is default; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDefault<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }

        /// <summary>
        /// Determines whether the specified value is defined.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is defined; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDefined<T>(T value) where T : struct
        {
            return Enum.IsDefined(typeof(T), value);
        }


    }
}
