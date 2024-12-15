using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLib
{
    public class WorkShop : Department
    {
        protected int countWorker; //количество работников в мастерской
        public WorkShop() : base()
        {
            countWorker = 0;
        }
        public WorkShop(string type, int countProd, int countDepartments, string typeDepartment, int countWorker) :
            base(type, countProd, countDepartments, typeDepartment)
        {
            this.countWorker = countWorker;
        }
        public int CountWorker
        {
            get { return countWorker; }
            set { countWorker = value; }
        }
        public new void ShowInfo()
        {
            base.Show();
            Console.WriteLine("МАСТЕРСКАЯ");
            Console.WriteLine("Количество работников в мастерской = " + countWorker + " человек");
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("МАСТЕРСКАЯ");
            Console.WriteLine("Количество работников в мастерской = " + countWorker + " человек");
        }
        public override void RandInit()
        {
            base.RandInit();
            countWorker = rnd.Next(5000, 1000000);
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите информацию о фабрике!");
            Console.Write("Количество работников в мастерской - ");
            countWorker = CheckWrite();
        }
    }
}
