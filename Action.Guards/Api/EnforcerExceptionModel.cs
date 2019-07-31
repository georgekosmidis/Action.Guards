using System.Collections.Generic;

namespace Action.Guards.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class EnforcerExceptionModel
    {
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// 
        /// <value>
        /// The name of the class.
        /// </value>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        ///
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the inner exception.
        /// </summary>
        ///
        /// <value>
        /// The inner exception.
        /// </value>
        public EnforcerExceptionModel InnerException { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        ///
        /// <value>
        /// The stack trace.
        /// </value>
        public List<string> StackTrace { get; set; }
    }
}
