using System;
using ProductionLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace laba_10_OOP_
{
    public class ProgramMenu
    {
        List<Production> arr = new List<Production>();
        public void Menu()
        {
            int choiseAction;
            bool infSortCountProd = false;
            do
            {
                Console.Clear();
                ShowMainMenu();
                choiseAction = CheckWrite();
                switch (choiseAction)
                {
                    case 1:
                        Console.Clear();
                        ShowInstruction();
                        CreateArr();
                        WorkConsole();
                        break;
                    case 2:
                        PrintArr(arr);
                        WorkConsole();
                        break;
                    case 3:
                        if (arr.Count > 0)
                        {
                            Console.Clear();
                            ShowTextChoise3();
                            int choiseSort = CheckWrite();
                            switch (choiseSort)
                            {
                                case 1:
                                    arr.Sort(new SortByAlphabet());
                                    PrintArr(arr);
                                    WorkConsole();
                                    break;
                                case 2:
                                    arr.Sort();
                                    infSortCountProd = true;
                                    PrintArr(arr);
                                    WorkConsole();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Массив пустой");
                            WorkConsole();
                        }
                        break;
                    case 4:
                        if (arr.Count > 0 && infSortCountProd == true)
                        {
                            Production searchable = new Production();
                            searchable.Init();
                            BinarySearch(searchable);
                        }
                        else
                        {
                            if(arr.Count == 0)
                            {
                                Console.WriteLine("Массив пустой");
                            }
                            else
                            {
                                Console.WriteLine("Массив не отсортирован по количеству выпускаемой продукции");
                            }
                        }
                        WorkConsole();
                        break;
                    case 5:
                        Money originalKurs = new Money();
                        Console.WriteLine("Оригинальный экземпляр:");
                        originalKurs.RandInit();
                        originalKurs.Show();
                        Money clonedKurs = (Money)originalKurs.Clone();
                        Console.WriteLine("Глубокое копирование:");
                        clonedKurs.Show();
                        Money shallowCopyKurs = (Money)originalKurs.ShallowCopy();
                        Console.WriteLine("Поверхностное копирование:");
                        shallowCopyKurs.Show();
                        originalKurs.kurs.Add(999999);
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Оригинальный(измененный) экземпляр:");
                        originalKurs.Show();
                        Console.WriteLine("Глубокое копирование:");
                        clonedKurs.Show();
                        Console.WriteLine("Поверхностное копирование:");
                        shallowCopyKurs.Show();
                        WorkConsole();
                        break;
                    case 6:
                        PrintArr(arr);
                        Console.WriteLine("-----------------------------------------------------");
                        PrintArrInfo(arr);
                        WorkConsole();  
                        break;
                    case 7:
                        if (arr.Count > 0)
                        {
                            Console.Clear();
                            ShowTextChoise7();
                            int choiseQuery = CheckWrite();
                            switch (choiseQuery)
                            {
                                case 1:
                                    QueryTypeProd();
                                    WorkConsole();
                                    break;
                                case 2:
                                    QueryCountProdMore();
                                    WorkConsole();
                                    break;
                                case 3:
                                    QueryTypeDepartment();
                                    WorkConsole();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Массив пустой");
                            WorkConsole();
                        }
                        break;
                    case 8:
                        IInit[] allArr = new IInit[5];
                        allArr[0] = new Production();
                        allArr[1] = new Factory();
                        allArr[2] = new Department();
                        allArr[3] = new WorkShop();
                        allArr[4] = new Money();
                        foreach (var item in allArr)
                        {
                            item.RandInit();
                            if(item is Production prod)
                            {
                                prod.Show();
                            }
                            else if (item is Money money)
                            {
                                money.Show();
                            }
                            Console.WriteLine("");
                        }
                        WorkConsole();
                        break;
                    case 0:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break;
                }
            } while (choiseAction != 0);
        }

        public void QueryTypeDepartment()
        {
            Console.WriteLine("Выберете тип цеха из списка: Цех раскроя, Швейный цех, Цех отделки, \nЦех контроля качества, Цех упаковки, Цех обработки тканей, Дизайнерский цех ");
            string type = Console.ReadLine();
            int count = 0;
            foreach (var item in arr)
            {
                if (item is Department)
                {
                    if (((Department)item).TypeDepartment == type)
                    {
                        count++;
                        item.Show();
                        Console.WriteLine();
                    }
                }
            }
            if(count == 0)
            {
                Console.WriteLine("Таких производств не нашлось");
            }
        }
        public void QueryCountProdMore()
        {
            foreach (var item in arr)
            {
                if(item is Production)
                {
                    if (item.CountProd > 500000)
                    {
                        item.Show();
                        Console.WriteLine();
                    }
                }
            }
        }
        public void QueryTypeProd()
        {
            SortedSet<string> setType = new SortedSet<string>();
            foreach (var item in arr)
            {
                setType.Add(item.Type);
            }
            Console.WriteLine("Типы продукции: ");
            foreach (var item in setType)
            {
                Console.Write(item + "; ");
            }
            Console.WriteLine();
        }
        public void CreateArr()
        {
            bool flag = false;
            while (!flag)
            {
                ConsoleKey a = Console.ReadKey().Key;
                switch (a)
                {
                    case ConsoleKey.P:
                        arr.Add(new Production());
                        break;
                    case ConsoleKey.F:
                        arr.Add(new Factory());
                        break;
                    case ConsoleKey.D:
                        arr.Add(new Department());
                        break;
                    case ConsoleKey.W:
                        arr.Add(new WorkShop());
                        break;
                    case ConsoleKey.Enter:
                        flag = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        ShowInstruction();
                        break;
                }
            }
            foreach (var item in arr)
            {
                item.RandInit();
                item.Show();
                Console.WriteLine("");
            }
        }
        public void PrintArr(List<Production> arr)
        {
            if(arr.Count>0)
            {
                foreach (var item in arr)
                {
                    item.Show();
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Массив пуст");
            }
        }
        public void PrintArrInfo(List<Production> arr)
        {
            if (arr.Count > 0)
            {
                foreach (var item in arr)
                {
                    item.ShowInfo();
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Массив пуст");
            }
        }
        public void BinarySearch(Production elem)
        {
            if (arr.BinarySearch(elem, new SortByCountProd()) >= 0)
                Console.WriteLine("Такой элемент содержится");
            else
                Console.WriteLine("Такого элемента в массиве нет");
        }
        static int CheckWrite()
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
        static void WorkConsole()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            Console.Clear();
        }
        static void ShowInstruction()
        {
            Console.WriteLine("ИНСТРУКЦИЯ");
            Console.WriteLine("p - Production");
            Console.WriteLine("f - Factory");
            Console.WriteLine("d - Department");
            Console.WriteLine("w - WorkShop");
            Console.WriteLine("Enter - Конец создания экземпляров");
            Console.WriteLine("Вводить в формате: wwppddf (вводить в любом порядке и в любом количестве)");
        }
        static void ShowMainMenu()
        {
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.WriteLine("1. Создать экземпляры класса");
            Console.WriteLine("2. Вывести экземпляры класса на экран");
            Console.WriteLine("3. Отсортировать экземпляры класса");
            Console.WriteLine("4. Бинарный поиск");
            Console.WriteLine("5. Клонирование экземпляров класса");
            Console.WriteLine("6. Виртуальный и не виртуальный вывод");
            Console.WriteLine("7. Запросы");
            Console.WriteLine("8. Массив типа IInit");
            Console.WriteLine("0. Выход");
        }
        static void ShowTextChoise1()
        {
            Console.WriteLine("1. Задать экземпляры c клавиатуры");
            Console.WriteLine("2. Задать экземпляры c помощью рандома");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextChoise3()
        {
            Console.WriteLine("1. Отсортировать по типу продукции");
            Console.WriteLine("2. Отсортировать по количеству выпускаемой продукции");
            Console.WriteLine("0. Назад");
        }
        static void ShowTextChoise7()
        {
            Console.WriteLine("1. Все типы продукции, которые производятся на этом производстве");
            Console.WriteLine("2. Все производства у которых кол-во выпускаемой продукции > 500000");
            Console.WriteLine("3. Все производства c заданным типом цеха");
            Console.WriteLine("0. Назад");
        }
    }
}
