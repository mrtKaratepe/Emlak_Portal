using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Agent : Person
    {

        public string agentName
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public House HouseInCharge
        {
            get;
            set;
        }


        public static Agent Create(string name, string description)
        {
            return new Agent
            {
                agentName=name,
                Description=description
            };
        }
    }
}
