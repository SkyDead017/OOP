using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_OOP_Part_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float x, y;
            Console.WriteLine("Проверка принадлежности точки");
            Console.WriteLine("Введите координату x: ");
            while (!float.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("ОШИБКА! Введите число!");
            }
            Console.WriteLine("Введите координату y: ");
            while (!float.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("ОШИБКА! Введите число!");
            }
            bool flag=false;
            if(y<=x+2 && y>=0 && y <= -x + 2)
            {
                flag = true;
            }
            if (flag)
            {
                Console.WriteLine("Точка принадлежит заштрихованной области");
            }
            else
            {
                Console.WriteLine("Точка НЕ принадлежит заштрихованной области");
            }
        }
    }
}
