using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Agent : Person
    {

        public string AgentName
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public IEnumerable<House> HouseInCharge
        {
            get;
            private set;
        }

        public void AddHouse(string name, string description)
        {
            this.HouseInCharge = House.Create(Guid.NewGuid(),name,description);
        }


        public static Agent Create(string name, string description)
        {
            return new Agent
            {
                AgentName=name,
                Description=description
            };
        }
    }
}
