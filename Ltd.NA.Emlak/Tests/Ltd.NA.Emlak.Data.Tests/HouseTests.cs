using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Domain;
using System.Linq;
using Ltd.NA.Emlak.Mocks;

namespace Ltd.NA.Emlak.Data.Tests
{
    [TestClass]
    public class HouseTests
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
        public void House_CanBe_Saved()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                House house = DomainMocksFactory.CreateHouse();
                context.Houses.Add(house);

                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                House house = context.Houses.FirstOrDefault();
                Assert.IsNotNull(house);
            }
        }

        [TestMethod]
        public void House_CanBe_Modified()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                House house = DomainMocksFactory.CreateHouse();
                context.Houses.Add(house);

                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                House house = context.Houses.FirstOrDefault();
                house.ModifyName("Modified");
                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                House house = context.Houses.FirstOrDefault();
                Assert.IsTrue(house.Name == "Modified");
            }
        }

        [TestMethod]
        public void House_CanBe_Deleted()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                House house = DomainMocksFactory.CreateHouse();
                context.Houses.Add(house);

                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                House house = context.Houses.FirstOrDefault();
                context.Houses.Remove(house);
                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                House house = context.Houses.FirstOrDefault();
                Assert.IsNull(house);
            }
        }

        [TestMethod]
        public void House_IsProperlyMapped()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                House house = DomainMocksFactory.CreateHouse();
                house.AddCategory("For Rent", "This house is for rent");
                house.AddAddress("My street", "my city", "my country", "my number", "zip code");
                
                context.Houses.Add(house);
                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                House house = context.Houses
                    .Include("Category")
                    .Include("Address")
                    .FirstOrDefault();
                Assert.IsTrue(house.Name == DomainMocksFactory.HOUSE_NAME);
                Assert.IsTrue(house.Description == DomainMocksFactory.HOUSE_DESC);
                Assert.IsTrue(house.Address.Address1 == "My street");
            }
        }

        [TestMethod]
        public void House_IsDeleted_ButCustomerIsNot()
        {
            Assert.Inconclusive("To do");
        }
    }
}
