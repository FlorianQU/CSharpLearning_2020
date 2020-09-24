using System;
using Xunit;

namespace ShapeProject.Tests
{
    public class OverlapAreaTest
    {
        [Theory]
        [InlineData(new double[] { 0, 0, 3, 2, 4, 3, 5, 4 }, 0)]
        [InlineData(new double[] { 0, 0, 3, 2, 2, 0, 4, 3 }, 2)]
        [InlineData(new double[] { 0, 0, 3, 2, -1, 1, 4, 2 }, 3)]
        [InlineData(new double[] { 0, 0, 3, 2, 0, -1, 3, 2 }, 6)]
        [InlineData(new double[] { 0, 0, 3, 2, 1, 0, 2, 1 }, 1)]
        [InlineData(new double[] { 0, 0, 3, 2, -1, -1, 1, 0 }, 0)]
        [InlineData(new double[] { 0, 0, 3, 2, -2, -2, -1, -1 }, 0)]

        public void GetOverlapArea_ReturnValue(double[] coordArray, double expectedResult)
        {
            Rectangle rectangle1 = new Rectangle(new Point(coordArray[0], coordArray[1]), new Point(coordArray[2], coordArray[3]));
            Rectangle rectangle2 = new Rectangle(new Point(coordArray[4], coordArray[5]), new Point(coordArray[6], coordArray[7]));
            double result = rectangle1.GetOverlapArea(rectangle2);
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new double[] { 1, 0, 0, 0, 0, 3, 0, 3, 4, 1, 1, 3, 4 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0 })]
        public void GetOverlapArea_BetweenShapes_Test(double[] inputArray, double[] expectedResults)
        {
            Circle circle = new Circle(inputArray[0], new Point(inputArray[1], inputArray[2]));
            Triangle triangle = new Triangle(new Point(inputArray[3], inputArray[4]), new Point(inputArray[5], inputArray[6]), new Point(inputArray[7], inputArray[8]));
            Rectangle rectangle = new Rectangle(new Point(inputArray[9], inputArray[10]), new Point(inputArray[11], inputArray[12]));
            double[] resultArray = new double[] {circle.GetOverlapArea(triangle), circle.GetOverlapArea(rectangle), circle.GetOverlapArea(circle),
                triangle.GetOverlapArea(circle), triangle.GetOverlapArea(rectangle), triangle.GetOverlapArea(triangle),
                rectangle.GetOverlapArea(circle), rectangle.GetOverlapArea(triangle) };
            Assert.Equal(expectedResults, resultArray);
        }
        [Fact]
        public void GetOverlapArea_ObjectIsNull()
        {
            Circle circle = new Circle(1, new Point(0, 0));
            Rectangle rectangle = new Rectangle(new Point(1, 1), new Point(3, 4));
            Triangle triangle = new Triangle(new Point(0, 0), new Point(3, 0), new Point(3, 4));
            Assert.Equal(-1, circle.GetOverlapArea(null));
            Assert.Equal(-1, rectangle.GetOverlapArea(null));
            Assert.Equal(-1, triangle.GetOverlapArea(null));
        }
    }
}
