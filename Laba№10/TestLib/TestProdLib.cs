using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProductionLib;
using laba_10_OOP_;

namespace TestProductionLib
{
    [TestClass]
    public class TestProdLib
    {
        [TestMethod]
        public void TestProductionInitialization()
        {
            Production production = new Production();
            Assert.AreEqual("", production.Type);
            Assert.AreEqual(0, production.CountProd);
        }

        [TestMethod]
        public void TestFactoryInitialization()
        {
            Factory factory = new Factory();
            Assert.AreEqual("", factory.Type);
            Assert.AreEqual(0, factory.CountProd);
            Assert.AreEqual(0, factory.CountDepartments);
        }

        [TestMethod]
        public void TestDepartmentInitialization()
        {
            Department department = new Department();
            Assert.AreEqual("", department.Type);
            Assert.AreEqual(0, department.CountProd);
            Assert.AreEqual(0, department.CountDepartments);
            Assert.AreEqual("", department.TypeDepartment);
        }

        [TestMethod]
        public void TestWorkShopInitialization()
        {
            WorkShop workShop = new WorkShop();
            Assert.AreEqual("", workShop.Type);
            Assert.AreEqual(0, workShop.CountProd);
            Assert.AreEqual(0, workShop.CountDepartments);
            Assert.AreEqual("", workShop.TypeDepartment);
            Assert.AreEqual(0, workShop.CountWorker);
        }

        [TestMethod]
        public void TestProductionInitializationParam()
        {
            Production production = new Production("Одежда", 1000);
            Assert.AreEqual("Одежда", production.Type);
            Assert.AreEqual(1000, production.CountProd);
        }

        [TestMethod]
        public void TestFactoryInitializationParam()
        {
            Factory factory = new Factory("Обувь", 2000, 5);
            Assert.AreEqual("Обувь", factory.Type);
            Assert.AreEqual(2000, factory.CountProd);
            Assert.AreEqual(5, factory.CountDepartments);
        }

        [TestMethod]
        public void TestDepartmentInitializationParam()
        {
            Department department = new Department("Аксессуары", 3000, 3, "Швейный цех");
            Assert.AreEqual("Аксессуары", department.Type);
            Assert.AreEqual(3000, department.CountProd);
            Assert.AreEqual(3, department.CountDepartments);
            Assert.AreEqual("Швейный цех", department.TypeDepartment);
        }

        [TestMethod]
        public void TestWorkShopInitializationParam()
        {
            WorkShop workShop = new WorkShop("Специальная одежда", 4000, 4, "Цех раскроя", 10);
            Assert.AreEqual("Специальная одежда", workShop.Type);
            Assert.AreEqual(4000, workShop.CountProd);
            Assert.AreEqual(4, workShop.CountDepartments);
            Assert.AreEqual("Цех раскроя", workShop.TypeDepartment);
            Assert.AreEqual(10, workShop.CountWorker);
        }

        [TestMethod]
        public void TestTypeSetter()
        {
            Production production = new Production();
            production.Type = "Одежда";
            Assert.AreEqual("Одежда", production.Type);
        }

        [TestMethod]
        public void TestCountProdSetter()
        {
            Production production = new Production();
            production.CountProd = 1000;
            Assert.AreEqual(1000, production.CountProd);
        }

        [TestMethod]
        public void TestCountDepartmentsSetter()
        {
            Factory factory = new Factory();
            factory.CountDepartments = 5;
            Assert.AreEqual(5, factory.CountDepartments);
        }

        [TestMethod]
        public void TestTypeDepartmentSetter()
        {
            Department department = new Department();
            department.TypeDepartment = "Швейный цех";
            Assert.AreEqual("Швейный цех", department.TypeDepartment);
        }

        [TestMethod]
        public void TestCountWorkerSetter()
        {
            WorkShop workShop = new WorkShop();
            workShop.CountWorker = 10;
            Assert.AreEqual(10, workShop.CountWorker);
        }
        [TestMethod]
        public void TestEqualsTrueProductions()
        {
            var prod1 = new Production { Type = "A", CountProd = 10 };
            var prod2 = new Production { Type = "A", CountProd = 10 };

            Assert.IsTrue(prod1.Equals(prod2));
        }

        [TestMethod]
        public void TestEqualsFalseDifferentProductions()
        {
            var prod1 = new Production { Type = "A", CountProd = 10 };
            var prod2 = new Production { Type = "B", CountProd = 10 };

            Assert.IsFalse(prod1.Equals(prod2));
        }

        [TestMethod]
        public void TestGetHashCodeSameValueForEqualProductions()
        {
            var prod1 = new Production { Type = "A", CountProd = 10 };
            var prod2 = new Production { Type = "A", CountProd = 10 };

            Assert.AreEqual(prod1.GetHashCode(), prod2.GetHashCode());
        }

        [TestMethod]
        public void TestGetHashCodeDifferentValueForDifferentProductions()
        {
            var prod1 = new Production { Type = "A", CountProd = 10 };
            var prod2 = new Production { Type = "B", CountProd = 10 };

            Assert.AreNotEqual(prod1.GetHashCode(), prod2.GetHashCode());
        }

        [TestMethod]
        public void TestCheckWriteValidInput()
        {
            using (var input = new System.IO.StringReader("5\n"))
            {
                Console.SetIn(input);
                int result = Production.CheckWrite();
                Assert.AreEqual(5, result);
            }
        }

        [TestMethod]
        public void TestCheckWriteInvalidInput()
        {
            using (var input = new System.IO.StringReader("abc\n-1\n5\n"))
            {
                Console.SetIn(input);
                int result = Production.CheckWrite();
                Assert.AreEqual(5, result);
            }
        }

        [TestMethod]
        public void TestCompareToNegativeValue()
        {
            var prod1 = new Production { CountProd = 5 };
            var prod2 = new Production { CountProd = 10 };

            Assert.AreEqual(-1, prod1.CompareTo(prod2));
        }

        [TestMethod]
        public void TestCompareToZero()
        {
            var prod1 = new Production { CountProd = 10 };
            var prod2 = new Production { CountProd = 10 };

            Assert.AreEqual(0, prod1.CompareTo(prod2));
        }

        [TestMethod]
        public void TestCompareToPositiveValue()
        {
            var prod1 = new Production { CountProd = 15 };
            var prod2 = new Production { CountProd = 10 };

            Assert.AreEqual(1, prod1.CompareTo(prod2));
        }
        [TestMethod]
        public void TestCompareNegativeValueCP()
        {
            var p1 = new Production { CountProd = 5 };
            var p2 = new Production { CountProd = 10 };
            var comparer = new SortByCountProd();

            int result = comparer.Compare(p1, p2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void TestCompareZeroCP()
        {
            var p1 = new Production { CountProd = 10 };
            var p2 = new Production { CountProd = 10 };
            var comparer = new SortByCountProd();

            int result = comparer.Compare(p1, p2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestComparePositiveValueCP()
        {
            var p1 = new Production { CountProd = 15 };
            var p2 = new Production { CountProd = 10 };
            var comparer = new SortByCountProd();

            int result = comparer.Compare(p1, p2);

            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void TestCompareNegativeValueType()
        {
            var p1 = new Production { Type = "A" };
            var p2 = new Production { Type = "B" };
            var comparer = new SortByAlphabet();

            int result = comparer.Compare(p1, p2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void TestCompareZeroType()
        {
            var p1 = new Production { Type = "A" };
            var p2 = new Production { Type = "A" };
            var comparer = new SortByAlphabet();

            int result = comparer.Compare(p1, p2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestComparePositiveValueType()
        {
            var p1 = new Production { Type = "B" };
            var p2 = new Production { Type = "A" };
            var comparer = new SortByAlphabet();

            int result = comparer.Compare(p1, p2);

            Assert.IsTrue(result > 0);
        }


    }
}