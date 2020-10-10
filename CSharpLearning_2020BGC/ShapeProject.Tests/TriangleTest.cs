using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShapeProject.Tests
{
    public class TriangleTest
    {
        [Theory]
        [InlineData(new double[] { 0, 0, 3, 0, 3, 4 }, true)]
        [InlineData(new double[] { 0, 0, 3, 0, 4, 0 }, false)]
        [InlineData(new double[] { 0, 0, -2, -1, 6, 3 }, false)]
        public void TriangleIsValid_Test(double[] inputArray, bool expectedResult)
        {
            bool result = Triangle.TriangleIsValid(new Point(inputArray[0], inputArray[1]), new Point(inputArray[2], inputArray[3]), new Point(inputArray[4], inputArray[5]));
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new double[] { 0, 0, 3, 0, 3, 4 }, 12)]
        [InlineData(new double[] { 4, 3, 8, 0, 0, 0 }, 18)]
        [InlineData(new double[] { 0, 0, 1, 3, 3, 3 }, 9.405)]
        public void GetPerimeter_Test(double[] inputArray, double expectedResult)
        {
            Triangle triangle = new Triangle(new Point(inputArray[0], inputArray[1]), new Point(inputArray[2], inputArray[3]), new Point(inputArray[4], inputArray[5]));
            double result = triangle.GetPerimeter();
            Assert.Equal(expectedResult, result, precision: 3);
        }
        [Theory]
        [InlineData(new double[] { 0, 0, 3, 0, 3, 4 }, 6)]
        [InlineData(new double[] { 4, 3, 8, 0, 0, 0 }, 12)]
        [InlineData(new double[] { 0, 0, 1, 3, 3, 3 }, 3)]
        public void GetArea_Test(double[] inputArray, double expectedResult)
        {
            Triangle triangle = new Triangle(new Point(inputArray[0], inputArray[1]), new Point(inputArray[2], inputArray[3]), new Point(inputArray[4], inputArray[5]));
            double result = triangle.GetArea();
            Assert.Equal(expectedResult, Math.Round(result, 3));
        }
    }
}
