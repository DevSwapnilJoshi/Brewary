using EGlossary.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Seeds
{
    public class CustomerSeedData
    {
        public static async Task Seed(InMemoryDbContext context)
        {
            var customers = new List<CustomerDataModel>
            {
                new()
                {
                    CustomerName ="Swapnil",
                    ContactName = "Swapnil Joshi",
                    ContactTitle = "Mr",
                    Address = "Kasar Amoboli",
                    City = "Pune",
                    Region = "Pune",
                    PostalCode = "4158781",
                    Country = "India",
                    Phone = "589774455",
                    Fax = string.Empty,
                    CreatedBy = 1001,
                    CreatedDate = DateTime.Now.AddDays(-1).Date
                },
                new ()
                {
                    CustomerName ="Madhav",
                    ContactName = "Murarai",
                    ContactTitle = "Mr",
                    Address = "Krishna Temple ",
                    City = "vrindavan",
                    Region = "vrindavan",
                    PostalCode = "281121",
                    Country = "India",
                    Phone = "815d8781124",
                    Fax = string.Empty,
                    CreatedBy = 1002,
                    CreatedDate = DateTime.Now.AddDays(-5).Date
                }
              };

            context.Customer.AddRange(customers);
            await context.SaveChangesAsync();
        }
    }
}