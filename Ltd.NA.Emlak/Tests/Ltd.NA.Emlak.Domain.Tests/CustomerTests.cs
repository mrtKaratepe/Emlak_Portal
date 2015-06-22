using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Mocks;

namespace Ltd.NA.Emlak.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private Customer mockCustomer;
        
        [TestInitialize]
        public void testInitialize()
        {
            mockCustomer = DomainMocksFactory.CreateCustomer();
        }


        [TestMethod]
        public void Customer_Created()
        {
            Assert.IsNotNull(mockCustomer);
        }

        [TestMethod]
        public void Customer_Created_HasProperties()
        {
            Assert.IsTrue(mockCustomer.FirstName == "first name");
            Assert.IsTrue(mockCustomer.LastName == "last name");
        }

        [TestMethod]
        public void Customer_HasOneHouseAssociated()
        {
            House tempHouseForCustomer = DomainMocksFactory.CreateHouse();
            Assert.IsTrue(tempHouseForCustomer.Owner.Houses.Contains(tempHouseForCustomer));

        }

        [TestMethod]
        public void Customer_HasTwoHouseAssociated()
        {
            House firstHouse = House.Create("name", "description", mockCustomer);
            House secondHouse = House.Create("name", "description", mockCustomer);

            Assert.IsTrue(mockCustomer.Houses.Count == 2);
            Assert.IsTrue(mockCustomer.Houses.Contains(firstHouse));
            Assert.IsTrue(mockCustomer.Houses.Contains(secondHouse));
        }
    }
}
