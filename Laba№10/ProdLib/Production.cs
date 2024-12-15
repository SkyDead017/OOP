using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLib
{
    public class Production : IInit, IComparable<Production>
    {
        protected static Random rnd = new Random();
        protected string type; //тип продукции
        protected int countProd; //количество выпускаемой продукции

        public Production()
        {
            type = "";
            countProd = 0;
        }
        public Production(string type, int countProd)
        {
            this.type = type;
            this.countProd = countProd;
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int CountProd
        {
            get { return countProd; }
            set { countProd = value; }
        }
        public void ShowInfo()
        {
            Console.WriteLine("ПРОИЗВОДСТВО");
            Console.WriteLine("Тип продукции - " + type);
            Console.WriteLine("Количество выпускаемой продукции - " + countProd);
        }
        public virtual void Show()
        {
            Console.WriteLine("ПРОИЗВОДСТВО");
            Console.WriteLine("Тип продукции - "+ type);
            Console.WriteLine("Количество выпускаемой продукции - "+ countProd);
        }

        public virtual void RandInit()
        {
            string[] typeNameProduction = { "Одежда", "Аксессуары", "Обувь", "Детская одежда", "Специальная одежда", "Костюмы и вечерние наряды", "Текстиль для спорта и активного отдыха" };
            int key =rnd.Next(typeNameProduction.Length);
            type = typeNameProduction[key];
            countProd = rnd.Next(5000, 1000000);
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите информацию о производстве!");
            Console.Write("Тип продукции - ");
            type = Console.ReadLine();
            Console.Write("Количество выпускаемой продукции - ");
            countProd = CheckWrite();
        }
        public override bool Equals(object obj)
        {
            if (obj is Production prod)
            {
                return Type == prod.Type && CountProd == prod.CountProd;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hashCode = 94;
            hashCode = hashCode * 25 + Type.GetHashCode();
            hashCode = hashCode * 25 +  CountProd.GetHashCode();
            return hashCode;
        }
        public static int CheckWrite()
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
        public int CompareTo(Production prod)
        {
            return CountProd.CompareTo(prod.CountProd);
        }
    }
}
