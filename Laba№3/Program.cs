using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3_OOP_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double left = 0.1;
            double right = 0.8;
            int n = 30;
            double epsil=0.0001;
            double step = (right - left) / 10;
            for (double x = left; x <= right; x += step)
            {
                double y = GetFunctionY(x);
                double SN = CalculateSN(x, n);
                double SE = CalculateSE(x, epsil);
                Console.WriteLine($"x= { x:F4} SE={SE:F4} SN={SN:F4} y={y:F4}");
            }
        }
        public static double GetFunctionY(double x)
        {
            return (1 / 4.0) * Math.Log((1 + x) / (1 - x)) + (1 / 2.0) * Math.Atan(x);
        }
        public static double CalculateSN(double x, int n)
        {
            double a0 = x;
            double b0 = 1;
            double sum = x;
            for(int i = 1; i <= n; i++)
            {
                a0 *= Math.Pow(x, 4);
                b0 += 4;
                sum += a0/b0;
            }
            return sum;
        }
        public static double CalculateSE(double x, double epsil)
        {
            double a0 = x;
            double b0 = 1;
            double sum = x;
            while (a0/b0 > epsil)
            {
                a0 *= Math.Pow(x, 4);
                b0 += 4;
                sum += a0 / b0;
            }
            return sum;
        }
    }
}
