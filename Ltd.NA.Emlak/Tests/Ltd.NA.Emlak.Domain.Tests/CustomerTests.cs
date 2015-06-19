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
        public void CustomerIsActive()
        {
            Assert.IsTrue(mockCustomer.active);
        }

        [TestMethod]
        public void Customer_Requirement_Test_For_Sale()
        {
            Assert.IsFalse(mockCustomer.CustomerLookingFor);
        }

        [TestMethod]
        public void Customer_Person_Informations()
        {
            Assert.IsTrue(mockCustomer.FirstName == "John");
            Assert.IsTrue(mockCustomer.LastName == "Lion");
            Assert.IsTrue(mockCustomer.Age == 35);
        }

        [TestMethod]
        public void Customer_Can_Get_A_House()
        {
            Assert.IsNotNull(mockCustomer.House);
        }

        [TestMethod]
        public void Customer_House_Informations()
        {
            Assert.IsTrue(mockCustomer.House.Name == "My Name");
        }
    }
}
