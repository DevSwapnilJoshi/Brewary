using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Persistence;
using EGlossary.Persistence.Reposistory;
using EGlossary.Service.Mapping;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EGlossary.UnitTest.Reposistory
{
    public class ProductReposistoryTest
    {
        private readonly DbContextOptionsBuilder<InMemoryDbContext> dbContext;
        private readonly InMemoryDbContext _imDbContext;
        private readonly ProductReposistory _productReposistory;
        public IMapper _moqMapper;

        public ProductReposistoryTest()
        {
            dbContext = new DbContextOptionsBuilder<InMemoryDbContext>();
            dbContext.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _imDbContext = new InMemoryDbContext(dbContext.Options);

            _moqMapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
            _productReposistory = new ProductReposistory(_imDbContext, _moqMapper);
        }

        [Fact]
        public async Task CreateProduct_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _productReposistory.CreateProducts(new ProductEntity());
            response.Should().NotBe(null);
            response.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task GetAll_Product_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _productReposistory.GetProducts();
            response.Count().Should().Be(0);
        }

        [Fact]
        public async Task Get_Product_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _productReposistory.GetProductById(1);
            response.Should().BeNull();
        }
    }
}