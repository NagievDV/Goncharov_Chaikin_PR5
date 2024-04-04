using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PR5UnitTest
{
    [TestClass]

    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 4);
            Assert.IsTrue(res < 5);

        }
    }
}
