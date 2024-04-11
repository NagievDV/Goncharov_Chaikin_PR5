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

            var tAP = new AuthPage();

            var tCP = new CaptchaPage();

            //Позитивные тест-кейсы
            Assert.IsTrue(tAP.Auth("Elizor@gmai,com", "yntiRS"));
            Assert.IsTrue(tAP.Auth("Vladlena@gmai.com", "07i7Lb"));
            Assert.IsTrue(tAP.Auth("Adam@gmai.com", "7SP9CV"));
            Assert.IsTrue(tAP.Auth("Kar@gmai.com", "6QF1WB"));
            Assert.IsTrue(tAP.Auth("Yli@gmai.com", "GwffgE"));
            Assert.IsTrue(tAP.Auth("Vasilisa@gmai.com", "d7iKKV"));
            Assert.IsTrue(tAP.Auth("Galina@gmai.com", "8KC7wJ"));
            Assert.IsTrue(tAP.Auth("Miron@@gmai,com", "x58OAN"));
            Assert.IsTrue(tAP.Auth("Vseslava@gmai.com", "fhDSBf"));
            Assert.IsTrue(tAP.Auth("Victoria@gmai.com", "9mlPQJ"));
            Assert.IsTrue(tAP.Auth("Anisa@gmai.com", "Wh4OYm"));
            Assert.IsTrue(tAP.Auth("Feafan@@gmai,com", "Kc1PeS"));

            //Негативные тест-кейсы

        }
    }
}
