using Action.Guards.Api;
using Action.Guards.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Action.Guards.Api.Tests
{

    [TestClass]
    public class EnforcerMiddlewareTests
    {

        [TestMethod]
        public async Task EnforcerMiddleware_DefaultConstructor_NoException_200()
        {

            var middleware = new EnforcerMiddleware(
                next: (innerHttpContext) => Task.FromResult(0)
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);

            Assert.AreEqual(200, context.Response.StatusCode);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task EnforcerMiddleware_DefaultConstructor_NotGuardException_Throw()
        {

            var middleware = new EnforcerMiddleware(
                next: (innerHttpContext) =>
                {
                    throw new InvalidOperationException("test");
                }
            );
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            await middleware.Invoke(context);
        }

        [TestMethod]
        public async Task EnforcerMiddleware_DefaultConstructor_GuardException_400_NothingIncluded()
        {

            var middleware = new EnforcerMiddleware(
                next: (innerHttpContext) =>
                {
                    throw new EnforcerException("Message", "ParamName");
                }
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);

            Assert.AreEqual(400, context.Response.StatusCode);

            var streamText = reader.ReadToEnd();
            var objResponse = JsonConvert.DeserializeObject<EnforcerExceptionModel>(streamText);
            Assert.AreEqual("", objResponse.ClassName);
            Assert.IsNull(objResponse.InnerException);
            Assert.AreEqual("", objResponse.Message);
            Assert.AreEqual(0, objResponse.StackTrace.Count);
        }

        [TestMethod]
        public async Task EnforcerMiddleware_SettingsConstructor_GuardException_400_AllIncluded()
        {

            var middleware = new EnforcerMiddleware(
                next: (innerHttpContext) =>
                {
                    throw new EnforcerException("Message", "ParamName")
                    {
                       
                    };
                },
                options: Options.Create(new ActionGuardSettings()
                {
                    ExceptionModel_ShowClassName = true,
                    ExceptionModel_ShowInnerExceptions = true,
                    ExceptionModel_ShowMessage = true,
                    ExceptionModel_ShowStackTrace = true
                })
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);

            Assert.AreEqual(400, context.Response.StatusCode);

            var streamText = reader.ReadToEnd();
            var objResponse = JsonConvert.DeserializeObject<EnforcerExceptionModel>(streamText);
            Assert.AreEqual("EnforcerException", objResponse.ClassName);
            Assert.IsNull(objResponse.InnerException);
            Assert.AreNotEqual("Message\\r\\nParameter name: ParamName", objResponse.Message);
            Assert.AreEqual(2, objResponse.StackTrace.Count);
        }
    }
}
