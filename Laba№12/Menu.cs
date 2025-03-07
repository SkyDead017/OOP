using System;
using ProductionLib;
using Lab12.Collection;
namespace Laba_12_OOP_
{
    //протестируй GetEnumerator, метод Contains, CopyTo и методы, где параметр - KeyValuePair<TKey, TValue>
    internal class Menu
    {
        static void Main(string[] args)
        {
            var ht = new HashTable<string, Production>(4);
            Production product = new Production();
            product.RandInit();
            //string key = ht.RandKey();
            ht["iop"] = product;
            ht.Display();
            Console.ReadKey();
            Production product1 = new Production();
            product1.RandInit();
            ht.Add("key", product1);
            ht.Display();
            Console.ReadKey();
            Production product2 = new Production();
            product2.RandInit();
            ht.Add("pip", product2);
            ht.Display();
            Console.ReadKey();
            Production product3 = new Production("Одежда", 22222);
            ht.Add("pop", product3);
            ht.Display();
            Console.ReadKey();

            Console.WriteLine("Удаление элемента с ключем KEY");
            ht.Remove("key");
            ht.Display();
            Console.ReadKey();

            Console.WriteLine("Поиск элемента по значению [Одежда, 22222]");
            if (ht.ContainsValue(product3))
            {
                Console.WriteLine("Элемент найден");
            }
            else { Console.WriteLine("Элемент не найден"); }
            ht.Display();
            Console.ReadKey();

            Console.WriteLine("ГЛУБОКОЕ КОПИРОВАНИЕ");
            var ht2 = (HashTable<string, Production>)ht.Clone();
            Console.WriteLine("Исходная");
            ht.Display();
            Console.WriteLine("Копия");
            ht2.Display();
            Production product4 = new Production();
            product4.RandInit();
            Console.WriteLine("Добавляем новый элемент в исходную таблицу");
            ht.Add("newEl1", product4);
            Console.WriteLine("Исходная");
            ht.Display();
            Console.WriteLine("Копия");
            ht2.Display();
            Console.ReadKey();
            Console.WriteLine("ПОВЕРХНОСТНОЕ КОПИРОВАНИЕ");
            Console.Write("Добавляем элемент");
            Production product5 = new Production();
            product5.RandInit();
            ht2 = (HashTable<string, Production>)ht.ShallowCopy();
            ht.Add("newEl", product5);
            ht.Display();
            ht2.Display();
            Console.ReadKey();
        }
    }
}
