using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShapeProject.Tests
{
    public class RectangleTest
    {
        [Theory]
        [InlineData(new int[] { 0, 0, 3, 2 }, true)]
        [InlineData(new int[] { 3, 2, 0, 0 }, false)]
        public void RectangleIsValid_Test(int[] inputArray, bool expectedResult)
        {
            Assert.Equal(expectedResult, Rectangle.RectangleIsValid(new Point(inputArray[0], inputArray[1]), new Point(inputArray[2], inputArray[3])));
        }
        [Theory]
        [InlineData(new int[] { 0, 0, 3, 2 }, 10)]
        [InlineData(new int[] { 3, 4, 5, 6 }, 8)]
        public void GetPerimeter_Test(int[] inputArray, double expectedResult)
        {
            Rectangle rectangle = new Rectangle(new Point(inputArray[0], inputArray[1]), new Point(inputArray[2], inputArray[3]));
            Assert.Equal(expectedResult, rectangle.GetPerimeter());
        }
        [Theory]
        [InlineData(new int[] { 0, 0, 3, 2 }, 6)]
        [InlineData(new int[] { 3, 4, 5, 6 }, 4)]
        public void GetArea_Test(int[] inputArray, double expectedResult)
        {
            Rectangle rectangle = new Rectangle(new Point(inputArray[0], inputArray[1]), new Point(inputArray[2], inputArray[3]));
            Assert.Equal(expectedResult, rectangle.GetArea());
        }
    }
}
