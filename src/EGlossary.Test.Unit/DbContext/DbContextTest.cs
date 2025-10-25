using AutoFixture;
using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.Enum;
using EGlossary.Domain.InterfaceReposistory;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;

namespace EGlossary.UnitTest.DbContext
{
    public class DbContextTest
    {
        public Mock<IProductReposistory> MoqProductReposistory;
        public Mock<IOrderReposistory> MoqOrderReposistory;
        public Mock<ICustomerReposistory> MoqCustomerReposistory;
        public Mock<ICategoryReposistory> MoqCategoryReposistory;
        public Fixture Fixture;
        public Mock<IMapper> MoqMapper;
        public Mock<HttpResponse> HttpResponseMock;

        public DbContextTest()
        {
            MoqProductReposistory = new Mock<IProductReposistory>();
            MoqOrderReposistory = new Mock<IOrderReposistory>();
            MoqCustomerReposistory = new Mock<ICustomerReposistory>();
            MoqCategoryReposistory = new Mock<ICategoryReposistory>();
            Fixture = new Fixture();
            MoqMapper = new Mock<IMapper>();
            HttpResponseMock = new Mock<HttpResponse>();
        }

        public IEnumerable<ProductEntity> GetProduct()
        {
            return new List<ProductEntity>
            {
                new()
                {
                    ProductName = "Mobile",
                    UnitPrice= 45000,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 101,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-1).Date,
                },
                new()
                {
                    ProductName = "T-Shirt",
                    UnitPrice = 1200,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    Sizes = Sizes.Inch,
                    CategoryId = 102,
                    CreatedBy=1001,
                    CreatedDate=DateTime.Now.AddDays(-2).Date,
                }
            };
        }
    }
}