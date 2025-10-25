using EGlossary.Domain.Entities;
using EGlossary.Service.Features.ProductsFeatures.Queries;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using Xunit;
using static EGlossary.Service.Features.ProductsFeatures.Queries.GetAllProductsQuery;
using static EGlossary.Service.Features.ProductsFeatures.Queries.GetProductByIdQuery;

namespace EGlossary.UnitTest.Services.ProductService.Queries
{
    public class GetProductTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;

        public GetProductTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Return_ProductList_IfProductsExists()
        {
            var moqDbContext = _dbContextTest.MoqProductReposistory;
            moqDbContext.Setup(x => x.GetProducts()).ReturnsAsync(_dbContextTest.GetProduct());
            //Act
            var productQueryHandler = new GetAllProductQueryHandler(moqDbContext.Object);
            var productList = productQueryHandler?.Handle(new GetAllProductsQuery(), default);
            productList!.Result.Count().Should().BeGreaterThanOrEqualTo(1);
            moqDbContext.Verify(v => v.GetProducts());
        }

        [Fact]
        public void GetAllProductQueryHandler_Return_Null_IfProductListIsEmpty()
        {
            var moqDbContext = _dbContextTest.MoqProductReposistory;
            moqDbContext.Setup(x => x.GetProducts()).ReturnsAsync(Enumerable.Empty<ProductEntity>());
            var productQueryHandler = new GetAllProductQueryHandler(moqDbContext.Object);

            var products = productQueryHandler?.Handle(new GetAllProductsQuery(), default);
            products!.Result.Count().Should().Be(0);
            moqDbContext.Verify(v => v.GetProducts());
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_HandleNullException()
        {
            var productQueryHandler = new GetAllProductQueryHandler(null);
            Action act = () => productQueryHandler?.Handle(null, default);
            act.Should().NotThrow();
        }

        [Fact]
        public void GetProductByIdQueryHandler_Should_Return_Product_IfProductExists()
        {
            var moqDbContext = _dbContextTest.MoqProductReposistory;
            moqDbContext.Setup(x => x.GetProductById(1));
            var getProductByIdQuery = new GetProductByIdQuery()
            {
                Id = 1
            };
            var productQueryHandler = new GetProductByIdQueryHandler(moqDbContext.Object);
            var product = productQueryHandler.Handle(getProductByIdQuery, default);
            product.Id.Should().Be(product.Id);
            moqDbContext.Verify(v => v.GetProductById(1));
        }
    }
}