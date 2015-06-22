using System.Collections.Generic;
using System.Linq;
using Ltd.NA.Emlak.Domain;
using Ltd.NA.Emlak.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Data.Entity;

namespace Ltd.NA.Emlak.Data.Tests
{
    [TestClass]
    public class AgentTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            using (var context = new DatabaseContext())
            {
                List<Agent> agents = context.Agents.ToList();
                foreach (Agent agent in agents)
                {
                    context.Agents.Remove(agent);
                }
                List<House> houses = context.Set<House>().ToList();
                foreach (House house in houses)
                {
                    context.Set<House>().Remove(house);
                }

                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var context = new DatabaseContext())
            {
                List<Agent> agents = context.Agents.ToList();
                foreach (Agent agent in agents)
                {
                    context.Agents.Remove(agent);
                }
                List<House> houses = context.Set<House>().ToList();
                foreach (House house in houses)
                {
                    context.Set<House>().Remove(house);
                }

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Agent_Can_Be_Created_With_DB()
        {
            using (var context = new DatabaseContext())
            {
                context.Database.Log = delegate(string s)
                {
                    Debug.WriteLine(s);
                };
                Agent agent = DomainMocksFactory.CreateAgent();
                context.Agents.Add(agent);

                context.SaveChanges();
            }

            using (var context = new DatabaseContext())
            {
                Agent agent = context.Agents.FirstOrDefault();
                //Assert.Inconclusive("Verify all properties");
            }
        }

        [TestMethod]
        public void Agent_Can_get_House_InDB()
        {
            using (var context = new DatabaseContext())
            {
                Agent agent = DomainMocksFactory.CreateAgent();
                House house = DomainMocksFactory.CreateHouse();
                agent.AddHouse(house);

                context.Agents.Add(agent);

                context.SaveChanges();
            }

            using (var context = new DatabaseContext())
            {
                Agent agent = context.Agents
                    .Include(x => x.HousesInCharge)
                    .FirstOrDefault();

                Assert.IsTrue(agent.HousesInCharge.Count > 0);
            }
        }

        [TestMethod]
        public void Agent_WithOneHouse_CanRemoveHouse()
        {
            Assert.Inconclusive("To do");
        }

        [TestMethod]
        public void Agent_WithTwoHouses_CanRemoveOneHouse_AndKeepTheOther()
        {
            Assert.Inconclusive("To do");
        }

        [TestMethod]
        public void Agent_IsDeleted_DoesNotDelete_Houses()
        {
            Assert.Inconclusive("To do");
        }
    }
}