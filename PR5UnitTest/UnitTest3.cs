using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _3ISIP_321_Goncharov_Chaikin_PR5;

namespace PR5UnitTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {

            var page = new AuthPage();

            Assert.IsTrue(page.Auth("Elizor@gmai,com", "yntiRS"));


        }
    }
}
