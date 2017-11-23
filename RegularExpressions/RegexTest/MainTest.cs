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
            result = Logic.CheckName(name);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPhoneCorrect()
        {
            bool result;
            string number1 = "123-123-1234";
            string number2 = "(123)123-1234";
            result = Logic.CheckPhone(number1);
            Assert.IsTrue(result);
            result = Logic.CheckPhone(number2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmailCorrect()
        {
            bool result;
            string email = "asd12@fake.de";
            result = Logic.CheckEmail(email);
            Assert.IsTrue(result);
        }
    }
}
