using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializePeople;
using System.IO;

namespace MainTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void IsConstructorWorking()
        {
            Person testPerson = new Person("Adam Test", DateTime.Now, Genders.MALE);
            Assert.IsNotNull(testPerson);
        }

        [TestMethod]
        public void IsToStringReturnsString()
        {
            Person testPerson = new Person("Adam Test", DateTime.Now, Genders.MALE);
            string testString = testPerson.ToString();
            Assert.IsNotNull(testString);
        }

        [TestMethod]
        public void IsToStringReturnsCorrectString()
        {
            Person testPerson = new Person("Adam Test", new DateTime(1983, 11, 3), Genders.MALE);
            string testString = testPerson.ToString();
            string properString = "Name: Adam Test, Birth date: 1983 11 03, Gender: MALE";
            Assert.AreEqual(properString, testString);
        }

        [TestMethod]
        public void IsObjectSerialazable()
        {
            if (File.Exists("test.txt")) File.Delete("test.txt");
            Person testPerson = new Person("Adam Test", new DateTime(1983, 11, 3), Genders.MALE);
            testPerson.Serialize("test.txt");
        }
    }
}
