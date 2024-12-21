using System.Diagnostics;
using ProductionLib;

namespace lab11
{
    internal class Program
    {
        static Stopwatch timer = new Stopwatch();
        static void Main(string[] args)
        {
            TestCollections tests = new TestCollections(1000);

            Factory first = new Factory(
                tests.factQueue.Peek().Type,
                tests.factQueue.Peek().CountProd,
                tests.factQueue.Peek().CountDepartments);
        
            Factory last = tests.GetLastTest();
            Factory lastCopy = new Factory(
                last.Type,
                last.CountProd,
                last.CountDepartments);

            Factory middle = tests.GetMiddleTest();
            Factory middleCopy = new Factory(
                middle.Type,
                middle.CountProd,
                middle.CountDepartments);

            Factory custom = new Factory("ТИП", 99999, 999);
            
            Console.WriteLine("Queue<Factory>: ");
            TimeQueueTestLookup(tests, first, lastCopy, middleCopy, custom);
            Console.WriteLine();

            Console.WriteLine("Queue<string>: ");
            TimeQueueStringLookup(tests, first, lastCopy, middleCopy, custom);
            Console.WriteLine();

            Console.WriteLine("Dictionary<Production, Factory> (ContainsKey): ");
            TimeDictionaryProdKeyLookup(tests, first, lastCopy, middleCopy, custom);
            Console.WriteLine();

            Console.WriteLine("Dictionary<string, Factory> (ContainsKey): ");
            TimeDictionaryStringKeyLookup(tests, first, lastCopy, middleCopy, custom);
            Console.WriteLine();

            Console.WriteLine("Dictionary<Production, Factory> (ContainsValue): ");
            TimeDictionaryProdValueLookup(tests, first, lastCopy, middleCopy, custom);
            Console.WriteLine();

            Console.WriteLine("Dictionary<string, Factory> (ContainsValue): ");
            TimeDictionaryStringValueLookup(tests, first, lastCopy, middleCopy, custom);
            Console.WriteLine();
        }

        public static void TimeQueueTestLookup(TestCollections tests, Factory first, Factory lastCopy, Factory middleCopy, Factory custom)
        {
            long ticksFirst = 0;
            long ticksMiddle = 0;
            long ticksLast = 0;
            long ticksCustom = 0;

            bool firstFlag = false;
            bool middleFlag = false;
            bool lastFlag = false;
            bool customFlag = false;
            for (int i = 0; i < 5; i++)
            {
                timer.Start();
                if (tests.factQueue.Contains(first))
                {
                    firstFlag = true;
                    timer.Stop();
                    ticksFirst += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.factQueue.Contains(middleCopy))
                {
                    middleFlag = true;  
                    timer.Stop();
                    ticksMiddle += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.factQueue.Contains(lastCopy))
                {
                    lastFlag = true;
                    timer.Stop();
                    ticksLast += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (!tests.factQueue.Contains(custom))
                {
                    customFlag = true;
                    timer.Stop();
                    ticksCustom += timer.ElapsedTicks;
                }
                timer.Reset();
            }

            Console.WriteLine("Тест (первый элемент), время проверки: " + (ticksFirst / 5) + " тиков. Элемент " + (firstFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (средний элемент), время проверки: {ticksMiddle / 5} тиков. Элемент "+ (middleFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (последний элемент), время проверки: {ticksLast / 5} тиков. Элемент "+  (lastFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (незнакомый элемент), время проверки: {ticksCustom / 5} тиков. Элемент "+(customFlag ? "не найден" : "найден"));
        }

        public static void TimeQueueStringLookup(TestCollections tests, Factory first, Factory lastCopy, Factory middleCopy, Factory custom)
        {
            long ticksFirst = 0;
            long ticksMiddle = 0;
            long ticksLast = 0;
            long ticksCustom = 0;
            bool firstFlag = false;
            bool middleFlag = false;
            bool lastFlag = false;
            bool customFlag = false;
            for (int i = 0; i < 5; i++) 
            {
                timer.Start();
                if (tests.stringQueue.Contains(first.ToString()))
                {
                    firstFlag = true;
                    timer.Stop();
                    ticksFirst += timer.ElapsedTicks; 
                }
                timer.Reset();

                timer.Start();
                if (tests.stringQueue.Contains(middleCopy.ToString()))
                {
                    middleFlag = true;
                    timer.Stop();
                    ticksMiddle += timer.ElapsedTicks;    
                }
                timer.Reset();

                timer.Start();
                if (tests.stringQueue.Contains(lastCopy.ToString()))
                {
                    lastFlag = true;
                    timer.Stop();
                    ticksLast += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (!tests.stringQueue.Contains(custom.ToString()))
                {
                    customFlag = true;
                    timer.Stop();
                    ticksCustom += timer.ElapsedTicks;
                }
                timer.Reset();
            }

            Console.WriteLine("Тест (первый элемент), время проверки: " + (ticksFirst / 5) + " тиков. Элемент " + (firstFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (средний элемент), время проверки: {ticksMiddle / 5} тиков. Элемент " + (middleFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (последний элемент), время проверки: {ticksLast / 5} тиков. Элемент " + (lastFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (незнакомый элемент), время проверки: {ticksCustom / 5} тиков. Элемент " + (customFlag ? "не найден" : "найден"));
        }

        public static void TimeDictionaryProdKeyLookup(TestCollections tests, Factory first, Factory lastCopy, Factory middleCopy, Factory custom)
        {
            long ticksFirst = 0;
            long ticksMiddle = 0;
            long ticksLast = 0;
            long ticksCustom = 0;
            bool firstFlag = false;
            bool middleFlag = false;
            bool lastFlag = false;
            bool customFlag = false;
            for (int i = 0; i < 5; i++)
            {
                timer.Start();
                if (tests.prodFactDictionary.ContainsKey(first.BaseProduction))
                {
                    firstFlag = true;
                    timer.Stop();
                    ticksFirst += timer.ElapsedTicks;
                    
                }
                timer.Reset();

                timer.Start();
                if (tests.prodFactDictionary.ContainsKey(middleCopy.BaseProduction))
                {
                    middleFlag = true;
                    timer.Stop();
                    ticksMiddle += timer.ElapsedTicks;
                    
                }
                timer.Reset();

                timer.Start();
                if (tests.prodFactDictionary.ContainsKey(lastCopy.BaseProduction))
                {
                    lastFlag = true;
                    timer.Stop();
                    ticksLast += timer.ElapsedTicks;

                }
                timer.Reset();

                timer.Start();
                if (!tests.prodFactDictionary.ContainsKey(custom.BaseProduction))
                {
                    customFlag = true;
                    timer.Stop();
                    ticksCustom += timer.ElapsedTicks;
                    
                }
                timer.Reset();
            }

            Console.WriteLine("Тест (первый элемент), время проверки: " + (ticksFirst / 5) + " тиков. Элемент " + (firstFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (средний элемент), время проверки: {ticksMiddle / 5} тиков. Элемент " + (middleFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (последний элемент), время проверки: {ticksLast / 5} тиков. Элемент " + (lastFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (незнакомый элемент), время проверки: {ticksCustom / 5} тиков. Элемент " + (customFlag ? "не найден" : "найден"));
        }

        public static void TimeDictionaryProdValueLookup(TestCollections tests, Factory first, Factory lastCopy, Factory middleCopy, Factory custom)
        {
            long ticksFirst = 0;
            long ticksMiddle = 0;
            long ticksLast = 0;
            long ticksCustom = 0;
            bool firstFlag = false;
            bool middleFlag = false;
            bool lastFlag = false;
            bool customFlag = false;
            for (int i = 0; i < 5; i++)
            {
                timer.Start();
                if (tests.stringFactDictionary.ContainsValue(first))
                {
                    firstFlag = true;
                    timer.Stop();
                    ticksFirst += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.stringFactDictionary.ContainsValue(middleCopy))
                {
                    middleFlag = true;
                    timer.Stop();
                    ticksMiddle += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.stringFactDictionary.ContainsValue(lastCopy))
                {
                    lastFlag = true;
                    timer.Stop();
                    ticksLast += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (!tests.stringFactDictionary.ContainsValue(custom))
                {
                    customFlag = true;
                    timer.Stop();
                    ticksCustom += timer.ElapsedTicks;
                }
                timer.Reset();
            }

            Console.WriteLine("Тест (первый элемент), время проверки: " + (ticksFirst / 5) + " тиков. Элемент " + (firstFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (средний элемент), время проверки: {ticksMiddle / 5} тиков. Элемент " + (middleFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (последний элемент), время проверки: {ticksLast / 5} тиков. Элемент " + (lastFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (незнакомый элемент), время проверки: {ticksCustom / 5} тиков. Элемент " + (customFlag ? "не найден" : "найден"));
        }

        public static void TimeDictionaryStringValueLookup(TestCollections tests, Factory first, Factory lastCopy, Factory middleCopy, Factory custom)
        {
            long ticksFirst = 0;
            long ticksMiddle = 0;
            long ticksLast = 0;
            long ticksCustom = 0;
            bool firstFlag = false;
            bool middleFlag = false;
            bool lastFlag = false;
            bool customFlag = false;
            for (int i = 0; i < 5; i++)
            {
                timer.Start();
                if (tests.stringFactDictionary.ContainsValue(first))
                {
                    firstFlag = true;
                    timer.Stop();
                    ticksFirst += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.stringFactDictionary.ContainsValue(lastCopy))
                {
                    lastFlag = true;
                    timer.Stop();
                    ticksLast += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.stringFactDictionary.ContainsValue(middleCopy))
                {
                    middleFlag = true;
                    timer.Stop();
                    ticksMiddle += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (!tests.stringFactDictionary.ContainsValue(custom))
                {
                    customFlag = true;
                    timer.Stop();
                    ticksCustom += timer.ElapsedTicks;
                }
                timer.Reset();
            }

            Console.WriteLine("Тест (первый элемент), время проверки: " + (ticksFirst / 5) + " тиков. Элемент " + (firstFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (средний элемент), время проверки: {ticksMiddle / 5} тиков. Элемент " + (middleFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (последний элемент), время проверки: {ticksLast / 5} тиков. Элемент " + (lastFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (незнакомый элемент), время проверки: {ticksCustom / 5} тиков. Элемент " + (customFlag ? "не найден" : "найден"));
        }

        public static void TimeDictionaryStringKeyLookup(TestCollections tests, Factory first, Factory lastCopy, Factory middleCopy, Factory custom)
        {
            long ticksFirst = 0;
            long ticksMiddle = 0;
            long ticksLast = 0;
            long ticksCustom = 0;
            bool firstFlag = false;
            bool middleFlag = false;
            bool lastFlag = false;
            bool customFlag = false;
            for (int i = 0; i < 5; i++)
            {
                timer.Start();
                if (tests.stringFactDictionary.ContainsKey(first.ToString()))
                {
                    firstFlag = true;
                    timer.Stop();
                    ticksFirst += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.stringFactDictionary.ContainsKey(lastCopy.ToString()))
                {
                    lastFlag = true;
                    timer.Stop();
                    ticksLast += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (tests.stringFactDictionary.ContainsKey(middleCopy.ToString()))
                {
                    middleFlag = true;
                    timer.Stop();
                    ticksMiddle += timer.ElapsedTicks;
                }
                timer.Reset();

                timer.Start();
                if (!tests.stringFactDictionary.ContainsKey(custom.ToString()))
                {
                    customFlag = true;
                    timer.Stop();
                    ticksCustom += timer.ElapsedTicks;
                }
                timer.Reset();
            }

            Console.WriteLine("Тест (первый элемент), время проверки: " + (ticksFirst / 5) + " тиков. Элемент " + (firstFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (средний элемент), время проверки: {ticksMiddle / 5} тиков. Элемент " + (middleFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (последний элемент), время проверки: {ticksLast / 5} тиков. Элемент " + (lastFlag ? "найден" : "не найден"));
            Console.WriteLine($"Тест (незнакомый элемент), время проверки: {ticksCustom / 5} тиков. Элемент " + (customFlag ? "не найден" : "найден"));
        }
    }
}
