using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Mocks;

namespace Ltd.NA.Emlak.Domain.Tests
{
    [TestClass]
    public class AgentTests
    {
        private Agent mocksAgent;

        [TestInitialize]
        public void testInitialize()
        {
            mocksAgent = DomainMocksFactory.CreateAgent();
        }

        [TestMethod]
        public void Agent_Created()
        {
            Assert.IsNotNull(mocksAgent);
        }

        [TestMethod]
        public void Agent_Created_HasProperties()
        {
            Assert.IsNotNull(mocksAgent.FirstName);
            Assert.IsNotNull(mocksAgent.LastName);
        }

        [TestMethod]
        public void Agent_Has_HouseAssociated()
        {
            House tempMocksHouse = DomainMocksFactory.CreateHouse();
            mocksAgent.HousesInCharge.Add(tempMocksHouse);
            Assert.IsTrue(mocksAgent.HousesInCharge.Count > 0);
        }

        [TestMethod]
        public void Agent_RemoveHouse_AssociationsAreRemoved()
        {
            House tempMocksHouse = DomainMocksFactory.CreateHouse();
            mocksAgent.HousesInCharge.Add(tempMocksHouse);
            Assert.IsTrue(mocksAgent.HousesInCharge.Count > 0);

            mocksAgent.HousesInCharge.Remove(tempMocksHouse);
            Assert.IsTrue(mocksAgent.HousesInCharge.Count == 0);

        }
    }
}
