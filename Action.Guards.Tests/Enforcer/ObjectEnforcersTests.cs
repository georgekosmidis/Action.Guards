using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Action.Guards.Exceptions;


namespace Action.Guards.Tests
{
    [TestClass]
    public class ObjectsEnforcersTests
    {
        [TestMethod]
        public void ObjectsEnforcers_AreEqual_Pass()
        {
            Enforcer.Object.AreEqual(1, 1, "test1");
        }
        [TestMethod]
        public void ObjectsEnforcers_AreEqual_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Object.AreEqual(1, 2, "test2"));
        }

        [TestMethod]
        public void ObjectsEnforcers_AreNotEqual_Pass()
        {
            Enforcer.Object.AreNotEqual(1, 2, "test1");
        }
        [TestMethod]
        public void ObjectsEnforcers_AreNotEqual_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Object.AreNotEqual(1, 1, "test2"));
        }


        [TestMethod]
        public void ObjectsEnforcers_IsNotNullOrDefault_Pass()
        {
            Enforcer.Object.IsNotNullOrDefault(DateTime.Now, "new");
        }
        [TestMethod]
        public void ObjectsEnforcers_IsNotNullOrDefault_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Object.IsNotNullOrDefault(new DateTime(), "default"));
            Assert.ThrowsException<EnforcerException>(() => { int? o = null; Enforcer.Object.IsNotNullOrDefault(o, "null"); });
        }


        [TestMethod]
        public void ObjectsEnforcers_IsNullOrDefault_Pass()
        {
            Enforcer.Object.IsNullOrDefault(new DateTime(), "default");
            int? o = null;
            Enforcer.Object.IsNullOrDefault(o, "null");
        }
        [TestMethod]
        public void ObjectsEnforcers_IsNullOrDefault_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => Enforcer.Object.IsNullOrDefault(DateTime.Now, "new"));
        }


        enum enumTest { a = 1, b = 2 };
        [TestMethod]
        public void ObjectsEnforcers_IsDefined_Pass()
        {
            Enforcer.Object.IsDefined(enumTest.a, "enumtest");
        }
        [TestMethod]
        public void ObjectsEnforcers_IsDefined_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => { var test = (enumTest)3; Enforcer.Object.IsDefined(test, "not-defined"); });
        }

        [TestMethod]
        public void ObjectsEnforcers_IsNotDefined_Pass()
        {
            var test = (enumTest)3;
            Enforcer.Object.IsNotDefined(test, "not-defined");
        }
        [TestMethod]
        public void ObjectsEnforcers_IsNotDefined_Exception()
        {
            Assert.ThrowsException<EnforcerException>(() => { Enforcer.Object.IsNotDefined(enumTest.a, "enumtest"); });
        }
    }
}
