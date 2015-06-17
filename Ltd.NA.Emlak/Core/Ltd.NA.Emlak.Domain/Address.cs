using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Address
    {
        private string adressLine1 { get; set; }
        private string adressLine2 { get; set; }
        private int number { get; set; }
        private string zipCode { get; set; }
        private string city { get; set; }
        private string country { get; set; }
        private string county { get; set; }

        


        public static Address Create(string adressLine1, int number, string city, string country)
        {
            return new Address
            {
                adressLine1 = adressLine1,
                number = number,
                city = city,
                country = country
            };
        }
    }
}
