using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Action.Guards.Checks.Tests
{
    [TestClass]
    public class ObjectChecksTests
    {

        [TestMethod]
        public void ObjectChecks_IsDefault_True()
        {
            var test = new DateTime();
            var result = Check.Object.IsDefault(test);
            Assert.IsTrue(result);

            string test2 = null;
            var result2 = Check.Object.IsDefault(test2);
            Assert.IsTrue(result2);

        }

        [TestMethod]
        public void ObjectChecks_IsDefault_False()
        {
            var test = new DateTime().AddDays(1);
            var result = Check.Object.IsDefault(test);
            Assert.IsFalse(result);

            string test2 = "";
            var result2 = Check.Object.IsDefault(test2);
            Assert.IsFalse(result2);
        }


        enum enumTest { a = 1, b = 2 };
        [TestMethod]
        public void ObjectChecks_IsDefined_True()
        {
            var result = Check.Object.IsDefined(enumTest.a);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ObjectChecks_IsDefined_False()
        {
            var result = Check.Object.IsDefined((enumTest)3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ObjectChecks_IsNull_True()
        {
            int? test = null;
            var result = Check.Object.IsNull(test);
            Assert.IsTrue(result);

            string test2 = null;
            var result2 = Check.Object.IsNull(test2);
            Assert.IsTrue(result2);
        }


        [TestMethod]
        public void ObjectChecks_IsNull_False()
        {
            int? test = 1;
            var result = Check.Object.IsNull(test);
            Assert.IsFalse(result);

            string test2 = " ";
            var result2 = Check.Object.IsNull(test2);
            Assert.IsFalse(result2);
        }
    }
}
