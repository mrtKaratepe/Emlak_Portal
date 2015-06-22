using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Customer : Person
    {

        public string TaxNumber
        {
            get;
            private set;
        }

        public IList<House> Houses
        {
            get;
            private set;
        }

        internal void AddHouse(House house)
        {
            this.Houses.Add(house);
        }

        public void RemoveHouse(House house)
        {
            this.Houses.Remove(house);
        }

        public static Customer create(string firstName, string lastName, int age, string taxNumber)
        {
            return new Customer(firstName, lastName, age, taxNumber);
        }

        [Obsolete("Don't use this, it is only for EF")]
        protected Customer()
        {

        }

        private Customer(string firstName, string lastName, int age, string tcNo)
            : base(firstName, lastName, age)
        {
            this.Houses = new List<House>();
        }
    }
}
