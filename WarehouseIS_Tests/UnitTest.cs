using System;
using System.Collections.Generic;
using NUnit.Framework;
using WarehouseIS_Base;
using WarehouseIS_Base.Classes;
using WarehouseIS_Base.Classes.Item;
using WarehouseIS_Base.Classes.User;

namespace WarehouseIS_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DBsimulation.Items.AddRange(ExtensionMethods.GenItems_Test());
        }
        //products in db:
        // (1, " аша", 100, 85, 100) { BuyDate = new DateTime(2021, 5, 10) },
        // (2, "—котч", 150, 20, 150),
        // (3, "√возди", 3, 1, 1000),
        // (4, "ѕиво", 75, 40, 47),
        // (5, "„ипсы", 70, 30, 126),
        // (6, "ћ€со", 400, 150, 5),
        // (7, "ћолоко", 90, 40, 100) { BuyDate = new DateTime(2021, 7, 10) },
        // (8, "’леб", 26, 15, 15)

        [Test()]
        //reservation test
        public void Test1()
        {
            
            var user = new Customer(1, "Vasili");
            var buyList = new List<Item>()
            {
                new Item(1," аша", 100, 85, 50)
            };
            user.SendRequest(buyList);
            Assert.AreEqual(50, DBsimulation.Items[0].Reserved);
        }

        [Test()]
        //SupplyTest
        public void Test2()
        {
            var supplier = new Supplier(2, "Gena");
            var supplyList = new List<Item>()
            {
                new Item(10, "Ўн€га", 440, 200, 40)
            };
            DBsimulation.Items.Add(supplyList[0]);
            var report = supplier.Supply(supplyList);
            Console.WriteLine(report.ToString());
            Assert.AreEqual(1, DBsimulation.Reports.Count);
        }

        [Test()]
        //RevisionTest
        public void Test3()
        {
            var supplier1 = new Supplier(3, "Gennadi");
            var report1 = supplier1.Revision(new DateTime(2021, 12, 10));
            Console.WriteLine(report1.ToString());
            Assert.AreEqual(2, report1.Lines.Count);
        }

        [Test()]
        //SaleTest
        public void Test4()
        {
            var deliler = new Deliveryman(4, "Tolya");
            var deliveryList = new List<Item>()
            {
                new Item(10, "Ўн€га", 440, 200, 40)
            };
            var report2 = deliler.CreateReport(deliveryList);
            Console.WriteLine(report2.ToString());
            Assert.AreEqual(1, report2.Lines.Count);
        }

        [Test()]
        //periodTest
        public void Test5()
        {
            var deliler = new Deliveryman(4, "Tolya");
            var deliveryList = new List<Item>()
            {
                new Item(10, "Ўн€га", 440, 200, 40)
            };
            var report2 = deliler.CreateReport(deliveryList);
            var report21 = deliler.CreateReport(deliveryList);
            var Booker = new Booker(5, "Lena");
            var report3 = Booker.PeriodReport(new DateTime(2021, 12, 11), new DateTime(2021, 12, 17));
            report3.AddDescription("ќтчЄт с 2021.11.12 по 2021.17.12");
            Console.WriteLine(report3.ToString());
            Assert.AreEqual(2, report3.Lines.Count);
        }

        [Test()]
        //StatsTest
        public void Test6()
        {
            var deliler = new Deliveryman(4, "Tolya");
            var deliveryList = new List<Item>()
            {
                new Item(10, "Ўн€га", 440, 200, 40)
            };
            var report2 = deliler.CreateReport(deliveryList);
            var report21 = deliler.CreateReport(deliveryList);
            var supplier = new Supplier(2, "Gena");
            var supplyList = new List<Item>()
            {
                new Item(10, "Ўн€га", 440, 200, 40)
            };
            var report = supplier.Supply(supplyList);

            DBsimulation.Items.Add(supplyList[0]);
            DBsimulation.Items.Add(deliveryList[0]);

            var admin = new Admin(10, "Max");
            var report10 = admin.InitAnalysis(new DateTime(2021, 10, 10));
            Console.WriteLine(report10.Description);
            Assert.AreEqual(3, report10.Lines.Count);
        }

        [Test()]
        public void Test7()
        {
            Assert.Pass();
        }
    }
}