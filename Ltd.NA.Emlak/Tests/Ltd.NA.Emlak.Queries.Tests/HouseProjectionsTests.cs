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
            Assert.IsTrue(result.TotalRecords == 0);
        }

        [TestMethod]
        public void Query_FirstFive_ReturnOnlyFive()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseList(5, 0);

            Assert.IsTrue(result.TotalRecords == 5);
            Assert.IsTrue(result.Items.Any(x => x.Name == "0"));
            Assert.IsFalse(result.Items.Any(x => x.Name == "6"));
        }

        [TestMethod]
        public void Query_SecondFive_ReturnOnlySecondFive()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseList(5, 5);
            Assert.IsTrue(result.TotalRecords == 5);
            Assert.IsTrue(result.Items.Any(x => x.Name == "6"));
            Assert.IsFalse(result.Items.Any(x => x.Name == "4"));
        }

        [TestMethod]
        public void Query_All_ReturnAll()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseList(999, 0);
            Assert.IsTrue(result.TotalRecords == 10);
        }

        [TestMethod]
        public void Query_Get_Address_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999,0);
            Assert.IsTrue(result.Any(x => x.Address.Address1 == "my address"));
            Assert.IsTrue(result.Any(x => x.Address.City == "my city"));
            Assert.IsTrue(result.Any(x => x.Address.Country == "my country"));
            Assert.IsTrue(result.Any(x => x.Address.Number == "my st. number"));
            Assert.IsTrue(result.Any(x => x.Address.ZipCode == "zip code"));
        }

        [TestMethod]
        public void Query_Get_Category_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999, 0);
            Assert.IsTrue(result.Any(x => x.Category.Entry == "my entry"));
            Assert.IsTrue(result.Any(x => x.Category.Description == "my description"));
        }

        [TestMethod]
        public void Query_Get_Agent_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999, 0);

            Assert.IsTrue(result.Any(x => x.Agent.FirstName == "first name"));
            Assert.IsTrue(result.Any(x => x.Agent.LastName == "last name"));
            Assert.IsTrue(result.Any(x => x.Agent.Age == 99));

        }

        [TestMethod]
        public void Query_Get_Customer_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999, 0);

            Assert.IsTrue(result.Any(x => x.Owner.FirstName == "first name"));
            Assert.IsTrue(result.Any(x => x.Owner.LastName == "last name"));
            Assert.IsTrue(result.Any(x => x.Owner.Age == 99));
        }

        private void CreateMockHouses()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    House house = DomainMocksFactory.CreateHouse();
                    house.ModifyName((i).ToString());
                    house.AddAddress("my address", "my city", "my country", "my st. number", "zip code");
                    house.AddCategory("my entry", "my description");
                    house.AssociateAgent(DomainMocksFactory.CreateAgent());
                    context.Houses.Add(house);
                }

                context.SaveChanges();
            }
        }
    }
}
