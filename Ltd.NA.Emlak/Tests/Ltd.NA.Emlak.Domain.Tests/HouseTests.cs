using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Mocks;

namespace Ltd.NA.Emlak.Domain.Tests
{
    [TestClass]
    public class HouseTests
    {
        private House mockHouse;

        [TestInitialize]
        public void TestInitialize()
        {
            mockHouse = DomainMocksFactory.CreateHouse();
        }

        [TestMethod]
        public void House_MustHave_Name_And_Description()
        {
            Assert.IsTrue(mockHouse.Id != Guid.Empty, "The id is empty");
            Assert.IsTrue(mockHouse.Name == DomainMocksFactory.HOUSE_NAME);
            Assert.IsTrue(mockHouse.Description == DomainMocksFactory.HOUSE_DESC);
        }

        [TestMethod]
        public void House_With_Id_IsValid()
        {
            Assert.IsTrue(mockHouse.IsValid);
        }

        [TestMethod]
        public void House_Can_Create_NewCategory()
        {
            Assert.IsNull(mockHouse.Category);

            mockHouse.AddCategory("rent", "house for rent");
            Assert.IsNotNull(mockHouse.Category);
        }

        [TestMethod]
        public void House_Can_Change_Category()
        {
            mockHouse.AddCategory("rent", "house for rent");
            Category originalCategory = mockHouse.Category;

            Category expectedCategory = new Category("sell", "house for sell");
            mockHouse.ChangeCategory(expectedCategory);

            Assert.AreNotEqual(originalCategory, mockHouse.Category);

        }

        [TestMethod]
        public void Add_Address_To_House()
        {
            Assert.IsNull(mockHouse.Address);
            mockHouse.AddAddress("Address Line 1", "Izmir", "Turkey", "100/3", "35140");
            Assert.IsNotNull(mockHouse.Address);

        }

        [TestMethod]
        public void Change_Adress_For_House()
        {
            mockHouse.AddAddress("Address Line 1", "Izmir", "Turkey", "100/3", "35140");
            Address originalAddress = mockHouse.Address;

            Address expectedAddress = new Address("Address Line 2", "Edremit", "Turkey", "100/3", "35140");
            mockHouse.ChangeAddress(expectedAddress);

            Assert.AreNotEqual(originalAddress,mockHouse.Address);

        }

        [TestMethod]
        public void House_Created_MustHaveACustomer()
        {
            Assert.IsNotNull(mockHouse.Owner);
        }

        [TestMethod]
        public void House_Created_IsAssociated_WithCustomerCollectionOfHouses()
        {
            House tempHouse = House.Create("Temp Name","Temp Description",mockHouse.Owner);
            //mockHouse.Owner.AddHouse(tempHouse);

            Assert.IsTrue(mockHouse.Owner.Houses.Count > 1);
        }

    }
}
