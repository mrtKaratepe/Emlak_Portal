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
            mockCustomer.Houses.Add(tempHouseForCustomer);

            Assert.IsTrue(mockCustomer.Houses.Count > 0);
        }

        [TestMethod]
        public void Customer_HasTwoHouseAssociated()
        {
            House tempHouseForCustomer = DomainMocksFactory.CreateHouse();
            mockCustomer.Houses.Add(tempHouseForCustomer);
            mockCustomer.Houses.Add(tempHouseForCustomer);

            Assert.IsTrue(mockCustomer.Houses.Count > 1);
            
        }
    }
}
