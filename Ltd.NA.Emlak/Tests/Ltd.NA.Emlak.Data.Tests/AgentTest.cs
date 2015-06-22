using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ltd.NA.Emlak.Domain;
using System.Linq;

namespace Ltd.NA.Emlak.Data.Tests
{
    [TestClass]
    public class AgentTest
    {

        [TestInitialize]
        public void TestInitialize()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var agents = context.Agents.ToList();
                foreach (var agent in agents)
                {
                    context.Agents.Remove(agent);
                }
                var houses = context.Set<House>().ToList();
                foreach (var house in houses)
                {
                    context.Set<House>().Remove(house);
                }

                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var agents = context.Agents.ToList();
                foreach (var agent in agents)
                {
                    context.Agents.Remove(agent);
                }
                var houses = context.Set<House>().ToList();
                foreach (var house in houses)
                {
                    context.Set<House>().Remove(house);
                }

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Agent_Can_Be_Created_With_DB()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                Agent agent = Agent.Create("Agent Name","Agent Description");
                context.Agents.Add(agent);

                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                Agent agent = context.Agents.FirstOrDefault();
                Assert.IsTrue(agent.agentName == "Agent Name");
                Assert.IsTrue(agent.Description == "Agent Description");
            }
        }

        [TestMethod]
        public void Agent_Can_get_House_InDB()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                Agent agent = Agent.Create("Agent Name", "Agent Description");
                agent.AddHouse("New Agent House", "Description");

                context.Agents.Add(agent);
                
                context.SaveChanges();
            }

            using (DatabaseContext context = new DatabaseContext())
            {
                Agent agent = context.Agents
                    .Include("House")
                    .FirstOrDefault();


                Assert.IsTrue(agent.HouseInCharge.Name == "New Agent House");
                Assert.IsTrue(agent.HouseInCharge.Description == "Description");

            }
        }



    }
}
