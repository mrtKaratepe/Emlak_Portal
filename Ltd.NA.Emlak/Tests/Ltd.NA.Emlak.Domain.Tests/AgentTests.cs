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
            Assert.Inconclusive("to refactor");
        }

        [TestMethod]
        public void Agent_Has_HouseAssociated()
        {
            Assert.Inconclusive("to refactor");
        }

        [TestMethod]
        public void Agent_RemoveHouse_AssociationsAreRemoved()
        {
            Assert.Inconclusive("to refactor");

        }
    }
}
