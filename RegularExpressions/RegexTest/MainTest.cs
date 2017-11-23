using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InputValidation;

namespace RegexTest
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void IsNameCorrect()
        {
            bool result;
            string name = "testName";
            result = Logic.checkName(name);
            Assert.IsTrue(result);
        }
    }
}
