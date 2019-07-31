using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action.Guards.Exceptions;
using Microsoft.Extensions.Options;

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
        private readonly RequestDelegate _next;

        /// <summary>
        /// The Action Guard Settings
        /// </summary>
        private readonly ActionGuardSettings _settings;


        public EnforcerMiddleware(RequestDelegate next)
        {
            _next = next;
            _settings = new ActionGuardSettings();//default values
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnforcerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="options">The options.</param>
        public EnforcerMiddleware(RequestDelegate next, IOptions<ActionGuardSettings> options)
        {
            _next = next;
            _settings = options.Value;
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
                await _next(context);
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
                ClassName = !_settings.ExceptionModel_ShowClassName ? "" : ex.GetType().Name.Split('.').Reverse().First(),
                InnerException = _settings.ExceptionModel_ShowInnerExceptions && ex.InnerException != null ? GetExceptionViewModel(ex.InnerException) : null,
                Message = !_settings.ExceptionModel_ShowClassName ? "" : ex.Message,
                StackTrace = !_settings.ExceptionModel_ShowClassName ? new List<string>() : ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList()
            };
        }
    }
}
