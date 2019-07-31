using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Action.Guards.Exceptions;

namespace Action.Guards.Tests
{
    [TestClass]
    public class StringEnforcersTests
    {
        [TestMethod]
        public void StringEnforcers_IsNotNullOrEmpty_Pass()
        {
            Enforcer.String.IsNotNullOrEmpty("test", "normal string should not trigger this guard");
            Enforcer.String.IsNotNullOrEmpty(" ", "white space should not trigger this guard");
        }
        [TestMethod]
        public void StringEnforcers_IsNotNullOrEmpty_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNotNullOrEmpty("", "empty string should trigger this guard"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNotNullOrEmpty(null, "null should trigger this guard"));
        }


        [TestMethod]
        public void StringEnforcers_IsNullOrEmpty_Pass()
        {
            Enforcer.String.IsNullOrEmpty("", "empty string should not trigger this guard");
            Enforcer.String.IsNullOrEmpty(null, "null should not trigger this guard");
        }
        [TestMethod]
        public void StringEnforcers_IsNullOrEmpty_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNullOrEmpty("test", "normal string should trigger this guard"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNullOrEmpty(" ", "white space should trigger this guard"));
        }


        [TestMethod]
        public void StringEnforcers_IsNotNullOrWhiteSpace_Pass()
        {
            Enforcer.String.IsNotNullOrWhiteSpace("test", "normal string should not trigger this guard");
            Enforcer.String.IsNotNullOrWhiteSpace("", "empty string should trigger this guard");
        }
        [TestMethod]
        public void StringEnforcers_IsNotNullOrWhiteSpace_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNotNullOrWhiteSpace("   ", "white-space should trigger this guard"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNotNullOrWhiteSpace(null, "null should trigger this guard"));
        }


        [TestMethod]
        public void StringEnforcers_IsNullOrWhiteSpace_Pass()
        {
            
            Enforcer.String.IsNullOrWhiteSpace("   ", "white-space should not trigger this guard");
            Enforcer.String.IsNullOrWhiteSpace(null, "null should not trigger this guard");
        }
        [TestMethod]
        public void StringEnforcers_IsNullOrWhiteSpace_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNullOrWhiteSpace("", "empty string should not trigger this guard"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNullOrWhiteSpace("test", "normal string should trigger this guard"));
        }


        [TestMethod]
        public void StringEnforcers_IsNotNull_Pass()
        {
            Enforcer.String.IsNotNull("test", "normal string should not trigger this guard");
            Enforcer.String.IsNotNull("", "empty should not trigger this guard");
            Enforcer.String.IsNotNull(" ", "white-space should not trigger this guard");
        }
        [TestMethod]
        public void StringEnforcers_IsNotNull_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNotNull(null, "null should trigger this guard"));
        }

        [TestMethod]
        public void StringEnforcers_IsNull_Pass()
        {
            Enforcer.String.IsNull(null, "null should not trigger this guard");
        }
        [TestMethod]
        public void StringEnforcers_IsNull_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNull("test", "normal string should trigger this guard"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNull("", "empty should trigger this guard"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.String.IsNull(" ", "white-space should trigger this guard"));

        }
    }
}
