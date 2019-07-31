using System;
using System.Collections.Generic;
using System.Text;
using Action.Guards.Enforcers;

namespace Action.Guards
{
    /// <summary>
    ///  Add the <see cref="EnforcerMiddleware" /> through the <see cref="ApplicationBuilderExtension" /> to automatically handle the exceptions thrown and return a 400 error!
    /// </summary>
    public static class Enforcer
    {
        /// <summary>
        /// Gets the string checks.
        /// </summary>
        /// <value>
        /// The string checks.
        /// </value>
        public static StringEnforcers String { get; } = new StringEnforcers();

        /// <summary>
        /// Gets the bool checks.
        /// </summary>
        /// <value>
        /// The bool checks.
        /// </value>
        public static BoolEnforcers Bool { get; } = new BoolEnforcers();

        /// <summary>
        /// Gets the object checks.
        /// </summary>
        /// <value>
        /// The object checks.
        /// </value>
        public static ObjectEnforcers Object { get; } = new ObjectEnforcers();

        /// <summary>
        /// Gets the numeric checks.
        /// </summary>
        /// <value>
        /// The numeric checks.
        /// </value>
        public static NumericEnforcers Numeric { get; } = new NumericEnforcers();

        /// <summary>
        /// Gets the datetime checks.
        /// </summary>
        /// <value>
        /// The datetime checks.
        /// </value>
        public static NumericEnforcers Datetime { get; } = new NumericEnforcers();

    }
}
