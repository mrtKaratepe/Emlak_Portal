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
            Assert.IsTrue(mockHouse.Name == "My Name");
            Assert.IsTrue(mockHouse.Description == "My Description");
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
    }
}
