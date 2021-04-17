using g4m4nez.Models;
using Xunit;

namespace g4m4nez.BusinessLayer.Tests
{
    public class CategoryTest
    {
        [Fact]
        public void TestCategoryName()
        {
            //Arrange
            string expected1 = "Їжа";
            string expected2 = "Guitars";
            string expected3 = "Секс-іграшки";
            string expected4 = "Theatre";

            //Act
            var actual1 = new Category(expected1, "icon.png", Category.Colors.BLACK).Name;
            var actual2 = new Category(expected2, "icon.png", Category.Colors.BLACK).Name;
            var actual3 = new Category(expected3, "icon.png", Category.Colors.BLACK).Name;
            var actual4 = new Category(expected4, "icon.png", Category.Colors.BLACK).Name;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }

        [Fact]
        public void TestIcon()
        {
            //Arrange
            string expected1 = "icon24.png";
            string expected2 = "/data/assets/icon24.png";
            string expected3 = "picture";
            string expected4 = "pstrn.jpg";

            //Act
            var actual1 = new Category("Їжа", expected1, Category.Colors.BLACK).Icon;
            var actual2 = new Category("Їжа", expected2, Category.Colors.BLACK).Icon;
            var actual3 = new Category("Їжа", expected3, Category.Colors.BLACK).Icon;
            var actual4 = new Category("Їжа", expected4, Category.Colors.BLACK).Icon;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }

        [Fact]
        public void TestColor()
        {
            //Arrange
            var expected1 = Category.Colors.BLACK;
            var expected2 = Category.Colors.BLUE;
            var expected3 = Category.Colors.CYAN;
            var expected4 = Category.Colors.MAGENTA;
            var expected5 = Category.Colors.ORANGE;

            //Act
            var actual1 = new Category("Їжа", "icon24.png", expected1).Color;
            var actual2 = new Category("Їжа", "icon24.png", expected2).Color;
            var actual3 = new Category("Їжа", "icon24.png", expected3).Color;
            var actual4 = new Category("Їжа", "icon24.png", expected4).Color;
            var actual5 = new Category("Їжа", "icon24.png", expected5).Color;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }
    }
}
