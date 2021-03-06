using g4m4nez.Models;
using Xunit;

namespace g4m4nez.BusinessLayer.Tests
{
    public class EmailTest
    {
        [Fact]
        public void TestMailName()
        {
            //Arrange
            string expected1 = "boublik";
            string expected2 = "a";
            string expected3 = "n4gib4t0r";

            //Act
            var actual1 = new Email("boublik", "ukma.edu.ua").MailName;
            var actual2 = new Email("a", "ukma.edu.ua").MailName;
            var actual3 = new Email("n4gib4t0r", "ukma.edu.ua").MailName;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void TestDomain()
        {
            //Arrange
            string expected1 = "ukma.edu.ua";
            string expected2 = "gmail.com";
            string expected3 = "m.net";
            string expected4 = "m.c";

            //Act
            var actual1 = new Email("boublik", "ukma.edu.ua").Domain;
            var actual2 = new Email("a", "gmail.com").Domain;
            var actual3 = new Email("a", "m.net").Domain;
            var actual4 = new Email("a", "m.c").Domain;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }

        [Fact]
        public void TestToString()
        {
            //Arrange
            string expected1 = "boublik@ukma.edu.ua";
            string expected2 = "boublik@gmail.com";
            string expected3 = "a@m.net";
            string expected4 = "a@m.c";

            //Act
            var actual1 = new Email("boublik", "ukma.edu.ua").ToString();
            var actual2 = new Email("boublik", "gmail.com").ToString();
            var actual3 = new Email("a", "m.net").ToString();
            var actual4 = new Email("a", "m.c").ToString();

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }
    }
}
