using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLib
{
    public class Factory : Production
    {
        protected int countDepartments; //количество цехов
        public Factory() : base()
        {
            countDepartments = 0;
        }
        public Factory(string type, int countProd, int countDepartments) : base(type, countProd)
        {
            this.countDepartments = countDepartments;
        }
        public int CountDepartments
        {
            get { return countDepartments; }
            set { countDepartments = value; }
        }
        public new void ShowInfo()
        {
            base.Show();
            Console.WriteLine("ФАБРИКА");
            Console.WriteLine("Количество цехов на фабрике = " + countDepartments);
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("ФАБРИКА");
            Console.WriteLine("Количество цехов на фабрике = " + countDepartments);
        }
        public override void RandInit()
        {
            base.RandInit();
            countDepartments = rnd.Next(5000, 1000000);
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите информацию о фабрике!");
            Console.Write("Количество цехов - ");
            countProd = CheckWrite();
        }
    }
}
