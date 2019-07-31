using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Action.Guards.Exceptions;

namespace Action.Guards.Tests
{
    [TestClass]
    public class NumericEnforcersTests
    {
        [TestMethod]
        public void NumericEnforcers_IsGreaterThan_Pass()
        {
            Enforcer.Numeric.IsGreaterThan(10, 0,  "greater");
        }
        [TestMethod]
        public void NumericEnforcers_IsGreaterThan_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsGreaterThan(0, 0, "equal"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsGreaterThan( 0, 10, "smaller"));
        }


        [TestMethod]
        public void NumericEnforcers_IsGreaterOrEqualThan_Pass()
        {
            Enforcer.Numeric.IsGreaterOrEqualThan(10, 0,  "greater");
            Enforcer.Numeric.IsGreaterOrEqualThan(0, 0, "equal");
        }
        [TestMethod]
        public void NumericEnforcers_IsGreaterOrEqualThan_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsGreaterOrEqualThan( 0, 10, "smaller"));
        }


        [TestMethod]
        public void NumericEnforcers_IsSmallerThan_Pass()
        {
            Enforcer.Numeric.IsSmallerThan( 0, 10, "smaller");
        }

        [TestMethod]
        public void NumericEnforcers_IsSmallerThan_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsSmallerThan(0, 0, "equal"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsSmallerThan(10, 0,  "greater"));
        }


        [TestMethod]
        public void NumericEnforcers_IsSmallerOrEqualThan_Pass()
        {
            Enforcer.Numeric.IsSmallerOrEqualThan( 0, 10, "greater");
            Enforcer.Numeric.IsSmallerOrEqualThan(0, 0, "equal");
        }
        [TestMethod]
        public void NumericEnforcers_IsSmallerOrEqualThan_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsSmallerOrEqualThan(10, 0, "smaller"));
        }


        [TestMethod]
        public void IsBetweenInclusiveThan_Pass()
        {
            Enforcer.Numeric.IsBetweenInclusive(5, 0, 10,  "between");
            Enforcer.Numeric.IsBetweenInclusive(0, 0, 10,  "equal-smaller");
            Enforcer.Numeric.IsBetweenInclusive(10, 0, 10,  "equal-bigger");
        }
        [TestMethod]
        public void IsBetweenInclusiveThan_Exceptions()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsBetweenInclusive(-1, 0, 10,  "smaller"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsBetweenInclusive(11, 0, 10, "bigger"));
        }


        [TestMethod]
        public void IsBetweenExclusiveThan_Pass()
        {
            Enforcer.Numeric.IsBetweenExclusive(5, 0, 10, "between");
        }
        [TestMethod]
        public void IsBetweenExclusiveThan_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsBetweenExclusive(0, 0, 10,  "equal-smaller"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsBetweenExclusive(10, 0, 10,  "equal-bigger"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsBetweenExclusive(-1, 0, 10,  "smaller"));
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Numeric.IsBetweenExclusive(11, 0, 10,  "bigger"));
        }
    }
}
