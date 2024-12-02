using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9_OOP_123
{
    public class PointArray
    {
        private Point[] arrPoints;
        public int Length
        {
            get
            {
                if (arrPoints == null)
                {
                    return 0;
                }
                return arrPoints.Length;
            }
        }

        public PointArray()
        {
            arrPoints = new Point[0];
        }

        public PointArray(int count)
        {
            arrPoints = new Point[count];
            Random random = new Random();
            for(int i = 0; i < count; i++)
            {
                arrPoints[i] = new Point(random.Next(1,100), random.Next(1,100));
            }
        }
        public static int ApproximateValue(PointArray arr, out double result)
        {
            result = arr[0].CalculateDistance();
            int remIndex = 0;
            for(int i=1; i<arr.Length; i++)
            {
                if (arr[i].CalculateDistance() < result)
                {
                    result = arr[i].CalculateDistance();
                    remIndex = i;
                }
            }
            return remIndex;
        }

        public PointArray(int count, bool isUserInput)
        {
            arrPoints = new Point[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите координаты для точки "+ (i+1));
                double x = CheckWrite();
                double y=CheckWrite();
                arrPoints[i] = new Point(x, y);
            }
        }

        public void DisplayPoints()
        {
            if (arrPoints.Length > 0)
            {
                Console.WriteLine(arrPoints.Length + " точек:");
                for (int i = 0; i < arrPoints.Length; i++)
                {
                    Console.WriteLine("Точка " + (i + 1) + ": " + arrPoints[i].ToString());
                }
            }
            if (arrPoints.Length == 0)
            {
                Console.WriteLine("Коллекция пустая");
            }
        }
        public Point this[int index]
        {
            get
            {
                if (index < 0 || index >= arrPoints.Length)
                {
                    throw new ArgumentException("Индекс выходит за границы коллекции!");
                }
                return arrPoints[index];
            }
            set {
                if (index < 0 || index >= arrPoints.Length)
                {
                    throw new ArgumentException("Индекс выходит за границы коллекции!");
                }
                arrPoints[index] = value;
            }
        }
        public static double CheckWrite()
        {
            bool ok;
            double input;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out input);
                if (!ok)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok);
            return input;
        }
    }
}
