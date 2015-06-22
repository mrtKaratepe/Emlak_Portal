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
            using (var context = new DatabaseContext())
            {
                //First Add House To The Agent
                House firstHouse = DomainMocksFactory.CreateHouse();
                Agent mocksAgent = DomainMocksFactory.CreateAgent();
                mocksAgent.HousesInCharge.Add(firstHouse);

                context.Agents.Add(mocksAgent);

                context.SaveChanges();
            }

            using (var context = new DatabaseContext())
            {
                Agent agent = context.Agents
                    .Include(x => x.HousesInCharge)
                    .FirstOrDefault();
                
                //Verify that we added to house to the agent.
                Assert.IsTrue(agent.HousesInCharge.Count == 1);

                //Then remove that house from agent.
                agent.HousesInCharge.RemoveAt(0);
                context.SaveChanges();
            }

            using (var context = new DatabaseContext())
            {
                Agent agent = context.Agents
                    .Include(x => x.HousesInCharge)
                    .FirstOrDefault();

                //Verify that you removed house from agent.
                Assert.IsTrue(agent.HousesInCharge.Count == 0);
            }
            
        }

        [TestMethod]
        public void Agent_WithTwoHouses_CanRemoveOneHouse_AndKeepTheOther()
        {
            using (var context = new DatabaseContext())
            {
                //First Add House To The Agent
                House firstHouse = DomainMocksFactory.CreateHouse();
                House secondHouse = DomainMocksFactory.CreateHouse();
                Agent mocksAgent = DomainMocksFactory.CreateAgent();
                
                mocksAgent.HousesInCharge.Add(firstHouse);
                mocksAgent.HousesInCharge.Add(secondHouse);

                context.Agents.Add(mocksAgent);

                context.SaveChanges();
            }

            using (var context = new DatabaseContext())
            {
                Agent agent = context.Agents
                    .Include(x => x.HousesInCharge)
                    .FirstOrDefault();

                //Verify that we added to houses to the agent.
                Assert.IsTrue(agent.HousesInCharge.Count == 2);

                //Then remove that house from agent.
                agent.HousesInCharge.RemoveAt(1);
                context.SaveChanges();
            }

            using (var context = new DatabaseContext())
            {
                Agent agent = context.Agents
                    .Include(x => x.HousesInCharge)
                    .FirstOrDefault();

                //Verify that you removed house from agent.
                Assert.IsTrue(agent.HousesInCharge.Count == 1);
            }
        }

        [TestMethod]
        public void Agent_IsDeleted_DoesNotDelete_Houses()
        {
            using (var context = new DatabaseContext())
            {
                Agent agent = DomainMocksFactory.CreateAgent();
                House house = DomainMocksFactory.CreateHouse();

                agent.HousesInCharge.Add(house);

                context.Houses.Add(house);
                context.Agents.Add(agent);

                context.SaveChanges();

            }

            using (var context = new DatabaseContext())
            {
                Agent agent = context.Agents
                    .Include(x => x.HousesInCharge)
                    .FirstOrDefault();
                //Verify that you have a proper agent object with house.
                Assert.IsTrue(agent.HousesInCharge.Count > 0);

                //Delete Agent object.
                context.Agents.Remove(agent);

                context.SaveChanges();
            }

            using (var context = new DatabaseContext())
            {
                House house = context.Houses.FirstOrDefault();
                Agent agent = context.Agents
                    .Include(x => x.HousesInCharge)
                    .FirstOrDefault();

                Assert.IsNotNull(house);
            }
        }


    }
}