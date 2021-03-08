using System;
using System.Collections.Generic;
using Xunit;

namespace BusinessLayer.Tests
{
    public class WalletCategoriesTest
    {
        [Fact]
        public void TestHashing()
        {
            //Arrange
            var expected1 = 2;

            //Act
            var actual1 = new HashSet<Category> { new Category("a", "", "", Category.Colors.BLACK), new Category("a", "", "", Category.Colors.BLACK) };

            //Assert
            Assert.Equal(actual1.Count, expected1);
        }
    }
}
