using AutoFixture;
using EGlossary.Domain.Entities;
using EGlossary.Service.Features.OrderFeatures.Queries;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static EGlossary.Service.Features.OrderFeatures.Queries.GetAllOrderQuery;
using static EGlossary.Service.Features.OrderFeatures.Queries.GetOrderByIdQuery;

namespace EGlossary.UnitTest.Services.OrderService.Queries
{
    public class GetOrderQueriesTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        private readonly GetAllOrderQuery _getAllOrderQuery;

        public GetOrderQueriesTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _getAllOrderQuery = _dbContextTest.Fixture.Create<GetAllOrderQuery>();
        }

        [Fact]
        public void GetAllOrderQueryHandler_Should_Return_OrderList_IfOrdersExists()
        {
            var moqDbContext = _dbContextTest.MoqOrderReposistory;
            moqDbContext.Setup(x => x.GetAllOrders()).ReturnsAsync(_dbContextTest.Fixture.Create<IEnumerable<OrderEntity>>);
            var orderQueryHandler = new GetAllOrderQueryHandler(moqDbContext.Object);
            var orderList = orderQueryHandler?.Handle(_getAllOrderQuery, default);
            orderList!.Result.Count().Should().BeGreaterThanOrEqualTo(1);
            moqDbContext.Verify(v => v.GetAllOrders());
        }

        [Fact]
        public void GetAllOrderQueryHandler_Return_Null_IfOrdertListIsEmpty()
        {
            var moqDbContext = _dbContextTest.MoqOrderReposistory;
            moqDbContext.Setup(x => x.GetAllOrders()).ReturnsAsync(Enumerable.Empty<OrderEntity>());
            var orderQueryHandler = new GetAllOrderQueryHandler(moqDbContext.Object);
            var orderList = orderQueryHandler?.Handle(_getAllOrderQuery, default);
            orderList!.Result.Should().BeNull();
            moqDbContext.Verify(v => v.GetAllOrders());
        }

        [Fact]
        public void GetAllOrderQueryHandler_Should_HandleNullException()
        {
            var orderQueryHandler = new GetAllOrderQueryHandler(null);
            Action act = () => orderQueryHandler?.Handle(null, default);
            act.Should().NotThrow();
        }

        [Fact]
        public void GetOrderByIdQueryHandler_Should_Return_Order_IfOrderExists()
        {
            var moqDbContext = _dbContextTest.MoqOrderReposistory;
            moqDbContext.Setup(x => x.GetOrderById(1));
            var getOrderByIdQuery = new GetOrderByIdQuery()
            {
                Id = 1
            };
            var orderQueryHandler = new GetOrderByIdQueryHandler(moqDbContext.Object);
            var order = orderQueryHandler.Handle(getOrderByIdQuery, default);
            order.Id.Should().Be(order.Id);
            moqDbContext.Verify(v => v.GetOrderById(1));
        }
    }
}