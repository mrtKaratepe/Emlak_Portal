using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Queries.Projections;
using System.Linq;
using Ltd.NA.Emlak.Data;
using Ltd.NA.Emlak.Domain;
using Ltd.NA.Emlak.Mocks;
using Ltd.NA.Emlak.Queries.Messages;

namespace Ltd.NA.Emlak.Queries.Tests
{
    [TestClass]
    public class HouseProjectionsTests
    {
        HouseSearchRequest filter;

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
            Assert.IsNull(filter);
        }

        [TestMethod]
        public void Query_FirstFive_ReturnOnlyFive()
        {
            CreateMockHouses();
            filter.Take = 5;
            filter.Skip = 0;
            var result = HouseProjections.GetHouseList(filter);

            Assert.IsTrue(result.Items.Count() == 5);
            Assert.IsTrue(result.Items.Any(x => x.Code == "0"));
            Assert.IsFalse(result.Items.Any(x => x.Code == "5"));
        }

        [TestMethod]
        public void Query_SecondFive_ReturnOnlySecondFive()
        {
            CreateMockHouses();
            filter.Take = 5;
            filter.Skip = 5;
            var result = HouseProjections.GetHouseList(filter);
            Assert.IsTrue(result.Items.Count() == 5);
            Assert.IsTrue(result.Items.Any(x => x.Code == "6"));
            Assert.IsFalse(result.Items.Any(x => x.Code == "4"));
        }

        [TestMethod]
        public void Query_All_ReturnAll()
        {
            CreateMockHouses();
            filter.Take = 999;
            filter.Skip = 0;
            var result = HouseProjections.GetHouseList(filter);
            Assert.IsTrue(result.TotalRecords == 10);
        }

        [TestMethod]
        public void Query_Get_Address_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999,0);
            Assert.IsTrue(result.Any(x => x.Address1 == "my address"));
            Assert.IsTrue(result.Any(x => x.City == "my city"));
            Assert.IsTrue(result.Any(x => x.Country == "my country"));
            Assert.IsTrue(result.Any(x => x.Number == "my st. number"));
            Assert.IsTrue(result.Any(x => x.ZipCode == "zip code"));
        }

        [TestMethod]
        public void Query_Get_Category_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999, 0);
            Assert.IsTrue(result.Any(x => x.Entry == "my entry"));
            Assert.IsTrue(result.Any(x => x.CatDescription == "my description"));
        }

        [TestMethod]
        public void Query_Get_Agent_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999, 0);

            Assert.IsTrue(result.Any(x => x.AgentFirstName == "first name"));
            Assert.IsTrue(result.Any(x => x.AgentLastName == "last name"));
            Assert.IsTrue(result.Any(x => x.AgentAge == 99));

        }

        [TestMethod]
        public void Query_Get_Customer_Of_House_With_details()
        {
            CreateMockHouses();
            var result = HouseProjections.GetHouseDetailsList(999, 0);

            Assert.IsTrue(result.Any(x => x.OwnerFirstName == "first name"));
            Assert.IsTrue(result.Any(x => x.OwnerLastName == "last name"));
            Assert.IsTrue(result.Any(x => x.OwnerAge == 99));
        }

        private void CreateMockHouses()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                    filter = new HouseSearchRequest();
                    filter.City = "City";
                /*
                    filter.Address = "Adress";
                    filter.Price = 0;
                    filter.Skip = 10;
                    filter.Street = "Street";
                    filter.Take = 10;
                    filter.TypeRent = true;
                    filter.ZipCode = "ZipCode";
                */
                for (int i = 0; i < 10; i++)
                {
                    House house = DomainMocksFactory.CreateHouse();
                    house.ModifyCode((i).ToString());
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
