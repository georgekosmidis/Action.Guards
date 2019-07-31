using Action.Guards.Exceptions;

namespace Action.Guards.Enforcers
{
    /// <summary>
    /// 
    /// </summary>
    public class BoolEnforcers
    {

        /// <summary>
        /// Determines whether the specified value is true.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="message">The message.</param>
        /// <exception cref="EnforcerException">'" + message + "' must be true!</exception>
        public void IsTrue(bool value, string message)
        {
            if (!Check.Bool.IsTrue(value))
                throw new EnforcerException("'" + message + "' must be true!", message);

        }

        /// <summary>
        /// Determines whether the specified value is false.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' must be true!</exception>
        public void IsFalse(bool value, string message)
        {
            if (!Check.Bool.IsFalse(value))
                throw new EnforcerException("'" + message + "' must be false!", message);

        }
    }
}
