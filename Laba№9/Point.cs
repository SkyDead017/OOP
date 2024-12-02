using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9_OOP_123
{
    public class Point
    {
        static Random rnd = new Random();
        private double x;
        private double y;
        private static int count;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public Point()
        {
            x = 0;
            y = 0;
            count++;
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            count++;
        }
        public void ShowCount()
        {
            Console.WriteLine("Количество созданных объектов = " + count);
        }
        public void Show()
        {
            Console.WriteLine("Координаты x = "+x+" y = "+y);
        }
        public double CalculateDistance()
        {
            double result = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return result;
        }
        public static double CalculateDistance(Point p)
        {
            double result = Math.Sqrt(Math.Pow(p.x, 2) + Math.Pow(p.y, 2));
            return result;
        }
        public static Point operator --(Point p)
        {
            --p.x;
            --p.y;
            return p;
        }
        public static Point operator -(Point p)
        {
            double tmp;
            tmp = p.x;
            p.x = p.y;
            p.y = tmp;
            return p;
        }
        public static implicit operator int(Point p)
        {
            return (int)p.x;
        }
        public static explicit operator double(Point p)
        {
            return p.y;
        }
        public static Point operator -(Point p, double k)
        {
            p.x -= k;
            return p;
        }
        public static Point operator -(double k, Point p)
        {
            p.y -= k;
            return p;
        }
        public static double operator -(Point p1, Point p2)
        {
            double result = Math.Sqrt(Math.Pow((p1.x-p2.x), 2) + Math.Pow((p1.y-p2.y), 2));
            return result;
        }
        public void RandInit()
        {
            X = rnd.Next(100);
            Y = rnd.Next(100);
            count++;
        }
        public override string ToString()
        {
            return "Координаты x = " + x + " y = " + y;
        }
        public override bool Equals(object obj)
        {
            if (obj is Point point)
            {
                return X == point.X && Y == point.Y;
            }
            return false;
        }
    }
}
