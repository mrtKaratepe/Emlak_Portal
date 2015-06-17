using System;
namespace Ltd.NA.Emlak.Domain
{
    public class Address
    {

        internal Address(string address1,
            string city,
            string country,
            string number,
            string zipCode)
        {
            this.Id = Guid.NewGuid();
            this.Address1 = address1;
            this.City = city;
            this.Country = country;
            this.Number = number;
            this.ZipCode = zipCode;
        }

        protected Address()
        {
            
        }

        public Guid Id
        {
            get;
            private set;
        }

        public string Address1
        {
            get;
            private set;
        }

        public string Address2 { get; set; }

        public string Number
        {
            get;
            private set;
        }

        public string City
        {
            get;
            private set;
        }

        public string Province { get; set; }

        public string ZipCode
        {
            get;
            private set;
        }

        public string Country
        {
            get;
            private set;
        }
    }
}