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
            var expected2 = "";

            //Act
            var actual1 = new Email("boublik");
            var actual2 = new Email("");

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }
    }
}
