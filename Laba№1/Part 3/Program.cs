using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_OOP_Part_3_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение выражения: (a+b)^3 - (a^3+3*a*b^2)");
            Console.WriteLine("                         3a^2*b+b^3");
            double a = 1000;
            double b = 0.0001;
            double stepOne, stepTwo, stepThree, stepFour, stepFive;
            //double
            Console.WriteLine("1 шаг: (a+b)^3");
            stepOne = Math.Pow(a + b, 3);
            Console.WriteLine("Результат = "+stepOne + "\n" + "2 шаг: a^3+3*a*b^2");
            stepTwo = (Math.Pow(a,3)+3*a*Math.Pow(b,2));
            Console.WriteLine("Результат = " + stepTwo + "\n" + "3 шаг: (a+b)^3 - (a^3+3*a*b^2)");
            stepThree = (stepOne - stepTwo);
            Console.WriteLine("Результат = " + stepThree + "\n" + "4 шаг: 3a^2*b+b^3");
            stepFour = (3 * Math.Pow(a, 2) * b + Math.Pow(b, 3));
            Console.WriteLine("Результат = " + stepFour + "\n" + "5 шаг: ((a+b)^3 - (a^3+3*a*b^2)) / 3a^2*b+b^3");
            stepFive = (stepThree/stepFour);
            Console.WriteLine("Итоговый ответ(double) = " + stepFive);
            //float
            Console.WriteLine("\nFLOAT:");
            Console.WriteLine("1 шаг: (a+b)^3");
            stepOne = (float)Math.Pow(a + b, 3);
            Console.WriteLine("Результат = " + stepOne + "\n" + "2 шаг: a^3+3*a*b^2");
            stepTwo = (float)(Math.Pow(a, 3) + 3 * a * Math.Pow(b, 2));
            Console.WriteLine("Результат = " + stepTwo + "\n" + "3 шаг: (a+b)^3 - (a^3+3*a*b^2)");
            stepThree = (float)(stepOne - stepTwo);
            Console.WriteLine("Результат = " + stepThree + "\n" + "4 шаг: 3a^2*b+b^3");
            stepFour = (float)(3 * Math.Pow(a, 2) * b + Math.Pow(b, 3));
            Console.WriteLine("Результат = " + stepFour + "\n" + "5 шаг: ((a+b)^3 - (a^3+3*a*b^2)) / 3a^2*b+b^3");
            stepFive = (float)(stepThree / stepFour);
            Console.WriteLine("Итоговый ответ(float) = " + stepFive);
        }
    }
}
