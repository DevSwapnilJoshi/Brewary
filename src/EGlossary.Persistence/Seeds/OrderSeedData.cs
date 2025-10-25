using EGlossary.Domain.Enum;
using EGlossary.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Seeds
{
    public class OrderSeedData
    {
        public static async Task Seed(InMemoryDbContext context)
        {
            var orders = new List<OrderDataModel>
            {
                new()
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-3).Date,
                    OrderFulfillmentDate =null,
                    OrderStatus="Open",
                    ProductDetails = new List<ProductDataModel>()
                    {
                        new()
                        {
                            ProductName = "Mobile",
                            UnitPrice= 45000,
                            UnitOfMeasurement = UnitOfMeasurement.Unity,
                            Sizes = Sizes.Inch,
                            CategoryId = 101
                        }
                    },
                    CreatedDate = DateTime.Now.AddDays(-3).Date,
                },
                new()
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-2).Date,
                    OrderFulfillmentDate =null,
                    OrderStatus="Open",
                    ProductDetails = new List<ProductDataModel>()
                    {
                        new()
                        {
                            ProductName = "MI",
                            UnitPrice= 46000,
                            UnitOfMeasurement = UnitOfMeasurement.Unity,
                            Sizes = Sizes.Inch,
                            CategoryId = 101
                        }
                    },
                    CreatedDate = DateTime.Now.AddDays(-2).Date,
                },
                new()
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-1).Date,
                    OrderFulfillmentDate =null,
                    OrderStatus="Open",
                    ProductDetails = new List<ProductDataModel>()
                    {
                        new()
                        {
                            ProductName = "Desgin",
                            UnitPrice= 4000,
                            UnitOfMeasurement = UnitOfMeasurement.Unity,
                            Sizes = Sizes.Inch,
                            CategoryId = 102
                        }
                    },
                    CreatedDate = DateTime.Now.AddDays(-1).Date,
                },
             };

            context.Order.AddRange(orders);
            await context.SaveChangesAsync();
        }
    }
}