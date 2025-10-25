using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Service.Features.ProductsFeatures.Commands;
using EGlossary.Service.Models;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using Xunit;

namespace EGlossary.UnitTest.Services.ProductService.Commands
{
    public class CreateProductCommandTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        public Mock<IMapper> _moqMapper;

        public CreateProductCommandTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _moqMapper = new Mock<IMapper>();
        }

        [Fact]
        public void CreateProductTest_With_ValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqProductReposistory;
            moqDbContext.Setup(x => x.CreateProducts(It.IsAny<ProductEntity>())).ReturnsAsync(1);
            var productCommandHandler = new CreateProductCommand(moqDbContext.Object, _moqMapper.Object);
            var response = productCommandHandler.Handle(new ProductDto(), default);
            response.Should().NotBeNull();
            response.Result.Should().Be(1);
            moqDbContext.Setup(s => s.CreateProducts(It.IsAny<ProductEntity>()));
        }

        [Fact]
        public void CreateProductTest_With_ValidInValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqProductReposistory;
            moqDbContext.Setup(x => x.CreateProducts(It.IsAny<ProductEntity>())).ReturnsAsync(0);
            var productCommandHandler = new CreateProductCommand(moqDbContext.Object, _moqMapper.Object);
            var response = productCommandHandler.Handle(new ProductDto(), default);
            response.Should().NotBeNull();
            response.Result.Should().Be(0);
            moqDbContext.Setup(s => s.CreateProducts(It.IsAny<ProductEntity>()));
        }
    }
}