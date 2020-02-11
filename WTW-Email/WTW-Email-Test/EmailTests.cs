using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTW_Email.Models;

namespace WTW_Email_Test
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void EmptyArrayTest()
        {
            // Arrange
            string[] emails = new string[] { };
            Solution solution = new Solution();

            // Act & Assert            
            Assert.AreEqual(0, solution.NumberOfUniqueEmailAddresses(emails), "Empty array test failed.");
        }

        [TestMethod]
        public void NoValidEmailsTest()
        {
            // Arrange
            string[] emails = new string[] { "abcd", "1234", "*#&$" };
            Solution solution = new Solution();

            // Act & Assert            
            Assert.AreEqual(0, solution.NumberOfUniqueEmailAddresses(emails), "No valid emails test failed.");
        }

        [TestMethod]
        public void SameEmailTest()
        {
            // Arrange
            string[] emails = new string[] { "jay.jorg308@gmail.com", "jay.jorg308@gmail.com", "jay.jorg308@gmail.com" };
            Solution solution = new Solution();

            // Act & Assert         
            Assert.AreEqual(1, solution.NumberOfUniqueEmailAddresses(emails), "Same email test failed.");
        }

        [TestMethod]
        public void SameEmailDifferentFormTest()
        {
            // Arrange
            string[] emails = new string[] { "jayjorg308@gmail.com", "jay.jorg308@gmail.com", "jay.jorg.308@gmail.com" };
            Solution solution = new Solution();

            // Act & Assert           
            Assert.AreEqual(1, solution.NumberOfUniqueEmailAddresses(emails), "Same email different form test failed.");
        }

        [TestMethod]
        public void SameEmailDifferentFormPlusTest()
        {
            // Arrange
            string[] emails = new string[] { "jayjorg@gmail.com", "jay.jorg@gmail.com", "jay.jorg+308@gmail.com" };
            Solution solution = new Solution();

            // Act & Assert           
            Assert.AreEqual(1, solution.NumberOfUniqueEmailAddresses(emails), "Same email different form plus test failed.");
        }

        [TestMethod]
        public void DifferentEmailsTest()
        {
            // Arrange
            string[] emails = new string[] { "jay.jorg308@gmail.com", "test.person+100@hotmail.com", "another.test@yahoo.com" };
            Solution solution = new Solution();

            // Act & Assert         
            Assert.AreEqual(3, solution.NumberOfUniqueEmailAddresses(emails), "Different emails test failed.");
        }
    }
}