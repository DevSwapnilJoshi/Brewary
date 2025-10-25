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
    public class OrderReposistoryTest
    {
        private readonly DbContextOptionsBuilder<InMemoryDbContext> dbContext;
        private readonly InMemoryDbContext _imDbContext;
        private readonly OrderReposistory _orderReposistory;
        public IMapper _moqMapper;

        public OrderReposistoryTest()
        {
            dbContext = new DbContextOptionsBuilder<InMemoryDbContext>();
            dbContext.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _imDbContext = new InMemoryDbContext(dbContext.Options);
            _moqMapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
            _orderReposistory = new OrderReposistory(_imDbContext, _moqMapper);
        }

        [Fact]
        public async Task CreateOrder_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _orderReposistory.CreateOrder(new OrderEntity());
            response.Should().NotBe(null);
            response.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task GetAll_Order_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _orderReposistory.GetAllOrders();
            response.Should().NotBeEmpty();
            response.Count().Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Get_Order_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _orderReposistory.GetOrderById(1);
            response.Id.Should().Be(1);
        }

        [Fact]
        public async Task Delete_Order_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _orderReposistory.DeleteOrder(1);
            response.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateOrder_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _orderReposistory.UpdateOrder(1, new OrderEntity());
            response.Should().NotBe(0);
        }
    }
}