using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLib
{
    public class Department : Factory
    {
        protected string typeDepartment; //тип цеха
        public Department() : base()
        {
            typeDepartment = "";
        }
        public Department(string type, int countProd, int countDepartments, string typeDepartment) : base(type, countProd, countDepartments)
        {
            this.typeDepartment = typeDepartment;
        }
        public string TypeDepartment
        {
            get { return typeDepartment; }
            set { typeDepartment = value; }
        }
        public new void ShowInfo()
        {
            base.Show();
            Console.WriteLine("ЦЕХ");
            Console.WriteLine("Тип цеха = " + typeDepartment);
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("ЦЕХ");
            Console.WriteLine("Тип цеха = " + typeDepartment);
        }
        public override void RandInit()
        {
            base.RandInit();
            string[] typeNameDepartment = { "Цех раскроя", "Швейный цех", "Цех отделки", "Цех контроля качества", "Цех упаковки", "Цех обработки тканей", "Дизайнерский цех" };
            int key = rnd.Next(typeDepartment.Length);
            typeDepartment = typeNameDepartment[key];
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите информацию о цехе!");
            Console.Write("Тип цеха - ");
            typeDepartment = Console.ReadLine();
        }
    }
}
