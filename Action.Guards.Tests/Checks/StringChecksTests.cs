using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Action.Guards;
using Action.Guards.BaseChecks;

namespace Action.Guards.BaseChecks.Tests
{
    [TestClass]
    public class StringChecksTests
    {
        [TestMethod]
        public void StringGuards_IsNullOrEmpty_True()
        {
            Assert.IsTrue(
                Check.String.IsNullOrEmpty("")
            );
            Assert.IsTrue(
                Check.String.IsNullOrEmpty(null)
            );
        }
        [TestMethod]
        public void StringGuards_IsNullOrEmpty_False()
        {
            Assert.IsFalse(
                Check.String.IsNullOrEmpty("test")
            );
            Assert.IsFalse(
                Check.String.IsNullOrEmpty(" ")
            );
        }
        

        [TestMethod]
        public void StringGuards_IsNullOrWhiteSpace_True()
        {
            Assert.IsTrue(
                Check.String.IsNullOrWhiteSpace(null)
            );
            Assert.IsTrue(
                Check.String.IsNullOrWhiteSpace("     ")
            );
        }
        [TestMethod]
        public void StringGuards_IsNullOrWhiteSpace_False()
        {
            Assert.IsFalse(
                Check.String.IsNullOrWhiteSpace("test")
            );
            Assert.IsFalse(
                Check.String.IsNullOrWhiteSpace("")
            );
        }


        [TestMethod]
        public void StringGuards_IsNull_True()
        {
            Assert.IsTrue(
                Check.String.IsNull(null)
            );
        }
        [TestMethod]
        public void StringGuards_IsNull_False()
        {
            Assert.IsFalse(
                Check.String.IsNull("test")
            );
            Assert.IsFalse(
                Check.String.IsNull("")
            );
            Assert.IsFalse(
                Check.String.IsNull("     ")
            );
        }
    }
}
