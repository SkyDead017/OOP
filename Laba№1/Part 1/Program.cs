using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_OOP_Part_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            double x;
            Console.WriteLine("Введите n:");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("ОШИБКА! Введите целое значение!");
            }
            Console.WriteLine("Введите m:");
            while (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("ОШИБКА! Введите целое значение!");
            }
            if (n == 0)
            {
                Console.Write("m=" + m + " n=" + n);
                Console.WriteLine(" m++/n-- = НЕЛЬЗЯ ВЫЧИСЛИТЬ");
            }
            else
            {
                Console.Write("m=" + m + " n=" + n);
                Console.WriteLine(" m++/n-- = " + (m++ / n--));
            }
            Console.Write("m=" + m + " n=" + n);
            Console.WriteLine(" ++m<n-- = " + (++m < n--));
            Console.Write("m=" + m + " n=" + n);
            Console.WriteLine(" n-->m = " + (n-- > m));
            Console.WriteLine("Введите x:");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("ОШИБКА! Введите целое значение!");
            }

            // Обработка корня нечетной степени

            // Проверка на отрицательные значения для корня нечетной степени
            double badRoot = Math.Pow((Math.Pow(x, 2) + Math.Pow(x, 3)), 0.2);
            if (Math.Pow(x, 2) + Math.Pow(x, 3) < 0)
            {
                badRoot = -Math.Pow(-1 * (Math.Pow(x, 2) + Math.Pow(x, 3)), 0.2);
            }

            double result = Math.Sin(Math.Pow(x, 3)) + Math.Pow(x, 4) + badRoot;

            Console.WriteLine("sin(x^3)+x^4+(x^2+x^3)^(1/5) = " + result);
        }
    }
}
