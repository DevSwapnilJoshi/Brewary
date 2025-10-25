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
    public class CreateOrderCommandTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        public Mock<IMapper> _moqMapper;

        public CreateOrderCommandTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _moqMapper = new Mock<IMapper>();
        }

        [Fact]
        public void CreateOrderTest_With_ValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqOrderReposistory;
            moqDbContext.Setup(x => x.CreateOrder(It.IsAny<OrderEntity>())).ReturnsAsync(1);
            var createOrderCommandHandler = new CreateOrderCommand(moqDbContext.Object, _moqMapper.Object);
            var response = createOrderCommandHandler.Handle(new OrderDto(), default);
            response.Should().NotBeNull();
            response.Result.Should().Be(1);
            moqDbContext.Setup(s => s.CreateOrder(It.IsAny<OrderEntity>()));
        }

        [Fact]
        public void CreateOrderTest_With_ValidInValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqOrderReposistory;
            moqDbContext.Setup(x => x.CreateOrder(It.IsAny<OrderEntity>())).ReturnsAsync(0);
            var createOrderCommandHandler = new CreateOrderCommand(moqDbContext.Object, _moqMapper.Object);
            var response = createOrderCommandHandler.Handle(new OrderDto(), default);
            response.Should().NotBeNull();
            response.Result.Should().Be(0);
            moqDbContext.Setup(s => s.CreateOrder(It.IsAny<OrderEntity>()));
        }
    }
}