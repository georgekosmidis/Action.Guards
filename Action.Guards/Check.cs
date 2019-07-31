using System;
using System.Collections.Generic;
using System.Text;
using Action.Guards.Checks;

namespace Action.Guards
{
    /// <summary>
    /// 
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Gets the object checks.
        /// </summary>
        /// <value>
        /// The object checks.
        /// </value>
        public static ObjectChecks Object { get; } = new ObjectChecks();

        /// <summary>
        /// Gets the bool checks.
        /// </summary>
        /// <value>
        /// The bool checks.
        /// </value>
        public static BoolChecks Bool { get; } = new BoolChecks();

        /// <summary>
        /// Gets the numeric checks.
        /// </summary>
        /// <value>
        /// The numeric checks.
        /// </value>
        public static NumericChecks Numeric { get; } = new NumericChecks();

        /// <summary>
        /// Gets the string checks.
        /// </summary>
        /// <value>
        /// The string checks.
        /// </value>
        public static StringChecks String { get; } = new StringChecks();
    }
}
