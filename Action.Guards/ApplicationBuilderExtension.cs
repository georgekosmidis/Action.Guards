using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Action.Guards.Api;

namespace Action.Guards
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Adds the enforcer middleware.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder AddEnforcerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EnforcerMiddleware>();
        }

    }
}
