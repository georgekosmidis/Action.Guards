using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Action.Guards;
using Action.Guards.BaseChecks;

namespace Action.Guards.BaseChecks.Tests
{
    [TestClass]
    public class BoolChecksTests
    {

        [TestMethod]
        public void BoolChecks_IsTrue_True()
        {
            var result = Check.Bool.IsTrue(true);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BoolChecks_IsTrue_False()
        {
            var result = Check.Bool.IsTrue(false);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BoolChecks_IsFalse_True()
        {
            var result = Check.Bool.IsFalse(false);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BoolChecks_IsFalse_False()
        {
            var result = Check.Bool.IsFalse(true);
            Assert.IsFalse(result);
        }
    }
}
