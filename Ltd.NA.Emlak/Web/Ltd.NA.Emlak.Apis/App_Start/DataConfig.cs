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
                firstHouse.AddAddress("111/1 Sokak", "Izmir", "Turkey", "23A", "35600");
                //---
                Customer customer2 = Customer.Create("First Name", "Last Name", 43, "12345ABCDE");

                House secondHouse = House.Create("First house", "Description for the house", customer2);
                secondHouse.AddAddress("222/1 Sokak", "Izmir", "Turkey", "23A", "35600");
                //---
                Customer customer3 = Customer.Create("First Name", "Last Name", 43, "12345ABCDE");

                House thirdHouse = House.Create("First house", "Description for the house", customer3);
                thirdHouse.AddAddress("333/1 Sokak", "Izmir", "Turkey", "23A", "35600");


                context.Customers.Add(customer);
                context.Customers.Add(customer2);
                context.Customers.Add(customer3);
                context.SaveChanges();
            }
        }
    }
}