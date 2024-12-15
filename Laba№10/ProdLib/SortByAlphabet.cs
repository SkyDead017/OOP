using System;
using System.Collections.Generic;
using ProductionLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10_OOP_
{
    public class SortByAlphabet : IComparer<Production>
    {
        public int Compare(Production p1, Production p2)
        {
            return p1.Type.CompareTo(p2.Type);
        }
    }
}
