using Ltd.NA.Emlak.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Mocks
{
    public class DomainMocksFactory
    {
        public static House CreateHouse()
        {
            return House.Create(Guid.NewGuid(), "My Name", "My Description");
        }

        public static Customer CreateCustomer(){
            Customer customer = Customer.create(123456789, true, false);
            customer.FirstName = "John";
            customer.LastName = "Lion";
            customer.AddHouse( "My Name", "My Description");
            customer.Age = 35;
            return customer;

        }

        public static Agent CreateAgent()
        {
            Agent agent = Agent.Create("Uckuyular", "Uckuyular Tansas Bolge");
            agent.FirstName = "John";
            agent.LastName = "Lion";
            agent.AddHouse("My Name", "My Description");
            return agent;
        }
    }
}
