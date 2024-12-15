using ProductionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10_OOP_
{
    public class SortByCountProd : IComparer<Production>
    {
        public int Compare(Production p1, Production p2)
        {
            return p1.CountProd.CompareTo(p2.CountProd);
        }

    }
}
