using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ltd.NA.Emlak.Domain.Tests
{
    [TestClass]
    public class HouseTests
    {
        [TestMethod]
        public void House_MustHave_Name_And_Description()
        {
            House house = House.Create(Guid.NewGuid(), "My Name", "My Description");

            Assert.IsTrue(house.Id != Guid.Empty);
            Assert.IsTrue(house.Name == "My Name");
            Assert.IsTrue(house.Description == "My Description");
        }

        [TestMethod]
        public void House_Without_Id_IsNotValid()
        {
            House house = House.Create(Guid.Empty, "My Name", "My Description");

            Assert.IsFalse(house.IsValid);
        }
    }
}
