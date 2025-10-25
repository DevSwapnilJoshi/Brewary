using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Service.Features.OrderFeatures.Commands;
using EGlossary.Service.Models;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using Xunit;

namespace EGlossary.UnitTest.Services.OrderService.Commands
{
    public class UpdateOrderCommandTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        public Mock<IMapper> _moqMapper;

        public UpdateOrderCommandTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _moqMapper = new Mock<IMapper>();
        }

        [Fact]
        public void UpdateOrderTest_With_ValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqOrderReposistory;
            moqDbContext.Setup(x => x.UpdateOrder(1, It.IsAny<OrderEntity>())).ReturnsAsync(1);
            var updateOrderCommandHandler = new UpdateOrderCommand(moqDbContext.Object, _moqMapper.Object);
            var response = updateOrderCommandHandler.Handle(new OrderDto() { OrderId = 1, OrderStatus = "Updated" }, default);
            response.Should().NotBeNull();
            response.Result.Should().NotBe(0);
            moqDbContext.Setup(s => s.CreateOrder(It.IsAny<OrderEntity>()));
        }
    }
}