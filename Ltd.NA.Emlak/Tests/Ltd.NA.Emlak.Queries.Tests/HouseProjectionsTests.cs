using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Queries.Projections;
using System.Linq;
using Ltd.NA.Emlak.Data;
using Ltd.NA.Emlak.Domain;
using Ltd.NA.Emlak.Mocks;

namespace Ltd.NA.Emlak.Queries.Tests
{
    [TestClass]
    public class HouseProjectionsTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var houses = context.Houses.ToList();
                foreach (var house in houses)
                {
                    context.Houses.Remove(house);
                }
                var categories = context.Set<Category>().ToList();
                foreach (var category in categories)
                {
                    context.Set<Category>().Remove(category);
                }
                var addresses = context.Set<Address>().ToList();
                foreach (var address in addresses)
                {
                    context.Set<Address>().Remove(address);
                }


                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var houses = context.Houses.ToList();
                foreach (var house in houses)
                {
                    context.Houses.Remove(house);
                }
                var categories = context.Set<Category>().ToList();
                foreach (var category in categories)
                {
                    context.Set<Category>().Remove(category);
                }
                var addresses = context.Set<Address>().ToList();
                foreach (var address in addresses)
                {
                    context.Set<Address>().Remove(address);
                }


                context.SaveChanges();
            }
        }


        [TestMethod]
        public void Query_DatabaseIsEmpty_ReturnsEmptyList()
        {
            var result = HouseProjections.GetHouseList(0, 10);
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void Query_FirstFive_ReturnOnlyFive()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseList(5, 0);

            Assert.IsTrue(result.Count() == 5);
            Assert.IsTrue(result.Any(x => x.Name == "1"));
            Assert.IsFalse(result.Any(x => x.Name == "6"));
        }

        [TestMethod]
        public void Query_SecondFive_ReturnOnlySecondFive()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseList(5, 1);
            Assert.IsTrue(result.Count() == 5);
            Assert.IsTrue(result.Any(x => x.Name == "6"));
            Assert.IsFalse(result.Any(x => x.Name == "5"));
        }

        [TestMethod]
        public void Query_All_ReturnAll()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseList(999, 0);
            Assert.IsTrue(result.Count() == 10);
        }


        private void CreateMockHouses()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    House house = DomainMocksFactory.CreateHouse();
                    house.ModifyName((i + 1).ToString());
                    context.Houses.Add(house);
                }

                context.SaveChanges();
            }
        }
    }
}
