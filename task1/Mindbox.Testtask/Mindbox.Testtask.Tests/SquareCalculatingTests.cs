using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mindbox.Testtask.Tests
{
    [TestClass]
    public class SquareCalculatingTests
    {
        double eps = 0.000000001;
        double eps4 = 0.0001;
        [TestMethod]
        public void TestCircleSquare1()
        {
            double rad = 10;
            ISquareCalcable circle = new Circle(rad);
            var actual = circle.CalcSquare();
            var expected = Math.PI * 100;
            Assert.AreEqual(expected, actual, eps);
        }
        [TestMethod]
        public void TestRandomCircleSquare()
        {
            Random rand = new Random();
            double rad = rand.NextDouble() * 10000;
            ISquareCalcable circle = new Circle(rad);
            var actual = circle.CalcSquare();
            var expected = Math.PI * rad * rad;
            Assert.AreEqual(expected, actual, eps4);
        }
        [TestMethod]
        public void TestZeroCirleSquare()
        {
            double rad = 0;
            ISquareCalcable circle = new Circle(rad);
            var actual = circle.CalcSquare();
            var expected = 0;
            Assert.AreEqual(expected, actual, eps);
        }
        [TestMethod]
        public void TestMaxDoubleCircleSquare()
        {
            var maxValue = Math.Sqrt(double.MaxValue / Math.PI);
            var maxValuePlus = maxValue + (double.MaxValue - maxValue) / 2;//Так как шаг может быть сильно больше 1, просто берём середину диапазона
            double rad =  maxValuePlus;
            ISquareCalcable circle = new Circle(rad);
            bool thereWasAnException = false;
            try
            {
                var expected = circle.CalcSquare();
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(ArgumentOutOfRangeException));
                thereWasAnException = true;
            }
            Assert.IsTrue(thereWasAnException);
        }
        [TestMethod]
        public void TestTriangleSquare1()
        {
            ISquareCalcable triangle = new Triangle(4, 4, 5);
            var expected = 7.806247;
            var actual = triangle.CalcSquare();
            Assert.AreEqual((double)expected, actual, eps4);
        }
        [TestMethod]
        public void TestRectTriangleSquare()
        {
            ISquareCalcable triangle = new Triangle(24, 7, 25);
            var expected = 84;
            var actual = triangle.CalcSquare();
            Assert.AreEqual((double)expected, actual, eps);
        }
        [TestMethod]
        public void TestNonExistingTriangleSquare()
        {
            ISquareCalcable triangle = new Triangle(1000, 10, 10);
            bool thereWasAnException = false;
            try
            {
                var actual = triangle.CalcSquare();
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(ArgumentException));
                thereWasAnException= true;
            }
            Assert.IsTrue(thereWasAnException);
        }
        [TestMethod]
        public void TestFlatTriangle()
        {
            ISquareCalcable triangle = new Triangle(20, 10, 10);
            bool thereWasAnException = false;
            try
            {
                var actual = triangle.CalcSquare();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(ArgumentException));
                thereWasAnException = true;
            }
            Assert.IsTrue(thereWasAnException);
        }
        [TestMethod]
        public void TestAlmostFlatTriangle()
        {
            ISquareCalcable triangle = new Triangle(20, 10.01, 10);
            var expected = 3.162673;
            var actual = triangle.CalcSquare();
            Assert.AreEqual(expected, actual, eps4);
        }
    }
}
