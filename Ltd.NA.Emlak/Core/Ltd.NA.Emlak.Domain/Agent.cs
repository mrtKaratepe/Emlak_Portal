using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Agent : Person
    {

        public string AgentCode
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public IList<House> HousesInCharge
        {
            get;
            private set;
        }

        public void AddHouse(House house)
        {
            house.AssociateAgent(this);
            this.HousesInCharge.Add(house);
        }

        public void RemoveHouse(House house)
        {
            house.AssociateAgent(null);
            this.HousesInCharge.Remove(house);
        }

        public static Agent Create(string firstName, string lastName, int age, string code, string description)
        {

            return new Agent(firstName, lastName, age, code, description);
        }

        [Obsolete("Don't use this, it is only for EF")]
        protected Agent()
        {
            
        }

        private Agent(string firstName, string lastName, int age, string code, string description)
            : base(firstName, lastName, age)
        {
            this.HousesInCharge = new List<House>();
            this.AgentCode = code;
            this.Description = description;
        }
    }
}
