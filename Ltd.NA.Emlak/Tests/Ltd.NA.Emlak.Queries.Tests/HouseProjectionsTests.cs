using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Queries.Projections;
using System.Linq;
using Ltd.NA.Emlak.Data;
using Ltd.NA.Emlak.Domain;

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
        public void Projection_NoHouseAvailable_ReturnEmpty()
        {
            var result = HouseProjections.GetHouseList();
            Assert.IsTrue(result.ToList().Count == 0);
        }

        [TestMethod]
        public void Projection_OneHouseAvailable_ReturnInList()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                House house = House.Create(Guid.NewGuid(), "Beautiful House", "This is a beautiful house");
                context.Houses.Add(house);

                context.SaveChanges();
            }

            var result = HouseProjections.GetHouseList();
            Assert.IsTrue(result.ToList().Count == 1);
        }
    }
}
