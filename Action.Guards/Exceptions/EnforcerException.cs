using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Guards.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    /// <seealso cref="Action.Guards.Exceptions.IEnforcerException" />
    [Serializable]
    public class EnforcerException : ArgumentException, IEnforcerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnforcerException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        public EnforcerException(string message, string paramName) : base(message, paramName) { }
    }
}
