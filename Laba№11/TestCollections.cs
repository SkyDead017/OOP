using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionLib;

namespace lab11
{
    internal class TestCollections
    {
        public Queue<Factory> factQueue = new Queue<Factory>();
        public Queue<string> stringQueue = new Queue<string>();
        public Dictionary<Production, Factory> prodFactDictionary = new Dictionary<Production, Factory>();
        public Dictionary<string, Factory> stringFactDictionary = new Dictionary<string, Factory>();

        public TestCollections() { }

        public TestCollections(int count)
        {
            factQueue = new Queue<Factory>();
            stringQueue = new Queue<string>();
            prodFactDictionary = new Dictionary<Production, Factory>();
            stringFactDictionary = new Dictionary<string, Factory>();

            int addedFactoriesCount = 0;

            while (addedFactoriesCount < count)
            {
                Factory fact = new Factory();
                fact.RandInit();

                if (!prodFactDictionary.ContainsKey(fact.BaseProduction) && !stringFactDictionary.ContainsKey(fact.ToString()))
                {
                    factQueue.Enqueue(fact);
                    stringQueue.Enqueue(fact.ToString());
                    prodFactDictionary.Add(fact.BaseProduction, fact);
                    stringFactDictionary.Add(fact.ToString(), fact);
                    addedFactoriesCount++; 
                }
                
            }
        }

        public Factory GetLastTest()
        {
            if (factQueue.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста. Невозможно получить последний элемент.");
            }

            Factory[] factoryArray = factQueue.ToArray();

            return factoryArray[factoryArray.Length - 1];
        }

        public Factory GetMiddleTest()
        {
            if (factQueue.Count < 500)
            {
                throw new InvalidOperationException("В очереди недостаточно элементов. Невозможно получить 500-й элемент.");
            }

            Factory[] factoryArray = factQueue.ToArray();

            return factoryArray[499];
        }
    }
}
