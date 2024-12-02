using System;
using PointClass;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9_OOP_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            PointArray arr = null;
            int choiseExample;
            do
            {
                ShowMainText();
                p.Show();
                try
                {
                    arr.DisplayPoints();
                }
                catch (Exception)
                {
                    Console.WriteLine("Коллекция не создана");
                }
                choiseExample = CheckWrite();
                switch (choiseExample)
                {
                    case 1:
                        Console.Clear();
                        Example1(p);
                        break;
                    case 2:
                        Console.Clear();
                        Example2(p);
                        break;
                    case 3:
                        Console.Clear();
                        Example3(ref arr);
                        break;
                    case 4:
                        Console.Clear();
                        p.ShowCount();
                        break;
                    case 0:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break;
                }
            } while (choiseExample != 0);
        }
        static void Example1(Point p)
        {
            int choiseInExample1;
            
            do
            {
                ShowTextExample1();
                p.Show();
                choiseInExample1 = CheckWrite();
                switch (choiseInExample1)
                {
                    case 1:
                        Console.Clear();
                        int choiseRandOrHand;
                        do
                        {
                            ShowTextExample1Choise1();
                            p.Show();
                            choiseRandOrHand = CheckWrite();
                            switch (choiseRandOrHand)
                            {
                                case 1:
                                    double x, y;
                                    Console.WriteLine("Введите x: ");
                                    x = PointArray.CheckWrite();
                                    Console.WriteLine("Введите y: ");
                                    y = PointArray.CheckWrite();
                                    Point p1 = new Point(x, y);
                                    p.X = p1.X;
                                    p.Y = p1.Y;
                                    p.Show();
                                    WorkConsole();
                                    break;
                                case 2:
                                    p.RandInit();
                                    p.Show();
                                    WorkConsole();
                                    break;
                                case 0:
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        } while (choiseRandOrHand != 0);
                        break;
                    case 2:
                        double resultFun;
                        resultFun = Point.CalculateDistance(p);
                        Console.WriteLine("Расстояние от точки до начала координат = "+resultFun);
                        WorkConsole();
                        break;
                    case 3:
                        double resultMet;
                        resultMet = p.CalculateDistance();
                        Console.WriteLine("Расстояние от точки до начала координат = " + resultMet);
                        WorkConsole();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break;
                }
            } while (choiseInExample1!=0);
        }
        static void Example2(Point p)
        {
            int choiseExample2;
            do
            {
                ShowTextExample2();
                p.Show ();
                choiseExample2 = CheckWrite();
                switch(choiseExample2)
                {
                    case 1:
                        Console.Clear();
                        int choiseUnOperation;
                        do
                        {
                            ShowTextExample2Choise1();
                            p.Show();
                            choiseUnOperation = CheckWrite();
                            switch (choiseUnOperation)
                            {
                                case 1:
                                    --p;
                                    p.Show();
                                    WorkConsole();
                                    break;
                                case 2:
                                    p = -p;
                                    p.Show();
                                    WorkConsole();
                                    break;
                                case 0:
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        }while (choiseUnOperation != 0);
                        break;
                    case 2:
                        Console.Clear();
                        int choisePrOperation;
                        do
                        {
                            ShowTextExample2Choise2();
                            choisePrOperation = CheckWrite();
                            switch (choisePrOperation)
                            {
                                case 1:
                                    int intX = p;
                                    Console.WriteLine(intX);
                                    WorkConsole();
                                    break;
                                case 2:
                                    double doubleY = (double)p;
                                    Console.WriteLine(doubleY);
                                    WorkConsole();
                                    break;
                                case 0:
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        } while (choisePrOperation != 0);
                        break;
                    case 3:
                        Console.Clear();
                        int choiseBinOperation;
                        do
                        {
                            ShowTextExample2Choise3();
                            choiseBinOperation = CheckWrite();
                            switch (choiseBinOperation)
                            {
                                case 1:
                                    Console.WriteLine("Существующая точка: ");
                                    p.Show();
                                    Console.WriteLine("Введите число на которое необходимо уменьшить координату x: ");
                                    double k = CheckWrite();
                                    p = p-k;
                                    Console.WriteLine("Измененная точка: ");
                                    p.Show();
                                    WorkConsole();
                                    break;
                                case 2:
                                    Console.WriteLine("Существующая точка: ");
                                    p.Show();
                                    Console.WriteLine("Введите число на которое необходимо уменьшить координату x: ");
                                    double c = CheckWrite();
                                    p = c - p;
                                    Console.WriteLine("Измененная точка: ");
                                    p.Show();
                                    WorkConsole();
                                    break;
                                case 3:
                                    Console.WriteLine("Существующая точка: ");
                                    p.Show();
                                    Console.WriteLine("Введите координату до которой необходимо найти расстояние от существующей точки");
                                    double x, y;
                                    Console.WriteLine("Введите x: ");
                                    x = PointArray.CheckWrite();
                                    Console.WriteLine("Введите y: ");
                                    y = PointArray.CheckWrite();
                                    Point p2 = new Point(x, y);
                                    double result = p - p2;
                                    Console.WriteLine("Расстояние от существующей точки до новой точки p = " + result);
                                    WorkConsole();
                                    break;
                                case 0:
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        } while (choiseBinOperation != 0);
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break;
                }
            }while(choiseExample2 != 0);
        }
        static void Example3(ref PointArray arr)
        {
            int choiseInExample3;

            do
            {
                ShowTextExample3();
                try
                {
                    arr.DisplayPoints();
                }
                catch (Exception)
                {
                    Console.WriteLine("Коллекция не создана");
                }
                choiseInExample3 = CheckWrite();
                switch (choiseInExample3)
                {
                    case 1:
                        arr = new PointArray();
                        arr.DisplayPoints();
                        WorkConsole();
                        break;
                    case 2:
                        Console.WriteLine("Введите количество элементов в коллекции: ");
                        int count = CheckWrite();
                        arr= new PointArray(count);
                        arr.DisplayPoints();
                        WorkConsole();
                        break;
                    case 3:
                        Console.WriteLine("Введите количество элементов в коллекции: ");
                        int countCl = CheckWrite();
                        arr= new PointArray(countCl, true);
                        arr.DisplayPoints();
                        WorkConsole();
                        break;
                    case 4:
                        Console.WriteLine("Введите номер элемента, который необходимо посмотреть: ");
                        int numEl = CheckWrite();
                        try
                        {
                            Console.WriteLine("Элемент под номером " + numEl + " = " + arr[numEl - 1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        WorkConsole();
                        break;
                    case 5:
                        int minPoint = PointArray.ApproximateValue(arr, out double result);
                        Console.WriteLine("Самая приближенная точка к началу координат : Точка " + (minPoint+1));
                        arr[minPoint].Show();
                        Console.WriteLine("Расстояние от точки до начала координат = "+result);
                        WorkConsole();
                        break;
                    case 6:
                        Console.WriteLine("Введите номер точки");
                        int k = CheckWrite();
                        Point p = new Point(11,17);
                        try
                        {
                            arr[k-1] = p;
                        }
                        catch
                        {
                            Console.WriteLine("Точки не существует");
                        }
                        WorkConsole();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break;
                }
            } while (choiseInExample3 != 0);
        }

        
        static void ShowMainText()
        {
            Console.WriteLine("------------");
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.WriteLine("------------");
            Console.WriteLine("1. Задание 1");
            Console.WriteLine("2. Задание 2");
            Console.WriteLine("3. Задание 3");
            Console.WriteLine("4. Количество созданных объектов");
            Console.WriteLine("0. Выход");
        }
        static void ShowTextExample1()
        {
            Console.WriteLine("1. Задать точку");
            Console.WriteLine("2. Вычислить расстояние от точки до начала координат(Функция)");
            Console.WriteLine("3. Вычислить расстояние от точки до начала координат(Метод)");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextExample1Choise1()
        {
            Console.WriteLine("1. Задать точку c клавиатуры");
            Console.WriteLine("2. Задать точку c помощью рандома");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextExample2()
        {
            Console.WriteLine("1. Унарные операции");
            Console.WriteLine("2. Операции приведения типа");
            Console.WriteLine("3. Бинарные операции");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextExample2Choise1()
        {
            Console.WriteLine("1. Уменьшить координаты x и y на 1");
            Console.WriteLine("2. Поменять координаты x и y местами");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextExample2Choise2()
        {
            Console.WriteLine("1. Неявное приведение типа к int");
            Console.WriteLine("2. Явное приведение типа к double");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextExample2Choise3()
        {
            Console.WriteLine("1. Уменьшить координату x");
            Console.WriteLine("2. Уменьшить координату y");
            Console.WriteLine("3. Вычислить расстояние до точки p");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextExample3()
        {
            Console.WriteLine("1. Создать коллекцию без параметров");
            Console.WriteLine("2. Создать коллекцию и заполнить её случайными точками");
            Console.WriteLine("3. Создать коллекцию и заполнить её с клавиатуры");
            Console.WriteLine("4. Посмотреть элемент в массиве");
            Console.WriteLine("5. Найти самую приближенную точку к началу координат");
            Console.WriteLine("6. Перезаписать точку");
            Console.WriteLine("0. Назад");
        }
        public static int CheckWrite()
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok);
            return input;
        }
        
        public static void WorkConsole()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
