using System;
using Xunit;

namespace BusinessLayer.Tests
{
    public class EmailTest
    {
        [Fact]
        public void TestMailname()
        {
            //Arrange
            var expected1 = "boublik";
            var expected2 = "boublik";
            var expected3 = "";
            var expected4 = "";

            //Act
            var actual1 = new Email("boublik", "").MailName();
            var actual2 = new Email("boublik", "asdavsdvasdva").MailName();
            var actual3 = new Email("", "").MailName();
            var actual4 = new Email("", "boublik").MailName();

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }
    }
}
