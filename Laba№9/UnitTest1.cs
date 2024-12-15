using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PointClass;

namespace TestPointClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDecrement_PointClass()
        {
            Point point = new Point(5,6);
            point--;
            Assert.AreEqual(new Point(4,5), point);
        }
        [TestMethod]
        public void Test_PointX()
        {
            Point point = new Point(5, 6);
            Assert.AreEqual(point.X, 5);
        }
        [TestMethod]
        public void Test_PointY()
        {
            Point point = new Point(5, 6);
            Assert.AreEqual(point.Y, 6);
        }
        [TestMethod]
        public void Test_PointCount()
        {
            Point point = new Point(5, 6);
            int count = point.Count;
            Point p2 = new Point(6, 8);
            Assert.AreEqual(p2.Count, count+1);
        }
        [TestMethod]
        public void Test_PointConstructor()
        {
            Point point = new Point();
            Assert.AreEqual(new Point(), point);
        }
        [TestMethod]
        public void Test_ConstructorParam()
        {
            Point point = new Point(5, 6);
            Assert.AreEqual(new Point(5,6), point);
        }
        [TestMethod]
        public void Test_PointCalculateDist()
        {
            Point point = new Point(3, 4);
            Assert.AreEqual(5, point.CalculateDistance());
        }
        [TestMethod]
        public void Test_PointCalculateDistStatic()
        {
            Point point = new Point(3, 4);
            Assert.AreEqual(5, Point.CalculateDistance(point));
        }
        [TestMethod]
        public void Test_PointDecrement()
        {
            Point point = new Point(5, 6);
            point--;
            Assert.AreEqual(new Point(4,5), point);
        }
        [TestMethod]
        public void Test_PointOperator()
        {
            Point point = new Point(5, 6);
            point = -point;
            Assert.AreEqual(new Point(6,5), point);
        }
        [TestMethod]
        public void Test_PointInt()
        {
            Point point = new Point(5, 6);
            int c = point;
            Assert.AreEqual(point.X, c);
        }
        [TestMethod]
        public void Test_PointDouble()
        {
            Point point = new Point(5, 6);
            double c = (double)point;
            Assert.AreEqual(point.Y, c);
        }
        [TestMethod]
        public void Test_PointDiffConst()
        {
            Point point = new Point(5, 6);
            point = point - 1;
            Assert.AreEqual(point.X, 4);
        }
        [TestMethod]
        public void Test_ConstDiffPoint()
        {
            Point point = new Point(5, 6);
            point = 1 - point;
            Assert.AreEqual(point.Y, 5);
        }
        [TestMethod]
        public void Test_PointDiffPoint()
        {
            Point point = new Point(5, 6);
            Point point2 = new Point(7, 8);
            double c = point - point2;
            Assert.AreEqual(c, point - point2);
        }
        [TestMethod]
        public void Test_PointToString()
        {
            Point point = new Point(5, 6);
            Assert.AreEqual("Координаты x = " + point.X + " y = " + point.Y, point.ToString());
        }
        [TestMethod]
        public void Test_PointSetters()
        {
            Point point = new Point();
            point.X = 5; point.Y = 6;
            Point point2 = new Point(5,6);
            Assert.AreEqual(point, point2);
        }
        [TestMethod]
        public void Test_PointArrayLength()
        {
            PointArray arr = new PointArray();
            Assert.AreEqual(0,arr.Length);
        }
        [TestMethod]
        public void Test_PointArrayLength2()
        {
            PointArray arr = new PointArray(5);
            Assert.AreEqual(5, arr.Length);
        }
        [TestMethod]
        public void Test_PointArrayApproximateValue()
        {
            Point point = new Point(5, 6);
            Point point2 = new Point(9, 9);
            Point point3 = new Point(0, 0);
            PointArray arr = new PointArray(3);
            arr[0] = point; arr[1] = point2; arr[2] = point3;
            double index;
            Assert.AreEqual(2, PointArray.ApproximateValue(arr,out index));
        }
        [TestMethod]
        public void Test_PointArrayIndexator()
        {
            Assert.ThrowsException<ArgumentException>(Test_PointArrayIndexatorMore);
            Assert.ThrowsException<ArgumentException>(Test_PointArrayIndexatorLess);
        }
        void Test_PointArrayIndexatorMore() 
        { 
            PointArray arr = new PointArray();
            Console.WriteLine(arr[7]);
        }
        void Test_PointArrayIndexatorLess()
        {
            PointArray arr = new PointArray();
            Console.WriteLine(arr[-2]);
        }
        [TestMethod]
        public void Test_PointArrayIndexator2()
        {
            Assert.ThrowsException<ArgumentException>(Test_PointArrayIndexator2More);
            Assert.ThrowsException<ArgumentException>(Test_PointArrayIndexator2Less);
        }
        void Test_PointArrayIndexator2More()
        {
            PointArray arr = new PointArray();
            arr[7] = new Point();
        }
        void Test_PointArrayIndexator2Less()
        {
            PointArray arr = new PointArray();
            arr[-2] = new Point();
        }
    }
}
