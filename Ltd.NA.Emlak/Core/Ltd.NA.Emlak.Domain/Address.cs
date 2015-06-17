using System;
namespace Ltd.NA.Emlak.Domain
{
    public class Address
    {
        private readonly Guid id;
        private readonly string address1;
        private readonly string city;
        private readonly string country;
        private readonly string number;
        private readonly string zipCode;

        internal Address(string address1,
            string city,
            string country,
            string number,
            string zipCode)
        {
            this.id = Guid.NewGuid();
            this.address1 = address1;
            this.city = city;
            this.country = country;
            this.number = number;
            this.zipCode = zipCode;
        }

        public Guid Id
        {
            get { return this.id; }
        }

        public string Address1
        {
            get { return address1; }
        }

        public string Address2 { get; set; }

        public string Number
        {
            get { return number; }
        }

        public string City
        {
            get { return city; }
        }

        public string Province { get; set; }

        public string ZipCode
        {
            get { return zipCode; }
        }

        public string Country
        {
            get { return country; }
        }
    }
}