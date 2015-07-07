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
        public const string HOUSE_NAME = "My house";
        public const string HOUSE_DESC = "My Description";

        public static House CreateHouse()
        {
            return House.Create(HOUSE_NAME, HOUSE_DESC,CreateCustomer());
        }

        public static Customer CreateCustomer(){
            Customer customer = Customer.Create("first name","last name",99,"tax number");
            return customer;

        }

        public static Agent CreateAgent()
        {
            Agent agent = Agent.Create("first name","last name",99,"code", "description");
            return agent;
        }
    }
}
