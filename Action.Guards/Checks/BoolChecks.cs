using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Guards.Checks
{
    /// <summary>
    /// 
    /// </summary>
    public class BoolChecks
    {
        /// <summary>
        /// Determines whether the specified value is true.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>
        ///   <c>true</c> if the specified value is true; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTrue(bool value)
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified value is false.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>
        ///   <c>true</c> if the specified value is false; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFalse(bool value)
        {
            return !value;
        }
    }
}
