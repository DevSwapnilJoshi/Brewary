using AutoMapper;
using EGlossary.Service.Features.OrderFeatures.Commands;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using Xunit;
using static EGlossary.Service.Features.OrderFeatures.Commands.DeleteOrderCommandHandler;

namespace EGlossary.UnitTest.Services.OrderService.Commands
{
    public class DeleteOrderCommandTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        public Mock<IMapper> _moqMapper;

        public DeleteOrderCommandTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _moqMapper = new Mock<IMapper>();
        }

        [Fact]
        public void DeleteOrderTest_With_ValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqOrderReposistory;
            moqDbContext.Setup(x => x.DeleteOrder(1));
            var deleteOrderCommandHandler = new DeleteOrderCommandHandler()
            {
                Id = 1
            };
            var orderQueryHandler = new DeleteOrderByIdCommandHandler(moqDbContext.Object, _moqMapper.Object);
            var order = orderQueryHandler.Handle(deleteOrderCommandHandler, default);
            order.Id.Should().Be(order.Id);
            moqDbContext.Verify(v => v.DeleteOrder(1));
        }
    }
}