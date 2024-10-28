using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace Laba_5_OOP_
{
    internal class Program
    {
        private static int[] oneDimArr = new int[0]; 
        private static int[,] twoDimArr = new int[0,0];
        private static int[][] tornDimArr = new int[0][];
        static void Main(string[] args)
        {
            int columnOneDim=0;
            int lineTornDim=0;
            int lineTwoDim=0;
            int columnTwoDim=0;
            int choiseWorkArr=0;
            do
            {
                ShowBaseMenu();
                choiseWorkArr = CheckWrite();
                switch (choiseWorkArr)
                {
                    case 1:
                        int choiseCreateOneArr;
                        do
                        {
                            ShowCreateArr(oneDimArr, columnOneDim);
                            choiseCreateOneArr = CheckWrite();
                            Console.Clear();
                            switch (choiseCreateOneArr)
                            {
                                case 1:
                                    Console.WriteLine("Введите количество элементов в массиве: ");
                                    columnOneDim = CheckWrite();
                                    oneDimArr = CreateArrKeyboard(oneDimArr, columnOneDim);
                                    Display(oneDimArr, columnOneDim);
                                    WorkConsole();
                                    break;
                                case 2:
                                    Console.WriteLine("Введите количество элементов в массиве: ");
                                    columnOneDim = CheckWrite();
                                    oneDimArr = CreateArrRandom(oneDimArr, columnOneDim);
                                    Display(oneDimArr, columnOneDim);
                                    WorkConsole();
                                    break;
                                case 3:
                                    if(CheckArrEmpty(oneDimArr))
                                    {
                                        Console.WriteLine("Ошибка! Массив пустой");
                                    }
                                    else
                                    {
                                        oneDimArr = DeleteNechElem(oneDimArr);
                                        columnOneDim = oneDimArr.Length;
                                        WorkConsole();
                                    }
                                    
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;

                            }
                        } while (choiseCreateOneArr != 0);
                        break;
                    case 2:
                        int choiseCreateTwoArr;
                        do
                        {
                            ShowCreateArr(twoDimArr, lineTwoDim, columnTwoDim);
                            choiseCreateTwoArr = CheckWrite();
                            Console.Clear();
                            switch (choiseCreateTwoArr)
                            {
                                case 1:
                                    Console.WriteLine("Введите количество строк в массиве: ");
                                    lineTwoDim = CheckWrite();
                                    Console.WriteLine("Введите количество столбцов в массиве: ");
                                    columnTwoDim = CheckWrite();
                                    twoDimArr = CreateArrKeyboard(lineTwoDim, columnTwoDim);
                                    Display(twoDimArr, lineTwoDim, columnTwoDim);
                                    WorkConsole();
                                    break;
                                case 2:
                                    Console.WriteLine("Введите количество строк в массиве: ");
                                    lineTwoDim = CheckWrite();
                                    Console.WriteLine("Введите количество столбцов в массиве: ");
                                    columnTwoDim = CheckWrite();
                                    twoDimArr = CreateArrRandom(lineTwoDim, columnTwoDim);
                                    Display(twoDimArr, lineTwoDim, columnTwoDim);
                                    WorkConsole();
                                    break;
                                case 3:
                                    Console.WriteLine("Сколько строк необходимо добавить? ");
                                    int k = CheckWrite();
                                    if (CheckArrEmpty(twoDimArr, k))
                                    {
                                        twoDimArr = AddKLine(twoDimArr, columnTwoDim, lineTwoDim, k);
                                        lineTwoDim += k;
                                    }
                                    Display(twoDimArr, lineTwoDim, columnTwoDim);
                                    WorkConsole();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;

                            }
                        } while (choiseCreateTwoArr != 0);

                        break;
                    case 3:
                        int choiseCreateTornArr;
                        do
                        {
                            ShowCreateArr(tornDimArr);
                            choiseCreateTornArr = CheckWrite();
                            Console.Clear();
                            switch (choiseCreateTornArr)
                            {
                                case 1:
                                    Console.WriteLine("Введите количество строк в массиве: ");
                                    lineTornDim = CheckWrite();
                                    tornDimArr = CreateArrKeyboard(lineTornDim);
                                    Display(tornDimArr);
                                    WorkConsole();
                                    break;
                                case 2:
                                    Console.WriteLine("Введите количество строк в массиве: ");
                                    lineTornDim = CheckWrite();
                                    tornDimArr = CreateArrRandom(lineTornDim);
                                    Display(tornDimArr);
                                    WorkConsole();
                                    break;
                                case 3:
                                    if (tornDimArr.Length == 0)
                                    {
                                        Console.WriteLine("Ошибка! Массив пуст");
                                    }
                                    if(tornDimArr.Length > 0)
                                    {
                                        Console.WriteLine("Введите номер строки которую необходимо удалить ");
                                        int k;
                                        do
                                        {
                                            k = CheckWrite();
                                            if (k < 1)
                                            {
                                                Console.WriteLine("Ошибка! Номера строк начинаются с 1");
                                            }
                                            if (k > tornDimArr.Length)
                                            {
                                                Console.WriteLine("Несуществующая строка");
                                            }
                                        } while (k < 1 || k > tornDimArr.Length);
                                        tornDimArr = DeleteNumLine(tornDimArr, k);
                                        Display(tornDimArr);
                                        WorkConsole();
                                    }
                                    
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        }while(choiseCreateTornArr!=0);
                        break;
                    case 4:
                        AllDisplay(oneDimArr, columnOneDim, twoDimArr, lineTwoDim, columnTwoDim, tornDimArr, lineTornDim);
                        WorkConsole();
                        break;
                    case 0:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break; 
                }
            } while (choiseWorkArr != 0);
        }

        static void AllDisplay(int[] arrOneDim, int count, int[,] arrTwoDim, int lineTwo, int columnTwo, int[][] arrTornDim, int lineTornDim)
        {
            if (count > 0)
            {
                Display(arrOneDim, count);
            }
            else { Console.WriteLine("Массив не задан"); }
            if (lineTwo > 0 && columnTwo>0)
            {
                Display(arrTwoDim, lineTwo, columnTwo);
            }
            else { Console.WriteLine("Массив не задан"); }
            if (arrTornDim.Length > 0 && lineTornDim > 0)
            {
                Display(arrTornDim);
            }
            else { Console.WriteLine("Массив не задан"); }
        }
        static void Display(int [] arr, int count)
        {
            Console.WriteLine("Одномерный массив: ");
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пустой");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            Console.WriteLine();
        }
        static void Display(int[,] arr, int line, int column)
        {
            Console.WriteLine("Двумерный массив: ");
            if(arr.Length == 0)
            {
                Console.WriteLine("Массив пустой");
            }
            else
            {
                for (int i = 0; i < line; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Display(int[][] arr)
        {
            Console.WriteLine("Рваный массив: ");
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пустой");
            }
            else
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        Console.Write(arr[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static int[] CreateArrKeyboard(int[] arr, int count)
        {
            Console.WriteLine("Введите элементы одномерного массива: ");
            for (int i = 0; i < count; i++)
            {
                Array.Resize(ref arr, count);
                int input;
                int.TryParse(Console.ReadLine(), out input);
                arr[i] = input;
            }
            return arr;
        }

        static int[,] CreateArrKeyboard(int line, int column)
        {
            Console.WriteLine("Введите элементы двумерного массива: ");
            int[,] arr = new int[line, column];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int input;
                    int.TryParse(Console.ReadLine(), out input);
                    arr[i,j] = input;
                }
            }
            return arr;
        }

        static int[][] CreateArrKeyboard(int line)
        {
            int[][] arr=new int[line][];
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine("Введите количество элементов в строке " + (i + 1));
                int countElem = CheckWrite();
                arr[i] = new int[countElem];
                Console.WriteLine("Введите элементы строки: ");
                for (int j = 0; j < countElem; j++)
                {
                    int input;
                    int.TryParse(Console.ReadLine(), out input);
                    arr[i][j] = input;
                }
            }
            return arr;
        }

        static int[] CreateArrRandom(int[] arr, int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                Array.Resize(ref arr, count);
                arr[i] = rand.Next(-100, 100);
            }
            return arr;
        }

        static int[,] CreateArrRandom(int line, int column)
        {
            Random rand = new Random();
            int[,] arr = new int[line, column];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }
            return arr;
        }

        static int[][] CreateArrRandom(int line)
        {
            Random rand = new Random();   
            int[][] arr = new int[line][];
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine("Введите количество элементов в строке " + (i+1));
                int countElem = CheckWrite();
                arr[i] = new int[countElem];
                for (int j = 0; j < countElem; j++)
                {
                    arr[i][j] = rand.Next(-100, 100);   
                }
            }
            return arr;
        }
        static void ShowBaseMenu()
        {
            Console.WriteLine("------------");
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.WriteLine("------------");
            Console.WriteLine("1. Работать с одномерным динамическим массивом");
            Console.WriteLine("2. Работать с двумерным динамическим массивом");
            Console.WriteLine("3. Работать с рваным динамическим массивом");
            Console.WriteLine("4. Напечатать все массивы");
            Console.WriteLine("0. Выход");
        }

        static void ShowCreateArr(int[]arr, int column)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("РАБОТА С ОДНОМЕРНЫМ МАССИВОМ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Задать массив с клавиатуры");
            Console.WriteLine("2. Задать массив случайно");
            Console.WriteLine("3. Удалить все нечетные элементы");
            Console.WriteLine("0. Назад");
            Display(arr,column);
        }
        static void ShowCreateArr(int[,]arr, int line, int column)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("РАБОТА С ДВУМЕРНЫМ МАССИВОМ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Задать массив с клавиатуры");
            Console.WriteLine("2. Задать массив случайно");
            Console.WriteLine("3. Добавить К строк в начало матрицы");
            Console.WriteLine("0. Назад");
            Display(arr, line, column);
        }
        static void ShowCreateArr(int[][]arr)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("РАБОТА С РВАНЫМ МАССИВОМ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Задать массив с клавиатуры");
            Console.WriteLine("2. Задать массив случайно");
            Console.WriteLine("3. Удалить строку с заданным номером");
            Console.WriteLine("0. Назад");
            Display(arr);
        }

        public static void WorkConsole()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static int[] DeleteNechElem(int []arr)
        {
            int[] newArr = arr.Where(x => x % 2 == 0).ToArray();
            Display(newArr, newArr.Length);
            return newArr;
        }

        static int[,] AddKLine(int[,]arr, int column , int line , int k)
        {
            int choiseComand;
            int[,] newArr = new int[line + k, column];
            do
            {
                Console.WriteLine("1. Задать новые строки с клавиатуры");
                Console.WriteLine("2. Задать новые строки рандомом");
                choiseComand = CheckWrite();
                switch (choiseComand)
                {
                    case 1:
                        for (int i = 0; i < k; i++)
                        {
                            Console.WriteLine("Введите " + column + " элементов в новую строку");
                            for (int j = 0; j < column; j++)
                            {
                                int input;
                                int.TryParse(Console.ReadLine(), out input);
                                newArr[i, j] = input;
                            }
                        }
                        break;
                    case 2:
                        Random random = new Random();
                        for (int i = 0; i < k; i++)
                        {
                            for (int j = 0; j < column; j++)
                            {
                                newArr[i, j] = random.Next(-100, 100);
                            }
                        }
                        break;
                }
                if(choiseComand != 1 && choiseComand != 2)
                {
                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                }
            } while (choiseComand != 1 && choiseComand != 2);
            for (int i = k; i < line + k; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    newArr[i, j] = arr[i - k, j];
                }
            }
            return newArr;
        }
        static int[][] DeleteNumLine(int[][]arr, int k)
        {
            int[][] newArr = new int[arr.Length - 1][];

            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (i != k - 1)
                {
                    newArr[j] = new int[arr[i].Length];
                    for (int l = 0; l < arr[i].Length; l++)
                    {
                        newArr[j][l] = arr[i][l];
                    }
                    j++;
                }
            }
            return newArr;
        }
        static int CheckWrite()
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok || input<0)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok || input<0);
            return input;
        }
        static bool CheckArrEmpty(int[] arr)
        {
            if (arr.Length == 0)
            {
                return true;
            }
            return false;
        }
        static bool CheckArrEmpty(int[,] arr, int k)
        {
            if (k != 0)
            {
                return true;
            }
            return false;
        }
    }
}
