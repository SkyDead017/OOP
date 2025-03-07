using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba_12_OOP__
{
    public class HashTable<TKey, TValue>: IEnumerable<ItemHT<TKey, TValue>>, IDictionary<TKey, TValue>, ICloneable
    {
        private int _capacity;
        private ItemHT<TKey, TValue>[] _tables;
        private int count = 0;

        public HashTable() { }
        public HashTable(int capacity)
        {
            _capacity = capacity;
            _tables = new ItemHT<TKey, TValue>[capacity];
        }
        public HashTable(HashTable<TKey, TValue> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            _capacity = other._capacity;
            _tables = new ItemHT<TKey, TValue>[_capacity];
            Count = other.Count;
            for (int i = 0; i < _capacity; i++)
            {
                if (other._tables[i] != null)
                {
                    _tables[i] = new ItemHT<TKey, TValue>(other._tables[i].Key, other._tables[i].Value);
                }
            }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] values = new TValue[_tables.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = _tables[i].Value;
                }
                
                return values;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] keys = new TKey[_tables.Length];
                for (int i = 0; i < keys.Length; i++)
                {
                    keys[i] = _tables[i].Key;
                }

                return keys;
            }
        }
        

        public int GetTableIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode())% _capacity;
        }
        public void Add(ItemHT<TKey, TValue> item)
        {
            var index = GetTableIndex(item.Key);
            var current = _tables[index];
            if (current == null)
            {
                _tables[index] = item;
            }
            else
            {
                try
                {
                    while (current != null)
                    {
                        if (item.Key.Equals(current.Key))
                        {
                            throw new ArgumentException("Такой ключ уже существует!");
                        }
                        if (current.NextEl == null)
                        {
                            current.NextEl = item;
                            break;
                        }
                        current = current.NextEl;
                    }
                }
                catch (Exception ex)
                {
                    // Обработка исключения
                    Console.WriteLine($"Обработано исключение: {ex.Message}");
                }
            }
            Count++;
        }


        //Добавление
        public void Add(TKey key, TValue value)
        {
            var index = GetTableIndex(key);
            var current = _tables[index];
            if (current == null)
            {
                _tables[index] = new ItemHT<TKey, TValue>(key, value);
            }
            else
            {
                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        throw new ArgumentException("Такой ключ уже существует!");
                    }
                    if (current.NextEl == null)
                    {
                        current.NextEl = new ItemHT<TKey, TValue>(key, value);
                        break;
                    }
                    current = current.NextEl;
                }
            }
            Count++;
        }
        //Удаление по ключу
        public bool Remove(TKey key)
        {
            var index = GetTableIndex(key);
            var current = _tables[index];
            ItemHT<TKey, TValue> previous = null;
            while (current != null)
            {
                if(current.Key.Equals(key))
                {
                    if(previous == null)
                    {
                        _tables[index] = current.NextEl;
                    }
                    else
                    {
                        previous.NextEl = current.NextEl;
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.NextEl;
            }
            return false;
        }

        //Поиск по значению
        public bool ContainsValue(TValue value)
        {
            foreach(var table in _tables)
            {
                var current = table;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        return true;
                    }
                    current = current.NextEl;
                }
            }
            return false;
        }

        //Печать Хеш Таблицы
        public void Display()
        {
            for (int i = 0; i < _tables.Length; i++)
            {
                Console.Write($"Пара {i+1}: ");
                var current = _tables[i];

                while (current != null)
                {
                    Console.Write($"[{current.Key}, {current.Value}] ");
                    current = current.NextEl; 
                }

                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------------------");
        }
        public IEnumerator<ItemHT<TKey, TValue>> GetEnumerator()
        {
            foreach (var item in _tables)
            {
                var current = item;
                while (current != null)
                {
                    yield return current;
                    current = current.NextEl;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsKey(TKey key)
        {
            var index = GetTableIndex(key);
            var current = _tables[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return true;
                }
                current = current.NextEl;
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = GetTableIndex(key);
            var current = _tables[index];
            while(current != null)
            {
                if (current.Key.Equals(key))
                {
                    value = current.Value;
                    return true;
                }
                current = current.NextEl;
            }
            value = default;
            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear(out HashTable<TKey, TValue> hashtable)
        {
            hashtable = new HashTable<TKey, TValue>(_capacity);
        }
        public void Clear()
        {
            Array.Clear(_tables, 0, _capacity);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var index = GetTableIndex(item.Key);
            var current = _tables[index];
            while (current != null)
            {
                if (current.Key.Equals(item.Key))
                {
                    if (current.Value.Equals(item.Value))
                    {
                        return true;
                    }
                }
                current = current.NextEl;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            foreach (var item in _tables)
            {
                array[arrayIndex++] = new KeyValuePair<TKey, TValue>(item.Key, item.Value);
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var index = GetTableIndex(item.Key);
            var current = _tables[index];
            ItemHT<TKey, TValue> previous = null;
            while (current != null)
            {
                if (current.Key.Equals(item.Key))
                {
                    if (current.Value.Equals(item.Value))
                    {
                        if (previous == null)
                        {
                            _tables[index] = current.NextEl;
                        }
                        else
                        {
                            previous.NextEl = current.NextEl;
                        }
                        Count--;
                        return true;
                    }
                }
                previous = current;
                current = current.NextEl;
            }
            return false;
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            foreach (var item in _tables)
            {
                var current = item;
                while (current != null)
                {
                    yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                    current = current.NextEl;
                }
            }
        }

        public object Clone()
        {
            return new HashTable<TKey, TValue>(this);
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public TValue this[TKey key]
        {
            get
            {
                var index = GetTableIndex(key);
                var current = _tables[index];

                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        return current.Value;
                    }
                    current = current.NextEl;
                }

                throw new KeyNotFoundException("Ключ не найден!");
            }
            set
            {
                var index = GetTableIndex(key);
                var current = _tables[index];

                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        current.Value = value;
                        return;
                    }
                    current = current.NextEl;
                }
                _tables[index] = new ItemHT<TKey, TValue>(key, value) { NextEl = _tables[index] };
            }
        }
        //public string RandKey()
        //{
        //    string key = "";
        //    string alphabetStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //    Random rand = new Random();
        //    int count = rand.Next(1, alphabetStr.Length);
        //    for(int i= 0; i < count; i++)
        //    {
        //        int index = rand.Next(alphabetStr.Length);
        //        key += alphabetStr[index];
        //    }
        //    return key;
        //}
        public bool IsReadOnly => throw new NotImplementedException();
    }
}
