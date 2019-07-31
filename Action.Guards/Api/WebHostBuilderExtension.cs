using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Guards.Api
{
    public static class WebHostBuilderExtension
    {
        /// <summary>
        /// Configures teqcycle logging system. 
        /// Uses Serilog under the hood
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder ConfigureGuards(this IWebHostBuilder builder, ActionGuardsConfiguration configuration)
        {
                        
            

            return builder;
        }
    }
}
