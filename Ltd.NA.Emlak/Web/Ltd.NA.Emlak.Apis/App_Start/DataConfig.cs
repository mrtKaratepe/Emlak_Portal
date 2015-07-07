using Ltd.NA.Emlak.Data;
using Ltd.NA.Emlak.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ltd.NA.Emlak.Apis
{
    public class DataConfig
    {
        public static void Initialize()
        {
            // cleanup before start

            using (DatabaseContext context = new DatabaseContext())
            {
                Customer customer = Customer.Create("First Name", "Last Name", 43, "12345ABCDE");

                House firstHouse = House.Create("First house", "Description for the house", customer);
                firstHouse.AddAddress("100/1 Sokak", "Izmir", "Turkey", "23A", "35600");

                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}