using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Action.Guards.Checks.Tests
{
    [TestClass]
    public class NumericChecksTests
    {

        [TestMethod]
        public void NumericChecks_AreEqual_True()
        {
            var test = new DateTime();
            var result = Check.Numeric.AreEqual(test, new DateTime());
            Assert.IsTrue(result);

            var result2 = Check.Numeric.AreEqual(1M, 1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void NumericChecks_AreEqual_False()
        {
            var test = (new DateTime()).AddDays(1);
            var result = Check.Numeric.AreEqual(test, new DateTime());
            Assert.IsFalse(result);

            var result2 = Check.Numeric.AreEqual(int.MaxValue, int.MinValue);
            Assert.IsFalse(result2);
        }


        [TestMethod]
        public void NumericChecks_IsGreaterThan_True()
        {
            var test = new DateTime().AddDays(1);
            var result = Check.Numeric.IsGreaterThan(test, new DateTime());
            Assert.IsTrue(result);

            var result2 = Check.Numeric.IsGreaterThan(1.1M, 1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void NumericChecks_IsGreaterThan_False()
        {
            var test = (new DateTime());
            var result = Check.Numeric.IsGreaterThan(test, new DateTime());
            Assert.IsFalse(result);

            var result2 = Check.Numeric.IsGreaterThan(int.MinValue, 10);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void NumericChecks_IsSmallerThan_True()
        {
            var test = new DateTime();
            var result = Check.Numeric.IsSmallerThan(test, new DateTime().AddDays(1));
            Assert.IsTrue(result);

            var result2 = Check.Numeric.IsSmallerThan(1M, 2);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void NumericChecks_IsSmallerThan_False()
        {
            var test = (new DateTime());
            var result = Check.Numeric.IsSmallerThan(test, new DateTime());
            Assert.IsFalse(result);

            var result2 = Check.Numeric.IsGreaterThan(int.MinValue, 10);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void NumericChecks_IsBetweenInclusive_True()
        {
            var test = new DateTime();
            var result = Check.Numeric.IsBetweenInclusive(test, new DateTime(), new DateTime().AddDays(1));
            Assert.IsTrue(result);

            var result2 = Check.Numeric.IsBetweenInclusive(1M, 1, 2);
            Assert.IsTrue(result2);

            var result3 = Check.Numeric.IsBetweenInclusive(2, 1, 2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void NumericChecks_IsBetweenInclusive_False()
        {
            var test = new DateTime().AddDays(10);
            var result = Check.Numeric.IsBetweenInclusive(test, new DateTime(), new DateTime().AddDays(1));
            Assert.IsFalse(result);

            var result2 = Check.Numeric.IsBetweenInclusive(1M, 2, 3);
            Assert.IsFalse(result2);

            var result3 = Check.Numeric.IsBetweenInclusive(4, 1, 2);
            Assert.IsFalse(result3);
        }


        [TestMethod]
        public void NumericChecks_IsBetweenExclusive_True()
        {
            var result = Check.Numeric.IsBetweenExclusive(2M, 1, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NumericChecks_IsBetweenExclusive_False()
        {
            var result2 = Check.Numeric.IsBetweenExclusive(1M, 1, 2);
            Assert.IsFalse(result2);

            var result3 = Check.Numeric.IsBetweenExclusive(2, 1, 2);
            Assert.IsFalse(result3);

            var result4 = Check.Numeric.IsBetweenExclusive(1M, 2, 3);
            Assert.IsFalse(result4);

            var result5 = Check.Numeric.IsBetweenExclusive(3, 1, 2);
            Assert.IsFalse(result5);
        }
    }
}
