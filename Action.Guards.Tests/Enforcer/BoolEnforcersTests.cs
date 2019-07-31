using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Action.Guards;
using Action.Guards.Exceptions;

namespace Action.Guards.Tests
{
    [TestClass]
    public class BoolEnforcersTests
    {

        [TestMethod]
        public void BoolEnforcers_IsTrue_Pass()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Bool.IsTrue(false, "test1"));
        }

        [TestMethod]
        public void BoolEnforcers_IsTrue_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Bool.IsTrue(false, "test1"));
        }

        [TestMethod]
        public void BoolEnforcers_IsFalse_Pass()
        {
            Enforcer.Bool.IsFalse(false, "test1");
        }

        [TestMethod]
        public void BoolEnforcers_IsFalse_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Bool.IsFalse(true, "test1"));
        }
    }
}

