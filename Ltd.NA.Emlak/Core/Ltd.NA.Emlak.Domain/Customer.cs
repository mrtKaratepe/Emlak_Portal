using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Customer : Person
    {

        public int TcNo
        {
            get;
            private set;
        }

        public Boolean active
        {
            get;
            private set;
        }

        public Boolean Rent
        {
            get;
            private set;
        }

        public House House
        {
            get;
            private set;
        }

        public void AddHouse(string name, string description)
        {
            this.House = House.Create(Guid.NewGuid(), name, description);
        }

        public Boolean CustomerIsActive
        {
            get { return active; }
        }

        public static Customer create(int tcNo, Boolean active, Boolean Rent)
        {
            return new Customer
            {
                TcNo = tcNo,
                active = active,
                Rent = Rent
            };
        }

        public Boolean CustomerLookingFor
        {
            get {return Rent;}
        }
    }
}
