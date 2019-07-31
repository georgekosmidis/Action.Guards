using System;
using System.Collections.Generic;
using System.Text;
using Action.Guards.Exceptions;

namespace Action.Guards.Enforcers
{
    /// <summary>
    /// 
    /// </summary>
    public class StringEnforcers
    {

        /// <summary>
        /// Determines whether [is null or empty] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="EnforcerException">'" + message + "' must be null or empty!</exception>
        public void IsNullOrEmpty(string value, string message)
        {
            if (!Check.String.IsNullOrEmpty(value))
                throw new EnforcerException("'" + message + "' must be null or empty!", message);
        }

        /// <summary>
        /// Determines whether [is not null or empty] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' cannot be null or empty!</exception>
        public void IsNotNullOrEmpty(string value, string message)
        {
            if (Check.String.IsNullOrEmpty(value))
                throw new EnforcerException("'" + message + "' cannot be null or empty!", message);
        }

        /// <summary>
        /// Determines whether [is null or white space] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' must be null, empty or contain whitespace only!</exception>
        public void IsNullOrWhiteSpace(string value, string message)
        {
            if (!Check.String.IsNullOrWhiteSpace(value))
                throw new EnforcerException("'" + message + "' must be null, empty or contain whitespace only!", message);
        }

        /// <summary>
        /// Determines whether [is not null or white space] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' cannot be null, empty or contain whitespace only!</exception>
        public void IsNotNullOrWhiteSpace(string value, string message)
        {
            if (Check.String.IsNullOrWhiteSpace(value))
                throw new EnforcerException("'" + message + "' cannot be null, empty or contain whitespace only!", message);
        }



        /// <summary>
        /// Determines whether [is not null] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' cannot be null or empty!</exception>
        public void IsNotNull(string value, string message)
        {
            if (Check.Object.IsNull(value))
                throw new EnforcerException("'" + message + "' cannot be null!", message);
        }

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Name of the parameter.</param>
        /// <exception cref="EnforcerException">'" + message + "' cannot be null!</exception>
        public void IsNull(string value, string message)
        {
            if (!Check.Object.IsNull(value))
                throw new EnforcerException("'" + message + "' cannot be null!", message);
        }

    }
}