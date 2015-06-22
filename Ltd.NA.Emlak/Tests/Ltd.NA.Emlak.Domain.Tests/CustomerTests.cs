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
            Assert.Inconclusive("to refactor");
        }

        [TestMethod]
        public void Customer_HasOneHouseAssociated()
        {
            Assert.Inconclusive("to refactor");
        }

        [TestMethod]
        public void Customer_HasTwoHouseAssociated()
        {
            Assert.Inconclusive("to refactor");
        }
    }
}
