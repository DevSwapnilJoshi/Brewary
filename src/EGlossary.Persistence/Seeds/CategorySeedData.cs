using EGlossary.Domain.Enum;
using EGlossary.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Seeds
{
    public class CategorySeedData
    {
        public static async Task Seed(InMemoryDbContext context)
        {
            var productsElectronic = new List<ProductDataModel>
            {
                new()
                {
                    ProductName = "i-Phone",
                    UnitPrice= 145000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },
                 new()
                {
                    ProductName = "Samsung",
                    UnitPrice= 55000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },
                new()
                {
                    ProductName = "MI",
                    UnitPrice= 14000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },
                new()
                {
                    ProductName = "Moto",
                    UnitPrice= 14000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },
                  new()
                {
                    ProductName = "Motorola",
                    UnitPrice= 14000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },
                   new()
                {
                    ProductName = "Oppo",
                    UnitPrice= 14000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },

                new()
                {
                    ProductName = "HTC",
                    UnitPrice= 14000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },
                  new()
                {
                    ProductName = "Intex ",
                    UnitPrice= 14000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mobile"
                },
                new()
                {
                    ProductName = "MI",
                    UnitPrice = 12200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Television"
                },
                new()
                {
                    ProductName = "LG",
                    UnitPrice = 12200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Television"
                },
                    new()
                {
                    ProductName = "MI",
                    UnitPrice = 12200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Television"
                },
                new()
                {
                    ProductName = "Sony",
                    UnitPrice = 12200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Television"
                },
                new()
                {
                    ProductName = "TCL",
                    UnitPrice = 12200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Television"
                },
                   new()
                {
                    ProductName = "Tecno",
                    UnitPrice = 12200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Television"
                },
                   new()
                {
                    ProductName = "Toshiba",
                    UnitPrice = 12200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Television"
                },
                     new()
  {
      ProductName = "MI",
      UnitPrice = 12200,
      UnitOfMeasurement = UnitOfMeasurement.Unity,
      Sizes = Sizes.Inch,
      CategoryId = 101,
      CreatedBy=1001,
      CreatedDate=DateTime.Now.AddDays(-2).Date,
      SubCategory = "Laptop"
  },
  new()
  {
      ProductName = "LG",
      UnitPrice = 12200,
      UnitOfMeasurement = UnitOfMeasurement.Unity,
      Sizes = Sizes.Inch,
      CategoryId = 101,
      CreatedBy=1001,
      CreatedDate=DateTime.Now.AddDays(-2).Date,
      SubCategory = "Laptop"
  },
      new()
  {
      ProductName = "MI",
      UnitPrice = 12200,
      UnitOfMeasurement = UnitOfMeasurement.Unity,
      Sizes = Sizes.Inch,
      CategoryId = 101,
      CreatedBy=1001,
      CreatedDate=DateTime.Now.AddDays(-2).Date,
      SubCategory = "Laptop"
  },
  new()
  {
      ProductName = "Sony",
      UnitPrice = 12200,
      UnitOfMeasurement = UnitOfMeasurement.Unity,
      Sizes = Sizes.Inch,
      CategoryId = 101,
      CreatedBy=1001,
      CreatedDate=DateTime.Now.AddDays(-2).Date,
      SubCategory = "Laptop"
  },
  new()
  {
      ProductName = "TCL",
      UnitPrice = 12200,
      UnitOfMeasurement = UnitOfMeasurement.Unity,
      Sizes = Sizes.Inch,
      CategoryId = 101,
      CreatedBy=1001,
      CreatedDate=DateTime.Now.AddDays(-2).Date,
      SubCategory = "Laptop"
  },
  new()
      {
          ProductName = "Tecno",
          UnitPrice = 12200,
          UnitOfMeasurement = UnitOfMeasurement.Unity,
          Sizes = Sizes.Inch,
          CategoryId = 101,
          CreatedBy=1001,
          CreatedDate=DateTime.Now.AddDays(-2).Date,
          SubCategory = "Laptop"
      },
  new()
      {
          ProductName = "Toshiba",
          UnitPrice = 12200,
          UnitOfMeasurement = UnitOfMeasurement.Unity,
          Sizes = Sizes.Inch,
          CategoryId = 101,
          CreatedBy=1001,
          CreatedDate=DateTime.Now.AddDays(-2).Date,
          SubCategory = "Laptop"
      },
 new()
      {
          ProductName = "HP",
          UnitPrice = 12200,
          UnitOfMeasurement = UnitOfMeasurement.Unity,
          Sizes = Sizes.Inch,
          CategoryId = 101,
          CreatedBy=1001,
          CreatedDate=DateTime.Now.AddDays(-2).Date,
          SubCategory = "Laptop"
      },
  new()
      {
          ProductName = "DELL",
          UnitPrice = 12200,
          UnitOfMeasurement = UnitOfMeasurement.Unity,
          Sizes = Sizes.Inch,
          CategoryId = 101,
          CreatedBy=1001,
          CreatedDate=DateTime.Now.AddDays(-2).Date,
          SubCategory = "Laptop"
      },
  new()
      {
          ProductName = "lenovo",
          UnitPrice = 12200,
          UnitOfMeasurement = UnitOfMeasurement.Unity,
          Sizes = Sizes.Inch,
          CategoryId = 101,
          CreatedBy=1001,
          CreatedDate=DateTime.Now.AddDays(-2).Date,
          SubCategory = "Laptop"
      },
    };

            var productsCloths = new List<ProductDataModel>
            {
                new()
                {
                    ProductName = "T-Shirt",
                    UnitPrice= 45000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                    SubCategory = "Mens"
                },
                new()
                {
                    ProductName = "Shirt",
                    UnitPrice = 1200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 102,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Mens"
                },
                  new()
                {
                    ProductName = "pant",
                    UnitPrice = 1200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 102,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Mens"
                },
                 new()
                {
                    ProductName = "blazer",
                    UnitPrice = 1200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 102,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                    SubCategory = "Mens"
                },

                 new()
{
    ProductName = "T-Shirt",
    UnitPrice= 45000,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 101,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-1).Date,
    SubCategory = "Kids"
},
new()
{
    ProductName = "Shirt",
    UnitPrice = 1200,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 102,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-2).Date,
    SubCategory = "Kids"
},
  new()
{
    ProductName = "pant",
    UnitPrice = 1200,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 102,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-2).Date,
    SubCategory = "Kids"
},
 new()
{
    ProductName = "blazer",
    UnitPrice = 1200,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 102,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-2).Date,
    SubCategory = "Kids"
},

 new()
{
    ProductName = "T-Shirt",
    UnitPrice= 45000,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 101,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-1).Date,
    SubCategory = "Woman"
},
new()
{
    ProductName = "Shirt",
    UnitPrice = 1200,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 102,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-2).Date,
    SubCategory = "Woman"
},
  new()
{
    ProductName = "pant",
    UnitPrice = 1200,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 102,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-2).Date,
    SubCategory = "Woman"
},
 new()
{
    ProductName = "blazer",
    UnitPrice = 1200,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 102,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-2).Date,
    SubCategory = "Woman"
},
  new()
{
    ProductName = "kurtis",
    UnitPrice = 1200,
    UnitOfMeasurement = UnitOfMeasurement.Unity,
    Sizes = Sizes.Inch,
    CategoryId = 102,
    CreatedBy=1001,
    CreatedDate=DateTime.Now.AddDays(-2).Date,
    SubCategory = "Woman"
}
            };
            var categories = new List<CategoryDataModel>
            {
                new() { Id = 101, CategoryName = "Electronic Device", Products = productsElectronic},
                new() { Id = 102, CategoryName = "Cloths" ,Products =productsCloths}
            };

            context.Category.AddRange(categories);

            await context.SaveChangesAsync();
        }
    }
}