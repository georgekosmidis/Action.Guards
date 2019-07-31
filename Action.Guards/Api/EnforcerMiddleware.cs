using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action.Guards.Exceptions;

namespace Action.Guards.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class EnforcerMiddleware
    {
        /// <summary>
        /// The next RequestDelegate.
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="next"> The next RequestDelegate. </param>
        public EnforcerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Executes the given operation on a different thread, and waits for the result.
        /// </summary>
        ///
        /// <param name="context">  The context. </param>
        ///
        /// <returns>
        /// An asynchronous result.
        /// </returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex) when (ex is IEnforcerException)
            {
                await HandleGuardExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles the exception asynchronoulsy.
        /// </summary>
        ///
        /// <param name="context">  The HttpContext. </param>
        /// <param name="ex">       The Exception. </param>
        ///
        /// <returns>
        /// An asynchronous result.
        /// </returns>
        private Task HandleGuardExceptionAsync(HttpContext context, Exception ex)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Microsoft.AspNetCore.Hosting.EnvironmentName.Development;

            var result = JsonConvert.SerializeObject(
                GetExceptionViewModel(ex),
                Formatting.Indented
            );

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400;//bad request
            if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }

            return context.Response.WriteAsync(result);
        }

        /// <summary>
        /// Gets the exception view model for serialization. <br />
        /// It uses recursion on every inner exception.
        /// </summary>
        ///
        /// <param name="ex">   The Exception. </param>
        ///
        /// <returns>
        /// The exception view model.
        /// </returns>
        private EnforcerExceptionModel GetExceptionViewModel(Exception ex)
        {
            return new EnforcerExceptionModel()
            {
                ClassName = ex.GetType().Name.Split('.').Reverse().First(),
                InnerException = ex.InnerException != null ? GetExceptionViewModel(ex.InnerException) : null,
                Message = ex.Message,
                StackTrace = ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList()
            };
        }
    }
}
