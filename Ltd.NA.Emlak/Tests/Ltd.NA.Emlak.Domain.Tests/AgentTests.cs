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
        public void Agent_Informations()
        {
            Assert.IsTrue(mocksAgent.agentName == "Uckuyular");
            Assert.IsNotNull(mocksAgent.Description);
        }

        [TestMethod]
        public void Agent_Personal_informations()
        {
            Assert.IsTrue(mocksAgent.FirstName == "John");
            Assert.IsNotNull(mocksAgent.LastName);
        }
    }
}
