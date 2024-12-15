using ProductionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10_OOP_
{
    public class Money : IInit, ICloneable
    {
        private static Random rnd = new Random();
        private string valuta;
        public List<int> kurs;

        public Money()
        {
            valuta = "";
            kurs = new List<int>();
        }
        public Money(string valuta, List<int> kurs)
        {
            this.valuta = valuta;
            this.kurs = kurs;
        }
        public string Valuta
        {
            get { return valuta; }
            set { valuta = value; }
        }
        public List<int> Kurs
        {
            get { return kurs; }
            set { kurs = value; }
        }
        public void Init()
        {
            Console.WriteLine("Введите информацию о деньгах!");
            Console.Write("Валюта - ");
            valuta = Console.ReadLine();
            Console.WriteLine("Введите количество измененных курсов");
            int count = CheckWrite();
            Console.WriteLine("Введите значения курсов");
            for (int i = 0; i < count; i++)
            {
                int valueKurs = CheckWrite();
                kurs.Add(valueKurs);
            }
        }

        public void RandInit()
        {
            string[] typeValuta = { "Рубли", "Доллары", "Тенге", "Евро", "Шекели", "Йены", "Юани", "Кроны" };
            int key = rnd.Next(typeValuta.Length);
            valuta = typeValuta[key];
            int count = rnd.Next(2,10);
            for (int i = 0; i < count; i++)
            {
                int valueKurs = rnd.Next(50,120);
                kurs.Add(valueKurs);
            }
        }
        public void Show()
        {
            Console.WriteLine("ДЕНЬГИ");
            Console.WriteLine("Валюта - "+ valuta);
            Console.WriteLine("Курсы - ");
            for(int i = 0;i < kurs.Count; i++)
            {
                Console.Write(kurs[i] + " ");
            }
            Console.WriteLine();
        }
        public object Clone()
        {
            Money clonedMoney = new Money(valuta, kurs);
            clonedMoney.kurs = new List<int> (kurs);
            return clonedMoney;
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
        public static int CheckWrite()
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok || input < 0)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok || input < 0);
            return input;
        }

    }
}
