using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12_OOP__
{
    public class ItemHT<TKey, TValue>
    {
        private TKey key;
        private TValue value;
        private ItemHT<TKey, TValue> nextEl;

        public TKey Key
        {
            get { return key; }
            set { key = value; }
        }

        public TValue Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public ItemHT<TKey, TValue> NextEl
        {
            get { return nextEl; }
            set { nextEl = value; }
        }
        public ItemHT(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
            nextEl = null;
        }
    }
}
