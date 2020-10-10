using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace ShapeProject.Tests
{
    public class CircleTest
    {
        [Theory]
        [InlineData(new double[] { 1, 0, 0 }, true)]
        [InlineData(new double[] { 0, 1, 1 }, false)]
        [InlineData(new double[] { -1, 1, 1 }, false)]
        public void CircleIsValid_Test(double[] inputArray, bool expectedResult)
        {
            bool result = Circle.CircleIsValid(inputArray[0], new Point(inputArray[1], inputArray[2]));
            Assert.Equal(expectedResult,result);
        }
        [Theory]
        [InlineData(new double[] { 1, 0, 0 })]
        [InlineData(new double[] { 2, 1, 1 })]
        public void GetCenter_Test(double[] inputArray)
        {
            Circle circle = new Circle(inputArray[0], new Point(inputArray[1], inputArray[2]));
            Assert.Equal(new double[] { inputArray[1],inputArray[2]}, new double[] { circle.Center.X, circle.Center.Y});
        }

        [Theory]
        [InlineData(new double[] { 1, 0, 0 }, 6.283)]
        [InlineData(new double[] { 2, 1, 1 }, 12.566)]
        public void GetPerimeter_Test(double[] inputArray, double expectedResult)
        {
            Circle circle = new Circle(inputArray[0], new Point(inputArray[1], inputArray[2]));
            Assert.Equal(expectedResult, circle.GetPerimeter(), precision: 3);
        }
        [Theory]
        [InlineData(new double[] { 1, 0, 0 }, 3.142)]
        [InlineData(new double[] { 2, 1, 1 }, 12.566)]
        public void GetArea_Test(double[] inputArray, double expectedResult)
        {
            Circle circle = new Circle(inputArray[0], new Point(inputArray[1], inputArray[2]));
            Assert.Equal(expectedResult, circle.GetArea(), precision: 3);
        }
    }
}
